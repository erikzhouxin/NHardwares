using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INPUTSTREAMCFG
    {
        public uint dwSize;
        public byte byValid;
        public byte byCamMode;                      //信号输入源类型，见NET_DVR_CAM_MODE
        public ushort wInputNo;                     //信号源序号0-224
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sCamName;         //信号输入源名称
        public NET_DVR_VIDEOEFFECT struVideoEffect; //视频参数
        public NET_DVR_PU_STREAM_CFG struPuStream;  //ip输入时使用
        public ushort wBoardNum;                        //信号源所在的板卡号
        public ushort wInputIdxOnBoard;             //信号源在板卡上的位置
        public ushort wResolutionX;                 //分辨率
        public ushort wResolutionY;
        public byte byVideoFormat;                  //视频制式，0-无，1-NTSC，2-PAL
        public byte byNetSignalResolution;  //; 1-CIF 2-4CIF 3-720P 4-1080P 5-500wp 。网络信号源的分辨率，在添加网络信号源时传给设备，设备根据这个分辨率来分配解码资源。
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sGroupName;   //网络信号源分组 组名
        public byte byJointMatrix;          //  关联矩阵 ，0-不关联  1-关联
        public byte byRes;
    }
}
