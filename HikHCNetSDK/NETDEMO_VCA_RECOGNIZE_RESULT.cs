namespace System.Data.HikHCNetSDK
{
    //识别结果标志
    public enum VCA_RECOGNIZE_RESULT
    {
        VCA_RECOGNIZE_FAILURE = 0,//识别失败
        VCA_IMAGE_RECOGNIZE_SUCCESS,//图像识别成功
        VCA_VIDEO_RECOGNIZE_SUCCESS_OF_BEST_LICENSE,//视频识别更优结果
        VCA_VIDEO_RECOGNIZE_SUCCESS_OF_NEW_LICENSE,//视频识别到新的车牌
        VCA_VIDEO_RECOGNIZE_FINISH_OF_CUR_LICENSE,//视频识别车牌结束
    }
}
