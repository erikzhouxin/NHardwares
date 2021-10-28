using System.Net;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 响应接口
    /// </summary>
    public interface IR600Queue : IDisposable
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
        /// <see cref="IR600Callback.ReadGpioValue"/>
        /// </summary>
        /// <returns></returns>
        int ReadGpioValue(byte btReadId, Action<IR600Message, byte, byte, bool, bool> ReadGpioValue);
        /// <summary>
        /// 写GPIO值
        /// <see cref="IR600Callback.WriteGpioValue"/>
        /// </summary>
        /// <returns></returns>
        int WriteGpioValue(byte btReadId, byte btChooseGpio, byte btGpioValue, Action<IR600Message> WriteGpioValue);
        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        /// <returns></returns>
        /// <see cref="IR600Callback.SetAntDetector"/>
        int SetAntDetector(byte btReadId, byte btDetectorStatus, Action<IR600Message> SetAntDetector);
        /// <summary>
        /// 读取天线连接检测阈值
        /// <see cref="IR600Callback.GetAntDetector"/>
        /// </summary>
        /// <returns></returns>
        int GetAntDetector(byte btReadId, Action<IR600Message, byte> GetAntDetector);
        /// <summary>
        /// 设置读ID
        /// <see cref="IR600Callback.SetReaderIdentifier"/>
        /// </summary>
        /// <returns></returns>
        int SetReaderIdentifier(byte btReadId, byte[] identifier, Action<IR600Message> SetReaderIdentifier);
        /// <summary>
        /// 获取读ID
        /// <see cref="IR600Callback.GetReaderIdentifier"/>
        /// </summary>
        /// <returns></returns>
        int GetReaderIdentifier(byte btReadId, Action<IR600Message, byte[]> GetReaderIdentifier);
        /// <summary>
        /// 设置配置
        /// <see cref="IR600Callback.SetLinkProfile"/>
        /// </summary>
        /// <returns></returns>
        int SetLinkProfile(byte btReadId, byte btProfile, Action<IR600Message, byte> SetLinkProfile);
        /// <summary>
        /// 获取配置
        /// <see cref="IR600Callback.GetLinkProfile"/>
        /// </summary>
        /// <returns></returns>
        int GetLinkProfile(byte btReadId, Action<IR600Message, R600LinkProfileType> GetLinkProfile);
        /// <summary>
        /// 重置
        /// </summary>
        /// <returns></returns>
        int Reset(byte btReadId);
        /// <summary>
        /// 设置非同步收发传输器波特率
        /// <see cref="IR600Callback.SetUartBaudRate"/>
        /// </summary>
        /// <returns></returns>
        int SetUartBaudRate(byte btReadId, int nIndexBaudrate, Action<IR600Message> SetUartBaudRate);
        /// <summary>
        /// 获取固件版本
        /// <see cref="IR600Callback.GetFirmwareVersion"/>
        /// </summary>
        /// <returns></returns>
        int GetFirmwareVersion(byte btReadId, Action<IR600Message, byte, byte> GetFirmwareVersion);
        /// <summary>
        /// 设置读地址
        /// <see cref="IR600Callback.SetReaderAddress"/>
        /// </summary>
        /// <returns></returns>
        int SetReaderAddress(byte btReadId, byte btNewReadId, Action<IR600Message> SetReaderAddress);
        /// <summary>
        /// 设置工作天线
        /// <see cref="IR600Callback.SetWorkAntenna"/>
        /// </summary>
        /// <returns></returns>
        int SetWorkAntenna(byte btReadId, byte btWorkAntenna, Action<IR600Message> SetWorkAntenna);
        /// <summary>
        /// 获取工作天线
        /// <see cref="IR600Callback.GetWorkAntenna"/>
        /// </summary>
        /// <returns></returns>
        int GetWorkAntenna(byte btReadId, Action<IR600Message, R600AntennaType> GetWorkAntenna);
        /// <summary>
        /// 设置输出功率
        /// <see cref="IR600Callback.SetOutputPower"/>
        /// </summary>
        /// <returns></returns>
        int SetOutputPower(byte btReadId, byte btOutputPower, Action<IR600Message> SetOutputPower);
        /// <summary>
        /// 获取输出功率
        /// <see cref="IR600Callback.GetOutputPower"/>
        /// </summary>
        /// <returns></returns>
        int GetOutputPower(byte btReadId, Action<IR600Message, byte> GetOutputPower);
        /// <summary>
        /// 设置频率区域
        /// <see cref="IR600Callback.SetFrequencyRegion"/>
        /// </summary>
        /// <returns></returns>
        int SetFrequencyRegion(byte btReadId, R600FreqRegionType btRegion, int btStart, byte btInterval, byte btChanelQuality, Action<IR600Message> SetFrequencyRegion);
        /// <summary>
        /// 得到频率区域
        /// <see cref="IR600Callback.GetFrequencyRegion"/>
        /// </summary>
        /// <returns></returns>
        int GetFrequencyRegion(byte btReadId, Action<IR600Message, R600FreqRegionType, int, byte, byte> GetFrequencyRegion);
        /// <summary>
        /// 设置呼叫模式
        /// <see cref="IR600Callback.SetBeeperMode"/>
        /// </summary>
        /// <returns></returns>
        int SetBeeperMode(byte btReadId, byte btMode, Action<IR600Message> SetBeeperMode);
        /// <summary>
        /// 得到工作温度
        /// <see cref="IR600Callback.GetReaderTemperature"/>
        /// </summary>
        /// <returns></returns>
        int GetReaderTemperature(byte btReadId, Action<IR600Message, int> GetReaderTemperature);
        /// <summary>
        /// 设置DRM模式
        /// <see cref="IR600Callback.SetDrmMode"/>
        /// </summary>
        /// <returns></returns>
        int SetDrmMode(byte btReadId, byte btDrmMode, Action<IR600Message> SetDrmMode);
        /// <summary>
        /// 获取DRM模式
        /// <see cref="IR600Callback.GetDrmMode"/>
        /// </summary>
        /// <returns></returns>
        int GetDrmMode(byte btReadId, Action<IR600Message, bool> GetDrmMode);
        /// <summary>
        /// 回波损耗测量
        /// <see cref="IR600Callback.GetImpedanceMatch"/>
        /// </summary>
        /// <returns></returns>
        [Obsolete("替代方案:GetImpedanceMatch")]
        int MeasureReturnLoss(byte btReadId, byte btFrequency, Action<IR600Message, byte> GetImpedanceMatch);
        /// <summary>
        /// 获得阻抗匹配
        /// <see cref="IR600Callback.GetImpedanceMatch"/>
        /// </summary>
        /// <returns></returns>
        int GetImpedanceMatch(byte btReadId, byte btFrequency, Action<IR600Message, byte> GetImpedanceMatch);
        /// <summary>
        /// 盘存
        /// <see cref="IR600Callback.Inventory"/>
        /// </summary>
        /// <returns></returns>
        int Inventory(byte btReadId, byte byRound, Action<IR600Message, byte, int, int, int, int> Inventory);
        /// <summary>
        /// 读标签
        /// <see cref="IR600Callback.ReadTag"/>
        /// </summary>
        /// <returns></returns>
        int ReadTag(byte btReadId, byte btMemBank, byte btWordAdd, byte btWordCnt, Action<IR600Message, R600TagInfo> ReadTag);
        /// <summary>
        /// 写标签
        /// <see cref="IR600Callback.WriteTag"/>
        /// </summary>
        /// <returns></returns>
        int WriteTag(byte btReadId, byte[] btAryPassWord, byte btMemBank, byte btWordAdd, byte btWordCnt, byte[] btAryData, Action<IR600Message, R600TagInfo> WriteTag);
        /// <summary>
        /// 锁定标签
        /// <see cref="IR600Callback.LockTag"/>
        /// </summary>
        /// <returns></returns>
        int LockTag(byte btReadId, byte[] btAryPassWord, byte btMembank, byte btLockType, Action<IR600Message, R600TagInfo> LockTag);
        /// <summary>
        /// 释放标记
        /// <see cref="IR600Callback.KillTag"/>
        /// </summary>
        /// <returns></returns>
        int KillTag(byte btReadId, byte[] btAryPassWord, Action<IR600Message, R600TagInfo> KillTag);
        /// <summary>
        /// 设置EPC(btEpcLen=0为取消)
        /// <see cref="IR600Callback.SetAccessEpcMatch"/>
        /// </summary>
        /// <returns></returns>
        int SetAccessEpcMatch(byte btReadId, byte btMode, byte btEpcLen, byte[] btAryEpc, Action<IR600Message> SetAccessEpcMatch);
        /// <summary>
        /// 获取EPC
        /// <see cref="IR600Callback.GetAccessEpcMatch"/>
        /// </summary>
        /// <returns></returns>
        int GetAccessEpcMatch(byte btReadId, Action<IR600Message, byte[]> GetAccessEpcMatch);
        /// <summary>
        /// 实时存盘
        /// <see cref="IR600Callback.InventoryReal"/>
        /// <see cref="IR600Callback.InventoryRealEnd"/>
        /// </summary>
        /// <returns></returns>
        int InventoryReal(byte btReadId, byte byRound, Action<IR600Message, R600TagInfo> InventoryReal, Action<IR600Message, int, int> InventoryRealEnd);
        /// <summary>
        /// 快速存盘
        /// <see cref="IR600Callback.FastSwitchInventory"/>
        /// <see cref="IR600Callback.FastSwitchInventoryEnd"/>
        /// </summary>
        /// <returns></returns>
        int FastSwitchInventory(byte btReadId, byte[] btAryData, Action<IR600Message, R600TagInfo> FastSwitchInventory, Action<IR600Message, int, int> FastSwitchInventoryEnd);
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
        /// 设置Impinj Monza快速读TID功能
        /// <see cref="IR600Callback.GetMonzaStatus"/>
        /// </summary>
        /// <returns></returns>
        int GetMonzaStatus(byte btReadId, Action<IR600Message, byte> GetMonzaStatus);
        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// <see cref="IR600Callback.SetMonzaStatus"/>
        /// </summary>
        /// <returns></returns>
        int SetMonzaStatus(byte btReadId, byte btMonzaStatus, Action<IR600Message, byte> SetMonzaStatus);
        /// <summary>
        /// 获取存盘
        /// <see cref="IR600Callback.GetInventoryBuffer"/>
        /// </summary>
        /// <returns></returns>
        int GetInventoryBuffer(byte btReadId, Action<IR600Message, R600TagInfo> GetInventoryBuffer);
        /// <summary>
        /// 
        /// <see cref="IR600Callback.GetAndResetInventoryBuffer"/>
        /// </summary>
        /// <returns></returns>
        int GetAndResetInventoryBuffer(byte btReadId, Action<IR600Message, R600TagInfo> GetAndResetInventoryBuffer);
        /// <summary>
        /// 
        /// <see cref="IR600Callback.GetInventoryBufferTagCount"/>
        /// </summary>
        /// <returns></returns>
        int GetInventoryBufferTagCount(byte btReadId, Action<IR600Message, int> GetInventoryBufferTagCount);
        /// <summary>
        /// 
        /// <see cref="IR600Callback.ResetInventoryBuffer"/>
        /// </summary>
        /// <returns></returns>
        int ResetInventoryBuffer(byte btReadId, Action<IR600Message> ResetInventoryBuffer);
        /// <summary>
        /// 未实现
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btInterval"></param>
        /// <returns></returns>
        int SetBufferDataFrameInterval(byte btReadId, byte btInterval);
        /// <summary>
        /// 未实现
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetBufferDataFrameInterval(byte btReadId);
        /// <summary>
        /// 
        /// <see cref="IR600Callback.InventoryISO18000"/>
        /// </summary>
        /// <returns></returns>
        int InventoryISO18000(byte btReadId, Action<IR600Message, R600TagInfoIso18000> InventoryISO18000, Action<IR600Message, int> InventoryISO18000End);
        /// <summary>
        /// 
        /// <see cref="IR600Callback.ReadTagISO18000"/>
        /// </summary>
        /// <returns></returns>
        int ReadTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt, Action<IR600Message, byte, byte[]> ReadTagISO18000);
        /// <summary>
        /// 
        /// <see cref="IR600Callback.WriteTagISO18000"/>
        /// </summary>
        /// <returns></returns>
        int WriteTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt, byte[] btAryBuffer, Action<IR600Message, byte, byte> WriteTagISO18000);
        /// <summary>
        /// 
        /// <see cref="IR600Callback.LockTagISO18000"/>
        /// </summary>
        /// <returns></returns>
        int LockTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, Action<IR600Message, byte, R600LockTagStatus> LockTagISO18000);
        /// <summary>
        /// 
        /// <see cref="IR600Callback.QueryTagISO18000"/>
        /// </summary>
        /// <returns></returns>
        int QueryTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, Action<IR600Message, byte, R600LockTagStatus> QueryTagISO18000);
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