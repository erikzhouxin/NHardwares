using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
            short output;
            output = short.Parse(input.ToString("X"), NumberStyles.HexNumber);
            return output;
        }

        /// <summary>
        /// Converts from short value to ushort value; it's used to pass negative values to DWs
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static ushort ConvertToUshort(this short input)
        {
            ushort output;
            output = ushort.Parse(input.ToString("X"), NumberStyles.HexNumber);
            return output;
        }

        /// <summary>
        /// Converts from UInt32 value to Int32 value; it's used to retrieve negative values from DBDs
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Int32 ConvertToInt(this uint input)
        {
            int output;
            output = int.Parse(input.ToString("X"), NumberStyles.HexNumber);
            return output;
        }

        /// <summary>
        /// Converts from Int32 value to UInt32 value; it's used to pass negative values to DBDs
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static UInt32 ConvertToUInt(this int input)
        {
            uint output;
            output = uint.Parse(input.ToString("X"), NumberStyles.HexNumber);
            return output;
        }

        /// <summary>
        /// Converts from float to DWord (DBD)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static UInt32 ConvertToUInt(this float input)
        {
            uint output;
            output = System.Data.NS7NetPlus.DWord.FromByteArray(System.Data.NS7NetPlus.Real.ToByteArray(input));
            return output;
        }

        /// <summary>
        /// Converts from DWord (DBD) to float
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static float ConvertToFloat(this uint input)
        {
            float output;
            output = System.Data.NS7NetPlus.Real.FromByteArray(System.Data.NS7NetPlus.DWord.ToByteArray(input));
            return output;
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
                    VarType.S7String => S7String.ToByteArray(s, dataItem.Count),
                    VarType.S7WString => S7WString.ToByteArray(s, dataItem.Count),
                    _ => System.Data.NS7NetPlus.String.ToByteArray(s, dataItem.Count)
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
                    return System.Data.NS7NetPlus.Byte.ToByteArray((byte)value);
                case "Int16":
                    return System.Data.NS7NetPlus.Int.ToByteArray((Int16)value);
                case "UInt16":
                    return System.Data.NS7NetPlus.Word.ToByteArray((UInt16)value);
                case "Int32":
                    return System.Data.NS7NetPlus.DInt.ToByteArray((Int32)value);
                case "UInt32":
                    return System.Data.NS7NetPlus.DWord.ToByteArray((UInt32)value);
                case "Single":
                    return System.Data.NS7NetPlus.Real.ToByteArray((float)value);
                case "Double":
                    return System.Data.NS7NetPlus.LReal.ToByteArray((double)value);
                case "DateTime":
                    return System.Data.NS7NetPlus.DateTime.ToByteArray((System.DateTime)value);
                case "Byte[]":
                    return (byte[])value;
                case "Int16[]":
                    return System.Data.NS7NetPlus.Int.ToByteArray((Int16[])value);
                case "UInt16[]":
                    return System.Data.NS7NetPlus.Word.ToByteArray((UInt16[])value);
                case "Int32[]":
                    return System.Data.NS7NetPlus.DInt.ToByteArray((Int32[])value);
                case "UInt32[]":
                    return System.Data.NS7NetPlus.DWord.ToByteArray((UInt32[])value);
                case "Single[]":
                    return System.Data.NS7NetPlus.Real.ToByteArray((float[])value);
                case "Double[]":
                    return System.Data.NS7NetPlus.LReal.ToByteArray((double[])value);
                case "String":
                    // Hack: This is backwards compatible with the old code, but functionally it's broken
                    // if the consumer does not pay attention to string length.
                    var stringVal = (string)value;
                    return System.Data.NS7NetPlus.String.ToByteArray(stringVal, stringVal.Length);
                case "DateTime[]":
                    return System.Data.NS7NetPlus.DateTime.ToByteArray((System.DateTime[])value);
                case "DateTimeLong[]":
                    return System.Data.NS7NetPlus.DateTimeLong.ToByteArray((System.DateTime[])value);
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

            List<Exception>? errors = null;

            for (int i = 0; i < dataItems.Length; i++)
            {
                try
                {
                    Plc.ValidateResponseCode((ReadWriteErrorCode)itemResults[i]);
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
    }
}
