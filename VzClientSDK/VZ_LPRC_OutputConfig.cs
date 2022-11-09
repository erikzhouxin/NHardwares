using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 输出配置
    /// </summary>
    public struct VZ_LPRC_OutputConfig
    {
        /// <summary>
        /// 开关量输出 1
        /// </summary>
        public int switchout1;
        /// <summary>
        /// 开关量输出 2
        /// </summary>
        public int switchout2;
        /// <summary>
        /// 开关量输出 3
        /// </summary>            
        public int switchout3;
        /// <summary>
        /// 开关量输出 4
        /// </summary>
        public int switchout4;
        /// <summary>
        /// 电平输出 1 
        /// </summary>
        public int levelout1;
        /// <summary>
        /// 电平输出 2
        /// </summary>
        public int levelout2;
        /// <summary>
        /// RS485-1
        /// </summary>
        public int rs485out1;
        /// <summary>
        /// RS485-2
        /// </summary>
        public int rs485out2;
        /// <summary>
        /// 触发输入的类型
        /// </summary>
        public VZ_InputType eInputType;
    }
}
