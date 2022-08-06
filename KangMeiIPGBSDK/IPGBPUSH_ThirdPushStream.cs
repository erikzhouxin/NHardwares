using System;

namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 创建本地第三方音频流，推流
    /// typedef struct  
    /// {
    ///     WORD                     EncType;//编码类型  EncType=1(高音质-mp3)、EncType=2(低延时- adpcm 22050采样)类型
    /// 	WORD                     StreamType;  //1:实时流  2:文件流(EncType只能为1,内部自动转为实时数据的流)
    /// 	WORD                     LcaFileCout;//当 EcnTYpe=1 且StreamType=2时,输入本地MP3文件
    ///     IPGBPUSH_LCA_ONEFILEINFO LcaFileInfo[IPGBPUSH_MAX_LCAFILECOUT];//文件流的MP3文件信息
    /// 	WORD                     LcaFile_loop;//文件流是否循环
    /// 	WORD                     LcaFile_PlayLen;//文件流推流时长(单元秒),为0时不控制时长，大于0时其控制逻辑高于循环
    /// 	//*******************************推流服务器的信息
    /// 	WORD                    ASerSrcId;        //推流到服务器上的第三方实时流编码源通道ID(注意:创建前需要服务器告知)
    /// 	WORD                    LogType;         //0:使用IP登录;1:使用域名登陆
    /// 	WORD                    Sport;           //服务器端口
    /// 	char                    Sip[IPGBPUSH_MAX_IPLEN];//服务器IP
    /// 	char                    Sdomain[IPGBPUSH_MAX_DOMAINLEN];//服务器域名
    /// 	char                    Sdes[IPGBPUSH_MAX_DESLEN]; //推流到服务器上的第三方实时流编码源通道加密认证字节(注意:创建前需要服务器告知)
    /// }IPGBPUSH_ThirdPushStream,LPIPGBPUSH_ThirdPushStream;
    /// </summary>
    public struct IPGBPUSH_ThirdPushStream
    {
        /// <summary>
        /// 编码类型  EncType=1(高音质-mp3)、EncType=2(低延时- adpcm 22050采样)类型
        /// </summary>
        public ushort EncType;
        /// <summary>
        /// 1:实时流  2:文件流(EncType只能为1,内部自动转为实时数据的流)
        /// </summary>
        public ushort StreamType;
        /// <summary>
        /// 当 EcnTYpe=1 且StreamType=2时,输入本地MP3文件
        /// </summary>
        public ushort LcaFileCout;
        /// <summary>
        /// 文件流的MP3文件信息
        /// </summary>
        public IPGBPUSH_LCA_ONEFILEINFO[] LcaFileInfo;
        /// <summary>
        /// 文件流是否循环
        /// </summary>
        public ushort LcaFile_loop;
        /// <summary>
        /// 文件流推流时长(单元秒),为0时不控制时长，大于0时其控制逻辑高于循环
        /// </summary>
        public ushort LcaFile_PlayLen;
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
    /// 创建本地第三方音频流，推流
    /// </summary>
    public class NETPUSHSDK_ThirdPushStream
    {
        /// <summary>
        /// 编码类型  EncType=1(高音质-mp3)、EncType=2(低延时- adpcm 22050采样)类型
        /// </summary>
        public ushort EncType;
        /// <summary>
        /// 1:实时流  2:文件流(EncType只能为1,内部自动转为实时数据的流)
        /// </summary>
        public ushort StreamType;
        /// <summary>
        /// 当 EcnTYpe=1 且StreamType=2时,输入本地MP3文件
        /// </summary>
        public ushort LcaFileCout;
        /// <summary>
        /// 文件流的MP3文件信息
        /// </summary>
        public NETPUSHSDK_LCA_ONEFILEINFO[] LcaFileInfo;
        /// <summary>
        /// 文件流是否循环
        /// </summary>
        public ushort LcaFile_loop;
        /// <summary>
        /// 文件流推流时长(单元秒),为0时不控制时长，大于0时其控制逻辑高于循环
        /// </summary>
        public ushort LcaFile_PlayLen;
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
        public static implicit operator NETPUSHSDK_ThirdPushStream(IPGBPUSH_ThirdPushStream model)
        {
            return new NETPUSHSDK_ThirdPushStream
            {
                ASerSrcId = model.ASerSrcId,
                LogType = model.LogType,
                Sport = model.Sport,
                Sip = model.Sip,
                Sdomain = model.Sdomain,
                Sdes = model.Sdes,
                EncType = model.EncType,
                StreamType = model.StreamType,
                LcaFileCout = model.LcaFileCout,
                LcaFileInfo = model.LcaFileInfo.SelectArray(s => (NETPUSHSDK_LCA_ONEFILEINFO)s),
                LcaFile_loop = model.LcaFile_loop,
                LcaFile_PlayLen = model.LcaFile_PlayLen,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBPUSH_ThirdPushStream(NETPUSHSDK_ThirdPushStream model)
        {
            return new IPGBPUSH_ThirdPushStream
            {
                ASerSrcId = model.ASerSrcId,
                LogType = model.LogType,
                Sport = model.Sport,
                Sip = model.Sip,
                Sdomain = model.Sdomain,
                Sdes = model.Sdes,
                EncType = model.EncType,
                StreamType = model.StreamType,
                LcaFileCout = model.LcaFileCout,
                LcaFileInfo = model.LcaFileInfo.SelectArray(s => (IPGBPUSH_LCA_ONEFILEINFO)s),
                LcaFile_loop = model.LcaFile_loop,
                LcaFile_PlayLen = model.LcaFile_PlayLen,
            };
        }
    }
}
