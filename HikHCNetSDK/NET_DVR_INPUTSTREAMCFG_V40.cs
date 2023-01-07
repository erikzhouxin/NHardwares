using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INPUTSTREAMCFG_V40
    {
        public uint dwSize;
        public byte byValid;     //
        public byte byCamMode;//见NET_DVR_CAM_MODE
        public ushort wInputNo; //信号源序号
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.NAME_LEN)]
        public string sCamName;
        public NET_DVR_VIDEOEFFECT struVideoEffect;//视频参数
        public NET_DVR_PU_STREAM_CFG struPuStream;    //ip输入时使用
        public ushort wBoardNum;      //信号源所在的板卡号，只能获取
        public ushort wInputIdxOnBoard; //信号源在板卡上的位置，只能获取
        public uint dwResolution;//分辨率
        public byte byVideoFormat;//视频制式，见VIDEO_STANDARD
        public byte byStatus;    //信号源状态，0-字段无效 1-有信号 2-无信号 3-异常 
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.NAME_LEN)]
        public string sGroupName;    //网络信号源分组 组名
        public byte byJointMatrix;            //关联矩阵，0-不关联  1-关联，当输入信号源为NET_DVR_CAM_BNC，NET_DVR_CAM_VGA，NET_DVR_CAM_DVI，NET_DVR_CAM_HDMI,中的一种时，该参数有效。
        public byte byJointNo;         //拼接信号源的拼接编号(只能获取)
        public byte byColorMode;      //色彩模式， 0-自定义 1-锐利 2-普通 3-柔和，当为自定义时，使用struVideoEffect设置
        public byte byScreenServer; //关联屏幕服务器，0-不联，1-关联
        public byte byDevNo; //设备号
        public byte byRes1;
        public uint dwInputSignalNo; //输入信号源编号（新）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 120, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
