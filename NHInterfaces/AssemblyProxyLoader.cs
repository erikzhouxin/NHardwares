using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace System.Data.HardwareInterfaces
{
    /// <summary>
    /// 程序集代理加载
    /// </summary>
    public class AssemblyProxyLoader
    {
        /// <summary>
        /// 程序集
        /// </summary>
        public virtual Assembly Assembly { get; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public virtual String FileName { get => Path.GetFileName(Assembly.Location); }
        /// <summary>
        /// 全称
        /// </summary>
        public virtual String FullName { get => Assembly.Location; }
        /// <summary>
        /// 文件构造
        /// </summary>
        public AssemblyProxyLoader(string dllPath)
        {
            Assembly = Assembly.LoadFile(dllPath);
        }
        /// <summary>
        /// 程序集名称构造
        /// </summary>
        /// <param name="assembly"></param>
        public AssemblyProxyLoader(AssemblyName assembly)
        {
            Assembly = Assembly.LoadFrom(assembly.FullName);
        }
        /// <summary>
        /// 程序集构造
        /// </summary>
        /// <param name="assembly"></param>
        public AssemblyProxyLoader(Assembly assembly)
        {
            Assembly = assembly;
        }
    }
}
