using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace System.Data.NS7NET
{
    /// <summary>
    /// 变量类型调用
    /// </summary>
    public static class S7NetCaller
    {
        #region // 内部调用
        /// <summary>
        /// 计算字符串Hash
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        internal static uint ComputeStringHash(string s)
        {
            uint num = 0;
            if (s != null)
            {
                num = 2166136261U;
                for (int i = 0; i < s.Length; i++)
                {
                    num = ((uint)s[i] ^ num) * 16777619U;
                }
            }
            return num;
        }
        #endregion 内部调用
        #region // Conversion 转换调用
        /// <summary>
        /// 位字符串转换成整型
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static int BinStringToInt32(this string txt)
        {
            int num = 0;
            for (int i = txt.Length - 1; i >= 0; i += -1)
            {
                if (int.Parse(txt.Substring(i, 1)) == 1)
                {
                    num += (int)Math.Pow(2.0, (double)(txt.Length - 1 - i));
                }
            }
            return num;
        }
        /// <summary>
        /// 位字符串转换成字节
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static byte? BinStringToByte(this string txt)
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
        /// <summary>
        /// 对象转换成位字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ValToBinString(this object value)
        {
            string text = "";
            string text2;
            try
            {
                if (value.GetType().Name.IndexOf("[]") < 0)
                {
                    text2 = value.GetType().Name;
                    int num;
                    long num2;
                    if (!(text2 == "Byte"))
                    {
                        if (!(text2 == "Int16"))
                        {
                            if (!(text2 == "Int32"))
                            {
                                if (!(text2 == "Int64"))
                                {
                                    throw new Exception();
                                }
                                num = 63;
                                num2 = (long)value;
                            }
                            else
                            {
                                num = 31;
                                num2 = (long)((int)value);
                            }
                        }
                        else
                        {
                            num = 15;
                            num2 = (long)((short)value);
                        }
                    }
                    else
                    {
                        num = 7;
                        num2 = (long)((ulong)((byte)value));
                    }
                    for (int i = num; i >= 0; i += -1)
                    {
                        if ((num2 & (long)Math.Pow(2.0, (double)i)) > 0L)
                        {
                            text += "1";
                        }
                        else
                        {
                            text += "0";
                        }
                    }
                }
                else
                {
                    text2 = value.GetType().Name;
                    if (!(text2 == "Byte[]"))
                    {
                        if (!(text2 == "Int16[]"))
                        {
                            if (!(text2 == "Int32[]"))
                            {
                                if (!(text2 == "Int64[]"))
                                {
                                    throw new Exception();
                                }
                                int num = 63;
                                byte[] array = (byte[])value;
                                for (int j = 0; j <= array.Length - 1; j++)
                                {
                                    for (int i = num; i >= 0; i += -1)
                                    {
                                        if ((array[j] & (byte)Math.Pow(2.0, (double)i)) > 0)
                                        {
                                            text += "1";
                                        }
                                        else
                                        {
                                            text += "0";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                int num = 31;
                                int[] array2 = (int[])value;
                                for (int j = 0; j <= array2.Length - 1; j++)
                                {
                                    for (int i = num; i >= 0; i += -1)
                                    {
                                        if ((array2[j] & (int)((byte)Math.Pow(2.0, (double)i))) > 0)
                                        {
                                            text += "1";
                                        }
                                        else
                                        {
                                            text += "0";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            int num = 15;
                            short[] array3 = (short[])value;
                            for (int j = 0; j <= array3.Length - 1; j++)
                            {
                                for (int i = num; i >= 0; i += -1)
                                {
                                    if ((array3[j] & (short)((byte)Math.Pow(2.0, (double)i))) > 0)
                                    {
                                        text += "1";
                                    }
                                    else
                                    {
                                        text += "0";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        int num = 7;
                        byte[] array4 = (byte[])value;
                        for (int j = 0; j <= array4.Length - 1; j++)
                        {
                            for (int i = num; i >= 0; i += -1)
                            {
                                if ((array4[j] & (byte)Math.Pow(2.0, (double)i)) > 0)
                                {
                                    text += "1";
                                }
                                else
                                {
                                    text += "0";
                                }
                            }
                        }
                    }
                }
                text2 = text;
            }
            catch
            {
                text2 = "";
            }
            return text2;
        }
        /// <summary>
        /// 查找位
        /// </summary>
        /// <param name="data"></param>
        /// <param name="bitPosition"></param>
        /// <returns></returns>
        public static bool SelectBit(this byte data, int bitPosition)
        {
            int num = 1 << bitPosition;
            return ((int)data & num) != 0;
        }
        /// <summary>
        /// 转换成短整型
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static short ConvertToShort(this ushort input)
        {
            return short.Parse(input.ToString("X"), NumberStyles.HexNumber);
        }
        /// <summary>
        /// 转换成无符号短整型
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static ushort ConvertToUshort(this short input)
        {
            return ushort.Parse(input.ToString("X"), NumberStyles.HexNumber);
        }
        /// <summary>
        /// 转换成整型
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int ConvertToInt(this uint input)
        {
            return int.Parse(input.ToString("X"), NumberStyles.HexNumber);
        }
        /// <summary>
        /// 转换成无符号整型
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static uint ConvertToUInt(this int input)
        {
            return uint.Parse(input.ToString("X"), NumberStyles.HexNumber);
        }
        /// <summary>
        /// 转换成无符号整型
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static uint ConvertToUInt(this double input)
        {
            return DWordFromByteArray(DoubleToByteArray(input));
        }
        /// <summary>
        /// 转换成双精度浮点数
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double ConvertToDouble(this uint input)
        {
            return DoubleFromByteArray(DWordToByteArray(input));
        }
        #endregion Conversion
        #region // Boolean 布尔值或位
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        public static bool BooleanGetValue(byte value, int bit)
        {
            return ((int)value & (int)Math.Pow(2.0, (double)bit)) != 0;
        }
        /// <summary>
        /// 设置位
        /// </summary>
        /// <param name="value"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        public static byte BooleanSetBit(byte value, int bit)
        {
            return (byte)(value | (byte)Math.Pow(2.0, (double)bit));
        }
        /// <summary>
        /// 清除位
        /// </summary>
        /// <param name="value"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        public static byte BooleanClearBit(byte value, int bit)
        {
            return (byte)(value & ~(byte)Math.Pow(2.0, (double)bit));
        }
        /// <summary>
        /// 清除位
        /// </summary>
        /// <param name="value"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        public static byte ClearBit(byte value, int bit)
        {
            return (byte)(value & ~(byte)Math.Pow(2.0, (double)bit));
        }
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        public static bool GetBit(byte value, int bit)
        {
            return ((int)value & (int)Math.Pow(2.0, (double)bit)) != 0;
        }
        /// <summary>
        /// 设置位
        /// </summary>
        /// <param name="value"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        public static byte SetBit(byte value, int bit)
        {
            return (byte)(value | (byte)Math.Pow(2.0, (double)bit));
        }
        #endregion Boolean
        #region // Byte 字节
        /// <summary>
        /// 转换成数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ByteToByteArray(byte value)
        {
            return new byte[] { value };
        }
        /// <summary>
        /// 取得只有一个元素的内容
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static byte ByteFromByteArray(byte[] bytes)
        {
            if (bytes?.Length == 1) { return bytes[0]; }
            throw new ArgumentException("字节数组必须是有且只有一个字节");
        }
        #endregion Byte
        #region // Class 类型对象
        /// <summary>
        /// 获取类长度
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        public static int GetClassSize(Type classType)
        {
            double num = 0.0;
            PropertyInfo[] properties = classType.GetProperties();
            int i = 0;
            while (i < properties.Length)
            {
                PropertyInfo propertyInfo = properties[i];
                string name = propertyInfo.PropertyType.Name;
                uint num2 = ComputeStringHash(name);
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
                num += (double)GetClassSize(propertyInfo.PropertyType);
                goto IL_276;
            }
            return (int)num;
        }
        /// <summary>
        /// 获取类长度
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        public static int ClassGetSize(Type classType) => GetClassSize(classType);
        /// <summary>
        /// 从字节中赋值
        /// </summary>
        /// <param name="sourceClass"></param>
        /// <param name="classType"></param>
        /// <param name="bytes"></param>
        public static void ClassFromBytes(object sourceClass, Type classType, byte[] bytes)
        {
            if (bytes == null) { return; }
            if (bytes.Length != GetClassSize(classType)) { return; }
            double num = 0.0;
            PropertyInfo[] properties = sourceClass.GetType().GetProperties();
            int i = 0;
            while (i < properties.Length)
            {
                PropertyInfo propertyInfo = properties[i];
                string name = propertyInfo.PropertyType.Name;
                uint num2 = ComputeStringHash(name);
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
                            propertyInfo.SetValue(sourceClass, DoubleFromByteArray(new byte[]
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
                            propertyInfo.SetValue(sourceClass, WordFromBytes(bytes[(int)num + 1], bytes[(int)num]), null);
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
                        ushort input = WordFromBytes(bytes[(int)num + 1], bytes[(int)num]);
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
                        uint input2 = DWordFromBytes(bytes[(int)num + 3], bytes[(int)num + 2], bytes[(int)num + 1], bytes[(int)num]);
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
                    propertyInfo.SetValue(sourceClass, DWordFromBytes(bytes[(int)num], bytes[(int)num + 1], bytes[(int)num + 2], bytes[(int)num + 3]), null);
                    num += 4.0;
                }
            IL_481:
                i++;
                continue;
            IL_424:
                byte[] array = new byte[GetClassSize(propertyInfo.PropertyType)];
                if (array.Length != 0)
                {
                    Buffer.BlockCopy(bytes, (int)Math.Ceiling(num), array, 0, array.Length);
                    object obj = Activator.CreateInstance(propertyInfo.PropertyType);
                    ClassFromBytes(obj, propertyInfo.PropertyType, array);
                    propertyInfo.SetValue(sourceClass, obj, null);
                    num += (double)array.Length;
                    goto IL_481;
                }
                goto IL_481;
            }
        }
        /// <summary>
        /// 类转换成字节
        /// </summary>
        /// <param name="sourceClass"></param>
        /// <returns></returns>
        public static byte[] ClassToBytes(object sourceClass)
        {
            byte[] array = new byte[GetClassSize(sourceClass.GetType())];
            double num = 0.0;
            foreach (PropertyInfo propertyInfo in sourceClass.GetType().GetProperties())
            {
                byte[] array2 = null;
                string name = propertyInfo.PropertyType.Name;
                uint num2 = ComputeStringHash(name);
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
                                    array2 = DoubleToByteArray((double)propertyInfo.GetValue(sourceClass, null));
                                }
                            }
                        }
                        else if (name == "UInt16")
                        {
                            array2 = WordToByteArray((ushort)propertyInfo.GetValue(sourceClass, null));
                        }
                    }
                    else if (name == "Int16")
                    {
                        array2 = IntToByteArray((short)propertyInfo.GetValue(sourceClass, null));
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
                        array2 = DIntToByteArray((int)propertyInfo.GetValue(sourceClass, null));
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
                    array2 = DWordToByteArray((uint)propertyInfo.GetValue(sourceClass, null));
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
        #endregion Class
        #region // Counter 计数器
        /// <summary>
        /// 从字节数组创建
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ushort CounterFromByteArray(byte[] bytes)
        {
            if (bytes?.Length == 2) { return CounterFromBytes(bytes[1], bytes[0]); }
            throw new ArgumentException("字节数组必须是有且只有二个字节");
        }

        /// <summary>
        /// 从高位/低位创建
        /// </summary>
        /// <returns></returns>
        public static ushort CounterFromBytes(byte LoVal, byte HiVal)
        {
            return (ushort)((int)HiVal * 256 + (int)LoVal);
        }
        /// <summary>
        /// 转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] CounterToByteArray(ushort value)
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
        /// 转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] CounterToByteArray(ushort[] value)
        {
            ByteArray byteArray = new ByteArray();
            foreach (ushort value2 in value)
            {
                byteArray.Add(CounterToByteArray(value2));
            }
            return byteArray.Array;
        }
        /// <summary>
        /// 转换成计数数组
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static ushort[] CounterToArray(byte[] bytes)
        {
            ushort[] array = new ushort[bytes.Length / 2];
            int num = 0;
            for (int i = 0; i < bytes.Length / 2; i++)
            {
                array[i] = CounterFromByteArray(new byte[]
                {
                    bytes[num++],
                    bytes[num++]
                });
            }
            return array;
        }
        #endregion Counter
        #region // DInt 整型
        /// <summary>
        /// 从字节转换
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int DIntFromByteArray(byte[] bytes)
        {
            if (bytes?.Length == 4) { return DIntFromBytes(bytes[3], bytes[2], bytes[1], bytes[0]); }
            throw new ArgumentException("字节数组必须是有且只有四个字节");
        }
        /// <summary>
        /// 从字节转换
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="v4"></param>
        /// <returns></returns>
        public static int DIntFromBytes(byte v1, byte v2, byte v3, byte v4)
        {
            return (int)((double)v1 + (double)v2 * Math.Pow(2.0, 8.0) + (double)v3 * Math.Pow(2.0, 16.0) + (double)v4 * Math.Pow(2.0, 24.0));
        }
        /// <summary>
        /// 转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] DIntToByteArray(int value)
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
        /// 转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] DIntToByteArray(int[] value)
        {
            ByteArray byteArray = new ByteArray();
            foreach (int value2 in value)
            {
                byteArray.Add(DIntToByteArray(value2));
            }
            return byteArray.Array;
        }
        /// <summary>
        /// 转换成整型数组
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static int[] DIntToArray(byte[] bytes)
        {
            int[] array = new int[bytes.Length / 4];
            int num = 0;
            for (int i = 0; i < bytes.Length / 4; i++)
            {
                array[i] = DIntFromByteArray(new byte[]
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
        /// 长整型转换
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int DIntCDWord(long value)
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
        #endregion DInt
        #region // Double 浮点数
        /// <summary>
        /// 从字节转换
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double DoubleFromByteArray(byte[] bytes)
        {
            if (bytes?.Length != 4) { throw new ArgumentException("字节数组必须是有且只有四个字节"); }
            byte b = bytes[0];
            byte b2 = bytes[1];
            byte b3 = bytes[2];
            byte b4 = bytes[3];
            if (b + b2 + b3 + b4 == 0)
            {
                return 0.0;
            }
            string text = DoubleValToBinString(b) + DoubleValToBinString(b2) + DoubleValToBinString(b3) + DoubleValToBinString(b4);
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
        /// 从整型转换
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double DoubleFromDWord(int value)
        {
            return DoubleFromByteArray(DIntToByteArray(value));
        }
        /// <summary>
        /// 从无符号整型转换
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double DoubleFromDWord(uint value)
        {
            return DoubleFromByteArray(DWordToByteArray(value));
        }
        /// <summary>
        /// 转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] DoubleToByteArray(double value)
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
                text += DoubleValToBinString((byte)(num2 + 127));
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
                array[0] = DoubleBinStringToByte(text.Substring(0, 8)).Value;
                array[1] = DoubleBinStringToByte(text.Substring(8, 8)).Value;
                array[2] = DoubleBinStringToByte(text.Substring(16, 8)).Value;
                array[3] = DoubleBinStringToByte(text.Substring(24, 8)).Value;
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
        /// 转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] DoubleToByteArray(double[] value)
        {
            ByteArray byteArray = new ByteArray();
            foreach (double value2 in value)
            {
                byteArray.Add(DoubleToByteArray(value2));
            }
            return byteArray.Array;
        }
        /// <summary>
        /// 转换成浮点数组
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static double[] DoubleToArray(byte[] bytes)
        {
            double[] array = new double[bytes.Length / 4];
            int num = 0;
            for (int i = 0; i < bytes.Length / 4; i++)
            {
                array[i] = DoubleFromByteArray(new byte[]
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
        /// 转换成位字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string DoubleValToBinString(byte value)
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
        /// 转换成字节
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        private static byte? DoubleBinStringToByte(string txt)
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
        #endregion Double
        #region // DWord 无符号整型
        /// <summary>
        /// 从字节数组
        /// </summary>
        /// <param name="bytes"></param>
        /// <exception cref="ArgumentException"></exception>
        public static uint DWordFromByteArray(byte[] bytes)
        {
            if (bytes?.Length == 4) { return DWordFromBytes(bytes[3], bytes[2], bytes[1], bytes[0]); }
            throw new ArgumentException("字节数组必须是有且只有四个字节");
        }
        /// <summary>
        /// 从字节
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="v4"></param>
        /// <returns></returns>
        public static uint DWordFromBytes(byte v1, byte v2, byte v3, byte v4)
        {
            return (uint)((double)v1 + (double)v2 * Math.Pow(2.0, 8.0) + (double)v3 * Math.Pow(2.0, 16.0) + (double)v4 * Math.Pow(2.0, 24.0));
        }
        /// <summary>
        /// 转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] DWordToByteArray(uint value)
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
        public static byte[] DWordToByteArray(uint[] value)
        {
            ByteArray byteArray = new ByteArray();
            foreach (uint value2 in value)
            {
                byteArray.Add(DWordToByteArray(value2));
            }
            return byteArray.Array;
        }
        /// <summary>
        /// 转换成无符号整型数组
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static uint[] DWordToArray(byte[] bytes)
        {
            uint[] array = new uint[bytes.Length / 4];
            int num = 0;
            for (int i = 0; i < bytes.Length / 4; i++)
            {
                array[i] = DWordFromByteArray(new byte[]
                {
                    bytes[num++],
                    bytes[num++],
                    bytes[num++],
                    bytes[num++]
                });
            }
            return array;
        }
        #endregion DWord
        #region // Int 短整型
        /// <summary>
        /// 从字节数组
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static short IntFromByteArray(byte[] bytes)
        {
            if (bytes?.Length == 2) { return IntFromBytes(bytes[1], bytes[0]); }
            throw new ArgumentException("字节数组必须是有且只有二个字节");
        }
        /// <summary>
        /// 从字节
        /// </summary>
        /// <param name="LoVal"></param>
        /// <param name="HiVal"></param>
        /// <returns></returns>
        public static short IntFromBytes(byte LoVal, byte HiVal)
        {
            return (short)((int)HiVal * 256 + (int)LoVal);
        }
        /// <summary>
        /// 转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] IntToByteArray(short value)
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
        /// 转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] IntToByteArray(short[] value)
        {
            ByteArray byteArray = new ByteArray();
            foreach (short value2 in value)
            {
                byteArray.Add(IntToByteArray(value2));
            }
            return byteArray.Array;
        }
        /// <summary>
        /// 转换成数组
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static short[] IntToArray(byte[] bytes)
        {
            short[] array = new short[bytes.Length / 2];
            int num = 0;
            for (int i = 0; i < bytes.Length / 2; i++)
            {
                array[i] = IntFromByteArray(new byte[]
                {
                    bytes[num++],
                    bytes[num++]
                });
            }
            return array;
        }
        /// <summary>
        /// 转换成值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static short IntCWord(int value)
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
        #region // String 字符串
        /// <summary>
        /// 字符串转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] StringToByteArray(string value)
        {
            char[] array = value.ToCharArray();
            byte[] array2 = new byte[value.Length];
            for (int i = 0; i <= array.Length - 1; i++)
            {
                array2[i] = (byte)StringAsc(array[i].ToString());
            }
            return array2;
        }
        /// <summary>
        /// 从字节数组转换
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string StringFromByteArray(byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes);
        }
        private static int StringAsc(string s)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            if (bytes.Length != 0)
            {
                return (int)bytes[0];
            }
            return 0;
        }
        #endregion String
        #region // Struct 结构体
        /// <summary>
        /// 获取结构体长度
        /// </summary>
        /// <param name="structType"></param>
        /// <returns></returns>
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
                num += (double)GetStructSize(fieldInfo.FieldType);
                goto IL_276;
            }
            return (int)num;
        }
        /// <summary>
        /// 获取结构体长度
        /// </summary>
        /// <param name="structType"></param>
        /// <returns></returns>
        public static int StructGetSize(Type structType) => GetStructSize(structType);
        /// <summary>
        /// 从字节转换
        /// </summary>
        /// <param name="structType"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static object StructFromBytes(Type structType, byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            if (bytes.Length != GetStructSize(structType))
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
                            fieldInfo.SetValue(obj, DoubleFromByteArray(new byte[]
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
                            fieldInfo.SetValue(obj, WordFromBytes(bytes[(int)num + 1], bytes[(int)num]));
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
                        ushort input = WordFromBytes(bytes[(int)num + 1], bytes[(int)num]);
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
                        uint input2 = DWordFromBytes(bytes[(int)num + 3], bytes[(int)num + 2], bytes[(int)num + 1], bytes[(int)num]);
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
                    fieldInfo.SetValue(obj, DWordFromBytes(bytes[(int)num], bytes[(int)num + 1], bytes[(int)num + 2], bytes[(int)num + 3]));
                    num += 4.0;
                }
            IL_471:
                i++;
                continue;
            IL_427:
                byte[] array = new byte[GetStructSize(fieldInfo.FieldType)];
                if (array.Length != 0)
                {
                    Buffer.BlockCopy(bytes, (int)Math.Ceiling(num), array, 0, array.Length);
                    fieldInfo.SetValue(obj, StructFromBytes(fieldInfo.FieldType, array));
                    num += (double)array.Length;
                    goto IL_471;
                }
                goto IL_471;
            }
            return obj;
        }
        /// <summary>
        /// 转换成字节
        /// </summary>
        /// <param name="structValue"></param>
        /// <returns></returns>
        public static byte[] StructToBytes(object structValue)
        {
            Type type = structValue.GetType();
            byte[] array = new byte[GetStructSize(type)];
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
                                    array2 = DoubleToByteArray((double)fieldInfo.GetValue(structValue));
                                }
                            }
                        }
                        else if (name == "UInt16")
                        {
                            array2 = WordToByteArray((ushort)fieldInfo.GetValue(structValue));
                        }
                    }
                    else if (name == "Int16")
                    {
                        array2 = IntToByteArray((short)fieldInfo.GetValue(structValue));
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
                        array2 = DIntToByteArray((int)fieldInfo.GetValue(structValue));
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
                    array2 = DWordToByteArray((uint)fieldInfo.GetValue(structValue));
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
        #endregion
        #region // Timer 计时器
        /// <summary>
        /// 从字节数组
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static double TimerFromByteArray(byte[] bytes)
        {
            string text = ((short)WordFromBytes(bytes[1], bytes[0])).ValToBinString();
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
        /// 转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] TimerToByteArray(ushort value)
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
        /// 转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] TimerToByteArray(ushort[] value)
        {
            ByteArray byteArray = new ByteArray();
            foreach (ushort value2 in value)
            {
                byteArray.Add(TimerToByteArray(value2));
            }
            return byteArray.Array;
        }
        /// <summary>
        /// 转换成浮点数组
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static double[] TimerToArray(byte[] bytes)
        {
            double[] array = new double[bytes.Length / 2];
            int num = 0;
            for (int i = 0; i < bytes.Length / 2; i++)
            {
                array[i] = TimerFromByteArray(new byte[]
                {
                    bytes[num++],
                    bytes[num++]
                });
            }
            return array;
        }
        #endregion
        #region // Word 无符号短整型
        /// <summary>
        /// 从字节数组转换
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ushort WordFromByteArray(byte[] bytes)
        {
            if (bytes?.Length == 2) { return WordFromBytes(bytes[1], bytes[0]); }
            throw new ArgumentException("字节数组必须是有且只有二个字节");
        }
        /// <summary>
        /// 转换成无符号整型
        /// </summary>
        /// <param name="LoVal"></param>
        /// <param name="HiVal"></param>
        /// <returns></returns>
        public static ushort WordFromBytes(byte LoVal, byte HiVal)
        {
            return (ushort)((int)HiVal * 256 + (int)LoVal);
        }
        /// <summary>
        /// 转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] WordToByteArray(ushort value)
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
        /// 转换成字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] WordToByteArray(ushort[] value)
        {
            ByteArray byteArray = new ByteArray();
            foreach (ushort value2 in value)
            {
                byteArray.Add(WordToByteArray(value2));
            }
            return byteArray.Array;
        }
        /// <summary>
        /// 转换成无符号短整型数组
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static ushort[] WordToArray(byte[] bytes)
        {
            ushort[] array = new ushort[bytes.Length / 2];
            int num = 0;
            for (int i = 0; i < bytes.Length / 2; i++)
            {
                array[i] = WordFromByteArray(new byte[]
                {
                    bytes[num++],
                    bytes[num++]
                });
            }
            return array;
        }
        #endregion
    }
}
