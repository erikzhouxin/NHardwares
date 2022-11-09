using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Cryptography;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 车牌识别SDK
    /// </summary>
    public static class VzClientSdk
    {
        /// <summary>
        /// SDK文件名称
        /// </summary>
        public const String DllFileName = "VzLPRSDK.dll";
        /**可过滤的车牌识别触发类型*/
        public const int VZ_LPRC_TRIG_ENABLE_STABLE = 0x1;     /** 允许触发稳定结果 **/
        public const int VZ_LPRC_TRIG_ENABLE_VLOOP = 0x2;     /** 允许触发虚拟线圈结果 **/
        public const int VZ_LPRC_TRIG_ENABLE_IO_IN1 = 0x10;    /** 允许外部IO_IN_1触发 **/
        public const int VZ_LPRC_TRIG_ENABLE_IO_IN2 = 0x20;    /** 允许外部IO_IN_2触发 **/
        public const int VZ_LPRC_TRIG_ENABLE_IO_IN3 = 0x40;    /** 允许外部IO_IN_3触发 **/

        //车牌类型
        public const int LT_UNKNOWN = 0;   //未知车牌
        public const int LT_BLUE = 1;   //蓝牌小汽车
        public const int LT_BLACK = 2;   //黑牌小汽车
        public const int LT_YELLOW = 3;   //单排黄牌
        public const int LT_YELLOW2 = 4;   //双排黄牌（大车尾牌，农用车）
        public const int LT_POLICE = 5;   //警车车牌
        public const int LT_ARMPOL = 6;   //武警车牌
        public const int LT_INDIVI = 7;   //个性化车牌
        public const int LT_ARMY = 8;   //单排军车牌
        public const int LT_ARMY2 = 9;   //双排军车牌
        public const int LT_EMBASSY = 10;  //使馆车牌
        public const int LT_HONGKONG = 11;  //香港进出中国大陆车牌
        public const int LT_TRACTOR = 12;  //农用车牌
        public const int LT_COACH = 13;  //教练车牌
        public const int LT_MACAO = 14;  //澳门进出中国大陆车牌
        public const int LT_ARMPOL2 = 15; //双层武警车牌
        public const int LT_ARMPOL_ZONGDUI = 16;  // 武警总队车牌
        public const int LT_ARMPOL2_ZONGDUI = 17; // 双层武警总队车牌
        public const int LI_AVIATION = 18;		  //民航
        public const int LI_ENERGY = 19;       //新能源小型车
        public const int LI_NO_PLATE = 20;     //无车牌

        /**可配置的识别类型*/
        public const int VZ_LPRC_REC_BLUE = (1 << (LT_BLUE));						    /** 蓝牌车*/
        public const int VZ_LPRC_REC_YELLOW = (1 << (LT_YELLOW) | 1 << (LT_YELLOW2));	/** 黄牌车*/
        public const int VZ_LPRC_REC_BLACK = (1 << (LT_BLACK));						/** 黑牌车*/
        public const int VZ_LPRC_REC_COACH = (1 << (LT_COACH));						/** 教练车*/
        public const int VZ_LPRC_REC_POLICE = (1 << (LT_POLICE));					    /** 警车*/
        public const int VZ_LPRC_REC_AMPOL = (1 << (LT_ARMPOL));				        /** 武警车*/
        public const int VZ_LPRC_REC_ARMY = (1 << (LT_ARMY) | 1 << (LT_ARMY2));		/** 军车*/
        public const int VZ_LPRC_REC_GANGAO = (1 << (LT_HONGKONG) | 1 << (LT_MACAO));	/** 港澳进出大陆车*/
        public const int VZ_LPRC_REC_EMBASSY = (1 << (LT_EMBASSY));                      /** 使馆车*/
        public const int VZ_LPRC_REC_AVIATION = (1 << (LT_EMBASSY));	                    /** 民航*/
        public const int VZ_LPRC_REC_ENERGY = (1 << (LI_ENERGY));                       /** 新能源*/
        public const int VZ_LPRC_REC_NO_PLATE = (1 << (LI_NO_PLATE));                     /** 无车牌*/

        public const int MAX_OutputConfig_Len = 7;
        ///**加密类型**/
        public const int ENCRYPT_NAME_LENGTH = 32;
        public const int ENCRYPT_LENGTH = 16;
        public const int SIGNATURE_LENGTH = 32;
        public const int VZ_LPRC_ROI_VERTEX_NUM_EX = 12;
        public const int VZ_LPRC_VIRTUAL_LOOP_NAME_LEN = 32;
        public const int VZ_LPRC_VIRTUAL_LOOP_VERTEX_NUM = 4;
        public const int VZ_LPRC_VIRTUAL_LOOP_MAX_NUM = 8;
        public const int VZ_LPRC_PROVINCE_STR_LEN = 128;
        public const int VZ_GET_CAR_INFO = 1201;
        public const int VZ_LPRC_MAX_RESOLUTION = 12;
        public const int VZ_LPRC_MAX_RATE = 5;
        public const int VZ_LPRC_MAX_VIDEO_QUALITY = 12;
        //中心服务器网络
        public const int LPRC_CENTER_IPLEN = 200;
        public const int URLLENGTH = 1000;

        static Lazy<IVzClientSdkProxy> _albCtrlSdk = new Lazy<IVzClientSdkProxy>(() => new VzClientSdkLoader(), true);
        /// <summary>
        /// 静态构造
        /// </summary>
        static VzClientSdk()
        {
            Directory.CreateDirectory(VzClientSdkLoader.DllFullPath);
            if (Environment.Is64BitProcess)
            {
                bool isExists = CompareFile(VzClientSdkLoader.DllFullName, Properties.Resources.X64_VzLPRSDK);
                if (!isExists)
                {
                    WriteFile(Properties.Resources.X64_VzLPRSDK, Path.Combine(VzClientSdkLoader.DllFullPath, "VzLPRSDK.dll"));
                }
            }
            else
            {
                bool isExists = CompareFile(VzClientSdkLoader.DllFullName, Properties.Resources.X86_VzLPRSDK);
                if (!isExists)
                {
                    WriteFile(Properties.Resources.X86_VzLPRSDK, Path.Combine(VzClientSdkLoader.DllFullPath, "VzLPRSDK.dll"));
                }
            }
        }

        private static void WriteFile(byte[] dllFile, string fullName)
        {
            try
            {
                if (File.Exists(fullName)) { File.Delete(fullName); }
                File.WriteAllBytes(fullName, dllFile);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private static bool CompareFile(string file, byte[] res)
        {
            if (!File.Exists(file)) { return false; }
            using (var hash = SHA1.Create())
            {
                using (var distFile = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var resHash = hash.ComputeHash(res);
                    var distHash = hash.ComputeHash(distFile);
                    if (resHash.Length != distHash.Length) { return false; }
                    for (int i = 0; i < resHash.Length; i++)
                    {
                        if (resHash[i] != distHash[i]) { return false; }
                    }
                    return true;
                }
            }
        }
        /// <summary>
        /// 创建SDK代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IVzClientSdkProxy Create(bool isBase = false)
        {
            var pluginDir = VzClientSdkLoader.DllFullPath;
            if (isBase)
            {
                if (!File.Exists(VzClientSdkDller.DllFullName))
                {
                    if (Directory.Exists(pluginDir))
                    {
                        try
                        {
                            CopyDirectory(pluginDir, Path.GetFullPath("."));
                        }
                        catch { }
                    }
                }
                return VzClientSdkDller.Instance;
            }
            if (!Directory.Exists(pluginDir)) { return VzClientSdkDller.Instance; }
            return _albCtrlSdk.Value;
        }
        /// <summary>
        /// 复制目录
        /// </summary>
        /// <param name="src"></param>
        /// <param name="tag"></param>
        public static void CopyDirectory(string src, string tag)
        {
            foreach (var item in new DirectoryInfo(src).GetFileSystemInfos())
            {
                if (item is DirectoryInfo dir)
                {
                    var tagDir = Path.Combine(tag, dir.Name);
                    if (!Directory.Exists(tagDir)) { Directory.CreateDirectory(tagDir); }
                    CopyDirectory(dir.FullName, tagDir);
                    continue;
                }
                File.Copy(item.FullName, Path.Combine(tag, item.Name), false);
            }
        }

    }
}
