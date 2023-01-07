using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    // 标定参数联合体
    // 后续的相关标定参数可以放在该结构里面
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct NET_DVR_CALIBRATION_PRARM_UNION
    {
        [FieldOffsetAttribute(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 240, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  //联合体结构大小
        /*[FieldOffsetAttribute(0)]
        public NET_DVR_PDC_CALIBRATION struPDCCalibration;  //PDC 标定参数
        [FieldOffsetAttribute(0)]
        public NET_DVR_BEHAVIOR_OUT_CALIBRATION  struBehaviorOutCalibration;  //  行为室外场景标定  主要应用于IVS等
        [FieldOffsetAttribute(0)]
        public NET_DVR_BEHAVIOR_IN_CALIBRATION  struBehaviorInCalibration;     // 行为室内场景标定，主要应用IAS等 
        [FieldOffsetAttribute(0)]
        public NET_DVR_ITS_CALIBRATION struITSCalibration;
         * */
    }


}
