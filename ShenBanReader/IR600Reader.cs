using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// R600读写器接口
    /// </summary>
    public interface IR600Reader : IDisposable
    {
        /// <summary>
        /// 接收回调
        /// </summary>
        Action<Byte[]> ReceiveCallback { get; }
        /// <summary>
        /// 发送回调
        /// </summary>
        Action<Byte[]> SendCallback { get; }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        int Connect(string portName, int baudRate, out string exception);
        /// <summary>
        /// 连接网口
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        int Connect(IPAddress ip, int port, out string exception);
        /// <summary>
        /// 注册命令回调
        /// </summary>
        /// <param name="model"></param>
        void RegistCallback(IR600Recall model);
        /// <summary>
        /// 注册命令回调
        /// </summary>
        /// <param name="model"></param>
        void RegistCallback(IR600Callback model);
        /// <summary>
        /// 读GPIO值
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int ReadGpioValue(byte btReadId);
        /// <summary>
        /// 写GPIO值
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btChooseGpio"></param>
        /// <param name="btGpioValue"></param>
        /// <returns></returns>
        int WriteGpioValue(byte btReadId, byte btChooseGpio, byte btGpioValue);
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btDetectorStatus"></param>
        /// <returns></returns>
        int SetAntDetector(byte btReadId, byte btDetectorStatus);
        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetAntDetector(byte btReadId);
        /// <summary>
        /// 设置读ID
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="identifier"></param>
        /// <returns></returns>
        int SetReaderIdentifier(byte btReadId, byte[] identifier);
        /// <summary>
        /// 获取读ID
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetReaderIdentifier(byte btReadId);
        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btProfile"></param>
        /// <returns></returns>
        int SetLinkProfile(byte btReadId, byte btProfile);
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetLinkProfile(byte btReadId);
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int Reset(byte btReadId);
        /// <summary>
        /// 设置非同步收发传输器波特率
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="nIndexBaudrate"></param>
        /// <returns></returns>
        int SetUartBaudRate(byte btReadId, int nIndexBaudrate);
        /// <summary>
        /// 获取固件版本
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetFirmwareVersion(byte btReadId);
        /// <summary>
        /// 设置读地址
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btNewReadId"></param>
        /// <returns></returns>
        int SetReaderAddress(byte btReadId, byte btNewReadId);
        /// <summary>
        /// 设置工作天线
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btWorkAntenna"></param>
        /// <returns></returns>
        int SetWorkAntenna(byte btReadId, byte btWorkAntenna);
        /// <summary>
        /// 获取工作天线
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetWorkAntenna(byte btReadId);
        /// <summary>
        /// 设置输出性能
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btOutputPower"></param>
        /// <returns></returns>
        int SetOutputPower(byte btReadId, byte btOutputPower);
        /// <summary>
        /// 获取输出性能
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetOutputPower(byte btReadId);
        /// <summary>
        /// 设置频率区域
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btRegion"></param>
        /// <param name="btStart"></param>
        /// <param name="btInterval"></param>
        /// <param name="btChannelQuantity"></param>
        /// <returns></returns>
        int SetFrequencyRegion(byte btReadId, R600FreqRegionType btRegion, int btStart, byte btInterval, byte btChannelQuantity);
        /// <summary>
        /// 得到频率区域
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetFrequencyRegion(byte btReadId);
        /// <summary>
        /// 设置呼叫模式
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMode"></param>
        /// <returns></returns>
        int SetBeeperMode(byte btReadId, byte btMode);
        /// <summary>
        /// 得到工作温度
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetReaderTemperature(byte btReadId);
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btDrmMode"></param>
        /// <returns></returns>
        int SetDrmMode(byte btReadId, byte btDrmMode);
        /// <summary>
        /// 获取DRM模式
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetDrmMode(byte btReadId);
        /// <summary>
        /// 回波损耗测量
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btFrequency"></param>
        /// <returns></returns>
        [Obsolete("替代方案:GetImpedanceMatch")]
        int MeasureReturnLoss(byte btReadId, byte btFrequency);
        /// <summary>
        /// 获得阻抗匹配
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btFrequency"></param>
        /// <returns></returns>
        int GetImpedanceMatch(byte btReadId, byte btFrequency);
        /// <summary>
        /// 盘存
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="byRound"></param>
        /// <returns></returns>
        int Inventory(byte btReadId, byte byRound);
        /// <summary>
        /// 读标签
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMemBank"></param>
        /// <param name="btWordAdd"></param>
        /// <param name="btWordCnt"></param>
        /// <returns></returns>
        int ReadTag(byte btReadId, byte btMemBank, byte btWordAdd, byte btWordCnt);
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryPassWord"></param>
        /// <param name="btMemBank"></param>
        /// <param name="btWordAdd"></param>
        /// <param name="btWordCnt"></param>
        /// <param name="btAryData"></param>
        /// <returns></returns>
        int WriteTag(byte btReadId, byte[] btAryPassWord, byte btMemBank, byte btWordAdd, byte btWordCnt, byte[] btAryData);
        /// <summary>
        /// 锁定标签
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryPassWord"></param>
        /// <param name="btMembank"></param>
        /// <param name="btLockType"></param>
        /// <returns></returns>
        int LockTag(byte btReadId, byte[] btAryPassWord, byte btMembank, byte btLockType);
        /// <summary>
        /// 释放标记
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryPassWord"></param>
        /// <returns></returns>
        int KillTag(byte btReadId, byte[] btAryPassWord);
        /// <summary>
        /// 设置EPC(len = 0为1取消)
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMode"></param>
        /// <param name="btEpcLen"></param>
        /// <param name="btAryEpc"></param>
        /// <returns></returns>
        int SetAccessEpcMatch(byte btReadId, byte btMode, byte btEpcLen, byte[] btAryEpc);
        /// <summary>
        /// 获取EPC
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetAccessEpcMatch(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="byRound"></param>
        /// <returns></returns>
        int InventoryReal(byte btReadId, byte byRound);
        /// <summary>
        /// 快速存盘
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryData"></param>
        /// <returns></returns>
        int FastSwitchInventory(byte btReadId, byte[] btAryData);
        /// <summary>
        /// 自定义存盘
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="session"></param>
        /// <param name="target"></param>
        /// <param name="byRound"></param>
        /// <returns></returns>
        int CustomizedInventory(byte btReadId, byte session, byte target, byte byRound);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetMonzaStatus(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMonzaStatus"></param>
        /// <returns></returns>
        int SetMonzaStatus(byte btReadId, byte btMonzaStatus);
        /// <summary>
        /// 获取存盘
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetInventoryBuffer(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetAndResetInventoryBuffer(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetInventoryBufferTagCount(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int ResetInventoryBuffer(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btInterval"></param>
        /// <returns></returns>
        int SetBufferDataFrameInterval(byte btReadId, byte btInterval);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetBufferDataFrameInterval(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int InventoryISO18000(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryUID"></param>
        /// <param name="btWordAdd"></param>
        /// <param name="btWordCnt"></param>
        /// <returns></returns>
        int ReadTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryUID"></param>
        /// <param name="btWordAdd"></param>
        /// <param name="btWordCnt"></param>
        /// <param name="btAryBuffer"></param>
        /// <returns></returns>
        int WriteTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt, byte[] btAryBuffer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryUID"></param>
        /// <param name="btWordAdd"></param>
        /// <returns></returns>
        int LockTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryUID"></param>
        /// <param name="btWordAdd"></param>
        /// <returns></returns>
        int QueryTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd);
        /// <summary>
        /// 正在连接
        /// </summary>
        /// <returns></returns>
        bool IsConnecting();
        /// <summary>
        /// 关闭com口
        /// </summary>
        void Close();
    }
}
