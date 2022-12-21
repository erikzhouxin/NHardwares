using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.NModbus
{
    /// <summary>
    /// 空传输
    /// </summary>
    internal class EmptyTransport : ModbusTransport
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="modbusFactory"></param>
        public EmptyTransport(IModbusFactory modbusFactory)
            : base(modbusFactory, NullModbusLogger.Instance)
        {
        }
        /// <summary>
        /// 读请求
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override byte[] ReadRequest()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 读响应
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override IModbusMessage ReadResponse<T>()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 创建消息帧
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override byte[] BuildMessageFrame(IModbusMessage message)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 写
        /// </summary>
        /// <param name="message"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Write(IModbusMessage message)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 成功返回
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <exception cref="NotImplementedException"></exception>
        internal override void OnValidateResponse(IModbusMessage request, IModbusMessage response)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// 流资源接口
    /// Represents a serial resource.
    /// Implementor - http://en.wikipedia.org/wiki/Bridge_Pattern
    /// </summary>
    public interface IStreamResource : IDisposable
    {
        /// <summary>
        /// 表示不发生超时
        /// Indicates that no timeout should occur.
        /// </summary>
        int InfiniteTimeout { get; }

        /// <summary>
        /// 获取或设置读取操作未完成时发生超时之前的毫秒数
        /// Gets or sets the number of milliseconds before a timeout occurs when a read operation does not finish.
        /// </summary>
        int ReadTimeout { get; set; }

        /// <summary>
        /// 获取或设置写入操作未完成时发生超时之前的毫秒数
        /// Gets or sets the number of milliseconds before a timeout occurs when a write operation does not finish.
        /// </summary>
        int WriteTimeout { get; set; }

        /// <summary>
        /// 清除接收缓冲区
        /// Purges the receive buffer.
        /// </summary>
        void DiscardInBuffer();

        /// <summary>
        /// 从输入缓冲区读取一定数量的字节，并将这些字节写入指定偏移位置的字节数组
        /// Reads a number of bytes from the input buffer and writes those bytes into a byte array at the specified offset.
        /// </summary>
        /// <param name="buffer">The byte array to write the input to.</param>
        /// <param name="offset">The offset in the buffer array to begin writing.</param>
        /// <param name="count">The number of bytes to read.</param>
        /// <returns>The number of bytes read.</returns>
        int Read(byte[] buffer, int offset, int count);

        /// <summary>
        ///     Writes a specified number of bytes to the port from an output buffer, starting at the specified offset.
        /// </summary>
        /// <param name="buffer">The byte array that contains the data to write to the port.</param>
        /// <param name="offset">The offset in the buffer array to begin writing.</param>
        /// <param name="count">The number of bytes to write.</param>
        void Write(byte[] buffer, int offset, int count);
    }
    /// <summary>
    ///     Refined Abstraction - http://en.wikipedia.org/wiki/Bridge_Pattern
    /// </summary>
    internal class ModbusAsciiTransport : ModbusSerialTransport, IModbusAsciiTransport
    {
        internal ModbusAsciiTransport(IStreamResource streamResource, IModbusFactory modbusFactory, IModbusLogger logger)
            : base(streamResource, modbusFactory, logger)
        {
            Debug.Assert(streamResource != null, "Argument streamResource cannot be null.");
        }

        public override byte[] BuildMessageFrame(IModbusMessage message)
        {
            var msgFrame = message.MessageFrame;

            var msgFrameAscii = ModbusUtility.GetAsciiBytes(msgFrame);
            var lrcAscii = ModbusUtility.GetAsciiBytes(ModbusUtility.CalculateLrc(msgFrame));
            var nlAscii = Encoding.UTF8.GetBytes(Modbus.NewLine.ToCharArray());

            var frame = new MemoryStream(1 + msgFrameAscii.Length + lrcAscii.Length + nlAscii.Length);
            frame.WriteByte((byte)':');
            frame.Write(msgFrameAscii, 0, msgFrameAscii.Length);
            frame.Write(lrcAscii, 0, lrcAscii.Length);
            frame.Write(nlAscii, 0, nlAscii.Length);

            return frame.ToArray();
        }

        public override bool ChecksumsMatch(IModbusMessage message, byte[] messageFrame)
        {
            return ModbusUtility.CalculateLrc(message.MessageFrame) == messageFrame[messageFrame.Length - 1];
        }

        public override byte[] ReadRequest()
        {
            return ReadRequestResponse();
        }

        public override IModbusMessage ReadResponse<T>()
        {
            return CreateResponse<T>(ReadRequestResponse());
        }

        internal byte[] ReadRequestResponse()
        {
            // read message frame, removing frame start ':'
            string frameHex = StreamResourceUtility.ReadLine(StreamResource).Substring(1);

            // convert hex to bytes
            byte[] frame = ModbusUtility.HexToBytes(frameHex);
            Logger.Trace($"RX: {string.Join(", ", frame)}");

            if (frame.Length < 3)
            {
                throw new IOException("Premature end of stream, message truncated.");
            }

            return frame;
        }

        public override void IgnoreResponse()
        {
            ReadRequestResponse();
        }
    }
    /// <summary>
    ///     Transport for Internet protocols.
    ///     Refined Abstraction - http://en.wikipedia.org/wiki/Bridge_Pattern
    /// </summary>
    internal class ModbusIpTransport : ModbusTransport
    {
        private static readonly object _transactionIdLock = new object();
        private ushort _transactionId;

        internal ModbusIpTransport(IStreamResource streamResource, IModbusFactory modbusFactory, IModbusLogger logger)
            : base(streamResource, modbusFactory, logger)
        {
            if (streamResource == null) throw new ArgumentNullException(nameof(streamResource));
        }

        internal static byte[] ReadRequestResponse(IStreamResource streamResource, IModbusLogger logger)
        {
            if (streamResource == null) throw new ArgumentNullException(nameof(streamResource));
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            // read header
            var mbapHeader = new byte[6];
            int numBytesRead = 0;

            while (numBytesRead != 6)
            {
                int bRead = streamResource.Read(mbapHeader, numBytesRead, 6 - numBytesRead);

                if (bRead == 0)
                {
                    throw new IOException("Read resulted in 0 bytes returned.");
                }

                numBytesRead += bRead;
            }

            logger.Debug($"MBAP header: {string.Join(", ", mbapHeader)}");
            var frameLength = (ushort)IPAddress.HostToNetworkOrder(BitConverter.ToInt16(mbapHeader, 4));
            logger.Debug($"{frameLength} bytes in PDU.");

            // read message
            var messageFrame = new byte[frameLength];
            numBytesRead = 0;

            while (numBytesRead != frameLength)
            {
                int bRead = streamResource.Read(messageFrame, numBytesRead, frameLength - numBytesRead);

                if (bRead == 0)
                {
                    throw new IOException("Read resulted in 0 bytes returned.");
                }

                numBytesRead += bRead;
            }

            logger.Debug($"PDU: {frameLength}");
            var frame = mbapHeader.Concat(messageFrame).ToArray();
            logger.LogFrameRx(frame);

            return frame;
        }

        internal static byte[] GetMbapHeader(IModbusMessage message)
        {
            byte[] transactionId = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)message.TransactionId));
            byte[] length = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)(message.ProtocolDataUnit.Length + 1)));

            var stream = new MemoryStream(7);
            stream.Write(transactionId, 0, transactionId.Length);
            stream.WriteByte(0);
            stream.WriteByte(0);
            stream.Write(length, 0, length.Length);
            stream.WriteByte(message.SlaveAddress);

            return stream.ToArray();
        }

        /// <summary>
        ///     Create a new transaction ID.
        /// </summary>
        internal virtual ushort GetNewTransactionId()
        {
            lock (_transactionIdLock)
            {
                _transactionId = _transactionId == ushort.MaxValue ? (ushort)1 : ++_transactionId;
            }

            return _transactionId;
        }

        internal IModbusMessage CreateMessageAndInitializeTransactionId<T>(byte[] fullFrame)
            where T : IModbusMessage, new()
        {
            byte[] mbapHeader = fullFrame.Slice(0, 6).ToArray();
            byte[] messageFrame = fullFrame.Slice(6, fullFrame.Length - 6).ToArray();

            IModbusMessage response = CreateResponse<T>(messageFrame);
            response.TransactionId = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(mbapHeader, 0));

            return response;
        }

        public override byte[] BuildMessageFrame(IModbusMessage message)
        {
            byte[] header = GetMbapHeader(message);
            byte[] pdu = message.ProtocolDataUnit;
            var messageBody = new MemoryStream(header.Length + pdu.Length);

            messageBody.Write(header, 0, header.Length);
            messageBody.Write(pdu, 0, pdu.Length);

            return messageBody.ToArray();
        }

        public override void Write(IModbusMessage message)
        {
            message.TransactionId = GetNewTransactionId();
            byte[] frame = BuildMessageFrame(message);

            Logger.LogFrameTx(frame);

            StreamResource.Write(frame, 0, frame.Length);
        }

        public override byte[] ReadRequest()
        {
            return ReadRequestResponse(StreamResource, Logger);
        }

        public override IModbusMessage ReadResponse<T>()
        {
            return CreateMessageAndInitializeTransactionId<T>(ReadRequestResponse(StreamResource, Logger));
        }

        internal override void OnValidateResponse(IModbusMessage request, IModbusMessage response)
        {
            if (request.TransactionId != response.TransactionId)
            {
                string msg = $"Response was not of expected transaction ID. Expected {request.TransactionId}, received {response.TransactionId}.";
                throw new IOException(msg);
            }
        }

        public override bool OnShouldRetryResponse(IModbusMessage request, IModbusMessage response)
        {
            if (request.TransactionId > response.TransactionId && request.TransactionId - response.TransactionId < RetryOnOldResponseThreshold)
            {
                // This response was from a previous request
                return true;
            }

            return base.OnShouldRetryResponse(request, response);
        }
    }
    /// <summary>
    ///     Refined Abstraction - http://en.wikipedia.org/wiki/Bridge_Pattern
    /// </summary>
    internal class ModbusRtuTransport : ModbusSerialTransport, IModbusRtuTransport
    {
        public const int RequestFrameStartLength = 7;

        public const int ResponseFrameStartLength = 4;

        internal ModbusRtuTransport(IStreamResource streamResource, IModbusFactory modbusFactory, IModbusLogger logger)
            : base(streamResource, modbusFactory, logger)
        {
            if (modbusFactory == null) throw new ArgumentNullException(nameof(modbusFactory));
            Debug.Assert(streamResource != null, "Argument streamResource cannot be null.");
        }

        internal int RequestBytesToRead(byte[] frameStart)
        {
            byte functionCode = frameStart[1];

            IModbusFunctionService service = ModbusFactory.GetFunctionServiceOrThrow(functionCode);

            return service.GetRtuRequestBytesToRead(frameStart);
        }

        internal int ResponseBytesToRead(byte[] frameStart)
        {
            byte functionCode = frameStart[1];

            if (functionCode > Modbus.ExceptionOffset)
            {
                return 1;
            }

            IModbusFunctionService service = ModbusFactory.GetFunctionServiceOrThrow(functionCode);

            return service.GetRtuResponseBytesToRead(frameStart);
        }

        public virtual byte[] Read(int count)
        {
            byte[] frameBytes = new byte[count];
            int numBytesRead = 0;

            while (numBytesRead != count)
            {
                numBytesRead += StreamResource.Read(frameBytes, numBytesRead, count - numBytesRead);
            }

            return frameBytes;
        }

        public override byte[] BuildMessageFrame(IModbusMessage message)
        {
            var messageFrame = message.MessageFrame;
            var crc = ModbusUtility.CalculateCrc(messageFrame);
            var messageBody = new MemoryStream(messageFrame.Length + crc.Length);

            messageBody.Write(messageFrame, 0, messageFrame.Length);
            messageBody.Write(crc, 0, crc.Length);

            return messageBody.ToArray();
        }

        public override bool ChecksumsMatch(IModbusMessage message, byte[] messageFrame)
        {
            ushort messageCrc = BitConverter.ToUInt16(messageFrame, messageFrame.Length - 2);
            ushort calculatedCrc = BitConverter.ToUInt16(ModbusUtility.CalculateCrc(message.MessageFrame), 0);

            return messageCrc == calculatedCrc;
        }

        public override IModbusMessage ReadResponse<T>()
        {
            byte[] frame = ReadResponse();

            Logger.LogFrameRx(frame);

            return CreateResponse<T>(frame);
        }

        private byte[] ReadResponse()
        {
            byte[] frameStart = Read(ResponseFrameStartLength);
            byte[] frameEnd = Read(ResponseBytesToRead(frameStart));
            byte[] frame = frameStart.Concat(frameEnd).ToArray();

            return frame;
        }

        public override void IgnoreResponse()
        {
            byte[] frame = ReadResponse();

            Logger.LogFrameIgnoreRx(frame);
        }

        public override byte[] ReadRequest()
        {
            byte[] frameStart = Read(RequestFrameStartLength);
            byte[] frameEnd = Read(RequestBytesToRead(frameStart));
            byte[] frame = frameStart.Concat(frameEnd).ToArray();

            Logger.LogFrameRx(frame);

            return frame;
        }
    }
    /// <summary>
    ///     Transport for Serial protocols.
    ///     Refined Abstraction - http://en.wikipedia.org/wiki/Bridge_Pattern
    /// </summary>
    public abstract class ModbusSerialTransport : ModbusTransport, IModbusSerialTransport
    {
        private bool _checkFrame = true;

        internal ModbusSerialTransport(IStreamResource streamResource, IModbusFactory modbusFactory, IModbusLogger logger)
            : base(streamResource, modbusFactory, logger)
        {
            Debug.Assert(streamResource != null, "Argument streamResource cannot be null.");
        }

        /// <summary>
        /// Gets or sets a value indicating whether LRC/CRC frame checking is performed on messages.
        /// </summary>
        public bool CheckFrame
        {
            get => _checkFrame;
            set => _checkFrame = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public void DiscardInBuffer()
        {
            StreamResource.DiscardInBuffer();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public override void Write(IModbusMessage message)
        {
            DiscardInBuffer();

            byte[] frame = BuildMessageFrame(message);

            Logger.LogFrameTx(frame);

            StreamResource.Write(frame, 0, frame.Length);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="frame"></param>
        /// <returns></returns>
        /// <exception cref="IOException"></exception>
        public override IModbusMessage CreateResponse<T>(byte[] frame)
        {
            IModbusMessage response = base.CreateResponse<T>(frame);

            // compare checksum
            if (CheckFrame && !ChecksumsMatch(response, frame))
            {
                string msg = $"Checksums failed to match {string.Join(", ", response.MessageFrame)} != {string.Join(", ", frame)}";
                Logger.Warning(msg);
                throw new IOException(msg);
            }

            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        public abstract void IgnoreResponse();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageFrame"></param>
        /// <returns></returns>
        public abstract bool ChecksumsMatch(IModbusMessage message, byte[] messageFrame);

        internal override void OnValidateResponse(IModbusMessage request, IModbusMessage response)
        {
            // no-op
        }
    }
    /// <summary>
    /// Modbus transport.
    /// Abstraction - http://en.wikipedia.org/wiki/Bridge_Pattern
    /// </summary>
    public abstract class ModbusTransport : IModbusTransport
    {
        private readonly object _syncLock = new object();
        private int _retries = Modbus.DefaultRetries;
        private int _waitToRetryMilliseconds = Modbus.DefaultWaitToRetryMilliseconds;
        private IStreamResource _streamResource;

        /// <summary>
        ///     This constructor is called by the NullTransport.
        /// </summary>
        internal ModbusTransport(IModbusFactory modbusFactory, IModbusLogger logger)
        {
            ModbusFactory = modbusFactory;
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        internal ModbusTransport(IStreamResource streamResource, IModbusFactory modbusFactory, IModbusLogger logger)
            : this(modbusFactory, logger)
        {
            _streamResource = streamResource ?? throw new ArgumentNullException(nameof(streamResource));
        }

        /// <summary>
        ///     Number of times to retry sending message after encountering a failure such as an IOException,
        ///     TimeoutException, or a corrupt message.
        /// </summary>
        public int Retries
        {
            get => _retries;
            set => _retries = value;
        }

        /// <summary>
        /// If non-zero, this will cause a second reply to be read if the first is behind the sequence number of the
        /// request by less than this number.  For example, set this to 3, and if when sending request 5, response 3 is
        /// read, we will attempt to re-read responses.
        /// </summary>
        public uint RetryOnOldResponseThreshold { get; set; }

        /// <summary>
        /// If set, Slave Busy exception causes retry count to be used.  If false, Slave Busy will cause infinite retries
        /// </summary>
        public bool SlaveBusyUsesRetryCount { get; set; }

        /// <summary>
        ///     Gets or sets the number of milliseconds the tranport will wait before retrying a message after receiving
        ///     an ACKNOWLEGE or SLAVE DEVICE BUSY slave exception response.
        /// </summary>
        public int WaitToRetryMilliseconds
        {
            get => _waitToRetryMilliseconds;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Resources.WaitRetryGreaterThanZero);
                }

                _waitToRetryMilliseconds = value;
            }
        }

        /// <summary>
        ///     Gets or sets the number of milliseconds before a timeout occurs when a read operation does not finish.
        /// </summary>
        public int ReadTimeout
        {
            get => StreamResource.ReadTimeout;
            set => StreamResource.ReadTimeout = value;
        }

        /// <summary>
        ///     Gets or sets the number of milliseconds before a timeout occurs when a write operation does not finish.
        /// </summary>
        public int WriteTimeout
        {
            get => StreamResource.WriteTimeout;
            set => StreamResource.WriteTimeout = value;
        }

        /// <summary>
        ///     Gets the stream resource.
        /// </summary>
        public IStreamResource StreamResource => _streamResource;
        /// <summary>
        /// 
        /// </summary>
        protected IModbusFactory ModbusFactory { get; }

        /// <summary>
        /// Gets the logger for this instance.
        /// </summary>
        protected IModbusLogger Logger { get; }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual T UnicastMessage<T>(IModbusMessage message)
            where T : IModbusMessage, new()
        {
            IModbusMessage response = null;
            int attempt = 1;
            bool success = false;

            do
            {
                try
                {
                    lock (_syncLock)
                    {
                        Write(message);

                        bool readAgain;
                        do
                        {
                            readAgain = false;
                            response = ReadResponse<T>();
                            var exceptionResponse = response as SlaveExceptionResponse;

                            if (exceptionResponse != null)
                            {
                                // if SlaveExceptionCode == ACKNOWLEDGE we retry reading the response without resubmitting request
                                readAgain = exceptionResponse.SlaveExceptionCode == SlaveExceptionCodes.Acknowledge;

                                if (readAgain)
                                {
                                    Logger.Debug($"Received ACKNOWLEDGE slave exception response, waiting {_waitToRetryMilliseconds} milliseconds and retrying to read response.");
                                    Sleep(WaitToRetryMilliseconds);
                                }
                                else
                                {
                                    throw new SlaveException(exceptionResponse);
                                }
                            }
                            else if (ShouldRetryResponse(message, response))
                            {
                                readAgain = true;
                            }
                        }
                        while (readAgain);
                    }

                    ValidateResponse(message, response);
                    success = true;
                }
                catch (SlaveException se)
                {
                    if (se.SlaveExceptionCode != SlaveExceptionCodes.SlaveDeviceBusy)
                    {
                        throw;
                    }

                    if (SlaveBusyUsesRetryCount && attempt++ > _retries)
                    {
                        throw;
                    }

                    Logger.Warning($"Received SLAVE_DEVICE_BUSY exception response, waiting {_waitToRetryMilliseconds} milliseconds and resubmitting request.");

                    Sleep(WaitToRetryMilliseconds);
                }
                catch (Exception e)
                {
                    if (e is SocketException || e.InnerException is SocketException)
                    {
                        throw;
                    }
                    else if (e is FormatException ||
                        e is NotImplementedException ||
                        e is TimeoutException ||
                        e is IOException)
                    {
                        Logger.Error($"{e.GetType().Name}, {(_retries - attempt + 1)} retries remaining - {e}");

                        if (attempt++ > _retries)
                        {
                            throw;
                        }

                        Sleep(WaitToRetryMilliseconds);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            while (!success);

            return (T)response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="frame"></param>
        /// <returns></returns>
        public virtual IModbusMessage CreateResponse<T>(byte[] frame)
            where T : IModbusMessage, new()
        {
            byte functionCode = frame[1];
            IModbusMessage response;

            // check for slave exception response else create message from frame
            if (functionCode > Modbus.ExceptionOffset)
            {
                response = ModbusMessageFactory.CreateModbusMessage<SlaveExceptionResponse>(frame);
            }
            else
            {
                response = ModbusMessageFactory.CreateModbusMessage<T>(frame);
            }

            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <exception cref="IOException"></exception>
        public void ValidateResponse(IModbusMessage request, IModbusMessage response)
        {
            // always check the function code and slave address, regardless of transport protocol
            if (request.FunctionCode != response.FunctionCode)
            {
                string msg = $"Received response with unexpected Function Code. Expected {request.FunctionCode}, received {response.FunctionCode}.";
                throw new IOException(msg);
            }

            if (request.SlaveAddress != response.SlaveAddress)
            {
                string msg = $"Response slave address does not match request. Expected {request.SlaveAddress}, received {response.SlaveAddress}.";
                throw new IOException(msg);
            }

            // message specific validation
            var req = request as IModbusRequest;

            if (req != null)
            {
                req.ValidateResponse(response);
            }

            OnValidateResponse(request, response);
        }

        /// <summary>
        ///     Check whether we need to attempt to read another response before processing it (e.g. response was from previous request)
        /// </summary>
        public bool ShouldRetryResponse(IModbusMessage request, IModbusMessage response)
        {
            // These checks are enforced in ValidateRequest, we don't want to retry for these
            if (request.FunctionCode != response.FunctionCode)
            {
                return false;
            }

            if (request.SlaveAddress != response.SlaveAddress)
            {
                return false;
            }

            return OnShouldRetryResponse(request, response);
        }

        /// <summary>
        ///     Provide hook to check whether receiving a response should be retried
        /// </summary>
        public virtual bool OnShouldRetryResponse(IModbusMessage request, IModbusMessage response)
        {
            return false;
        }

        /// <summary>
        ///     Provide hook to do transport level message validation.
        /// </summary>
        internal abstract void OnValidateResponse(IModbusMessage request, IModbusMessage response);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract byte[] ReadRequest();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public abstract IModbusMessage ReadResponse<T>()
            where T : IModbusMessage, new();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public abstract byte[] BuildMessageFrame(IModbusMessage message);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public abstract void Write(IModbusMessage message);

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
        ///     unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposableUtility.Dispose(ref _streamResource);
            }
        }

        private static void Sleep(int millisecondsTimeout)
        {
            TestTry.TaskDelay(millisecondsTimeout).Wait();
        }
    }
    /// <summary>
    ///     Concrete Implementor - http://en.wikipedia.org/wiki/Bridge_Pattern
    ///     This implementation is for sockets that Convert Rs485 to Ethernet.
    /// </summary>
    public class SocketAdapter : IStreamResource
    {
        private Socket _socketClient;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="socketClient"></param>
        public SocketAdapter(Socket socketClient)
        {
            Debug.Assert(socketClient != null, "Argument socketClient van not be null");
            _socketClient = socketClient;
        }
        /// <summary>
        /// 
        /// </summary>
        public int InfiniteTimeout => Timeout.Infinite;
        /// <summary>
        /// 
        /// </summary>
        public int ReadTimeout
        {
            get => _socketClient.SendTimeout;
            set => _socketClient.SendTimeout = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public int WriteTimeout
        {
            get => _socketClient.ReceiveTimeout;
            set => _socketClient.ReceiveTimeout = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public void DiscardInBuffer()
        {
            // socket does not hold buffers.
            return;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public int Read(byte[] buffer, int offset, int size)
        {
            return _socketClient.Receive(buffer, offset, size, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        public void Write(byte[] buffer, int offset, int size)
        {
            _socketClient.Send(buffer, offset, size, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposableUtility.Dispose(ref _socketClient);
            }
        }
    }
    internal static class StreamResourceUtility
    {
        internal static string ReadLine(IStreamResource stream)
        {
            var result = new StringBuilder();
            var singleByteBuffer = new byte[1];

            do
            {
                if (stream.Read(singleByteBuffer, 0, 1) == 0)
                {
                    continue;
                }

                result.Append(Encoding.UTF8.GetChars(singleByteBuffer).First());
            }
            while (!result.ToString().EndsWith(Modbus.NewLine));

            return result.ToString().Substring(0, result.Length - Modbus.NewLine.Length);
        }
    }
    /// <summary>
    ///     Concrete Implementor - http://en.wikipedia.org/wiki/Bridge_Pattern
    /// </summary>
    public class TcpClientAdapter : IStreamResource
    {
        private TcpClient _tcpClient;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tcpClient"></param>
        public TcpClientAdapter(TcpClient tcpClient)
        {
            Debug.Assert(tcpClient != null, "Argument tcpClient cannot be null.");

            _tcpClient = tcpClient;
        }
        /// <summary>
        /// 
        /// </summary>
        public int InfiniteTimeout => Timeout.Infinite;
        /// <summary>
        /// 
        /// </summary>
        public int ReadTimeout
        {
            get => _tcpClient.GetStream().ReadTimeout;
            set => _tcpClient.GetStream().ReadTimeout = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public int WriteTimeout
        {
            get => _tcpClient.GetStream().WriteTimeout;
            set => _tcpClient.GetStream().WriteTimeout = value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        public void Write(byte[] buffer, int offset, int size)
        {
            _tcpClient.GetStream().Write(buffer, offset, size);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public int Read(byte[] buffer, int offset, int size)
        {
            return _tcpClient.GetStream().Read(buffer, offset, size);
        }
        /// <summary>
        /// 
        /// </summary>
        public void DiscardInBuffer()
        {
            _tcpClient.GetStream().Flush();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposableUtility.Dispose(ref _tcpClient);
            }
        }
    }
    /// <summary>
    ///     Concrete Implementor - http://en.wikipedia.org/wiki/Bridge_Pattern
    /// </summary>
    public class UdpClientAdapter : IStreamResource
    {
        // strategy for cross platform r/w
        private const int MaxBufferSize = ushort.MaxValue;
        private UdpClient _udpClient;
        private readonly byte[] _buffer = new byte[MaxBufferSize];
        private int _bufferOffset;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="udpClient"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UdpClientAdapter(UdpClient udpClient)
        {
            if (udpClient == null)
            {
                throw new ArgumentNullException(nameof(udpClient));
            }

            _udpClient = udpClient;
        }
        /// <summary>
        /// 
        /// </summary>
        public int InfiniteTimeout => Timeout.Infinite;
        /// <summary>
        /// 
        /// </summary>
        public int ReadTimeout
        {
            get => _udpClient.Client.ReceiveTimeout;
            set => _udpClient.Client.ReceiveTimeout = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public int WriteTimeout
        {
            get => _udpClient.Client.SendTimeout;
            set => _udpClient.Client.SendTimeout = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public void DiscardInBuffer()
        {
            // no-op
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="IOException"></exception>
        public int Read(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(offset),
                    "Argument offset must be greater than or equal to 0.");
            }

            if (offset > buffer.Length)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(offset),
                    "Argument offset cannot be greater than the length of buffer.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(count),
                    "Argument count must be greater than or equal to 0.");
            }

            if (count > buffer.Length - offset)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(count),
                    "Argument count cannot be greater than the length of buffer minus offset.");
            }

            if (_bufferOffset == 0)
            {
                _bufferOffset = _udpClient.Client.Receive(_buffer);
            }

            if (_bufferOffset < count)
            {
                throw new IOException("Not enough bytes in the datagram.");
            }

            Buffer.BlockCopy(_buffer, 0, buffer, offset, count);
            _bufferOffset -= count;
            Buffer.BlockCopy(_buffer, count, _buffer, 0, _bufferOffset);

            return count;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Write(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(offset),
                    "Argument offset must be greater than or equal to 0.");
            }

            if (offset > buffer.Length)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(offset),
                    "Argument offset cannot be greater than the length of buffer.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(count),
                    "Argument count must be greater than or equal to 0.");
            }

            if (count > buffer.Length - offset)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(count),
                    "Argument count cannot be greater than the length of buffer minus offset.");
            }

            _udpClient.Client.Send(buffer.Skip(offset).Take(count).ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposableUtility.Dispose(ref _udpClient);
            }
        }
    }
}
