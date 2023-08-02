﻿using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace System.Data.WeiGuangCodeBarSDK
{
    /// <summary>
    /// 简单微光条码SDK调用
    /// </summary>
    public static class SimpleVBarSdk
    {
        /// <summary>
        /// 动态链接库文件名
        /// </summary>
        public const String DllFileName = "vbar.dll";
        /// <summary>
        /// 动态链接库文件名
        /// </summary>
        public const String DllVirtualPath = @"plugins\weiguangcodebarsdk";
        /// <summary>
        /// x86的dll目录
        /// </summary>
        public const String DllFileNameX86 = $@".\{DllVirtualPath}\x86\{DllFileName}";
        /// <summary>
        /// x64的dll目录
        /// </summary>
        public const String DllFileNameX64 = $@".\{DllVirtualPath}\x64\{DllFileName}";
        /// <summary>
        /// SDK包相对路径
        /// </summary>
        public const String DllPackFile = $"{DllVirtualPath}.cswin";
        /// <summary>
        /// SDK全路径
        /// </summary>
        public static string DllSdkFile { get; } = Path.GetFullPath(DllPackFile);
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String DllFullName { get; } = Path.GetFullPath(DllFileName);
        static Lazy<ISimpleVBarSdkProxy> _vbarSdk = new Lazy<ISimpleVBarSdkProxy>(() => new SimpleVBarSdkLoader(), true);
        static SimpleVBarSdk()
        {
            var res = new SdkFileLoaderModel()
            {
                BasePath = DllFullPath,
                PlatformPath = Environment.Is64BitProcess ? "x64" : "x86",
                VersionFile = $"{nameof(WeiGuangCodeBarSDK)}.version",
                SdkFileName = DllSdkFile
            }.Build();
            if (res.IsSuccess) { return; }
            throw new Exception(res.Message, (res as IAlertException)?.Exception);
        }
        /// <summary>
        /// 创建SDK代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static ISimpleVBarSdkProxy Create(bool isBase = false)
        {
            if (!isBase) { return _vbarSdk.Value; }
            return Environment.Is64BitProcess ? SimpleVBarSdkDllerX64.Instance : SimpleVBarSdkDllerX86.Instance;
        }
    }
}
