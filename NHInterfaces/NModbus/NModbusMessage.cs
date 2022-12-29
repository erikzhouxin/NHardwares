using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace System.Data.NModbus
{

    /// <summary>
    ///     Abstract Modbus message.
    /// </summary>
    internal abstract class AbstractModbusMessage
    {
        private readonly ModbusMessageImpl _messageImpl;

        /// <summary>
        ///     Abstract Modbus message.
        /// </summary>
        internal AbstractModbusMessage()
        {
            _messageImpl = new ModbusMessageImpl();
        }

        /// <summary>
        ///     Abstract Modbus message.
        /// </summary>
        internal AbstractModbusMessage(byte slaveAddress, byte functionCode)
        {
            _messageImpl = new ModbusMessageImpl(slaveAddress, functionCode);
        }

        public ushort TransactionId
        {
            get => _messageImpl.TransactionId;
            set => _messageImpl.TransactionId = value;
        }

        public byte FunctionCode
        {
            get => _messageImpl.FunctionCode;
            set => _messageImpl.FunctionCode = value;
        }

        public byte SlaveAddress
        {
            get => _messageImpl.SlaveAddress;
            set => _messageImpl.SlaveAddress = value;
        }

        public byte[] MessageFrame => _messageImpl.MessageFrame;

        public virtual byte[] ProtocolDataUnit => _messageImpl.ProtocolDataUnit;

        public abstract int MinimumFrameSize { get; }

        internal ModbusMessageImpl MessageImpl => _messageImpl;

        public void Initialize(byte[] frame)
        {
            if (frame.Length < MinimumFrameSize)
            {
                string msg = $"Message frame must contain at least {MinimumFrameSize} bytes of data.";
                throw new FormatException(msg);
            }

            _messageImpl.Initialize(frame);
            InitializeUnique(frame);
        }

        protected abstract void InitializeUnique(byte[] frame);
    }
    internal abstract class AbstractModbusMessageWithData<TData> : AbstractModbusMessage
        where TData : IModbusMessageDataCollection
    {
        internal AbstractModbusMessageWithData()
        {
        }

        internal AbstractModbusMessageWithData(byte slaveAddress, byte functionCode)
            : base(slaveAddress, functionCode)
        {
        }

        public TData Data
        {
            get => (TData)MessageImpl.Data;
            set => MessageImpl.Data = value;
        }
    }
    internal class DiagnosticsRequestResponse : AbstractModbusMessageWithData<RegisterCollection>, IModbusMessage
    {
        public DiagnosticsRequestResponse()
        {
        }

        public DiagnosticsRequestResponse(ushort subFunctionCode, byte slaveAddress, RegisterCollection data)
            : base(slaveAddress, ModbusFunctionCodes.Diagnostics)
        {
            SubFunctionCode = subFunctionCode;
            Data = data;
        }

        public override int MinimumFrameSize => 6;

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "May implement addtional sub function codes in the future.")]
        public ushort SubFunctionCode
        {
            get => MessageImpl.SubFunctionCode.Value;
            set => MessageImpl.SubFunctionCode = value;
        }

        public override string ToString()
        {
            Debug.Assert(
                SubFunctionCode == ModbusFunctionCodes.DiagnosticsReturnQueryData,
                "Need to add support for additional sub-function.");

            return $"Diagnostics message, sub-function return query data - {Data}.";
        }

        protected override void InitializeUnique(byte[] frame)
        {
            SubFunctionCode = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 2));
            Data = new RegisterCollection(frame.Slice(4, 2).ToArray());
        }
    }
    /// <summary>
    ///     Methods specific to a modbus request message.
    /// </summary>
    public interface IModbusRequest : IModbusMessage
    {
        /// <summary>
        ///     Validate the specified response against the current request.
        /// </summary>
        void ValidateResponse(IModbusMessage response);
    }
    /// <summary>
    /// Modbus message factory.
    /// </summary>
    public static class ModbusMessageFactory
    {
        /// <summary>
        /// Create a Modbus message.
        /// </summary>
        /// <typeparam name="T">Modbus message type.</typeparam>
        /// <param name="frame">Bytes of Modbus frame.</param>
        /// <returns>New Modbus message based on type and frame bytes.</returns>
        public static T CreateModbusMessage<T>(byte[] frame)
            where T : IModbusMessage, new()
        {
            //Create the message
            T message = new T();

            //initialize it
            message.Initialize(frame);

            //return it
            return message;
        }
    }
    /// <summary>
    ///     Class holding all implementation shared between two or more message types.
    ///     Interfaces expose subsets of type specific implementations.
    /// </summary>
    internal class ModbusMessageImpl
    {
        // smallest supported message frame size (sans checksum)
        private const int MinimumFrameSize = 2;


        public ModbusMessageImpl()
        {
        }

        public ModbusMessageImpl(byte slaveAddress, byte functionCode)
        {
            SlaveAddress = slaveAddress;
            FunctionCode = functionCode;
        }

        public byte? ByteCount { get; set; }

        public byte? ExceptionCode { get; set; }

        public ushort TransactionId { get; set; }

        public byte FunctionCode { get; set; }

        public ushort? NumberOfPoints { get; set; }

        public byte SlaveAddress { get; set; }

        public ushort? StartAddress { get; set; }

        public ushort? SubFunctionCode { get; set; }

        public IModbusMessageDataCollection Data { get; set; }

        public byte[] MessageFrame
        {
            get
            {
                var pdu = ProtocolDataUnit;
                var frame = new MemoryStream(1 + pdu.Length);

                frame.WriteByte(SlaveAddress);
                frame.Write(pdu, 0, pdu.Length);

                return frame.ToArray();
            }
        }

        public byte[] ProtocolDataUnit
        {
            get
            {
                List<byte> pdu = new List<byte>();

                pdu.Add(FunctionCode);

                if (ExceptionCode.HasValue)
                {
                    pdu.Add(ExceptionCode.Value);
                }

                if (SubFunctionCode.HasValue)
                {
                    pdu.AddRange(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)SubFunctionCode.Value)));
                }

                if (StartAddress.HasValue)
                {
                    pdu.AddRange(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)StartAddress.Value)));
                }

                if (NumberOfPoints.HasValue)
                {
                    pdu.AddRange(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)NumberOfPoints.Value)));
                }

                if (ByteCount.HasValue)
                {
                    pdu.Add(ByteCount.Value);
                }

                if (Data != null)
                {
                    pdu.AddRange(Data.NetworkBytes);
                }

                return pdu.ToArray();
            }
        }

        public void Initialize(byte[] frame)
        {
            if (frame == null)
            {
                throw new ArgumentNullException(nameof(frame), "Argument frame cannot be null.");
            }

            if (frame.Length < MinimumFrameSize)
            {
                string msg = $"Message frame must contain at least {MinimumFrameSize} bytes of data.";
                throw new FormatException(msg);
            }

            SlaveAddress = frame[0];
            FunctionCode = frame[1];
        }
    }
    internal class ReadCoilsInputsRequest : AbstractModbusMessage, IModbusRequest
    {
        public ReadCoilsInputsRequest()
        {
        }

        public ReadCoilsInputsRequest(byte functionCode, byte slaveAddress, ushort startAddress, ushort numberOfPoints)
            : base(slaveAddress, functionCode)
        {
            StartAddress = startAddress;
            NumberOfPoints = numberOfPoints;
        }

        public ushort StartAddress
        {
            get => MessageImpl.StartAddress.Value;
            set => MessageImpl.StartAddress = value;
        }

        public override int MinimumFrameSize => 6;

        public ushort NumberOfPoints
        {
            get => MessageImpl.NumberOfPoints.Value;

            set
            {
                if (value > Modbus.MaximumDiscreteRequestResponseSize)
                {
                    string msg = $"Maximum amount of data {Modbus.MaximumDiscreteRequestResponseSize} coils.";
                    throw new ArgumentOutOfRangeException(nameof(NumberOfPoints), msg);
                }

                MessageImpl.NumberOfPoints = value;
            }
        }

        public override string ToString()
        {
            string msg = $"Read {NumberOfPoints} {(FunctionCode == ModbusFunctionCodes.ReadCoils ? "coils" : "inputs")} starting at address {StartAddress}.";
            return msg;
        }

        public void ValidateResponse(IModbusMessage response)
        {
            var typedResponse = (ReadCoilsInputsResponse)response;

            // best effort validation - the same response for a request for 1 vs 6 coils (same byte count) will pass validation.
            var expectedByteCount = (NumberOfPoints + 7) / 8;

            if (expectedByteCount != typedResponse.ByteCount)
            {
                string msg = $"Unexpected byte count. Expected {expectedByteCount}, received {typedResponse.ByteCount}.";
                throw new IOException(msg);
            }
        }

        protected override void InitializeUnique(byte[] frame)
        {
            StartAddress = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 2));
            NumberOfPoints = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 4));
        }
    }
    internal class ReadCoilsInputsResponse : AbstractModbusMessageWithData<DiscreteCollection>, IModbusMessage
    {
        public ReadCoilsInputsResponse()
        {
        }

        public ReadCoilsInputsResponse(byte functionCode, byte slaveAddress, byte byteCount, DiscreteCollection data)
            : base(slaveAddress, functionCode)
        {
            ByteCount = byteCount;
            Data = data;
        }

        public byte ByteCount
        {
            get => MessageImpl.ByteCount.Value;
            set => MessageImpl.ByteCount = value;
        }

        public override int MinimumFrameSize => 3;

        public override string ToString()
        {
            string msg = $"Read {Data.Count()} {(FunctionCode == ModbusFunctionCodes.ReadInputs ? "inputs" : "coils")} - {Data}.";
            return msg;
        }

        protected override void InitializeUnique(byte[] frame)
        {
            if (frame.Length < 3 + frame[2])
            {
                throw new FormatException("Message frame data segment does not contain enough bytes.");
            }

            ByteCount = frame[2];
            Data = new DiscreteCollection(frame.Slice(3, ByteCount).ToArray());
        }
    }
    internal class ReadHoldingInputRegistersRequest : AbstractModbusMessage, IModbusRequest
    {
        public ReadHoldingInputRegistersRequest()
        {
        }

        public ReadHoldingInputRegistersRequest(byte functionCode, byte slaveAddress, ushort startAddress, ushort numberOfPoints)
            : base(slaveAddress, functionCode)
        {
            StartAddress = startAddress;
            NumberOfPoints = numberOfPoints;
        }

        public ushort StartAddress
        {
            get => MessageImpl.StartAddress.Value;
            set => MessageImpl.StartAddress = value;
        }

        public override int MinimumFrameSize => 6;

        public ushort NumberOfPoints
        {
            get => MessageImpl.NumberOfPoints.Value;

            set
            {
                if (value > Modbus.MaximumRegisterRequestResponseSize)
                {
                    string msg = $"Maximum amount of data {Modbus.MaximumRegisterRequestResponseSize} registers.";
                    throw new ArgumentOutOfRangeException(nameof(NumberOfPoints), msg);
                }

                MessageImpl.NumberOfPoints = value;
            }
        }

        public override string ToString()
        {
            string msg = $"Read {NumberOfPoints} {(FunctionCode == ModbusFunctionCodes.ReadHoldingRegisters ? "holding" : "input")} registers starting at address {StartAddress}.";
            return msg;
        }

        public void ValidateResponse(IModbusMessage response)
        {
            var typedResponse = response as ReadHoldingInputRegistersResponse;
            Debug.Assert(typedResponse != null, "Argument response should be of type ReadHoldingInputRegistersResponse.");
            var expectedByteCount = NumberOfPoints * 2;

            if (expectedByteCount != typedResponse.ByteCount)
            {
                string msg = $"Unexpected byte count. Expected {expectedByteCount}, received {typedResponse.ByteCount}.";
                throw new IOException(msg);
            }
        }

        protected override void InitializeUnique(byte[] frame)
        {
            StartAddress = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 2));
            NumberOfPoints = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 4));
        }
    }
    internal class ReadHoldingInputRegistersResponse : AbstractModbusMessageWithData<RegisterCollection>, IModbusMessage
    {
        public ReadHoldingInputRegistersResponse()
        {
        }

        public ReadHoldingInputRegistersResponse(byte functionCode, byte slaveAddress, RegisterCollection data)
            : base(slaveAddress, functionCode)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            ByteCount = data.ByteCount;
            Data = data;
        }

        public byte ByteCount
        {
            get => MessageImpl.ByteCount.Value;
            set => MessageImpl.ByteCount = value;
        }

        public override int MinimumFrameSize => 3;

        public override string ToString()
        {
            string msg = $"Read {Data.Count} {(FunctionCode == ModbusFunctionCodes.ReadHoldingRegisters ? "holding" : "input")} registers.";
            return msg;
        }

        protected override void InitializeUnique(byte[] frame)
        {
            if (frame.Length < MinimumFrameSize + frame[2])
            {
                throw new FormatException("Message frame does not contain enough bytes.");
            }

            ByteCount = frame[2];
            Data = new RegisterCollection(frame.Slice(3, ByteCount).ToArray());
        }
    }
    internal class ReadWriteMultipleRegistersRequest : AbstractModbusMessageWithData<RegisterCollection>, IModbusRequest
    {
        private ReadHoldingInputRegistersRequest _readRequest;
        private WriteMultipleRegistersRequest _writeRequest;

        public ReadWriteMultipleRegistersRequest()
        {
        }

        public ReadWriteMultipleRegistersRequest(
            byte slaveAddress,
            ushort startReadAddress,
            ushort numberOfPointsToRead,
            ushort startWriteAddress,
            RegisterCollection writeData)
            : base(slaveAddress, ModbusFunctionCodes.ReadWriteMultipleRegisters)
        {
            _readRequest = new ReadHoldingInputRegistersRequest(
                ModbusFunctionCodes.ReadHoldingRegisters,
                slaveAddress,
                startReadAddress,
                numberOfPointsToRead);

            _writeRequest = new WriteMultipleRegistersRequest(
                slaveAddress,
                startWriteAddress,
                writeData);

            // TODO: ugly hack for all ModbusSerialTransport-inheritances (ModbusIpTransport would not need this, as it implements complete different BuildMessageFrame)

            // fake ByteCount, Data can hold only even number of bytes
            ByteCount = (ProtocolDataUnit[1]);

            // fake Data, as this modbusmessage does not fit ModbusMessageImpl
            Data = new RegisterCollection(ProtocolDataUnit.Slice(2, ProtocolDataUnit.Length - 2).ToArray());
        }

        public byte ByteCount
        {
            get => MessageImpl.ByteCount.Value;
            set => MessageImpl.ByteCount = value;
        }

        public override byte[] ProtocolDataUnit
        {
            get
            {
                byte[] readPdu = _readRequest.ProtocolDataUnit;
                byte[] writePdu = _writeRequest.ProtocolDataUnit;
                var stream = new MemoryStream(readPdu.Length + writePdu.Length);

                stream.WriteByte(FunctionCode);

                // read and write PDUs without function codes
                stream.Write(readPdu, 1, readPdu.Length - 1);
                stream.Write(writePdu, 1, writePdu.Length - 1);

                return stream.ToArray();
            }
        }

        public ReadHoldingInputRegistersRequest ReadRequest => _readRequest;

        public WriteMultipleRegistersRequest WriteRequest => _writeRequest;

        public override int MinimumFrameSize => 11;

        public override string ToString()
        {
            string msg = $"Write {_writeRequest.NumberOfPoints} holding registers starting at address {_writeRequest.StartAddress}, and read {_readRequest.NumberOfPoints} registers starting at address {_readRequest.StartAddress}.";
            return msg;
        }

        public void ValidateResponse(IModbusMessage response)
        {
            var typedResponse = (ReadHoldingInputRegistersResponse)response;
            var expectedByteCount = ReadRequest.NumberOfPoints * 2;

            if (expectedByteCount != typedResponse.ByteCount)
            {
                string msg = $"Unexpected byte count in response. Expected {expectedByteCount}, received {typedResponse.ByteCount}.";
                throw new IOException(msg);
            }
        }

        protected override void InitializeUnique(byte[] frame)
        {
            if (frame.Length < MinimumFrameSize + frame[10])
            {
                throw new FormatException("Message frame does not contain enough bytes.");
            }

            byte[] readFrame = new byte[2 + 4];
            byte[] writeFrame = new byte[frame.Length - 6 + 2];

            readFrame[0] = writeFrame[0] = SlaveAddress;
            readFrame[1] = writeFrame[1] = FunctionCode;

            Buffer.BlockCopy(frame, 2, readFrame, 2, 4);
            Buffer.BlockCopy(frame, 6, writeFrame, 2, frame.Length - 6);

            _readRequest = ModbusMessageFactory.CreateModbusMessage<ReadHoldingInputRegistersRequest>(readFrame);
            _writeRequest = ModbusMessageFactory.CreateModbusMessage<WriteMultipleRegistersRequest>(writeFrame);
        }
    }
    internal class SlaveExceptionResponse : AbstractModbusMessage, IModbusMessage
    {
        private static readonly Dictionary<byte, string> _exceptionMessages = CreateExceptionMessages();

        public SlaveExceptionResponse()
        {
        }

        public SlaveExceptionResponse(byte slaveAddress, byte functionCode, byte exceptionCode)
            : base(slaveAddress, functionCode)
        {
            SlaveExceptionCode = exceptionCode;
        }

        public override int MinimumFrameSize => 3;

        public byte SlaveExceptionCode
        {
            get => MessageImpl.ExceptionCode.Value;
            set => MessageImpl.ExceptionCode = value;
        }

        /// <summary>
        ///     Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            string msg = _exceptionMessages.ContainsKey(SlaveExceptionCode)
                ? _exceptionMessages[SlaveExceptionCode]
                : Resources.Unknown;

            return string.Format(
                CultureInfo.InvariantCulture,
                Resources.SlaveExceptionResponseFormat,
                Environment.NewLine,
                FunctionCode,
                SlaveExceptionCode,
                msg);
        }

        internal static Dictionary<byte, string> CreateExceptionMessages()
        {
            return new Dictionary<byte, string>(9)
            {
                {1, Resources.IllegalFunction},
                {2, Resources.IllegalDataAddress},
                {3, Resources.IllegalDataValue},
                {4, Resources.SlaveDeviceFailure},
                {5, Resources.Acknowlege},
                {6, Resources.SlaveDeviceBusy},
                {8, Resources.MemoryParityError},
                {10, Resources.GatewayPathUnavailable},
                {11, Resources.GatewayTargetDeviceFailedToRespond}
            };
        }

        protected override void InitializeUnique(byte[] frame)
        {
            if (FunctionCode <= Modbus.ExceptionOffset)
            {
                throw new FormatException(Resources.SlaveExceptionResponseInvalidFunctionCode);
            }

            SlaveExceptionCode = frame[2];
        }
    }
    internal class WriteFileRecordRequest : AbstractModbusMessageWithData<FileRecordCollection>, IModbusRequest
    {
        public WriteFileRecordRequest()
        {
        }

        public WriteFileRecordRequest(byte slaveAdress, FileRecordCollection data)
            : base(slaveAdress, ModbusFunctionCodes.WriteFileRecord)
        {
            Data = data;
            ByteCount = data.ByteCount;
        }

        public override int MinimumFrameSize => 10;

        public byte ByteCount
        {
            get => MessageImpl.ByteCount.Value;
            set => MessageImpl.ByteCount = value;
        }

        public void ValidateResponse(IModbusMessage response)
        {
            var typedResponse = (WriteFileRecordResponse)response;

            if (Data.FileNumber != typedResponse.Data.FileNumber)
            {
                string msg = $"Unexpected file number in response. Expected {Data.FileNumber}, received {typedResponse.Data.FileNumber}.";
                throw new IOException(msg);
            }

            if (Data.StartingAddress != typedResponse.Data.StartingAddress)
            {
                string msg = $"Unexpected starting address in response. Expected {Data.StartingAddress}, received {typedResponse.Data.StartingAddress}.";
                throw new IOException(msg);
            }
        }

        protected override void InitializeUnique(byte[] frame)
        {
            if (frame.Length < frame[2])
            {
                throw new FormatException("Message frame does not contain enough bytes.");
            }

            ByteCount = frame[2];
            Data = new FileRecordCollection(frame);
        }

        public override string ToString()
        {
            string msg = $"Write {Data.DataBytes.Count} bytes for file {Data.FileNumber} starting at address {Data.StartingAddress}.";
            return msg;
        }
    }
    class WriteFileRecordResponse : AbstractModbusMessageWithData<FileRecordCollection>, IModbusMessage
    {
        public WriteFileRecordResponse()
        {
        }

        public WriteFileRecordResponse(byte slaveAddress)
            : base(slaveAddress, ModbusFunctionCodes.WriteFileRecord)
        {
        }

        public WriteFileRecordResponse(byte slaveAddress, FileRecordCollection data)
            : base(slaveAddress, ModbusFunctionCodes.WriteFileRecord)
        {
            Data = data;
        }

        public override int MinimumFrameSize => 10;

        public byte ByteCount
        {
            get => MessageImpl.ByteCount.Value;
            set => MessageImpl.ByteCount = value;
        }

        protected override void InitializeUnique(byte[] frame)
        {
            if (frame.Length < frame[2])
            {
                throw new FormatException("Message frame does not contain enough bytes.");
            }

            ByteCount = frame[2];
            Data = new FileRecordCollection(frame);
        }

        public override string ToString()
        {
            string msg = $"Wrote {Data.DataBytes.Count} bytes for file {Data.FileNumber} starting at address {Data.StartingAddress}.";
            return msg;
        }
    }
    /// <summary>
    ///     Write Multiple Coils request.
    /// </summary>
    internal class WriteMultipleCoilsRequest : AbstractModbusMessageWithData<DiscreteCollection>, IModbusRequest
    {
        /// <summary>
        ///     Write Multiple Coils request.
        /// </summary>
        public WriteMultipleCoilsRequest()
        {
        }

        /// <summary>
        ///     Write Multiple Coils request.
        /// </summary>
        public WriteMultipleCoilsRequest(byte slaveAddress, ushort startAddress, DiscreteCollection data)
            : base(slaveAddress, ModbusFunctionCodes.WriteMultipleCoils)
        {
            StartAddress = startAddress;
            NumberOfPoints = (ushort)data.Count;
            ByteCount = (byte)((data.Count + 7) / 8);
            Data = data;
        }

        public byte ByteCount
        {
            get => MessageImpl.ByteCount.Value;
            set => MessageImpl.ByteCount = value;
        }

        public ushort NumberOfPoints
        {
            get => MessageImpl.NumberOfPoints.Value;

            set
            {
                if (value > Modbus.MaximumDiscreteRequestResponseSize)
                {
                    string msg = $"Maximum amount of data {Modbus.MaximumDiscreteRequestResponseSize} coils.";
                    throw new ArgumentOutOfRangeException("NumberOfPoints", msg);
                }

                MessageImpl.NumberOfPoints = value;
            }
        }

        public ushort StartAddress
        {
            get => MessageImpl.StartAddress.Value;
            set => MessageImpl.StartAddress = value;
        }

        public override int MinimumFrameSize => 7;

        public override string ToString()
        {
            string msg = $"Write {NumberOfPoints} coils starting at address {StartAddress}.";
            return msg;
        }

        public void ValidateResponse(IModbusMessage response)
        {
            var typedResponse = (WriteMultipleCoilsResponse)response;

            if (StartAddress != typedResponse.StartAddress)
            {
                string msg = $"Unexpected start address in response. Expected {StartAddress}, received {typedResponse.StartAddress}.";
                throw new IOException(msg);
            }

            if (NumberOfPoints != typedResponse.NumberOfPoints)
            {
                string msg = $"Unexpected number of points in response. Expected {NumberOfPoints}, received {typedResponse.NumberOfPoints}.";
                throw new IOException(msg);
            }
        }

        protected override void InitializeUnique(byte[] frame)
        {
            if (frame.Length < MinimumFrameSize + frame[6])
            {
                throw new FormatException("Message frame does not contain enough bytes.");
            }

            StartAddress = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 2));
            NumberOfPoints = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 4));
            ByteCount = frame[6];
            Data = new DiscreteCollection(frame.Slice(7, ByteCount).ToArray());
        }
    }
    internal class WriteMultipleCoilsResponse : AbstractModbusMessage, IModbusMessage
    {
        public WriteMultipleCoilsResponse()
        {
        }

        public WriteMultipleCoilsResponse(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
            : base(slaveAddress, ModbusFunctionCodes.WriteMultipleCoils)
        {
            StartAddress = startAddress;
            NumberOfPoints = numberOfPoints;
        }

        public ushort NumberOfPoints
        {
            get => MessageImpl.NumberOfPoints.Value;

            set
            {
                if (value > Modbus.MaximumDiscreteRequestResponseSize)
                {
                    string msg = $"Maximum amount of data {Modbus.MaximumDiscreteRequestResponseSize} coils.";
                    throw new ArgumentOutOfRangeException("NumberOfPoints", msg);
                }

                MessageImpl.NumberOfPoints = value;
            }
        }

        public ushort StartAddress
        {
            get => MessageImpl.StartAddress.Value;
            set => MessageImpl.StartAddress = value;
        }

        public override int MinimumFrameSize => 6;

        public override string ToString()
        {
            string msg = $"Wrote {NumberOfPoints} coils starting at address {StartAddress}.";
            return msg;
        }

        protected override void InitializeUnique(byte[] frame)
        {
            StartAddress = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 2));
            NumberOfPoints = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 4));
        }
    }
    internal class WriteMultipleRegistersRequest : AbstractModbusMessageWithData<RegisterCollection>, IModbusRequest
    {
        public WriteMultipleRegistersRequest()
        {
        }

        public WriteMultipleRegistersRequest(byte slaveAddress, ushort startAddress, RegisterCollection data)
            : base(slaveAddress, ModbusFunctionCodes.WriteMultipleRegisters)
        {
            StartAddress = startAddress;
            NumberOfPoints = (ushort)data.Count;
            ByteCount = (byte)(data.Count * 2);
            Data = data;
        }

        public byte ByteCount
        {
            get => MessageImpl.ByteCount.Value;
            set => MessageImpl.ByteCount = value;
        }

        public ushort NumberOfPoints
        {
            get => MessageImpl.NumberOfPoints.Value;

            set
            {
                if (value > Modbus.MaximumRegisterRequestResponseSize)
                {
                    string msg = $"Maximum amount of data {Modbus.MaximumRegisterRequestResponseSize} registers.";
                    throw new ArgumentOutOfRangeException(nameof(NumberOfPoints), msg);
                }

                MessageImpl.NumberOfPoints = value;
            }
        }

        public ushort StartAddress
        {
            get => MessageImpl.StartAddress.Value;
            set => MessageImpl.StartAddress = value;
        }

        public override int MinimumFrameSize => 7;

        public override string ToString()
        {
            string msg = $"Write {NumberOfPoints} holding registers starting at address {StartAddress}.";
            return msg;
        }

        public void ValidateResponse(IModbusMessage response)
        {
            var typedResponse = (WriteMultipleRegistersResponse)response;

            if (StartAddress != typedResponse.StartAddress)
            {
                string msg = $"Unexpected start address in response. Expected {StartAddress}, received {typedResponse.StartAddress}.";
                throw new IOException(msg);
            }

            if (NumberOfPoints != typedResponse.NumberOfPoints)
            {
                string msg = $"Unexpected number of points in response. Expected {NumberOfPoints}, received {typedResponse.NumberOfPoints}.";
                throw new IOException(msg);
            }
        }

        protected override void InitializeUnique(byte[] frame)
        {
            if (frame.Length < MinimumFrameSize + frame[6])
            {
                throw new FormatException("Message frame does not contain enough bytes.");
            }

            StartAddress = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 2));
            NumberOfPoints = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 4));
            ByteCount = frame[6];
            Data = new RegisterCollection(frame.Slice(7, ByteCount).ToArray());
        }
    }
    internal class WriteMultipleRegistersResponse : AbstractModbusMessage, IModbusMessage
    {
        public WriteMultipleRegistersResponse()
        {
        }

        public WriteMultipleRegistersResponse(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
            : base(slaveAddress, ModbusFunctionCodes.WriteMultipleRegisters)
        {
            StartAddress = startAddress;
            NumberOfPoints = numberOfPoints;
        }

        public ushort NumberOfPoints
        {
            get => MessageImpl.NumberOfPoints.Value;

            set
            {
                if (value > Modbus.MaximumRegisterRequestResponseSize)
                {
                    string msg = $"Maximum amount of data {Modbus.MaximumRegisterRequestResponseSize} registers.";
                    throw new ArgumentOutOfRangeException(nameof(NumberOfPoints), msg);
                }

                MessageImpl.NumberOfPoints = value;
            }
        }

        public ushort StartAddress
        {
            get => MessageImpl.StartAddress.Value;
            set => MessageImpl.StartAddress = value;
        }

        public override int MinimumFrameSize => 6;

        public override string ToString()
        {
            string msg = $"Wrote {NumberOfPoints} holding registers starting at address {StartAddress}.";
            return msg;
        }

        protected override void InitializeUnique(byte[] frame)
        {
            StartAddress = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 2));
            NumberOfPoints = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 4));
        }
    }
    internal class WriteSingleCoilRequestResponse : AbstractModbusMessageWithData<RegisterCollection>, IModbusRequest
    {
        public WriteSingleCoilRequestResponse()
        {
        }

        public WriteSingleCoilRequestResponse(byte slaveAddress, ushort startAddress, bool coilState)
            : base(slaveAddress, ModbusFunctionCodes.WriteSingleCoil)
        {
            StartAddress = startAddress;
            Data = new RegisterCollection(coilState ? Modbus.CoilOn : Modbus.CoilOff);
        }

        public override int MinimumFrameSize => 6;

        public ushort StartAddress
        {
            get => MessageImpl.StartAddress.Value;
            set => MessageImpl.StartAddress = value;
        }

        public override string ToString()
        {
            Debug.Assert(Data != null, "Argument Data cannot be null.");
            Debug.Assert(Data.Count() == 1, "Data should have a count of 1.");

            string msg = $"Write single coil {(Data.First() == Modbus.CoilOn ? 1 : 0)} at address {StartAddress}.";
            return msg;
        }

        public void ValidateResponse(IModbusMessage response)
        {
            var typedResponse = (WriteSingleCoilRequestResponse)response;

            if (StartAddress != typedResponse.StartAddress)
            {
                string msg = $"Unexpected start address in response. Expected {StartAddress}, received {typedResponse.StartAddress}.";
                throw new IOException(msg);
            }

            if (Data.First() != typedResponse.Data.First())
            {
                string msg = $"Unexpected data in response. Expected {Data.First()}, received {typedResponse.Data.First()}.";
                throw new IOException(msg);
            }
        }

        protected override void InitializeUnique(byte[] frame)
        {
            StartAddress = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 2));
            Data = new RegisterCollection(frame.Slice(4, 2).ToArray());
        }
    }
    internal class WriteSingleRegisterRequestResponse : AbstractModbusMessageWithData<RegisterCollection>, IModbusRequest
    {
        public WriteSingleRegisterRequestResponse()
        {
        }

        public WriteSingleRegisterRequestResponse(byte slaveAddress, ushort startAddress, ushort registerValue)
            : base(slaveAddress, ModbusFunctionCodes.WriteSingleRegister)
        {
            StartAddress = startAddress;
            Data = new RegisterCollection(registerValue);
        }

        public override int MinimumFrameSize => 6;

        public ushort StartAddress
        {
            get => MessageImpl.StartAddress.Value;
            set => MessageImpl.StartAddress = value;
        }

        public override string ToString()
        {
            Debug.Assert(Data != null, "Argument Data cannot be null.");
            Debug.Assert(Data.Count() == 1, "Data should have a count of 1.");

            string msg = $"Write single holding register {Data[0]} at address {StartAddress}.";
            return msg;
        }

        public void ValidateResponse(IModbusMessage response)
        {
            var typedResponse = (WriteSingleRegisterRequestResponse)response;

            if (StartAddress != typedResponse.StartAddress)
            {
                string msg = $"Unexpected start address in response. Expected {StartAddress}, received {typedResponse.StartAddress}.";
                throw new IOException(msg);
            }

            if (Data.First() != typedResponse.Data.First())
            {
                string msg = $"Unexpected data in response. Expected {Data.First()}, received {typedResponse.Data.First()}.";
                throw new IOException(msg);
            }
        }

        protected override void InitializeUnique(byte[] frame)
        {
            StartAddress = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 2));
            Data = new RegisterCollection((ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 4)));
        }
    }
}
