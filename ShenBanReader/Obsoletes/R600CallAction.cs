using System;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 回调委托接口
    /// </summary>
    public interface IR600CallAction
    {
        /// <summary>
        /// 发送回调
        /// </summary>
        Action<byte[]> SendCallback { get; set; }
        /// <summary>
        /// 接收回调
        /// </summary>
        Action<byte[]> ReceiveCallback { get; set; }
        /// <summary>
        /// 未知的数据包类型处理
        /// </summary>
        Action<IReadMessage> AlertUnknownPacketType { get; set; }
        /// <summary>
        /// 提示错误
        /// </summary>
        Action<ReadAlertError> AlertError { get; set; }
        /// <summary>
        /// 提示回调错误
        /// </summary>
        Action<Exception> AlertCallbackError { get; set; }
        /// <summary>
        /// 读取GPIO状态
        /// </summary>
        Action<IReadMessage, byte, byte, bool, bool> ReadGpioValue { get; set; }
        /// <summary>
        /// 设置GPIO状态
        /// </summary>
        Action<IReadMessage> WriteGpioValue { get; set; }
        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        Action<IReadMessage> SetAntDetector { get; set; }
        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        Action<IReadMessage, byte> GetAntDetector { get; set; }
        /// <summary>
        /// 设置读写器识别标记
        /// </summary>
        Action<IReadMessage> SetReaderIdentifier { get; set; }
        /// <summary>
        /// 读取读写器识别标记
        /// </summary>
        Action<IReadMessage, byte[]> GetReaderIdentifier { get; set; }
        /// <summary>
        /// 设置射频通讯链路配置
        /// </summary>
        Action<IReadMessage, byte> SetLinkProfile { get; set; }
        /// <summary>
        /// 读取射频通讯链路配置
        /// </summary>
        Action<IReadMessage, ReadLinkProfileType> GetLinkProfile { get; set; }
        /// <summary>
        /// 设置波特率
        /// </summary>
        Action<IReadMessage> SetUartBaudRate { get; set; }
        /// <summary>
        /// 取得读写器版本号
        /// </summary>
        Action<IReadMessage, byte, byte> GetFirmwareVersion { get; set; }
        /// <summary>
        /// 设置读写器地址
        /// </summary>
        Action<IReadMessage> SetReaderAddress { get; set; }
        /// <summary>
        /// 设置工作天线
        /// </summary>
        Action<IReadMessage> SetWorkAntenna { get; set; }
        /// <summary>
        /// 取得工作天线
        /// </summary>
        Action<IReadMessage, ReadAntennaType> GetWorkAntenna { get; set; }
        /// <summary>
        /// 设置输出功率
        /// </summary>
        Action<IReadMessage> SetOutputPower { get; set; }
        /// <summary>
        /// 获取输出功率
        /// </summary>
        Action<IReadMessage, byte> GetOutputPower { get; set; }
        /// <summary>
        /// 设置射频规范
        /// </summary>
        Action<IReadMessage> SetFrequencyRegion { get; set; }
        /// <summary>
        /// 获取射频规范
        /// </summary>
        Action<IReadMessage, ReadFreqRegionType, int, byte, byte> GetFrequencyRegion { get; set; }
        /// <summary>
        /// 设置蜂鸣器模式
        /// </summary>
        Action<IReadMessage> SetBeeperMode { get; set; }
        /// <summary>
        /// 取得读写器温度
        /// </summary>
        Action<IReadMessage, int> GetReaderTemperature { get; set; }
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        Action<IReadMessage> SetDrmMode { get; set; }
        /// <summary>
        /// 取得DRM模式
        /// </summary>
        Action<IReadMessage, bool> GetDrmMode { get; set; }
        /// <summary>
        /// 测量天线端口阻抗匹配
        /// </summary>
        Action<IReadMessage, byte> GetImpedanceMatch { get; set; }
        /// <summary>
        /// 盘存标签
        /// </summary>
        Action<IReadMessage, byte, int, int, int, int> Inventory { get; set; }
        /// <summary>
        /// 读标签
        /// </summary>
        Action<IReadMessage, R600TagInfo> ReadTag { get; set; }
        /// <summary>
        /// 写标签
        /// </summary>
        Action<IReadMessage, R600TagInfo> WriteTag { get; set; }
        /// <summary>
        /// 锁定标签
        /// </summary>
        Action<IReadMessage, R600TagInfo> LockTag { get; set; }
        /// <summary>
        /// 销毁标签
        /// </summary>
        Action<IReadMessage, R600TagInfo> KillTag { get; set; }
        /// <summary>
        /// 选定/取消选定标签
        /// </summary>
        Action<IReadMessage> SetAccessEpcMatch { get; set; }
        /// <summary>
        /// 取得选定标签
        /// </summary>
        Action<IReadMessage, byte[]> GetAccessEpcMatch { get; set; }
        /// <summary>
        /// 实时盘存(单个)
        /// </summary>
        Action<IReadMessage, R600TagInfo> InventoryReal { get; set; }
        /// <summary>
        /// 实时盘存(完成)
        /// </summary>
        Action<IReadMessage, int, int> InventoryRealEnd { get; set; }
        /// <summary>
        /// 快速4天线盘存(单个)
        /// </summary>
        Action<IReadMessage, R600TagInfo> FastSwitchInventory { get; set; }
        /// <summary>
        /// 快速4天线盘存(完成)
        /// </summary>
        Action<IReadMessage, int, int> FastSwitchInventoryEnd { get; set; }
        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// </summary>
        Action<IReadMessage, byte> SetMonzaStatus { get; set; }
        /// <summary>
        /// 读取Impinj Monza快速读TID功能
        /// </summary>
        Action<IReadMessage, byte> GetMonzaStatus { get; set; }
        /// <summary>
        /// 读取缓存
        /// </summary>
        Action<IReadMessage, R600TagInfo> GetInventoryBuffer { get; set; }
        /// <summary>
        /// 读取清空缓存
        /// </summary>
        Action<IReadMessage, R600TagInfo> GetAndResetInventoryBuffer { get; set; }
        /// <summary>
        /// 读取缓存标签数量
        /// </summary>
        Action<IReadMessage, int> GetInventoryBufferTagCount { get; set; }
        /// <summary>
        /// 清空缓存
        /// </summary>
        Action<IReadMessage> ResetInventoryBuffer { get; set; }
        /// <summary>
        /// 盘存标签(单个)
        /// </summary>
        Action<IReadMessage, R600TagInfoIso18000> InventoryISO18000 { get; set; }
        /// <summary>
        /// 盘存标签(完成)
        /// </summary>
        Action<IReadMessage, int> InventoryISO18000End { get; set; }
        /// <summary>
        /// 读取标签
        /// </summary>
        Action<IReadMessage, byte, byte[]> ReadTagISO18000 { get; set; }
        /// <summary>
        /// 写标签
        /// </summary>
        Action<IReadMessage, byte, byte> WriteTagISO18000 { get; set; }
        /// <summary>
        /// 永久写保护
        /// </summary>
        Action<IReadMessage, byte, ReadLockTagStatus> LockTagISO18000 { get; set; }
        /// <summary>
        /// 查询标签
        /// </summary>
        Action<IReadMessage, byte, ReadLockTagStatus> QueryTagISO18000 { get; set; }
    }
    /// <summary>
    /// 回调委托接口
    /// </summary>
    public class R600CallAction : IR600CallAction
    {
        /// <summary>
        /// 默认构造
        /// </summary>
        public R600CallAction()
        {
        }
        /// <summary>
        /// 构造
        /// </summary>
        public R600CallAction(IR600CallMethod model)
        {
            if (model == null) { return; }
            this.SendCallback = model.SendCallback;
            this.ReceiveCallback = model.ReceiveCallback;
            this.AlertUnknownPacketType = model.AlertUnknownPacketType;
            this.AlertError = model.AlertError;
            this.AlertCallbackError = model.AlertCallbackError;
            this.ReadGpioValue = model.ReadGpioValue;
            this.WriteGpioValue = model.WriteGpioValue;
            this.SetAntDetector = model.SetAntDetector;
            this.GetAntDetector = model.GetAntDetector;
            this.SetReaderIdentifier = model.SetReaderIdentifier;
            this.GetReaderIdentifier = model.GetReaderIdentifier;
            this.SetLinkProfile = model.SetLinkProfile;
            this.GetLinkProfile = model.GetLinkProfile;
            this.SetUartBaudRate = model.SetUartBaudRate;
            this.GetFirmwareVersion = model.GetFirmwareVersion;
            this.SetReaderAddress = model.SetReaderAddress;
            this.SetWorkAntenna = model.SetWorkAntenna;
            this.GetWorkAntenna = model.GetWorkAntenna;
            this.SetOutputPower = model.SetOutputPower;
            this.GetOutputPower = model.GetOutputPower;
            this.SetFrequencyRegion = model.SetFrequencyRegion;
            this.GetFrequencyRegion = model.GetFrequencyRegion;
            this.SetBeeperMode = model.SetBeeperMode;
            this.GetReaderTemperature = model.GetReaderTemperature;
            this.SetDrmMode = model.SetDrmMode;
            this.GetDrmMode = model.GetDrmMode;
            this.GetImpedanceMatch = model.GetImpedanceMatch;
            this.Inventory = model.Inventory;
            this.ReadTag = model.ReadTag;
            this.WriteTag = model.WriteTag;
            this.LockTag = model.LockTag;
            this.KillTag = model.KillTag;
            this.SetAccessEpcMatch = model.SetAccessEpcMatch;
            this.GetAccessEpcMatch = model.GetAccessEpcMatch;
            this.InventoryReal = model.InventoryReal;
            this.InventoryRealEnd = model.InventoryRealEnd;
            this.FastSwitchInventory = model.FastSwitchInventory;
            this.FastSwitchInventoryEnd = model.FastSwitchInventoryEnd;
            this.SetMonzaStatus = model.SetMonzaStatus;
            this.GetMonzaStatus = model.GetMonzaStatus;
            this.GetInventoryBuffer = model.GetInventoryBuffer;
            this.GetAndResetInventoryBuffer = model.GetAndResetInventoryBuffer;
            this.GetInventoryBufferTagCount = model.GetInventoryBufferTagCount;
            this.ResetInventoryBuffer = model.ResetInventoryBuffer;
            this.InventoryISO18000 = model.InventoryISO18000;
            this.InventoryISO18000End = model.InventoryISO18000End;
            this.ReadTagISO18000 = model.ReadTagISO18000;
            this.WriteTagISO18000 = model.WriteTagISO18000;
            this.LockTagISO18000 = model.LockTagISO18000;
            this.QueryTagISO18000 = model.QueryTagISO18000;
        }
        /// <summary>
        /// 发送回调
        /// </summary>
        public virtual Action<byte[]> SendCallback { get; set; }
        /// <summary>
        /// 接收回调
        /// </summary>
        public virtual Action<byte[]> ReceiveCallback { get; set; }
        /// <summary>
        /// 未知的数据包类型处理
        /// </summary>
        public virtual Action<IReadMessage> AlertUnknownPacketType { get; set; }
        /// <summary>
        /// 提示错误
        /// </summary>
        public virtual Action<ReadAlertError> AlertError { get; set; }
        /// <summary>
        /// 提示回调错误
        /// </summary>
        public virtual Action<Exception> AlertCallbackError { get; set; }
        /// <summary>
        /// 读取GPIO状态
        /// </summary>
        public virtual Action<IReadMessage, byte, byte, bool, bool> ReadGpioValue { get; set; }
        /// <summary>
        /// 设置GPIO状态
        /// </summary>
        public virtual Action<IReadMessage> WriteGpioValue { get; set; }
        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        public virtual Action<IReadMessage> SetAntDetector { get; set; }
        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        public virtual Action<IReadMessage, byte> GetAntDetector { get; set; }
        /// <summary>
        /// 设置读写器识别标记
        /// </summary>
        public virtual Action<IReadMessage> SetReaderIdentifier { get; set; }
        /// <summary>
        /// 读取读写器识别标记
        /// </summary>
        public virtual Action<IReadMessage, byte[]> GetReaderIdentifier { get; set; }
        /// <summary>
        /// 设置射频通讯链路配置
        /// </summary>
        public virtual Action<IReadMessage, byte> SetLinkProfile { get; set; }
        /// <summary>
        /// 读取射频通讯链路配置
        /// </summary>
        public virtual Action<IReadMessage, ReadLinkProfileType> GetLinkProfile { get; set; }
        /// <summary>
        /// 设置波特率
        /// </summary>
        public virtual Action<IReadMessage> SetUartBaudRate { get; set; }
        /// <summary>
        /// 取得读写器版本号
        /// </summary>
        public virtual Action<IReadMessage, byte, byte> GetFirmwareVersion { get; set; }
        /// <summary>
        /// 设置读写器地址
        /// </summary>
        public virtual Action<IReadMessage> SetReaderAddress { get; set; }
        /// <summary>
        /// 设置工作天线
        /// </summary>
        public virtual Action<IReadMessage> SetWorkAntenna { get; set; }
        /// <summary>
        /// 取得工作天线
        /// </summary>
        public virtual Action<IReadMessage, ReadAntennaType> GetWorkAntenna { get; set; }
        /// <summary>
        /// 设置输出功率
        /// </summary>
        public virtual Action<IReadMessage> SetOutputPower { get; set; }
        /// <summary>
        /// 获取输出功率
        /// </summary>
        public virtual Action<IReadMessage, byte> GetOutputPower { get; set; }
        /// <summary>
        /// 设置射频规范
        /// </summary>
        public virtual Action<IReadMessage> SetFrequencyRegion { get; set; }
        /// <summary>
        /// 获取射频规范
        /// </summary>
        public virtual Action<IReadMessage, ReadFreqRegionType, int, byte, byte> GetFrequencyRegion { get; set; }
        /// <summary>
        /// 设置蜂鸣器模式
        /// </summary>
        public virtual Action<IReadMessage> SetBeeperMode { get; set; }
        /// <summary>
        /// 取得读写器温度
        /// </summary>
        public virtual Action<IReadMessage, int> GetReaderTemperature { get; set; }
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        public virtual Action<IReadMessage> SetDrmMode { get; set; }
        /// <summary>
        /// 取得DRM模式
        /// </summary>
        public virtual Action<IReadMessage, bool> GetDrmMode { get; set; }
        /// <summary>
        /// 测量天线端口阻抗匹配
        /// </summary>
        public virtual Action<IReadMessage, byte> GetImpedanceMatch { get; set; }
        /// <summary>
        /// 盘存标签
        /// </summary>
        public virtual Action<IReadMessage, byte, int, int, int, int> Inventory { get; set; }
        /// <summary>
        /// 读标签
        /// </summary>
        public virtual Action<IReadMessage, R600TagInfo> ReadTag { get; set; }
        /// <summary>
        /// 写标签
        /// </summary>
        public virtual Action<IReadMessage, R600TagInfo> WriteTag { get; set; }
        /// <summary>
        /// 锁定标签
        /// </summary>
        public virtual Action<IReadMessage, R600TagInfo> LockTag { get; set; }
        /// <summary>
        /// 销毁标签
        /// </summary>
        public virtual Action<IReadMessage, R600TagInfo> KillTag { get; set; }
        /// <summary>
        /// 选定/取消选定标签
        /// </summary>
        public virtual Action<IReadMessage> SetAccessEpcMatch { get; set; }
        /// <summary>
        /// 取得选定标签
        /// </summary>
        public virtual Action<IReadMessage, byte[]> GetAccessEpcMatch { get; set; }
        /// <summary>
        /// 实时盘存(单个)
        /// </summary>
        public virtual Action<IReadMessage, R600TagInfo> InventoryReal { get; set; }
        /// <summary>
        /// 实时盘存(完成)
        /// </summary>
        public virtual Action<IReadMessage, int, int> InventoryRealEnd { get; set; }
        /// <summary>
        /// 快速4天线盘存(单个)
        /// </summary>
        public virtual Action<IReadMessage, R600TagInfo> FastSwitchInventory { get; set; }
        /// <summary>
        /// 快速4天线盘存(完成)
        /// </summary>
        public virtual Action<IReadMessage, int, int> FastSwitchInventoryEnd { get; set; }
        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// </summary>
        public virtual Action<IReadMessage, byte> SetMonzaStatus { get; set; }
        /// <summary>
        /// 读取Impinj Monza快速读TID功能
        /// </summary>
        public virtual Action<IReadMessage, byte> GetMonzaStatus { get; set; }
        /// <summary>
        /// 读取缓存
        /// </summary>
        public virtual Action<IReadMessage, R600TagInfo> GetInventoryBuffer { get; set; }
        /// <summary>
        /// 读取清空缓存
        /// </summary>
        public virtual Action<IReadMessage, R600TagInfo> GetAndResetInventoryBuffer { get; set; }
        /// <summary>
        /// 读取缓存标签数量
        /// </summary>
        public virtual Action<IReadMessage, int> GetInventoryBufferTagCount { get; set; }
        /// <summary>
        /// 清空缓存
        /// </summary>
        public virtual Action<IReadMessage> ResetInventoryBuffer { get; set; }
        /// <summary>
        /// 盘存标签(单个)
        /// </summary>
        public virtual Action<IReadMessage, R600TagInfoIso18000> InventoryISO18000 { get; set; }
        /// <summary>
        /// 盘存标签(完成)
        /// </summary>
        public virtual Action<IReadMessage, int> InventoryISO18000End { get; set; }
        /// <summary>
        /// 读取标签
        /// </summary>
        public virtual Action<IReadMessage, byte, byte[]> ReadTagISO18000 { get; set; }
        /// <summary>
        /// 写标签
        /// </summary>
        public virtual Action<IReadMessage, byte, byte> WriteTagISO18000 { get; set; }
        /// <summary>
        /// 永久写保护
        /// </summary>
        public virtual Action<IReadMessage, byte, ReadLockTagStatus> LockTagISO18000 { get; set; }
        /// <summary>
        /// 查询标签
        /// </summary>
        public virtual Action<IReadMessage, byte, ReadLockTagStatus> QueryTagISO18000 { get; set; }
    }
    /// <summary>
    /// 回调委托抽象类
    /// </summary>
    public abstract class AR600CallAction : R600CallAction, IR600CallAction, IR600CallMethod
    {
        /// <summary>
        /// 默认构造
        /// </summary>
        public AR600CallAction() : base() { }
        /// <summary>
        /// 构造
        /// </summary>
        public AR600CallAction(IR600CallMethod model) : base(model) { }
        #region // 回调方法接口
        /// <summary>
        /// 发送回调
        /// </summary>
        /// <param name="aryData"></param>
        void IR600CallMethod.SendCallback(byte[] aryData)
        {
            SendCallback?.Invoke(aryData);
        }
        /// <summary>
        /// 接收回调
        /// </summary>
        /// <param name="aryData"></param>
        void IR600CallMethod.ReceiveCallback(byte[] aryData)
        {
            ReceiveCallback?.Invoke(aryData);
        }
        /// <summary>
        /// 未知的数据包类型处理
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600CallMethod.AlertUnknownPacketType(IReadMessage msgTran)
        {
            AlertUnknownPacketType?.Invoke(msgTran);
        }
        /// <summary>
        /// 提示错误
        /// </summary>
        /// <param name="alert"></param>
        void IR600CallMethod.AlertError(ReadAlertError alert)
        {
            AlertError?.Invoke(alert);
        }
        /// <summary>
        /// 提示回调错误
        /// </summary>
        /// <param name="ex"></param>
        void IR600CallMethod.AlertCallbackError(Exception ex)
        {
            AlertCallbackError?.Invoke(ex);
        }
        /// <summary>
        /// 读取GPIO状态
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="gpio1Value"></param>
        /// <param name="gpio2Value"></param>
        /// <param name="isGpio1Low"></param>
        /// <param name="isGpio2Low"></param>
        void IR600CallMethod.ReadGpioValue(IReadMessage msgTran, byte gpio1Value, byte gpio2Value, bool isGpio1Low, bool isGpio2Low)
        {
            ReadGpioValue?.Invoke(msgTran, gpio1Value, gpio2Value, isGpio1Low, isGpio2Low);
        }
        /// <summary>
        /// 设置GPIO状态
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600CallMethod.WriteGpioValue(IReadMessage msgTran)
        {
            WriteGpioValue?.Invoke(msgTran);
        }
        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600CallMethod.SetAntDetector(IReadMessage msgTran)
        {
            SetAntDetector?.Invoke(msgTran);
        }
        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        void IR600CallMethod.GetAntDetector(IReadMessage msgTran, byte antDetector)
        {
            GetAntDetector?.Invoke(msgTran, antDetector);
        }
        /// <summary>
        /// 设置读写器识别标记
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600CallMethod.SetReaderIdentifier(IReadMessage msgTran)
        {
            SetReaderIdentifier?.Invoke(msgTran);
        }
        /// <summary>
        /// 读取读写器识别标记
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="aryData"></param>
        void IR600CallMethod.GetReaderIdentifier(IReadMessage msgTran, byte[] aryData)
        {
            GetReaderIdentifier?.Invoke(msgTran, aryData);
        }
        /// <summary>
        /// 设置射频通讯链路配置
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="linkProfile"></param>
        void IR600CallMethod.SetLinkProfile(IReadMessage msgTran, byte linkProfile)
        {
            SetLinkProfile?.Invoke(msgTran, linkProfile);
        }
        /// <summary>
        /// 读取射频通讯链路配置
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="profileType"></param>
        void IR600CallMethod.GetLinkProfile(IReadMessage msgTran, ReadLinkProfileType profileType)
        {
            GetLinkProfile?.Invoke(msgTran, profileType);
        }
        /// <summary>
        /// 设置波特率
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600CallMethod.SetUartBaudRate(IReadMessage msgTran)
        {
            SetUartBaudRate?.Invoke(msgTran);
        }
        /// <summary>
        /// 取得读写器版本号
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        void IR600CallMethod.GetFirmwareVersion(IReadMessage msgTran, byte major, byte minor)
        {
            GetFirmwareVersion?.Invoke(msgTran, major, minor);
        }
        /// <summary>
        /// 设置读写器地址
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600CallMethod.SetReaderAddress(IReadMessage msgTran)
        {
            SetReaderAddress?.Invoke(msgTran);
        }
        /// <summary>
        /// 设置工作天线
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600CallMethod.SetWorkAntenna(IReadMessage msgTran)
        {
            SetWorkAntenna?.Invoke(msgTran);
        }
        /// <summary>
        /// 取得工作天线
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antennaType"></param>
        void IR600CallMethod.GetWorkAntenna(IReadMessage msgTran, ReadAntennaType antennaType)
        {
            GetWorkAntenna?.Invoke(msgTran, antennaType);
        }
        /// <summary>
        /// 设置输出功率
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600CallMethod.SetOutputPower(IReadMessage msgTran)
        {
            SetOutputPower?.Invoke(msgTran);
        }
        /// <summary>
        /// 获取输出功率
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="outputPower"></param>
        void IR600CallMethod.GetOutputPower(IReadMessage msgTran, byte outputPower)
        {
            GetOutputPower?.Invoke(msgTran, outputPower);
        }
        /// <summary>
        /// 设置射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600CallMethod.SetFrequencyRegion(IReadMessage msgTran)
        {
            SetFrequencyRegion?.Invoke(msgTran);
        }
        /// <summary>
        /// 获取射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="frequencyType"></param>
        /// <param name="start"></param>
        /// <param name="interval"></param>
        /// <param name="chanelQuantity"></param>
        void IR600CallMethod.GetFrequencyRegion(IReadMessage msgTran, ReadFreqRegionType frequencyType, int start, byte interval, byte chanelQuantity)
        {
            GetFrequencyRegion?.Invoke(msgTran, frequencyType, start, interval, chanelQuantity);
        }
        /// <summary>
        /// 设置蜂鸣器模式
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600CallMethod.SetBeeperMode(IReadMessage msgTran)
        {
            SetBeeperMode?.Invoke(msgTran);
        }
        /// <summary>
        /// 取得读写器温度
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="temperature"></param>
        void IR600CallMethod.GetReaderTemperature(IReadMessage msgTran, int temperature)
        {
            GetReaderTemperature?.Invoke(msgTran, temperature);
        }
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600CallMethod.SetDrmMode(IReadMessage msgTran)
        {
            SetDrmMode?.Invoke(msgTran);
        }
        /// <summary>
        /// 取得DRM模式
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="isOpen"></param>
        void IR600CallMethod.GetDrmMode(IReadMessage msgTran, bool isOpen)
        {
            GetDrmMode?.Invoke(msgTran, isOpen);
        }
        /// <summary>
        /// 测量天线端口阻抗匹配
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antImpedance"></param>
        void IR600CallMethod.GetImpedanceMatch(IReadMessage msgTran, byte antImpedance)
        {
            GetImpedanceMatch?.Invoke(msgTran, antImpedance);
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
        void IR600CallMethod.Inventory(IReadMessage msgTran, byte currentAnt, int tagCount, int readRate, int totalRead, int duration)
        {
            Inventory?.Invoke(msgTran, currentAnt, tagCount, readRate, totalRead, duration);
        }
        /// <summary>
        /// 读标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600CallMethod.ReadTag(IReadMessage msgTran, R600TagInfo model)
        {
            ReadTag?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600CallMethod.WriteTag(IReadMessage msgTran, R600TagInfo model)
        {
            WriteTag?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 锁定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600CallMethod.LockTag(IReadMessage msgTran, R600TagInfo model)
        {
            LockTag?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 销毁标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600CallMethod.KillTag(IReadMessage msgTran, R600TagInfo model)
        {
            KillTag?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 选定/取消选定标签
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600CallMethod.SetAccessEpcMatch(IReadMessage msgTran)
        {
            SetAccessEpcMatch?.Invoke(msgTran);
        }
        /// <summary>
        /// 取得选定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="data"></param>
        void IR600CallMethod.GetAccessEpcMatch(IReadMessage msgTran, byte[] data)
        {
            GetAccessEpcMatch?.Invoke(msgTran, data);
        }
        /// <summary>
        /// 实时盘存(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600CallMethod.InventoryReal(IReadMessage msgTran, R600TagInfo model)
        {
            InventoryReal?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 实时盘存(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="readRate"></param>
        /// <param name="dataCount"></param>
        void IR600CallMethod.InventoryRealEnd(IReadMessage msgTran, int readRate, int dataCount)
        {
            InventoryRealEnd?.Invoke(msgTran, readRate, dataCount);
        }
        /// <summary>
        /// 快速4天线盘存(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600CallMethod.FastSwitchInventory(IReadMessage msgTran, R600TagInfo model)
        {
            FastSwitchInventory?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 快速4天线盘存(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="dataCount"></param>
        /// <param name="cmdDuration"></param>
        void IR600CallMethod.FastSwitchInventoryEnd(IReadMessage msgTran, int dataCount, int cmdDuration)
        {
            FastSwitchInventoryEnd?.Invoke(msgTran, dataCount, cmdDuration);
        }
        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        void IR600CallMethod.SetMonzaStatus(IReadMessage msgTran, byte antDetector)
        {
            SetMonzaStatus?.Invoke(msgTran, antDetector);
        }
        /// <summary>
        /// 读取Impinj Monza快速读TID功能
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        void IR600CallMethod.GetMonzaStatus(IReadMessage msgTran, byte antDetector)
        {
            GetMonzaStatus?.Invoke(msgTran, antDetector);
        }
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600CallMethod.GetInventoryBuffer(IReadMessage msgTran, R600TagInfo model)
        {
            GetInventoryBuffer?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 读取清空缓存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600CallMethod.GetAndResetInventoryBuffer(IReadMessage msgTran, R600TagInfo model)
        {
            GetAndResetInventoryBuffer?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 读取缓存标签数量
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="tagCount"></param>
        void IR600CallMethod.GetInventoryBufferTagCount(IReadMessage msgTran, int tagCount)
        {
            GetInventoryBufferTagCount?.Invoke(msgTran, tagCount);
        }
        /// <summary>
        /// 清空缓存
        /// </summary>
        void IR600CallMethod.ResetInventoryBuffer(IReadMessage msgTran)
        {
            ResetInventoryBuffer?.Invoke(msgTran);
        }
        /// <summary>
        /// 盘存标签(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600CallMethod.InventoryISO18000(IReadMessage msgTran, R600TagInfoIso18000 model)
        {
            InventoryISO18000?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 盘存标签(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="tagCnt"></param>
        void IR600CallMethod.InventoryISO18000End(IReadMessage msgTran, int tagCnt)
        {
            InventoryISO18000End?.Invoke(msgTran, tagCnt);
        }
        /// <summary>
        /// 读取标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="data"></param>
        void IR600CallMethod.ReadTagISO18000(IReadMessage msgTran, byte antId, byte[] data)
        {
            ReadTagISO18000?.Invoke(msgTran, antId, data);
        }
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="length"></param>
        void IR600CallMethod.WriteTagISO18000(IReadMessage msgTran, byte antId, byte length)
        {
            WriteTagISO18000?.Invoke(msgTran, antId, length);
        }
        /// <summary>
        /// 永久写保护
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="status"></param>
        void IR600CallMethod.LockTagISO18000(IReadMessage msgTran, byte antId, ReadLockTagStatus status)
        {
            LockTagISO18000?.Invoke(msgTran, antId, status);
        }
        /// <summary>
        /// 查询标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="status"></param>
        void IR600CallMethod.QueryTagISO18000(IReadMessage msgTran, byte antId, ReadLockTagStatus status)
        {
            QueryTagISO18000?.Invoke(msgTran, antId, status);
        }
        #endregion
    }
}
