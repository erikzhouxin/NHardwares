using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.HikHCNetSDK
{
    // 用户调用SendwithRecv接口时，接口返回的状态
    public enum NET_SDK_SENDWITHRECV_STATUS
    {
        NET_SDK_CONFIG_STATUS_SUCCESS = 1000,    // 成功读取到数据，客户端处理完本次数据后需要再次调用NET_DVR_SendWithRecvRemoteConfig获取下一条数据
        NET_SDK_CONFIG_STATUS_NEEDWAIT,          // 配置等待，客户端可重新NET_DVR_SendWithRecvRemoteConfig
        NET_SDK_CONFIG_STATUS_FINISH,            // 数据全部取完，此时客户端可调用NET_DVR_StopRemoteConfig结束
        NET_SDK_CONFIG_STATUS_FAILED,            // 配置失败，客户端可重新NET_DVR_SendWithRecvRemoteConfig
        NET_SDK_CONFIG_STATUS_EXCEPTION,         // 配置异常，此时客户端可调用NET_DVR_StopRemoteConfig结束
    }
}
