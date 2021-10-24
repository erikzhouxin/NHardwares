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
        /// 
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
        int SetRadioProfile(byte btReadId, byte btProfile);
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetRadioProfile(byte btReadId);
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
        /// <param name="btStartRegion"></param>
        /// <param name="btEndRegion"></param>
        /// <returns></returns>
        int SetFrequencyRegion(byte btReadId, byte btRegion, byte btStartRegion, byte btEndRegion);
        /// <summary>
        /// 用户自定义频率
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="nStartFreq"></param>
        /// <param name="btFreqInterval"></param>
        /// <param name="btChannelQuantity"></param>
        /// <returns></returns>
        int SetUserDefineFrequency(byte btReadId, int nStartFreq, byte btFreqInterval, byte btChannelQuantity);
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
        int MeasureReturnLoss(byte btReadId, byte btFrequency);
        /// <summary>
        /// 获得阻抗匹配
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btFrequency"></param>
        /// <returns></returns>
        int GetAntImpedanceMatch(byte btReadId, byte btFrequency);
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
        /// 设置EPC
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMode"></param>
        /// <param name="btEpcLen"></param>
        /// <param name="btAryEpc"></param>
        /// <returns></returns>
        int SetAccessEpcMatch(byte btReadId, byte btMode, byte btEpcLen, byte[] btAryEpc);
        /// <summary>
        /// 取消EPC
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMode"></param>
        /// <returns></returns>
        int CancelAccessEpcMatch(byte btReadId, byte btMode);
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
    /// <summary>
    /// 读写器抽象类
    /// </summary>
    internal abstract class AR600Reader : IR600Reader
    {
        /// <summary>
        /// 接收回调
        /// </summary>
        public Action<Byte[]> ReceiveCallback { get; internal set; }
        /// <summary>
        /// 发送回调
        /// </summary>
        public Action<Byte[]> SendCallback { get; internal set; }
        /// <summary>
        /// 分析回调
        /// </summary>
        public Action<IR600Message> AnalysisCallback { get; internal set; }
        /// <summary>
        /// 回调模型
        /// </summary>
        protected IR600Recall _recall;
        /// <summary>
        /// 内部链接模型
        /// </summary>
        protected ITalkModel _talker;
        /// <summary>
        /// 记录未处理的接收数据，主要考虑接收数据分段
        /// </summary>
        protected byte[] m_btAryBuffer = new byte[4096];
        /// <summary>
        /// 记录未处理数据的有效长度
        /// </summary>
        protected int m_nLenth = 0;
        public abstract int Connect(string portName, int baudRate, out string exception);
        public abstract int Connect(IPAddress ip, int port, out string exception);
        /// <summary>
        /// 检查字节
        /// </summary>
        /// <param name="aryBuffer"></param>
        /// <param name="index"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static byte CheckByte(byte[] aryBuffer, int index, int len)
        {
            byte btSum = 0x00;
            for (int nloop = index; nloop < index + len; nloop++)
            {
                btSum += aryBuffer[nloop];
            }
            return Convert.ToByte(((~btSum) + 1) & 0xFF);
        }
        /// <summary>
        /// 读GPIO值
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int ReadGpioValue(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.ReadGpioValue);
        }
        /// <summary>
        /// 写GPIO值
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btChooseGpio"></param>
        /// <param name="btGpioValue"></param>
        /// <returns></returns>
        public virtual int WriteGpioValue(byte btReadId, byte btChooseGpio, byte btGpioValue)
        {
            return SendMessage(btReadId, R600CmdType.WriteGpioValue, new byte[2] { btChooseGpio, btGpioValue });
        }
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btDetectorStatus"></param>
        /// <returns></returns>
        public virtual int SetAntDetector(byte btReadId, byte btDetectorStatus)
        {
            return SendMessage(btReadId, R600CmdType.SetAntDetector, new byte[1] { btDetectorStatus });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetAntDetector(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.GetAntDetector);
        }
        /// <summary>
        /// 设置读ID
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public virtual int SetReaderIdentifier(byte btReadId, byte[] identifier)
        {
            return SendMessage(btReadId, R600CmdType.SetReaderIdentifier, identifier);
        }
        /// <summary>
        /// 获取读ID
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetReaderIdentifier(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.GetReaderIdentifier);
        }
        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btProfile"></param>
        /// <returns></returns>
        public virtual int SetRadioProfile(byte btReadId, byte btProfile)
        {
            return SendMessage(btReadId, R600CmdType.SetLinkProfile, new byte[1] { btProfile });
        }
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetRadioProfile(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.GetLinkProfile);
        }
        /// <summary>
        /// 复位读写器
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int Reset(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.Reset);
        }
        /// <summary>
        /// 设置非同步收发传输器波特率
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="nIndexBaudrate"></param>
        /// <returns></returns>
        public virtual int SetUartBaudRate(byte btReadId, int nIndexBaudrate)
        {
            return SendMessage(btReadId, R600CmdType.SetUartBaudRate, new byte[1] { Convert.ToByte(nIndexBaudrate) });
        }
        /// <summary>
        /// 获取固件版本
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetFirmwareVersion(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.GetFirmwareVersion);
        }
        /// <summary>
        /// 设置读地址
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btNewReadId"></param>
        /// <returns></returns>
        public virtual int SetReaderAddress(byte btReadId, byte btNewReadId)
        {
            return SendMessage(btReadId, R600CmdType.SetReaderAddress, new byte[1] { btNewReadId });
        }
        /// <summary>
        /// 设置工作天线
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btWorkAntenna"></param>
        /// <returns></returns>
        public virtual int SetWorkAntenna(byte btReadId, byte btWorkAntenna)
        {
            return SendMessage(btReadId, R600CmdType.SetWorkAntenna, new byte[1] { btWorkAntenna });
        }
        /// <summary>
        /// 获取工作天线
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetWorkAntenna(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.GetWorkAntenna);
        }
        /// <summary>
        /// 设置输出性能
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btOutputPower"></param>
        /// <returns></returns>
        public virtual int SetOutputPower(byte btReadId, byte btOutputPower)
        {
            return SendMessage(btReadId, R600CmdType.SetOutputPower, new byte[1] { btOutputPower });
        }
        /// <summary>
        /// 获取输出性能
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetOutputPower(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.GetOutputPower);
        }
        /// <summary>
        /// 设置频率区域
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btRegion"></param>
        /// <param name="btStartRegion"></param>
        /// <param name="btEndRegion"></param>
        /// <returns></returns>
        public virtual int SetFrequencyRegion(byte btReadId, byte btRegion, byte btStartRegion, byte btEndRegion)
        {
            return SendMessage(btReadId, R600CmdType.SetFrequencyRegion, new byte[3] { btRegion, btStartRegion, btEndRegion });
        }
        /// <summary>
        /// 用户自定义频率
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="nStartFreq"></param>
        /// <param name="btFreqInterval"></param>
        /// <param name="btChannelQuantity"></param>
        /// <returns></returns>
        public virtual int SetUserDefineFrequency(byte btReadId, int nStartFreq, byte btFreqInterval, byte btChannelQuantity)
        {
            byte[] btAryData = new byte[6];
            btAryData[0] = 4;
            btAryData[1] = btFreqInterval;
            btAryData[2] = btChannelQuantity;
            byte[] btAryFreq = BitConverter.GetBytes(nStartFreq);
            btAryData[3] = btAryFreq[2];
            btAryData[4] = btAryFreq[1];
            btAryData[5] = btAryFreq[0];

            return SendMessage(btReadId, R600CmdType.SetFrequencyRegion, btAryData);
        }
        /// <summary>
        /// 得到频率区域
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetFrequencyRegion(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.GetFrequencyRegion);
        }
        /// <summary>
        /// 设置呼叫模式
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMode"></param>
        /// <returns></returns>
        public virtual int SetBeeperMode(byte btReadId, byte btMode)
        {
            return SendMessage(btReadId, R600CmdType.SetBeeperMode, new byte[1] { btMode });
        }
        /// <summary>
        /// 得到工作温度
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetReaderTemperature(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.GetReaderTemperature);
        }
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btDrmMode"></param>
        /// <returns></returns>
        public virtual int SetDrmMode(byte btReadId, byte btDrmMode)
        {
            return SendMessage(btReadId, R600CmdType.SetDrmMode, new byte[1] { btDrmMode });
        }
        /// <summary>
        /// 获取DRM模式
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetDrmMode(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.GetDrmMode);
        }
        /// <summary>
        /// 回波损耗测量
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btFrequency"></param>
        /// <returns></returns>
        [Obsolete("替代方案:GetAntImpedanceMatch")]
        public virtual int MeasureReturnLoss(byte btReadId, byte btFrequency)
        {
            return SendMessage(btReadId, R600CmdType.GetAntImpedanceMatch, new byte[1] { btFrequency });
        }
        /// <summary>
        /// 获得阻抗匹配
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btFrequency"></param>
        /// <returns></returns>
        public virtual int GetAntImpedanceMatch(byte btReadId, byte btFrequency)
        {
            return SendMessage(btReadId, R600CmdType.GetAntImpedanceMatch, new byte[1] { btFrequency });
        }
        /// <summary>
        /// 盘存
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="byRound"></param>
        /// <returns></returns>
        public virtual int Inventory(byte btReadId, byte byRound)
        {
            return SendMessage(btReadId, R600CmdType.Inventory, new byte[1] { byRound });
        }
        /// <summary>
        /// 读标签
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMemBank"></param>
        /// <param name="btWordAdd"></param>
        /// <param name="btWordCnt"></param>
        /// <returns></returns>
        public virtual int ReadTag(byte btReadId, byte btMemBank, byte btWordAdd, byte btWordCnt)
        {
            return SendMessage(btReadId, R600CmdType.ReadTag, new byte[3] { btMemBank, btWordAdd, btWordCnt });
        }
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
        public virtual int WriteTag(byte btReadId, byte[] btAryPassWord, byte btMemBank, byte btWordAdd, byte btWordCnt, byte[] btAryData)
        {
            byte[] btAryBuffer = new byte[btAryData.Length + 7];
            btAryPassWord.CopyTo(btAryBuffer, 0);
            btAryBuffer[4] = btMemBank;
            btAryBuffer[5] = btWordAdd;
            btAryBuffer[6] = btWordCnt;
            btAryData.CopyTo(btAryBuffer, 7);
            return SendMessage(btReadId, R600CmdType.WriteTag, btAryBuffer);
        }
        /// <summary>
        /// 锁定标签
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryPassWord"></param>
        /// <param name="btMembank"></param>
        /// <param name="btLockType"></param>
        /// <returns></returns>
        public virtual int LockTag(byte btReadId, byte[] btAryPassWord, byte btMembank, byte btLockType)
        {
            byte[] btAryData = new byte[6];
            btAryPassWord.CopyTo(btAryData, 0);
            btAryData[4] = btMembank;
            btAryData[5] = btLockType;
            return SendMessage(btReadId, R600CmdType.LockTag, btAryData);
        }
        /// <summary>
        /// 释放标记
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryPassWord"></param>
        /// <returns></returns>
        public virtual int KillTag(byte btReadId, byte[] btAryPassWord)
        {
            byte[] btAryData = new byte[4];
            btAryPassWord.CopyTo(btAryData, 0);
            return SendMessage(btReadId, R600CmdType.KillTag, btAryData);
        }
        /// <summary>
        /// 设置EPC
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMode"></param>
        /// <param name="btEpcLen"></param>
        /// <param name="btAryEpc"></param>
        /// <returns></returns>
        public virtual int SetAccessEpcMatch(byte btReadId, byte btMode, byte btEpcLen, byte[] btAryEpc)
        {
            int nLen = Convert.ToInt32(btEpcLen) + 2;
            byte[] btAryData = new byte[nLen];
            btAryData[0] = btMode;
            btAryData[1] = btEpcLen;
            btAryEpc.CopyTo(btAryData, 2);
            return SendMessage(btReadId, R600CmdType.SetAccessEpcMatch, btAryData);
        }
        /// <summary>
        /// 取消EPC
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMode"></param>
        /// <returns></returns>
        public virtual int CancelAccessEpcMatch(byte btReadId, byte btMode)
        {
            return SendMessage(btReadId, R600CmdType.SetAccessEpcMatch, new byte[1] { btMode });
        }
        /// <summary>
        /// 获取EPC
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetAccessEpcMatch(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.GetAccessEpcMatch);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="byRound"></param>
        /// <returns></returns>
        public virtual int InventoryReal(byte btReadId, byte byRound)
        {
            return SendMessage(btReadId, R600CmdType.InventoryReal, new byte[1] { byRound });
        }
        /// <summary>
        /// 快速存盘
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryData"></param>
        /// <returns></returns>
        public virtual int FastSwitchInventory(byte btReadId, byte[] btAryData)
        {
            return SendMessage(btReadId, R600CmdType.FastSwitchInventory, btAryData);
        }
        /// <summary>
        /// 自定义存盘
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="session"></param>
        /// <param name="target"></param>
        /// <param name="byRound"></param>
        /// <returns></returns>
        public virtual int CustomizedInventory(byte btReadId, byte session, byte target, byte byRound)
        {
            return SendMessage(btReadId, R600CmdType.CustomizedInventory, new byte[3] { session, target, byRound });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetMonzaStatus(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.GetMonzaStatus);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMonzaStatus"></param>
        /// <returns></returns>
        public virtual int SetMonzaStatus(byte btReadId, byte btMonzaStatus)
        {
            return SendMessage(btReadId, R600CmdType.SetMonzaStatus, new byte[1] { btMonzaStatus });
        }
        /// <summary>
        /// 获取存盘
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetInventoryBuffer(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.GetInventoryBuffer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetAndResetInventoryBuffer(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.GetAndResetInventoryBuffer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetInventoryBufferTagCount(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.GetInventoryBufferTagCount);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int ResetInventoryBuffer(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.ResetInventoryBuffer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btInterval"></param>
        /// <returns></returns>
        public virtual int SetBufferDataFrameInterval(byte btReadId, byte btInterval)
        {
            return SendMessage(btReadId, R600CmdType.SetBufferDataFrameInterval, new byte[1] { btInterval });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetBufferDataFrameInterval(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.GetBufferDataFrameInterval);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int InventoryISO18000(byte btReadId)
        {
            return SendMessage(btReadId, R600CmdType.InventoryISO18000);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryUID"></param>
        /// <param name="btWordAdd"></param>
        /// <param name="btWordCnt"></param>
        /// <returns></returns>
        public virtual int ReadTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt)
        {
            int nLen = btAryUID.Length + 2;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[nLen - 2] = btWordAdd;
            btAryData[nLen - 1] = btWordCnt;
            return SendMessage(btReadId, R600CmdType.ReadTagISO18000, btAryData);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryUID"></param>
        /// <param name="btWordAdd"></param>
        /// <param name="btWordCnt"></param>
        /// <param name="btAryBuffer"></param>
        /// <returns></returns>
        public virtual int WriteTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt, byte[] btAryBuffer)
        {
            int nLen = btAryUID.Length + 2 + btAryBuffer.Length;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[btAryUID.Length] = btWordAdd;
            btAryData[btAryUID.Length + 1] = btWordCnt;
            btAryBuffer.CopyTo(btAryData, btAryUID.Length + 2);
            return SendMessage(btReadId, R600CmdType.WriteTagISO18000, btAryData);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryUID"></param>
        /// <param name="btWordAdd"></param>
        /// <returns></returns>
        public virtual int LockTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd)
        {
            int nLen = btAryUID.Length + 1;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[nLen - 1] = btWordAdd;
            return SendMessage(btReadId, R600CmdType.LockTagISO18000, btAryData);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryUID"></param>
        /// <param name="btWordAdd"></param>
        /// <returns></returns>
        public virtual int QueryTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd)
        {
            int nLen = btAryUID.Length + 1;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[nLen - 1] = btWordAdd;
            return SendMessage(btReadId, R600CmdType.QueryTagISO18000, btAryData);
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btCmd"></param>
        /// <param name="btAryData"></param>
        /// <returns></returns>
        public virtual int SendMessage(byte btReadId, R600CmdType btCmd, byte[] btAryData = null)
        {
            return SendMessage(btReadId, (byte)btCmd, btAryData);
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btCmd"></param>
        /// <param name="btAryData"></param>
        /// <returns></returns>
        public virtual int SendMessage(byte btReadId, byte btCmd, byte[] btAryData = null)
        {
            byte[] data;
            if (btAryData == null)
            {
                data = new byte[5];
                data[0] = 0xA0;
                data[1] = 0x03;
                data[2] = btReadId;
                data[3] = btCmd;
                data[4] = CheckByte(data, 0, 4);
            }
            else
            {
                int nLen = btAryData.Length;
                data = new byte[nLen + 5];
                data[0] = 0xA0;
                data[1] = Convert.ToByte(nLen + 3);
                data[2] = btReadId;
                data[3] = btCmd;
                btAryData.CopyTo(data, 4);
                data[nLen + 4] = CheckByte(data, 0, nLen + 4);
            }
            if (_talker.Send(data))
            {
                SendCallback?.Invoke(data);
                return 0;
            }
            return -1;
        }
        /// <summary>
        /// 正在连接
        /// </summary>
        /// <returns></returns>
        public virtual bool IsConnecting()
        {
            return _talker.IsConnect();
        }
        public virtual void Close()
        {
            _talker.Dispose();
        }
        /// <summary>
        /// 释放
        /// 1.断开连接
        /// </summary>
        public virtual void Dispose()
        {
            Close();
        }
        /// <summary>
        /// 注册回调
        /// </summary>
        public virtual void RegistCallback(IR600Recall model)
        {
            _recall = model;
            SendCallback = model.SendCallback;
            ReceiveCallback = model.ReceiveCallback;
        }
        #region // 内部类
        /// <summary>
        /// 对话模型接口
        /// </summary>
        protected interface ITalkModel : IDisposable
        {
            /// <summary>
            /// 接收到发来的消息
            /// </summary>
            event Action<byte[]> Received;
            /// <summary>
            /// 连接到服务端
            /// </summary>
            /// <param name="ip">IP地址</param>
            /// <param name="port">端口号</param>
            /// <param name="message">消息提示</param>
            /// <returns></returns>
            bool Connect(IPAddress ip, int port, out string message);
            /// <summary>
            /// 连接到服务端
            /// </summary>
            /// <param name="portName">串口号</param>
            /// <param name="bautRate">波特率</param>
            /// <param name="message">消息提示</param>
            /// <returns></returns>
            bool Connect(string portName, int bautRate, out string message);
            /// <summary>
            /// 发送数据包
            /// </summary>
            /// <param name="aryBuffer"></param>
            /// <returns></returns>
            bool Send(byte[] aryBuffer);
            /// <summary>
            /// 注销连接
            /// </summary>
            void Exit();
            /// <summary>
            /// 校验是否连接服务器
            /// </summary>
            /// <returns></returns>
            bool IsConnect();
        }
        /// <summary>
        /// 对话模型
        /// </summary>
        protected class TalkModel : ITalkModel
        {
            /// <summary>
            /// 接收事件
            /// </summary>
            public virtual event Action<byte[]> Received;
            /// <summary>
            /// 链接
            /// </summary>
            /// <param name="ip"></param>
            /// <param name="port"></param>
            /// <param name="message"></param>
            /// <returns></returns>
            public virtual bool Connect(IPAddress ip, int port, out string message)
            {
                message = "接口未实现";
                return false;
            }
            /// <summary>
            /// 链接
            /// </summary>
            /// <param name="portName"></param>
            /// <param name="bautRate"></param>
            /// <param name="message"></param>
            /// <returns></returns>
            public virtual bool Connect(string portName, int bautRate, out string message)
            {
                message = "接口未实现";
                return false;
            }
            /// <summary>
            /// 释放资源
            /// </summary>
            public virtual void Dispose()
            {

            }

            /// <summary>
            /// 退出
            /// </summary>
            public virtual void Exit()
            {

            }
            /// <summary>
            /// 已连接
            /// </summary>
            /// <returns></returns>
            public virtual bool IsConnect()
            {
                return false;
            }
            /// <summary>
            /// 发送
            /// </summary>
            /// <param name="aryBuffer"></param>
            /// <returns></returns>
            public virtual bool Send(byte[] aryBuffer)
            {
                return false;
            }
        }
        /// <summary>
        /// TCP连接模型
        /// </summary>
        protected class TcpTalkModel : TalkModel, ITalkModel
        {
            public override event Action<byte[]> Received;
            TcpClient client;
            Stream streamToTran;
            private Thread waitThread;
            private bool bIsConnect = false;
            /// <summary>
            /// 连接
            /// </summary>
            /// <param name="ipAddress"></param>
            /// <param name="port"></param>
            /// <param name="message"></param>
            /// <returns></returns>
            public override bool Connect(IPAddress ipAddress, int port, out string message)
            {
                message = string.Empty;
                try
                {
                    client = new TcpClient();
                    client.Connect(ipAddress, port);
                    streamToTran = client.GetStream();    // 获取连接至远程的流

                    //建立线程收取服务器发送数据
                    ThreadStart stThead = new(ReceivedData);
                    waitThread = new Thread(stThead)
                    {
                        IsBackground = true
                    };
                    waitThread.Start();

                    bIsConnect = true;
                    return true;
                }
                catch (System.Exception ex)
                {
                    message = ex.Message;
                    bIsConnect = false;
                    return false;
                }
            }

            private void ReceivedData()
            {
                while (true)
                {
                    try
                    {
                        byte[] btAryBuffer = new byte[4096];
                        int nLenRead = streamToTran.Read(btAryBuffer, 0, btAryBuffer.Length);
                        if (nLenRead == 0) { continue; }
                        if (Received != null)
                        {
                            byte[] btAryReceiveData = new byte[nLenRead];
                            Array.Copy(btAryBuffer, btAryReceiveData, nLenRead);
                            Received(btAryReceiveData);
                        }
                    }
                    catch { }
                }
            }
            /// <summary>
            /// 发送
            /// </summary>
            /// <param name="aryBuffer"></param>
            /// <returns></returns>
            public override bool Send(byte[] aryBuffer)
            {
                try
                {
                    if (!bIsConnect) { return false; }
                    lock (streamToTran)
                    {
                        streamToTran.Write(aryBuffer, 0, aryBuffer.Length);
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            /// <summary>
            /// 退出
            /// </summary>
            public override void Exit()
            {
                streamToTran?.Dispose();
                client?.Close();
                waitThread.Abort();
                bIsConnect = false;
            }
            /// <summary>
            /// 是连接
            /// </summary>
            /// <returns></returns>
            public override bool IsConnect()
            {
                return bIsConnect;
            }
            public override void Dispose()
            {
                base.Dispose();
                Exit();
            }
        }
        /// <summary>
        /// 串口连接模型
        /// </summary>
        protected class SerialTalkModel : TalkModel, ITalkModel
        {
            public override event Action<byte[]> Received;
            SerialPort serialPort;
            public SerialTalkModel()
            {
                serialPort = new SerialPort();
                serialPort.DataReceived += ISerialPort_DataReceived;
            }

            private void ISerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                try
                {
                    int nCount = serialPort.BytesToRead;
                    if (nCount == 0) { return; }
                    byte[] btAryBuffer = new byte[nCount];
                    serialPort.Read(btAryBuffer, 0, nCount);
                    if (Received != null)
                    {
                        Received(btAryBuffer);
                    }
                }
                catch { }
            }

            public override bool Connect(string portName, int bautRate, out string message)
            {
                message = string.Empty;
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                try
                {
                    serialPort.PortName = portName;
                    serialPort.BaudRate = bautRate;
                    serialPort.ReadTimeout = 200;
                    serialPort.Open();
                }
                catch (System.Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
                return true;
            }

            public override void Exit()
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
            }

            public override bool IsConnect()
            {
                return serialPort.IsOpen;
            }

            public override bool Send(byte[] aryBuffer)
            {
                if (!serialPort.IsOpen) { return false; }
                serialPort.Write(aryBuffer, 0, aryBuffer.Length);
                return true;
            }
            public override void Dispose()
            {
                base.Dispose();
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                serialPort.Dispose();
            }
        }
        #endregion
    }
}
