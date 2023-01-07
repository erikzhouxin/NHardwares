namespace System.Data.HikHCNetSDK
{
    //视频质量诊断检测事件
    public enum VQD_EVENT_ENUM
    {
        ENUM_VQD_EVENT_BLUR = 1,  //图像模糊
        ENUM_VQD_EVENT_LUMA = 2,  //亮度异常
        ENUM_VQD_EVENT_CHROMA = 3,  //图像偏色
        ENUM_VQD_EVENT_SNOW = 4,  //雪花干扰
        ENUM_VQD_EVENT_STREAK = 5,  //条纹干扰
        ENUM_VQD_EVENT_FREEZE = 6,  //画面冻结
        ENUM_VQD_EVENT_SIGNAL_LOSS = 7,  //信号丢失
        ENUM_VQD_EVENT_PTZ = 8,  //云台失控
        ENUM_VQD_EVENT_SCNENE_CHANGE = 9,  //场景突变
        ENUM_VQD_EVENT_VIDEO_ABNORMAL = 10, //视频异常
        ENUM_VQD_EVENT_VIDEO_BLOCK = 11, //视频遮挡
    }
}
