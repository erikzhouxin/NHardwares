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
        /// 
        /// </summary>
        public const String DllVirtualFileName = $"{DllVirtualPath}\\{DllFileName}";
        /// <summary>
        /// 基路径
        /// </summary>
        public static String BaseDllFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 基路径全称
        /// </summary>
        public static String BaseDllFullName { get; } = Path.GetFullPath(DllFileName);
        /// <summary>
        /// SDK虚拟路径
        /// </summary>
        public const String DllVirtualPath = @"plugins\haikanghcnetsdk";
        /// <summary>
        /// SDK全路径
        /// </summary>
        public static String DllFullPath { get; } = Path.GetFullPath(DllVirtualPath);
        /// <summary>
        /// SDK全名称
        /// </summary>
        public static String DllFullName { get; } = Path.Combine(DllFullPath, DllFileName);
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
