using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //线结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_LINE
    {
        public NET_VCA_POINT struStart;//起点 
        public NET_VCA_POINT struEnd; //终点

        //             public void Init()
        //             {
        //                 struStart = new NET_VCA_POINT();
        //                 struEnd = new NET_VCA_POINT();
        //             }
    }

}
