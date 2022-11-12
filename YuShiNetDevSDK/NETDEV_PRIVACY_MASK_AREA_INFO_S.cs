using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
 * @struct tagAreaInfo
 * @brief  Definition of area configuration structure 
 * @attention
 */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PRIVACY_MASK_AREA_INFO_S
    {
        public Int32 bIsEanbled;           /* Enable or not. */
        public Int32 dwTopLeftX;           /* X [0, 10000]  Upper left corner X [0, 10000]  */
        public Int32 dwTopLeftY;           /* Y [0, 10000]  Upper left corner Y [0, 10000]  */
        public Int32 dwBottomRightX;       /* X [0, 10000]  Lower right corner x [0, 10000] */
        public Int32 dwBottomRightY;       /* Y [0, 10000]  Lower right corner y [0, 10000] */
        public Int32 dwIndex;              /* Index. */
    }

    //    [StructLayout(LayoutKind.Sequential)]
    //    public struct NETDEV_PRIVACY_MASK_AREA_INFO_S
    //{
    //        public Int32   bIsEanbled;           /* Enable or not. */
    //        public Int32   dwTopLeftX;           /* X [0, 10000]  Upper left corner X [0, 10000]  */
    //        public Int32   dwTopLeftY;           /* Y [0, 10000]  Upper left corner Y [0, 10000]  */
    //        public Int32   dwBottomRightX;       /* X [0, 10000]  Lower right corner x [0, 10000] */
    //        public Int32   dwBottomRightY;       /* Y [0, 10000]  Lower right corner y [0, 10000] */
    //        public Int32   dwIndex;              /* Index */
    //};

}
