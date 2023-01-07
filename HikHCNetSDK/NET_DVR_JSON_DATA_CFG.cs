using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_JSON_DATA_CFG
    {
        public uint dwSize;                    //size of NET_DVR_JSON_DATA_CFG
        public IntPtr lpJsonData;                //Json data
        public uint dwJsonDataSize;            //Json data size
        public IntPtr lpPicData;                //picture data
        public uint dwPicDataSize;            //picture data size
        public uint dwInfraredFacePicSize;            //infrared picture data size
        public IntPtr lpInfraredFacePicBuffer;                //infrared picture data
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 248)]
        public byte[] byRes;  //reserve
    }

}
