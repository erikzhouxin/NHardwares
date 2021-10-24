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
        void AlertUnknownPacketType(IR600Message msgTran);
        /// <summary>
        /// 提示错误
        /// </summary>
        /// <param name="alert"></param>
        void AlertError(R600AlertError alert);
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
        void ReadGpioValue(IR600Message msgTran, byte gpio1Value, byte gpio2Value, bool isGpio1Low, bool isGpio2Low);
        /// <summary>
        /// 设置GPIO状态
        /// </summary>
        /// <param name="msgTran"></param>
        void WriteGpioValue(IR600Message msgTran);
        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        /// <param name="msgTran"></param>
        void SetAntDetector(IR600Message msgTran);
        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        void GetAntDetector(IR600Message msgTran, byte antDetector);
        /// <summary>
        /// 设置读写器识别标记
        /// </summary>
        /// <param name="msgTran"></param>
        void SetReaderIdentifier(IR600Message msgTran);
        /// <summary>
        /// 读取读写器识别标记
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="aryData"></param>
        void GetReaderIdentifier(IR600Message msgTran, byte[] aryData);
        /// <summary>
        /// 设置射频通讯链路配置
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="linkProfile"></param>
        void SetProfile(IR600Message msgTran, byte linkProfile);
        /// <summary>
        /// 读取射频通讯链路配置
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="profileType"></param>
        void GetProfile(IR600Message msgTran, R600LinkProfileType profileType);
        /// <summary>
        /// 设置波特率
        /// </summary>
        /// <param name="msgTran"></param>
        void SetUartBaudRate(IR600Message msgTran);
        /// <summary>
        /// 取得读写器版本号
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        void GetFirmwareVersion(IR600Message msgTran, byte major, byte minor);
        /// <summary>
        /// 设置读写器地址
        /// </summary>
        /// <param name="msgTran"></param>
        void SetReaderAddress(IR600Message msgTran);
        /// <summary>
        /// 设置工作天线
        /// </summary>
        /// <param name="msgTran"></param>
        void SetWorkAntenna(IR600Message msgTran);
        /// <summary>
        /// 取得工作天线
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antennaType"></param>
        void GetWorkAntenna(IR600Message msgTran, R600AntennaType antennaType);
        /// <summary>
        /// 设置输出功率
        /// </summary>
        /// <param name="msgTran"></param>
        void SetOutputPower(IR600Message msgTran);
        /// <summary>
        /// 获取输出功率
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="outputPower"></param>
        void GetOutputPower(IR600Message msgTran, byte outputPower);
        /// <summary>
        /// 设置射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        void SetFrequencyRegion(IR600Message msgTran);
        /// <summary>
        /// 获取射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="frequencyType"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        void GetFrequencyRegion(IR600Message msgTran, R600FreqRegionType frequencyType, byte start, byte end);
        /// <summary>
        /// 获取用户射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="frequencyType"></param>
        /// <param name="interval"></param>
        /// <param name="chanelQuantity"></param>
        /// <param name="start"></param>
        void GetUserDefineFrequencyRegion(IR600Message msgTran, R600FreqRegionType frequencyType, byte interval, int chanelQuantity, int start);
        /// <summary>
        /// 设置蜂鸣器模式
        /// </summary>
        /// <param name="msgTran"></param>
        void SetBeeperMode(IR600Message msgTran);
        /// <summary>
        /// 取得读写器温度
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="temperature"></param>
        void GetReaderTemperature(IR600Message msgTran, int temperature);
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        /// <param name="msgTran"></param>
        void SetDrmMode(IR600Message msgTran);
        /// <summary>
        /// 取得DRM模式
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="isOpen"></param>
        void GetDrmMode(IR600Message msgTran, bool isOpen);
        /// <summary>
        /// 测量天线端口阻抗匹配
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antImpedance"></param>
        void GetImpedanceMatch(IR600Message msgTran, byte antImpedance);
        /// <summary>
        /// 盘存标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="currentAnt"></param>
        /// <param name="tagCount"></param>
        /// <param name="readRate"></param>
        /// <param name="totalRead"></param>
        /// <param name="duration"></param>
        void Inventory(IR600Message msgTran, byte currentAnt, int tagCount, int readRate, int totalRead, int duration);
        /// <summary>
        /// 读标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void ReadTag(IR600Message msgTran, R600TagInfo model);
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void WriteTag(IR600Message msgTran, R600TagInfo model);
        /// <summary>
        /// 锁定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void LockTag(IR600Message msgTran, R600TagInfo model);
        /// <summary>
        /// 销毁标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void KillTag(IR600Message msgTran, R600TagInfo model);
        /// <summary>
        /// 选定/取消选定标签
        /// </summary>
        /// <param name="msgTran"></param>
        void SetAccessEpcMatch(IR600Message msgTran);
        /// <summary>
        /// 取得选定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="data"></param>
        void GetAccessEpcMatch(IR600Message msgTran, byte[] data);
        /// <summary>
        /// 实时盘存(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void InventoryReal(IR600Message msgTran, R600TagInfo model);
        /// <summary>
        /// 实时盘存(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="readRate"></param>
        /// <param name="dataCount"></param>
        void InventoryRealEnd(IR600Message msgTran, int readRate, int dataCount);
        /// <summary>
        /// 快速4天线盘存(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void FastSwitchInventory(IR600Message msgTran, R600TagInfo model);
        /// <summary>
        /// 快速4天线盘存(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="dataCount"></param>
        /// <param name="cmdDuration"></param>
        void FastSwitchInventoryEnd(IR600Message msgTran, int dataCount, int cmdDuration);
        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        void SetMonzaStatus(IR600Message msgTran, byte antDetector);
        /// <summary>
        /// 读取Impinj Monza快速读TID功能
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        void GetMonzaStatus(IR600Message msgTran, byte antDetector);
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void GetInventoryBuffer(IR600Message msgTran, R600TagInfo model);
        /// <summary>
        /// 读取清空缓存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void GetAndResetInventoryBuffer(IR600Message msgTran, R600TagInfo model);
        /// <summary>
        /// 读取缓存标签数量
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="tagCount"></param>
        void GetInventoryBufferTagCount(IR600Message msgTran, int tagCount);
        /// <summary>
        /// 清空缓存
        /// </summary>
        void ResetInventoryBuffer(IR600Message msgTran);
        /// <summary>
        /// 盘存标签(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void InventoryISO18000(IR600Message msgTran, R600TagInfoIso18000 model);
        /// <summary>
        /// 盘存标签(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="tagCnt"></param>
        void InventoryISO18000End(IR600Message msgTran, int tagCnt);
        /// <summary>
        /// 读取标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="data"></param>
        void ReadTagISO18000(IR600Message msgTran, byte antId, byte[] data);
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="length"></param>
        void WriteTagISO18000(IR600Message msgTran, byte antId, byte length);
        /// <summary>
        /// 永久写保护
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="status"></param>
        void LockTagISO18000(IR600Message msgTran, byte antId, R600LockTagStatus status);
        /// <summary>
        /// 查询标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="status"></param>
        void QueryTagISO18000(IR600Message msgTran, byte antId, R600LockTagStatus status);
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
        Action<byte[]> IR600Callback.SendCallback { get => SendCallback; }
        /// <summary>
        /// 接收回调
        /// </summary>
        Action<byte[]> IR600Callback.ReceiveCallback { get => ReceiveCallback; }
        /// <summary>
        /// 未知的数据包类型处理
        /// </summary>
        Action<IR600Message> IR600Callback.AlertUnknownPacketType { get => AlertUnknownPacketType; }
        /// <summary>
        /// 提示错误
        /// </summary>
        Action<R600AlertError> IR600Callback.AlertError { get => AlertError; }
        /// <summary>
        /// 提示回调错误
        /// </summary>
        Action<Exception> IR600Callback.AlertCallbackError { get => AlertCallbackError; }
        /// <summary>
        /// 读取GPIO状态
        /// </summary>
        Action<IR600Message, byte, byte, bool, bool> IR600Callback.ReadGpioValue { get => ReadGpioValue; }
        /// <summary>
        /// 设置GPIO状态
        /// </summary>
        Action<IR600Message> IR600Callback.WriteGpioValue { get => WriteGpioValue; }
        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        Action<IR600Message> IR600Callback.SetAntDetector { get => SetAntDetector; }
        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        Action<IR600Message, byte> IR600Callback.GetAntDetector { get => GetAntDetector; }
        /// <summary>
        /// 设置读写器识别标记
        /// </summary>
        Action<IR600Message> IR600Callback.SetReaderIdentifier { get => SetReaderIdentifier; }
        /// <summary>
        /// 读取读写器识别标记
        /// </summary>
        Action<IR600Message, byte[]> IR600Callback.GetReaderIdentifier { get => GetReaderIdentifier; }
        /// <summary>
        /// 设置射频通讯链路配置
        /// </summary>
        Action<IR600Message, byte> IR600Callback.SetProfile { get => SetProfile; }
        /// <summary>
        /// 读取射频通讯链路配置
        /// </summary>
        Action<IR600Message, R600LinkProfileType> IR600Callback.GetProfile { get => GetProfile; }
        /// <summary>
        /// 设置波特率
        /// </summary>
        Action<IR600Message> IR600Callback.SetUartBaudRate { get => SetUartBaudRate; }
        /// <summary>
        /// 取得读写器版本号
        /// </summary>
        Action<IR600Message, byte, byte> IR600Callback.GetFirmwareVersion { get => GetFirmwareVersion; }
        /// <summary>
        /// 设置读写器地址
        /// </summary>
        Action<IR600Message> IR600Callback.SetReaderAddress { get => SetReaderAddress; }
        /// <summary>
        /// 设置工作天线
        /// </summary>
        Action<IR600Message> IR600Callback.SetWorkAntenna { get => SetWorkAntenna; }
        /// <summary>
        /// 取得工作天线
        /// </summary>
        Action<IR600Message, R600AntennaType> IR600Callback.GetWorkAntenna { get => GetWorkAntenna; }
        /// <summary>
        /// 设置输出功率
        /// </summary>
        Action<IR600Message> IR600Callback.SetOutputPower { get => SetOutputPower; }
        /// <summary>
        /// 获取输出功率
        /// </summary>
        Action<IR600Message, byte> IR600Callback.GetOutputPower { get => GetOutputPower; }
        /// <summary>
        /// 设置射频规范
        /// </summary>
        Action<IR600Message> IR600Callback.SetFrequencyRegion { get => SetFrequencyRegion; }
        /// <summary>
        /// 获取射频规范
        /// </summary>
        Action<IR600Message, R600FreqRegionType, byte, byte> IR600Callback.GetFrequencyRegion { get => GetFrequencyRegion; }
        /// <summary>
        /// 获取用户射频规范
        /// </summary>
        Action<IR600Message, R600FreqRegionType, byte, int, int> IR600Callback.GetUserDefineFrequencyRegion { get => GetUserDefineFrequencyRegion; }
        /// <summary>
        /// 设置蜂鸣器模式
        /// </summary>
        Action<IR600Message> IR600Callback.SetBeeperMode { get => SetBeeperMode; }
        /// <summary>
        /// 取得读写器温度
        /// </summary>
        Action<IR600Message, int> IR600Callback.GetReaderTemperature { get => GetReaderTemperature; }
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        Action<IR600Message> IR600Callback.SetDrmMode { get => SetDrmMode; }
        /// <summary>
        /// 取得DRM模式
        /// </summary>
        Action<IR600Message, bool> IR600Callback.GetDrmMode { get => GetDrmMode; }
        /// <summary>
        /// 测量天线端口阻抗匹配
        /// </summary>
        Action<IR600Message, byte> IR600Callback.GetImpedanceMatch { get => GetImpedanceMatch; }
        /// <summary>
        /// 盘存标签
        /// </summary>
        Action<IR600Message, byte, int, int, int, int> IR600Callback.Inventory { get => Inventory; }
        /// <summary>
        /// 读标签
        /// </summary>
        Action<IR600Message, R600TagInfo> IR600Callback.ReadTag { get => ReadTag; }
        /// <summary>
        /// 写标签
        /// </summary>
        Action<IR600Message, R600TagInfo> IR600Callback.WriteTag { get => WriteTag; }
        /// <summary>
        /// 锁定标签
        /// </summary>
        Action<IR600Message, R600TagInfo> IR600Callback.LockTag { get => LockTag; }
        /// <summary>
        /// 销毁标签
        /// </summary>
        Action<IR600Message, R600TagInfo> IR600Callback.KillTag { get => KillTag; }
        /// <summary>
        /// 选定/取消选定标签
        /// </summary>
        Action<IR600Message> IR600Callback.SetAccessEpcMatch { get => SetAccessEpcMatch; }
        /// <summary>
        /// 取得选定标签
        /// </summary>
        Action<IR600Message, byte[]> IR600Callback.GetAccessEpcMatch { get => GetAccessEpcMatch; }
        /// <summary>
        /// 实时盘存(单个)
        /// </summary>
        Action<IR600Message, R600TagInfo> IR600Callback.InventoryReal { get => InventoryReal; }
        /// <summary>
        /// 实时盘存(完成)
        /// </summary>
        Action<IR600Message, int, int> IR600Callback.InventoryRealEnd { get => InventoryRealEnd; }
        /// <summary>
        /// 快速4天线盘存(单个)
        /// </summary>
        Action<IR600Message, R600TagInfo> IR600Callback.FastSwitchInventory { get => FastSwitchInventory; }
        /// <summary>
        /// 快速4天线盘存(完成)
        /// </summary>
        Action<IR600Message, int, int> IR600Callback.FastSwitchInventoryEnd { get => FastSwitchInventoryEnd; }
        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// </summary>
        Action<IR600Message, byte> IR600Callback.SetMonzaStatus { get => SetMonzaStatus; }
        /// <summary>
        /// 读取Impinj Monza快速读TID功能
        /// </summary>
        Action<IR600Message, byte> IR600Callback.GetMonzaStatus { get => GetMonzaStatus; }
        /// <summary>
        /// 读取缓存
        /// </summary>
        Action<IR600Message, R600TagInfo> IR600Callback.GetInventoryBuffer { get => GetInventoryBuffer; }
        /// <summary>
        /// 读取清空缓存
        /// </summary>
        Action<IR600Message, R600TagInfo> IR600Callback.GetAndResetInventoryBuffer { get => GetAndResetInventoryBuffer; }
        /// <summary>
        /// 读取缓存标签数量
        /// </summary>
        Action<IR600Message, int> IR600Callback.GetInventoryBufferTagCount { get => GetInventoryBufferTagCount; }
        /// <summary>
        /// 清空缓存
        /// </summary>
        Action<IR600Message> IR600Callback.ResetInventoryBuffer { get => ResetInventoryBuffer; }
        /// <summary>
        /// 盘存标签(单个)
        /// </summary>
        Action<IR600Message, R600TagInfoIso18000> IR600Callback.InventoryISO18000 { get => InventoryISO18000; }
        /// <summary>
        /// 盘存标签(完成)
        /// </summary>
        Action<IR600Message, int> IR600Callback.InventoryISO18000End { get => InventoryISO18000End; }
        /// <summary>
        /// 读取标签
        /// </summary>
        Action<IR600Message, byte, byte[]> IR600Callback.ReadTagISO18000 { get => ReadTagISO18000; }
        /// <summary>
        /// 写标签
        /// </summary>
        Action<IR600Message, byte, byte> IR600Callback.WriteTagISO18000 { get => WriteTagISO18000; }
        /// <summary>
        /// 永久写保护
        /// </summary>
        Action<IR600Message, byte, R600LockTagStatus> IR600Callback.LockTagISO18000 { get => LockTagISO18000; }
        /// <summary>
        /// 查询标签
        /// </summary>
        Action<IR600Message, byte, R600LockTagStatus> IR600Callback.QueryTagISO18000 { get => QueryTagISO18000; }
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
        public virtual void AlertUnknownPacketType(IR600Message msgTran)
        {
        }
        /// <summary>
        /// 提示错误
        /// </summary>
        /// <param name="alert"></param>
        public virtual void AlertError(R600AlertError alert)
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
        public virtual void ReadGpioValue(IR600Message msgTran, byte gpio1Value, byte gpio2Value, bool isGpio1Low, bool isGpio2Low)
        {
        }
        /// <summary>
        /// 设置GPIO状态
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void WriteGpioValue(IR600Message msgTran)
        {
        }
        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetAntDetector(IR600Message msgTran)
        {
        }
        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        public virtual void GetAntDetector(IR600Message msgTran, byte antDetector)
        {
        }
        /// <summary>
        /// 设置读写器识别标记
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetReaderIdentifier(IR600Message msgTran)
        {
        }
        /// <summary>
        /// 读取读写器识别标记
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="aryData"></param>
        public virtual void GetReaderIdentifier(IR600Message msgTran, byte[] aryData)
        {
        }
        /// <summary>
        /// 设置射频通讯链路配置
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="linkProfile"></param>
        public virtual void SetProfile(IR600Message msgTran, byte linkProfile)
        {
        }
        /// <summary>
        /// 读取射频通讯链路配置
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="profileType"></param>
        public virtual void GetProfile(IR600Message msgTran, R600LinkProfileType profileType)
        {
        }
        /// <summary>
        /// 设置波特率
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetUartBaudRate(IR600Message msgTran)
        {
        }
        /// <summary>
        /// 取得读写器版本号
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        public virtual void GetFirmwareVersion(IR600Message msgTran, byte major, byte minor)
        {
        }
        /// <summary>
        /// 设置读写器地址
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetReaderAddress(IR600Message msgTran)
        {
        }
        /// <summary>
        /// 设置工作天线
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetWorkAntenna(IR600Message msgTran)
        {
        }
        /// <summary>
        /// 取得工作天线
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antennaType"></param>
        public virtual void GetWorkAntenna(IR600Message msgTran, R600AntennaType antennaType)
        {
        }
        /// <summary>
        /// 设置输出功率
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetOutputPower(IR600Message msgTran)
        {
        }
        /// <summary>
        /// 获取输出功率
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="outputPower"></param>
        public virtual void GetOutputPower(IR600Message msgTran, byte outputPower)
        {
        }
        /// <summary>
        /// 设置射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetFrequencyRegion(IR600Message msgTran)
        {
        }
        /// <summary>
        /// 获取射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="frequencyType"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public virtual void GetFrequencyRegion(IR600Message msgTran, R600FreqRegionType frequencyType, byte start, byte end)
        {
        }
        /// <summary>
        /// 获取用户射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="frequencyType"></param>
        /// <param name="interval"></param>
        /// <param name="chanelQuantity"></param>
        /// <param name="start"></param>
        public virtual void GetUserDefineFrequencyRegion(IR600Message msgTran, R600FreqRegionType frequencyType, byte interval, int chanelQuantity, int start)
        {
        }
        /// <summary>
        /// 设置蜂鸣器模式
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetBeeperMode(IR600Message msgTran)
        {
        }
        /// <summary>
        /// 取得读写器温度
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="temperature"></param>
        public virtual void GetReaderTemperature(IR600Message msgTran, int temperature)
        {
        }
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetDrmMode(IR600Message msgTran)
        {
        }
        /// <summary>
        /// 取得DRM模式
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="isOpen"></param>
        public virtual void GetDrmMode(IR600Message msgTran, bool isOpen)
        {
        }
        /// <summary>
        /// 测量天线端口阻抗匹配
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antImpedance"></param>
        public virtual void GetImpedanceMatch(IR600Message msgTran, byte antImpedance)
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
        public virtual void Inventory(IR600Message msgTran, byte currentAnt, int tagCount, int readRate, int totalRead, int duration)
        {
        }
        /// <summary>
        /// 读标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void ReadTag(IR600Message msgTran, R600TagInfo model)
        {
        }
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void WriteTag(IR600Message msgTran, R600TagInfo model)
        {
        }
        /// <summary>
        /// 锁定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void LockTag(IR600Message msgTran, R600TagInfo model)
        {
        }
        /// <summary>
        /// 销毁标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void KillTag(IR600Message msgTran, R600TagInfo model)
        {
        }
        /// <summary>
        /// 选定/取消选定标签
        /// </summary>
        /// <param name="msgTran"></param>
        public virtual void SetAccessEpcMatch(IR600Message msgTran)
        {
        }
        /// <summary>
        /// 取得选定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="data"></param>
        public virtual void GetAccessEpcMatch(IR600Message msgTran, byte[] data)
        {
        }
        /// <summary>
        /// 实时盘存(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void InventoryReal(IR600Message msgTran, R600TagInfo model)
        {
        }
        /// <summary>
        /// 实时盘存(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="readRate"></param>
        /// <param name="dataCount"></param>
        public virtual void InventoryRealEnd(IR600Message msgTran, int readRate, int dataCount)
        {
        }
        /// <summary>
        /// 快速4天线盘存(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void FastSwitchInventory(IR600Message msgTran, R600TagInfo model)
        {
        }
        /// <summary>
        /// 快速4天线盘存(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="dataCount"></param>
        /// <param name="cmdDuration"></param>
        public virtual void FastSwitchInventoryEnd(IR600Message msgTran, int dataCount, int cmdDuration)
        {
        }
        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        public virtual void SetMonzaStatus(IR600Message msgTran, byte antDetector)
        {
        }
        /// <summary>
        /// 读取Impinj Monza快速读TID功能
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        public virtual void GetMonzaStatus(IR600Message msgTran, byte antDetector)
        {
        }
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void GetInventoryBuffer(IR600Message msgTran, R600TagInfo model)
        {
        }
        /// <summary>
        /// 读取清空缓存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void GetAndResetInventoryBuffer(IR600Message msgTran, R600TagInfo model)
        {
        }
        /// <summary>
        /// 读取缓存标签数量
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="tagCount"></param>
        public virtual void GetInventoryBufferTagCount(IR600Message msgTran, int tagCount)
        {
        }
        /// <summary>
        /// 清空缓存
        /// </summary>
        public virtual void ResetInventoryBuffer(IR600Message msgTran)
        {
        }
        /// <summary>
        /// 盘存标签(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        public virtual void InventoryISO18000(IR600Message msgTran, R600TagInfoIso18000 model)
        {
        }
        /// <summary>
        /// 盘存标签(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="tagCnt"></param>
        public virtual void InventoryISO18000End(IR600Message msgTran, int tagCnt)
        {
        }
        /// <summary>
        /// 读取标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="data"></param>
        public virtual void ReadTagISO18000(IR600Message msgTran, byte antId, byte[] data)
        {
        }
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="length"></param>
        public virtual void WriteTagISO18000(IR600Message msgTran, byte antId, byte length)
        {
        }
        /// <summary>
        /// 永久写保护
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="status"></param>
        public virtual void LockTagISO18000(IR600Message msgTran, byte antId, R600LockTagStatus status)
        {
        }
        /// <summary>
        /// 查询标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="status"></param>
        public virtual void QueryTagISO18000(IR600Message msgTran, byte antId, R600LockTagStatus status)
        {
        }

        #endregion
    }
}
