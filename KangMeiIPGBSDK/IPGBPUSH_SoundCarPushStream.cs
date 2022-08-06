using System;

namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 创建本地实时声卡采集推流
    /// typedef struct  
    /// {
    ///     WORD                  EncType;//编码类型  EncType=1(高音质-mp3)、EncType=2(低延时- adpcm 22050采样)类型
    /// 	IPGBPUSH_CBSOUNDNODE  CapMixInfo;//输入声卡采集混音接口信息
    /// 	//*******************************推流服务器的信息
    /// 	WORD                  ASerSrcId;        //推流到服务器上的第三方实时流编码源通道ID(注意:创建前需要服务器告知)
    /// 	WORD                  LogType;         //0:使用IP登录;1:使用域名登陆
    /// 	WORD                  Sport;           //服务器端口
    /// 	char                  Sip[IPGBPUSH_MAX_IPLEN];//服务器IP
    /// 	char                  Sdomain[IPGBPUSH_MAX_DOMAINLEN];//服务器域名
    /// 	char                  Sdes[IPGBPUSH_MAX_DESLEN]; //推流到服务器上的第三方实时流编码源通道加密认证字节(注意:创建前需要服务器告知)
    /// }IPGBPUSH_SoundCarPushStream,LPIPGBPUSH_SoundCarPushStream;
    /// </summary>
    public struct IPGBPUSH_SoundCarPushStream
    {
        /// <summary>
        /// 编码类型  EncType=1(高音质-mp3)、EncType=2(低延时- adpcm 22050采样)类型
        /// </summary>
        public ushort EncType;
        /// <summary>
        /// 输入声卡采集混音接口信息
        /// </summary>
        public IPGBPUSH_CBSOUNDNODE CapMixInfo;
        /// <summary>
        /// 推流到服务器上的第三方实时流编码源通道ID(注意:创建前需要服务器告知)
        /// </summary>
        public ushort ASerSrcId;
        /// <summary>
        /// 0:使用IP登录;1:使用域名登陆
        /// </summary>
        public ushort LogType;
        /// <summary>
        /// 服务器端口
        /// </summary>
        public ushort Sport;
        /// <summary>
        /// 服务器IP
        /// </summary>
        public string Sip;
        /// <summary>
        /// 服务器域名
        /// </summary>
        public string Sdomain;
        /// <summary>
        /// 推流到服务器上的第三方实时流编码源通道加密认证字节(注意:创建前需要服务器告知)
        /// </summary>
        public string Sdes;
    }
    /// <summary>
    /// 创建本地实时声卡采集推流
    /// </summary>
    public class NETPUSHSDK_SoundCarPushStream
    {
        /// <summary>
        /// 编码类型  EncType=1(高音质-mp3)、EncType=2(低延时- adpcm 22050采样)类型
        /// </summary>
        public ushort EncType;
        /// <summary>
        /// 输入声卡采集混音接口信息
        /// </summary>
        public NETPUSHSDK_CBSOUNDNODE CapMixInfo;
        /// <summary>
        /// 推流到服务器上的第三方实时流编码源通道ID(注意:创建前需要服务器告知)
        /// </summary>
        public ushort ASerSrcId;
        /// <summary>
        /// 0:使用IP登录;1:使用域名登陆
        /// </summary>
        public ushort LogType;
        /// <summary>
        /// 服务器端口
        /// </summary>
        public ushort Sport;
        /// <summary>
        /// 服务器IP
        /// </summary>
        public string Sip;
        /// <summary>
        /// 服务器域名
        /// </summary>
        public string Sdomain;
        /// <summary>
        /// 推流到服务器上的第三方实时流编码源通道加密认证字节(注意:创建前需要服务器告知)
        /// </summary>
        public string Sdes;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETPUSHSDK_SoundCarPushStream(IPGBPUSH_SoundCarPushStream model)
        {
            return new NETPUSHSDK_SoundCarPushStream()
            {
                EncType = model.EncType,
                CapMixInfo = (NETPUSHSDK_CBSOUNDNODE)model.CapMixInfo,
                ASerSrcId = model.ASerSrcId,
                LogType = model.LogType,
                Sport = model.Sport,
                Sip = model.Sip,
                Sdes = model.Sdes,
                Sdomain = model.Sdomain
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBPUSH_SoundCarPushStream(NETPUSHSDK_SoundCarPushStream model)
        {
            return new IPGBPUSH_SoundCarPushStream()
            {
                EncType = model.EncType,
                CapMixInfo = (IPGBPUSH_CBSOUNDNODE)model.CapMixInfo,
                ASerSrcId = model.ASerSrcId,
                LogType = model.LogType,
                Sport = model.Sport,
                Sip = model.Sip,
                Sdes = model.Sdes,
                Sdomain = model.Sdomain
            };
        }
    }
}
