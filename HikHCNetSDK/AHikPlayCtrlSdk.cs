using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.HikHCNetSDK
{
    /// <summary>
    /// 播放控制SDK
    /// </summary>
    public static class HikPlayCtrlSdk
    {
        /// <summary>
        /// SDK文件名称
        /// </summary>
        public const string DllFileName = "PlayCtrl.dll";
        /// <summary>
        /// SDK虚拟路径
        /// </summary>
        public const String DllVirtualPath = HikHCNetSdk.DllVirtualPath;
        /// <summary>
        /// x86的dll目录
        /// </summary>
        public const String DllFileNameX86 = $@".\{DllVirtualPath}\x86\{DllFileName}";
        /// <summary>
        /// x64的dll目录
        /// </summary>
        public const String DllFileNameX64 = $@".\{DllVirtualPath}\x64\{DllFileName}";
        /// <summary>
        /// 基路径
        /// </summary>
        public static String BaseFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// SDK全路径
        /// </summary>
        public static String DllFullPath { get; } = Path.GetFullPath(DllVirtualPath);
        /// <summary>
        /// 时间一
        /// </summary>
        public const int Timer1 = 1;
        /// <summary>
        /// 时间二
        /// </summary>
        public const int Timer2 = 2;

        /// <summary>
        /// 创建SDK代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IHikPlayCtrlSdkProxy Create(bool isBase = false) => HikHCNetSdk.CreatePlayM4(isBase);
    }
}
