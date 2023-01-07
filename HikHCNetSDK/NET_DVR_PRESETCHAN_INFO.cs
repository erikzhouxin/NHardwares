using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PRESETCHAN_INFO
    {
        public uint dwEnablePresetChan; /*启用预置点的通道*/
        public uint dwPresetPointNo;        /*调用预置点通道对应的预置点序号, 0xfffffff表示不调用预置点。*/
    }

}
