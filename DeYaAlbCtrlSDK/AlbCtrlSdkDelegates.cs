using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.DeYaAlbCtrlSDK
{
    /// <summary>
    /// 道闸机状态改变时的事件回调委托
    /// 在任何方式改变道闸机的某个状态后，触发此委托完成状态改变的事件处理
    /// 事件：
    /// 联机状态改变(关闭连接时由于句柄置空不会触发)
    /// 前线圈状态改变/后线圈状态改变/收到起竿落杆信号
    /// 杆位置发生改变/其他信号发生改变
    /// <![CDATA[
    /// 事件编号          事件参数            事件说明
    /// -------------------------------------------------------------
    /// 1                0                  未知状态
    ///                  1                  落杆中
    ///                  2                  落杆至水平位置
    ///                  3                  起竿中
    ///                  4                  起竿至竖直位置
    /// -------------------------------------------------------------
    /// 2                0                  前线圈(抓拍线圈)无车
    ///                  1                  前线圈(抓拍线圈)有车
    /// -------------------------------------------------------------
    /// 3                0                  后线圈(栏杆线圈)无车
    ///                  1                  后线圈(栏杆线圈)有车
    /// -------------------------------------------------------------
    /// 4                                   栏杆机故障标志位详见故障接口
    /// -------------------------------------------------------------
    /// 96                                  设备接受连接    
    /// -------------------------------------------------------------
    /// 97                                  设备拒绝连接
    /// -------------------------------------------------------------
    /// 98                                  与设备建立连线
    /// -------------------------------------------------------------
    /// 99                                  与设备连线断开
    /// 注：此事件处于非主线程中
    /// ]]>
    /// </summary>
    /// <param name="h">发生变化的栏杆机设备句柄，调用 DEV_Open 返回的句柄</param>
    /// <param name="nEventId">发生的事件</param>
    /// <param name="nParam">事件参数</param>
    public delegate void DEVEventCallBack(IntPtr h, Int32 nEventId, Int32 nParam);
    internal class DCreater
    {
        public delegate IntPtr DEV_Open(string strIP);
        public delegate Boolean DEV_Close(IntPtr h);
        public delegate Boolean DEV_ALB_Ctrl(IntPtr h, Boolean bOpen);
        public delegate Boolean DEV_SetEventHandle(IntPtr h, DEVEventCallBack pCallback);
        public delegate Boolean DEV_EnableEventMessageEx(IntPtr h, IntPtr hWnd, int MsgID);
        public delegate Boolean DEV_GetStatus(IntPtr h, out uint dwStatus);
        [Obsolete("替代方案:[DEV_GetStatus]此方法已弃用去除")]
        public delegate Boolean DEV_GetFaultBits(IntPtr h, int dwFaultBits);
        public delegate Boolean DEV_EnableLog(IntPtr h, Boolean bEnable);
        public delegate Boolean DEV_SetLogPath(IntPtr h, String Path);
        public delegate Boolean DEV_GetVersion(IntPtr h, out long Version);
        public delegate Boolean DEV_Queue(IntPtr h, Boolean bOpen);
    }
}
