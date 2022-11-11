using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_StuUserInfo
    {
        public string strDevIP;
        public string strDevAdmin;
        public string strDevPassWord;
        public int iPort;
        public IntPtr lpDevHandle;
        public IntPtr lpPicHandle;
        public IntPtr lpUserData;
        public Boolean bLogin;
        public Boolean bStartStream;
        public IntPtr lpStreamHandle;  /* 用于存储起照片流时传入的用户数据的地址，通过它在照片回调函数中辨别数据属于哪台设备 */
        public int ulPicCount;
    }

}
