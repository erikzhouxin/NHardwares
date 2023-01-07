namespace System.Data.HikHCNetSDK
{
    //智能通道类型
    public enum VCA_CHAN_ABILITY_TYPE
    {
        VCA_BEHAVIOR_BASE = 1,          //行为分析基本版
        VCA_BEHAVIOR_ADVANCE = 2,          //行为分析高级版
        VCA_BEHAVIOR_FULL = 3,          //行为分析完整版
        VCA_PLATE = 4,          //车牌能力
        VCA_ATM = 5,          //ATM能力
        VCA_PDC = 6,          //人流量统计
        VCA_ITS = 7,          //智能 交通事件
        VCA_BEHAVIOR_PRISON = 8,          //行为分析监狱版(监舍) 
        VCA_FACE_SNAP = 9,           //人脸抓拍能力
        VCA_FACE_SNAPRECOG = 10,          //人脸抓拍和识别能力
        VCA_FACE_RETRIEVAL = 11,          //人脸后检索能力
        VCA_FACE_RECOG = 12,          //人脸识别能力
        VCA_BEHAVIOR_PRISON_PERIMETER = 13, // 行为分析监狱版 (周界)
        VCA_TPS = 14,          //交通诱导
        VCA_TFS = 15,          //道路违章取证
        VCA_BEHAVIOR_FACESNAP = 16           //人脸抓拍和行为分析能力
    }

}
