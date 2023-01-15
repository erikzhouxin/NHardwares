using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Data.Extter;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace TestHardwareDemo.WinForm.Components
{
    /// <summary>
    /// 兼容WinForm组件
    /// </summary>
    public static class CompatWinFormComponent
    {
        #region // TabPage
        public static bool TryGetTabPageSelect<T>(IEnumerable<TabPage> pages, T scanPanel, out TabPage page)
        {
            foreach (TabPage item in pages)
            {
                foreach (var ctl in item.Controls)
                {
                    if (ctl is T scan)
                    {
                        if (scan.Equals(scanPanel))
                        {
                            page = item;
                            return true;
                        }
                    }
                }
            }
            page = null;
            return false;
        }
        public static bool TryGetTabPage<T>(IEnumerable<TabPage> pages, out T userControl, out TabPage page)
        {
            foreach (TabPage item in pages)
            {
                foreach (var ctl in item.Controls)
                {
                    if (ctl is T scan)
                    {
                        userControl = scan;
                        page = item;
                        return true;
                    }
                }
            }
            userControl = default(T);
            page = null;
            return false;
        }
        public static bool TrySelectTabPage<T>(TabControl tabControl, out T userControl)
            where T : UserControl, new()
        {
            if (!TryGetTabPage(tabControl.TabPages.ToEnumerable<TabPage>(), out userControl, out TabPage page))
            {
                page = new TabPage();
                if (!typeof(UserControl).IsAssignableFrom(typeof(T)))
                {
                    return false;
                }
                var attr = typeof(T).GetCustomAttribute<EDisplayAttribute>() ?? new EDisplayAttribute($"测试{typeof(T).Name}");
                page.Text = attr.Display;
                page.Controls.Add(userControl = new T());
                userControl.Dock = DockStyle.Fill;
                tabControl.TabPages.Add(page);
            }
            tabControl.SelectedTab = page;
            return true;

        }
        #endregion TabPage
        #region // TextCheck
        public static bool TryCheckIPAddressPort(string iptext, string porttext, Action<string> AppendError, out Tuble<string, int> outVal)
        {
            iptext = (iptext ?? String.Empty).Trim();
            if (!IPAddress.TryParse(iptext, out var ipAddress))
            {
                AppendError($"小呆瓜注意：IP地址（{iptext}）长这样吗？能不能长点心好不好啊！");
                outVal = null;
                return false;
            }
            porttext = (porttext ?? "0").Trim();
            if (!Int32.TryParse(porttext, out var port) || port > ushort.MaxValue || port < ushort.MinValue)
            {
                AppendError($"小笨蛋注意：端口号是[0-65535]的数字哦！");
                outVal = null;
                return false;
            }
            outVal = new Tuble<string, int>(ipAddress.ToString(), port);
            return true;
        }
        #endregion TextCheck

    }
}
