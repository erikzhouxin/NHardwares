using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INQUEST_CDRW
    {
        public uint dwEnable;            //刻录机状态是否有效,0-无效,1-有效    
        public uint dwStatus;            /* 当dwType=0时，
                                                            0-光盘正常，1-无光盘或光盘异常,
                                                            当dwType=1或2时，
                                                            0-刻录正常，1-无光盘或光盘异常，
                                                            2-光盘已封盘(81不支持)，3-光盘空间不足，
                                                            4-异常导致审讯终止(81不支持)
                                                            当dwType=3时，
                                                            0-刻录正常，1-无光盘或光盘异常，
                                                            2-光盘已封盘(81不支持)，3-光盘空间不足
                                                            当dwType=4时，
                                                            0-刻录正常，1-无光盘或光盘异常，
                                                            2-光盘已封盘(81不支持)，3-光盘空间不足
                                                            当dwType=5时,
                                                            0-光盘正常， 1-无光盘或光盘异常,
                                                            2-光盘已封盘(81不支持)
                                                            当dwType=6或7时,
                                                            0-刻录正常, 1-无光盘或光盘异常,
                                2-光盘已封盘(81不支持), 3-光盘空间不足*/
        public uint dwVolumn;      //光盘容量,单位M
        public uint dwFreeSpace;   //光盘剩余容量,单位M    
        public uint dwTimeLeft;     // 光盘剩余时间，单位秒
        public byte byCDType;         // 光盘类型
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;      //保留字节
    }
}
