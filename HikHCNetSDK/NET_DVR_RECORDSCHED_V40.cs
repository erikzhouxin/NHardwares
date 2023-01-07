using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //时间段录像参数配置(子结构)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_RECORDSCHED_V40
    {
        public NET_DVR_SCHEDTIME struRecordTime;
        /*录像类型，0:定时录像，1:移动侦测，2:报警录像，3:动测|报警，4:动测&报警 5:命令触发, 
        6-智能报警录像，10-PIR报警，11-无线报警，12-呼救报警，13-全部事件,14-智能交通事件, 
        15-越界侦测,16-区域入侵,17-声音异常,18-场景变更侦测,
        19-智能侦测(越界侦测|区域入侵|人脸侦测|声音异常|场景变更侦测),20－人脸侦测,21-POS录像,
        22-进入区域侦测, 23-离开区域侦测,24-徘徊侦测,25-人员聚集侦测,26-快速运动侦测,27-停车侦测,
        28-物品遗留侦测,29-物品拿取侦测,30-火点检测，31-防破坏检测,32-打架斗殴事件(司法),33-起身事件(司法), 34-瞌睡事件(司法)
        35-船只检测, 36-测温预警，37-测温报警，38-温差报警，39-离线测温报警,40-防区报警，41-紧急求助,42-业务咨询,43-起身检测,44-折线攀高,45-如厕超时，46-人脸抓拍，47-非法摆摊,48-目标抓拍,
        49-剧烈运动，50离岗检测，51-起立，52人数变化 */
        public byte byRecordType;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 31, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
