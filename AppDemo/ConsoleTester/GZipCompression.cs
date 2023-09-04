using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Data.Extter;
using System.Data.NHInterfaces;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace System.Data.GZip
{
    internal class GZipCompression
    {
        /******************SDK创建模板代码块*********************************** 
        {
            var sdkDir = "Test";
            var fileList = new List<string>()
            {
            };
            res.Add(new FileInfo(CompressSDK(baseDir, sdkDir, fileList)));
        }
        ******************SDK创建模板代码块**********************************/
        /// <summary>
        /// 创建SDK
        /// </summary>
        /// <returns></returns>
        public static FileInfo[] CreateSdks()
        {
            var baseDir = Path.GetFullPath("../../../../../AppBeans/");
            var res = new List<FileInfo>();
            // 德亚道闸
            {
                var sdkDir = "DeYaAlbCtrlSDK";
                var fileList = new List<string>()
                {
                    Path.Combine("x64", "ALBCtrlDll.dll"),

                    Path.Combine("x86", "ALBCtrlDll.dll"),
                };
                res.Add(new FileInfo(CompressSDK(baseDir, sdkDir, fileList)));
            }
            // 德亚道闸
            {
                var sdkDir = "DeYaLpnrSDK";
                var fileList = new List<string>()
                {
                    Path.Combine("x64", "RWLPNRAPI.dll"),
                    Path.Combine("x86", "RWLPNRAPI.dll"),
                };
                res.Add(new FileInfo(CompressSDK(baseDir, sdkDir, fileList)));
            }
            // 德亚车牌识别
            {
                var sdkDir = "DeYaIceIpcSDK";
                var fileList = new List<string>()
                {
                    Path.Combine("x64", "ice_ipcsdk.dll"),
                    Path.Combine("x64", "avutil-52.dll"),
                    Path.Combine("x64", "draw.dll"),
                    Path.Combine("x64", "hi_h264dec_w64.dll"),
                    Path.Combine("x64", "ice_p2p.dll"),
                    Path.Combine("x64", "Packet.dll"),
                    Path.Combine("x64", "swscale-2.dll"),
                    Path.Combine("x64", "wpcap.dll"),
                    Path.Combine("x64", "zlibwapi.dll"),

                    Path.Combine("x86", "ice_ipcsdk.dll"),
                    Path.Combine("x86", "avutil-52.dll"),
                    Path.Combine("x86", "draw.dll"),
                    Path.Combine("x86", "hi_h264dec_w.dll"),
                    Path.Combine("x86", "ice_p2p.dll"),
                    Path.Combine("x86", "Packet.dll"),
                    Path.Combine("x86", "swscale-2.dll"),
                    Path.Combine("x86", "wpcap.dll"),
                    Path.Combine("x86", "zlibwapi.dll"),
                };
                res.Add(new FileInfo(CompressSDK(baseDir, sdkDir, fileList)));
            }
            // 臻识科技车牌识别
            {
                var sdkDir = "VzClientSDK";
                var fileList = new List<string>()
                {
                    Path.Combine("x64", "VzLPRSDK.dll"),
                    Path.Combine("x64", "avcodec-57.dll"),
                    Path.Combine("x64", "avformat-57.dll"),
                    Path.Combine("x64", "avutil-54.dll"),
                    Path.Combine("x64", "avutil-55.dll"),
                    Path.Combine("x64", "libwinpthread-1.dll"),
                    Path.Combine("x64", "swscale-3.dll"),
                    Path.Combine("x64", "VzAudioDataPlayer.dll"),
                    Path.Combine("x64", "VzDrawsLib.dll"),
                    Path.Combine("x64", "VzPlayer2.dll"),
                    Path.Combine("x64", "VzStreamClient.dll"),

                    Path.Combine("x86", "VzLPRSDK.dll"),
                    Path.Combine("x86", "avcodec-57.dll"),
                    Path.Combine("x86", "avformat-57.dll"),
                    Path.Combine("x86", "avutil-55.dll"),
                    Path.Combine("x86", "msvcr90.dll"),
                    Path.Combine("x86", "VzAudioDataPlayer.dll"),
                    Path.Combine("x86", "VzDrawsLib.dll"),
                    Path.Combine("x86", "VzPlayer2.dll"),
                    Path.Combine("x86", "VzStreamClient.dll"),
                };
                res.Add(new FileInfo(CompressSDK(baseDir, sdkDir, fileList)));
            }
            // 微光二维码识别
            {
                var sdkDir = "WeiGuangCodeBarSDK";
                var fileList = new List<string>()
                {
                    Path.Combine("x64", "vbar.dll"),
                    Path.Combine("x86", "vbar.dll"),
                };
                res.Add(new FileInfo(CompressSDK(baseDir, sdkDir, fileList)));
            }
            // 海康威视监控
            {
                var sdkDir = "HikHCNetSDK";
                var fileList = new List<string>()
                {
                    Path.Combine("x64", "HCNetSDK.dll"),
                    Path.Combine("x64", "PlayCtrl.dll"),
                    Path.Combine("x64", "AudioRender.dll"),
                    Path.Combine("x64", "GdiPlus.dll"),
                    Path.Combine("x64", "HCCore.dll"),
                    Path.Combine("x64", "hlog.dll"),
                    Path.Combine("x64", "HmMerge.dll"),
                    Path.Combine("x64", "hpr.dll"),
                    Path.Combine("x64", "HXVA.dll"),
                    Path.Combine("x64", "libcrypto-1_1-x64.dll"),
                    Path.Combine("x64", "libmmd.dll"),
                    Path.Combine("x64", "libssl-1_1-x64.dll"),
                    Path.Combine("x64", "MP_Render.dll"),
                    Path.Combine("x64", "NPQos.dll"),
                    Path.Combine("x64", "OpenAL32.dll"),
                    Path.Combine("x64", "SuperRender.dll"),
                    Path.Combine("x64", "YUVProcess.dll"),
                    Path.Combine("x64", "zlib1.dll"),
                    Path.Combine("x64", "HCNetSDKCom\\AnalyzeData.dll"),
                    Path.Combine("x64", "HCNetSDKCom\\AudioRender.dll"),
                    Path.Combine("x64", "HCNetSDKCom\\HCAlarm.dll"),
                    Path.Combine("x64", "HCNetSDKCom\\HCCoreDevCfg.dll"),
                    Path.Combine("x64", "HCNetSDKCom\\HCDisplay.dll"),
                    Path.Combine("x64", "HCNetSDKCom\\HCGeneralCfgMgr.dll"),
                    Path.Combine("x64", "HCNetSDKCom\\HCIndustry.dll"),
                    Path.Combine("x64", "HCNetSDKCom\\HCPlayBack.dll"),
                    Path.Combine("x64", "HCNetSDKCom\\HCPreview.dll"),
                    Path.Combine("x64", "HCNetSDKCom\\HCVoiceTalk.dll"),
                    Path.Combine("x64", "HCNetSDKCom\\libiconv2.dll"),
                    Path.Combine("x64", "HCNetSDKCom\\OpenAL32.dll"),
                    Path.Combine("x64", "HCNetSDKCom\\StreamTransClient.dll"),
                    Path.Combine("x64", "HCNetSDKCom\\SystemTransform.dll"),

                    Path.Combine("x86", "HCNetSDK.dll"),
                    Path.Combine("x86", "PlayCtrl.dll"),
                    Path.Combine("x86", "AudioRender.dll"),
                    Path.Combine("x86", "gdiplus.dll"),
                    Path.Combine("x86", "HCCore.dll"),
                    Path.Combine("x86", "hlog.dll"),
                    Path.Combine("x86", "HmMerge.dll"),
                    Path.Combine("x86", "hpr.dll"),
                    Path.Combine("x86", "HXVA.dll"),
                    Path.Combine("x86", "libcrypto-1_1.dll"),
                    Path.Combine("x86", "libssl-1_1.dll"),
                    Path.Combine("x86", "MP_Render.dll"),
                    Path.Combine("x86", "MP_VIE.dll"),
                    Path.Combine("x86", "NPQos.dll"),
                    Path.Combine("x86", "OpenAL32.dll"),
                    Path.Combine("x86", "SuperRender.dll"),
                    Path.Combine("x86", "YUVProcess.dll"),
                    Path.Combine("x86", "zlib1.dll"),
                    Path.Combine("x86", "HCNetSDKCom\\AnalyzeData.dll"),
                    Path.Combine("x86", "HCNetSDKCom\\AudioIntercom.dll"),
                    Path.Combine("x86", "HCNetSDKCom\\AudioRender.dll"),
                    Path.Combine("x86", "HCNetSDKCom\\HCAlarm.dll"),
                    Path.Combine("x86", "HCNetSDKCom\\HCCoreDevCfg.dll"),
                    Path.Combine("x86", "HCNetSDKCom\\HCDisplay.dll"),
                    Path.Combine("x86", "HCNetSDKCom\\HCGeneralCfgMgr.dll"),
                    Path.Combine("x86", "HCNetSDKCom\\HCIndustry.dll"),
                    Path.Combine("x86", "HCNetSDKCom\\HCPlayBack.dll"),
                    Path.Combine("x86", "HCNetSDKCom\\HCPreview.dll"),
                    Path.Combine("x86", "HCNetSDKCom\\HCVoiceTalk.dll"),
                    Path.Combine("x86", "HCNetSDKCom\\libiconv2.dll"),
                    Path.Combine("x86", "HCNetSDKCom\\msvcr90.dll"),
                    Path.Combine("x86", "HCNetSDKCom\\OpenAL32.dll"),
                    Path.Combine("x86", "HCNetSDKCom\\StreamTransClient.dll"),
                    Path.Combine("x86", "HCNetSDKCom\\SystemTransform.dll"),
                };
                res.Add(new FileInfo(CompressSDK(baseDir, sdkDir, fileList)));
            }
            // 宇视监控视频
            {
                var sdkDir = "YuShiITSSDK";
                var fileList = new List<string>()
                {
                    Path.Combine("x64", "NetDEVSDK.dll"),
                    Path.Combine("x64", "avutil_audio_aac.dll"),
                    Path.Combine("x64", "dsp_audio_aac.dll"),
                    Path.Combine("x64", "dsp_audio_aac_enc.dll"),
                    Path.Combine("x64", "dsp_audio_g711.dll"),
                    Path.Combine("x64", "dsp_h264_gpu_dec.dll"),
                    Path.Combine("x64", "dsp_video_h264_1.dll"),
                    Path.Combine("x64", "dsp_video_mjpeg.dll"),
                    Path.Combine("x64", "FaceDetection.dll"),
                    Path.Combine("x64", "fisheye_rectify.dll"),
                    Path.Combine("x64", "iconv.dll"),
                    Path.Combine("x64", "ISF_ImageProc.dll"),
                    Path.Combine("x64", "libcloud.dll"),
                    Path.Combine("x64", "libcloudclient.dll"),
                    Path.Combine("x64", "libcloudhttpcurl.dll"),
                    Path.Combine("x64", "libcurl.dll"),
                    Path.Combine("x64", "libstun.dll"),
                    Path.Combine("x64", "libwinpthread-1.dll"),
                    Path.Combine("x64", "mfc90.dll"),
                    Path.Combine("x64", "mfc90u.dll"),
                    Path.Combine("x64", "mfcm90.dll"),
                    Path.Combine("x64", "mfcm90u.dll"),
                    Path.Combine("x64", "msvcm90.dll"),
                    Path.Combine("x64", "msvcp90.dll"),
                    Path.Combine("x64", "msvcp120.dll"),
                    Path.Combine("x64", "msvcr90.dll"),
                    Path.Combine("x64", "msvcr120.dll"),
                    Path.Combine("x64", "mxml1.dll"),
                    Path.Combine("x64", "NDAO.dll"),
                    Path.Combine("x64", "NDPlayer.dll"),
                    Path.Combine("x64", "NDRM_Module.dll"),
                    Path.Combine("x64", "NDRSA.dll"),
                    Path.Combine("x64", "NDRtmp.dll"),
                    Path.Combine("x64", "NetCloudSDK.dll"),
                    Path.Combine("x64", "NetDEVDiscovery.dll"),
                    Path.Combine("x64", "nvidia_gpu_dec.dll"),
                    Path.Combine("x64", "pthreadVC2.dll"),
                    Path.Combine("x64", "RSA.dll"),

                    Path.Combine("x86", "NetDEVSDK.dll"),
                    Path.Combine("x86", "dsp_audio_aac.dll"),
                    Path.Combine("x86", "dsp_audio_aac_enc.dll"),
                    Path.Combine("x86", "dsp_audio_g711.dll"),
                    Path.Combine("x86", "dsp_h264_gpu_dec.dll"),
                    Path.Combine("x86", "dsp_video_h264_1.dll"),
                    Path.Combine("x86", "dsp_video_mjpeg.dll"),
                    Path.Combine("x86", "FaceDetection.dll"),
                    Path.Combine("x86", "fisheye_rectify.dll"),
                    Path.Combine("x86", "HW_H265dec_Win32D.dll"),
                    Path.Combine("x86", "iconv.dll"),
                    Path.Combine("x86", "ISF_ImageProc.dll"),
                    Path.Combine("x86", "libcloud.dll"),
                    Path.Combine("x86", "libcloudclient.dll"),
                    Path.Combine("x86", "libcloudhttpcurl.dll"),
                    Path.Combine("x86", "libcurl.dll"),
                    Path.Combine("x86", "libstun.dll"),
                    Path.Combine("x86", "mfc90.dll"),
                    Path.Combine("x86", "mfc90u.dll"),
                    Path.Combine("x86", "mfcm90.dll"),
                    Path.Combine("x86", "mfcm90u.dll"),
                    Path.Combine("x86", "msvcm90.dll"),
                    Path.Combine("x86", "msvcp90.dll"),
                    Path.Combine("x86", "msvcp120.dll"),
                    Path.Combine("x86", "msvcr90.dll"),
                    Path.Combine("x86", "msvcr120.dll"),
                    Path.Combine("x86", "mxml1.dll"),
                    Path.Combine("x86", "NDAO.dll"),
                    Path.Combine("x86", "NDPlayer.dll"),
                    Path.Combine("x86", "NDRM_Module.dll"),
                    Path.Combine("x86", "NDRSA.dll"),
                    Path.Combine("x86", "NDRtmp.dll"),
                    Path.Combine("x86", "NetCloudSDK.dll"),
                    Path.Combine("x86", "NetDEVDiscovery.dll"),
                    Path.Combine("x86", "nvidia_gpu_dec.dll"),
                    Path.Combine("x86", "pthreadGC2.dll"),
                    Path.Combine("x86", "pthreadVC2.dll"),
                    Path.Combine("x86", "RSA.dll"),
                };
                res.Add(new FileInfo(CompressSDK(baseDir, sdkDir, fileList)));
            }
            // 宇视网络监控
            {
                var sdkDir = "YuShiNetDevSDK";
                var fileList = new List<string>()
                {
                    Path.Combine("x64", "NetDEVSDK.dll"),
                    Path.Combine("x64", "avutil_audio_aac.dll"),
                    Path.Combine("x64", "dsp_audio_aac.dll"),
                    Path.Combine("x64", "dsp_audio_aac_enc.dll"),
                    Path.Combine("x64", "dsp_audio_g711.dll"),
                    Path.Combine("x64", "dsp_h264_gpu_dec.dll"),
                    Path.Combine("x64", "dsp_video_h264_1.dll"),
                    Path.Combine("x64", "dsp_video_mjpeg.dll"),
                    Path.Combine("x64", "fisheye_rectify.dll"),
                    Path.Combine("x64", "libcloud.dll"),
                    Path.Combine("x64", "libcloudclient.dll"),
                    Path.Combine("x64", "libcloudhttpcurl.dll"),
                    Path.Combine("x64", "libcurl.dll"),
                    Path.Combine("x64", "libstun.dll"),
                    Path.Combine("x64", "libwinpthread-1.dll"),
                    Path.Combine("x64", "mfc90.dll"),
                    Path.Combine("x64", "mfc90u.dll"),
                    Path.Combine("x64", "mfcm90.dll"),
                    Path.Combine("x64", "mfcm90u.dll"),
                    Path.Combine("x64", "msvcm90.dll"),
                    Path.Combine("x64", "msvcp90.dll"),
                    Path.Combine("x64", "msvcp120.dll"),
                    Path.Combine("x64", "msvcr90.dll"),
                    Path.Combine("x64", "msvcr120.dll"),
                    Path.Combine("x64", "mxml1.dll"),
                    Path.Combine("x64", "NDAO.dll"),
                    Path.Combine("x64", "NDFace.dll"),
                    Path.Combine("x64", "NDPlayer.dll"),
                    Path.Combine("x64", "NDRM_Module.dll"),
                    Path.Combine("x64", "NDRSA.dll"),
                    Path.Combine("x64", "NDRtmp.dll"),
                    Path.Combine("x64", "NetCloudSDK.dll"),
                    Path.Combine("x64", "NetDEVDiscovery.dll"),
                    Path.Combine("x64", "nvidia_gpu_dec.dll"),
                    Path.Combine("x64", "pthreadVC2.dll"),
                    Path.Combine("x64", "RSA.dll"),

                    Path.Combine("x86", "NetDEVSDK.dll"),
                    Path.Combine("x86", "dsp_audio_aac.dll"),
                    Path.Combine("x86", "dsp_audio_aac_enc.dll"),
                    Path.Combine("x86", "dsp_audio_g711.dll"),
                    Path.Combine("x86", "dsp_h264_gpu_dec.dll"),
                    Path.Combine("x86", "dsp_video_h264_1.dll"),
                    Path.Combine("x86", "dsp_video_h265_32.dll"),
                    Path.Combine("x86", "dsp_video_mjpeg.dll"),
                    Path.Combine("x86", "fisheye_rectify.dll"),
                    Path.Combine("x86", "libcloud.dll"),
                    Path.Combine("x86", "libcloudclient.dll"),
                    Path.Combine("x86", "libcloudhttpcurl.dll"),
                    Path.Combine("x86", "libcurl.dll"),
                    Path.Combine("x86", "libstun.dll"),
                    Path.Combine("x86", "mfc90.dll"),
                    Path.Combine("x86", "mfc90u.dll"),
                    Path.Combine("x86", "mfcm90.dll"),
                    Path.Combine("x86", "mfcm90u.dll"),
                    Path.Combine("x86", "msvcm90.dll"),
                    Path.Combine("x86", "msvcp90.dll"),
                    Path.Combine("x86", "msvcp120.dll"),
                    Path.Combine("x86", "msvcr90.dll"),
                    Path.Combine("x86", "msvcr120.dll"),
                    Path.Combine("x86", "mxml1.dll"),
                    Path.Combine("x86", "NDAO.dll"),
                    Path.Combine("x86", "NDFace.dll"),
                    Path.Combine("x86", "NDPlayer.dll"),
                    Path.Combine("x86", "NDRM_Module.dll"),
                    Path.Combine("x86", "NDRSA.dll"),
                    Path.Combine("x86", "NDRtmp.dll"),
                    Path.Combine("x86", "NetCloudSDK.dll"),
                    Path.Combine("x86", "NetDEVDiscovery.dll"),
                    Path.Combine("x86", "nvidia_gpu_dec.dll"),
                    Path.Combine("x86", "pthreadGC2.dll"),
                    Path.Combine("x86", "pthreadVC2.dll"),
                    Path.Combine("x86", "RSA.dll"),
                };
                res.Add(new FileInfo(CompressSDK(baseDir, sdkDir, fileList)));
            }
            // 华大hd100
            {
                var sdkDir = "HDSSSESDK";
                var fileList = new List<string>()
                {
                    Path.Combine("x86", "HDSSSEEXE.exe"),
                    Path.Combine("x86", "BmpToJpg.dll"),
                    Path.Combine("x86", "HDSSSE32.dll"),
                    Path.Combine("x86", "UnPack.dll"),
                };
                res.Add(new FileInfo(CompressSDK(baseDir, sdkDir, fileList)));
            }
            // oledb odbc旧版访问
            {
                var sdkDir = "EDBODBCSDK";
                var fileList = new List<string>()
                {
                    Path.Combine("x86","EDBODBCEXE.exe"),
                };
                res.Add(new FileInfo(CompressSDK(baseDir, sdkDir, fileList)));
            }
            // 康美广播音箱
            {
                var sdkDir = "KangMeiIPGBSDK";
                var fileList = new List<string>()
                {
                    Path.Combine("x64","IPGBNET.dll"),
                    Path.Combine("x64","IPGBNETPush.dll"),
                    Path.Combine("x64","IPGBNETSDK.dll"),
                    Path.Combine("x64","CtlAudioDrv.dll"),
                    Path.Combine("x64","IPGBPushStream.dll"),
                    Path.Combine("x64","lame_enc_dll.dll"),
                    Path.Combine("x64","libmp3lame.dll"),
                    Path.Combine("x64","mfc100.dll"),
                    Path.Combine("x64","mfc100u.dll"),
                    Path.Combine("x64","msvcp100.dll"),
                    Path.Combine("x64","msvcr100.dll"),
                    Path.Combine("x64","zlibwapi.dll"),

                    Path.Combine("x86","IPGBNET.dll"),
                    Path.Combine("x86","IPGBNETPush.dll"),
                    Path.Combine("x86","IPGBNETSDK.dll"),
                    Path.Combine("x86","CtlAudioDrv.dll"),
                    Path.Combine("x86","IPGBPushStream.dll"),
                    Path.Combine("x86","lame_enc_dll.dll"),
                    Path.Combine("x86","libmp3lame.dll"),
                    Path.Combine("x86","mfc100.dll"),
                    Path.Combine("x86","mfc100u.dll"),
                    Path.Combine("x86","msvcp100.dll"),
                    Path.Combine("x86","msvcr100.dll"),
                    Path.Combine("x86","zlibwapi.dll"),
                };
                res.Add(new FileInfo(CompressSDK(baseDir, sdkDir, fileList)));
            }
            // 仰邦科技LED
            {
                var sdkDir = "OnbonLedBxSDK";
                var fileList = new List<string>()
                {
                    Path.Combine("x64", "bx_sdk_dual.dll"),
                    Path.Combine("x64", "bx_sdk_dual_server.dll"),
                    Path.Combine("x64", "cairo-1.14.6.dll"),
                    Path.Combine("x64", "freetype265.dll"),
                    Path.Combine("x64", "libpng16.dll"),
                    Path.Combine("x64", "pixman-0.34.0.dll"),
                    Path.Combine("x64", "zlibwapi.dll"),

                    Path.Combine("x86", "bx_sdk_dual.dll"),
                    Path.Combine("x86", "bx_sdk_dual_server.dll"),
                    Path.Combine("x86", "cairo-1.14.6.dll"),
                    Path.Combine("x86", "freetype.dll"),
                    Path.Combine("x86", "freetype265.dll"),
                    Path.Combine("x86", "libpng16.dll"),
                    Path.Combine("x86", "zlibwapi.dll"),
                };
                res.Add(new FileInfo(CompressSDK(baseDir, sdkDir, fileList)));
            }
            return res.ToArray();
        }

        private static string CompressSDK(string baseDir, string sdkDir, List<string> fileList)
        {
            var sdkPath = Path.Combine(baseDir, sdkDir);
            var sdkMap = fileList.ToDictionary(s => s, s => Path.Combine(sdkPath, s));
            var fileDat = Path.Combine(sdkPath, $"{sdkDir.ToLower()}.cswin");
            SdkFileComponent.FileZipCompress(sdkMap, fileDat);
            return fileDat;
        }
    }
}
