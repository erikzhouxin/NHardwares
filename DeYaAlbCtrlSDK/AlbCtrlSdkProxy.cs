using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.DeYaAlbCtrlSDK
{
    /// <summary>
    /// 德亚道闸SDK代理
    /// </summary>
    public interface IAlbCtrlSdkProxy
    {
        /// <summary>
        /// 打开并连接设备
        /// </summary>
        /// <param name="strIP">
        /// A.使用网线和栏杆机控制器通信时，strIP 为栏杆机控制器的 IP 地址字符串，
        ///   例如“192.168.1.101”。?pcIP
        /// B.使用串口和栏杆机控制器通信时，strIP 为连接栏杆机控制器的串口号，
        ///   例如使用串口 3 连接栏杆机控制器，则 strIP 为”COM3”，注意大小写。
        /// </param>
        /// <returns>成功：返回设备的句柄。失败：返回 NULL。</returns>
        IntPtr DEV_Open(string strIP);
        /// <summary>
        /// 关闭设备
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_Close(IntPtr h);
        /// <summary>
        /// 控制设备抬杆或落杆
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="bOpen">TRUE 为控制抬杆，FALSE 为控制落杆。</param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_ALB_Ctrl(IntPtr h, Boolean bOpen);
        /// <summary>
        /// 注册设备状态变化事件处理函数
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="pCallback">
        /// 设备状态变化事件处理函数指针
        /// (1)设备事件列表
        /// <![CDATA[
        /// nEventId   nParam            说明
        /// 1          BalustradeStatus  栏杆的状态，BalustradeStatus 有以下几种情况：
        ///                              0： 未知状态
        ///                              1： 落杆中
        ///                              2： 落到水平位置
        ///                              3： 抬杆中
        ///                              4： 抬到竖直位置
        /// 2          FCoilStatus       前线圈(抓拍线圈)的状态，FCoilStatus有以下2种情况：
        ///                              0： 线圈无车
        ///                              1： 线圈有车
        /// 3          BCoilStatus       后线圈(栏杆线圈)的状态，BCoilStatus有以下2种情况：
        ///                              0： 线圈无车
        ///                              1： 线圈有车
        /// 4          FaultBits         栏杆机故障标志位（详见DEV_GetFaultBits接口中的描述）
        /// 96                           设备接受连接
        /// 97                           设备拒绝连接
        /// 98                           与设备建立连线
        /// 99                           与设备连线断开
        /// ]]>
        /// (2)此接口和 DEV_EnableEventMessageEx 接口只能 2 选 1，如果都调用的话，
        /// 那么当有事件发生时，动态库使用 DEV_SetEventHandle 接口注册的事件回掉函数通知上位机。
        /// </param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_SetEventHandle(IntPtr h, DEVEventCallBack pCallback);
        /// <summary>
        /// 注册接设备状态变化事件的句柄和消息 ID。
        /// 说明:
        /// (1)上位机收到设备消息时，消息的 wParam 为发生事件的设备句柄（即，调用DEV_Open 返回的句柄）
        /// (2)上位机收到设备消息时，消息的 lParam 为事件编号+事件参数，
        /// 其中 lParam 的低8位（即，Bit0~Bit7）为事件参数，
        /// lParam 的 8 到 16 位为事件编号（即，Bit8~Bit15）
        /// <![CDATA[
        /// (lParam >> 8) & 0xFF              lParam & 0xFF                 说明
        /// 1                                 栏杆状态，有以下几种情况：    栏杆状态变化事件
        ///                                   0：未知状态落杆
        ///                                   1：中落到水平位
        ///                                   2：置抬杆中抬到
        ///                                   3：竖直位置
        ///                                   4：
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 2                                前线圈(抓拍线圈)状态，        前线圈(抓拍线圈)状态变化事件
        ///                                  有以下 2 种情况：
        ///                                  0： 线圈无车
        ///                                  1： 线圈有车
        /// 3                                后线圈(栏杆线圈)状态，        后线圈(栏杆线圈)状态变化事件
        ///                                  有以下 2 种情况：
        ///                                  0： 线圈无车
        ///                                  1： 线圈有车
        /// 4                                栏杆机故障标志位（详见
        ///                                  DEV_GetFaultBits接口中的描述）栏杆机故障位变化事件
        /// 96                               无                            设备接受连接事件
        /// 97                               无                            设备拒绝连接事件
        /// 98                               无                            与设备建立连线事件
        /// 99                               无                            与设备连线断开事件
        /// ]]>
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="hWnd">用于接收设备消息的窗口句柄</param>
        /// <param name="MsgID">设备消息编号</param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_EnableEventMessageEx(IntPtr h, IntPtr hWnd, int MsgID);
        /// <summary>
        /// 获取设备状态
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="dwStatus">
        /// 用于存放设备状态的变量地址
        /// dwStatus 为 4 字节（32 位）的变量地址，设备状态描述如下
        /// <![CDATA[
        /// bit              含义
        /// bit0 ~bit3       栏杆机状态：
        ///                  0： 未知状态
        ///                  1： 落杆中
        ///                  2： 落到水平位置
        ///                  3： 抬杆中
        ///                  4： 抬到竖直位置
        /// bit4             前线圈(抓拍线圈)状态: 
        ///                  0： 线圈无车
        ///                  1： 线圈有车
        /// bit5             后线圈(栏杆线圈)状态：
        ///                  0： 线圈无车
        ///                  1： 线圈有车
        /// bit6             设备在线状态：
        ///                  0：设备离线
        ///                  1：设备在线
        /// bit7 ~bit31      保留
        /// ]]>
        /// </param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_GetStatus(IntPtr h, out uint dwStatus);
        /// <summary>
        /// 获取设备故障位
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="dwFaultBits">
        /// 用于存放设备故障位的变量地址
        /// dwFaultBits 为 4 字节（32 位）的变量地址，设备故障位描述如下
        /// <![CDATA[
        /// bit          含义
        /// bit0         角度传感器远大于正常范围置 1，否则为 0
        /// bit1         角度传感器远小于正常范围置 1，否则为 0
        /// bit2         角度传感器在抬落杆过程中无变化置 1，否则为 0
        /// bit3         抬杆到位接近开关故障置 1，否则为 0
        /// bit4         落杆到位接近开关故障置 1，否则为 0
        /// bit5 ~bit31  保留
        /// ]]>
        /// </param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        [Obsolete("替代方案:[DEV_GetStatus]此方法已弃用去除")]
        Boolean DEV_GetFaultBits(IntPtr h, int dwFaultBits);
        /// <summary>
        /// 打开/关闭日志记录
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="bEnable">打开或关闭日志</param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_EnableLog(IntPtr h, Boolean bEnable);
        /// <summary>
        /// 设置日志路径
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="Path">日志路径字符串，只到文件夹，不用指定文件名称</param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_SetLogPath(IntPtr h, String Path);
        /// <summary>
        /// 获取版本号
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="Version">
        /// 用于存放控制器版本号的地址
        /// 设备版本号(使用long类型接收，将其转化为二进制格式，按照8位对照ascii码格式获取版本号)
        /// <![CDATA[
        /// 版本号示例：
        ///      3.2.3
        /// 获取long类型值：
        ///      219818372659
        /// 转化为64位二进制：
        ///    00000000 00000000 00000000 00110011 00101110 00110010 00101110 00110011
        /// 按照每8位转化为整数:
        ///           0        0        0       51       46       50       46       51
        /// 对应ASCII码：
        ///                                      3        .        2        .        3
        /// ]]>
        /// </param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_GetVersion(IntPtr h, out long Version);
        /// <summary>
        /// 启用队列
        /// </summary>
        /// <param name="h">设备句柄</param>
        /// <param name="bOpen">TRUE 为启用，FALSE 为关闭。</param>
        /// <returns>成功：返回TRUE。失败：返回FALSE。</returns>
        Boolean DEV_Queue(IntPtr h, Boolean bOpen);
    }
}
