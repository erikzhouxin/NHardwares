using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 深坂R600读写代理
    /// </summary>
    public static class R600Builder
    {
        /// <summary>
        /// 创建读写器
        /// </summary>
        public static IR600Reader GetReader(IR600Recall recall)
        {
            var result = new R600Reader();
            result.RegistCallback(recall);
            return result;
        }
        /// <summary>
        /// 创建读写器
        /// </summary>
        [Obsolete("替代方案:GetReader")]
        public static IR600Reader GetQueue(IR600Recall recall)
        {
            var result = new R600Queue();
            result.RegistCallback(recall);
            return result;
        }
        #region // 辅助方法
        /// <summary>
        /// 获取区域频率
        /// </summary>
        /// <param name="region"></param>
        /// <param name="start"></param>
        /// <param name="interval"></param>
        /// <param name="freq"></param>
        /// <returns></returns>
        public static double GetFreq(byte region, int start, byte interval, byte freq)
        {
            if (region == 4)
            {
                return (start + freq * interval * 10) / 1000;
            }
            else if (freq < 0x07)
            {
                return 865.00 + Convert.ToInt32(freq) * 0.5;
            }
            else
            {
                return 902.00 + (Convert.ToInt32(freq) - 7) * 0.5;
            }
        }
        /// <summary>
        /// 字符串转16进制数组，字符串以空格分割
        /// </summary>
        /// <param name="strHexValue"></param>
        /// <returns></returns>
        public static byte[] StringToByteArray(string strHexValue)
        {
            string[] strAryHex = strHexValue.Split(' ');
            byte[] btAryHex = new byte[strAryHex.Length];
            try
            {
                int nIndex = 0;
                foreach (string strTemp in strAryHex)
                {
                    btAryHex[nIndex] = Convert.ToByte(strTemp, 16);
                    nIndex++;
                }
            }
            catch { }
            return btAryHex;
        }

        /// <summary>
        /// 字符数组转为16进制数组
        /// </summary>
        /// <param name="strAryHex"></param>
        /// <param name="nLen"></param>
        /// <returns></returns>
        public static byte[] StringArrayToByteArray(string[] strAryHex, int nLen)
        {
            if (strAryHex.Length < nLen)
            {
                nLen = strAryHex.Length;
            }
            byte[] btAryHex = new byte[nLen];
            try
            {
                int nIndex = 0;
                foreach (string strTemp in strAryHex)
                {
                    btAryHex[nIndex] = Convert.ToByte(strTemp, 16);
                    nIndex++;
                }
            }
            catch { }
            return btAryHex;
        }

        /// <summary>
        /// 16进制字符数组转成字符串
        /// </summary>
        /// <param name="btAryHex"></param>
        /// <param name="nIndex"></param>
        /// <param name="nLen"></param>
        /// <returns></returns>
        public static string ByteArrayToString(byte[] btAryHex, int nIndex, int nLen)
        {
            if (nIndex + nLen > btAryHex.Length)
            {
                nLen = btAryHex.Length - nIndex;
            }
            string strResult = string.Empty;
            for (int nloop = nIndex; nloop < nIndex + nLen; nloop++)
            {
                string strTemp = string.Format(" {0:X2}", btAryHex[nloop]);
                strResult += strTemp;
            }
            return strResult;
        }

        /// <summary>
        /// 将字符串按照指定长度截取并转存为字符数组，空格忽略
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
        public static string[] StringToStringArray(string strValue, int nLength)
        {
            string[] strAryResult = null;

            if (!string.IsNullOrEmpty(strValue))
            {
                ArrayList strListResult = new();
                string strTemp = string.Empty;
                int nTemp = 0;

                for (int nloop = 0; nloop < strValue.Length; nloop++)
                {
                    if (strValue[nloop] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        nTemp++;

                        //校验截取的字符是否在A~F、0~9区间，不在则直接退出
                        Regex reg = new(@"^(([A-F])*(\d)*)$");
                        if (!reg.IsMatch(strValue.Substring(nloop, 1)))
                        {
                            return strAryResult;
                        }

                        strTemp += strValue.Substring(nloop, 1);

                        //判断是否到达截取长度
                        if ((nTemp == nLength) || (nloop == strValue.Length - 1 && !string.IsNullOrEmpty(strTemp)))
                        {
                            strListResult.Add(strTemp);
                            nTemp = 0;
                            strTemp = string.Empty;
                        }
                    }
                }

                if (strListResult.Count > 0)
                {
                    strAryResult = new string[strListResult.Count];
                    strListResult.CopyTo(strAryResult);
                }
            }

            return strAryResult;
        }
        /// <summary>
        /// 格式化错误代码
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string FormatErrorCode(byte errorCode, out int code)
        {
            code = errorCode;
            return FormatErrorCode(errorCode);
        }
        /// <summary>
        /// 格式化错误代码
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static string FormatErrorCode(byte errorCode)
        {
            return errorCode switch
            {
                0x10 => "命令已执行",
                0x11 => "命令执行失败",
                0x20 => "CPU 复位错误",
                0x21 => "打开CW 错误",
                0x22 => "天线未连接",
                0x23 => "写Flash 错误",
                0x24 => "读Flash 错误",
                0x25 => "设置发射功率错误",
                0x31 => "盘存标签错误",
                0x32 => "读标签错误",
                0x33 => "写标签错误",
                0x34 => "锁定标签错误",
                0x35 => "灭活标签错误",
                0x36 => "无可操作标签错误",
                0x37 => "成功盘存但访问失败",
                0x38 => "缓存为空",
                0x40 => "访问标签错误或访问密码错误",
                0x41 => "无效的参数",
                0x42 => "wordCnt 参数超过规定长度",
                0x43 => "MemBank 参数超出范围",
                0x44 => "Lock 数据区参数超出范围",
                0x45 => "LockType 参数超出范围",
                0x46 => "读卡器地址无效",
                0x47 => "Antenna_id 超出范围",
                0x48 => "输出功率参数超出范围",
                0x49 => "射频规范区域参数超出范围",
                0x4A => "波特率参数超过范围",
                0x4B => "蜂鸣器设置参数超出范围",
                0x4C => "EPC 匹配长度越界",
                0x4D => "EPC 匹配长度错误",
                0x4E => "EPC 匹配参数超出范围",
                0x4F => "频率范围设置参数错误",
                0x50 => "无法接收标签的RN16",
                0x51 => "DRM 设置参数错误",
                0x52 => "PLL 不能锁定",
                0x53 => "射频芯片无响应",
                0x54 => "输出达不到指定的输出功率",
                0x55 => "版权认证未通过",
                0x56 => "频谱规范设置错误",
                0x57 => "输出功率过低",
                0xFF => "未知错误",
                _ => string.Empty,
            };
        }
        #endregion
        #region // 内部方法
        /// <summary>
        /// 获取MD5加密值
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        internal static byte[] GetMd5(this byte[] bytes)
        {
            return new MD5CryptoServiceProvider().ComputeHash(bytes);
        }
        /// <summary>
        /// 获取MD5加密值
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        internal static string GetMd5String(this byte[] bytes)
        {
            return GetHexString(GetMd5(bytes));
        }
        /// <summary>
        /// 将字节数组转换成16进制字符串
        /// </summary>
        /// <param name="hashData">字节数组</param>
        /// <returns>16进制字符串(大写字母)</returns>
        internal static string GetHexString(this byte[] hashData)
        {
            StringBuilder sBuilder = new StringBuilder();
            foreach (var hash in hashData)
            {
                sBuilder.AppendFormat("{0:X2}", hash);
            }
            return sBuilder.ToString();
        }
        internal static bool IsDefault<T>(this T model) where T : struct
        {
            return model.Equals(default(T));
        }
        /// <summary>
        /// 转换成Int32 高位是第一个
        /// </summary>
        /// <param name="aryData"></param>
        /// <returns></returns>
        internal static Int32 ConvertInt32(this byte[] aryData)
        {
            int res = 0;
            for (int i = 1; i <= aryData.Length; i++)
            {
                var dist = 8 * (i - 1);
                res += ((int)aryData[aryData.Length - i]) >> dist;
            }
            return res;
        }
        #endregion
    }
}
