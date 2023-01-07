using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CRUISECHAN_INFO
    {
        public uint dwEnableCruiseChan; /*启用巡航的通道*/
        public uint dwCruiseNo;     /*巡航通道对应的巡航编号, 0xfffffff表示无效*/
    }

}
