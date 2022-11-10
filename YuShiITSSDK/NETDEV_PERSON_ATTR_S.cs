using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVPersonAttr
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_ATTR_S
    {
        public UInt32 udwGender;
        public UInt32 udwAgeRange;
        public UInt32 udwSleevesLength;
        public UInt32 udwCoatColor;
        public UInt32 udwTrousersLength;
        public UInt32 udwTrousersColor;
        public UInt32 udwBodyToward;
        public UInt32 udwShoesTubeLength;
        public UInt32 udwHairLength;
        public UInt32 udwBagFlag;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
