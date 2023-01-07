using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*ftp上传参数*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FTPCFG
    {
        public uint dwSize;
        public uint dwEnableFTP;            /*是否启动ftp上传功能*/
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sFTPIP;               /*ftp 服务器*/
        public uint dwFTPPort;              /*ftp端口*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;    /*用户名*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;    /*密码*/
        public uint dwDirLevel; /*0 = 不使用目录结构，直接保存在根目录,1 = 使用1级目录,2=使用2级目录*/
        public ushort wTopDirMode;  /* 一级目录，0x1 = 使用设备名,0x2 = 使用设备号,0x3 = 使用设备ip地址，0x4=使用监测点,0x5=使用时间(年月),0x=6自定义,0x7=违规类型,0x8=方向,0x9=地点*/
        public ushort wSubDirMode;  /* 二级目录，0x1 = 使用通道名,0x2 = 使用通道号，,0x3=使用时间(年月日),0x4=使用车道号,0x=5自定义,0x6=违规类型,0x7=方向,0x8=地点*/
        public byte byEnableAnony; //启用匿名，0-否，1-是
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 23, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
