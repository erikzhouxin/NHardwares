namespace System.Data.HikHCNetSDK
{
    public enum VCA_DETECTION_MINOR_TYPE : uint
    {
        EVENT_VCA_TRAVERSE_PLANE = 1,        //越警侦测
        EVENT_FIELD_DETECTION,           //区域入侵侦测
        EVENT_AUDIO_INPUT_ALARM,      //音频输入异常
        EVENT_SOUND_INTENSITY_ALARM,   //声强突变侦测
        EVENT_FACE_DETECTION,             //人脸侦测
        EVENT_VIRTUAL_FOCUS_ALARM, /*虚焦侦测*/
        EVENT_SCENE_CHANGE_ALARM, /*场景变更侦测*/
        EVENT_ALL = 0xffffffff              //表示全部
    }

}
