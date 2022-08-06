using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.WeiGuangCodeBarSDK
{
    internal partial class DCreater
    {
        //打开信道
        public delegate IntPtr vbar_channel_open(int type, long parm);
        //发送数据
        public delegate int vbar_channel_send(IntPtr dev, byte[] data, int length);
        //接收数据
        public delegate int vbar_channel_recv(IntPtr dev, byte[] buffer, int size, int milliseconds);
        //关闭信道
        public delegate void vbar_channel_close(IntPtr dev);
    }
}
