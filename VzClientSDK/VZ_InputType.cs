using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 触发输入的类型
    /// </summary>
    public enum VZ_InputType : uint
    {
        /// <summary>
        /// 通过
        /// </summary>
        nWhiteList = 0, 
        /// <summary>
        /// 不通过
        /// </summary>
        nNotWhiteList,   
        /// <summary>
        /// 无车牌
        /// </summary>
        nNoLicence,     
        /// <summary>
        /// 黑名单
        /// </summary>
        nBlackList,     
        /// <summary>
        /// 开关量/电平输入 1
        /// </summary>
        nExtIoctl1,      
        /// <summary>
        /// 开关量/电平输入 2
        /// </summary> 
        nExtIoctl2,   
        /// <summary>
        /// 开关量/电平输入 3
        /// </summary>
        nExtIoctl3     
    }
}
