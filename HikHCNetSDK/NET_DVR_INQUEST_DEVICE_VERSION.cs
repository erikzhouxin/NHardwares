using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INQUEST_DEVICE_VERSION
    {
        public byte byMainVersion;         /*基线主版本.
								   0 : 未知
								   1 : 8000审讯DVR
								       次版本: 1 : 8000HD-S
								   2 : 8100审讯DVR 
									   次版本: 1 : 审讯81SNL
											   2 : 审讯81SH
											   3 : 审讯81SFH
								   3 : 8608高清审讯机NVR 
									   次版本: 1 : DS-8608SN-SP
											   2 : DS-8608SN-ST
									  */
        public byte bySubVersion;          //基线次版本
        public byte byUpgradeVersion;      //升级版本,未升级为0
        public byte byCustomizeVersion;     //定制版本,非定制为0
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 60, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;             //保留
    }
}
