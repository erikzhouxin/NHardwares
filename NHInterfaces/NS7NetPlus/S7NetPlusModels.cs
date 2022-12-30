using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.NS7NetPlus
{
    /// <summary>
    /// Types of S7 cpu supported by the library
    /// </summary>
    public enum CpuType
    {
        /// <summary>
        /// S7 200 cpu type
        /// </summary>
        S7200 = 0,

        /// <summary>
        /// Siemens Logo 0BA8
        /// </summary>
        Logo0BA8 = 1,

        /// <summary>
        /// S7 200 Smart
        /// </summary>
        S7200Smart = 2,

        /// <summary>
        /// S7 300 cpu type
        /// </summary>
        S7300 = 10,

        /// <summary>
        /// S7 400 cpu type
        /// </summary>
        S7400 = 20,

        /// <summary>
        /// S7 1200 cpu type
        /// </summary>
        S71200 = 30,

        /// <summary>
        /// S7 1500 cpu type
        /// </summary>
        S71500 = 40,
    }

    /// <summary>
    /// Types of error code that can be set after a function is called
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// The function has been executed correctly
        /// </summary>
        NoError = 0,

        /// <summary>
        /// Wrong type of CPU error
        /// </summary>
        WrongCPU_Type = 1,

        /// <summary>
        /// Connection error
        /// </summary>
        ConnectionError = 2,

        /// <summary>
        /// Ip address not available
        /// </summary>
        IPAddressNotAvailable,

        /// <summary>
        /// Wrong format of the variable
        /// </summary>
        WrongVarFormat = 10,

        /// <summary>
        /// Wrong number of received bytes
        /// </summary>
        WrongNumberReceivedBytes = 11,

        /// <summary>
        /// Error on send data
        /// </summary>
        SendData = 20,

        /// <summary>
        /// Error on read data
        /// </summary>
        ReadData = 30,

        /// <summary>
        /// Error on write data
        /// </summary>
        WriteData = 50
    }

    /// <summary>
    /// Types of memory area that can be read
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// Input area memory
        /// </summary>
        Input = 129,

        /// <summary>
        /// Output area memory
        /// </summary>
        Output = 130,

        /// <summary>
        /// Merkers area memory (M0, M0.0, ...)
        /// </summary>
        Memory = 131,

        /// <summary>
        /// DB area memory (DB1, DB2, ...)
        /// </summary>
        DataBlock = 132,

        /// <summary>
        /// Timer area memory(T1, T2, ...)
        /// </summary>
        Timer = 29,

        /// <summary>
        /// Counter area memory (C1, C2, ...)
        /// </summary>
        Counter = 28
    }

    /// <summary>
    /// Types
    /// </summary>
    public enum VarType
    {
        /// <summary>
        /// S7 Bit variable type (bool)
        /// </summary>
        Bit,

        /// <summary>
        /// S7 Byte variable type (8 bits)
        /// </summary>
        Byte,

        /// <summary>
        /// S7 Word variable type (16 bits, 2 bytes)
        /// </summary>
        Word,

        /// <summary>
        /// S7 DWord variable type (32 bits, 4 bytes)
        /// </summary>
        DWord,

        /// <summary>
        /// S7 Int variable type (16 bits, 2 bytes)
        /// </summary>
        Int,

        /// <summary>
        /// DInt variable type (32 bits, 4 bytes)
        /// </summary>
        DInt,

        /// <summary>
        /// Real variable type (32 bits, 4 bytes)
        /// </summary>
        Real,

        /// <summary>
        /// LReal variable type (64 bits, 8 bytes)
        /// </summary>
        LReal,

        /// <summary>
        /// Char Array / C-String variable type (variable)
        /// </summary>
        String,

        /// <summary>
        /// S7 String variable type (variable)
        /// </summary>
        S7String,

        /// <summary>
        /// S7 WString variable type (variable)
        /// </summary>
        S7WString,

        /// <summary>
        /// Timer variable type
        /// </summary>
        Timer,

        /// <summary>
        /// Counter variable type
        /// </summary>
        Counter,

        /// <summary>
        /// DateTIme variable type
        /// </summary>
        DateTime,

        /// <summary>
        /// DateTimeLong variable type
        /// </summary>
        DateTimeLong
    }
    /// <summary>
    /// Create an instance of a memory block that can be read by using ReadMultipleVars
    /// </summary>
    public class DataItem
    {
        /// <summary>
        /// Memory area to read 
        /// </summary>
        public DataType DataType { get; set; }

        /// <summary>
        /// Type of data to be read (default is bytes)
        /// </summary>
        public VarType VarType { get; set; }

        /// <summary>
        /// Address of memory area to read (example: for DB1 this value is 1, for T45 this value is 45)
        /// </summary>
        public int DB { get; set; }

        /// <summary>
        /// Address of the first byte to read
        /// </summary>
        public int StartByteAdr { get; set; }

        /// <summary>
        /// Addess of bit to read from StartByteAdr
        /// </summary>
        public byte BitAdr { get; set; }

        /// <summary>
        /// Number of variables to read
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Contains the value of the memory area after the read has been executed
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Create an instance of DataItem
        /// </summary>
        public DataItem()
        {
            VarType = VarType.Byte;
            Count = 1;
        }

        /// <summary>
        /// Create an instance of <see cref="DataItem"/> from the supplied address.
        /// </summary>
        /// <param name="address">The address to create the DataItem for.</param>
        /// <returns>A new <see cref="DataItem"/> instance with properties parsed from <paramref name="address"/>.</returns>
        /// <remarks>The <see cref="Count" /> property is not parsed from the address.</remarks>
        public static DataItem FromAddress(string address)
        {
            PLCAddress.Parse(address, out var dataType, out var dbNumber, out var varType, out var startByte,
                out var bitNumber);

            return new DataItem
            {
                DataType = dataType,
                DB = dbNumber,
                VarType = varType,
                StartByteAdr = startByte,
                BitAdr = (byte)(bitNumber == -1 ? 0 : bitNumber)
            };
        }

        /// <summary>
        /// Create an instance of <see cref="DataItem"/> from the supplied address and value.
        /// </summary>
        /// <param name="address">The address to create the DataItem for.</param>
        /// <param name="value">The value to be applied to the DataItem.</param>
        /// <returns>A new <see cref="DataItem"/> instance with properties parsed from <paramref name="address"/> and the supplied value set.</returns>
        public static DataItem FromAddressAndValue<T>(string address, T value)
        {
            var dataItem = FromAddress(address);
            dataItem.Value = value;

            if (typeof(T).IsArray)
            {
                var array = ((Array)dataItem.Value);
                if (array != null)
                {
                    dataItem.Count = array.Length;
                }
            }

            return dataItem;
        }

        internal static DataItemAddress GetDataItemAddress(DataItem dataItem)
        {
            return new DataItemAddress(dataItem.DataType, dataItem.DB, dataItem.StartByteAdr, S7NetPlusPlc.VarTypeToByteLength(dataItem.VarType, dataItem.Count));
        }
    }
    /// <summary>
    /// 非法数据异常
    /// </summary>
    [Serializable]
    public class InvalidDataException : Exception
    {
        /// <summary>
        /// 接受数据
        /// </summary>
        public byte[] ReceivedData { get; }
        /// <summary>
        /// 错误
        /// </summary>
        public int ErrorIndex { get; }
        /// <summary>
        /// 错误值
        /// </summary>
        public byte ExpectedValue { get; }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="message"></param>
        /// <param name="receivedData"></param>
        /// <param name="errorIndex"></param>
        /// <param name="expectedValue"></param>
        public InvalidDataException(string message, byte[] receivedData, int errorIndex, byte expectedValue)
            : base(FormatMessage(message, receivedData, errorIndex, expectedValue))
        {
            ReceivedData = receivedData;
            ErrorIndex = errorIndex;
            ExpectedValue = expectedValue;
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected InvalidDataException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
            ReceivedData = (byte[])info.GetValue(nameof(ReceivedData), typeof(byte[]));
            ErrorIndex = info.GetInt32(nameof(ErrorIndex));
            ExpectedValue = info.GetByte(nameof(ExpectedValue));
        }

        private static string FormatMessage(string message, byte[] receivedData, int errorIndex, byte expectedValue)
        {
            if (errorIndex >= receivedData.Length)
                throw new ArgumentOutOfRangeException(nameof(errorIndex),
                    $"{nameof(errorIndex)} {errorIndex} is outside the bounds of {nameof(receivedData)} with length {receivedData.Length}.");

            return $"{message} Invalid data received. Expected '{expectedValue}' at index {errorIndex}, " +
                $"but received {receivedData[errorIndex]}. See the {nameof(ReceivedData)} property " +
                "for the full message received.";
        }
    }
    /// <summary>
    /// PLC异常
    /// </summary>
    [Serializable]
    public class PlcException : Exception
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public ErrorCode ErrorCode { get; }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="errorCode"></param>
        public PlcException(ErrorCode errorCode) : this(errorCode, $"PLC communication failed with error '{errorCode}'.")
        {
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="innerException"></param>
        public PlcException(ErrorCode errorCode, Exception innerException) : this(errorCode, innerException.Message,
            innerException)
        {
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        public PlcException(ErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public PlcException(ErrorCode errorCode, string message, Exception inner) : base(message, inner)
        {
            ErrorCode = errorCode;
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected PlcException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
            ErrorCode = (ErrorCode)info.GetInt32(nameof(ErrorCode));
        }
    }
    /// <summary>
    /// 字符串属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class S7StringAttribute : Attribute
    {
        private readonly S7StringType type;
        private readonly int reservedLength;

        /// <summary>
        /// Initializes a new instance of the <see cref="S7StringAttribute"/> class.
        /// </summary>
        /// <param name="type">The string type.</param>
        /// <param name="reservedLength">Reserved length of the string in characters.</param>
        /// <exception cref="ArgumentException">Please use a valid value for the string type</exception>
        public S7StringAttribute(S7StringType type, int reservedLength)
        {
            if (!Enum.IsDefined(typeof(S7StringType), type))
                throw new ArgumentException("Please use a valid value for the string type");

            this.type = type;
            this.reservedLength = reservedLength;
        }

        /// <summary>
        /// Gets the type of the string.
        /// </summary>
        /// <value>
        /// The string type.
        /// </value>
        public S7StringType Type => type;

        /// <summary>
        /// Gets the reserved length of the string in characters.
        /// </summary>
        /// <value>
        /// The reserved length of the string in characters.
        /// </value>
        public int ReservedLength => reservedLength;

        /// <summary>
        /// Gets the reserved length in bytes.
        /// </summary>
        /// <value>
        /// The reserved length in bytes.
        /// </value>
        public int ReservedLengthInBytes => type == S7StringType.S7String ? reservedLength + 2 : (reservedLength * 2) + 4;
    }
    /// <summary>
    /// String type.
    /// </summary>
    public enum S7StringType
    {
        /// <summary>
        /// ASCII string.
        /// </summary>
        S7String = VarType.S7String,

        /// <summary>
        /// Unicode string.
        /// </summary>
        S7WString = VarType.S7WString
    }
    /// <summary>
    /// Provides a representation of the Transport Service Access Point, or TSAP in short. TSAP's are used
    /// to specify a client and server address. For most PLC types a default TSAP is available that allows
    /// connection from any IP and can be calculated using the rack and slot numbers.
    /// </summary>
    public struct Tsap
    {
        /// <summary>
        /// First byte of the TSAP.
        /// </summary>
        public byte FirstByte { get; set; }

        /// <summary>
        /// Second byte of the TSAP.
        /// </summary>
        public byte SecondByte { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tsap" /> class using the specified values.
        /// </summary>
        /// <param name="firstByte">The first byte of the TSAP.</param>
        /// <param name="secondByte">The second byte of the TSAP.</param>
        public Tsap(byte firstByte, byte secondByte)
        {
            FirstByte = firstByte;
            SecondByte = secondByte;
        }
    }
    /// <summary>
    /// Implements a pair of TSAP addresses used to connect to a PLC.
    /// </summary>
    public class TsapPair
    {
        /// <summary>
        /// The local <see cref="Tsap" />.
        /// </summary>
        public Tsap Local { get; set; }

        /// <summary>
        /// The remote <see cref="Tsap" />
        /// </summary>
        public Tsap Remote { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TsapPair" /> class using the specified local and
        /// remote TSAP.
        /// </summary>
        /// <param name="local">The local TSAP.</param>
        /// <param name="remote">The remote TSAP.</param>
        public TsapPair(Tsap local, Tsap remote)
        {
            Local = local;
            Remote = remote;
        }

        /// <summary>
        /// Builds a <see cref="TsapPair" /> that can be used to connect to a PLC using the default connection
        /// addresses.
        /// </summary>
        /// <remarks>
        /// The remote TSAP is constructed using <code>new Tsap(0x03, (byte) ((rack &lt;&lt; 5) | slot))</code>.
        /// </remarks>
        /// <param name="cpuType">The CPU type of the PLC.</param>
        /// <param name="rack">The rack of the PLC's network card.</param>
        /// <param name="slot">The slot of the PLC's network card.</param>
        /// <returns>A TSAP pair that matches the given parameters.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="cpuType"/> is invalid.
        ///
        /// -or-
        ///
        /// The <paramref name="rack"/> parameter is less than 0.
        ///
        /// -or-
        ///
        /// The <paramref name="rack"/> parameter is greater than 15.
        ///
        /// -or-
        ///
        /// The <paramref name="slot"/> parameter is less than 0.
        ///
        /// -or-
        ///
        /// The <paramref name="slot"/> parameter is greater than 15.</exception>
        public static TsapPair GetDefaultTsapPair(CpuType cpuType, int rack, int slot)
        {
            if (rack < 0) throw InvalidRackOrSlot(rack, nameof(rack), "minimum", 0);
            if (rack > 0x0F) throw InvalidRackOrSlot(rack, nameof(rack), "maximum", 0x0F);

            if (slot < 0) throw InvalidRackOrSlot(slot, nameof(slot), "minimum", 0);
            if (slot > 0x0F) throw InvalidRackOrSlot(slot, nameof(slot), "maximum", 0x0F);

            switch (cpuType)
            {
                case CpuType.S7200:
                    return new TsapPair(new Tsap(0x10, 0x00), new Tsap(0x10, 0x01));
                case CpuType.Logo0BA8:
                    // The actual values are probably on a per-project basis
                    return new TsapPair(new Tsap(0x01, 0x00), new Tsap(0x01, 0x02));
                case CpuType.S7200Smart:
                case CpuType.S71200:
                case CpuType.S71500:
                case CpuType.S7300:
                case CpuType.S7400:
                    // Testing with S7 1500 shows only the remote TSAP needs to match. This might differ for other
                    // PLC types.
                    return new TsapPair(new Tsap(0x01, 0x00), new Tsap(0x03, (byte)((rack << 5) | slot)));
                default:
                    throw new ArgumentOutOfRangeException(nameof(cpuType), "Invalid CPU Type specified");
            }
        }

        private static ArgumentOutOfRangeException InvalidRackOrSlot(int value, string name, string extrema,
            int extremaValue)
        {
            return new ArgumentOutOfRangeException(name,
                $"Invalid {name} value specified (decimal: {value}, hexadecimal: {value:X}), {extrema} value " +
                $"is {extremaValue} (decimal) or {extremaValue:X} (hexadecimal).");
        }
    }
    /// <summary>
    /// 字节数组
    /// </summary>
    internal class ByteArray
    {
        readonly List<byte> list;

        public byte this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }

        public byte[] Array
        {
            get { return list.ToArray(); }
        }

        public int Length => list.Count;

        public ByteArray()
        {
            list = new List<byte>();
        }

        public ByteArray(int size)
        {
            list = new List<byte>(size);
        }

        public void Clear()
        {
            list.Clear();
        }

        public void Add(byte item)
        {
            list.Add(item);
        }

        public void AddWord(ushort value)
        {
            list.Add((byte)(value >> 8));
            list.Add((byte)value);
        }

        public void Add(byte[] items)
        {
            list.AddRange(items);
        }

        public void Add(IEnumerable<byte> items)
        {
            list.AddRange(items);
        }

        public void Add(ByteArray byteArray)
        {
            list.AddRange(byteArray.Array);
        }
    }
    /// <summary>
    /// COTP Protocol functions and types
    /// </summary>
    internal class COTP
    {
        public enum PduType : byte
        {
            Data = 0xf0,
            ConnectionConfirmed = 0xd0
        }
        /// <summary>
        /// Describes a COTP TPDU (Transport protocol data unit)
        /// </summary>
        public class TPDU
        {
            public TPKT TPkt { get; }
            public byte HeaderLength;
            public PduType PDUType;
            public int TPDUNumber;
            public byte[] Data;
            public bool LastDataUnit;

            public TPDU(TPKT tPKT)
            {
                TPkt = tPKT;

                HeaderLength = tPKT.Data[0]; // Header length excluding this length byte
                if (HeaderLength >= 2)
                {
                    PDUType = (PduType)tPKT.Data[1];
                    if (PDUType == PduType.Data) //DT Data
                    {
                        var flags = tPKT.Data[2];
                        TPDUNumber = flags & 0x7F;
                        LastDataUnit = (flags & 0x80) > 0;
                        Data = new byte[tPKT.Data.Length - HeaderLength - 1]; // substract header length byte + header length.
                        Array.Copy(tPKT.Data, HeaderLength + 1, Data, 0, Data.Length);
                        return;
                    }
                    //TODO: Handle other PDUTypes
                }
                Data = new byte[0];
            }

            /// <summary>
            /// Reads COTP TPDU (Transport protocol data unit) from the network stream
            /// See: https://tools.ietf.org/html/rfc905
            /// </summary>
            /// <param name="stream">The socket to read from</param>
            /// <param name="cancellationToken"></param>
            /// <returns>COTP DPDU instance</returns>
            public static async Task<TPDU> ReadAsync(Stream stream, CancellationToken cancellationToken)
            {
                var tpkt = await TPKT.ReadAsync(stream, cancellationToken).ConfigureAwait(false);
                if (tpkt.Length == 0)
                {
                    throw new TPDUInvalidException("No protocol data received");
                }
                return new TPDU(tpkt);
            }

            public override string ToString()
            {
                return string.Format("Length: {0} PDUType: {1} TPDUNumber: {2} Last: {3} Segment Data: {4}",
                    HeaderLength,
                    PDUType,
                    TPDUNumber,
                    LastDataUnit,
                    BitConverter.ToString(Data)
                    );
            }

        }

        /// <summary>
        /// Describes a COTP TSDU (Transport service data unit). One TSDU consist of 1 ore more TPDUs
        /// </summary>
        public class TSDU
        {
            /// <summary>
            /// Reads the full COTP TSDU (Transport service data unit)
            /// See: https://tools.ietf.org/html/rfc905
            /// </summary>
            /// <param name="stream">The stream to read from</param>
            /// <param name="cancellationToken"></param>
            /// <returns>Data in TSDU</returns>
            public static async Task<byte[]> ReadAsync(Stream stream, CancellationToken cancellationToken)
            {
                var segment = await TPDU.ReadAsync(stream, cancellationToken).ConfigureAwait(false);

                if (segment.LastDataUnit)
                {
                    return segment.Data;
                }

                // More segments are expected, prepare a buffer to store all data
                var buffer = new byte[segment.Data.Length];
                Array.Copy(segment.Data, buffer, segment.Data.Length);

                while (!segment.LastDataUnit)
                {
                    segment = await TPDU.ReadAsync(stream, cancellationToken).ConfigureAwait(false);
                    var previousLength = buffer.Length;
                    Array.Resize(ref buffer, buffer.Length + segment.Data.Length);
                    Array.Copy(segment.Data, 0, buffer, previousLength, segment.Data.Length);
                }

                return buffer;
            }
        }
    }
    /// <summary>
    /// Represents an area of memory in the PLC
    /// </summary>
    internal class DataItemAddress
    {
        public DataItemAddress(DataType dataType, int db, int startByteAddress, int byteLength)
        {
            DataType = dataType;
            DB = db;
            StartByteAddress = startByteAddress;
            ByteLength = byteLength;
        }


        /// <summary>
        /// Memory area to read 
        /// </summary>
        public DataType DataType { get; }

        /// <summary>
        /// Address of memory area to read (example: for DB1 this value is 1, for T45 this value is 45)
        /// </summary>
        public int DB { get; }

        /// <summary>
        /// Address of the first byte to read
        /// </summary>
        public int StartByteAddress { get; }

        /// <summary>
        /// Length of data to read
        /// </summary>
        public int ByteLength { get; }
    }
    /// <summary>
    /// PLC地址
    /// </summary>
    internal class PLCAddress
    {
        private DataType dataType;
        private int dbNumber;
        private int startByte;
        private int bitNumber;
        private VarType varType;

        public DataType DataType
        {
            get => dataType;
            set => dataType = value;
        }

        public int DbNumber
        {
            get => dbNumber;
            set => dbNumber = value;
        }

        public int StartByte
        {
            get => startByte;
            set => startByte = value;
        }

        public int BitNumber
        {
            get => bitNumber;
            set => bitNumber = value;
        }

        public VarType VarType
        {
            get => varType;
            set => varType = value;
        }

        public PLCAddress(string address)
        {
            Parse(address, out dataType, out dbNumber, out varType, out startByte, out bitNumber);
        }

        public static void Parse(string input, out DataType dataType, out int dbNumber, out VarType varType, out int address, out int bitNumber)
        {
            bitNumber = -1;
            dbNumber = 0;

            switch (input.Substring(0, 2))
            {
                case "DB":
                    string[] strings = input.Split(new char[] { '.' });
                    if (strings.Length < 2)
                        throw new InvalidAddressException("To few periods for DB address");

                    dataType = DataType.DataBlock;
                    dbNumber = int.Parse(strings[0].Substring(2));
                    address = int.Parse(strings[1].Substring(3));

                    string dbType = strings[1].Substring(0, 3);
                    switch (dbType)
                    {
                        case "DBB":
                            varType = VarType.Byte;
                            return;
                        case "DBW":
                            varType = VarType.Word;
                            return;
                        case "DBD":
                            varType = VarType.DWord;
                            return;
                        case "DBX":
                            bitNumber = int.Parse(strings[2]);
                            if (bitNumber > 7)
                                throw new InvalidAddressException("Bit can only be 0-7");
                            varType = VarType.Bit;
                            return;
                        default:
                            throw new InvalidAddressException();
                    }
                case "IB":
                case "EB":
                    // Input byte
                    dataType = DataType.Input;
                    dbNumber = 0;
                    address = int.Parse(input.Substring(2));
                    varType = VarType.Byte;
                    return;
                case "IW":
                case "EW":
                    // Input word
                    dataType = DataType.Input;
                    dbNumber = 0;
                    address = int.Parse(input.Substring(2));
                    varType = VarType.Word;
                    return;
                case "ID":
                case "ED":
                    // Input double-word
                    dataType = DataType.Input;
                    dbNumber = 0;
                    address = int.Parse(input.Substring(2));
                    varType = VarType.DWord;
                    return;
                case "QB":
                case "AB":
                case "OB":
                    // Output byte
                    dataType = DataType.Output;
                    dbNumber = 0;
                    address = int.Parse(input.Substring(2));
                    varType = VarType.Byte;
                    return;
                case "QW":
                case "AW":
                case "OW":
                    // Output word
                    dataType = DataType.Output;
                    dbNumber = 0;
                    address = int.Parse(input.Substring(2));
                    varType = VarType.Word;
                    return;
                case "QD":
                case "AD":
                case "OD":
                    // Output double-word
                    dataType = DataType.Output;
                    dbNumber = 0;
                    address = int.Parse(input.Substring(2));
                    varType = VarType.DWord;
                    return;
                case "MB":
                    // Memory byte
                    dataType = DataType.Memory;
                    dbNumber = 0;
                    address = int.Parse(input.Substring(2));
                    varType = VarType.Byte;
                    return;
                case "MW":
                    // Memory word
                    dataType = DataType.Memory;
                    dbNumber = 0;
                    address = int.Parse(input.Substring(2));
                    varType = VarType.Word;
                    return;
                case "MD":
                    // Memory double-word
                    dataType = DataType.Memory;
                    dbNumber = 0;
                    address = int.Parse(input.Substring(2));
                    varType = VarType.DWord;
                    return;
                default:
                    switch (input.Substring(0, 1))
                    {
                        case "E":
                        case "I":
                            // Input
                            dataType = DataType.Input;
                            varType = VarType.Bit;
                            break;
                        case "Q":
                        case "A":
                        case "O":
                            // Output
                            dataType = DataType.Output;
                            varType = VarType.Bit;
                            break;
                        case "M":
                            // Memory
                            dataType = DataType.Memory;
                            varType = VarType.Bit;
                            break;
                        case "T":
                            // Timer
                            dataType = DataType.Timer;
                            dbNumber = 0;
                            address = int.Parse(input.Substring(1));
                            varType = VarType.Timer;
                            return;
                        case "Z":
                        case "C":
                            // Counter
                            dataType = DataType.Counter;
                            dbNumber = 0;
                            address = int.Parse(input.Substring(1));
                            varType = VarType.Counter;
                            return;
                        default:
                            throw new InvalidAddressException(string.Format("{0} is not a valid address", input.Substring(0, 1)));
                    }

                    string txt2 = input.Substring(1);
                    if (txt2.IndexOf(".") == -1)
                        throw new InvalidAddressException("To few periods for DB address");

                    address = int.Parse(txt2.Substring(0, txt2.IndexOf(".")));
                    bitNumber = int.Parse(txt2.Substring(txt2.IndexOf(".") + 1));
                    if (bitNumber > 7)
                        throw new InvalidAddressException("Bit can only be 0-7");
                    return;
            }
        }
    }

    internal class WrongNumberOfBytesException : Exception
    {
        public WrongNumberOfBytesException() : base()
        {
        }

        public WrongNumberOfBytesException(string message) : base(message)
        {
        }

        public WrongNumberOfBytesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongNumberOfBytesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    internal class InvalidAddressException : Exception
    {
        public InvalidAddressException() : base()
        {
        }

        public InvalidAddressException(string message) : base(message)
        {
        }

        public InvalidAddressException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAddressException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    internal class InvalidVariableTypeException : Exception
    {
        public InvalidVariableTypeException() : base()
        {
        }

        public InvalidVariableTypeException(string message) : base(message)
        {
        }

        public InvalidVariableTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidVariableTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    internal class TPKTInvalidException : Exception
    {
        public TPKTInvalidException() : base()
        {
        }

        public TPKTInvalidException(string message) : base(message)
        {
        }

        public TPKTInvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TPKTInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    internal class TPDUInvalidException : Exception
    {
        public TPDUInvalidException() : base()
        {
        }

        public TPDUInvalidException(string message) : base(message)
        {
        }

        public TPDUInvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TPDUInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    internal enum ReadWriteErrorCode : byte
    {
        Reserved = 0x00,
        HardwareFault = 0x01,
        AccessingObjectNotAllowed = 0x03,
        AddressOutOfRange = 0x05,
        DataTypeNotSupported = 0x06,
        DataTypeInconsistent = 0x07,
        ObjectDoesNotExist = 0x0a,
        Success = 0xff
    }
    internal class TaskQueue
    {
        private static readonly object Sentinel = new object();

        private Task prev = TestTry.TaskFromResult(Sentinel);

        public async Task<T> Enqueue<T>(Func<Task<T>> action)
        {
            var tcs = new TaskCompletionSource<object>();
            await Interlocked.Exchange(ref prev, tcs.Task).ConfigureAwait(false);

            try
            {
                return await action.Invoke().ConfigureAwait(false);
            }
            finally
            {
                tcs.SetResult(Sentinel);
            }
        }
    }
    /// <summary>
    /// Describes a TPKT Packet
    /// </summary>
    internal class TPKT
    {
        public byte Version;
        public byte Reserved1;
        public int Length;
        public byte[] Data;
        private TPKT(byte version, byte reserved1, int length, byte[] data)
        {
            Version = version;
            Reserved1 = reserved1;
            Length = length;
            Data = data;
        }

        /// <summary>
        /// Reads a TPKT from the socket Async
        /// </summary>
        /// <param name="stream">The stream to read from</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task TPKT Instace</returns>
        public static async Task<TPKT> ReadAsync(Stream stream, CancellationToken cancellationToken)
        {
            var buf = new byte[4];
            int len = await stream.ReadExactAsync(buf, 0, 4, cancellationToken).ConfigureAwait(false);
            if (len < 4) throw new TPKTInvalidException("TPKT is incomplete / invalid");

            var version = buf[0];
            var reserved1 = buf[1];
            var length = buf[2] * 256 + buf[3]; //BigEndian

            var data = new byte[length - 4];
            len = await stream.ReadExactAsync(data, 0, data.Length, cancellationToken).ConfigureAwait(false);
            if (len < data.Length)
                throw new TPKTInvalidException("TPKT payload incomplete / invalid");

            return new TPKT
            (
                version: version,
                reserved1: reserved1,
                length: length,
                data: data
            );
        }

        public override string ToString()
        {
            return string.Format("Version: {0} Length: {1} Data: {2}",
                Version,
                Length,
                BitConverter.ToString(Data)
                );
        }
    }
}
