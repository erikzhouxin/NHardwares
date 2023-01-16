using System;
using System.Collections.Generic;
using System.Text;

namespace TestHardwareDemo.WinForm.Components
{
    /// <summary>
    /// 配置子控件清理接口
    /// </summary>
    public interface IConfigClearSubControl
    {
        /// <summary>
        /// 清理返回False则不能被清理
        /// </summary>
        IAlertMsg Clear();
    }
}
