using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace System.Data.HDSSSESDK
{
    /// <summary>
    /// SDK创建类
    /// </summary>
    public static class HD100CardSdk
    {
        /// <summary>
        /// SDK文件名称
        /// </summary>
        public const String DllFileName = "HDSSSE32.dll";
        /// <summary>
        /// 相对路径
        /// </summary>
        public const string DllVirtualPath = @"plugins\hdsssesdk";
        /// <summary>
        /// x86的dll目录
        /// </summary>
        public const String DllFileNameX86 = $@".\{DllVirtualPath}\x86\{DllFileName}";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string BaseFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(DllVirtualPath);

        static Lazy<IHD100CardSdkProxy> _hd100Card = new Lazy<IHD100CardSdkProxy>(() => new HD100CardSdkLoader(), true);
        /// <summary>
        /// plugins内容实例
        /// </summary>
        public static IHD100CardSdkProxy Instance { get => Environment.Is64BitProcess ? HD100CardApi64.Instance : _hd100Card.Value; }
        /// <summary>
        /// 创建SDK代理,SDK原生不支持64位,所以64位可能有性能损耗
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IHD100CardSdkProxy Create(bool isBase = false)
        {
            if (Environment.Is64BitProcess) { return HD100CardApi64.Instance; }
            if (!isBase) { return _hd100Card.Value; }
            return HD100CardSdkDller.Instance;
        }
        [Obsolete("替代方案:HD100CardSdk.Create")]
        internal static IHD100CardApi CreateApi()
        {
            if (Environment.Is64BitProcess) { return HD100CardApi64.Instance; }
            return new HD100CardApi();
        }
    }
}
