using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_STREAM_MODE
    {
        public byte byGetStreamType;/*取流方式：0- 直接从设备取流；1- 从流媒体取流；2- 通过IPServer获得IP地址后取流；
                                          * 3- 通过IPServer找到设备，再通过流媒体取设备的流； 4- 通过流媒体由URL去取流；
                                          * 5- 通过hiDDNS域名连接设备然后从设备取流 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public NET_DVR_GET_STREAM_UNION uGetStream;
        public void Init()
        {
            byGetStreamType = 0;
            byRes = new byte[3];
            //uGetStream.Init();
        }
    }

}
