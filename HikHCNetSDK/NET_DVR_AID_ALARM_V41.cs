using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //交通事件报警(扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_AID_ALARM_V41
    {
        public uint dwSize;              //结构长度
        public uint dwRelativeTime;        //相对时标
        public uint dwAbsTime;            //绝对时标
        public NET_VCA_DEV_INFO struDevInfo;            //前端设备信息
        public NET_DVR_AID_INFO struAIDInfo;         //交通事件信息
        public NET_DVR_SCENE_INFO struSceneInfo;       //场景信息
        public uint dwPicDataLen;        //图片长度
        public IntPtr pImage;             //指向图片的指针
                                          // 0-数据直接上传; 1-云存储服务器URL(3.7Ver)原先的图片数据变成URL数据，图片长度变成URL长度
        public byte byDataType;
        public byte byLaneNo;  //关联车道号 
        public ushort wMilliSecond;        //时标毫秒
                                           //监测点编号（路口编号、内部编号）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MONITORSITE_ID_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byMonitoringSiteID;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.DEVICE_ID_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byDeviceID;//设备编号
        public uint dwXmlLen;//XML报警信息长度
        public IntPtr pXmlBuf;// XML报警信息指针,其XML对应到EventNotificationAlert XML Block
        public byte byTargetType;// 检测的目标类型，0~未知，1~行人、2~二轮车、3~三轮车(行人检测中返回)
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 19, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; // 保留字节   
    }



}
