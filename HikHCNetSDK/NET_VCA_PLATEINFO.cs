using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //车牌识别参数子结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_PLATEINFO
    {
        public VCA_RECOGNIZE_SCENE eRecogniseScene;//识别场景(低速和高速)
        public NET_VCA_PLATE_PARAM struModifyParam;//车牌可动态修改参数
    }
}
