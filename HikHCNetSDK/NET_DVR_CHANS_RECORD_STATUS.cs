using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //channel record status
    //***通道录像状态*****//
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CHANS_RECORD_STATUS
    {
        public byte byValid;       //是否有效
        public byte byRecord;      /*(只读)录像类型, 按位表示:0: 不在录像；1：在录像 2-空闲 
						3-无连接 4-无输入视频 5-未加载 6-存档中
							7-回传中 8-用户名或密码错 9-未验证
							10-存档中和录像中 11-录像回传中和录像中*/
        public ushort wChannelNO;   //通道号
        public uint dwRelatedHD;  //关联磁盘
        public byte byOffLineRecord;  //断网录像功能 0-关闭 1-开启
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;      //保留字节
    }
}
