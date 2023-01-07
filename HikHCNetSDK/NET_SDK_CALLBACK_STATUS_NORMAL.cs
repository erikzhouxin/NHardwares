namespace System.Data.HikHCNetSDK
{
    // Long config status value
    public enum NET_SDK_CALLBACK_STATUS_NORMAL
    {
        NET_SDK_CALLBACK_STATUS_SUCCESS = 1000,        //成功
        NET_SDK_CALLBACK_STATUS_PROCESSING,            //处理中
        NET_SDK_CALLBACK_STATUS_FAILED,                //失败
        NET_SDK_CALLBACK_STATUS_EXCEPTION,             //异常
        NET_SDK_CALLBACK_STATUS_LANGUAGE_MISMATCH,     //语言不匹配
        NET_SDK_CALLBACK_STATUS_DEV_TYPE_MISMATCH,     //设备类型不匹配
        NET_DVR_CALLBACK_STATUS_SEND_WAIT             //发送等待
    }
}
