namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 回调委托接口
    /// </summary>
    public interface IR600Callback
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
        Action<IR600Message> AlertUnknownPacketType { get; set; }
        /// <summary>
        /// 提示错误
        /// </summary>
        Action<R600AlertError> AlertError { get; set; }
        /// <summary>
        /// 提示回调错误
        /// </summary>
        Action<Exception> AlertCallbackError { get; set; }
        /// <summary>
        /// 读取GPIO状态
        /// </summary>
        Action<IR600Message, byte, byte, bool, bool> ReadGpioValue { get; set; }
        /// <summary>
        /// 设置GPIO状态
        /// </summary>
        Action<IR600Message> WriteGpioValue { get; set; }
        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        Action<IR600Message> SetAntDetector { get; set; }
        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        Action<IR600Message, byte> GetAntDetector { get; set; }
        /// <summary>
        /// 设置读写器识别标记
        /// </summary>
        Action<IR600Message> SetReaderIdentifier { get; set; }
        /// <summary>
        /// 读取读写器识别标记
        /// </summary>
        Action<IR600Message, byte[]> GetReaderIdentifier { get; set; }
        /// <summary>
        /// 设置射频通讯链路配置
        /// </summary>
        Action<IR600Message, byte> SetLinkProfile { get; set; }
        /// <summary>
        /// 读取射频通讯链路配置
        /// </summary>
        Action<IR600Message, R600LinkProfileType> GetLinkProfile { get; set; }
        /// <summary>
        /// 设置波特率
        /// </summary>
        Action<IR600Message> SetUartBaudRate { get; set; }
        /// <summary>
        /// 取得读写器版本号
        /// </summary>
        Action<IR600Message, byte, byte> GetFirmwareVersion { get; set; }
        /// <summary>
        /// 设置读写器地址
        /// </summary>
        Action<IR600Message> SetReaderAddress { get; set; }
        /// <summary>
        /// 设置工作天线
        /// </summary>
        Action<IR600Message> SetWorkAntenna { get; set; }
        /// <summary>
        /// 取得工作天线
        /// </summary>
        Action<IR600Message, R600AntennaType> GetWorkAntenna { get; set; }
        /// <summary>
        /// 设置输出功率
        /// </summary>
        Action<IR600Message> SetOutputPower { get; set; }
        /// <summary>
        /// 获取输出功率
        /// </summary>
        Action<IR600Message, byte> GetOutputPower { get; set; }
        /// <summary>
        /// 设置射频规范
        /// </summary>
        Action<IR600Message> SetFrequencyRegion { get; set; }
        /// <summary>
        /// 获取射频规范
        /// </summary>
        Action<IR600Message, R600FreqRegionType, int, byte, byte> GetFrequencyRegion { get; set; }
        /// <summary>
        /// 设置蜂鸣器模式
        /// </summary>
        Action<IR600Message> SetBeeperMode { get; set; }
        /// <summary>
        /// 取得读写器温度
        /// </summary>
        Action<IR600Message, int> GetReaderTemperature { get; set; }
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        Action<IR600Message> SetDrmMode { get; set; }
        /// <summary>
        /// 取得DRM模式
        /// </summary>
        Action<IR600Message, bool> GetDrmMode { get; set; }
        /// <summary>
        /// 测量天线端口阻抗匹配
        /// </summary>
        Action<IR600Message, byte> GetImpedanceMatch { get; set; }
        /// <summary>
        /// 盘存标签
        /// </summary>
        Action<IR600Message, byte, int, int, int, int> Inventory { get; set; }
        /// <summary>
        /// 读标签
        /// </summary>
        Action<IR600Message, R600TagInfo> ReadTag { get; set; }
        /// <summary>
        /// 写标签
        /// </summary>
        Action<IR600Message, R600TagInfo> WriteTag { get; set; }
        /// <summary>
        /// 锁定标签
        /// </summary>
        Action<IR600Message, R600TagInfo> LockTag { get; set; }
        /// <summary>
        /// 销毁标签
        /// </summary>
        Action<IR600Message, R600TagInfo> KillTag { get; set; }
        /// <summary>
        /// 选定/取消选定标签
        /// </summary>
        Action<IR600Message> SetAccessEpcMatch { get; set; }
        /// <summary>
        /// 取得选定标签
        /// </summary>
        Action<IR600Message, byte[]> GetAccessEpcMatch { get; set; }
        /// <summary>
        /// 实时盘存(单个)
        /// </summary>
        Action<IR600Message, R600TagInfo> InventoryReal { get; set; }
        /// <summary>
        /// 实时盘存(完成)
        /// </summary>
        Action<IR600Message, int, int> InventoryRealEnd { get; set; }
        /// <summary>
        /// 快速4天线盘存(单个)
        /// </summary>
        Action<IR600Message, R600TagInfo> FastSwitchInventory { get; set; }
        /// <summary>
        /// 快速4天线盘存(完成)
        /// </summary>
        Action<IR600Message, int, int> FastSwitchInventoryEnd { get; set; }
        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// </summary>
        Action<IR600Message, byte> SetMonzaStatus { get; set; }
        /// <summary>
        /// 读取Impinj Monza快速读TID功能
        /// </summary>
        Action<IR600Message, byte> GetMonzaStatus { get; set; }
        /// <summary>
        /// 读取缓存
        /// </summary>
        Action<IR600Message, R600TagInfo> GetInventoryBuffer { get; set; }
        /// <summary>
        /// 读取清空缓存
        /// </summary>
        Action<IR600Message, R600TagInfo> GetAndResetInventoryBuffer { get; set; }
        /// <summary>
        /// 读取缓存标签数量
        /// </summary>
        Action<IR600Message, int> GetInventoryBufferTagCount { get; set; }
        /// <summary>
        /// 清空缓存
        /// </summary>
        Action<IR600Message> ResetInventoryBuffer { get; set; }
        /// <summary>
        /// 盘存标签(单个)
        /// </summary>
        Action<IR600Message, R600TagInfoIso18000> InventoryISO18000 { get; set; }
        /// <summary>
        /// 盘存标签(完成)
        /// </summary>
        Action<IR600Message, int> InventoryISO18000End { get; set; }
        /// <summary>
        /// 读取标签
        /// </summary>
        Action<IR600Message, byte, byte[]> ReadTagISO18000 { get; set; }
        /// <summary>
        /// 写标签
        /// </summary>
        Action<IR600Message, byte, byte> WriteTagISO18000 { get; set; }
        /// <summary>
        /// 永久写保护
        /// </summary>
        Action<IR600Message, byte, R600LockTagStatus> LockTagISO18000 { get; set; }
        /// <summary>
        /// 查询标签
        /// </summary>
        Action<IR600Message, byte, R600LockTagStatus> QueryTagISO18000 { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class R600Callback : IR600Callback
    {
        /// <summary>
        /// 默认构造
        /// </summary>
        public R600Callback()
        {
        }
        /// <summary>
        /// 构造
        /// </summary>
        public R600Callback(IR600Recall model)
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
        public virtual Action<IR600Message> AlertUnknownPacketType { get; set; }
        /// <summary>
        /// 提示错误
        /// </summary>
        public virtual Action<R600AlertError> AlertError { get; set; }
        /// <summary>
        /// 提示回调错误
        /// </summary>
        public virtual Action<Exception> AlertCallbackError { get; set; }
        /// <summary>
        /// 读取GPIO状态
        /// </summary>
        public virtual Action<IR600Message, byte, byte, bool, bool> ReadGpioValue { get; set; }
        /// <summary>
        /// 设置GPIO状态
        /// </summary>
        public virtual Action<IR600Message> WriteGpioValue { get; set; }
        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        public virtual Action<IR600Message> SetAntDetector { get; set; }
        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        public virtual Action<IR600Message, byte> GetAntDetector { get; set; }
        /// <summary>
        /// 设置读写器识别标记
        /// </summary>
        public virtual Action<IR600Message> SetReaderIdentifier { get; set; }
        /// <summary>
        /// 读取读写器识别标记
        /// </summary>
        public virtual Action<IR600Message, byte[]> GetReaderIdentifier { get; set; }
        /// <summary>
        /// 设置射频通讯链路配置
        /// </summary>
        public virtual Action<IR600Message, byte> SetLinkProfile { get; set; }
        /// <summary>
        /// 读取射频通讯链路配置
        /// </summary>
        public virtual Action<IR600Message, R600LinkProfileType> GetLinkProfile { get; set; }
        /// <summary>
        /// 设置波特率
        /// </summary>
        public virtual Action<IR600Message> SetUartBaudRate { get; set; }
        /// <summary>
        /// 取得读写器版本号
        /// </summary>
        public virtual Action<IR600Message, byte, byte> GetFirmwareVersion { get; set; }
        /// <summary>
        /// 设置读写器地址
        /// </summary>
        public virtual Action<IR600Message> SetReaderAddress { get; set; }
        /// <summary>
        /// 设置工作天线
        /// </summary>
        public virtual Action<IR600Message> SetWorkAntenna { get; set; }
        /// <summary>
        /// 取得工作天线
        /// </summary>
        public virtual Action<IR600Message, R600AntennaType> GetWorkAntenna { get; set; }
        /// <summary>
        /// 设置输出功率
        /// </summary>
        public virtual Action<IR600Message> SetOutputPower { get; set; }
        /// <summary>
        /// 获取输出功率
        /// </summary>
        public virtual Action<IR600Message, byte> GetOutputPower { get; set; }
        /// <summary>
        /// 设置射频规范
        /// </summary>
        public virtual Action<IR600Message> SetFrequencyRegion { get; set; }
        /// <summary>
        /// 获取射频规范
        /// </summary>
        public virtual Action<IR600Message, R600FreqRegionType, int, byte, byte> GetFrequencyRegion { get; set; }
        /// <summary>
        /// 设置蜂鸣器模式
        /// </summary>
        public virtual Action<IR600Message> SetBeeperMode { get; set; }
        /// <summary>
        /// 取得读写器温度
        /// </summary>
        public virtual Action<IR600Message, int> GetReaderTemperature { get; set; }
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        public virtual Action<IR600Message> SetDrmMode { get; set; }
        /// <summary>
        /// 取得DRM模式
        /// </summary>
        public virtual Action<IR600Message, bool> GetDrmMode { get; set; }
        /// <summary>
        /// 测量天线端口阻抗匹配
        /// </summary>
        public virtual Action<IR600Message, byte> GetImpedanceMatch { get; set; }
        /// <summary>
        /// 盘存标签
        /// </summary>
        public virtual Action<IR600Message, byte, int, int, int, int> Inventory { get; set; }
        /// <summary>
        /// 读标签
        /// </summary>
        public virtual Action<IR600Message, R600TagInfo> ReadTag { get; set; }
        /// <summary>
        /// 写标签
        /// </summary>
        public virtual Action<IR600Message, R600TagInfo> WriteTag { get; set; }
        /// <summary>
        /// 锁定标签
        /// </summary>
        public virtual Action<IR600Message, R600TagInfo> LockTag { get; set; }
        /// <summary>
        /// 销毁标签
        /// </summary>
        public virtual Action<IR600Message, R600TagInfo> KillTag { get; set; }
        /// <summary>
        /// 选定/取消选定标签
        /// </summary>
        public virtual Action<IR600Message> SetAccessEpcMatch { get; set; }
        /// <summary>
        /// 取得选定标签
        /// </summary>
        public virtual Action<IR600Message, byte[]> GetAccessEpcMatch { get; set; }
        /// <summary>
        /// 实时盘存(单个)
        /// </summary>
        public virtual Action<IR600Message, R600TagInfo> InventoryReal { get; set; }
        /// <summary>
        /// 实时盘存(完成)
        /// </summary>
        public virtual Action<IR600Message, int, int> InventoryRealEnd { get; set; }
        /// <summary>
        /// 快速4天线盘存(单个)
        /// </summary>
        public virtual Action<IR600Message, R600TagInfo> FastSwitchInventory { get; set; }
        /// <summary>
        /// 快速4天线盘存(完成)
        /// </summary>
        public virtual Action<IR600Message, int, int> FastSwitchInventoryEnd { get; set; }
        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// </summary>
        public virtual Action<IR600Message, byte> SetMonzaStatus { get; set; }
        /// <summary>
        /// 读取Impinj Monza快速读TID功能
        /// </summary>
        public virtual Action<IR600Message, byte> GetMonzaStatus { get; set; }
        /// <summary>
        /// 读取缓存
        /// </summary>
        public virtual Action<IR600Message, R600TagInfo> GetInventoryBuffer { get; set; }
        /// <summary>
        /// 读取清空缓存
        /// </summary>
        public virtual Action<IR600Message, R600TagInfo> GetAndResetInventoryBuffer { get; set; }
        /// <summary>
        /// 读取缓存标签数量
        /// </summary>
        public virtual Action<IR600Message, int> GetInventoryBufferTagCount { get; set; }
        /// <summary>
        /// 清空缓存
        /// </summary>
        public virtual Action<IR600Message> ResetInventoryBuffer { get; set; }
        /// <summary>
        /// 盘存标签(单个)
        /// </summary>
        public virtual Action<IR600Message, R600TagInfoIso18000> InventoryISO18000 { get; set; }
        /// <summary>
        /// 盘存标签(完成)
        /// </summary>
        public virtual Action<IR600Message, int> InventoryISO18000End { get; set; }
        /// <summary>
        /// 读取标签
        /// </summary>
        public virtual Action<IR600Message, byte, byte[]> ReadTagISO18000 { get; set; }
        /// <summary>
        /// 写标签
        /// </summary>
        public virtual Action<IR600Message, byte, byte> WriteTagISO18000 { get; set; }
        /// <summary>
        /// 永久写保护
        /// </summary>
        public virtual Action<IR600Message, byte, R600LockTagStatus> LockTagISO18000 { get; set; }
        /// <summary>
        /// 查询标签
        /// </summary>
        public virtual Action<IR600Message, byte, R600LockTagStatus> QueryTagISO18000 { get; set; }
    }
    /// <summary>
    /// 回调委托抽象类
    /// </summary>
    public abstract class AR600Callback : R600Callback, IR600Callback, IR600Recall
    {
        /// <summary>
        /// 默认构造
        /// </summary>
        public AR600Callback() : base()
        {
        }
        /// <summary>
        /// 构造
        /// </summary>
        public AR600Callback(IR600Recall model) : base(model)
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
        #region // 回调方法接口
        /// <summary>
        /// 发送回调
        /// </summary>
        /// <param name="aryData"></param>
        void IR600Recall.SendCallback(byte[] aryData)
        {
            SendCallback?.Invoke(aryData);
        }
        /// <summary>
        /// 接收回调
        /// </summary>
        /// <param name="aryData"></param>
        void IR600Recall.ReceiveCallback(byte[] aryData)
        {
            ReceiveCallback?.Invoke(aryData);
        }
        /// <summary>
        /// 未知的数据包类型处理
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600Recall.AlertUnknownPacketType(IR600Message msgTran)
        {
            AlertUnknownPacketType?.Invoke(msgTran);
        }
        /// <summary>
        /// 提示错误
        /// </summary>
        /// <param name="alert"></param>
        void IR600Recall.AlertError(R600AlertError alert)
        {
            AlertError?.Invoke(alert);
        }
        /// <summary>
        /// 提示回调错误
        /// </summary>
        /// <param name="ex"></param>
        void IR600Recall.AlertCallbackError(Exception ex)
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
        void IR600Recall.ReadGpioValue(IR600Message msgTran, byte gpio1Value, byte gpio2Value, bool isGpio1Low, bool isGpio2Low)
        {
            ReadGpioValue?.Invoke(msgTran, gpio1Value, gpio2Value, isGpio1Low, isGpio2Low);
        }
        /// <summary>
        /// 设置GPIO状态
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600Recall.WriteGpioValue(IR600Message msgTran)
        {
            WriteGpioValue?.Invoke(msgTran);
        }
        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600Recall.SetAntDetector(IR600Message msgTran)
        {
            SetAntDetector?.Invoke(msgTran);
        }
        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        void IR600Recall.GetAntDetector(IR600Message msgTran, byte antDetector)
        {
            GetAntDetector?.Invoke(msgTran, antDetector);
        }
        /// <summary>
        /// 设置读写器识别标记
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600Recall.SetReaderIdentifier(IR600Message msgTran)
        {
            SetReaderIdentifier?.Invoke(msgTran);
        }
        /// <summary>
        /// 读取读写器识别标记
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="aryData"></param>
        void IR600Recall.GetReaderIdentifier(IR600Message msgTran, byte[] aryData)
        {
            GetReaderIdentifier?.Invoke(msgTran, aryData);
        }
        /// <summary>
        /// 设置射频通讯链路配置
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="linkProfile"></param>
        void IR600Recall.SetLinkProfile(IR600Message msgTran, byte linkProfile)
        {
            SetLinkProfile?.Invoke(msgTran, linkProfile);
        }
        /// <summary>
        /// 读取射频通讯链路配置
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="profileType"></param>
        void IR600Recall.GetLinkProfile(IR600Message msgTran, R600LinkProfileType profileType)
        {
            GetLinkProfile?.Invoke(msgTran, profileType);
        }
        /// <summary>
        /// 设置波特率
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600Recall.SetUartBaudRate(IR600Message msgTran)
        {
            SetUartBaudRate?.Invoke(msgTran);
        }
        /// <summary>
        /// 取得读写器版本号
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        void IR600Recall.GetFirmwareVersion(IR600Message msgTran, byte major, byte minor)
        {
            GetFirmwareVersion?.Invoke(msgTran, major, minor);
        }
        /// <summary>
        /// 设置读写器地址
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600Recall.SetReaderAddress(IR600Message msgTran)
        {
            SetReaderAddress?.Invoke(msgTran);
        }
        /// <summary>
        /// 设置工作天线
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600Recall.SetWorkAntenna(IR600Message msgTran)
        {
            SetWorkAntenna?.Invoke(msgTran);
        }
        /// <summary>
        /// 取得工作天线
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antennaType"></param>
        void IR600Recall.GetWorkAntenna(IR600Message msgTran, R600AntennaType antennaType)
        {
            GetWorkAntenna?.Invoke(msgTran, antennaType);
        }
        /// <summary>
        /// 设置输出功率
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600Recall.SetOutputPower(IR600Message msgTran)
        {
            SetOutputPower?.Invoke(msgTran);
        }
        /// <summary>
        /// 获取输出功率
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="outputPower"></param>
        void IR600Recall.GetOutputPower(IR600Message msgTran, byte outputPower)
        {
            GetOutputPower?.Invoke(msgTran, outputPower);
        }
        /// <summary>
        /// 设置射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600Recall.SetFrequencyRegion(IR600Message msgTran)
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
        void IR600Recall.GetFrequencyRegion(IR600Message msgTran, R600FreqRegionType frequencyType, int start, byte interval, byte chanelQuantity)
        {
            GetFrequencyRegion?.Invoke(msgTran, frequencyType, start, interval, chanelQuantity);
        }
        /// <summary>
        /// 设置蜂鸣器模式
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600Recall.SetBeeperMode(IR600Message msgTran)
        {
            SetBeeperMode?.Invoke(msgTran);
        }
        /// <summary>
        /// 取得读写器温度
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="temperature"></param>
        void IR600Recall.GetReaderTemperature(IR600Message msgTran, int temperature)
        {
            GetReaderTemperature?.Invoke(msgTran, temperature);
        }
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600Recall.SetDrmMode(IR600Message msgTran)
        {
            SetDrmMode?.Invoke(msgTran);
        }
        /// <summary>
        /// 取得DRM模式
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="isOpen"></param>
        void IR600Recall.GetDrmMode(IR600Message msgTran, bool isOpen)
        {
            GetDrmMode?.Invoke(msgTran, isOpen);
        }
        /// <summary>
        /// 测量天线端口阻抗匹配
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antImpedance"></param>
        void IR600Recall.GetImpedanceMatch(IR600Message msgTran, byte antImpedance)
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
        void IR600Recall.Inventory(IR600Message msgTran, byte currentAnt, int tagCount, int readRate, int totalRead, int duration)
        {
            Inventory?.Invoke(msgTran, currentAnt, tagCount, readRate, totalRead, duration);
        }
        /// <summary>
        /// 读标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600Recall.ReadTag(IR600Message msgTran, R600TagInfo model)
        {
            ReadTag?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600Recall.WriteTag(IR600Message msgTran, R600TagInfo model)
        {
            WriteTag?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 锁定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600Recall.LockTag(IR600Message msgTran, R600TagInfo model)
        {
            LockTag?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 销毁标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600Recall.KillTag(IR600Message msgTran, R600TagInfo model)
        {
            KillTag?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 选定/取消选定标签
        /// </summary>
        /// <param name="msgTran"></param>
        void IR600Recall.SetAccessEpcMatch(IR600Message msgTran)
        {
            SetAccessEpcMatch?.Invoke(msgTran);
        }
        /// <summary>
        /// 取得选定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="data"></param>
        void IR600Recall.GetAccessEpcMatch(IR600Message msgTran, byte[] data)
        {
            GetAccessEpcMatch?.Invoke(msgTran, data);
        }
        /// <summary>
        /// 实时盘存(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600Recall.InventoryReal(IR600Message msgTran, R600TagInfo model)
        {
            InventoryReal?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 实时盘存(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="readRate"></param>
        /// <param name="dataCount"></param>
        void IR600Recall.InventoryRealEnd(IR600Message msgTran, int readRate, int dataCount)
        {
            InventoryRealEnd?.Invoke(msgTran, readRate, dataCount);
        }
        /// <summary>
        /// 快速4天线盘存(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600Recall.FastSwitchInventory(IR600Message msgTran, R600TagInfo model)
        {
            FastSwitchInventory?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 快速4天线盘存(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="dataCount"></param>
        /// <param name="cmdDuration"></param>
        void IR600Recall.FastSwitchInventoryEnd(IR600Message msgTran, int dataCount, int cmdDuration)
        {
            FastSwitchInventoryEnd?.Invoke(msgTran, dataCount, cmdDuration);
        }
        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        void IR600Recall.SetMonzaStatus(IR600Message msgTran, byte antDetector)
        {
            SetMonzaStatus?.Invoke(msgTran, antDetector);
        }
        /// <summary>
        /// 读取Impinj Monza快速读TID功能
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antDetector"></param>
        void IR600Recall.GetMonzaStatus(IR600Message msgTran, byte antDetector)
        {
            GetMonzaStatus?.Invoke(msgTran, antDetector);
        }
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600Recall.GetInventoryBuffer(IR600Message msgTran, R600TagInfo model)
        {
            GetInventoryBuffer?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 读取清空缓存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600Recall.GetAndResetInventoryBuffer(IR600Message msgTran, R600TagInfo model)
        {
            GetAndResetInventoryBuffer?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 读取缓存标签数量
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="tagCount"></param>
        void IR600Recall.GetInventoryBufferTagCount(IR600Message msgTran, int tagCount)
        {
            GetInventoryBufferTagCount?.Invoke(msgTran, tagCount);
        }
        /// <summary>
        /// 清空缓存
        /// </summary>
        void IR600Recall.ResetInventoryBuffer(IR600Message msgTran)
        {
            ResetInventoryBuffer?.Invoke(msgTran);
        }
        /// <summary>
        /// 盘存标签(单个)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="model"></param>
        void IR600Recall.InventoryISO18000(IR600Message msgTran, R600TagInfoIso18000 model)
        {
            InventoryISO18000?.Invoke(msgTran, model);
        }
        /// <summary>
        /// 盘存标签(完成)
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="tagCnt"></param>
        void IR600Recall.InventoryISO18000End(IR600Message msgTran, int tagCnt)
        {
            InventoryISO18000End?.Invoke(msgTran, tagCnt);
        }
        /// <summary>
        /// 读取标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="data"></param>
        void IR600Recall.ReadTagISO18000(IR600Message msgTran, byte antId, byte[] data)
        {
            ReadTagISO18000?.Invoke(msgTran, antId, data);
        }
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="length"></param>
        void IR600Recall.WriteTagISO18000(IR600Message msgTran, byte antId, byte length)
        {
            WriteTagISO18000?.Invoke(msgTran, antId, length);
        }
        /// <summary>
        /// 永久写保护
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="status"></param>
        void IR600Recall.LockTagISO18000(IR600Message msgTran, byte antId, R600LockTagStatus status)
        {
            LockTagISO18000?.Invoke(msgTran, antId, status);
        }
        /// <summary>
        /// 查询标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <param name="antId"></param>
        /// <param name="status"></param>
        void IR600Recall.QueryTagISO18000(IR600Message msgTran, byte antId, R600LockTagStatus status)
        {
            QueryTagISO18000?.Invoke(msgTran, antId, status);
        }
        #endregion
    }
}
