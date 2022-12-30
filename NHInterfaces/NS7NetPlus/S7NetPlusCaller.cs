using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.NS7NetPlus
{
    /// <summary>
    /// 变量类型调用
    /// </summary>
    public static class S7NetPlusCaller
    {
        #region // Conversion
        /// <summary>
        /// Converts a binary string to Int32 value
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static int BinStringToInt32(this string txt)
        {
            int ret = 0;

            for (int i = 0; i < txt.Length; i++)
            {
                ret = (ret << 1) | ((txt[i] == '1') ? 1 : 0);
            }
            return ret;
        }

        /// <summary>
        /// Converts a binary string to a byte. Can return null.
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static byte? BinStringToByte(this string txt)
        {
            if (txt.Length == 8) return (byte)BinStringToInt32(txt);
            return null;
        }

        /// <summary>
        /// Converts the value to a binary string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ValToBinString(this object value)
        {
            int cnt = 0;
            int cnt2 = 0;
            int x = 0;
            string txt = "";
            long longValue = 0;

            try
            {
                if (value.GetType().Name.IndexOf("[]") < 0)
                {
                    // ist nur ein Wert
                    switch (value.GetType().Name)
                    {
                        case "Byte":
                            x = 7;
                            longValue = (long)((byte)value);
                            break;
                        case "Int16":
                            x = 15;
                            longValue = (long)((Int16)value);
                            break;
                        case "Int32":
                            x = 31;
                            longValue = (long)((Int32)value);
                            break;
                        case "Int64":
                            x = 63;
                            longValue = (long)((Int64)value);
                            break;
                        default:
                            throw new Exception();
                    }

                    for (cnt = x; cnt >= 0; cnt += -1)
                    {
                        if (((Int64)longValue & (Int64)Math.Pow(2, cnt)) > 0)
                            txt += "1";
                        else
                            txt += "0";
                    }
                }
                else
                {
                    // ist ein Array
                    switch (value.GetType().Name)
                    {
                        case "Byte[]":
                            x = 7;
                            byte[] ByteArr = (byte[])value;
                            for (cnt2 = 0; cnt2 <= ByteArr.Length - 1; cnt2++)
                            {
                                for (cnt = x; cnt >= 0; cnt += -1)
                                    if ((ByteArr[cnt2] & (byte)Math.Pow(2, cnt)) > 0) txt += "1"; else txt += "0";
                            }
                            break;
                        case "Int16[]":
                            x = 15;
                            Int16[] Int16Arr = (Int16[])value;
                            for (cnt2 = 0; cnt2 <= Int16Arr.Length - 1; cnt2++)
                            {
                                for (cnt = x; cnt >= 0; cnt += -1)
                                    if ((Int16Arr[cnt2] & (byte)Math.Pow(2, cnt)) > 0) txt += "1"; else txt += "0";
                            }
                            break;
                        case "Int32[]":
                            x = 31;
                            Int32[] Int32Arr = (Int32[])value;
                            for (cnt2 = 0; cnt2 <= Int32Arr.Length - 1; cnt2++)
                            {
                                for (cnt = x; cnt >= 0; cnt += -1)
                                    if ((Int32Arr[cnt2] & (byte)Math.Pow(2, cnt)) > 0) txt += "1"; else txt += "0";
                            }
                            break;
                        case "Int64[]":
                            x = 63;
                            byte[] Int64Arr = (byte[])value;
                            for (cnt2 = 0; cnt2 <= Int64Arr.Length - 1; cnt2++)
                            {
                                for (cnt = x; cnt >= 0; cnt += -1)
                                    if ((Int64Arr[cnt2] & (byte)Math.Pow(2, cnt)) > 0) txt += "1"; else txt += "0";
                            }
                            break;
                        default:
                            throw new Exception();
                    }
                }
                return txt;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Helper to get a bit value given a byte and the bit index.
        /// Example: DB1.DBX0.5 -> var bytes = ReadBytes(DB1.DBW0); bool bit = bytes[0].SelectBit(5); 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="bitPosition"></param>
        /// <returns></returns>
        public static bool SelectBit(this byte data, int bitPosition)
        {
            int mask = 1 << bitPosition;
            int result = data & mask;

            return (result != 0);
        }

        /// <summary>
        /// Converts from ushort value to short value; it's used to retrieve negative values from words
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static short ConvertToShort(this ushort input)
        {
            return short.Parse(input.ToString("X"), NumberStyles.HexNumber);
        }

        /// <summary>
        /// Converts from short value to ushort value; it's used to pass negative values to DWs
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static ushort ConvertToUshort(this short input)
        {
            return ushort.Parse(input.ToString("X"), NumberStyles.HexNumber);
        }

        /// <summary>
        /// Converts from UInt32 value to Int32 value; it's used to retrieve negative values from DBDs
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Int32 ConvertToInt(this uint input)
        {
            return int.Parse(input.ToString("X"), NumberStyles.HexNumber);
        }

        /// <summary>
        /// Converts from Int32 value to UInt32 value; it's used to pass negative values to DBDs
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static UInt32 ConvertToUInt(this int input)
        {
            return uint.Parse(input.ToString("X"), NumberStyles.HexNumber);
        }

        /// <summary>
        /// Converts from float to DWord (DBD)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static UInt32 ConvertToUInt(this float input)
        {
            return DWordFromByteArray(RealToByteArray(input));
        }

        /// <summary>
        /// Converts from DWord (DBD) to float
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static float ConvertToFloat(this uint input)
        {
            return RealFromByteArray(DWordToByteArray(input));
        }
        #endregion Conversion
        #region // ConnectionRequest 连接请求
        internal static byte[] GetCOTPConnectionRequest(TsapPair tsapPair)
        {
            byte[] bSend1 = {
                    3, 0, 0, 22, //TPKT
                    17,     //COTP Header Length
                    224,    //Connect Request
                    0, 0,   //Destination Reference
                    0, 46,  //Source Reference
                    0,      //Flags
                    193,    //Parameter Code (src-tasp)
                    2,      //Parameter Length
                    tsapPair.Local.FirstByte, tsapPair.Local.SecondByte,   //Source TASP
                    194,    //Parameter Code (dst-tasp)
                    2,      //Parameter Length
                    tsapPair.Remote.FirstByte, tsapPair.Remote.SecondByte,   //Destination TASP
                    192,    //Parameter Code (tpdu-size)
                    1,      //Parameter Length
                    10      //TPDU Size (2^10 = 1024)
                };

            return bSend1;
        }
        #endregion
        #region // MemoryStreamExtension
        /// <summary>
        /// Helper function to write to whole content of the given byte array to a memory stream.
        /// 
        /// Writes all bytes in value from 0 to value.Length to the memory stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="value"></param>
        internal static void WriteByteArray(this System.IO.MemoryStream stream, byte[] value)
        {
            stream.Write(value, 0, value.Length);
        }
        #endregion MemoryStreamExtension
        #region // TcpClientMixins
#if NETSTANDARD1_3
        public static void Close(this TcpClient tcpClient)
        {
            tcpClient.Dispose();
        }

        public static void Connect(this TcpClient tcpClient, string host, int port)
        {
            tcpClient.ConnectAsync(host, port).GetAwaiter().GetResult();
        }
#endif
        #endregion TcpClientMixins
        #region // StreamExtensions
        /// <summary>
        /// Reads bytes from the stream into the buffer until exactly the requested number of bytes (or EOF) have been read
        /// </summary>
        /// <param name="stream">the Stream to read from</param>
        /// <param name="buffer">the buffer to read into</param>
        /// <param name="offset">the offset in the buffer to read into</param>
        /// <param name="count">the amount of bytes to read into the buffer</param>
        /// <returns>returns the amount of read bytes</returns>
        public static int ReadExact(this Stream stream, byte[] buffer, int offset, int count)
        {
            int read = 0;
            int received;
            do
            {
                received = stream.Read(buffer, offset + read, count - read);
                read += received;
            }
            while (read < count && received > 0);

            return read;
        }
        /// <summary>
        /// Reads bytes from the stream into the buffer until exactly the requested number of bytes (or EOF) have been read
        /// </summary>
        /// <param name="stream">the Stream to read from</param>
        /// <param name="buffer">the buffer to read into</param>
        /// <param name="offset">the offset in the buffer to read into</param>
        /// <param name="count">the amount of bytes to read into the buffer</param>
        /// <param name="cancellationToken"></param>
        /// <returns>returns the amount of read bytes</returns>
        public static async Task<int> ReadExactAsync(this Stream stream, byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            int read = 0;
            int received;
            do
            {
                received = await stream.ReadAsync(buffer, offset + read, count - read, cancellationToken).ConfigureAwait(false);
                read += received;
            }
            while (read < count && received > 0);

            return read;
        }
        #endregion StreamExtensions
        #region // TypeHelper
        /// <summary>
        /// Converts an array of T to an array of bytes 
        /// </summary>
        internal static byte[] ToByteArray<T>(T[] value, Func<T, byte[]> converter) where T : struct
        {
            var buffer = new byte[Marshal.SizeOf(default(T)) * value.Length];
            var stream = new MemoryStream(buffer);
            foreach (var val in value)
            {
                stream.Write(converter(val), 0, 4);
            }

            return buffer;
        }

        /// <summary>
        /// Converts an array of T repesented as S7 binary data to an array of T
        /// </summary>
        internal static T[] ToArray<T>(byte[] bytes, Func<byte[], T> converter) where T : struct
        {
            var typeSize = Marshal.SizeOf(default(T));
            var entries = bytes.Length / typeSize;
            var values = new T[entries];

            for (int i = 0; i < entries; ++i)
            {
                var buffer = new byte[typeSize];
                Array.Copy(bytes, i * typeSize, buffer, 0, typeSize);
                values[i] = converter(buffer);
            }

            return values;
        }
        #endregion
        #region // Serialization
        internal static ushort GetWordAt(IList<byte> buf, int index)
        {
            return (ushort)((buf[index] << 8) + buf[index]);
        }

        internal static byte[] SerializeDataItem(DataItem dataItem)
        {
            if (dataItem.Value == null)
            {
                throw new Exception($"DataItem.Value is null, cannot serialize. StartAddr={dataItem.StartByteAdr} VarType={dataItem.VarType}");
            }

            if (dataItem.Value is string s)
                return dataItem.VarType switch
                {
                    VarType.S7String => S7StringToByteArray(s, dataItem.Count),
                    VarType.S7WString => S7WStringToByteArray(s, dataItem.Count),
                    _ => StringToByteArray(s, dataItem.Count)
                };

            return SerializeValue(dataItem.Value);
        }

        internal static byte[] SerializeValue(object value)
        {
            switch (value.GetType().Name)
            {
                case "Boolean":
                    return new[] { (byte)((bool)value ? 1 : 0) };
                case "Byte":
                    return ByteToByteArray((byte)value);
                case "Int16":
                    return IntToByteArray((Int16)value);
                case "UInt16":
                    return WordToByteArray((UInt16)value);
                case "Int32":
                    return DIntToByteArray((Int32)value);
                case "UInt32":
                    return DWordToByteArray((UInt32)value);
                case "Single":
                    return RealToByteArray((float)value);
                case "Double":
                    return LRealToByteArray((double)value);
                case "DateTime":
                    return DateTimeToByteArray((System.DateTime)value);
                case "Byte[]":
                    return (byte[])value;
                case "Int16[]":
                    return IntToByteArray((Int16[])value);
                case "UInt16[]":
                    return WordToByteArray((UInt16[])value);
                case "Int32[]":
                    return DIntToByteArray((Int32[])value);
                case "UInt32[]":
                    return DWordToByteArray((UInt32[])value);
                case "Single[]":
                    return RealToByteArray((float[])value);
                case "Double[]":
                    return LRealToByteArray((double[])value);
                case "String":
                    // Hack: This is backwards compatible with the old code, but functionally it's broken
                    // if the consumer does not pay attention to string length.
                    var stringVal = (string)value;
                    return StringToByteArray(stringVal, stringVal.Length);
                case "DateTime[]":
                    return DateTimeToByteArray((System.DateTime[])value);
                case "DateTimeLong[]":
                    return DateTimeLongToByteArray((System.DateTime[])value);
                default:
                    throw new InvalidVariableTypeException();
            }
        }

        internal static void SetAddressAt(ByteArray buffer, int index, int startByte, byte bitNumber)
        {
            var start = startByte * 8 + bitNumber;
            buffer[index + 2] = (byte)start;
            start >>= 8;
            buffer[index + 1] = (byte)start;
            start >>= 8;
            buffer[index] = (byte)start;
        }

        internal static void SetWordAt(ByteArray buffer, int index, ushort value)
        {
            buffer[index] = (byte)(value >> 8);
            buffer[index + 1] = (byte)value;
        }
        #endregion Serialization
        #region // S7WriteMultiple
        internal static int CreateRequest(ByteArray message, DataItem[] dataItems)
        {
            message.Add(Header.Template);

            message[Header.Offsets.ParameterCount] = (byte)dataItems.Length;
            var paramSize = dataItems.Length * Parameter.Template.Length;

            S7NetPlusCaller.SetWordAt(message, Header.Offsets.ParameterSize,
                (ushort)(2 + paramSize));

            var paramOffset = Header.Template.Length;
            var data = new ByteArray();

            var itemCount = 0;

            foreach (var item in dataItems)
            {
                itemCount++;
                message.Add(Parameter.Template);
                var value = S7NetPlusCaller.SerializeDataItem(item);
                var wordLen = item.Value is bool ? 1 : 2;

                message[paramOffset + Parameter.Offsets.WordLength] = (byte)wordLen;
                S7NetPlusCaller.SetWordAt(message, paramOffset + Parameter.Offsets.Amount, (ushort)value.Length);
                S7NetPlusCaller.SetWordAt(message, paramOffset + Parameter.Offsets.DbNumber, (ushort)item.DB);
                message[paramOffset + Parameter.Offsets.Area] = (byte)item.DataType;

                data.Add(0x00);
                if (item.Value is bool b)
                {
                    if (item.BitAdr > 7)
                        throw new ArgumentException(
                            $"Cannot read bit with invalid {nameof(item.BitAdr)} '{item.BitAdr}'.", nameof(dataItems));

                    S7NetPlusCaller.SetAddressAt(message, paramOffset + Parameter.Offsets.Address, item.StartByteAdr,
                        item.BitAdr);

                    data.Add(0x03);
                    data.AddWord(1);

                    data.Add(b ? (byte)1 : (byte)0);
                    if (itemCount != dataItems.Length)
                    {
                        data.Add(0);
                    }
                }
                else
                {
                    S7NetPlusCaller.SetAddressAt(message, paramOffset + Parameter.Offsets.Address, item.StartByteAdr, 0);

                    var len = value.Length;
                    data.Add(0x04);
                    data.AddWord((ushort)(len << 3));
                    data.Add(value);

                    if ((len & 0b1) == 1 && itemCount != dataItems.Length)
                    {
                        data.Add(0);
                    }
                }

                paramOffset += Parameter.Template.Length;
            }

            message.Add(data.Array);

            S7NetPlusCaller.SetWordAt(message, Header.Offsets.MessageLength, (ushort)message.Length);
            S7NetPlusCaller.SetWordAt(message, Header.Offsets.DataLength, (ushort)(message.Length - paramOffset));

            return message.Length;
        }

        internal static void ParseResponse(byte[] message, int length, DataItem[] dataItems)
        {
            if (length < 12) throw new Exception("Not enough data received to parse write response.");

            var messageError = S7NetPlusCaller.GetWordAt(message, 10);
            if (messageError != 0)
                throw new Exception($"Write failed with error {messageError}.");

            if (length < 14 + dataItems.Length)
                throw new Exception("Not enough data received to parse individual item responses.");
#if NET40
            IList<byte> itemResults = message.Skip(14).Take(dataItems.Length).ToList();
#else
            IList<byte> itemResults = new ArraySegment<byte>(message, 14, dataItems.Length);
#endif

            List<Exception> errors = null;

            for (int i = 0; i < dataItems.Length; i++)
            {
                try
                {
                    S7NetPlusPlc.ValidateResponseCode((ReadWriteErrorCode)itemResults[i]);
                }
                catch (Exception e)
                {
                    if (errors == null) errors = new List<Exception>();
                    errors.Add(new Exception($"Write of dataItem {dataItems[i]} failed: {e.Message}."));
                }

            }

            if (errors != null)
                throw new AggregateException(
                    $"Write failed for {errors.Count} items. See the innerExceptions for details.", errors);
        }

        private static class Header
        {
            public static byte[] Template { get; } =
            {
                0x03, 0x00, 0x00, 0x00, // TPKT
                0x02, 0xf0, 0x80, // ISO DT
                0x32, // S7 protocol ID
                0x01, // JobRequest
                0x00, 0x00, // Reserved
                0x05, 0x00, // PDU reference
                0x00, 0x0e, // Parameters length
                0x00, 0x00, // Data length
                0x05, // Function: Write var
                0x00, // Number of items to write
            };

            public static class Offsets
            {
                public const int MessageLength = 2;
                public const int ParameterSize = 13;
                public const int DataLength = 15;
                public const int ParameterCount = 18;
            }
        }

        private static class Parameter
        {
            public static byte[] Template { get; } =
            {
                0x12, // Spec
                0x0a, // Length of remaining bytes
                0x10, // Addressing mode
                0x02, // Transport size
                0x00, 0x00, // Number of elements
                0x00, 0x00, // DB number
                0x84, // Area type
                0x00, 0x00, 0x00 // Area offset
            };

            public static class Offsets
            {
                public const int WordLength = 3;
                public const int Amount = 4;
                public const int DbNumber = 6;
                public const int Area = 8;
                public const int Address = 9;
            }
        }
        #endregion S7WriteMultiple
        #region // Bit 位
        /// <summary>
        /// 转换一个位成布尔
        /// </summary>
        public static bool BitFromByte(byte v, byte bitAdr)
        {
            return (((int)v & (1 << bitAdr)) != 0);
        }
        /// <summary>
        /// 将字节数组转换成位数组
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>A BitArray with the same number of bits and equal values as <paramref name="bytes"/>.</returns>
        public static BitArray BitToBitArray(byte[] bytes) => BitToBitArray(bytes, bytes.Length * 8);
        /// <summary>
        /// 将字节数组转换成位数组
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="length">返回位长度</param>
        /// <returns>A BitArray with <paramref name="length"/> bits.</returns>
        public static BitArray BitToBitArray(byte[] bytes, int length)
        {
            if (length > bytes.Length * 8) { throw new ArgumentException($"Not enough data in bytes to return {length} bits.", nameof(bytes)); }
            var bitArr = new BitArray(bytes);
            var bools = new bool[length];
            for (var i = 0; i < length; i++)
            { bools[i] = bitArr[i]; }
            return new BitArray(bools);
        }
        #endregion Bit
        #region // Boolean 布尔
        /// <summary>
        /// Returns the value of a bit in a bit, given the address of the bit
        /// </summary>
        public static bool BooleanGetValue(byte value, int bit)
        {
            return (((int)value & (1 << bit)) != 0);
        }

        /// <summary>
        /// Sets the value of a bit to 1 (true), given the address of the bit. Returns
        /// a copy of the value with the bit set.
        /// </summary>
        /// <param name="value">The input value to modify.</param>
        /// <param name="bit">The index (zero based) of the bit to set.</param>
        /// <returns>The modified value with the bit at index set.</returns>
        public static byte BooleanSetBit(byte value, int bit)
        {
            BooleanSetBit(ref value, bit);
            return value;
        }

        /// <summary>
        /// Sets the value of a bit to 1 (true), given the address of the bit.
        /// </summary>
        /// <param name="value">The value to modify.</param>
        /// <param name="bit">The index (zero based) of the bit to set.</param>
        public static void BooleanSetBit(ref byte value, int bit)
        {
            value = (byte)((value | (1 << bit)) & 0xFF);
        }

        /// <summary>
        /// Resets the value of a bit to 0 (false), given the address of the bit. Returns
        /// a copy of the value with the bit cleared.
        /// </summary>
        /// <param name="value">The input value to modify.</param>
        /// <param name="bit">The index (zero based) of the bit to clear.</param>
        /// <returns>The modified value with the bit at index cleared.</returns>
        public static byte BooleanClearBit(byte value, int bit)
        {
            BooleanClearBit(ref value, bit);
            return value;
        }

        /// <summary>
        /// Resets the value of a bit to 0 (false), given the address of the bit
        /// </summary>
        /// <param name="value">The input value to modify.</param>
        /// <param name="bit">The index (zero based) of the bit to clear.</param>
        public static void BooleanClearBit(ref byte value, int bit)
        {
            value = (byte)(value & ~(1 << bit) & 0xFF);
        }
        #endregion Boolean
        #region // Byte 字节
        /// <summary>
        /// Converts a byte to byte array
        /// </summary>
        public static byte[] ByteToByteArray(byte value)
        {
            return new byte[] { value }; ;
        }

        /// <summary>
        /// Converts a byte array to byte
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte ByteFromByteArray(byte[] bytes)
        {
            if (bytes.Length != 1)
            {
                throw new ArgumentException("Wrong number of bytes. Bytes array must contain 1 bytes.");
            }
            return bytes[0];
        }
        #endregion Byte
        #region // Class 类
        private static IEnumerable<PropertyInfo> ClassGetAccessableProperties(Type classType)
        {
            return classType
#if NETSTANDARD1_3
                .GetTypeInfo().DeclaredProperties.Where(p => p.SetMethod != null);
#else
                .GetProperties(
                    BindingFlags.SetProperty |
                    BindingFlags.Public |
                    BindingFlags.Instance)
                .Where(p => p.GetSetMethod() != null);
#endif
        }

        private static double ClassGetIncreasedNumberOfBytes(double numBytes, Type type, PropertyInfo propertyInfo)
        {
            switch (type.Name)
            {
                case "Boolean":
                    numBytes += 0.125;
                    break;
                case "Byte":
                    numBytes = Math.Ceiling(numBytes);
                    numBytes++;
                    break;
                case "Int16":
                case "UInt16":
                    ClassIncrementToEven(ref numBytes);
                    numBytes += 2;
                    break;
                case "Int32":
                case "UInt32":
                    ClassIncrementToEven(ref numBytes);
                    numBytes += 4;
                    break;
                case "Single":
                    ClassIncrementToEven(ref numBytes);
                    numBytes += 4;
                    break;
                case "Double":
                    ClassIncrementToEven(ref numBytes);
                    numBytes += 8;
                    break;
                case "String":
                    S7StringAttribute attribute = propertyInfo?.GetCustomAttributes<S7StringAttribute>().SingleOrDefault();
                    if (attribute == default(S7StringAttribute))
                        throw new ArgumentException("Please add S7StringAttribute to the string field");

                    ClassIncrementToEven(ref numBytes);
                    numBytes += attribute.ReservedLengthInBytes;
                    break;
                default:
                    var propertyClass = Activator.CreateInstance(type);
                    numBytes = GetClassSize(propertyClass, numBytes, true);
                    break;
            }

            return numBytes;
        }
        /// <summary>
        /// Gets the size of the class in bytes.
        /// </summary>
        /// <param name="instance">An instance of the class</param>
        /// <param name="numBytes"></param>
        /// <param name="isInnerProperty"></param>
        /// <returns>the number of bytes</returns>
        public static double ClassGetSize(object instance, double numBytes = 0.0, bool isInnerProperty = false) => GetClassSize(instance, numBytes, isInnerProperty);

        /// <summary>
        /// Gets the size of the class in bytes.
        /// </summary>
        /// <param name="instance">An instance of the class</param>
        /// <param name="numBytes"></param>
        /// <param name="isInnerProperty"></param>
        /// <returns>the number of bytes</returns>
        public static double GetClassSize(object instance, double numBytes = 0.0, bool isInnerProperty = false)
        {
            var properties = ClassGetAccessableProperties(instance.GetType());
            foreach (var property in properties)
            {
                if (property.PropertyType.IsArray)
                {
                    Type elementType = property.PropertyType.GetElementType();
                    Array array = (Array)property.GetValue(instance, null);
                    if (array.Length <= 0)
                    {
                        throw new Exception("Cannot determine size of class, because an array is defined which has no fixed size greater than zero.");
                    }

                    ClassIncrementToEven(ref numBytes);
                    for (int i = 0; i < array.Length; i++)
                    {
                        numBytes = ClassGetIncreasedNumberOfBytes(numBytes, elementType, property);
                    }
                }
                else
                {
                    numBytes = ClassGetIncreasedNumberOfBytes(numBytes, property.PropertyType, property);
                }
            }
            if (false == isInnerProperty)
            {
                // enlarge numBytes to next even number because S7-Structs in a DB always will be resized to an even byte count
                numBytes = Math.Ceiling(numBytes);
                if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                    numBytes++;
            }
            return numBytes;
        }

        private static object ClassGetPropertyValue(Type propertyType, PropertyInfo propertyInfo, byte[] bytes, ref double numBytes)
        {
            object value = null;

            switch (propertyType.Name)
            {
                case "Boolean":
                    // get the value
                    int bytePos = (int)Math.Floor(numBytes);
                    int bitPos = (int)((numBytes - (double)bytePos) / 0.125);
                    if ((bytes[bytePos] & (int)Math.Pow(2, bitPos)) != 0)
                    { value = true; }
                    else
                    { value = false; }
                    numBytes += 0.125;
                    break;
                case "Byte":
                    numBytes = Math.Ceiling(numBytes);
                    value = (byte)(bytes[(int)numBytes]);
                    numBytes++;
                    break;
                case "Int16":
                    ClassIncrementToEven(ref numBytes);
                    // hier auswerten
                    ushort source = WordFromBytes(bytes[(int)numBytes + 1], bytes[(int)numBytes]);
                    value = source.ConvertToShort();
                    numBytes += 2;
                    break;
                case "UInt16":
                    ClassIncrementToEven(ref numBytes);
                    // hier auswerten
                    value = WordFromBytes(bytes[(int)numBytes + 1], bytes[(int)numBytes]);
                    numBytes += 2;
                    break;
                case "Int32":
                    ClassIncrementToEven(ref numBytes);
                    var wordBuffer = new byte[4];
                    Array.Copy(bytes, (int)numBytes, wordBuffer, 0, wordBuffer.Length);
                    uint sourceUInt = DWordFromByteArray(wordBuffer);
                    value = sourceUInt.ConvertToInt();
                    numBytes += 4;
                    break;
                case "UInt32":
                    ClassIncrementToEven(ref numBytes);
                    var wordBuffer2 = new byte[4];
                    Array.Copy(bytes, (int)numBytes, wordBuffer2, 0, wordBuffer2.Length);
                    value = DWordFromByteArray(wordBuffer2);
                    numBytes += 4;
                    break;
                case "Single":
                    ClassIncrementToEven(ref numBytes);
                    // hier auswerten
                    value = RealFromByteArray(
                        new byte[] {
                            bytes[(int)numBytes],
                            bytes[(int)numBytes + 1],
                            bytes[(int)numBytes + 2],
                            bytes[(int)numBytes + 3] });
                    numBytes += 4;
                    break;
                case "Double":
                    ClassIncrementToEven(ref numBytes);
                    var buffer = new byte[8];
                    Array.Copy(bytes, (int)numBytes, buffer, 0, 8);
                    // hier auswerten
                    value = LRealFromByteArray(buffer);
                    numBytes += 8;
                    break;
                case "String":
                    S7StringAttribute attribute = propertyInfo?.GetCustomAttributes<S7StringAttribute>().SingleOrDefault();
                    if (attribute == default(S7StringAttribute))
                        throw new ArgumentException("Please add S7StringAttribute to the string field");

                    ClassIncrementToEven(ref numBytes);

                    // get the value
                    var sData = new byte[attribute.ReservedLengthInBytes];
                    Array.Copy(bytes, (int)numBytes, sData, 0, sData.Length);
                    value = attribute.Type switch
                    {
                        S7StringType.S7String => S7StringFromByteArray(sData),
                        S7StringType.S7WString => S7WStringFromByteArray(sData),
                        _ => throw new ArgumentException("Please use a valid string type for the S7StringAttribute")
                    };
                    numBytes += sData.Length;
                    break;
                default:
                    var propClass = Activator.CreateInstance(propertyType);
                    numBytes = ClassFromBytes(propClass, bytes, numBytes);
                    value = propClass;
                    break;
            }

            return value;
        }

        /// <summary>
        /// Sets the object's values with the given array of bytes
        /// </summary>
        /// <param name="sourceClass">The object to fill in the given array of bytes</param>
        /// <param name="bytes">The array of bytes</param>
        /// <param name="numBytes"></param>
        /// <param name="isInnerClass"></param>
        public static double ClassFromBytes(object sourceClass, byte[] bytes, double numBytes = 0, bool isInnerClass = false)
        {
            if (bytes == null) { return numBytes; }

            var properties = ClassGetAccessableProperties(sourceClass.GetType());
            foreach (var property in properties)
            {
                if (property.PropertyType.IsArray)
                {
                    Array array = (Array)property.GetValue(sourceClass, null);
                    ClassIncrementToEven(ref numBytes);
                    Type elementType = property.PropertyType.GetElementType();
                    for (int i = 0; i < array.Length && numBytes < bytes.Length; i++)
                    {
                        array.SetValue(
                            ClassGetPropertyValue(elementType, property, bytes, ref numBytes),
                            i);
                    }
                }
                else
                {
                    property.SetValue(
                        sourceClass,
                        ClassGetPropertyValue(property.PropertyType, property, bytes, ref numBytes),
                        null);
                }
            }

            return numBytes;
        }

        private static double ClassSetBytesFromProperty(object propertyValue, PropertyInfo propertyInfo, byte[] bytes, double numBytes)
        {
            int bytePos = 0;
            int bitPos = 0;
            byte[] bytes2 = null;

            switch (propertyValue.GetType().Name)
            {
                case "Boolean":
                    // get the value
                    bytePos = (int)Math.Floor(numBytes);
                    bitPos = (int)((numBytes - (double)bytePos) / 0.125);
                    if ((bool)propertyValue)
                        bytes[bytePos] |= (byte)Math.Pow(2, bitPos);            // is true
                    else
                        bytes[bytePos] &= (byte)(~(byte)Math.Pow(2, bitPos));   // is false
                    numBytes += 0.125;
                    break;
                case "Byte":
                    numBytes = (int)Math.Ceiling(numBytes);
                    bytePos = (int)numBytes;
                    bytes[bytePos] = (byte)propertyValue;
                    numBytes++;
                    break;
                case "Int16":
                    bytes2 = IntToByteArray((Int16)propertyValue);
                    break;
                case "UInt16":
                    bytes2 = WordToByteArray((UInt16)propertyValue);
                    break;
                case "Int32":
                    bytes2 = DIntToByteArray((Int32)propertyValue);
                    break;
                case "UInt32":
                    bytes2 = DWordToByteArray((UInt32)propertyValue);
                    break;
                case "Single":
                    bytes2 = RealToByteArray((float)propertyValue);
                    break;
                case "Double":
                    bytes2 = LRealToByteArray((double)propertyValue);
                    break;
                case "String":
                    S7StringAttribute attribute = propertyInfo?.GetCustomAttributes<S7StringAttribute>().SingleOrDefault();
                    if (attribute == default(S7StringAttribute))
                        throw new ArgumentException("Please add S7StringAttribute to the string field");

                    bytes2 = attribute.Type switch
                    {
                        S7StringType.S7String => S7StringToByteArray((string)propertyValue, attribute.ReservedLength),
                        S7StringType.S7WString => S7WStringToByteArray((string)propertyValue, attribute.ReservedLength),
                        _ => throw new ArgumentException("Please use a valid string type for the S7StringAttribute")
                    };
                    break;
                default:
                    numBytes = ClassToBytes(propertyValue, bytes, numBytes);
                    break;
            }

            if (bytes2 != null)
            {
                ClassIncrementToEven(ref numBytes);

                bytePos = (int)numBytes;
                for (int bCnt = 0; bCnt < bytes2.Length; bCnt++)
                { bytes[bytePos + bCnt] = bytes2[bCnt]; }
                numBytes += bytes2.Length;
            }

            return numBytes;
        }

        /// <summary>
        /// Creates a byte array depending on the struct type.
        /// </summary>
        /// <param name="sourceClass">The struct object</param>
        /// <param name="bytes"></param>
        /// <param name="numBytes"></param>
        /// <returns>A byte array or null if fails.</returns>
        public static double ClassToBytes(object sourceClass, byte[] bytes, double numBytes = 0.0)
        {
            var properties = ClassGetAccessableProperties(sourceClass.GetType());
            foreach (var property in properties)
            {
                if (property.PropertyType.IsArray)
                {
                    Array array = (Array)property.GetValue(sourceClass, null);
                    ClassIncrementToEven(ref numBytes);
                    Type elementType = property.PropertyType.GetElementType();
                    for (int i = 0; i < array.Length && numBytes < bytes.Length; i++)
                    {
                        numBytes = ClassSetBytesFromProperty(array.GetValue(i), property, bytes, numBytes);
                    }
                }
                else
                {
                    numBytes = ClassSetBytesFromProperty(property.GetValue(sourceClass, null), property, bytes, numBytes);
                }
            }
            return numBytes;
        }

        private static void ClassIncrementToEven(ref double numBytes)
        {
            numBytes = Math.Ceiling(numBytes);
            if (numBytes % 2 > 0) numBytes++;
        }
        #endregion Class
        #region // Counter 计数器
        /// <summary>
        /// Converts a Counter (2 bytes) to ushort (UInt16)
        /// </summary>
        public static UInt16 CounterFromByteArray(byte[] bytes)
        {
            if (bytes.Length != 2)
            {
                throw new ArgumentException("Wrong number of bytes. Bytes array must contain 2 bytes.");
            }
            // bytes[0] -> HighByte
            // bytes[1] -> LowByte
            return (UInt16)((bytes[0] << 8) | bytes[1]);
        }


        /// <summary>
        /// Converts a ushort (UInt16) to word (2 bytes)
        /// </summary>
        public static byte[] CounterToByteArray(UInt16 value)
        {
            byte[] bytes = new byte[2];

            bytes[0] = (byte)((value << 8) & 0xFF);
            bytes[1] = (byte)((value) & 0xFF);

            return bytes;
        }

        /// <summary>
        /// Converts an array of ushort (UInt16) to an array of bytes
        /// </summary>
        public static byte[] CounterToByteArray(UInt16[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (UInt16 val in value)
            { arr.Add(CounterToByteArray(val)); }
            return arr.Array;
        }

        /// <summary>
        /// Converts an array of bytes to an array of ushort
        /// </summary>
        public static UInt16[] CounterToArray(byte[] bytes)
        {
            UInt16[] values = new UInt16[bytes.Length / 2];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 2; cnt++)
            { values[cnt] = CounterFromByteArray(new byte[] { bytes[counter++], bytes[counter++] }); }

            return values;
        }
        #endregion Counter
        #region // DateTime 日期时间
        /// <summary>
        /// The minimum <see cref="T:System.DateTime"/> value supported by the specification.
        /// </summary>
        public static readonly System.DateTime DateTimeSpecMinimum = new System.DateTime(1990, 1, 1);

        /// <summary>
        /// The maximum <see cref="T:System.DateTime"/> value supported by the specification.
        /// </summary>
        public static readonly System.DateTime DateTimeSpecMaximum = new System.DateTime(2089, 12, 31, 23, 59, 59, 999);

        /// <summary>
        /// Parses a <see cref="T:System.DateTime"/> value from bytes.
        /// </summary>
        /// <param name="bytes">Input bytes read from PLC.</param>
        /// <returns>A <see cref="T:System.DateTime"/> object representing the value read from PLC.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the length of
        ///   <paramref name="bytes"/> is not 8 or any value in <paramref name="bytes"/>
        ///   is outside the valid range of values.</exception>
        public static System.DateTime DateTimeFromByteArray(byte[] bytes)
        {
            return DateTimeFromByteArrayImpl(bytes);
        }

        /// <summary>
        /// Parses an array of <see cref="T:System.DateTime"/> values from bytes.
        /// </summary>
        /// <param name="bytes">Input bytes read from PLC.</param>
        /// <returns>An array of <see cref="T:System.DateTime"/> objects representing the values read from PLC.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the length of
        ///   <paramref name="bytes"/> is not a multiple of 8 or any value in
        ///   <paramref name="bytes"/> is outside the valid range of values.</exception>
        public static System.DateTime[] DateTimeToArray(byte[] bytes)
        {
            if (bytes.Length % 8 != 0)
                throw new ArgumentOutOfRangeException(nameof(bytes), bytes.Length,
                    $"Parsing an array of DateTime requires a multiple of 8 bytes of input data, input data is '{bytes.Length}' long.");

            var cnt = bytes.Length / 8;
            var result = new System.DateTime[bytes.Length / 8];

            for (var i = 0; i < cnt; i++)
            {
#if NET40
                result[i] = DateTimeFromByteArrayImpl(bytes.Skip(i * 8).Take(8).ToList());
#else
                result[i] = DateTimeFromByteArrayImpl(new ArraySegment<byte>(bytes, i * 8, 8));
#endif
            }

            return result;
        }

        private static System.DateTime DateTimeFromByteArrayImpl(IList<byte> bytes)
        {
            if (bytes.Count != 8)
                throw new ArgumentOutOfRangeException(nameof(bytes), bytes.Count,
                    $"Parsing a DateTime requires exactly 8 bytes of input data, input data is {bytes.Count} bytes long.");

            int DecodeBcd(byte input) => 10 * (input >> 4) + (input & 0b00001111);

            int ByteToYear(byte bcdYear)
            {
                var input = DecodeBcd(bcdYear);
                if (input < 90) return input + 2000;
                if (input < 100) return input + 1900;

                throw new ArgumentOutOfRangeException(nameof(bcdYear), bcdYear,
                    $"Value '{input}' is higher than the maximum '99' of S7 date and time representation.");
            }

            int AssertRangeInclusive(int input, byte min, byte max, string field)
            {
                if (input < min)
                    throw new ArgumentOutOfRangeException(nameof(input), input,
                        $"Value '{input}' is lower than the minimum '{min}' allowed for {field}.");
                if (input > max)
                    throw new ArgumentOutOfRangeException(nameof(input), input,
                        $"Value '{input}' is higher than the maximum '{max}' allowed for {field}.");

                return input;
            }

            var year = ByteToYear(bytes[0]);
            var month = AssertRangeInclusive(DecodeBcd(bytes[1]), 1, 12, "month");
            var day = AssertRangeInclusive(DecodeBcd(bytes[2]), 1, 31, "day of month");
            var hour = AssertRangeInclusive(DecodeBcd(bytes[3]), 0, 23, "hour");
            var minute = AssertRangeInclusive(DecodeBcd(bytes[4]), 0, 59, "minute");
            var second = AssertRangeInclusive(DecodeBcd(bytes[5]), 0, 59, "second");
            var hsec = AssertRangeInclusive(DecodeBcd(bytes[6]), 0, 99, "first two millisecond digits");
            var msec = AssertRangeInclusive(bytes[7] >> 4, 0, 9, "third millisecond digit");
            var dayOfWeek = AssertRangeInclusive(bytes[7] & 0b00001111, 1, 7, "day of week");

            return new System.DateTime(year, month, day, hour, minute, second, hsec * 10 + msec);
        }

        /// <summary>
        /// Converts a <see cref="T:System.DateTime"/> value to a byte array.
        /// </summary>
        /// <param name="dateTime">The DateTime value to convert.</param>
        /// <returns>A byte array containing the S7 date time representation of <paramref name="dateTime"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value of
        ///   <paramref name="dateTime"/> is before <see cref="P:DateTimeSpecMinimum"/>
        ///   or after <see cref="P:SpecMaximumDateTime"/>.</exception>
        public static byte[] DateTimeToByteArray(System.DateTime dateTime)
        {
            byte EncodeBcd(int value)
            {
                return (byte)((value / 10 << 4) | value % 10);
            }

            if (dateTime < DateTimeSpecMinimum)
                throw new ArgumentOutOfRangeException(nameof(dateTime), dateTime,
                    $"Date time '{dateTime}' is before the minimum '{DateTimeSpecMinimum}' supported in S7 date time representation.");

            if (dateTime > DateTimeSpecMaximum)
                throw new ArgumentOutOfRangeException(nameof(dateTime), dateTime,
                    $"Date time '{dateTime}' is after the maximum '{DateTimeSpecMaximum}' supported in S7 date time representation.");

            byte MapYear(int year) => (byte)(year < 2000 ? year - 1900 : year - 2000);

            int DayOfWeekToInt(DayOfWeek dayOfWeek) => (int)dayOfWeek + 1;

            return new[]
            {
                EncodeBcd(MapYear(dateTime.Year)),
                EncodeBcd(dateTime.Month),
                EncodeBcd(dateTime.Day),
                EncodeBcd(dateTime.Hour),
                EncodeBcd(dateTime.Minute),
                EncodeBcd(dateTime.Second),
                EncodeBcd(dateTime.Millisecond / 10),
                (byte) (dateTime.Millisecond % 10 << 4 | DayOfWeekToInt(dateTime.DayOfWeek))
            };
        }

        /// <summary>
        /// Converts an array of <see cref="T:System.DateTime"/> values to a byte array.
        /// </summary>
        /// <param name="dateTimes">The DateTime values to convert.</param>
        /// <returns>A byte array containing the S7 date time representations of <paramref name="dateTimes"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when any value of
        ///   <paramref name="dateTimes"/> is before <see cref="P:DateTimeSpecMinimum"/>
        ///   or after <see cref="P:SpecMaximumDateTime"/>.</exception>
        public static byte[] DateTimeToByteArray(System.DateTime[] dateTimes)
        {
            var bytes = new List<byte>(dateTimes.Length * 8);
            foreach (var dateTime in dateTimes)
            { bytes.AddRange(DateTimeToByteArray(dateTime)); }

            return bytes.ToArray();
        }
        #endregion DateTime
        #region // DateTimeLong 长日期时间
        /// <summary>
        /// 类型的字节长度
        /// </summary>
        public const int DateTimeLongTypeLengthInBytes = 12;
        /// <summary>
        /// The minimum <see cref="T:System.DateTime" /> value supported by the specification.
        /// </summary>
        public static readonly System.DateTime DateTimeLongSpecMinimum = new System.DateTime(1970, 1, 1);

        /// <summary>
        /// The maximum <see cref="T:System.DateTime" /> value supported by the specification.
        /// </summary>
        public static readonly System.DateTime DateTimeLongSpecMaximum = new System.DateTime(2262, 4, 11, 23, 47, 16, 854);

        /// <summary>
        /// Parses a <see cref="T:System.DateTime" /> value from bytes.
        /// </summary>
        /// <param name="bytes">Input bytes read from PLC.</param>
        /// <returns>A <see cref="T:System.DateTime" /> object representing the value read from PLC.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the length of
        /// <paramref name="bytes" /> is not 12 or any value in <paramref name="bytes" />
        /// is outside the valid range of values.
        /// </exception>
        public static System.DateTime DateTimeLongFromByteArray(byte[] bytes)
        {
            return DateTimeLongFromByteArrayImpl(bytes);
        }

        /// <summary>
        /// Parses an array of <see cref="T:System.DateTime" /> values from bytes.
        /// </summary>
        /// <param name="bytes">Input bytes read from PLC.</param>
        /// <returns>An array of <see cref="T:System.DateTime" /> objects representing the values read from PLC.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the length of
        /// <paramref name="bytes" /> is not a multiple of 12 or any value in
        /// <paramref name="bytes" /> is outside the valid range of values.
        /// </exception>
        public static System.DateTime[] DateTimeLongToArray(byte[] bytes)
        {
            if (bytes.Length % DateTimeLongTypeLengthInBytes != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bytes), bytes.Length,
                    $"Parsing an array of DateTimeLong requires a multiple of 12 bytes of input data, input data is '{bytes.Length}' long.");
            }

            var cnt = bytes.Length / DateTimeLongTypeLengthInBytes;
            var result = new System.DateTime[cnt];

            for (var i = 0; i < cnt; i++)
            {
                var slice = new byte[DateTimeLongTypeLengthInBytes];
                Array.Copy(bytes, i * DateTimeLongTypeLengthInBytes, slice, 0, DateTimeLongTypeLengthInBytes);
                result[i] = DateTimeLongFromByteArrayImpl(slice);
            }

            return result;
        }

        private static System.DateTime DateTimeLongFromByteArrayImpl(byte[] bytes)
        {
            if (bytes.Length != DateTimeLongTypeLengthInBytes)
            {
                throw new ArgumentOutOfRangeException(nameof(bytes), bytes.Length,
                    $"Parsing a DateTimeLong requires exactly 12 bytes of input data, input data is {bytes.Length} bytes long.");
            }


            var year = DateTimeLongAssertRangeInclusive(WordFromBytes(bytes[1], bytes[0]), 1970, 2262, "year");
            var month = DateTimeLongAssertRangeInclusive(bytes[2], 1, 12, "month");
            var day = DateTimeLongAssertRangeInclusive(bytes[3], 1, 31, "day of month");
            var dayOfWeek = DateTimeLongAssertRangeInclusive(bytes[4], 1, 7, "day of week");
            var hour = DateTimeLongAssertRangeInclusive(bytes[5], 0, 23, "hour");
            var minute = DateTimeLongAssertRangeInclusive(bytes[6], 0, 59, "minute");
            var second = DateTimeLongAssertRangeInclusive(bytes[7], 0, 59, "second");
            ;

            var nanoseconds = DateTimeLongAssertRangeInclusive<uint>(DWordFromBytes(bytes[11], bytes[10], bytes[9], bytes[8]), 0,
                999999999, "nanoseconds");

            var time = new System.DateTime(year, month, day, hour, minute, second);
            return time.AddTicks(nanoseconds / 100);
        }

        /// <summary>
        /// Converts a <see cref="T:System.DateTime" /> value to a byte array.
        /// </summary>
        /// <param name="dateTime">The DateTime value to convert.</param>
        /// <returns>A byte array containing the S7 DateTimeLong representation of <paramref name="dateTime" />.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the value of
        /// <paramref name="dateTime" /> is before <see cref="P:DateTimeLongSpecMinimum" />
        /// or after <see cref="P:SpecMaximumDateTime" />.
        /// </exception>
        public static byte[] DateTimeLongToByteArray(System.DateTime dateTime)
        {
            if (dateTime < DateTimeLongSpecMinimum)
            {
                throw new ArgumentOutOfRangeException(nameof(dateTime), dateTime,
                    $"Date time '{dateTime}' is before the minimum '{DateTimeLongSpecMinimum}' supported in S7 DateTimeLong representation.");
            }

            if (dateTime > DateTimeLongSpecMaximum)
            {
                throw new ArgumentOutOfRangeException(nameof(dateTime), dateTime,
                    $"Date time '{dateTime}' is after the maximum '{DateTimeLongSpecMaximum}' supported in S7 DateTimeLong representation.");
            }

            var stream = new MemoryStream(DateTimeLongTypeLengthInBytes);
            // Convert Year
            stream.Write(WordToByteArray(Convert.ToUInt16(dateTime.Year)), 0, 2);

            // Convert Month
            stream.WriteByte(Convert.ToByte(dateTime.Month));

            // Convert Day
            stream.WriteByte(Convert.ToByte(dateTime.Day));

            // Convert WeekDay. NET DateTime starts with Sunday = 0, while S7DT has Sunday = 1.
            stream.WriteByte(Convert.ToByte(dateTime.DayOfWeek + 1));

            // Convert Hour
            stream.WriteByte(Convert.ToByte(dateTime.Hour));

            // Convert Minutes
            stream.WriteByte(Convert.ToByte(dateTime.Minute));

            // Convert Seconds
            stream.WriteByte(Convert.ToByte(dateTime.Second));

            // Convert Nanoseconds. Net DateTime has a representation of 1 Tick = 100ns.
            // Thus First take the ticks Mod 1 Second (1s = 10'000'000 ticks), and then Convert to nanoseconds.
            stream.Write(DWordToByteArray(Convert.ToUInt32(dateTime.Ticks % 10000000 * 100)), 0, 4);

            return stream.ToArray();
        }

        /// <summary>
        /// Converts an array of <see cref="T:System.DateTime" /> values to a byte array.
        /// </summary>
        /// <param name="dateTimes">The DateTime values to convert.</param>
        /// <returns>A byte array containing the S7 DateTimeLong representations of <paramref name="dateTimes" />.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when any value of
        /// <paramref name="dateTimes" /> is before <see cref="P:DateTimeLongSpecMinimum" />
        /// or after <see cref="P:SpecMaximumDateTime" />.
        /// </exception>
        public static byte[] DateTimeLongToByteArray(System.DateTime[] dateTimes)
        {
            var bytes = new List<byte>(dateTimes.Length * DateTimeLongTypeLengthInBytes);
            foreach (var dateTime in dateTimes)
            {
                bytes.AddRange(DateTimeLongToByteArray(dateTime));
            }

            return bytes.ToArray();
        }

        private static T DateTimeLongAssertRangeInclusive<T>(T input, T min, T max, string field) where T : IComparable<T>
        {
            if (input.CompareTo(min) < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(input), input,
                    $"Value '{input}' is lower than the minimum '{min}' allowed for {field}.");
            }

            if (input.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException(nameof(input), input,
                    $"Value '{input}' is higher than the maximum '{max}' allowed for {field}.");
            }

            return input;
        }
        #endregion DateTimeLong
        #region // DWord 无符号整型
        /// <summary>
        /// Converts a S7 DWord (4 bytes) to uint (UInt32)
        /// </summary>
        public static UInt32 DWordFromByteArray(byte[] bytes)
        {
            return (UInt32)(bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3]);
        }
        /// <summary>
        /// Converts 4 bytes to DWord (UInt32)
        /// </summary>
        public static UInt32 DWordFromBytes(byte b1, byte b2, byte b3, byte b4)
        {
            return (UInt32)((b4 << 24) | (b3 << 16) | (b2 << 8) | b1);
        }
        /// <summary>
        /// Converts a uint (UInt32) to S7 DWord (4 bytes) 
        /// </summary>
        public static byte[] DWordToByteArray(UInt32 value)
        {
            byte[] bytes = new byte[4];

            bytes[0] = (byte)((value >> 24) & 0xFF);
            bytes[1] = (byte)((value >> 16) & 0xFF);
            bytes[2] = (byte)((value >> 8) & 0xFF);
            bytes[3] = (byte)((value) & 0xFF);

            return bytes;
        }
        /// <summary>
        /// Converts an array of uint (UInt32) to an array of S7 DWord (4 bytes) 
        /// </summary>
        public static byte[] DWordToByteArray(UInt32[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (UInt32 val in value)
            { arr.Add(DWordToByteArray(val)); }
            return arr.Array;
        }
        /// <summary>
        /// Converts an array of S7 DWord to an array of uint (UInt32)
        /// </summary>
        public static UInt32[] DWordToArray(byte[] bytes)
        {
            UInt32[] values = new UInt32[bytes.Length / 4];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 4; cnt++)
            { values[cnt] = DWordFromByteArray(new byte[] { bytes[counter++], bytes[counter++], bytes[counter++], bytes[counter++] }); }

            return values;
        }
        #endregion DWord
        #region // DInt 整型
        /// <summary>
        /// Converts a S7 DInt (4 bytes) to int (Int32)
        /// </summary>
        public static Int32 DIntFromByteArray(byte[] bytes)
        {
            if (bytes.Length != 4)
            {
                throw new ArgumentException("Wrong number of bytes. Bytes array must contain 4 bytes.");
            }
            return bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3];
        }

        /// <summary>
        /// Converts a int (Int32) to S7 DInt (4 bytes)
        /// </summary>
        public static byte[] DIntToByteArray(Int32 value)
        {
            byte[] bytes = new byte[4];

            bytes[0] = (byte)((value >> 24) & 0xFF);
            bytes[1] = (byte)((value >> 16) & 0xFF);
            bytes[2] = (byte)((value >> 8) & 0xFF);
            bytes[3] = (byte)((value) & 0xFF);

            return bytes;
        }

        /// <summary>
        /// Converts an array of int (Int32) to an array of bytes
        /// </summary>
        public static byte[] DIntToByteArray(Int32[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (Int32 val in value)
            { arr.Add(DIntToByteArray(val)); }
            return arr.Array;
        }

        /// <summary>
        /// Converts an array of S7 DInt to an array of int (Int32)
        /// </summary>
        public static Int32[] DIntToArray(byte[] bytes)
        {
            Int32[] values = new Int32[bytes.Length / 4];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 4; cnt++)
            { values[cnt] = DIntFromByteArray(new byte[] { bytes[counter++], bytes[counter++], bytes[counter++], bytes[counter++] }); }

            return values;
        }
        #endregion DInt
        #region // Int 短整型
        /// <summary>
        /// Converts a S7 Int (2 bytes) to short (Int16)
        /// </summary>
        public static short IntFromByteArray(byte[] bytes)
        {
            if (bytes.Length != 2)
            {
                throw new ArgumentException("Wrong number of bytes. Bytes array must contain 2 bytes.");
            }
            // bytes[0] -> HighByte
            // bytes[1] -> LowByte
            return (short)((int)(bytes[1]) | ((int)(bytes[0]) << 8));
        }
        /// <summary>
        /// Converts a short (Int16) to a S7 Int byte array (2 bytes)
        /// </summary>
        public static byte[] IntToByteArray(Int16 value)
        {
            byte[] bytes = new byte[2];

            bytes[0] = (byte)(value >> 8 & 0xFF);
            bytes[1] = (byte)(value & 0xFF);

            return bytes;
        }
        /// <summary>
        /// Converts an array of short (Int16) to a S7 Int byte array (2 bytes)
        /// </summary>
        public static byte[] IntToByteArray(Int16[] value)
        {
            byte[] bytes = new byte[value.Length * 2];
            int bytesPos = 0;

            for (int i = 0; i < value.Length; i++)
            {
                bytes[bytesPos++] = (byte)((value[i] >> 8) & 0xFF);
                bytes[bytesPos++] = (byte)(value[i] & 0xFF);
            }
            return bytes;
        }
        /// <summary>
        /// Converts an array of S7 Int to an array of short (Int16)
        /// </summary>
        public static Int16[] IntToArray(byte[] bytes)
        {
            int shortsCount = bytes.Length / 2;

            Int16[] values = new Int16[shortsCount];

            int counter = 0;
            for (int cnt = 0; cnt < shortsCount; cnt++)
            { values[cnt] = IntFromByteArray(new byte[] { bytes[counter++], bytes[counter++] }); }

            return values;
        }

        /// <summary>
        /// Converts a C# int value to a C# short value, to be used as word.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int16 IntCWord(int value)
        {
            if (value > 32767)
            {
                value -= 32768;
                value = 32768 - value;
                value *= -1;
            }
            return (short)value;
        }
        #endregion Int
        #region // LReal 双精度浮点数
        /// <summary>
        /// Converts a S7 LReal (8 bytes) to double
        /// </summary>
        public static double LRealFromByteArray(byte[] bytes)
        {
            if (bytes.Length != 8)
            {
                throw new ArgumentException("Wrong number of bytes. Bytes array must contain 8 bytes.");
            }
            var buffer = bytes;

            // sps uses bigending so we have to reverse if platform needs
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buffer);
            }

            return BitConverter.ToDouble(buffer, 0);
        }

        /// <summary>
        /// Converts a double to S7 LReal (8 bytes)
        /// </summary>
        public static byte[] LRealToByteArray(double value)
        {
            var bytes = BitConverter.GetBytes(value);

            // sps uses bigending so we have to check if platform is same
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return bytes;
        }

        /// <summary>
        /// Converts an array of double to an array of bytes 
        /// </summary>
        public static byte[] LRealToByteArray(double[] value) => S7NetPlusCaller.ToByteArray(value, LRealToByteArray);
        /// <summary>
        /// Converts an array of S7 LReal to an array of double
        /// </summary>
        public static double[] LRealToArray(byte[] bytes) => S7NetPlusCaller.ToArray(bytes, LRealFromByteArray);
        #endregion LReal
        #region // Real 单精度浮点数
        /// <summary>
        /// Converts a S7 Real (4 bytes) to float
        /// </summary>
        public static float RealFromByteArray(byte[] bytes)
        {
            if (bytes.Length != 4)
            {
                throw new ArgumentException("Wrong number of bytes. Bytes array must contain 4 bytes.");
            }

            // sps uses bigending so we have to reverse if platform needs
            if (BitConverter.IsLittleEndian)
            {
                // create deep copy of the array and reverse
                bytes = new byte[] { bytes[3], bytes[2], bytes[1], bytes[0] };
            }

            return BitConverter.ToSingle(bytes, 0);
        }

        /// <summary>
        /// Converts a float to S7 Real (4 bytes)
        /// </summary>
        public static byte[] RealToByteArray(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            // sps uses bigending so we have to check if platform is same
            if (!BitConverter.IsLittleEndian) { return bytes; }

            // create deep copy of the array and reverse
            return new byte[] { bytes[3], bytes[2], bytes[1], bytes[0] };
        }

        /// <summary>
        /// Converts an array of float to an array of bytes 
        /// </summary>
        public static byte[] RealToByteArray(float[] value)
        {
            var buffer = new byte[4 * value.Length];
            var stream = new MemoryStream(buffer);
            foreach (var val in value)
            {
                stream.Write(RealToByteArray(val), 0, 4);
            }

            return buffer;
        }
        /// <summary>
        /// Converts an array of S7 Real to an array of float
        /// </summary>
        public static float[] RealToArray(byte[] bytes)
        {
            var values = new float[bytes.Length / 4];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 4; cnt++)
            { values[cnt] = RealFromByteArray(new byte[] { bytes[counter++], bytes[counter++], bytes[counter++], bytes[counter++] }); }

            return values;
        }
        /// <summary>
        /// Converts a S7 DInt to float
        /// </summary>
        public static float RealFromDWord(Int32 value)
        {
            byte[] b = DIntToByteArray(value);
            float d = RealFromByteArray(b);
            return d;
        }
        /// <summary>
        /// Converts a S7 DWord to float
        /// </summary>
        public static float RealFromDWord(UInt32 value)
        {
            byte[] b = DWordToByteArray(value);
            float d = RealFromByteArray(b);
            return d;
        }
        #endregion Real
        #region // Double 单精度浮点数
        /// <summary>
        /// Converts a S7 Real (4 bytes) to double <see cref="RealFromByteArray(byte[])"/>
        /// </summary>
        public static double DoubleFromByteArray(byte[] bytes) => RealFromByteArray(bytes);

        /// <summary>
        /// Converts a S7 DInt to double <see cref="RealFromDWord(int)"/>
        /// </summary>
        public static double DoubleFromDWord(Int32 value) => RealFromDWord(value);

        /// <summary>
        /// Converts a S7 DWord to double <see cref="RealFromDWord(uint)"/>
        /// </summary>
        public static double DoubleFromDWord(UInt32 value) => RealFromDWord(value);

        /// <summary>
        /// Converts a double to S7 Real (4 bytes) <see cref="RealToByteArray(float)"/>
        /// </summary>
        public static byte[] DoubleToByteArray(double value) => RealToByteArray((float)value);

        /// <summary>
        /// Converts an array of double to an array of bytes <see cref="RealToByteArray(float[])"/>
        /// </summary>
        public static byte[] DoubleToByteArray(double[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (double val in value)
            { arr.Add(DoubleToByteArray(val)); }
            return arr.Array;
        }

        /// <summary>
        /// Converts an array of S7 Real to an array of double <see cref="RealToArray(byte[])"/>
        /// </summary>
        public static double[] DoubleToArray(byte[] bytes)
        {
            double[] values = new double[bytes.Length / 4];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 4; cnt++)
            { values[cnt] = DoubleFromByteArray(new byte[] { bytes[counter++], bytes[counter++], bytes[counter++], bytes[counter++] }); }

            return values;
        }
        #endregion Double
        #region // Single 单精度浮点数
        /// <summary>
        /// Converts a S7 Real (4 bytes) to float <see cref="RealFromByteArray(byte[])"/>
        /// </summary>
        public static float SingleFromByteArray(byte[] bytes) => RealFromByteArray(bytes);

        /// <summary>
        /// Converts a S7 DInt to float <see cref="RealFromDWord(int)"/>
        /// </summary>
        public static float SingleFromDWord(Int32 value) => RealFromDWord(value);

        /// <summary>
        /// Converts a S7 DWord to float <see cref="RealFromDWord(uint)"/>
        /// </summary>
        public static float SingleFromDWord(UInt32 value) => RealFromDWord(value);
        /// <summary>
        /// Converts a double to S7 Real (4 bytes) <see cref="RealToByteArray(float)"/>
        /// </summary>
        public static byte[] SingleToByteArray(float value) => RealToByteArray(value);

        /// <summary>
        /// Converts an array of float to an array of bytes <see cref="RealToByteArray(float[])"/>
        /// </summary>
        public static byte[] SingleToByteArray(float[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (float val in value)
            { arr.Add(SingleToByteArray(val)); }
            return arr.Array;
        }

        /// <summary>
        /// Converts an array of S7 Real to an array of float <see cref="RealToArray(byte[])"/>
        /// </summary>
        public static float[] SingleToArray(byte[] bytes) => RealToArray(bytes);
        #endregion Single
        #region // S7String 指定编码字符串
        private static Encoding s7StringStringEncoding = Encoding.ASCII;

        /// <summary>
        /// The Encoding used when serializing and deserializing S7String (Encoding.ASCII by default)
        /// </summary>
        /// <exception cref="ArgumentNullException">StringEncoding must not be null</exception>
        public static Encoding S7StringStringEncoding
        {
            get => s7StringStringEncoding;
            set => s7StringStringEncoding = value ?? throw new ArgumentNullException(nameof(S7StringStringEncoding));
        }

        /// <summary>
        /// Converts S7 bytes to a string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string S7StringFromByteArray(byte[] bytes)
        {
            return S7StringFromByteArray(bytes, S7StringStringEncoding);
        }

        /// <summary>
        /// Converts a <see cref="T:string"/> to S7 string with 2-byte header.
        /// </summary>
        /// <param name="value">The string to convert to byte array.</param>
        /// <param name="reservedLength">The length (in characters) allocated in PLC for the string.</param>
        /// <returns>A <see cref="T:byte[]" /> containing the string header and string value with a maximum length of <paramref name="reservedLength"/> + 2.</returns>
        public static byte[] S7StringToByteArray(string value, int reservedLength)
        {
            return S7StringToByteArray(value, reservedLength, S7StringStringEncoding);
        }
        /// <summary>
        /// Converts S7 bytes to a string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string S7StringFromByteArray(byte[] bytes, Encoding encoding)
        {
            if (bytes.Length < 2)
            {
                throw new PlcException(ErrorCode.ReadData, "Malformed S7 String / too short");
            }

            int size = bytes[0];
            int length = bytes[1];
            if (length > size)
            {
                throw new PlcException(ErrorCode.ReadData, "Malformed S7 String / length larger than capacity");
            }

            try
            {
                return encoding.GetString(bytes, 2, length);
            }
            catch (Exception e)
            {
                throw new PlcException(ErrorCode.ReadData,
                    $"Failed to parse {VarType.S7String} from data. Following fields were read: size: '{size}', actual length: '{length}', total number of bytes (including header): '{bytes.Length}'.",
                    e);
            }
        }

        /// <summary>
        /// Converts a <see cref="T:string"/> to S7 string with 2-byte header.
        /// </summary>
        /// <param name="value">The string to convert to byte array.</param>
        /// <param name="reservedLength">The length (in characters) allocated in PLC for the string.</param>
        /// <param name="encoding"></param>
        /// <returns>A <see cref="T:byte[]" /> containing the string header and string value with a maximum length of <paramref name="reservedLength"/> + 2.</returns>
        public static byte[] S7StringToByteArray(string value, int reservedLength, Encoding encoding)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (reservedLength > 254) throw new ArgumentException($"The maximum string length supported is 254.");

            var bytes = encoding.GetBytes(value);
            if (bytes.Length > reservedLength) throw new ArgumentException($"The provided string length ({bytes.Length} is larger than the specified reserved length ({reservedLength}).");

            var buffer = new byte[2 + reservedLength];
            Array.Copy(bytes, 0, buffer, 2, bytes.Length);
            buffer[0] = (byte)reservedLength;
            buffer[1] = (byte)bytes.Length;
            return buffer;
        }
        #endregion S7String
        #region // S7WString Unicode字符串
        /// <summary>
        /// Converts S7 bytes to a string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string S7WStringFromByteArray(byte[] bytes)
        {
            return S7WStringFromByteArray(bytes, Encoding.BigEndianUnicode);
        }

        /// <summary>
        /// Converts a <see cref="T:string"/> to S7 wstring with 4-byte header.
        /// </summary>
        /// <param name="value">The string to convert to byte array.</param>
        /// <param name="reservedLength">The length (in characters) allocated in PLC for the string.</param>
        /// <returns>A <see cref="T:byte[]" /> containing the string header and string value with a maximum length of <paramref name="reservedLength"/> + 4.</returns>
        public static byte[] S7WStringToByteArray(string value, int reservedLength)
        {
            return S7WStringToByteArray(value, reservedLength, Encoding.BigEndianUnicode);
        }
        /// <summary>
        /// Converts S7 bytes to a string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string S7WStringFromByteArray(byte[] bytes, Encoding encoding)
        {
            if (bytes.Length < 4)
            {
                throw new PlcException(ErrorCode.ReadData, "Malformed S7 WString / too short");
            }

            int size = (bytes[0] << 8) | bytes[1];
            int length = (bytes[2] << 8) | bytes[3];

            if (length > size)
            {
                throw new PlcException(ErrorCode.ReadData, "Malformed S7 WString / length larger than capacity");
            }

            try
            {
                return encoding.GetString(bytes, 4, length * 2);
            }
            catch (Exception e)
            {
                throw new PlcException(ErrorCode.ReadData,
                    $"Failed to parse {VarType.S7WString} from data. Following fields were read: size: '{size}', actual length: '{length}', total number of bytes (including header): '{bytes.Length}'.",
                    e);
            }

        }

        /// <summary>
        /// Converts a <see cref="T:string"/> to S7 wstring with 4-byte header.
        /// </summary>
        /// <param name="value">The string to convert to byte array.</param>
        /// <param name="reservedLength">The length (in characters) allocated in PLC for the string.</param>
        /// <param name="encoding"></param>
        /// <returns>A <see cref="T:byte[]" /> containing the string header and string value with a maximum length of <paramref name="reservedLength"/> + 4.</returns>
        public static byte[] S7WStringToByteArray(string value, int reservedLength, Encoding encoding)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (reservedLength > 16382) throw new ArgumentException("The maximum string length supported is 16382.");

            var buffer = new byte[4 + reservedLength * 2];
            buffer[0] = (byte)((reservedLength >> 8) & 0xFF);
            buffer[1] = (byte)(reservedLength & 0xFF);
            buffer[2] = (byte)((value.Length >> 8) & 0xFF);
            buffer[3] = (byte)(value.Length & 0xFF);

            var stringLength = encoding.GetBytes(value, 0, value.Length, buffer, 4) / 2;
            if (stringLength > reservedLength) throw new ArgumentException($"The provided string length ({stringLength} is larger than the specified reserved length ({reservedLength}).");

            return buffer;
        }
        #endregion S7WString
        #region // String 字符串
        /// <summary>
        /// Converts a string to <paramref name="reservedLength"/> of bytes, padded with 0-bytes if required.
        /// </summary>
        /// <param name="value">The string to write to the PLC.</param>
        /// <param name="reservedLength">The amount of bytes reserved for the <paramref name="value"/> in the PLC.</param>
        public static byte[] StringToByteArray(string value, int reservedLength)
        {
            var length = value?.Length;
            if (length > reservedLength) length = reservedLength;
            var bytes = new byte[reservedLength];

            if (length == null || length == 0) return bytes;

            System.Text.Encoding.ASCII.GetBytes(value, 0, length.Value, bytes, 0);

            return bytes;
        }

        /// <summary>
        /// Converts S7 bytes to a string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string StringFromByteArray(byte[] bytes)
        {
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
        #endregion String
        #region // StringEx 字符串扩展
        /// <inheritdoc cref="S7StringFromByteArray(byte[])"/>
        public static string StringExFromByteArray(byte[] bytes) => S7StringFromByteArray(bytes);

        /// <inheritdoc cref="S7StringToByteArray(string, int)"/>
        public static byte[] StringExToByteArray(string value, int reservedLength) => S7StringToByteArray(value, reservedLength);
        #endregion StringEx
        #region // Struct 结构体
        /// <summary>
        /// Gets the size of the struct in bytes.
        /// </summary>
        /// <param name="structType">the type of the struct</param>
        /// <returns>the number of bytes</returns>
        public static int StructGetSize(Type structType) => GetStructSize(structType);
        /// <summary>
        /// Gets the size of the struct in bytes.
        /// </summary>
        /// <param name="structType">the type of the struct</param>
        /// <returns>the number of bytes</returns>
        public static int GetStructSize(Type structType)
        {
            double numBytes = 0.0;

            var infos = structType
#if NETSTANDARD1_3
                .GetTypeInfo().DeclaredFields;
#else
                .GetFields();
#endif

            foreach (var info in infos)
            {
                switch (info.FieldType.Name)
                {
                    case "Boolean":
                        numBytes += 0.125;
                        break;
                    case "Byte":
                        numBytes = Math.Ceiling(numBytes);
                        numBytes++;
                        break;
                    case "Int16":
                    case "UInt16":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        numBytes += 2;
                        break;
                    case "Int32":
                    case "UInt32":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        numBytes += 4;
                        break;
                    case "Single":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        numBytes += 4;
                        break;
                    case "Double":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        numBytes += 8;
                        break;
                    case "String":
                        S7StringAttribute attribute = info.GetCustomAttributes<S7StringAttribute>().SingleOrDefault();
                        if (attribute == default(S7StringAttribute))
                            throw new ArgumentException("Please add S7StringAttribute to the string field");

                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        numBytes += attribute.ReservedLengthInBytes;
                        break;
                    default:
                        numBytes += GetStructSize(info.FieldType);
                        break;
                }
            }
            return (int)numBytes;
        }

        /// <summary>
        /// Creates a struct of a specified type by an array of bytes.
        /// </summary>
        /// <param name="structType">The struct type</param>
        /// <param name="bytes">The array of bytes</param>
        /// <returns>The object depending on the struct type or null if fails(array-length != struct-length</returns>
        public static object StructFromBytes(Type structType, byte[] bytes)
        {
            if (bytes == null)
                return null;

            if (bytes.Length != GetStructSize(structType))
                return null;

            // and decode it
            int bytePos = 0;
            int bitPos = 0;
            double numBytes = 0.0;
            object structValue = Activator.CreateInstance(structType);


            var infos = structValue.GetType()
#if NETSTANDARD1_3
                .GetTypeInfo().DeclaredFields;
#else
                .GetFields();
#endif

            foreach (var info in infos)
            {
                switch (info.FieldType.Name)
                {
                    case "Boolean":
                        // get the value
                        bytePos = (int)Math.Floor(numBytes);
                        bitPos = (int)((numBytes - (double)bytePos) / 0.125);
                        if ((bytes[bytePos] & (int)Math.Pow(2, bitPos)) != 0)
                            info.SetValue(structValue, true);
                        else
                            info.SetValue(structValue, false);
                        numBytes += 0.125;
                        break;
                    case "Byte":
                        numBytes = Math.Ceiling(numBytes);
                        info.SetValue(structValue, (byte)(bytes[(int)numBytes]));
                        numBytes++;
                        break;
                    case "Int16":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        // get the value
                        ushort source = WordFromBytes(bytes[(int)numBytes + 1], bytes[(int)numBytes]);
                        info.SetValue(structValue, source.ConvertToShort());
                        numBytes += 2;
                        break;
                    case "UInt16":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        // get the value
                        info.SetValue(structValue, WordFromBytes(bytes[(int)numBytes + 1],
                                                                          bytes[(int)numBytes]));
                        numBytes += 2;
                        break;
                    case "Int32":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        // get the value
                        uint sourceUInt = DWordFromBytes(bytes[(int)numBytes + 3],
                                                                           bytes[(int)numBytes + 2],
                                                                           bytes[(int)numBytes + 1],
                                                                           bytes[(int)numBytes + 0]);
                        info.SetValue(structValue, sourceUInt.ConvertToInt());
                        numBytes += 4;
                        break;
                    case "UInt32":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        // get the value
                        info.SetValue(structValue, DWordFromBytes(bytes[(int)numBytes],
                                                                           bytes[(int)numBytes + 1],
                                                                           bytes[(int)numBytes + 2],
                                                                           bytes[(int)numBytes + 3]));
                        numBytes += 4;
                        break;
                    case "Single":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        // get the value
                        info.SetValue(structValue, RealFromByteArray(new byte[] { bytes[(int)numBytes],
                                                                           bytes[(int)numBytes + 1],
                                                                           bytes[(int)numBytes + 2],
                                                                           bytes[(int)numBytes + 3] }));
                        numBytes += 4;
                        break;
                    case "Double":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        // get the value
                        var data = new byte[8];
                        Array.Copy(bytes, (int)numBytes, data, 0, 8);
                        info.SetValue(structValue, LRealFromByteArray(data));
                        numBytes += 8;
                        break;
                    case "String":
                        S7StringAttribute attribute = info.GetCustomAttributes<S7StringAttribute>().SingleOrDefault();
                        if (attribute == default(S7StringAttribute))
                            throw new ArgumentException("Please add S7StringAttribute to the string field");

                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;

                        // get the value
                        var sData = new byte[attribute.ReservedLengthInBytes];
                        Array.Copy(bytes, (int)numBytes, sData, 0, sData.Length);
                        switch (attribute.Type)
                        {
                            case S7StringType.S7String:
                                info.SetValue(structValue, S7StringFromByteArray(sData));
                                break;
                            case S7StringType.S7WString:
                                info.SetValue(structValue, S7WStringFromByteArray(sData));
                                break;
                            default:
                                throw new ArgumentException("Please use a valid string type for the S7StringAttribute");
                        }

                        numBytes += sData.Length;
                        break;
                    default:
                        var buffer = new byte[GetStructSize(info.FieldType)];
                        if (buffer.Length == 0)
                            continue;
                        Buffer.BlockCopy(bytes, (int)Math.Ceiling(numBytes), buffer, 0, buffer.Length);
                        info.SetValue(structValue, StructFromBytes(info.FieldType, buffer));
                        numBytes += buffer.Length;
                        break;
                }
            }
            return structValue;
        }

        /// <summary>
        /// Creates a byte array depending on the struct type.
        /// </summary>
        /// <param name="structValue">The struct object</param>
        /// <returns>A byte array or null if fails.</returns>
        public static byte[] StructToBytes(object structValue)
        {
            Type type = structValue.GetType();

            int size = GetStructSize(type);
            byte[] bytes = new byte[size];
            byte[] bytes2 = null;

            int bytePos = 0;
            int bitPos = 0;
            double numBytes = 0.0;

            var infos = type
#if NETSTANDARD1_3
                .GetTypeInfo().DeclaredFields;
#else
                .GetFields();
#endif

            foreach (var info in infos)
            {
                bytes2 = null;
                switch (info.FieldType.Name)
                {
                    case "Boolean":
                        // get the value
                        bytePos = (int)Math.Floor(numBytes);
                        bitPos = (int)((numBytes - (double)bytePos) / 0.125);
                        if ((bool)info.GetValue(structValue))
                        { bytes[bytePos] |= (byte)Math.Pow(2, bitPos); }         // is true
                        else
                        { bytes[bytePos] &= (byte)(~(byte)Math.Pow(2, bitPos)); } // is false
                        numBytes += 0.125;
                        break;
                    case "Byte":
                        numBytes = (int)Math.Ceiling(numBytes);
                        bytePos = (int)numBytes;
                        bytes[bytePos] = (byte)info.GetValue(structValue);
                        numBytes++;
                        break;
                    case "Int16":
                        bytes2 = IntToByteArray((Int16)info.GetValue(structValue));
                        break;
                    case "UInt16":
                        bytes2 = WordToByteArray((UInt16)info.GetValue(structValue));
                        break;
                    case "Int32":
                        bytes2 = DIntToByteArray((Int32)info.GetValue(structValue));
                        break;
                    case "UInt32":
                        bytes2 = DWordToByteArray((UInt32)info.GetValue(structValue));
                        break;
                    case "Single":
                        bytes2 = RealToByteArray((float)info.GetValue(structValue));
                        break;
                    case "Double":
                        bytes2 = LRealToByteArray((double)info.GetValue(structValue));
                        break;
                    case "String":
                        S7StringAttribute attribute = info.GetCustomAttributes<S7StringAttribute>().SingleOrDefault();
                        if (attribute == default(S7StringAttribute))
                            throw new ArgumentException("Please add S7StringAttribute to the string field");

                        bytes2 = attribute.Type switch
                        {
                            S7StringType.S7String => S7StringToByteArray((string)info.GetValue(structValue), attribute.ReservedLength),
                            S7StringType.S7WString => S7WStringToByteArray((string)info.GetValue(structValue), attribute.ReservedLength),
                            _ => throw new ArgumentException("Please use a valid string type for the S7StringAttribute")
                        };
                        break;
                }
                if (bytes2 != null)
                {
                    // add them
                    numBytes = Math.Ceiling(numBytes);
                    if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                        numBytes++;
                    bytePos = (int)numBytes;
                    for (int bCnt = 0; bCnt < bytes2.Length; bCnt++)
                        bytes[bytePos + bCnt] = bytes2[bCnt];
                    numBytes += bytes2.Length;
                }
            }
            return bytes;
        }
        #endregion Struct
        #region // Timer 计时器
        /// <summary>
        /// Converts the timer bytes to a double
        /// </summary>
        public static double TimerFromByteArray(byte[] bytes)
        {
            double wert = 0;

            wert = ((bytes[0]) & 0x0F) * 100.0;
            wert += ((bytes[1] >> 4) & 0x0F) * 10.0;
            wert += ((bytes[1]) & 0x0F) * 1.0;

            // this value is not used... may for a nother exponation
            //int unknown = (bytes[0] >> 6) & 0x03;

            switch ((bytes[0] >> 4) & 0x03)
            {
                case 0:
                    wert *= 0.01;
                    break;
                case 1:
                    wert *= 0.1;
                    break;
                case 2:
                    wert *= 1.0;
                    break;
                case 3:
                    wert *= 10.0;
                    break;
            }

            return wert;
        }

        /// <summary>
        /// Converts a ushort (UInt16) to an array of bytes formatted as time
        /// </summary>
        public static byte[] TimerToByteArray(UInt16 value)
        {
            byte[] bytes = new byte[2];
            bytes[1] = (byte)((int)value & 0xFF);
            bytes[0] = (byte)((int)value >> 8 & 0xFF);

            return bytes;
        }

        /// <summary>
        /// Converts an array of ushorts (Uint16) to an array of bytes formatted as time
        /// </summary>
        public static byte[] TimerToByteArray(UInt16[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (UInt16 val in value)
            { arr.Add(TimerToByteArray(val)); }
            return arr.Array;
        }

        /// <summary>
        /// Converts an array of bytes formatted as time to an array of doubles
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static double[] TimerToArray(byte[] bytes)
        {
            double[] values = new double[bytes.Length / 2];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 2; cnt++)
            { values[cnt] = TimerFromByteArray(new byte[] { bytes[counter++], bytes[counter++] }); }

            return values;
        }
        #endregion Timer
        #region // Word 无符号短整型
        /// <summary>
        /// Converts a word (2 bytes) to ushort (UInt16)
        /// </summary>
        public static UInt16 WordFromByteArray(byte[] bytes)
        {
            if (bytes.Length != 2)
            {
                throw new ArgumentException("Wrong number of bytes. Bytes array must contain 2 bytes.");
            }

            return (UInt16)((bytes[0] << 8) | bytes[1]);
        }

        /// <summary>
        /// Converts 2 bytes to ushort (UInt16)
        /// </summary>
        public static UInt16 WordFromBytes(byte b1, byte b2)
        {
            return (UInt16)((b2 << 8) | b1);
        }

        /// <summary>
        /// Converts a ushort (UInt16) to word (2 bytes)
        /// </summary>
        public static byte[] WordToByteArray(UInt16 value)
        {
            byte[] bytes = new byte[2];

            bytes[1] = (byte)(value & 0xFF);
            bytes[0] = (byte)((value >> 8) & 0xFF);

            return bytes;
        }

        /// <summary>
        /// Converts an array of ushort (UInt16) to an array of bytes
        /// </summary>
        public static byte[] WordToByteArray(UInt16[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (UInt16 val in value)
            { arr.Add(WordToByteArray(val)); }
            return arr.Array;
        }

        /// <summary>
        /// Converts an array of bytes to an array of ushort
        /// </summary>
        public static UInt16[] WordToArray(byte[] bytes)
        {
            UInt16[] values = new UInt16[bytes.Length / 2];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 2; cnt++)
            { values[cnt] = WordFromByteArray(new byte[] { bytes[counter++], bytes[counter++] }); }

            return values;
        }
        #endregion Word
    }
}
