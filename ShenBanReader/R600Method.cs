using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 消息接收事件委托
    /// </summary>
    /// <param name="btAryBuffer"></param>
    public delegate void R600ReceivedEventHandler(byte[] btAryBuffer);
    /// <summary>
    /// 接受数据回调
    /// </summary>
    /// <param name="btAryReceiveData"></param>
    public delegate void R600ReciveCallback(byte[] btAryReceiveData);
    /// <summary>
    /// 发送数据回调
    /// </summary>
    /// <param name="btArySendData"></param>
    public delegate void R600SendCallback(byte[] btArySendData);
    /// <summary>
    /// 解析数据回调
    /// </summary>
    /// <param name="msgTran"></param>
    public delegate void R600AnalyCallback(R600Message msgTran);
    /// <summary>
    /// 方法操作
    /// </summary>
    public static class R600Method
    {
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
    }
}
