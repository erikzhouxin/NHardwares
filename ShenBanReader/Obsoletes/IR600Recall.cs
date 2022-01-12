using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 回调方法接口
    /// </summary>
    public interface IR600Recall
    {
        /// <summary>
        /// 发送回调
        /// </summary>
        /// <param name="aryData"></param>
        void SendCallback(byte[] aryData);
        /// <summary>
        /// 接收回调
        /// </summary>
        /// <param name="aryData"></param>
        void ReceiveCallback(byte[] aryData);
        /// <summary>
        /// 未知的数据包类型处理
        /// </summary>
        /// <param name="msgTran"></param>
        void AlertUnknownPacketType(IReadMessage msgTran);
        /// <summary>
        /// 提示错误
        /// </summary>
        /// <param name="alert"></param>
        void AlertError(ReadAlertError alert);
        /// <summary>
        /// 提示回调错误
        /// </summary>
        /// <param name="ex"></param>
        void AlertCallbackError(Exception ex);
        /// <summary>
        /// 读取GPIO状态
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="gpio1Value"></param>
        /// <param name="gpio2Value"></param>
        /// <param name="isGpio1Low"></param>
        /// <param name="isGpio2Low"></param>
        void ReadGpioValue(IReadMessage msgTran, byte gpio1Value, byte gpio2Value, bool isGpio1Low, bool isGpio2Low);
        /// <summary>
        /// 设置GPIO状态
        /// </summary>
        /// <param name="msgTran"></param>
        void WriteGpioValue(IReadMessage msgTran);
        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        /// <param name="msgTran"></param>
        void SetAntDetector(IReadMessage msgTran);
        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        void GetAntDetector(IReadMessage msgTran, byte antDetector);
        /// <summary>
        /// 设置读写器识别标记
        /// </summary>
        /// <param name="msgTran"></param>
        void SetReaderIdentifier(IReadMessage msgTran);
        /// <summary>
        /// 读取读写器识别标记
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="aryData"></param>
        void GetReaderIdentifier(IReadMessage msgTran, byte[] aryData);
        /// <summary>
        /// 设置射频通讯链路配置
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="linkProfile"></param>
        void SetLinkProfile(IReadMessage msgTran, byte linkProfile);
        /// <summary>
        /// 读取射频通讯链路配置
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="profileType"></param>
        void GetLinkProfile(IReadMessage msgTran, ReadLinkProfileType profileType);
        /// <summary>
        /// 设置波特率
        /// </summary>
        /// <param name="msgTran"></param>
        void SetUartBaudRate(IReadMessage msgTran);
        /// <summary>
        /// 取得读写器版本号
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        void GetFirmwareVersion(IReadMessage msgTran, byte major, byte minor);
        /// <summary>
        /// 设置读写器地址
        /// </summary>
        /// <param name="msgTran"></param>
        void SetReaderAddress(IReadMessage msgTran);
        /// <summary>
        /// 设置工作天线
        /// </summary>
        /// <param name="msgTran"></param>
        void SetWorkAntenna(IReadMessage msgTran);
        /// <summary>
        /// 取得工作天线
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antennaType"></param>
        void GetWorkAntenna(IReadMessage msgTran, ReadAntennaType antennaType);
        /// <summary>
        /// 设置输出功率
        /// </summary>
        /// <param name="msgTran"></param>
        void SetOutputPower(IReadMessage msgTran);
        /// <summary>
        /// 获取输出功率
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="outputPower"></param>
        void GetOutputPower(IReadMessage msgTran, byte outputPower);
        /// <summary>
        /// 设置射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        void SetFrequencyRegion(IReadMessage msgTran);
        /// <summary>
        /// 获取射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="frequencyType"></param>
        /// <param name="start"></param>
        /// <param name="interval"></param>
        /// <param name="chanelQuantity"></param>
        void GetFrequencyRegion(IReadMessage msgTran, ReadFreqRegionType frequencyType, int start, byte interval, byte chanelQuantity);
        /// <summary>
        /// 设置蜂鸣器模式
        /// </summary>
        /// <param name="msgTran"></param>
        void SetBeeperMode(IReadMessage msgTran);
        /// <summary>
        /// 取得读写器温度
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="temperature"></param>
        void GetReaderTemperature(IReadMessage msgTran, int temperature);
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        /// <param name="msgTran"></param>
        void SetDrmMode(IReadMessage msgTran);
        /// <summary>
        /// 取得DRM模式
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="isOpen"></param>
        void GetDrmMode(IReadMessage msgTran, bool isOpen);
        /// <summary>
        /// 测量天线端口阻抗匹配
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antImpedance"></param>
        void GetImpedanceMatch(IReadMessage msgTran, byte antImpedance);
        /// <summary>
        /// 盘存标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="currentAnt"></param>
        /// <param name="tagCount"></param>
        /// <param name="readRate"></param>
        /// <param name="totalRead"></param>
        /// <param name="duration"></param>
        void Inventory(IReadMessage msgTran, byte currentAnt, int tagCount, int readRate, int totalRead, int duration);
        /// <summary>
        /// 读标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void ReadTag(IReadMessage msgTran, R600TagInfo model);
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void WriteTag(IReadMessage msgTran, R600TagInfo model);
        /// <summary>
        /// 锁定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void LockTag(IReadMessage msgTran, R600TagInfo model);
        /// <summary>
        /// 销毁标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void KillTag(IReadMessage msgTran, R600TagInfo model);
        /// <summary>
        /// 选定/取消选定标签
        /// </summary>
        /// <param name="msgTran"></param>
        void SetAccessEpcMatch(IReadMessage msgTran);
        /// <summary>
        /// 取得选定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="data"></param>
        void GetAccessEpcMatch(IReadMessage msgTran, byte[] data);
        /// <summary>
        /// 实时盘存(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void InventoryReal(IReadMessage msgTran, R600TagInfo model);
        /// <summary>
        /// 实时盘存(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="readRate"></param>
        /// <param name="dataCount"></param>
        void InventoryRealEnd(IReadMessage msgTran, int readRate, int dataCount);
        /// <summary>
        /// 快速4天线盘存(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void FastSwitchInventory(IReadMessage msgTran, R600TagInfo model);
        /// <summary>
        /// 快速4天线盘存(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="dataCount"></param>
        /// <param name="cmdDuration"></param>
        void FastSwitchInventoryEnd(IReadMessage msgTran, int dataCount, int cmdDuration);
        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        void SetMonzaStatus(IReadMessage msgTran, byte antDetector);
        /// <summary>
        /// 读取Impinj Monza快速读TID功能
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        void GetMonzaStatus(IReadMessage msgTran, byte antDetector);
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void GetInventoryBuffer(IReadMessage msgTran, R600TagInfo model);
        /// <summary>
        /// 读取清空缓存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void GetAndResetInventoryBuffer(IReadMessage msgTran, R600TagInfo model);
        /// <summary>
        /// 读取缓存标签数量
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="tagCount"></param>
        void GetInventoryBufferTagCount(IReadMessage msgTran, int tagCount);
        /// <summary>
        /// 清空缓存
        /// </summary>
        void ResetInventoryBuffer(IReadMessage msgTran);
        /// <summary>
        /// 盘存标签(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void InventoryISO18000(IReadMessage msgTran, R600TagInfoIso18000 model);
        /// <summary>
        /// 盘存标签(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="tagCnt"></param>
        void InventoryISO18000End(IReadMessage msgTran, int tagCnt);
        /// <summary>
        /// 读取标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="data"></param>
        void ReadTagISO18000(IReadMessage msgTran, byte antId, byte[] data);
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="length"></param>
        void WriteTagISO18000(IReadMessage msgTran, byte antId, byte length);
        /// <summary>
        /// 永久写保护
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="status"></param>
        void LockTagISO18000(IReadMessage msgTran, byte antId, ReadLockTagStatus status);
        /// <summary>
        /// 查询标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="status"></param>
        void QueryTagISO18000(IReadMessage msgTran, byte antId, ReadLockTagStatus status);
    }
    /// <summary>
    /// 回调方法抽象类
    /// </summary>
    public abstract class AR600Recall : IR600Recall, IR600Callback
    {
        #region // 回调委托接口
        /// <summary>
        /// 发送回调
        /// </summary>
        Action<byte[]> IR600Callback.SendCallback { get => SendCallback; set { } }
        /// <summary>
        /// 接收回调
        /// </summary>
        Action<byte[]> IR600Callback.ReceiveCallback { get => ReceiveCallback; set { } }
        /// <summary>
        /// 未知的数据包类型处理
        /// </summary>
        Action<IReadMessage> IR600Callback.AlertUnknownPacketType { get => AlertUnknownPacketType; set { } }
        /// <summary>
        /// 提示错误
        /// </summary>
        Action<ReadAlertError> IR600Callback.AlertError { get => AlertError; set { } }
        /// <summary>
        /// 提示回调错误
        /// </summary>
        Action<Exception> IR600Callback.AlertCallbackError { get => AlertCallbackError; set { } }
        /// <summary>
        /// 读取GPIO状态
        /// </summary>
        Action<IReadMessage, byte, byte, bool, bool> IR600Callback.ReadGpioValue { get => ReadGpioValue; set { } }
        /// <summary>
        /// 设置GPIO状态
        /// </summary>
        Action<IReadMessage> IR600Callback.WriteGpioValue { get => WriteGpioValue; set { } }
        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        Action<IReadMessage> IR600Callback.SetAntDetector { get => SetAntDetector; set { } }
        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        Action<IReadMessage, byte> IR600Callback.GetAntDetector { get => GetAntDetector; set { } }
        /// <summary>
        /// 设置读写器识别标记
        /// </summary>
        Action<IReadMessage> IR600Callback.SetReaderIdentifier { get => SetReaderIdentifier; set { } }
        /// <summary>
        /// 读取读写器识别标记
        /// </summary>
        Action<IReadMessage, byte[]> IR600Callback.GetReaderIdentifier { get => GetReaderIdentifier; set { } }
        /// <summary>
        /// 设置射频通讯链路配置
        /// </summary>
        Action<IReadMessage, byte> IR600Callback.SetLinkProfile { get => SetLinkProfile; set { } }
        /// <summary>
        /// 读取射频通讯链路配置
        /// </summary>
        Action<IReadMessage, ReadLinkProfileType> IR600Callback.GetLinkProfile { get => GetLinkProfile; set { } }
        /// <summary>
        /// 设置波特率
        /// </summary>
        Action<IReadMessage> IR600Callback.SetUartBaudRate { get => SetUartBaudRate; set { } }
        /// <summary>
        /// 取得读写器版本号
        /// </summary>
        Action<IReadMessage, byte, byte> IR600Callback.GetFirmwareVersion { get => GetFirmwareVersion; set { } }
        /// <summary>
        /// 设置读写器地址
        /// </summary>
        Action<IReadMessage> IR600Callback.SetReaderAddress { get => SetReaderAddress; set { } }
        /// <summary>
        /// 设置工作天线
        /// </summary>
        Action<IReadMessage> IR600Callback.SetWorkAntenna { get => SetWorkAntenna; set { } }
        /// <summary>
        /// 取得工作天线
        /// </summary>
        Action<IReadMessage, ReadAntennaType> IR600Callback.GetWorkAntenna { get => GetWorkAntenna; set { } }
        /// <summary>
        /// 设置输出功率
        /// </summary>
        Action<IReadMessage> IR600Callback.SetOutputPower { get => SetOutputPower; set { } }
        /// <summary>
        /// 获取输出功率
        /// </summary>
        Action<IReadMessage, byte> IR600Callback.GetOutputPower { get => GetOutputPower; set { } }
        /// <summary>
        /// 设置射频规范
        /// </summary>
        Action<IReadMessage> IR600Callback.SetFrequencyRegion { get => SetFrequencyRegion; set { } }
        /// <summary>
        /// 获取射频规范
        /// </summary>
        Action<IReadMessage, ReadFreqRegionType, int, byte, byte> IR600Callback.GetFrequencyRegion { get => GetFrequencyRegion; set { } }
        /// <summary>
        /// 设置蜂鸣器模式
        /// </summary>
        Action<IReadMessage> IR600Callback.SetBeeperMode { get => SetBeeperMode; set { } }
        /// <summary>
        /// 取得读写器温度
        /// </summary>
        Action<IReadMessage, int> IR600Callback.GetReaderTemperature { get => GetReaderTemperature; set { } }
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        Action<IReadMessage> IR600Callback.SetDrmMode { get => SetDrmMode; set { } }
        /// <summary>
        /// 取得DRM模式
        /// </summary>
        Action<IReadMessage, bool> IR600Callback.GetDrmMode { get => GetDrmMode; set { } }
        /// <summary>
        /// 测量天线端口阻抗匹配
        /// </summary>
        Action<IReadMessage, byte> IR600Callback.GetImpedanceMatch { get => GetImpedanceMatch; set { } }
        /// <summary>
        /// 盘存标签
        /// </summary>
        Action<IReadMessage, byte, int, int, int, int> IR600Callback.Inventory { get => Inventory; set { } }
        /// <summary>
        /// 读标签
        /// </summary>
        Action<IReadMessage, R600TagInfo> IR600Callback.ReadTag { get => ReadTag; set { } }
        /// <summary>
        /// 写标签
        /// </summary>
        Action<IReadMessage, R600TagInfo> IR600Callback.WriteTag { get => WriteTag; set { } }
        /// <summary>
        /// 锁定标签
        /// </summary>
        Action<IReadMessage, R600TagInfo> IR600Callback.LockTag { get => LockTag; set { } }
        /// <summary>
        /// 销毁标签
        /// </summary>
        Action<IReadMessage, R600TagInfo> IR600Callback.KillTag { get => KillTag; set { } }
        /// <summary>
        /// 选定/取消选定标签
        /// </summary>
        Action<IReadMessage> IR600Callback.SetAccessEpcMatch { get => SetAccessEpcMatch; set { } }
        /// <summary>
        /// 取得选定标签
        /// </summary>
        Action<IReadMessage, byte[]> IR600Callback.GetAccessEpcMatch { get => GetAccessEpcMatch; set { } }
        /// <summary>
        /// 实时盘存(单个)
        /// </summary>
        Action<IReadMessage, R600TagInfo> IR600Callback.InventoryReal { get => InventoryReal; set { } }
        /// <summary>
        /// 实时盘存(完成)
        /// </summary>
        Action<IReadMessage, int, int> IR600Callback.InventoryRealEnd { get => InventoryRealEnd; set { } }
        /// <summary>
        /// 快速4天线盘存(单个)
        /// </summary>
        Action<IReadMessage, R600TagInfo> IR600Callback.FastSwitchInventory { get => FastSwitchInventory; set { } }
        /// <summary>
        /// 快速4天线盘存(完成)
        /// </summary>
        Action<IReadMessage, int, int> IR600Callback.FastSwitchInventoryEnd { get => FastSwitchInventoryEnd; set { } }
        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// </summary>
        Action<IReadMessage, byte> IR600Callback.SetMonzaStatus { get => SetMonzaStatus; set { } }
        /// <summary>
        /// 读取Impinj Monza快速读TID功能
        /// </summary>
        Action<IReadMessage, byte> IR600Callback.GetMonzaStatus { get => GetMonzaStatus; set { } }
        /// <summary>
        /// 读取缓存
        /// </summary>
        Action<IReadMessage, R600TagInfo> IR600Callback.GetInventoryBuffer { get => GetInventoryBuffer; set { } }
        /// <summary>
        /// 读取清空缓存
        /// </summary>
        Action<IReadMessage, R600TagInfo> IR600Callback.GetAndResetInventoryBuffer { get => GetAndResetInventoryBuffer; set { } }
        /// <summary>
        /// 读取缓存标签数量
        /// </summary>
        Action<IReadMessage, int> IR600Callback.GetInventoryBufferTagCount { get => GetInventoryBufferTagCount; set { } }
        /// <summary>
        /// 清空缓存
        /// </summary>
        Action<IReadMessage> IR600Callback.ResetInventoryBuffer { get => ResetInventoryBuffer; set { } }
        /// <summary>
        /// 盘存标签(单个)
        /// </summary>
        Action<IReadMessage, R600TagInfoIso18000> IR600Callback.InventoryISO18000 { get => InventoryISO18000; set { } }
        /// <summary>
        /// 盘存标签(完成)
        /// </summary>
        Action<IReadMessage, int> IR600Callback.InventoryISO18000End { get => InventoryISO18000End; set { } }
        /// <summary>
        /// 读取标签
        /// </summary>
        Action<IReadMessage, byte, byte[]> IR600Callback.ReadTagISO18000 { get => ReadTagISO18000; set { } }
        /// <summary>
        /// 写标签
        /// </summary>
        Action<IReadMessage, byte, byte> IR600Callback.WriteTagISO18000 { get => WriteTagISO18000; set { } }
        /// <summary>
        /// 永久写保护
        /// </summary>
        Action<IReadMessage, byte, ReadLockTagStatus> IR600Callback.LockTagISO18000 { get => LockTagISO18000; set { } }
        /// <summary>
        /// 查询标签
        /// </summary>
        Action<IReadMessage, byte, ReadLockTagStatus> IR600Callback.QueryTagISO18000 { get => QueryTagISO18000; set { } }
        #endregion

        #region // 回调方法接口
        /// <summary>
        /// 发送回调
        /// </summary>
        /// <param name="aryData"></param>
        public virtual void SendCallback(byte[] aryData)
        {
        }
        /// <summary>
        /// 接收回调
        /// </summary>
        /// <param name="aryData"></param>
        public virtual void ReceiveCallback(byte[] aryData)
        {
        }
        /// <summary>
        /// 未知的数据包类型处理
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void AlertUnknownPacketType(IReadMessage msgTran)
        {
        }
        /// <summary>
        /// 提示错误
        /// </summary>
        /// <param name="alert"></param>
        public virtual void AlertError(ReadAlertError alert)
        {
        }
        /// <summary>
        /// 提示回调错误
        /// </summary>
        /// <param name="ex"></param>
        public virtual void AlertCallbackError(Exception ex)
        {
        }
        /// <summary>
        /// 读取GPIO状态
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="gpio1Value"></param>
        /// <param name="gpio2Value"></param>
        /// <param name="isGpio1Low"></param>
        /// <param name="isGpio2Low"></param>
        public virtual void ReadGpioValue(IReadMessage msgTran, byte gpio1Value, byte gpio2Value, bool isGpio1Low, bool isGpio2Low)
        {
        }
        /// <summary>
        /// 设置GPIO状态
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void WriteGpioValue(IReadMessage msgTran)
        {
        }
        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetAntDetector(IReadMessage msgTran)
        {
        }
        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        public virtual void GetAntDetector(IReadMessage msgTran, byte antDetector)
        {
        }
        /// <summary>
        /// 设置读写器识别标记
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetReaderIdentifier(IReadMessage msgTran)
        {
        }
        /// <summary>
        /// 读取读写器识别标记
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="aryData"></param>
        public virtual void GetReaderIdentifier(IReadMessage msgTran, byte[] aryData)
        {
        }
        /// <summary>
        /// 设置射频通讯链路配置
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="linkProfile"></param>
        public virtual void SetLinkProfile(IReadMessage msgTran, byte linkProfile)
        {
        }
        /// <summary>
        /// 读取射频通讯链路配置
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="profileType"></param>
        public virtual void GetLinkProfile(IReadMessage msgTran, ReadLinkProfileType profileType)
        {
        }
        /// <summary>
        /// 设置波特率
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetUartBaudRate(IReadMessage msgTran)
        {
        }
        /// <summary>
        /// 取得读写器版本号
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        public virtual void GetFirmwareVersion(IReadMessage msgTran, byte major, byte minor)
        {
        }
        /// <summary>
        /// 设置读写器地址
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetReaderAddress(IReadMessage msgTran)
        {
        }
        /// <summary>
        /// 设置工作天线
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetWorkAntenna(IReadMessage msgTran)
        {
        }
        /// <summary>
        /// 取得工作天线
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antennaType"></param>
        public virtual void GetWorkAntenna(IReadMessage msgTran, ReadAntennaType antennaType)
        {
        }
        /// <summary>
        /// 设置输出功率
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetOutputPower(IReadMessage msgTran)
        {
        }
        /// <summary>
        /// 获取输出功率
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="outputPower"></param>
        public virtual void GetOutputPower(IReadMessage msgTran, byte outputPower)
        {
        }
        /// <summary>
        /// 设置射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetFrequencyRegion(IReadMessage msgTran)
        {
        }
        /// <summary>
        /// 获取射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="frequencyType"></param>
        /// <param name="start"></param>
        /// <param name="interval"></param>
        /// <param name="chanelQuantity"></param>
        public virtual void GetFrequencyRegion(IReadMessage msgTran, ReadFreqRegionType frequencyType, int start, byte interval, byte chanelQuantity)
        {
        }
        /// <summary>
        /// 设置蜂鸣器模式
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetBeeperMode(IReadMessage msgTran)
        {
        }
        /// <summary>
        /// 取得读写器温度
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="temperature"></param>
        public virtual void GetReaderTemperature(IReadMessage msgTran, int temperature)
        {
        }
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetDrmMode(IReadMessage msgTran)
        {
        }
        /// <summary>
        /// 取得DRM模式
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="isOpen"></param>
        public virtual void GetDrmMode(IReadMessage msgTran, bool isOpen)
        {
        }
        /// <summary>
        /// 测量天线端口阻抗匹配
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antImpedance"></param>
        public virtual void GetImpedanceMatch(IReadMessage msgTran, byte antImpedance)
        {
        }
        /// <summary>
        /// 盘存标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="currentAnt"></param>
        /// <param name="tagCount"></param>
        /// <param name="readRate"></param>
        /// <param name="totalRead"></param>
        /// <param name="duration"></param>
        public virtual void Inventory(IReadMessage msgTran, byte currentAnt, int tagCount, int readRate, int totalRead, int duration)
        {
        }
        /// <summary>
        /// 读标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void ReadTag(IReadMessage msgTran, R600TagInfo model)
        {
        }
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void WriteTag(IReadMessage msgTran, R600TagInfo model)
        {
        }
        /// <summary>
        /// 锁定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void LockTag(IReadMessage msgTran, R600TagInfo model)
        {
        }
        /// <summary>
        /// 销毁标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void KillTag(IReadMessage msgTran, R600TagInfo model)
        {
        }
        /// <summary>
        /// 选定/取消选定标签
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetAccessEpcMatch(IReadMessage msgTran)
        {
        }
        /// <summary>
        /// 取得选定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="data"></param>
        public virtual void GetAccessEpcMatch(IReadMessage msgTran, byte[] data)
        {
        }
        /// <summary>
        /// 实时盘存(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void InventoryReal(IReadMessage msgTran, R600TagInfo model)
        {
        }
        /// <summary>
        /// 实时盘存(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="readRate"></param>
        /// <param name="dataCount"></param>
        public virtual void InventoryRealEnd(IReadMessage msgTran, int readRate, int dataCount)
        {
        }
        /// <summary>
        /// 快速4天线盘存(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void FastSwitchInventory(IReadMessage msgTran, R600TagInfo model)
        {
        }
        /// <summary>
        /// 快速4天线盘存(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="dataCount"></param>
        /// <param name="cmdDuration"></param>
        public virtual void FastSwitchInventoryEnd(IReadMessage msgTran, int dataCount, int cmdDuration)
        {
        }
        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        public virtual void SetMonzaStatus(IReadMessage msgTran, byte antDetector)
        {
        }
        /// <summary>
        /// 读取Impinj Monza快速读TID功能
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        public virtual void GetMonzaStatus(IReadMessage msgTran, byte antDetector)
        {
        }
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void GetInventoryBuffer(IReadMessage msgTran, R600TagInfo model)
        {
        }
        /// <summary>
        /// 读取清空缓存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void GetAndResetInventoryBuffer(IReadMessage msgTran, R600TagInfo model)
        {
        }
        /// <summary>
        /// 读取缓存标签数量
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="tagCount"></param>
        public virtual void GetInventoryBufferTagCount(IReadMessage msgTran, int tagCount)
        {
        }
        /// <summary>
        /// 清空缓存
        /// </summary>
        public virtual void ResetInventoryBuffer(IReadMessage msgTran)
        {
        }
        /// <summary>
        /// 盘存标签(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void InventoryISO18000(IReadMessage msgTran, R600TagInfoIso18000 model)
        {
        }
        /// <summary>
        /// 盘存标签(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="tagCnt"></param>
        public virtual void InventoryISO18000End(IReadMessage msgTran, int tagCnt)
        {
        }
        /// <summary>
        /// 读取标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="data"></param>
        public virtual void ReadTagISO18000(IReadMessage msgTran, byte antId, byte[] data)
        {
        }
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="length"></param>
        public virtual void WriteTagISO18000(IReadMessage msgTran, byte antId, byte length)
        {
        }
        /// <summary>
        /// 永久写保护
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="status"></param>
        public virtual void LockTagISO18000(IReadMessage msgTran, byte antId, ReadLockTagStatus status)
        {
        }
        /// <summary>
        /// 查询标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="status"></param>
        public virtual void QueryTagISO18000(IReadMessage msgTran, byte antId, ReadLockTagStatus status)
        {
        }

        #endregion
    }
}
