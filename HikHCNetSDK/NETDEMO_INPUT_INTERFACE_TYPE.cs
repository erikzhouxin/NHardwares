namespace System.Data.HikHCNetSDK
{
    /*******************************屏幕控制*******************************/
    //屏幕输入源控制
    public enum INPUT_INTERFACE_TYPE
    {
        INTERFACE_VGA = 0,
        INTERFACE_SVIDEO, // 2046NL不支持，2046NH支持
        INTERFACE_YPBPR,
        INTERFACE_DVI,
        INTERFACE_BNC,
        INTERFACE_DVI_LOOP,//(环通) 2046NH不支持，2046NL支持
        INTERFACE_BNC_LOOP, //(环通) 2046NH不支持，2046NL.支持
        INTERFACE_HDMI,
    }
}
