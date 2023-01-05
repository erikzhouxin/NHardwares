using System;
using System.Collections.Generic;
using System.Data.NSerialPort;
using System.Linq;
using System.Text;

namespace System.Data.RecBarCodeModule
{
    /// <summary>
    /// 识别二维码组件
    /// </summary>
    public static class RecBarCodeSdk
    {
        /// <summary>
        /// CRC 校验，采用的是 CRC16_XMODEM，多项式 x16+x12+x5+1（0x1021）。
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static int XModemInt(byte[] bytes) => XModemInt(bytes, 0, bytes.Length);
        /// <summary>
        /// CRC 校验，采用的是 CRC16_XMODEM，多项式 x16+x12+x5+1（0x1021），数据反转为 MSB First, 数据格式为字符串格式的配置。
        /// 如一条命令为：$xxxxxx-yyyy, 这 yyyy 这 4 位为检验码，$xxxxxx-这 8 位为计算校验的内容。
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int XModemInt(byte[] bytes, int offset, int count)
        {
            int crc = 0x0000;
            var end = offset + count;
            int ployNormal = 0x1021;
            for (int index = offset; index < end; index++)
            {
                var b = bytes[index];
                for (int i = 0; i < 8; i++)
                {
                    var bit = ((b >> (7 - i) & 1) == 1);
                    var cl5 = ((crc >> 15 & 1) == 1);
                    crc <<= 1;
                    if (cl5 ^ bit)
                    {
                        crc ^= ployNormal;
                    }
                }
            }
            crc &= 0xffff;
            return crc;
        }
        /// <summary>
        /// CRC 校验，采用的是 CRC16_XMODEM，多项式 x16+x12+x5+1（0x1021）。
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static short XModemShort(byte[] bytes, int offset, int count) => (short)XModemInt(bytes, offset, count);
        /// <summary>
        /// CRC 校验，采用的是 CRC16_XMODEM，多项式 x16+x12+x5+1（0x1021）。
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static short XModemShort(byte[] bytes) => (short)XModemInt(bytes, 0, bytes.Length);
        /// <summary>
        /// 创建一个二维码识别实例
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IRecBarCodeProxy CreateRecBarCode(this ISerialPortConfigModel config)
        {
            var talkModel = config.CreateTalk();
            return new RecBarCodeModuleProxy(talkModel);
        }
    }
}
