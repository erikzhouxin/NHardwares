using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 创建第三方实时流编码源通道信息,用于第三方实时流广播
     * typedef struct  
     * {
     * 	WORD                EncType;//编码类型 EncType=1(高音质)、EncType=2(低延时)类型
     * 	                            //当EncType=1时输入音频数据格式: MP3编码 、位速率128kb/s                       
     * 	                            //当EncType=2时输入音频数据格式: adpcm编码 22050(采样频率)，1(通道),16位(采样位数) 
     *                              //(注意每个adpcm编码块如下，且每个编码块总大小为512个字节,编码时输入PCM长为2034)  
     * 								//typedef struct dvi_adpcm_4bit_mono_blockheader_tag 
     * 								//{
     * 								//	short isamp0; 
     * 								//	unsigned char bsteptableindex; 
     * 								//	unsigned char breserved;
     * 								//}dvi_adpcm_4bit_mono_blockheader;
     * 	WORD                 ADataInputType;// 音频数据传输方式  
     * 										// 1:使用"IPGBNETSDK_FillDataToThirdRealSrcChannel"函数
     * 	                                    // 2:使用TCP协议网络传输,详细通信协议请参照SDK说明文档
     * }IPGBSDK_ThirdRealSrcINFO,LPIPGBSDK_ThirdRealSrcINFO;
     **/
    public struct IPGBSDK_ThirdRealSrcINFO
    {
        /// <summary>
        /// 编码类型 EncType=1(高音质)、EncType=2(低延时)类型
        /// 当EncType=1时输入音频数据格式: MP3编码 、位速率128kb/s 
        /// 当EncType=2时输入音频数据格式: adpcm编码 22050(采样频率)，1(通道),16位(采样位数)
        /// </summary>
        public ushort EncType;
        /// <summary>
        /// 音频数据传输方式
        /// 1:使用"IPGBNETSDK_FillDataToThirdRealSrcChannel"函数
        /// 2:使用TCP协议网络传输,详细通信协议请参照SDK说明文档
        /// </summary>
        public ushort ADataInputType;
    }
    /// <summary>
    /// 创建第三方实时流编码源通道信息,用于第三方实时流广播
    /// </summary>
    public class NETAVHSDK_ThirdRealSrcINFO
    {
        /// <summary>
        /// 编码类型 EncType=1(高音质)、EncType=2(低延时)类型
        /// 当EncType=1时输入音频数据格式: MP3编码 、位速率128kb/s 
        /// 当EncType=2时输入音频数据格式: adpcm编码 22050(采样频率)，1(通道),16位(采样位数)
        /// </summary>
        public ushort EncType;
        /// <summary>
        /// 音频数据传输方式
        /// 1:使用"IPGBNETSDK_FillDataToThirdRealSrcChannel"函数
        /// 2:使用TCP协议网络传输,详细通信协议请参照SDK说明文档
        /// </summary>
        public ushort ADataInputType;
        /// <summary>
        /// 
        /// </summary>
        public string buf;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETAVHSDK_ThirdRealSrcINFO(IPGBSDK_ThirdRealSrcINFO model)
        {
            return new NETAVHSDK_ThirdRealSrcINFO
            {
                EncType = model.EncType,
                ADataInputType = model.ADataInputType,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBSDK_ThirdRealSrcINFO(NETAVHSDK_ThirdRealSrcINFO model)
        {
            return new IPGBSDK_ThirdRealSrcINFO
            {
                EncType = model.EncType,
                ADataInputType = model.ADataInputType,
            };
        }
        /// <summary>
        /// 设置模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public NETAVHSDK_ThirdRealSrcINFO SetModel(IPGBSDK_ThirdRealSrcINFO model)
        {
            EncType = model.EncType;
            ADataInputType = model.ADataInputType;
            return this;
        }
    }
}
