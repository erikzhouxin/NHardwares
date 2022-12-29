using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace System.Data.NS7NET
{
    /// <summary>
    /// 布尔值(位) <see cref="S7NetCaller"/>
    /// </summary>
    [Obsolete("替代方案:S7NetCaller.Boolean*")]
    public static class Boolean
    {
        /// <summary>
        /// 获取值 <see cref="S7NetCaller.BooleanGetValue"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.BooleanGetValue")]
        public static bool GetValue(byte value, int bit)
        {
            return ((int)value & (int)Math.Pow(2.0, (double)bit)) != 0;
        }
        /// <summary>
        /// 设置位 <see cref="S7NetCaller.BooleanSetBit"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.BooleanSetBit")]
        public static byte SetBit(byte value, int bit)
        {
            return (byte)(value | (byte)Math.Pow(2.0, (double)bit));
        }
        /// <summary>
        /// 清除位 <see cref="S7NetCaller.BooleanClearBit"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.BooleanClearBit")]
        public static byte ClearBit(byte value, int bit)
        {
            return (byte)(value & ~(byte)Math.Pow(2.0, (double)bit));
        }
    }
    /// <summary>
    /// 字节 <see cref="S7NetCaller"/>
    /// </summary>
    [Obsolete("替代方案:VarTypeCaller")]
    public static class Byte
    {
        /// <summary>
        /// 转换成数组 <see cref="S7NetCaller.ByteToByteArray"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.ByteToByteArray")]
        public static byte[] ToByteArray(byte value)
        {
            return new byte[] { value };
        }
        /// <summary>
        /// 取得只有一个元素的内容 <see cref="S7NetCaller.ByteFromByteArray"/>
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [Obsolete("替代方案:S7NetCaller.ByteFromByteArray")]
        public static byte FromByteArray(byte[] bytes)
        {
            if (bytes?.Length == 1) { return bytes[0]; }
            throw new ArgumentException("参数数组必须是有且只有一个元素");
        }
    }
    /// <summary>
    /// 类内容 <see cref="S7NetCaller"/>
    /// </summary>
    [Obsolete("替代方案:S7NetCaller.Class*")]
    public static class Class
    {
        /// <summary>
        /// 获取类长度 <see cref="S7NetCaller.ClassGetSize"/>
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.ClassGetSize")]
        public static int GetClassSize(Type classType)
        {
            double num = 0.0;
            PropertyInfo[] properties = classType.GetProperties();
            int i = 0;
            while (i < properties.Length)
            {
                PropertyInfo propertyInfo = properties[i];
                string name = propertyInfo.PropertyType.Name;
                uint num2 = S7NetCaller.ComputeStringHash(name);
                if (num2 <= 2386971688U)
                {
                    if (num2 <= 1283547685U)
                    {
                        if (num2 != 765439473U)
                        {
                            if (num2 != 1283547685U)
                            {
                                goto IL_267;
                            }
                            if (!(name == "Float"))
                            {
                                goto IL_267;
                            }
                            goto IL_21F;
                        }
                        else if (!(name == "Int16"))
                        {
                            goto IL_267;
                        }
                    }
                    else if (num2 != 1323747186U)
                    {
                        if (num2 != 2386971688U)
                        {
                            goto IL_267;
                        }
                        if (!(name == "Double"))
                        {
                            goto IL_267;
                        }
                        goto IL_21F;
                    }
                    else if (!(name == "UInt16"))
                    {
                        goto IL_267;
                    }
                    num = Math.Ceiling(num);
                    if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                    {
                        num += 1.0;
                    }
                    num += 2.0;
                    goto IL_276;
                IL_21F:
                    num = Math.Ceiling(num);
                    if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                    {
                        num += 1.0;
                    }
                    num += 4.0;
                }
                else
                {
                    if (num2 <= 3409549631U)
                    {
                        if (num2 != 2711245919U)
                        {
                            if (num2 != 3409549631U)
                            {
                                goto IL_267;
                            }
                            if (!(name == "Byte"))
                            {
                                goto IL_267;
                            }
                            num = Math.Ceiling(num);
                            num += 1.0;
                            goto IL_276;
                        }
                        else if (!(name == "Int32"))
                        {
                            goto IL_267;
                        }
                    }
                    else if (num2 != 3538687084U)
                    {
                        if (num2 != 3969205087U)
                        {
                            goto IL_267;
                        }
                        if (!(name == "Boolean"))
                        {
                            goto IL_267;
                        }
                        num += 0.125;
                        goto IL_276;
                    }
                    else if (!(name == "UInt32"))
                    {
                        goto IL_267;
                    }
                    num = Math.Ceiling(num);
                    if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                    {
                        num += 1.0;
                    }
                    num += 4.0;
                }
            IL_276:
                i++;
                continue;
            IL_267:
                num += (double)Class.GetClassSize(propertyInfo.PropertyType);
                goto IL_276;
            }
            return (int)num;
        }
        /// <summary>
        /// 从字节中赋值 <see cref="S7NetCaller.ClassFromBytes"/>
        /// </summary>
        /// <param name="sourceClass"></param>
        /// <param name="classType"></param>
        /// <param name="bytes"></param>
        [Obsolete("替代方案:S7NetCaller.ClassFromBytes")]
        public static void FromBytes(object sourceClass, Type classType, byte[] bytes)
        {
            if (bytes == null) { return; }
            if (bytes.Length != Class.GetClassSize(classType)) { return; }
            double num = 0.0;
            PropertyInfo[] properties = sourceClass.GetType().GetProperties();
            int i = 0;
            while (i < properties.Length)
            {
                PropertyInfo propertyInfo = properties[i];
                string name = propertyInfo.PropertyType.Name;
                uint num2 = S7NetCaller.ComputeStringHash(name);
                if (num2 <= 2386971688U)
                {
                    if (num2 != 765439473U)
                    {
                        if (num2 != 1323747186U)
                        {
                            if (num2 != 2386971688U)
                            {
                                goto IL_424;
                            }
                            if (!(name == "Double"))
                            {
                                goto IL_424;
                            }
                            num = Math.Ceiling(num);
                            if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                            {
                                num += 1.0;
                            }
                            propertyInfo.SetValue(sourceClass, Double.FromByteArray(new byte[]
                            {
                                bytes[(int)num],
                                bytes[(int)num + 1],
                                bytes[(int)num + 2],
                                bytes[(int)num + 3]
                            }), null);
                            num += 4.0;
                        }
                        else
                        {
                            if (!(name == "UInt16"))
                            {
                                goto IL_424;
                            }
                            num = Math.Ceiling(num);
                            if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                            {
                                num += 1.0;
                            }
                            propertyInfo.SetValue(sourceClass, Word.FromBytes(bytes[(int)num + 1], bytes[(int)num]), null);
                            num += 2.0;
                        }
                    }
                    else
                    {
                        if (!(name == "Int16"))
                        {
                            goto IL_424;
                        }
                        num = Math.Ceiling(num);
                        if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                        {
                            num += 1.0;
                        }
                        ushort input = Word.FromBytes(bytes[(int)num + 1], bytes[(int)num]);
                        propertyInfo.SetValue(sourceClass, input.ConvertToShort(), null);
                        num += 2.0;
                    }
                }
                else if (num2 <= 3409549631U)
                {
                    if (num2 != 2711245919U)
                    {
                        if (num2 != 3409549631U)
                        {
                            goto IL_424;
                        }
                        if (!(name == "Byte"))
                        {
                            goto IL_424;
                        }
                        num = Math.Ceiling(num);
                        propertyInfo.SetValue(sourceClass, bytes[(int)num], null);
                        num += 1.0;
                    }
                    else
                    {
                        if (!(name == "Int32"))
                        {
                            goto IL_424;
                        }
                        num = Math.Ceiling(num);
                        if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                        {
                            num += 1.0;
                        }
                        uint input2 = DWord.FromBytes(bytes[(int)num + 3], bytes[(int)num + 2], bytes[(int)num + 1], bytes[(int)num]);
                        propertyInfo.SetValue(sourceClass, input2.ConvertToInt(), null);
                        num += 4.0;
                    }
                }
                else if (num2 != 3538687084U)
                {
                    if (num2 != 3969205087U)
                    {
                        goto IL_424;
                    }
                    if (!(name == "Boolean"))
                    {
                        goto IL_424;
                    }
                    int num3 = (int)Math.Floor(num);
                    int num4 = (int)((num - (double)num3) / 0.125);
                    if (((int)bytes[num3] & (int)Math.Pow(2.0, (double)num4)) != 0)
                    {
                        propertyInfo.SetValue(sourceClass, true, null);
                    }
                    else
                    {
                        propertyInfo.SetValue(sourceClass, false, null);
                    }
                    num += 0.125;
                }
                else
                {
                    if (!(name == "UInt32"))
                    {
                        goto IL_424;
                    }
                    num = Math.Ceiling(num);
                    if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                    {
                        num += 1.0;
                    }
                    propertyInfo.SetValue(sourceClass, DWord.FromBytes(bytes[(int)num], bytes[(int)num + 1], bytes[(int)num + 2], bytes[(int)num + 3]), null);
                    num += 4.0;
                }
            IL_481:
                i++;
                continue;
            IL_424:
                byte[] array = new byte[Class.GetClassSize(propertyInfo.PropertyType)];
                if (array.Length != 0)
                {
                    Buffer.BlockCopy(bytes, (int)Math.Ceiling(num), array, 0, array.Length);
                    object obj = Activator.CreateInstance(propertyInfo.PropertyType);
                    Class.FromBytes(obj, propertyInfo.PropertyType, array);
                    propertyInfo.SetValue(sourceClass, obj, null);
                    num += (double)array.Length;
                    goto IL_481;
                }
                goto IL_481;
            }
        }
        /// <summary>
        /// 类转换成字节 <see cref="S7NetCaller.ClassToBytes"/>
        /// </summary>
        /// <param name="sourceClass"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.ClassToBytes")]
        public static byte[] ToBytes(object sourceClass)
        {
            byte[] array = new byte[Class.GetClassSize(sourceClass.GetType())];
            double num = 0.0;
            foreach (PropertyInfo propertyInfo in sourceClass.GetType().GetProperties())
            {
                byte[] array2 = null;
                string name = propertyInfo.PropertyType.Name;
                uint num2 = S7NetCaller.ComputeStringHash(name);
                if (num2 <= 2386971688U)
                {
                    if (num2 != 765439473U)
                    {
                        if (num2 != 1323747186U)
                        {
                            if (num2 == 2386971688U)
                            {
                                if (name == "Double")
                                {
                                    array2 = Double.ToByteArray((double)propertyInfo.GetValue(sourceClass, null));
                                }
                            }
                        }
                        else if (name == "UInt16")
                        {
                            array2 = Word.ToByteArray((ushort)propertyInfo.GetValue(sourceClass, null));
                        }
                    }
                    else if (name == "Int16")
                    {
                        array2 = Int.ToByteArray((short)propertyInfo.GetValue(sourceClass, null));
                    }
                }
                else if (num2 <= 3409549631U)
                {
                    if (num2 != 2711245919U)
                    {
                        if (num2 == 3409549631U)
                        {
                            if (name == "Byte")
                            {
                                num = (double)((int)Math.Ceiling(num));
                                int num3 = (int)num;
                                array[num3] = (byte)propertyInfo.GetValue(sourceClass, null);
                                num += 1.0;
                            }
                        }
                    }
                    else if (name == "Int32")
                    {
                        array2 = DInt.ToByteArray((int)propertyInfo.GetValue(sourceClass, null));
                    }
                }
                else if (num2 != 3538687084U)
                {
                    if (num2 == 3969205087U)
                    {
                        if (name == "Boolean")
                        {
                            int num3 = (int)Math.Floor(num);
                            int num4 = (int)((num - (double)num3) / 0.125);
                            if ((bool)propertyInfo.GetValue(sourceClass, null))
                            {
                                byte[] array3 = array;
                                int num5 = num3;
                                array3[num5] |= (byte)Math.Pow(2.0, (double)num4);
                            }
                            else
                            {
                                byte[] array4 = array;
                                int num6 = num3;
                                array4[num6] &= (byte)~(byte)Math.Pow(2.0, (double)num4);
                            }
                            num += 0.125;
                        }
                    }
                }
                else if (name == "UInt32")
                {
                    array2 = DWord.ToByteArray((uint)propertyInfo.GetValue(sourceClass, null));
                }
                if (array2 != null)
                {
                    num = Math.Ceiling(num);
                    if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                    {
                        num += 1.0;
                    }
                    int num3 = (int)num;
                    for (int j = 0; j < array2.Length; j++)
                    {
                        array[num3 + j] = array2[j];
                    }
                    num += (double)array2.Length;
                }
            }
            return array;
        }
    }
    /// <summary>
    /// 计数器 <see cref="S7NetCaller"/>
    /// </summary>
    [Obsolete("替代方案:S7NetCaller.Counter*")]
    public static class Counter
    {
        /// <summary>
        /// 从字节数组创建 <see cref="S7NetCaller.CounterFromByteArray"/>
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [Obsolete("替代方案:S7NetCaller.CounterFromByteArray")]
        public static ushort FromByteArray(byte[] bytes)
        {
            if (bytes.Length != 2)
            {
                throw new ArgumentException("Wrong number of bytes. Bytes array must contain 2 bytes.");
            }
            return Counter.FromBytes(bytes[1], bytes[0]);
        }

        /// <summary>
        /// 从高位/低位创建 <see cref="S7NetCaller.CounterFromBytes"/>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [Obsolete("替代方案:S7NetCaller.CounterFromBytes")]
        public static ushort FromBytes(byte LoVal, byte HiVal)
        {
            return (ushort)((int)HiVal * 256 + (int)LoVal);
        }
        /// <summary>
        /// 转换成字节数组 <see cref="S7NetCaller.CounterToByteArray(ushort)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.CounterToByteArray")]
        public static byte[] ToByteArray(ushort value)
        {
            byte[] array = new byte[2];
            int num = 2;
            long num2 = (long)((ulong)value);
            for (int i = 0; i < num; i++)
            {
                long num3 = (long)Math.Pow(256.0, (double)i);
                long num4 = num2 / num3;
                array[num - i - 1] = (byte)(num4 & 255L);
                num2 -= (long)((ulong)array[num - i - 1] * (ulong)num3);
            }
            return array;
        }
        /// <summary>
        /// 转换成字节数组 <see cref="S7NetCaller.CounterToByteArray(ushort[])"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.CounterToByteArray")]
        public static byte[] ToByteArray(ushort[] value)
        {
            ByteArray byteArray = new ByteArray();
            foreach (ushort value2 in value)
            {
                byteArray.Add(Counter.ToByteArray(value2));
            }
            return byteArray.Array;
        }
        /// <summary>
        /// 转换成计数数组 <see cref="S7NetCaller.CounterToArray"/>
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.CounterToArray")]
        public static ushort[] ToArray(byte[] bytes)
        {
            ushort[] array = new ushort[bytes.Length / 2];
            int num = 0;
            for (int i = 0; i < bytes.Length / 2; i++)
            {
                array[i] = Counter.FromByteArray(new byte[]
                {
                    bytes[num++],
                    bytes[num++]
                });
            }
            return array;
        }
    }
    /// <summary>
    /// 整型 <see cref="S7NetCaller"/>
    /// </summary>
    [Obsolete("替代方案:S7NetCaller.DInt*")]
    public static class DInt
    {
        /// <summary>
        /// 从字节转换 <see cref="S7NetCaller.DIntFromByteArray"/>
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [Obsolete("替代方案:S7NetCaller.DIntFromByteArray")]
        public static int FromByteArray(byte[] bytes)
        {
            if (bytes.Length != 4)
            {
                throw new ArgumentException("Wrong number of bytes. Bytes array must contain 4 bytes.");
            }
            return DInt.FromBytes(bytes[3], bytes[2], bytes[1], bytes[0]);
        }
        /// <summary>
        /// 从字节转换 <see cref="S7NetCaller.DIntFromBytes"/>
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="v4"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DIntFromBytes")]
        public static int FromBytes(byte v1, byte v2, byte v3, byte v4)
        {
            return (int)((double)v1 + (double)v2 * Math.Pow(2.0, 8.0) + (double)v3 * Math.Pow(2.0, 16.0) + (double)v4 * Math.Pow(2.0, 24.0));
        }
        /// <summary>
        /// 转换成字节数组 <see cref="S7NetCaller.DIntToByteArray(int)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DIntToByteArray")]
        public static byte[] ToByteArray(int value)
        {
            byte[] array = new byte[4];
            int num = 4;
            long num2 = (long)value;
            for (int i = 0; i < num; i++)
            {
                long num3 = (long)Math.Pow(256.0, (double)i);
                long num4 = num2 / num3;
                array[num - i - 1] = (byte)(num4 & 255L);
                num2 -= (long)((ulong)array[num - i - 1] * (ulong)num3);
            }
            return array;
        }
        /// <summary>
        /// 转换成字节数组 <see cref="S7NetCaller.DIntToByteArray(int[])"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DIntToByteArray")]
        public static byte[] ToByteArray(int[] value)
        {
            ByteArray byteArray = new ByteArray();
            foreach (int value2 in value)
            {
                byteArray.Add(DInt.ToByteArray(value2));
            }
            return byteArray.Array;
        }
        /// <summary>
        /// 转换成整型数组 <see cref="S7NetCaller.DIntToArray"/>
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DIntToArray")]
        public static int[] ToArray(byte[] bytes)
        {
            int[] array = new int[bytes.Length / 4];
            int num = 0;
            for (int i = 0; i < bytes.Length / 4; i++)
            {
                array[i] = DInt.FromByteArray(new byte[]
                {
                    bytes[num++],
                    bytes[num++],
                    bytes[num++],
                    bytes[num++]
                });
            }
            return array;
        }
        /// <summary>
        /// 长整型转换 <see cref="S7NetCaller.DIntCDWord"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DIntCDWord")]
        public static int CDWord(long value)
        {
            if (value > 2147483647L)
            {
                var minVal = int.MinValue;
                value -= (long)((ulong)minVal);
                value = (long)((ulong)minVal - (ulong)value);
                value *= -1L;
            }
            return (int)value;
        }
    }
    /// <summary>
    /// 浮点数 <see cref="S7NetCaller"/>
    /// </summary>
    [Obsolete("替代方案:S7NetCaller.Double*")]
    public static class Double
    {
        /// <summary>
        /// 从字节转换 <see cref="S7NetCaller.DoubleFromByteArray"/>
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [Obsolete("替代方案:S7NetCaller.DoubleFromByteArray")]
        public static double FromByteArray(byte[] bytes)
        {
            if (bytes.Length != 4)
            {
                throw new ArgumentException("Wrong number of bytes. Bytes array must contain 4 bytes.");
            }
            byte b = bytes[0];
            byte b2 = bytes[1];
            byte b3 = bytes[2];
            byte b4 = bytes[3];
            if (b + b2 + b3 + b4 == 0)
            {
                return 0.0;
            }
            string text = Double.ValToBinString(b) + Double.ValToBinString(b2) + Double.ValToBinString(b3) + Double.ValToBinString(b4);
            int num = int.Parse(text.Substring(0, 1));
            int num2 = text.Substring(1, 8).BinStringToInt32();
            string text2 = text.Substring(9, 23);
            double num3 = 1.0;
            double num4 = 1.0;
            for (int i = 0; i <= 22; i++)
            {
                num4 /= 2.0;
                if (text2.Substring(i, 1) == "1")
                {
                    num3 += num4;
                }
            }
            return Math.Pow(-1.0, (double)num) * Math.Pow(2.0, (double)(num2 - 127)) * num3;
        }
        /// <summary>
        /// 从整型转换 <see cref="S7NetCaller.DoubleFromDWord(int)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DoubleFromDWord")]
        public static double FromDWord(int value)
        {
            return Double.FromByteArray(DInt.ToByteArray(value));
        }
        /// <summary>
        /// 从无符号整型转换 <see cref="S7NetCaller.DoubleFromDWord(uint)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DoubleFromDWord")]
        public static double FromDWord(uint value)
        {
            return Double.FromByteArray(DWord.ToByteArray(value));
        }
        /// <summary>
        /// 转换成字节数组 <see cref="S7NetCaller.DoubleToByteArray(double)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DoubleToByteArray")]
        public static byte[] ToByteArray(double value)
        {
            double num = value;
            byte[] array = new byte[4];
            if (num != 0.0)
            {
                string text;
                if (num < 0.0)
                {
                    num *= -1.0;
                    text = "1";
                }
                else
                {
                    text = "0";
                }
                int num2 = (int)Math.Floor(Math.Log(num) / Math.Log(2.0));
                num = num / Math.Pow(2.0, (double)num2) - 1.0;
                text += Double.ValToBinString((byte)(num2 + 127));
                for (int i = 1; i <= 23; i++)
                {
                    if (num - Math.Pow(2.0, (double)(-(double)i)) >= 0.0)
                    {
                        num -= Math.Pow(2.0, (double)(-(double)i));
                        text += "1";
                    }
                    else
                    {
                        text += "0";
                    }
                }
                array[0] = Double.BinStringToByte(text.Substring(0, 8)).Value;
                array[1] = Double.BinStringToByte(text.Substring(8, 8)).Value;
                array[2] = Double.BinStringToByte(text.Substring(16, 8)).Value;
                array[3] = Double.BinStringToByte(text.Substring(24, 8)).Value;
            }
            else
            {
                array[0] = 0;
                array[1] = 0;
                array[2] = 0;
                array[3] = 0;
            }
            return array;
        }
        /// <summary>
        /// 转换成字节数组 <see cref="S7NetCaller.DoubleToByteArray(double[])"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DoubleToByteArray")]
        public static byte[] ToByteArray(double[] value)
        {
            ByteArray byteArray = new ByteArray();
            foreach (double value2 in value)
            {
                byteArray.Add(Double.ToByteArray(value2));
            }
            return byteArray.Array;
        }
        /// <summary>
        /// 转换成浮点数组 <see cref="S7NetCaller.DoubleToArray"/>
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DoubleToArray")]
        public static double[] ToArray(byte[] bytes)
        {
            double[] array = new double[bytes.Length / 4];
            int num = 0;
            for (int i = 0; i < bytes.Length / 4; i++)
            {
                array[i] = Double.FromByteArray(new byte[]
                {
                    bytes[num++],
                    bytes[num++],
                    bytes[num++],
                    bytes[num++]
                });
            }
            return array;
        }
        /// <summary>
        /// 转换成位字符串 <see cref="S7NetCaller.DoubleValToBinString"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DoubleValToBinString")]
        private static string ValToBinString(byte value)
        {
            string text = "";
            for (int i = 7; i >= 0; i += -1)
            {
                if ((value & (byte)Math.Pow(2.0, (double)i)) > 0)
                {
                    text += "1";
                }
                else
                {
                    text += "0";
                }
            }
            return text;
        }
        /// <summary>
        /// 转换成字节 <see cref="S7NetCaller.DoubleBinStringToByte"/>
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DoubleBinStringToByte")]
        private static byte? BinStringToByte(string txt)
        {
            int num = 0;
            if (txt.Length == 8)
            {
                for (int i = 7; i >= 0; i += -1)
                {
                    if (int.Parse(txt.Substring(i, 1)) == 1)
                    {
                        num += (int)Math.Pow(2.0, (double)(txt.Length - 1 - i));
                    }
                }
                return new byte?((byte)num);
            }
            return null;
        }
    }
    /// <summary>
    /// 无符号整型 <see cref="S7NetCaller"/>
    /// </summary>
    [Obsolete("替代方案:S7NetCaller.DWord*")]
    public static class DWord
    {
        /// <summary>
        /// 从字节数组
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DWordFromByteArray")]
        public static uint FromByteArray(byte[] bytes)
        {
            return DWord.FromBytes(bytes[3], bytes[2], bytes[1], bytes[0]);
        }
        /// <summary>
        /// 从字节
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="v4"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DWordFromBytes")]
        public static uint FromBytes(byte v1, byte v2, byte v3, byte v4)
        {
            return (uint)((double)v1 + (double)v2 * Math.Pow(2.0, 8.0) + (double)v3 * Math.Pow(2.0, 16.0) + (double)v4 * Math.Pow(2.0, 24.0));
        }
        /// <summary>
        /// 转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DWordToByteArray")]
        public static byte[] ToByteArray(uint value)
        {
            byte[] array = new byte[4];
            int num = 4;
            long num2 = (long)((ulong)value);
            for (int i = 0; i < num; i++)
            {
                long num3 = (long)Math.Pow(256.0, (double)i);
                long num4 = num2 / num3;
                array[num - i - 1] = (byte)(num4 & 255L);
                num2 -= (long)((ulong)array[num - i - 1] * (ulong)num3);
            }
            return array;
        }
        /// <summary>
        /// 转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DWordToByteArray")]
        public static byte[] ToByteArray(uint[] value)
        {
            ByteArray byteArray = new ByteArray();
            foreach (uint value2 in value)
            {
                byteArray.Add(DWord.ToByteArray(value2));
            }
            return byteArray.Array;
        }
        /// <summary>
        /// 转换成无符号整型数组
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.DWordToArray")]
        public static uint[] ToArray(byte[] bytes)
        {
            uint[] array = new uint[bytes.Length / 4];
            int num = 0;
            for (int i = 0; i < bytes.Length / 4; i++)
            {
                array[i] = DWord.FromByteArray(new byte[]
                {
                    bytes[num++],
                    bytes[num++],
                    bytes[num++],
                    bytes[num++]
                });
            }
            return array;
        }
    }
    /// <summary>
    /// 短整型 <see cref="S7NetCaller"/>
    /// </summary>
    [Obsolete("替代方案:S7NetCaller.Int*")]
    public static class Int
    {
        /// <summary>
        /// 从字节数组 <see cref="S7NetCaller.IntFromByteArray"/>
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [Obsolete("替代方案:S7NetCaller.IntFromByteArray")]
        public static short FromByteArray(byte[] bytes)
        {
            if (bytes.Length != 2)
            {
                throw new ArgumentException("Wrong number of bytes. Bytes array must contain 2 bytes.");
            }
            return Int.FromBytes(bytes[1], bytes[0]);
        }
        /// <summary>
        /// 从字节 <see cref="S7NetCaller.IntFromBytes"/>
        /// </summary>
        /// <param name="LoVal"></param>
        /// <param name="HiVal"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.IntFromBytes")]
        public static short FromBytes(byte LoVal, byte HiVal)
        {
            return (short)((int)HiVal * 256 + (int)LoVal);
        }
        /// <summary>
        /// 转换成字节数组 <see cref="S7NetCaller.IntToByteArray(short)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.IntToByteArray")]
        public static byte[] ToByteArray(short value)
        {
            byte[] array = new byte[2];
            int num = 2;
            long num2 = (long)value;
            for (int i = 0; i < num; i++)
            {
                long num3 = (long)Math.Pow(256.0, (double)i);
                long num4 = num2 / num3;
                array[num - i - 1] = (byte)(num4 & 255L);
                num2 -= (long)((ulong)array[num - i - 1] * (ulong)num3);
            }
            return array;
        }
        /// <summary>
        /// 转换成字节数组 <see cref="S7NetCaller.IntToByteArray(short[])"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.IntToByteArray")]
        public static byte[] ToByteArray(short[] value)
        {
            ByteArray byteArray = new ByteArray();
            foreach (short value2 in value)
            {
                byteArray.Add(Int.ToByteArray(value2));
            }
            return byteArray.Array;
        }
        /// <summary>
        /// 转换成数组 <see cref="S7NetCaller.IntToArray"/>
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.IntToArray")]
        public static short[] ToArray(byte[] bytes)
        {
            short[] array = new short[bytes.Length / 2];
            int num = 0;
            for (int i = 0; i < bytes.Length / 2; i++)
            {
                array[i] = Int.FromByteArray(new byte[]
                {
                    bytes[num++],
                    bytes[num++]
                });
            }
            return array;
        }
        /// <summary>
        /// 转换成值 <see cref="S7NetCaller.IntCWord"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.IntCWord")]
        public static short CWord(int value)
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
    /// 字符串 <see cref="S7NetCaller"/>
    /// </summary>
    [Obsolete("替代方案:S7NetCaller.String*")]
    public static class String
    {
        /// <summary>
        /// 字符串转换成字节数组 <see cref="S7NetCaller.StringToByteArray"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.StringToByteArray")]
        public static byte[] ToByteArray(string value)
        {
            char[] array = value.ToCharArray();
            byte[] array2 = new byte[value.Length];
            for (int i = 0; i <= array.Length - 1; i++)
            {
                array2[i] = (byte)String.Asc(array[i].ToString());
            }
            return array2;
        }
        /// <summary>
        /// 从字节数组转换 <see cref="S7NetCaller.StringFromByteArray"/>
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.StringFromByteArray")]
        public static string FromByteArray(byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes);
        }
        [Obsolete("替代方案:S7NetCaller.StringAsc")]
        private static int Asc(string s)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            if (bytes.Length != 0)
            {
                return (int)bytes[0];
            }
            return 0;
        }
    }
    /// <summary>
    /// 结构体 <see cref="S7NetCaller"/>
    /// </summary>
    [Obsolete("替代方案:S7NetCaller.Struct*")]
    public static class Struct
    {
        /// <summary>
        /// 获取结构体长度 <see cref="S7NetCaller.StructGetSize"/>
        /// </summary>
        /// <param name="structType"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.StructGetSize")]
        public static int GetStructSize(Type structType)
        {
            double num = 0.0;
            FieldInfo[] fields = structType.GetFields();
            int i = 0;
            while (i < fields.Length)
            {
                FieldInfo fieldInfo = fields[i];
                string name = fieldInfo.FieldType.Name;
                uint num2 = S7NetCaller.ComputeStringHash(name);
                if (num2 <= 2386971688U)
                {
                    if (num2 <= 1283547685U)
                    {
                        if (num2 != 765439473U)
                        {
                            if (num2 != 1283547685U)
                            {
                                goto IL_267;
                            }
                            if (!(name == "Float"))
                            {
                                goto IL_267;
                            }
                            goto IL_21F;
                        }
                        else if (!(name == "Int16"))
                        {
                            goto IL_267;
                        }
                    }
                    else if (num2 != 1323747186U)
                    {
                        if (num2 != 2386971688U)
                        {
                            goto IL_267;
                        }
                        if (!(name == "Double"))
                        {
                            goto IL_267;
                        }
                        goto IL_21F;
                    }
                    else if (!(name == "UInt16"))
                    {
                        goto IL_267;
                    }
                    num = Math.Ceiling(num);
                    if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                    {
                        num += 1.0;
                    }
                    num += 2.0;
                    goto IL_276;
                IL_21F:
                    num = Math.Ceiling(num);
                    if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                    {
                        num += 1.0;
                    }
                    num += 4.0;
                }
                else
                {
                    if (num2 <= 3409549631U)
                    {
                        if (num2 != 2711245919U)
                        {
                            if (num2 != 3409549631U)
                            {
                                goto IL_267;
                            }
                            if (!(name == "Byte"))
                            {
                                goto IL_267;
                            }
                            num = Math.Ceiling(num);
                            num += 1.0;
                            goto IL_276;
                        }
                        else if (!(name == "Int32"))
                        {
                            goto IL_267;
                        }
                    }
                    else if (num2 != 3538687084U)
                    {
                        if (num2 != 3969205087U)
                        {
                            goto IL_267;
                        }
                        if (!(name == "Boolean"))
                        {
                            goto IL_267;
                        }
                        num += 0.125;
                        goto IL_276;
                    }
                    else if (!(name == "UInt32"))
                    {
                        goto IL_267;
                    }
                    num = Math.Ceiling(num);
                    if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                    {
                        num += 1.0;
                    }
                    num += 4.0;
                }
            IL_276:
                i++;
                continue;
            IL_267:
                num += (double)Struct.GetStructSize(fieldInfo.FieldType);
                goto IL_276;
            }
            return (int)num;
        }
        /// <summary>
        /// 从字节转换 <see cref="S7NetCaller.StructFromBytes"/>
        /// </summary>
        /// <param name="structType"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.StructFromBytes")]
        public static object FromBytes(Type structType, byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            if (bytes.Length != Struct.GetStructSize(structType))
            {
                return null;
            }
            double num = 0.0;
            object obj = Activator.CreateInstance(structType);
            FieldInfo[] fields = obj.GetType().GetFields();
            int i = 0;
            while (i < fields.Length)
            {
                FieldInfo fieldInfo = fields[i];
                string name = fieldInfo.FieldType.Name;
                uint num2 = S7NetCaller.ComputeStringHash(name);
                if (num2 <= 2386971688U)
                {
                    if (num2 != 765439473U)
                    {
                        if (num2 != 1323747186U)
                        {
                            if (num2 != 2386971688U)
                            {
                                goto IL_427;
                            }
                            if (!(name == "Double"))
                            {
                                goto IL_427;
                            }
                            num = Math.Ceiling(num);
                            if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                            {
                                num += 1.0;
                            }
                            fieldInfo.SetValue(obj, Double.FromByteArray(new byte[]
                            {
                                bytes[(int)num],
                                bytes[(int)num + 1],
                                bytes[(int)num + 2],
                                bytes[(int)num + 3]
                            }));
                            num += 4.0;
                        }
                        else
                        {
                            if (!(name == "UInt16"))
                            {
                                goto IL_427;
                            }
                            num = Math.Ceiling(num);
                            if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                            {
                                num += 1.0;
                            }
                            fieldInfo.SetValue(obj, Word.FromBytes(bytes[(int)num + 1], bytes[(int)num]));
                            num += 2.0;
                        }
                    }
                    else
                    {
                        if (!(name == "Int16"))
                        {
                            goto IL_427;
                        }
                        num = Math.Ceiling(num);
                        if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                        {
                            num += 1.0;
                        }
                        ushort input = Word.FromBytes(bytes[(int)num + 1], bytes[(int)num]);
                        fieldInfo.SetValue(obj, input.ConvertToShort());
                        num += 2.0;
                    }
                }
                else if (num2 <= 3409549631U)
                {
                    if (num2 != 2711245919U)
                    {
                        if (num2 != 3409549631U)
                        {
                            goto IL_427;
                        }
                        if (!(name == "Byte"))
                        {
                            goto IL_427;
                        }
                        num = Math.Ceiling(num);
                        fieldInfo.SetValue(obj, bytes[(int)num]);
                        num += 1.0;
                    }
                    else
                    {
                        if (!(name == "Int32"))
                        {
                            goto IL_427;
                        }
                        num = Math.Ceiling(num);
                        if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                        {
                            num += 1.0;
                        }
                        uint input2 = DWord.FromBytes(bytes[(int)num + 3], bytes[(int)num + 2], bytes[(int)num + 1], bytes[(int)num]);
                        fieldInfo.SetValue(obj, input2.ConvertToInt());
                        num += 4.0;
                    }
                }
                else if (num2 != 3538687084U)
                {
                    if (num2 != 3969205087U)
                    {
                        goto IL_427;
                    }
                    if (!(name == "Boolean"))
                    {
                        goto IL_427;
                    }
                    int num3 = (int)Math.Floor(num);
                    int num4 = (int)((num - (double)num3) / 0.125);
                    if (((int)bytes[num3] & (int)Math.Pow(2.0, (double)num4)) != 0)
                    {
                        fieldInfo.SetValue(obj, true);
                    }
                    else
                    {
                        fieldInfo.SetValue(obj, false);
                    }
                    num += 0.125;
                }
                else
                {
                    if (!(name == "UInt32"))
                    {
                        goto IL_427;
                    }
                    num = Math.Ceiling(num);
                    if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                    {
                        num += 1.0;
                    }
                    fieldInfo.SetValue(obj, DWord.FromBytes(bytes[(int)num], bytes[(int)num + 1], bytes[(int)num + 2], bytes[(int)num + 3]));
                    num += 4.0;
                }
            IL_471:
                i++;
                continue;
            IL_427:
                byte[] array = new byte[Struct.GetStructSize(fieldInfo.FieldType)];
                if (array.Length != 0)
                {
                    Buffer.BlockCopy(bytes, (int)Math.Ceiling(num), array, 0, array.Length);
                    fieldInfo.SetValue(obj, Struct.FromBytes(fieldInfo.FieldType, array));
                    num += (double)array.Length;
                    goto IL_471;
                }
                goto IL_471;
            }
            return obj;
        }
        /// <summary>
        /// 转换成字节 <see cref="S7NetCaller.StructToBytes"/>
        /// </summary>
        /// <param name="structValue"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.StructToBytes")]
        public static byte[] ToBytes(object structValue)
        {
            Type type = structValue.GetType();
            byte[] array = new byte[Struct.GetStructSize(type)];
            double num = 0.0;
            foreach (FieldInfo fieldInfo in type.GetFields())
            {
                byte[] array2 = null;
                string name = fieldInfo.FieldType.Name;
                uint num2 = S7NetCaller.ComputeStringHash(name);
                if (num2 <= 2386971688U)
                {
                    if (num2 != 765439473U)
                    {
                        if (num2 != 1323747186U)
                        {
                            if (num2 == 2386971688U)
                            {
                                if (name == "Double")
                                {
                                    array2 = Double.ToByteArray((double)fieldInfo.GetValue(structValue));
                                }
                            }
                        }
                        else if (name == "UInt16")
                        {
                            array2 = Word.ToByteArray((ushort)fieldInfo.GetValue(structValue));
                        }
                    }
                    else if (name == "Int16")
                    {
                        array2 = Int.ToByteArray((short)fieldInfo.GetValue(structValue));
                    }
                }
                else if (num2 <= 3409549631U)
                {
                    if (num2 != 2711245919U)
                    {
                        if (num2 == 3409549631U)
                        {
                            if (name == "Byte")
                            {
                                num = (double)((int)Math.Ceiling(num));
                                int num3 = (int)num;
                                array[num3] = (byte)fieldInfo.GetValue(structValue);
                                num += 1.0;
                            }
                        }
                    }
                    else if (name == "Int32")
                    {
                        array2 = DInt.ToByteArray((int)fieldInfo.GetValue(structValue));
                    }
                }
                else if (num2 != 3538687084U)
                {
                    if (num2 == 3969205087U)
                    {
                        if (name == "Boolean")
                        {
                            int num3 = (int)Math.Floor(num);
                            int num4 = (int)((num - (double)num3) / 0.125);
                            if ((bool)fieldInfo.GetValue(structValue))
                            {
                                byte[] array3 = array;
                                int num5 = num3;
                                array3[num5] |= (byte)Math.Pow(2.0, (double)num4);
                            }
                            else
                            {
                                byte[] array4 = array;
                                int num6 = num3;
                                array4[num6] &= (byte)~(byte)Math.Pow(2.0, (double)num4);
                            }
                            num += 0.125;
                        }
                    }
                }
                else if (name == "UInt32")
                {
                    array2 = DWord.ToByteArray((uint)fieldInfo.GetValue(structValue));
                }
                if (array2 != null)
                {
                    num = Math.Ceiling(num);
                    if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
                    {
                        num += 1.0;
                    }
                    int num3 = (int)num;
                    for (int j = 0; j < array2.Length; j++)
                    {
                        array[num3 + j] = array2[j];
                    }
                    num += (double)array2.Length;
                }
            }
            return array;
        }
    }
    /// <summary>
    /// 计时器 <see cref="S7NetCaller"/>
    /// </summary>
    [Obsolete("替代方案:S7NetCaller.Timer*")]
    public static class Timer
    {
        /// <summary>
        /// 从字节数组 <see cref="S7NetCaller.TimerFromByteArray"/>
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.TimerFromByteArray")]
        public static double FromByteArray(byte[] bytes)
        {
            string text = ((short)Word.FromBytes(bytes[1], bytes[0])).ValToBinString();
            double num = (double)text.Substring(4, 4).BinStringToInt32() * 100.0;
            num += (double)text.Substring(8, 4).BinStringToInt32() * 10.0;
            num += (double)text.Substring(12, 4).BinStringToInt32();
            string a = text.Substring(2, 2);
            if (!(a == "00"))
            {
                if (!(a == "01"))
                {
                    if (!(a == "10"))
                    {
                        if (a == "11")
                        {
                            num *= 10.0;
                        }
                    }
                    else
                    {
                        num *= 1.0;
                    }
                }
                else
                {
                    num *= 0.1;
                }
            }
            else
            {
                num *= 0.01;
            }
            return num;
        }
        /// <summary>
        /// 转换成字节数组 <see cref="S7NetCaller.TimerToByteArray(ushort)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.TimerToByteArray")]
        public static byte[] ToByteArray(ushort value)
        {
            byte[] array = new byte[2];
            int num = 2;
            long num2 = (long)((ulong)value);
            for (int i = 0; i < num; i++)
            {
                long num3 = (long)Math.Pow(256.0, (double)i);
                long num4 = num2 / num3;
                array[num - i - 1] = (byte)(num4 & 255L);
                num2 -= (long)((ulong)array[num - i - 1] * (ulong)num3);
            }
            return array;
        }
        /// <summary>
        /// 转换成字节数组 <see cref="S7NetCaller.TimerToByteArray(ushort[])"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.TimerToByteArray")]
        public static byte[] ToByteArray(ushort[] value)
        {
            ByteArray byteArray = new ByteArray();
            foreach (ushort value2 in value)
            {
                byteArray.Add(Timer.ToByteArray(value2));
            }
            return byteArray.Array;
        }
        /// <summary>
        /// 转换成浮点数组 <see cref="S7NetCaller.TimerToArray"/>
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.TimerToArray")]
        public static double[] ToArray(byte[] bytes)
        {
            double[] array = new double[bytes.Length / 2];
            int num = 0;
            for (int i = 0; i < bytes.Length / 2; i++)
            {
                array[i] = Timer.FromByteArray(new byte[]
                {
                    bytes[num++],
                    bytes[num++]
                });
            }
            return array;
        }
    }
    /// <summary>
    /// 无符号短整型 <see cref="S7NetCaller"/>
    /// </summary>
    [Obsolete("替代方案:S7NetCaller.Word*")]
    public static class Word
    {
        /// <summary>
        /// 从字节数组转换 <see cref="S7NetCaller.WordFromByteArray"/>
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [Obsolete("替代方案:S7NetCaller.WordFromByteArray")]
        public static ushort FromByteArray(byte[] bytes)
        {
            if (bytes.Length != 2)
            {
                throw new ArgumentException("Wrong number of bytes. Bytes array must contain 2 bytes.");
            }
            return Word.FromBytes(bytes[1], bytes[0]);
        }
        /// <summary>
        /// 转换成无符号整型 <see cref="S7NetCaller.WordFromBytes"/>
        /// </summary>
        /// <param name="LoVal"></param>
        /// <param name="HiVal"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.WordFromBytes")]
        public static ushort FromBytes(byte LoVal, byte HiVal)
        {
            return (ushort)((int)HiVal * 256 + (int)LoVal);
        }
        /// <summary>
        /// 转换成字节数组 <see cref="S7NetCaller.WordToByteArray(ushort)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.WordToByteArray")]
        public static byte[] ToByteArray(ushort value)
        {
            byte[] array = new byte[2];
            int num = 2;
            long num2 = (long)((ulong)value);
            for (int i = 0; i < num; i++)
            {
                long num3 = (long)Math.Pow(256.0, (double)i);
                long num4 = num2 / num3;
                array[num - i - 1] = (byte)(num4 & 255L);
                num2 -= (long)((ulong)array[num - i - 1] * (ulong)num3);
            }
            return array;
        }
        /// <summary>
        /// 转换成字节数组 <see cref="S7NetCaller.WordToByteArray(ushort[])"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.WordToByteArray")]
        public static byte[] ToByteArray(ushort[] value)
        {
            ByteArray byteArray = new ByteArray();
            foreach (ushort value2 in value)
            {
                byteArray.Add(Word.ToByteArray(value2));
            }
            return byteArray.Array;
        }
        /// <summary>
        /// 转换成无符号短整型数组 <see cref="S7NetCaller.WordToArray"/>
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        [Obsolete("替代方案:S7NetCaller.WordToArray")]
        public static ushort[] ToArray(byte[] bytes)
        {
            ushort[] array = new ushort[bytes.Length / 2];
            int num = 0;
            for (int i = 0; i < bytes.Length / 2; i++)
            {
                array[i] = Word.FromByteArray(new byte[]
                {
                    bytes[num++],
                    bytes[num++]
                });
            }
            return array;
        }
    }
}
