using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*该结构体表示IAS智能库标定样本，其中包括一个目标框和一条对应的高度标定线；
     * 目标框为站立的人体外接矩形框；高度线样本标识从人头顶点到脚点的标定线；用归一化坐标表示；*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IN_CAL_SAMPLE
    {
        public NET_VCA_RECT struVcaRect;   // 目标框
        public NET_DVR_LINE_SEGMENT struLineSegment;    // 高度标定线
    }


}
