namespace System.Data.HikHCNetSDK
{
    // Long config callback type
    public enum NET_SDK_CALLBACK_TYPE
    {
        NET_SDK_CALLBACK_TYPE_STATUS = 0, //回调状态值
        NET_SDK_CALLBACK_TYPE_PROGRESS,   //回调进度值 
        NET_SDK_CALLBACK_TYPE_DATA        //回调数据内容
    }
}
