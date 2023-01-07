using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INQUEST_ROOM_INFO
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.NAME_LEN)]
        public string szCDName; //光盘名称，单室双刻光盘名称是一样的
        [StructLayoutAttribute(LayoutKind.Explicit)]
        public struct uCalcMode
        {
            [FieldOffsetAttribute(0)]
            public byte byBitRate;  // byCalcType为0时有效，(0-32、1-48、2-64、3-80、4-96、5-128、
                                    //6-160、7-192、8-224、9-256、10-320、11-384、12-448、
                                    //13-512、14-640、15-768、16-896前16个值保留)17-1024、18-1280、19-1536、
                                    //20-1792、21-2048、22-3072、23-4096、24-8192
            [FieldOffsetAttribute(0)]
            public byte byInquestTime;  // byCalcType为1时有效，0-1小时, 1-2小时,2-3小时,3-4小时, 4-6小时,5-8小时
                                        //8-16小时, 9-20小时,10-22小时,11-24小时
        }
        public byte byCalcType;         //刻录计算类型0-按码率 1-按时间
        public byte byAutoDelRecord;    // 是否自动删除录像，0-不删除，即结束时保存录像 1-删除
        public byte byAlarmThreshold;       // 声音报警阀值
        public byte byInquestChannelResolution;     //审讯通道分辨率，0:720P  1:1080P
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
