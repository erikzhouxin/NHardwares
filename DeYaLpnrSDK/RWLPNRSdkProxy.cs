﻿using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.DeYaLpnrSDK
{
    /// <summary>
    /// 德亚道闸SDK代理
    /// </summary>
    public interface IRWLPNRSdkProxy
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        IntPtr LPNR_Init(byte[] ip);
        /// <summary>
        /// 结束
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        int LPNR_Terminate(IntPtr handle);
        /// <summary>
        /// 设置回调
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="cb"></param>
        /// <returns></returns>
        int LPNR_SetCallBack(IntPtr lib, LPNRCallBack cb);
        /// <summary>
        /// 获取车牌
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="funcName"></param>
        /// <returns></returns>
        int LPNR_GetPlateNumber(IntPtr lib, byte[] funcName);
        /// <summary>
        /// 同步时间
        /// </summary>
        /// <param name="lib"></param>
        /// <returns></returns>
        int LPNR_SyncTime(IntPtr lib);
        /// <summary>
        /// 启用感应线圈
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="en"></param>
        /// <returns></returns>
        int LPNR_EnableLiveFrame(IntPtr lib, int en);
        /// <summary>
        /// 是在线
        /// </summary>
        /// <param name="lib"></param>
        /// <returns></returns>
        int LPNR_IsOnline(IntPtr lib);
        /// <summary>
        /// 获取截图大小
        /// </summary>
        /// <param name="lib"></param>
        /// <returns></returns>
        int LPNR_GetCapturedImageSize(IntPtr lib);
        /// <summary>
        /// 获取感应线圈
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        int LPNR_GetLiveFrame(IntPtr lib, byte[] date);
        /// <summary>
        /// 获取感应线圈大小
        /// </summary>
        /// <param name="lib"></param>
        /// <returns></returns>
        int LPNR_GetLiveFrameSize(IntPtr lib);
        /// <summary>
        /// 获取截图
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        int LPNR_GetCapturedImage(IntPtr lib, byte[] date);
        /// <summary>
        /// 触发器
        /// </summary>
        /// <param name="lib"></param>
        /// <returns></returns>
        int LPNR_SoftTrigger(IntPtr lib);
    }
}
