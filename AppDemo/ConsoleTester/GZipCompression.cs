using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.IO;
using System.Linq;
using System.Text;

namespace System.Data.GZip
{
    internal class GZipCompression
    {
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
                var sdkPath = Path.Combine(baseDir, sdkDir);
                var fileList = new List<string>()
                {
                    Path.Combine("x64","ALBCtrlDll.dll"),

                    Path.Combine("x86","ALBCtrlDll.dll"),
                };
                var sdkMap = fileList.ToDictionary(s => Path.Combine(sdkPath, s), s => s);
                var fileDat = Path.Combine(sdkPath, $"{sdkDir.ToLower()}.cswin");
                SdkFileComponent.FileGZipCompressSDK(sdkMap, fileDat);
                res.Add(new FileInfo(fileDat));
            }
            // 德亚车牌识别
            {
                var sdkDir = "DeYaIceIpcSDK";
                var sdkPath = Path.Combine(baseDir, sdkDir);
                var fileList = new List<string>()
                {
                    Path.Combine("x64","ice_ipcsdk.dll"),
                    Path.Combine("x64","avutil-52.dll"),
                    Path.Combine("x64","draw.dll"),
                    Path.Combine("x64","hi_h264dec_w64.dll"),
                    Path.Combine("x64","ice_p2p.dll"),
                    Path.Combine("x64","Packet.dll"),
                    Path.Combine("x64","swscale-2.dll"),
                    Path.Combine("x64","wpcap.dll"),
                    Path.Combine("x64","zlibwapi.dll"),

                    Path.Combine("x86","ice_ipcsdk.dll"),
                    Path.Combine("x86","avutil-52.dll"),
                    Path.Combine("x86","draw.dll"),
                    Path.Combine("x86","hi_h264dec_w.dll"),
                    Path.Combine("x86","ice_p2p.dll"),
                    Path.Combine("x86","Packet.dll"),
                    Path.Combine("x86","swscale-2.dll"),
                    Path.Combine("x86","wpcap.dll"),
                    Path.Combine("x86","zlibwapi.dll"),
                };
                var sdkMap = fileList.ToDictionary(s => Path.Combine(sdkPath, s), s => s);
                var fileDat = Path.Combine(sdkPath, $"{sdkDir.ToLower()}.cswin");
                SdkFileComponent.FileGZipCompressSDK(sdkMap, fileDat);
                res.Add(new FileInfo(fileDat));

                SdkFileComponent.FileGZipDecompressSDK(fileDat, Path.GetFullPath("Test"), null);
            }
            return res.ToArray();
        }
    }
}
