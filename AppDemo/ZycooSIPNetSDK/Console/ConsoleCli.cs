using System;
using System.Collections.Generic;
using System.Text;

namespace ZycooSIPNetSDK.CmdConsole
{
    /// <summary>
    /// 输出命令行界面接口
    /// </summary>
    public interface IConsoleCli
    {
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 欢迎语
        /// </summary>
        String Welcome { get; }
        /// <summary>
        /// 说明
        /// </summary>
        String Readme { get; }
        /// <summary>
        /// 开始调用
        /// </summary>
        void Start();
        /// <summary>
        /// 帮助
        /// </summary>
        void Help();
    }
    /// <summary>
    /// 输出命令行界面
    /// </summary>
    public class ConsoleCli : IConsoleCli
    {
        /// <summary>
        /// 默认启动字符串
        /// </summary>
        public static String DefaultStartString { get; set; } = "啥也没有，啥也不是";
        /// <summary>
        /// 默认帮助字符串
        /// </summary>
        public static String DefaultHelpString { get; set; } = "啥也没有，啥也不是";
        /// <inheritdoc/>
        public virtual string Name { get; set; }
        /// <inheritdoc/>
        public virtual string Welcome { get; set; }
        /// <inheritdoc/>
        public virtual string Readme { get; set; }
        private Action _start;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="start"></param>
        public ConsoleCli(Action start)
        {
            _start = start ?? DefaultStart;
        }
        /// <summary>
        /// 构造
        /// </summary>
        protected ConsoleCli() : this(null) { }
        /// <inheritdoc/>
        public virtual void Start() => _start?.Invoke();
        /// <summary>
        /// 默认启动
        /// </summary>
        public virtual void DefaultStart()
        {
            Console.WriteLine(DefaultStartString);
        }
        /// <inheritdoc/>
        public virtual void Help()
        {
            Console.WriteLine(DefaultHelpString);
        }
    }
}
