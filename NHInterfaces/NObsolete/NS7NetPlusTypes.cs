using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Cobber;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace System.Data.NS7NetPlus
{
    /// <summary>
    /// 包含将位从S7 plc转换为c#的转换方法。
    /// </summary>
    [Obsolete("替代方案:S7NetPlusCaller.Bit*")]
    public static class Bit
    {
        /// <summary>
        /// 转换一个位成布尔
        /// </summary>
        [Obsolete("替代方案:S7NetPlusCaller.BitFromByte")]
        public static bool FromByte(byte v, byte bitAdr)
        {
            return (((int)v & (1 << bitAdr)) != 0);
        }
        /// <summary>
        /// 将字节数组转换成位数组
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>A BitArray with the same number of bits and equal values as <paramref name="bytes"/>.</returns>
        [Obsolete("替代方案:S7NetPlusCaller.BitToBitArray")]
        public static BitArray ToBitArray(byte[] bytes) => ToBitArray(bytes, bytes.Length * 8);
        /// <summary>
        /// 将字节数组转换成位数组
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="length">返回位长度</param>
        /// <returns>A BitArray with <paramref name="length"/> bits.</returns>
        [Obsolete("替代方案:S7NetPlusCaller.BitToBitArray")]
        public static BitArray ToBitArray(byte[] bytes, int length)
        {
            if (length > bytes.Length * 8) { throw new ArgumentException($"Not enough data in bytes to return {length} bits.", nameof(bytes)); }
            var bitArr = new BitArray(bytes);
            var bools = new bool[length];
            for (var i = 0; i < length; i++) 
            { bools[i] = bitArr[i]; }
            return new BitArray(bools);
        }
    }
    /// <summary>
    /// Contains the methods to read, set and reset bits inside bytes
    /// </summary>
    public static class Boolean
    {
        /// <summary>
        /// Returns the value of a bit in a bit, given the address of the bit
        /// </summary>
        public static bool GetValue(byte value, int bit)
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
        public static byte SetBit(byte value, int bit)
        {
            SetBit(ref value, bit);

            return value;
        }

        /// <summary>
        /// Sets the value of a bit to 1 (true), given the address of the bit.
        /// </summary>
        /// <param name="value">The value to modify.</param>
        /// <param name="bit">The index (zero based) of the bit to set.</param>
        public static void SetBit(ref byte value, int bit)
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
        public static byte ClearBit(byte value, int bit)
        {
            ClearBit(ref value, bit);

            return value;
        }

        /// <summary>
        /// Resets the value of a bit to 0 (false), given the address of the bit
        /// </summary>
        /// <param name="value">The input value to modify.</param>
        /// <param name="bit">The index (zero based) of the bit to clear.</param>
        public static void ClearBit(ref byte value, int bit)
        {
            value = (byte)(value & ~(1 << bit) & 0xFF);
        }
    }
    /// <summary>
    /// Contains the methods to convert from bytes to byte arrays
    /// </summary>
    public static class Byte
    {
        /// <summary>
        /// Converts a byte to byte array
        /// </summary>
        public static byte[] ToByteArray(byte value)
        {
            return new byte[] { value }; ;
        }

        /// <summary>
        /// Converts a byte array to byte
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte FromByteArray(byte[] bytes)
        {
            if (bytes.Length != 1)
            {
                throw new ArgumentException("Wrong number of bytes. Bytes array must contain 1 bytes.");
            }
            return bytes[0];
        }

    }
    /// <summary>
    /// Contains the methods to convert a C# class to S7 data types
    /// </summary>
    public static class Class
    {
        private static IEnumerable<PropertyInfo> GetAccessableProperties(Type classType)
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

        private static double GetIncreasedNumberOfBytes(double numBytes, Type type, PropertyInfo? propertyInfo)
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
                    IncrementToEven(ref numBytes);
                    numBytes += 2;
                    break;
                case "Int32":
                case "UInt32":
                    IncrementToEven(ref numBytes);
                    numBytes += 4;
                    break;
                case "Single":
                    IncrementToEven(ref numBytes);
                    numBytes += 4;
                    break;
                case "Double":
                    IncrementToEven(ref numBytes);
                    numBytes += 8;
                    break;
                case "String":
                    S7StringAttribute? attribute = propertyInfo?.GetCustomAttributes<S7StringAttribute>().SingleOrDefault();
                    if (attribute == default(S7StringAttribute))
                        throw new ArgumentException("Please add S7StringAttribute to the string field");

                    IncrementToEven(ref numBytes);
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
        /// <returns>the number of bytes</returns>
        public static double GetClassSize(object instance, double numBytes = 0.0, bool isInnerProperty = false)
        {
            var properties = GetAccessableProperties(instance.GetType());
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

                    IncrementToEven(ref numBytes);
                    for (int i = 0; i < array.Length; i++)
                    {
                        numBytes = GetIncreasedNumberOfBytes(numBytes, elementType, property);
                    }
                }
                else
                {
                    numBytes = GetIncreasedNumberOfBytes(numBytes, property.PropertyType, property);
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

        private static object? GetPropertyValue(Type propertyType, PropertyInfo? propertyInfo, byte[] bytes, ref double numBytes)
        {
            object? value = null;

            switch (propertyType.Name)
            {
                case "Boolean":
                    // get the value
                    int bytePos = (int)Math.Floor(numBytes);
                    int bitPos = (int)((numBytes - (double)bytePos) / 0.125);
                    if ((bytes[bytePos] & (int)Math.Pow(2, bitPos)) != 0)
                        value = true;
                    else
                        value = false;
                    numBytes += 0.125;
                    break;
                case "Byte":
                    numBytes = Math.Ceiling(numBytes);
                    value = (byte)(bytes[(int)numBytes]);
                    numBytes++;
                    break;
                case "Int16":
                    IncrementToEven(ref numBytes);
                    // hier auswerten
                    ushort source = Word.FromBytes(bytes[(int)numBytes + 1], bytes[(int)numBytes]);
                    value = source.ConvertToShort();
                    numBytes += 2;
                    break;
                case "UInt16":
                    IncrementToEven(ref numBytes);
                    // hier auswerten
                    value = Word.FromBytes(bytes[(int)numBytes + 1], bytes[(int)numBytes]);
                    numBytes += 2;
                    break;
                case "Int32":
                    IncrementToEven(ref numBytes);
                    var wordBuffer = new byte[4];
                    Array.Copy(bytes, (int)numBytes, wordBuffer, 0, wordBuffer.Length);
                    uint sourceUInt = DWord.FromByteArray(wordBuffer);
                    value = sourceUInt.ConvertToInt();
                    numBytes += 4;
                    break;
                case "UInt32":
                    IncrementToEven(ref numBytes);
                    var wordBuffer2 = new byte[4];
                    Array.Copy(bytes, (int)numBytes, wordBuffer2, 0, wordBuffer2.Length);
                    value = DWord.FromByteArray(wordBuffer2);
                    numBytes += 4;
                    break;
                case "Single":
                    IncrementToEven(ref numBytes);
                    // hier auswerten
                    value = Real.FromByteArray(
                        new byte[] {
                            bytes[(int)numBytes],
                            bytes[(int)numBytes + 1],
                            bytes[(int)numBytes + 2],
                            bytes[(int)numBytes + 3] });
                    numBytes += 4;
                    break;
                case "Double":
                    IncrementToEven(ref numBytes);
                    var buffer = new byte[8];
                    Array.Copy(bytes, (int)numBytes, buffer, 0, 8);
                    // hier auswerten
                    value = LReal.FromByteArray(buffer);
                    numBytes += 8;
                    break;
                case "String":
                    S7StringAttribute? attribute = propertyInfo?.GetCustomAttributes<S7StringAttribute>().SingleOrDefault();
                    if (attribute == default(S7StringAttribute))
                        throw new ArgumentException("Please add S7StringAttribute to the string field");

                    IncrementToEven(ref numBytes);

                    // get the value
                    var sData = new byte[attribute.ReservedLengthInBytes];
                    Array.Copy(bytes, (int)numBytes, sData, 0, sData.Length);
                    value = attribute.Type switch
                    {
                        S7StringType.S7String => S7String.FromByteArray(sData),
                        S7StringType.S7WString => S7WString.FromByteArray(sData),
                        _ => throw new ArgumentException("Please use a valid string type for the S7StringAttribute")
                    };
                    numBytes += sData.Length;
                    break;
                default:
                    var propClass = Activator.CreateInstance(propertyType);
                    numBytes = FromBytes(propClass, bytes, numBytes);
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
        public static double FromBytes(object sourceClass, byte[] bytes, double numBytes = 0, bool isInnerClass = false)
        {
            if (bytes == null)
                return numBytes;

            var properties = GetAccessableProperties(sourceClass.GetType());
            foreach (var property in properties)
            {
                if (property.PropertyType.IsArray)
                {
                    Array array = (Array)property.GetValue(sourceClass, null);
                    IncrementToEven(ref numBytes);
                    Type elementType = property.PropertyType.GetElementType();
                    for (int i = 0; i < array.Length && numBytes < bytes.Length; i++)
                    {
                        array.SetValue(
                            GetPropertyValue(elementType, property, bytes, ref numBytes),
                            i);
                    }
                }
                else
                {
                    property.SetValue(
                        sourceClass,
                        GetPropertyValue(property.PropertyType, property, bytes, ref numBytes),
                        null);
                }
            }

            return numBytes;
        }

        private static double SetBytesFromProperty(object propertyValue, PropertyInfo? propertyInfo, byte[] bytes, double numBytes)
        {
            int bytePos = 0;
            int bitPos = 0;
            byte[]? bytes2 = null;

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
                    bytes2 = Int.ToByteArray((Int16)propertyValue);
                    break;
                case "UInt16":
                    bytes2 = Word.ToByteArray((UInt16)propertyValue);
                    break;
                case "Int32":
                    bytes2 = DInt.ToByteArray((Int32)propertyValue);
                    break;
                case "UInt32":
                    bytes2 = DWord.ToByteArray((UInt32)propertyValue);
                    break;
                case "Single":
                    bytes2 = Real.ToByteArray((float)propertyValue);
                    break;
                case "Double":
                    bytes2 = LReal.ToByteArray((double)propertyValue);
                    break;
                case "String":
                    S7StringAttribute? attribute = propertyInfo?.GetCustomAttributes<S7StringAttribute>().SingleOrDefault();
                    if (attribute == default(S7StringAttribute))
                        throw new ArgumentException("Please add S7StringAttribute to the string field");

                    bytes2 = attribute.Type switch
                    {
                        S7StringType.S7String => S7String.ToByteArray((string)propertyValue, attribute.ReservedLength),
                        S7StringType.S7WString => S7WString.ToByteArray((string)propertyValue, attribute.ReservedLength),
                        _ => throw new ArgumentException("Please use a valid string type for the S7StringAttribute")
                    };
                    break;
                default:
                    numBytes = ToBytes(propertyValue, bytes, numBytes);
                    break;
            }

            if (bytes2 != null)
            {
                IncrementToEven(ref numBytes);

                bytePos = (int)numBytes;
                for (int bCnt = 0; bCnt < bytes2.Length; bCnt++)
                    bytes[bytePos + bCnt] = bytes2[bCnt];
                numBytes += bytes2.Length;
            }

            return numBytes;
        }

        /// <summary>
        /// Creates a byte array depending on the struct type.
        /// </summary>
        /// <param name="sourceClass">The struct object</param>
        /// <returns>A byte array or null if fails.</returns>
        public static double ToBytes(object sourceClass, byte[] bytes, double numBytes = 0.0)
        {
            var properties = GetAccessableProperties(sourceClass.GetType());
            foreach (var property in properties)
            {
                if (property.PropertyType.IsArray)
                {
                    Array array = (Array)property.GetValue(sourceClass, null);
                    IncrementToEven(ref numBytes);
                    Type elementType = property.PropertyType.GetElementType();
                    for (int i = 0; i < array.Length && numBytes < bytes.Length; i++)
                    {
                        numBytes = SetBytesFromProperty(array.GetValue(i), property, bytes, numBytes);
                    }
                }
                else
                {
                    numBytes = SetBytesFromProperty(property.GetValue(sourceClass, null), property, bytes, numBytes);
                }
            }
            return numBytes;
        }

        private static void IncrementToEven(ref double numBytes)
        {
            numBytes = Math.Ceiling(numBytes);
            if (numBytes % 2 > 0) numBytes++;
        }
    }
    /// <summary>
    /// Contains the conversion methods to convert Counter from S7 plc to C# ushort (UInt16).
    /// </summary>
    public static class Counter
    {
        /// <summary>
        /// Converts a Counter (2 bytes) to ushort (UInt16)
        /// </summary>
        public static UInt16 FromByteArray(byte[] bytes)
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
        public static byte[] ToByteArray(UInt16 value)
        {
            byte[] bytes = new byte[2];

            bytes[0] = (byte)((value << 8) & 0xFF);
            bytes[1] = (byte)((value) & 0xFF);

            return bytes;
        }

        /// <summary>
        /// Converts an array of ushort (UInt16) to an array of bytes
        /// </summary>
        public static byte[] ToByteArray(UInt16[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (UInt16 val in value)
                arr.Add(ToByteArray(val));
            return arr.Array;
        }

        /// <summary>
        /// Converts an array of bytes to an array of ushort
        /// </summary>
        public static UInt16[] ToArray(byte[] bytes)
        {
            UInt16[] values = new UInt16[bytes.Length / 2];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 2; cnt++)
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++] });

            return values;
        }
    }
    /// <summary>
    /// Contains the methods to convert between <see cref="T:System.DateTime"/> and S7 representation of datetime values.
    /// </summary>
    public static class DateTime
    {
        /// <summary>
        /// The minimum <see cref="T:System.DateTime"/> value supported by the specification.
        /// </summary>
        public static readonly System.DateTime SpecMinimumDateTime = new System.DateTime(1990, 1, 1);

        /// <summary>
        /// The maximum <see cref="T:System.DateTime"/> value supported by the specification.
        /// </summary>
        public static readonly System.DateTime SpecMaximumDateTime = new System.DateTime(2089, 12, 31, 23, 59, 59, 999);

        /// <summary>
        /// Parses a <see cref="T:System.DateTime"/> value from bytes.
        /// </summary>
        /// <param name="bytes">Input bytes read from PLC.</param>
        /// <returns>A <see cref="T:System.DateTime"/> object representing the value read from PLC.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the length of
        ///   <paramref name="bytes"/> is not 8 or any value in <paramref name="bytes"/>
        ///   is outside the valid range of values.</exception>
        public static System.DateTime FromByteArray(byte[] bytes)
        {
            return FromByteArrayImpl(bytes);
        }

        /// <summary>
        /// Parses an array of <see cref="T:System.DateTime"/> values from bytes.
        /// </summary>
        /// <param name="bytes">Input bytes read from PLC.</param>
        /// <returns>An array of <see cref="T:System.DateTime"/> objects representing the values read from PLC.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the length of
        ///   <paramref name="bytes"/> is not a multiple of 8 or any value in
        ///   <paramref name="bytes"/> is outside the valid range of values.</exception>
        public static System.DateTime[] ToArray(byte[] bytes)
        {
            if (bytes.Length % 8 != 0)
                throw new ArgumentOutOfRangeException(nameof(bytes), bytes.Length,
                    $"Parsing an array of DateTime requires a multiple of 8 bytes of input data, input data is '{bytes.Length}' long.");

            var cnt = bytes.Length / 8;
            var result = new System.DateTime[bytes.Length / 8];

            for (var i = 0; i < cnt; i++)
            {
#if NET40
                result[i] = FromByteArrayImpl(bytes.Skip(i * 8).Take(8).ToList());
#else
                result[i] = FromByteArrayImpl(new ArraySegment<byte>(bytes, i * 8, 8));
#endif
            }

            return result;
        }

        private static System.DateTime FromByteArrayImpl(IList<byte> bytes)
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
        ///   <paramref name="dateTime"/> is before <see cref="P:SpecMinimumDateTime"/>
        ///   or after <see cref="P:SpecMaximumDateTime"/>.</exception>
        public static byte[] ToByteArray(System.DateTime dateTime)
        {
            byte EncodeBcd(int value)
            {
                return (byte)((value / 10 << 4) | value % 10);
            }

            if (dateTime < SpecMinimumDateTime)
                throw new ArgumentOutOfRangeException(nameof(dateTime), dateTime,
                    $"Date time '{dateTime}' is before the minimum '{SpecMinimumDateTime}' supported in S7 date time representation.");

            if (dateTime > SpecMaximumDateTime)
                throw new ArgumentOutOfRangeException(nameof(dateTime), dateTime,
                    $"Date time '{dateTime}' is after the maximum '{SpecMaximumDateTime}' supported in S7 date time representation.");

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
        /// <returns>A byte array containing the S7 date time representations of <paramref name="dateTime"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when any value of
        ///   <paramref name="dateTimes"/> is before <see cref="P:SpecMinimumDateTime"/>
        ///   or after <see cref="P:SpecMaximumDateTime"/>.</exception>
        public static byte[] ToByteArray(System.DateTime[] dateTimes)
        {
            var bytes = new List<byte>(dateTimes.Length * 8);
            foreach (var dateTime in dateTimes) bytes.AddRange(ToByteArray(dateTime));

            return bytes.ToArray();
        }
    }
    /// <summary>
    /// Contains the methods to convert between <see cref="T:System.DateTime" /> and S7 representation of DateTimeLong (DTL) values.
    /// </summary>
    public static class DateTimeLong
    {
        public const int TypeLengthInBytes = 12;
        /// <summary>
        /// The minimum <see cref="T:System.DateTime" /> value supported by the specification.
        /// </summary>
        public static readonly System.DateTime SpecMinimumDateTime = new System.DateTime(1970, 1, 1);

        /// <summary>
        /// The maximum <see cref="T:System.DateTime" /> value supported by the specification.
        /// </summary>
        public static readonly System.DateTime SpecMaximumDateTime = new System.DateTime(2262, 4, 11, 23, 47, 16, 854);

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
        public static System.DateTime FromByteArray(byte[] bytes)
        {
            return FromByteArrayImpl(bytes);
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
        public static System.DateTime[] ToArray(byte[] bytes)
        {
            if (bytes.Length % TypeLengthInBytes != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bytes), bytes.Length,
                    $"Parsing an array of DateTimeLong requires a multiple of 12 bytes of input data, input data is '{bytes.Length}' long.");
            }

            var cnt = bytes.Length / TypeLengthInBytes;
            var result = new System.DateTime[cnt];

            for (var i = 0; i < cnt; i++)
            {
                var slice = new byte[TypeLengthInBytes];
                Array.Copy(bytes, i * TypeLengthInBytes, slice, 0, TypeLengthInBytes);
                result[i] = FromByteArrayImpl(slice);
            }

            return result;
        }

        private static System.DateTime FromByteArrayImpl(byte[] bytes)
        {
            if (bytes.Length != TypeLengthInBytes)
            {
                throw new ArgumentOutOfRangeException(nameof(bytes), bytes.Length,
                    $"Parsing a DateTimeLong requires exactly 12 bytes of input data, input data is {bytes.Length} bytes long.");
            }


            var year = AssertRangeInclusive(Word.FromBytes(bytes[1], bytes[0]), 1970, 2262, "year");
            var month = AssertRangeInclusive(bytes[2], 1, 12, "month");
            var day = AssertRangeInclusive(bytes[3], 1, 31, "day of month");
            var dayOfWeek = AssertRangeInclusive(bytes[4], 1, 7, "day of week");
            var hour = AssertRangeInclusive(bytes[5], 0, 23, "hour");
            var minute = AssertRangeInclusive(bytes[6], 0, 59, "minute");
            var second = AssertRangeInclusive(bytes[7], 0, 59, "second");
            ;

            var nanoseconds = AssertRangeInclusive<uint>(DWord.FromBytes(bytes[11], bytes[10], bytes[9], bytes[8]), 0,
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
        /// <paramref name="dateTime" /> is before <see cref="P:SpecMinimumDateTime" />
        /// or after <see cref="P:SpecMaximumDateTime" />.
        /// </exception>
        public static byte[] ToByteArray(System.DateTime dateTime)
        {
            if (dateTime < SpecMinimumDateTime)
            {
                throw new ArgumentOutOfRangeException(nameof(dateTime), dateTime,
                    $"Date time '{dateTime}' is before the minimum '{SpecMinimumDateTime}' supported in S7 DateTimeLong representation.");
            }

            if (dateTime > SpecMaximumDateTime)
            {
                throw new ArgumentOutOfRangeException(nameof(dateTime), dateTime,
                    $"Date time '{dateTime}' is after the maximum '{SpecMaximumDateTime}' supported in S7 DateTimeLong representation.");
            }

            var stream = new MemoryStream(TypeLengthInBytes);
            // Convert Year
            stream.Write(Word.ToByteArray(Convert.ToUInt16(dateTime.Year)), 0, 2);

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
            stream.Write(DWord.ToByteArray(Convert.ToUInt32(dateTime.Ticks % 10000000 * 100)), 0, 4);

            return stream.ToArray();
        }

        /// <summary>
        /// Converts an array of <see cref="T:System.DateTime" /> values to a byte array.
        /// </summary>
        /// <param name="dateTimes">The DateTime values to convert.</param>
        /// <returns>A byte array containing the S7 DateTimeLong representations of <paramref name="dateTimes" />.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when any value of
        /// <paramref name="dateTimes" /> is before <see cref="P:SpecMinimumDateTime" />
        /// or after <see cref="P:SpecMaximumDateTime" />.
        /// </exception>
        public static byte[] ToByteArray(System.DateTime[] dateTimes)
        {
            var bytes = new List<byte>(dateTimes.Length * TypeLengthInBytes);
            foreach (var dateTime in dateTimes)
            {
                bytes.AddRange(ToByteArray(dateTime));
            }

            return bytes.ToArray();
        }

        private static T AssertRangeInclusive<T>(T input, T min, T max, string field) where T : IComparable<T>
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
    }
    /// <summary>
    /// Contains the conversion methods to convert DWord from S7 plc to C#.
    /// </summary>
    public static class DWord
    {
        /// <summary>
        /// Converts a S7 DWord (4 bytes) to uint (UInt32)
        /// </summary>
        public static UInt32 FromByteArray(byte[] bytes)
        {
            return (UInt32)(bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3]);
        }


        /// <summary>
        /// Converts 4 bytes to DWord (UInt32)
        /// </summary>
        public static UInt32 FromBytes(byte b1, byte b2, byte b3, byte b4)
        {
            return (UInt32)((b4 << 24) | (b3 << 16) | (b2 << 8) | b1);
        }


        /// <summary>
        /// Converts a uint (UInt32) to S7 DWord (4 bytes) 
        /// </summary>
        public static byte[] ToByteArray(UInt32 value)
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
        public static byte[] ToByteArray(UInt32[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (UInt32 val in value)
                arr.Add(ToByteArray(val));
            return arr.Array;
        }

        /// <summary>
        /// Converts an array of S7 DWord to an array of uint (UInt32)
        /// </summary>
        public static UInt32[] ToArray(byte[] bytes)
        {
            UInt32[] values = new UInt32[bytes.Length / 4];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 4; cnt++)
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++], bytes[counter++], bytes[counter++] });

            return values;
        }
    }
    /// <summary>
    /// Contains the conversion methods to convert Real from S7 plc to C# double.
    /// </summary>
    [Obsolete("Class Double is obsolete. Use Real instead for 32bit floating point, or LReal for 64bit floating point.")]
    public static class Double
    {
        /// <summary>
        /// Converts a S7 Real (4 bytes) to double
        /// </summary>
        public static double FromByteArray(byte[] bytes) => Real.FromByteArray(bytes);

        /// <summary>
        /// Converts a S7 DInt to double
        /// </summary>
        public static double FromDWord(Int32 value)
        {
            byte[] b = DInt.ToByteArray(value);
            double d = FromByteArray(b);
            return d;
        }

        /// <summary>
        /// Converts a S7 DWord to double
        /// </summary>
        public static double FromDWord(UInt32 value)
        {
            byte[] b = DWord.ToByteArray(value);
            double d = FromByteArray(b);
            return d;
        }


        /// <summary>
        /// Converts a double to S7 Real (4 bytes)
        /// </summary>
        public static byte[] ToByteArray(double value) => Real.ToByteArray((float)value);

        /// <summary>
        /// Converts an array of double to an array of bytes 
        /// </summary>
        public static byte[] ToByteArray(double[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (double val in value)
                arr.Add(ToByteArray(val));
            return arr.Array;
        }

        /// <summary>
        /// Converts an array of S7 Real to an array of double
        /// </summary>
        public static double[] ToArray(byte[] bytes)
        {
            double[] values = new double[bytes.Length / 4];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 4; cnt++)
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++], bytes[counter++], bytes[counter++] });

            return values;
        }

    }
    /// <summary>
    /// Contains the conversion methods to convert DInt from S7 plc to C# int (Int32).
    /// </summary>
    public static class DInt
    {
        /// <summary>
        /// Converts a S7 DInt (4 bytes) to int (Int32)
        /// </summary>
        public static Int32 FromByteArray(byte[] bytes)
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
        public static byte[] ToByteArray(Int32 value)
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
        public static byte[] ToByteArray(Int32[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (Int32 val in value)
                arr.Add(ToByteArray(val));
            return arr.Array;
        }

        /// <summary>
        /// Converts an array of S7 DInt to an array of int (Int32)
        /// </summary>
        public static Int32[] ToArray(byte[] bytes)
        {
            Int32[] values = new Int32[bytes.Length / 4];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 4; cnt++)
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++], bytes[counter++], bytes[counter++] });

            return values;
        }


    }
    /// <summary>
    /// Contains the conversion methods to convert Int from S7 plc to C#.
    /// </summary>
    public static class Int
    {
        /// <summary>
        /// Converts a S7 Int (2 bytes) to short (Int16)
        /// </summary>
        public static short FromByteArray(byte[] bytes)
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
        public static byte[] ToByteArray(Int16 value)
        {
            byte[] bytes = new byte[2];

            bytes[0] = (byte)(value >> 8 & 0xFF);
            bytes[1] = (byte)(value & 0xFF);

            return bytes;
        }

        /// <summary>
        /// Converts an array of short (Int16) to a S7 Int byte array (2 bytes)
        /// </summary>
        public static byte[] ToByteArray(Int16[] value)
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
        public static Int16[] ToArray(byte[] bytes)
        {
            int shortsCount = bytes.Length / 2;

            Int16[] values = new Int16[shortsCount];

            int counter = 0;
            for (int cnt = 0; cnt < shortsCount; cnt++)
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++] });

            return values;
        }

        /// <summary>
        /// Converts a C# int value to a C# short value, to be used as word.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int16 CWord(int value)
        {
            if (value > 32767)
            {
                value -= 32768;
                value = 32768 - value;
                value *= -1;
            }
            return (short)value;
        }

    }
    /// <summary>
    /// Contains the conversion methods to convert Real from S7 plc to C# double.
    /// </summary>
    public static class LReal
    {
        /// <summary>
        /// Converts a S7 LReal (8 bytes) to double
        /// </summary>
        public static double FromByteArray(byte[] bytes)
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
        public static byte[] ToByteArray(double value)
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
        public static byte[] ToByteArray(double[] value) => S7NetPlusCaller.ToByteArray(value, ToByteArray);

        /// <summary>
        /// Converts an array of S7 LReal to an array of double
        /// </summary>
        public static double[] ToArray(byte[] bytes) => S7NetPlusCaller.ToArray(bytes, FromByteArray);

    }
    /// <summary>
    /// Contains the conversion methods to convert Real from S7 plc to C# double.
    /// </summary>
    public static class Real
    {
        /// <summary>
        /// Converts a S7 Real (4 bytes) to float
        /// </summary>
        public static float FromByteArray(byte[] bytes)
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
        public static byte[] ToByteArray(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            // sps uses bigending so we have to check if platform is same
            if (!BitConverter.IsLittleEndian) return bytes;

            // create deep copy of the array and reverse
            return new byte[] { bytes[3], bytes[2], bytes[1], bytes[0] };
        }

        /// <summary>
        /// Converts an array of float to an array of bytes 
        /// </summary>
        public static byte[] ToByteArray(float[] value)
        {
            var buffer = new byte[4 * value.Length];
            var stream = new MemoryStream(buffer);
            foreach (var val in value)
            {
                stream.Write(ToByteArray(val), 0, 4);
            }

            return buffer;
        }

        /// <summary>
        /// Converts an array of S7 Real to an array of float
        /// </summary>
        public static float[] ToArray(byte[] bytes)
        {
            var values = new float[bytes.Length / 4];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 4; cnt++)
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++], bytes[counter++], bytes[counter++] });

            return values;
        }

    }
    /// <summary>
    /// Contains the methods to convert from S7 strings to C# strings
    /// An S7 String has a preceeding 2 byte header containing its capacity and length
    /// </summary>
    public static class S7String
    {
        private static Encoding stringEncoding = Encoding.ASCII;

        /// <summary>
        /// The Encoding used when serializing and deserializing S7String (Encoding.ASCII by default)
        /// </summary>
        /// <exception cref="ArgumentNullException">StringEncoding must not be null</exception>
        public static Encoding StringEncoding
        {
            get => stringEncoding;
            set => stringEncoding = value ?? throw new ArgumentNullException(nameof(StringEncoding));
        }

        /// <summary>
        /// Converts S7 bytes to a string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string FromByteArray(byte[] bytes)
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
                return StringEncoding.GetString(bytes, 2, length);
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
        /// <returns>A <see cref="T:byte[]" /> containing the string header and string value with a maximum length of <paramref name="reservedLength"/> + 2.</returns>
        public static byte[] ToByteArray(string value, int reservedLength)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (reservedLength > 254) throw new ArgumentException($"The maximum string length supported is 254.");

            var bytes = StringEncoding.GetBytes(value);
            if (bytes.Length > reservedLength) throw new ArgumentException($"The provided string length ({bytes.Length} is larger than the specified reserved length ({reservedLength}).");

            var buffer = new byte[2 + reservedLength];
            Array.Copy(bytes, 0, buffer, 2, bytes.Length);
            buffer[0] = (byte)reservedLength;
            buffer[1] = (byte)bytes.Length;
            return buffer;
        }
    }
    /// <summary>
    /// Contains the methods to convert from S7 wstrings to C# strings
    /// An S7 WString has a preceding 4 byte header containing its capacity and length
    /// </summary>
    public static class S7WString
    {
        /// <summary>
        /// Converts S7 bytes to a string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string FromByteArray(byte[] bytes)
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
                return Encoding.BigEndianUnicode.GetString(bytes, 4, length * 2);
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
        /// <returns>A <see cref="T:byte[]" /> containing the string header and string value with a maximum length of <paramref name="reservedLength"/> + 4.</returns>
        public static byte[] ToByteArray(string value, int reservedLength)
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

            var stringLength = Encoding.BigEndianUnicode.GetBytes(value, 0, value.Length, buffer, 4) / 2;
            if (stringLength > reservedLength) throw new ArgumentException($"The provided string length ({stringLength} is larger than the specified reserved length ({reservedLength}).");

            return buffer;
        }
    }
    /// <summary>
    /// Contains the conversion methods to convert Real from S7 plc to C# float.
    /// </summary>
    [Obsolete("Class Single is obsolete. Use Real instead.")]
    public static class Single
    {
        /// <summary>
        /// Converts a S7 Real (4 bytes) to float
        /// </summary>
        public static float FromByteArray(byte[] bytes) => Real.FromByteArray(bytes);

        /// <summary>
        /// Converts a S7 DInt to float
        /// </summary>
        public static float FromDWord(Int32 value)
        {
            byte[] b = DInt.ToByteArray(value);
            float d = FromByteArray(b);
            return d;
        }

        /// <summary>
        /// Converts a S7 DWord to float
        /// </summary>
        public static float FromDWord(UInt32 value)
        {
            byte[] b = DWord.ToByteArray(value);
            float d = FromByteArray(b);
            return d;
        }


        /// <summary>
        /// Converts a double to S7 Real (4 bytes)
        /// </summary>
        public static byte[] ToByteArray(float value) => Real.ToByteArray(value);

        /// <summary>
        /// Converts an array of float to an array of bytes 
        /// </summary>
        public static byte[] ToByteArray(float[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (float val in value)
                arr.Add(ToByteArray(val));
            return arr.Array;
        }

        /// <summary>
        /// Converts an array of S7 Real to an array of float
        /// </summary>
        public static float[] ToArray(byte[] bytes)
        {
            float[] values = new float[bytes.Length / 4];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 4; cnt++)
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++], bytes[counter++], bytes[counter++] });

            return values;
        }

    }
    /// <summary>
    /// Contains the methods to convert from S7 Array of Chars (like a const char[N] C-String) to C# strings
    /// </summary>
    public class String
    {
        /// <summary>
        /// Converts a string to <paramref name="reservedLength"/> of bytes, padded with 0-bytes if required.
        /// </summary>
        /// <param name="value">The string to write to the PLC.</param>
        /// <param name="reservedLength">The amount of bytes reserved for the <paramref name="value"/> in the PLC.</param>
        public static byte[] ToByteArray(string value, int reservedLength)
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
        public static string FromByteArray(byte[] bytes)
        {
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

    }
    /// <inheritdoc cref="S7String"/>
    [Obsolete("Please use S7String class")]
    public static class StringEx
    {
        /// <inheritdoc cref="S7String.FromByteArray(byte[])"/>
        public static string FromByteArray(byte[] bytes) => S7String.FromByteArray(bytes);

        /// <inheritdoc cref="S7String.ToByteArray(string, int)"/>
        public static byte[] ToByteArray(string value, int reservedLength) => S7String.ToByteArray(value, reservedLength);
    }
    /// <summary>
    /// Contains the method to convert a C# struct to S7 data types
    /// </summary>
    public static class Struct
    {
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
                        S7StringAttribute? attribute = info.GetCustomAttributes<S7StringAttribute>().SingleOrDefault();
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
        public static object? FromBytes(Type structType, byte[] bytes)
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
                        ushort source = Word.FromBytes(bytes[(int)numBytes + 1], bytes[(int)numBytes]);
                        info.SetValue(structValue, source.ConvertToShort());
                        numBytes += 2;
                        break;
                    case "UInt16":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        // get the value
                        info.SetValue(structValue, Word.FromBytes(bytes[(int)numBytes + 1],
                                                                          bytes[(int)numBytes]));
                        numBytes += 2;
                        break;
                    case "Int32":
                        numBytes = Math.Ceiling(numBytes);
                        if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
                            numBytes++;
                        // get the value
                        uint sourceUInt = DWord.FromBytes(bytes[(int)numBytes + 3],
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
                        info.SetValue(structValue, DWord.FromBytes(bytes[(int)numBytes],
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
                        info.SetValue(structValue, Real.FromByteArray(new byte[] { bytes[(int)numBytes],
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
                        info.SetValue(structValue, LReal.FromByteArray(data));
                        numBytes += 8;
                        break;
                    case "String":
                        S7StringAttribute? attribute = info.GetCustomAttributes<S7StringAttribute>().SingleOrDefault();
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
                                info.SetValue(structValue, S7String.FromByteArray(sData));
                                break;
                            case S7StringType.S7WString:
                                info.SetValue(structValue, S7WString.FromByteArray(sData));
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
                        info.SetValue(structValue, FromBytes(info.FieldType, buffer));
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
        public static byte[] ToBytes(object structValue)
        {
            Type type = structValue.GetType();

            int size = Struct.GetStructSize(type);
            byte[] bytes = new byte[size];
            byte[]? bytes2 = null;

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
                            bytes[bytePos] |= (byte)Math.Pow(2, bitPos);            // is true
                        else
                            bytes[bytePos] &= (byte)(~(byte)Math.Pow(2, bitPos));   // is false
                        numBytes += 0.125;
                        break;
                    case "Byte":
                        numBytes = (int)Math.Ceiling(numBytes);
                        bytePos = (int)numBytes;
                        bytes[bytePos] = (byte)info.GetValue(structValue);
                        numBytes++;
                        break;
                    case "Int16":
                        bytes2 = Int.ToByteArray((Int16)info.GetValue(structValue));
                        break;
                    case "UInt16":
                        bytes2 = Word.ToByteArray((UInt16)info.GetValue(structValue));
                        break;
                    case "Int32":
                        bytes2 = DInt.ToByteArray((Int32)info.GetValue(structValue));
                        break;
                    case "UInt32":
                        bytes2 = DWord.ToByteArray((UInt32)info.GetValue(structValue));
                        break;
                    case "Single":
                        bytes2 = Real.ToByteArray((float)info.GetValue(structValue));
                        break;
                    case "Double":
                        bytes2 = LReal.ToByteArray((double)info.GetValue(structValue));
                        break;
                    case "String":
                        S7StringAttribute? attribute = info.GetCustomAttributes<S7StringAttribute>().SingleOrDefault();
                        if (attribute == default(S7StringAttribute))
                            throw new ArgumentException("Please add S7StringAttribute to the string field");

                        bytes2 = attribute.Type switch
                        {
                            S7StringType.S7String => S7String.ToByteArray((string)info.GetValue(structValue), attribute.ReservedLength),
                            S7StringType.S7WString => S7WString.ToByteArray((string)info.GetValue(structValue), attribute.ReservedLength),
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
    }
    /// <summary>
    /// Converts the Timer data type to C# data type
    /// </summary>
    public static class Timer
    {
        /// <summary>
        /// Converts the timer bytes to a double
        /// </summary>
        public static double FromByteArray(byte[] bytes)
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
        public static byte[] ToByteArray(UInt16 value)
        {
            byte[] bytes = new byte[2];
            bytes[1] = (byte)((int)value & 0xFF);
            bytes[0] = (byte)((int)value >> 8 & 0xFF);

            return bytes;
        }

        /// <summary>
        /// Converts an array of ushorts (Uint16) to an array of bytes formatted as time
        /// </summary>
        public static byte[] ToByteArray(UInt16[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (UInt16 val in value)
                arr.Add(ToByteArray(val));
            return arr.Array;
        }

        /// <summary>
        /// Converts an array of bytes formatted as time to an array of doubles
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static double[] ToArray(byte[] bytes)
        {
            double[] values = new double[bytes.Length / 2];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 2; cnt++)
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++] });

            return values;
        }
    }
    /// <summary>
    /// Contains the conversion methods to convert Words from S7 plc to C#.
    /// </summary>
    public static class Word
    {
        /// <summary>
        /// Converts a word (2 bytes) to ushort (UInt16)
        /// </summary>
        public static UInt16 FromByteArray(byte[] bytes)
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
        public static UInt16 FromBytes(byte b1, byte b2)
        {
            return (UInt16)((b2 << 8) | b1);
        }


        /// <summary>
        /// Converts a ushort (UInt16) to word (2 bytes)
        /// </summary>
        public static byte[] ToByteArray(UInt16 value)
        {
            byte[] bytes = new byte[2];

            bytes[1] = (byte)(value & 0xFF);
            bytes[0] = (byte)((value >> 8) & 0xFF);

            return bytes;
        }

        /// <summary>
        /// Converts an array of ushort (UInt16) to an array of bytes
        /// </summary>
        public static byte[] ToByteArray(UInt16[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (UInt16 val in value)
                arr.Add(ToByteArray(val));
            return arr.Array;
        }

        /// <summary>
        /// Converts an array of bytes to an array of ushort
        /// </summary>
        public static UInt16[] ToArray(byte[] bytes)
        {
            UInt16[] values = new UInt16[bytes.Length / 2];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 2; cnt++)
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++] });

            return values;
        }
    }
}
