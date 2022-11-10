using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TMS_FACE_SNAPSHOT_PIC_INFO_S
    {
        public Int32 udwFaceId;
        public IntPtr pcPicBuff;
        public Int32 udwPicBuffLen;
        public Int32 enImgType;
        public Int32 enImgFormat;
        NETDEV_FACE_POSITION_INFO_S stFacePos;
        public Int32 udwImageWidth;
        public Int32 udwImageHeight;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TMS_CAMER_ID_LEN)]
        public char[] szCamerID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TMS_FACE_RECORD_ID_LEN)]
        public char[] szRecordID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TMS_FACE_TOLLGATE_ID_LEN)]
        public char[] szTollgateID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TMS_PASSTIME_LEN)]
        public char[] szPassTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
        public byte[] byRes;                                            /*   Reserved field*/
    };

}
