using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.WeiGuangCodeBarSDK
{
    /// <summary>
    /// 简单VBar接口
    /// </summary>
    public class SimpleVBarApi
    {
        private IntPtr dev = IntPtr.Zero;
        private ISimpleVBarSdkProxy _proxy;
        /// <summary>
        /// 构造
        /// </summary>
        public SimpleVBarApi() : this(false) { }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="isBase"></param>
        public SimpleVBarApi(bool isBase)
        {
            _proxy = SimpleVBarSdk.Create(isBase);
        }
        /// <summary>
        /// 连接设备
        /// </summary>
        /// <returns></returns>
        public bool OpenDevice()
        {
            dev = _proxy.Vbar_channel_open(1, 1);
            if (dev == IntPtr.Zero)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 打开设备
        /// </summary>
        public void CloseDevice()
        {
            if (dev != IntPtr.Zero)
            {
                _proxy.Vbar_channel_close(dev);
                dev = IntPtr.Zero;
            }

        }
        byte[] iSetByte_ctl = new byte[64];
        /// <summary>
        /// 扫码开关
        /// </summary>
        /// <param name="cswitch"></param>
        public void ControlScan(bool cswitch)
        {
            if (dev != IntPtr.Zero)
            {
                if (cswitch)
                {
                    iSetByte_ctl[0] = 0x55;
                    iSetByte_ctl[1] = 0xAA;
                    iSetByte_ctl[2] = 0x05;
                    iSetByte_ctl[3] = 0x01;
                    iSetByte_ctl[4] = 0x00;
                    iSetByte_ctl[5] = 0x00;
                    iSetByte_ctl[6] = 0xfb;
                }
                else
                {
                    iSetByte_ctl[0] = 0x55;
                    iSetByte_ctl[1] = 0xAA;
                    iSetByte_ctl[2] = 0x05;
                    iSetByte_ctl[3] = 0x01;
                    iSetByte_ctl[4] = 0x00;
                    iSetByte_ctl[5] = 0x01;
                    iSetByte_ctl[6] = 0xfa;
                }
                _proxy.Vbar_channel_send(dev, iSetByte_ctl, 64);
            }

        }
        byte[] iSetByte = new byte[64];
        /// <summary>
        /// 背光控制
        /// </summary>
        /// <param name="bswitch"></param>
        public void Backlight(bool bswitch)
        {
            if (dev != IntPtr.Zero)
            {
                if (bswitch)
                {
                    iSetByte[0] = 0x55;
                    iSetByte[1] = 0xAA;
                    iSetByte[2] = 0x24;
                    iSetByte[3] = 0x01;
                    iSetByte[4] = 0x00;
                    iSetByte[5] = 0x01;
                    iSetByte[6] = 0xDB;
                }
                else
                {
                    iSetByte[0] = 0x55;
                    iSetByte[1] = 0xAA;
                    iSetByte[2] = 0x24;
                    iSetByte[3] = 0x01;
                    iSetByte[4] = 0x00;
                    iSetByte[5] = 0x00;
                    iSetByte[6] = 0xDA;
                }
                _proxy.Vbar_channel_send(dev, iSetByte, 64);
            }

        }
        /// <summary>
        /// 解码设置
        /// </summary>
        /// <param name="result_buffer"></param>
        /// <param name="result_size"></param>
        /// <returns></returns>
        public bool GetResultStr(out byte[] result_buffer, out int result_size)
        {
            if (dev != IntPtr.Zero)
            {
                byte[] bufferrecv = new byte[1024];
                _proxy.Vbar_channel_recv(dev, bufferrecv, 1024, 200);
                if (bufferrecv[0] == 85 && bufferrecv[1] == 170 && bufferrecv[3] == 0)
                {
                    //Console.WriteLine(bufferrecv[4]);
                    //Console.WriteLine(bufferrecv[5]);
                    int datalen = bufferrecv[4] + (bufferrecv[5] << 8);
                    //Console.WriteLine(datalen);
                    byte[] readBuffers = new byte[datalen];
                    for (int s1 = 0; s1 < datalen; s1++)
                    {
                        readBuffers[s1] = bufferrecv[6 + s1];
                    }
                    result_buffer = readBuffers;
                    result_size = datalen;
                    return true;
                }
                else
                {
                    result_buffer = null;
                    result_size = 0;
                    return false;
                }
            }
            else
            {
                result_buffer = null;
                result_size = 0;
                return false;
            }
        }
        /// <summary>
        /// 解码设置
        /// </summary>
        /// <param name="resuult"></param>
        /// <returns></returns>
        public bool GetResultStr(out string resuult)
        {
            if (dev != IntPtr.Zero)
            {
                byte[] bufferrecv = new byte[1024];
                _proxy.Vbar_channel_recv(dev, bufferrecv, 1024, 200);
                if (bufferrecv[0] == 85 && bufferrecv[1] == 170 && bufferrecv[3] == 0)
                {
                    int datalen = bufferrecv[4] + (bufferrecv[5] << 8);
                    byte[] readBuffers = new byte[datalen];
                    for (int s1 = 0; s1 < datalen; s1++)
                    {
                        readBuffers[s1] = bufferrecv[6 + s1];
                    }
                    resuult = Encoding.UTF8.GetString(readBuffers);
                    return true;
                }
                else
                {
                    resuult = null;
                    return false;
                }
            }
            else
            {
                resuult = null;
                return false;
            }
        }
    }
}
