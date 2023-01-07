using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //禁止名单报警信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_BLOCKLIST_INFO_ALARM
    {
        public NET_VCA_BLOCKLIST_INFO struBlockListInfo;
        public uint dwBlockListPicLen;       //禁止名单人脸子图的长度，为0表示没有图片，大于0表示有图片
        public uint dwFDIDLen;// 人脸库ID长度
        public IntPtr pFDID;  //人脸库Id指针
        public uint dwPIDLen;// 人脸库图片ID长度
        public IntPtr pPID;  //人脸库图片ID指针
        public ushort wThresholdValue; //人脸库阈值[0,100]
        public byte byIsNoSaveFDPicture;//0-保存人脸库图片,1-不保存人脸库图片, 若开启了导入图片或者建模时不保存原图功能时,该字段返回1,此时人脸库图片将不再返回
        public byte byRealTimeContrast;//是否实时报警 0-实时 1-非实时
        public IntPtr pBuffer1;//指向图片的指针
    }
}
