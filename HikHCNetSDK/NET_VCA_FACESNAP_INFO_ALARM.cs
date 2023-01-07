using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //人脸抓拍信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_FACESNAP_INFO_ALARM
    {
        public uint dwRelativeTime;     // 相对时标
        public uint dwAbsTime;            // 绝对时标
        public uint dwSnapFacePicID;       //抓拍人脸图ID
        public uint dwSnapFacePicLen;        //抓拍人脸子图的长度，为0表示没有图片，大于0表示有图片
        public NET_VCA_DEV_INFO struDevInfo;   //前端设备信息
        public byte byFaceScore;        //人脸评分，指人脸子图的质量的评分,0-100
        public byte bySex;//性别，0-未知，1-男，2-女
        public byte byGlasses;//是否带眼镜，0-未知，1-是，2-否
        /*
         * 识别人脸的年龄段范围[byAge-byAgeDeviation,byAge+byAgeDeviation]
         */
        public byte byAge;//年龄
        public byte byAgeDeviation;//年龄误差值
        public byte byAgeGroup;//年龄段，详见HUMAN_AGE_GROUP_ENUM，若传入0xff表示未知
        /*人脸子图图片质量评估等级，0-低等质量,1-中等质量,2-高等质量,
        该质量评估算法仅针对人脸子图单张图片,具体是通过姿态、清晰度、遮挡情况、光照情况等可影响人脸识别性能的因素综合评估的结果*/
        public byte byFacePicQuality;
        public byte byEthnic; //字段预留,暂不开放
        public uint dwUIDLen; // 上传报警的标识长度
        public IntPtr pUIDBuffer;  //标识指针
        public float fStayDuration;  //停留画面中时间(单位: 秒)
        public IntPtr pBuffer1;  //抓拍人脸子图的图片数据
    }
}
