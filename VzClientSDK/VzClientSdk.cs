using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Cryptography;
using System.Data.HardwareInterfaces;

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
        /// <summary>
        /// 全路径
        /// </summary>
        public static string BaseDllFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String BaseDllFullName { get; } = Path.GetFullPath(DllFileName);
        /// <summary>
        /// 相对路径
        /// </summary>
        public const string DllVirtualPath = @"plugins\vzclientsdk";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(DllVirtualPath);
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String DllFullName { get; } = Path.Combine(DllFullPath, DllFileName);
        #region // 可过滤的车牌识别触发类型
        /// <summary>
        /// 允许触发稳定结果
        /// </summary>
        public const int VZ_LPRC_TRIG_ENABLE_STABLE = 0x1;
        /// <summary>
        /// 允许触发虚拟线圈结果
        /// </summary>
        public const int VZ_LPRC_TRIG_ENABLE_VLOOP = 0x2;
        /// <summary>
        /// 允许外部IO_IN_1触发
        /// </summary>
        public const int VZ_LPRC_TRIG_ENABLE_IO_IN1 = 0x10;
        /// <summary>
        /// 允许外部IO_IN_2触发
        /// </summary>
        public const int VZ_LPRC_TRIG_ENABLE_IO_IN2 = 0x20;
        /// <summary>
        /// 允许外部IO_IN_3触发
        /// </summary>
        public const int VZ_LPRC_TRIG_ENABLE_IO_IN3 = 0x40;
        #endregion 可过滤的车牌识别触发类型
        #region // 车牌类型
        /// <summary>
        /// 未知车牌
        /// </summary>
        public const int LT_UNKNOWN = 0;
        /// <summary>
        /// 蓝牌小汽车
        /// </summary>
        public const int LT_BLUE = 1;
        /// <summary>
        /// 黑牌小汽车
        /// </summary>
        public const int LT_BLACK = 2;
        /// <summary>
        /// 单排黄牌
        /// </summary>
        public const int LT_YELLOW = 3;
        /// <summary>
        /// 双排黄牌（大车尾牌，农用车）
        /// </summary>
        public const int LT_YELLOW2 = 4;
        /// <summary>
        /// 警车车牌
        /// </summary>
        public const int LT_POLICE = 5;
        /// <summary>
        /// 武警车牌
        /// </summary>
        public const int LT_ARMPOL = 6;
        /// <summary>
        /// 个性化车牌
        /// </summary>
        public const int LT_INDIVI = 7;
        /// <summary>
        /// 单排军车牌
        /// </summary>
        public const int LT_ARMY = 8;
        /// <summary>
        /// 双排军车牌
        /// </summary>
        public const int LT_ARMY2 = 9;
        /// <summary>
        /// 使馆车牌
        /// </summary>
        public const int LT_EMBASSY = 10;
        /// <summary>
        /// 香港进出中国大陆车牌
        /// </summary>
        public const int LT_HONGKONG = 11;
        /// <summary>
        /// 农用车牌
        /// </summary>
        public const int LT_TRACTOR = 12;
        /// <summary>
        /// 教练车牌
        /// </summary>
        public const int LT_COACH = 13;
        /// <summary>
        /// 澳门进出中国大陆车牌
        /// </summary>
        public const int LT_MACAO = 14;
        /// <summary>
        /// 双层武警车牌
        /// </summary>
        public const int LT_ARMPOL2 = 15;
        /// <summary>
        /// 武警总队车牌
        /// </summary>
        public const int LT_ARMPOL_ZONGDUI = 16;
        /// <summary>
        /// 双层武警总队车牌
        /// </summary>
        public const int LT_ARMPOL2_ZONGDUI = 17;
        /// <summary>
        /// 民航
        /// </summary>
        public const int LI_AVIATION = 18;
        /// <summary>
        /// 新能源小型车
        /// </summary>
        public const int LI_ENERGY = 19;
        /// <summary>
        /// 无车牌
        /// </summary>
        public const int LI_NO_PLATE = 20;
        #endregion 车牌类型
        #region // 可配置的识别类型
        /// <summary>
        /// 蓝牌车
        /// </summary>
        public const int VZ_LPRC_REC_BLUE = (1 << (LT_BLUE));
        /// <summary>
        /// 黄牌车
        /// </summary>
        public const int VZ_LPRC_REC_YELLOW = (1 << (LT_YELLOW) | 1 << (LT_YELLOW2));
        /// <summary>
        /// 黑牌车
        /// </summary>
        public const int VZ_LPRC_REC_BLACK = (1 << (LT_BLACK));
        /// <summary>
        /// 教练车
        /// </summary>
        public const int VZ_LPRC_REC_COACH = (1 << (LT_COACH));
        /// <summary>
        /// 警车
        /// </summary>
        public const int VZ_LPRC_REC_POLICE = (1 << (LT_POLICE));
        /// <summary>
        /// 武警车
        /// </summary>
        public const int VZ_LPRC_REC_AMPOL = (1 << (LT_ARMPOL));
        /// <summary>
        /// 军车
        /// </summary>
        public const int VZ_LPRC_REC_ARMY = (1 << (LT_ARMY) | 1 << (LT_ARMY2));
        /// <summary>
        /// 港澳进出大陆车
        /// </summary>
        public const int VZ_LPRC_REC_GANGAO = (1 << (LT_HONGKONG) | 1 << (LT_MACAO));
        /// <summary>
        /// 使馆车
        /// </summary>
        public const int VZ_LPRC_REC_EMBASSY = (1 << (LT_EMBASSY));
        /// <summary>
        /// 民航
        /// </summary>
        public const int VZ_LPRC_REC_AVIATION = (1 << (LT_EMBASSY));
        /// <summary>
        /// 新能源
        /// </summary>
        public const int VZ_LPRC_REC_ENERGY = (1 << (LI_ENERGY));
        /// <summary>
        /// 无车牌
        /// </summary>
        public const int VZ_LPRC_REC_NO_PLATE = (1 << (LI_NO_PLATE));
        #endregion 可配置的识别类型
        /// <summary>
        /// 最大输出配置长度
        /// </summary>
        public const int MAX_OutputConfig_Len = 7;
        /// <summary>
        /// 加密名称长度
        /// </summary>
        public const int ENCRYPT_NAME_LENGTH = 32;
        /// <summary>
        /// 加密长度
        /// </summary>
        public const int ENCRYPT_LENGTH = 16;
        /// <summary>
        /// 签名长度
        /// </summary>
        public const int SIGNATURE_LENGTH = 32;
        /// <summary>
        /// 
        /// </summary>
        public const int VZ_LPRC_ROI_VERTEX_NUM_EX = 12;
        /// <summary>
        /// 
        /// </summary>
        public const int VZ_LPRC_VIRTUAL_LOOP_NAME_LEN = 32;
        /// <summary>
        /// 
        /// </summary>
        public const int VZ_LPRC_VIRTUAL_LOOP_VERTEX_NUM = 4;
        /// <summary>
        /// 
        /// </summary>
        public const int VZ_LPRC_VIRTUAL_LOOP_MAX_NUM = 8;
        /// <summary>
        /// 
        /// </summary>
        public const int VZ_LPRC_PROVINCE_STR_LEN = 128;
        /// <summary>
        /// 
        /// </summary>
        public const int VZ_GET_CAR_INFO = 1201;
        /// <summary>
        /// 
        /// </summary>
        public const int VZ_LPRC_MAX_RESOLUTION = 12;
        /// <summary>
        /// 
        /// </summary>
        public const int VZ_LPRC_MAX_RATE = 5;
        /// <summary>
        /// 
        /// </summary>
        public const int VZ_LPRC_MAX_VIDEO_QUALITY = 12;
        /// <summary>
        /// 中心服务器网络
        /// </summary>
        public const int LPRC_CENTER_IPLEN = 200;
        /// <summary>
        /// URL长度
        /// </summary>
        public const int URLLENGTH = 1000;

        static Lazy<IVzClientSdkProxy> _vzClientSdk = new Lazy<IVzClientSdkProxy>(() => new VzClientSdkLoader(), true);
        /// <summary>
        /// 静态构造
        /// </summary>
        static VzClientSdk()
        {
            Directory.CreateDirectory(DllFullPath);
            if (Environment.Is64BitProcess)
            {
                if (!SdkFileComponent.CompareResourceFile(DllFullName, Properties.Resources.X64_VzLPRSDK))
                {
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_VzLPRSDK, Path.Combine(DllFullPath, "VzLPRSDK.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_avcodec_57, Path.Combine(DllFullPath, "avcodec-57.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_avformat_57, Path.Combine(DllFullPath, "avformat-57.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_avutil_54, Path.Combine(DllFullPath, "avutil-54.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_avutil_55, Path.Combine(DllFullPath, "avutil-55.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_libwinpthread_1, Path.Combine(DllFullPath, "libwinpthread-1.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_swscale_3, Path.Combine(DllFullPath, "swscale-3.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_VzAudioDataPlayer, Path.Combine(DllFullPath, "VzAudioDataPlayer.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_VzDrawsLib, Path.Combine(DllFullPath, "VzDrawsLib.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_VzPlayer2, Path.Combine(DllFullPath, "VzPlayer2.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_VzStreamClient, Path.Combine(DllFullPath, "VzStreamClient.dll"));
                }
            }
            else
            {
                if (!SdkFileComponent.CompareResourceFile(DllFullName, Properties.Resources.X86_VzLPRSDK))
                {
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_VzLPRSDK, Path.Combine(DllFullPath, "VzLPRSDK.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_avcodec_57, Path.Combine(DllFullPath, "avcodec-57.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_avformat_57, Path.Combine(DllFullPath, "avformat-57.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_avutil_55, Path.Combine(DllFullPath, "avutil-55.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_msvcr90, Path.Combine(DllFullPath, "msvcr90.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_VzAudioDataPlayer, Path.Combine(DllFullPath, "VzAudioDataPlayer.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_VzDrawsLib, Path.Combine(DllFullPath, "VzDrawsLib.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_VzPlayer2, Path.Combine(DllFullPath, "VzPlayer2.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_VzStreamClient, Path.Combine(DllFullPath, "VzStreamClient.dll"));
                }
            }
        }
        /// <summary>
        /// plugins内容实例
        /// </summary>
        public static IVzClientSdkProxy Instance { get => _vzClientSdk.Value; }
        /// <summary>
        /// 创建SDK代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IVzClientSdkProxy Create(bool isBase = false)
        {
            if (!isBase) { return _vzClientSdk.Value; }
            if (!File.Exists(DllFullName))
            { SdkFileComponent.TryCopyDirectory(DllFullPath, BaseDllFullPath); }
            return VzClientSdkDller.Instance;
        }
    }
}
