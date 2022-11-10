using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 区域配置结构体定义 Definition of area configuration structure 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PRIVACY_MASK_AREA_INFO_S
    {
        public Int32 bIsEanbled;           /* 是否启用  Enable or not. */
        public Int32 dwTopLeftX;           /* 左上角X [0, 10000]  X [0, 10000]  Upper left corner X [0, 10000]  */
        public Int32 dwTopLeftY;           /* 左上角Y [0, 10000]  Y [0, 10000]  Upper left corner Y [0, 10000]  */
        public Int32 dwBottomRightX;       /* 右下角X [0, 10000]  X [0, 10000]  Lower right corner x [0, 10000] */
        public Int32 dwBottomRightY;       /* 右下角Y [0, 10000]  Y [0, 10000]  Lower right corner y [0, 10000] */
        public Int32 dwIndex;              /* 索引 Index. */
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
