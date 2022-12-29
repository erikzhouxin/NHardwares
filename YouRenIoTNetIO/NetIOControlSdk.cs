using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.Linq;
using System.Text;

namespace System.Data.YouRenIoTNetIO
{
    /// <summary>
    /// 网络IO控制器SDK
    /// </summary>
    public static class NetIOControlSdk
    {
        static NetIOControlSdk()
        {

        }
        /// <summary>
        /// 创建一个IO控制器
        /// </summary>
        /// <param name="controlType"></param>
        /// <returns></returns>
        public static IUsrIOControlProxy CreateIOControl(IOControlType controlType)
        {
            return new UsrIOControlProxy(controlType);
        }
    }
}
