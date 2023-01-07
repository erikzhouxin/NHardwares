namespace System.Data.HikHCNetSDK
{
    //下载状态
    public enum NET_SDK_DOWNLOAD_STATUS
    {
        NET_SDK_DOWNLOAD_STATUS_SUCCESS = 1,    //下载成功
        NET_SDK_DOWNLOAD_STATUS_PROCESSING,     //正在下载
        NET_SDK_DOWNLOAD_STATUS_FAILED,         //下载失败
        NET_SDK_DOWNLOAD_STATUS_UNKOWN_ERROR    //未知错误 
    }
}
