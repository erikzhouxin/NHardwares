using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace System.Data.EDBODBCSDK
{
    /// <summary>
    /// 数据访问SDK
    /// </summary>
    public static class DbAccessSdk
    {
        /// <summary>
        /// 全路径
        /// </summary>
        public static string BaseFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 相对路径
        /// </summary>
        public const string DllVirtualPath = @"plugins\edbodbcsdk";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(DllVirtualPath);

        static Lazy<IDbAccessSdkProxy> _dbAccess = new Lazy<IDbAccessSdkProxy>(() => new DbAccessSdkApi(), true);
        /// <summary>
        /// plugins内容实例
        /// </summary>
        public static IDbAccessSdkProxy Instance { get => Environment.Is64BitProcess ? DbAccessSdkApi64.Instance : _dbAccess.Value; }
        /// <summary>
        /// 创建SDK代理,SDK原生不支持64位,所以64位可能有性能损耗
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IDbAccessSdkProxy Create(bool isBase = false)
        {
            if (Environment.Is64BitProcess) { return DbAccessSdkApi64.Instance; }
            return isBase ? new DbAccessSdkApi() : _dbAccess.Value;
        }
    }
}
