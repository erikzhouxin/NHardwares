using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CCD_CFG
    {
        public uint dwSize;//结构长度
        public byte byBlc;/*背光补偿0-off; 1-on*/
        public byte byBlcMode;/*blc类型0-自定义1-上；2-下；3-左；4-右；5-中；注：此项在blc为 on 时才起效*/
        public byte byAwb;/*自动白平衡0-自动1; 1-自动2; 2-自动控制*/
        public byte byAgc;/*自动增益0-关; 1-低; 2-中; 3-高*/
        public byte byDayNight;/*日夜转换；0 彩色；1黑白；2自动*/
        public byte byMirror;/*镜像0-关;1-左右;2-上下;3-中心*/
        public byte byShutter;/*快门0-自动; 1-1/25; 2-1/50; 3-1/100; 4-1/250;5-1/500; 6-1/1k ;7-1/2k; 8-1/4k; 9-1/10k; 10-1/100k;*/
        public byte byIrCutTime;/*IRCUT切换时间，5, 10, 15, 20, 25*/
        public byte byLensType;/*镜头类型0-电子光圈; 1-自动光圈*/
        public byte byEnVideoTrig;/*视频触发使能：1-支持；0-不支持。视频触发模式下视频快门速度按照byShutter速度，抓拍图片的快门速度按照byCapShutter速度，抓拍完成后会自动调节回视频模式*/
        public byte byCapShutter;/*抓拍时的快门速度，1-1/25; 2-1/50; 3-1/100; 4-1/250;5-1/500; 6-1/1k ;7-1/2k; 8-1/4k; 9-1/10k; 10-1/100k; 11-1/150; 12-1/200*/
        public byte byEnRecognise;/*1-支持识别；0-不支持识别*/
    }
}
