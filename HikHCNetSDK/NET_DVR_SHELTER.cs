namespace System.Data.HikHCNetSDK
{
    //遮挡区域(子结构)
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct NET_DVR_SHELTER
    {
        public ushort wHideAreaTopLeftX;/* 遮挡区域的x坐标 */
        public ushort wHideAreaTopLeftY;/* 遮挡区域的y坐标 */
        public ushort wHideAreaWidth;/* 遮挡区域的宽 */
        public ushort wHideAreaHeight;/*遮挡区域的高*/
    }
}
