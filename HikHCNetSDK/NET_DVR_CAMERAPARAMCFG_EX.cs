using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //前端参数配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CAMERAPARAMCFG_EX
    {
        public uint dwSize;
        public NET_DVR_VIDEOEFFECT struVideoEffect;/*亮度、对比度、饱和度、锐度、色调配置*/
        public NET_DVR_GAIN struGain;/*自动增益*/
        public NET_DVR_WHITEBALANCE struWhiteBalance;/*白平衡*/
        public NET_DVR_EXPOSURE struExposure; /*曝光控制*/
        public NET_DVR_GAMMACORRECT struGammaCorrect;/*Gamma校正*/
        public NET_DVR_WDR struWdr;/*宽动态*/
        public NET_DVR_DAYNIGHT struDayNight;/*日夜转换*/
        public NET_DVR_BACKLIGHT struBackLight;/*背光补偿*/
        public NET_DVR_NOISEREMOVE struNoiseRemove;/*数字降噪*/
        public byte byPowerLineFrequencyMode; /*0-50HZ; 1-60HZ*/
        public byte byIrisMode; /*0-自动光圈 1-手动光圈, 2-P-Iris1*/
        public byte byMirror;  /* 镜像：0 off，1- leftright，2- updown，3-center */
        public byte byDigitalZoom;  /*数字缩放:0 dsibale  1 enable*/
        public byte byDeadPixelDetect;   /*坏点检测,0 dsibale  1 enable*/
        public byte byBlackPwl;/*黑电平补偿 ,  0-255*/
        public byte byEptzGate;// EPTZ开关变量:0-不启用电子云台，1-启用电子云台
        public byte byLocalOutputGate;//本地输出开关变量0-本地输出关闭1-本地BNC输出打开 2-HDMI输出关闭  
                                      //20-HDMI_720P50输出开
                                      //21-HDMI_720P60输出开
                                      //22-HDMI_1080I60输出开
                                      //23-HDMI_1080I50输出开
                                      //24-HDMI_1080P24输出开
                                      //25-HDMI_1080P25输出开
                                      //26-HDMI_1080P30输出开
                                      //27-HDMI_1080P50输出开
                                      //28-HDMI_1080P60输出开
        public byte byCoderOutputMode;//编码器fpga输出模式0直通3像素搬家
        public byte byLineCoding; //是否开启行编码：0-否，1-是
        public byte byDimmerMode; //调光模式：0-半自动，1-自动
        public byte byPaletteMode; //调色板：0-白热，1-黑热，2-调色板2，…，8-调色板8
        public byte byEnhancedMode; //增强方式（探测物体周边）：0-不增强，1-1，2-2，3-3，4-4
        public byte byDynamicContrastEN;    //动态对比度增强 0-1
        public byte byDynamicContrast;    //动态对比度 0-100
        public byte byJPEGQuality;    //JPEG图像质量 0-100
        public NET_DVR_CMOSMODECFG struCmosModeCfg;//CMOS模式下前端参数配置，镜头模式从能力集获取
        public byte byFilterSwitch; //滤波开关：0-不启用，1-启用
        public byte byFocusSpeed; //镜头调焦速度：0-10
        public byte byAutoCompensationInterval; //定时自动快门补偿：1-120，单位：分钟
        public byte bySceneMode;  //场景模式：0-室外，1-室内，2-默认，3-弱光
        public NET_DVR_DEFOGCFG struDefogCfg;//透雾参数
        public NET_DVR_ELECTRONICSTABILIZATION struElectronicStabilization;//电子防抖
        public NET_DVR_CORRIDOR_MODE_CCD struCorridorMode;//走廊模式
        public byte byExposureSegmentEnable; //0~不启用,1~启用  曝光时间和增益呈阶梯状调整，比如曝光往上调整时，先提高曝光时间到中间值，然后提高增益到中间值，再提高曝光到最大值，最后提高增益到最大值
        public byte byBrightCompensate;//亮度增强 [0~100]

        /*0-关闭、1-640*480@25fps、2-640*480@30ps、3-704*576@25fps、4-704*480@30fps、5-1280*720@25fps、6-1280*720@30fps、
         * 7-1280*720@50fps、8-1280*720@60fps、9-1280*960@15fps、10-1280*960@25fps、11-1280*960@30fps、
         * 12-1280*1024@25fps、13--1280*1024@30fps、14-1600*900@15fps、15-1600*1200@15fps、16-1920*1080@15fps、
         * 17-1920*1080@25fps、18-1920*1080@30fps、19-1920*1080@50fps、20-1920*1080@60fps、21-2048*1536@15fps、22-2048*1536@20fps、
         * 23-2048*1536@24fps、24-2048*1536@25fps、25-2048*1536@30fps、26-2560*2048@25fps、27-2560*2048@30fps、
         * 28-2560*1920@7.5fps、29-3072*2048@25fps、30-3072*2048@30fps、31-2048*1536@12.5、32-2560*1920@6.25、
         * 33-1600*1200@25、34-1600*1200@30、35-1600*1200@12.5、36-1600*900@12.5、37-1600@900@15、38-800*600@25、39-800*600@30*/
        public byte byCaptureModeN; //视频输入模式（N制）
        public byte byCaptureModeP; //视频输入模式（P制）
        public NET_DVR_SMARTIR_PARAM struSmartIRParam; //红外放过爆配置信息
        public NET_DVR_PIRIS_PARAM struPIrisParam;//PIris配置信息对应byIrisMode字段从2-PIris1开始生效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 296, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
    }



}
