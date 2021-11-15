using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// R600命令类型
    /// </summary>
    public enum R600CmdType : byte
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// 读取GPIO状态
        /// </summary>
        ReadGpioValue = 0x60,
        /// <summary>
        /// 设置GPIO状态
        /// </summary>
        WriteGpioValue = 0x61,
        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        SetAntDetector = 0x62,
        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        GetAntDetector = 0x63,
        /// <summary>
        /// 设置读写器识别标记
        /// </summary>
        SetReaderIdentifier = 0x67,
        /// <summary>
        /// 读取读写器识别标记
        /// </summary>
        GetReaderIdentifier = 0x68,
        /// <summary>
        /// 设置射频通讯链路配置
        /// 备用名[SetRadioProfile]
        /// </summary>
        SetLinkProfile = 0x69,
        /// <summary>
        /// 读取射频通讯链路配置
        /// 备用名[GetRadioProfile]
        /// </summary>
        GetLinkProfile = 0x6A,
        /// <summary>
        /// 复位读写器
        /// 命令发送成功即可
        /// </summary>
        Reset = 0x70,
        /// <summary>
        /// 设置波特率
        /// </summary>
        SetUartBaudRate = 0x71,
        /// <summary>
        /// 获取固件版本
        /// </summary>
        GetFirmwareVersion = 0x72,
        /// <summary>
        /// 设置读写器地址
        /// </summary>
        SetReaderAddress = 0x73,
        /// <summary>
        /// 设置工作天线
        /// </summary>
        SetWorkAntenna = 0x74,
        /// <summary>
        /// 获取工作天线
        /// </summary>
        GetWorkAntenna = 0x75,
        /// <summary>
        /// 设置输出功率
        /// </summary>
        SetOutputPower = 0x76,
        /// <summary>
        /// 获取输出功率
        /// </summary>
        GetOutputPower = 0x77,
        /// <summary>
        /// 设置射频规范
        /// 备用名[SetUserDefineFrequency]
        /// </summary>
        SetFrequencyRegion = 0x78,
        /// <summary>
        /// 获取射频规范
        /// </summary>
        GetFrequencyRegion = 0x79,
        /// <summary>
        /// 设置蜂鸣器模式
        /// </summary>
        SetBeeperMode = 0x7A,
        /// <summary>
        /// 获取读写器温度
        /// </summary>
        GetReaderTemperature = 0x7B,
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        SetDrmMode = 0x7C,
        /// <summary>
        /// 获取DRM模式
        /// </summary>
        GetDrmMode = 0x7D,
        /// <summary>
        /// 测量天线端口阻抗匹配(回波损耗)
        /// 备用名[MeasureReturnLoss]
        /// </summary>
        GetAntImpedanceMatch = 0x7E,
        /// <summary>
        /// 盘存标签
        /// </summary>
        Inventory = 0x80,
        /// <summary>
        /// 读标签
        /// </summary>
        ReadTag = 0x81,
        /// <summary>
        /// 写标签
        /// </summary>
        WriteTag = 0x82,
        /// <summary>
        /// 锁定标签
        /// </summary>
        LockTag = 0x83,
        /// <summary>
        /// 销毁标签
        /// </summary>
        KillTag = 0x84,
        /// <summary>
        /// 选定/取消选定标签
        /// 备用名[CancelAccessEpcMatch]
        /// </summary>
        SetAccessEpcMatch = 0x85,
        /// <summary>
        /// 取得选定标签
        /// </summary>
        GetAccessEpcMatch = 0x86,
        /// <summary>
        /// 实时盘存/自定义Session和Inventoried Flag盘存
        /// </summary>
        InventoryReal = 0x89,
        /// <summary>
        /// 快速4天线盘存
        /// </summary>
        FastSwitchInventory = 0x8A,
        /// <summary>
        /// 自定义盘存
        /// </summary>
        CustomizedInventory = 0x8B,
        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// </summary>
        SetMonzaStatus = 0x8D,
        /// <summary>
        /// 读取Impinj Monza快速读TID功能
        /// </summary>
        GetMonzaStatus = 0x8E,
        /// <summary>
        /// 读取缓存标签
        /// </summary>
        GetInventoryBuffer = 0x90,
        /// <summary>
        /// 读取并重置缓存标签
        /// </summary>
        GetAndResetInventoryBuffer = 0x91,
        /// <summary>
        /// 读取缓存标签数量
        /// </summary>
        GetInventoryBufferTagCount = 0x92,
        /// <summary>
        /// 清空缓存
        /// </summary>
        ResetInventoryBuffer = 0x93,
        /// <summary>
        /// ***未实现
        /// </summary>
        SetBufferDataFrameInterval = 0x94,
        /// <summary>
        /// ***未实现
        /// </summary>
        GetBufferDataFrameInterval = 0x95,
        /// <summary>
        /// 盘存标签
        /// </summary>
        InventoryISO18000 = 0xB0,
        /// <summary>
        /// 读取标签
        /// </summary>
        ReadTagISO18000 = 0xB1,
        /// <summary>
        /// 写入标签
        /// </summary>
        WriteTagISO18000 = 0xB2,
        /// <summary>
        /// 永久写保护
        /// </summary>
        LockTagISO18000 = 0xB3,
        /// <summary>
        /// 查询标签
        /// </summary>
        QueryTagISO18000 = 0xB4,
    }
    /// <summary>
    /// 命令调用
    /// </summary>
    public static class R600CmdTypeCaller
    {
        /// <summary>
        /// 获取Enum名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static String ToEnumName(this R600CmdType type) => type switch
        {
            R600CmdType.Unknown => nameof(R600CmdType.Unknown),
            R600CmdType.ReadGpioValue => nameof(R600CmdType.ReadGpioValue),
            R600CmdType.WriteGpioValue => nameof(R600CmdType.WriteGpioValue),
            R600CmdType.SetAntDetector => nameof(R600CmdType.SetAntDetector),
            R600CmdType.GetAntDetector => nameof(R600CmdType.GetAntDetector),
            R600CmdType.SetReaderIdentifier => nameof(R600CmdType.SetReaderIdentifier),
            R600CmdType.GetReaderIdentifier => nameof(R600CmdType.GetReaderIdentifier),
            R600CmdType.SetLinkProfile => nameof(R600CmdType.SetLinkProfile),
            R600CmdType.GetLinkProfile => nameof(R600CmdType.GetLinkProfile),
            R600CmdType.Reset => nameof(R600CmdType.Reset),
            R600CmdType.SetUartBaudRate => nameof(R600CmdType.SetUartBaudRate),
            R600CmdType.GetFirmwareVersion => nameof(R600CmdType.GetFirmwareVersion),
            R600CmdType.SetReaderAddress => nameof(R600CmdType.SetReaderAddress),
            R600CmdType.SetWorkAntenna => nameof(R600CmdType.SetWorkAntenna),
            R600CmdType.GetWorkAntenna => nameof(R600CmdType.GetWorkAntenna),
            R600CmdType.SetOutputPower => nameof(R600CmdType.SetOutputPower),
            R600CmdType.GetOutputPower => nameof(R600CmdType.GetOutputPower),
            R600CmdType.SetFrequencyRegion => nameof(R600CmdType.SetFrequencyRegion),
            R600CmdType.GetFrequencyRegion => nameof(R600CmdType.GetFrequencyRegion),
            R600CmdType.SetBeeperMode => nameof(R600CmdType.SetBeeperMode),
            R600CmdType.GetReaderTemperature => nameof(R600CmdType.GetReaderTemperature),
            R600CmdType.SetDrmMode => nameof(R600CmdType.SetDrmMode),
            R600CmdType.GetDrmMode => nameof(R600CmdType.GetDrmMode),
            R600CmdType.GetAntImpedanceMatch => nameof(R600CmdType.GetAntImpedanceMatch),
            R600CmdType.Inventory => nameof(R600CmdType.Inventory),
            R600CmdType.ReadTag => nameof(R600CmdType.ReadTag),
            R600CmdType.WriteTag => nameof(R600CmdType.WriteTag),
            R600CmdType.LockTag => nameof(R600CmdType.LockTag),
            R600CmdType.KillTag => nameof(R600CmdType.KillTag),
            R600CmdType.SetAccessEpcMatch => nameof(R600CmdType.SetAccessEpcMatch),
            R600CmdType.GetAccessEpcMatch => nameof(R600CmdType.GetAccessEpcMatch),
            R600CmdType.InventoryReal => nameof(R600CmdType.InventoryReal),
            R600CmdType.FastSwitchInventory => nameof(R600CmdType.FastSwitchInventory),
            R600CmdType.CustomizedInventory => nameof(R600CmdType.CustomizedInventory),
            R600CmdType.SetMonzaStatus => nameof(R600CmdType.SetMonzaStatus),
            R600CmdType.GetMonzaStatus => nameof(R600CmdType.GetMonzaStatus),
            R600CmdType.GetInventoryBuffer => nameof(R600CmdType.GetInventoryBuffer),
            R600CmdType.GetAndResetInventoryBuffer => nameof(R600CmdType.GetAndResetInventoryBuffer),
            R600CmdType.GetInventoryBufferTagCount => nameof(R600CmdType.GetInventoryBufferTagCount),
            R600CmdType.ResetInventoryBuffer => nameof(R600CmdType.ResetInventoryBuffer),
            R600CmdType.SetBufferDataFrameInterval => nameof(R600CmdType.SetBufferDataFrameInterval),
            R600CmdType.GetBufferDataFrameInterval => nameof(R600CmdType.GetBufferDataFrameInterval),
            R600CmdType.InventoryISO18000 => nameof(R600CmdType.InventoryISO18000),
            R600CmdType.ReadTagISO18000 => nameof(R600CmdType.ReadTagISO18000),
            R600CmdType.WriteTagISO18000 => nameof(R600CmdType.WriteTagISO18000),
            R600CmdType.LockTagISO18000 => nameof(R600CmdType.LockTagISO18000),
            R600CmdType.QueryTagISO18000 => nameof(R600CmdType.QueryTagISO18000),
            _ => nameof(R600CmdType.Unknown),
        };
        /// <summary>
        /// 获取Enum名称
        /// <see cref="ToEnumName(R600CmdType)"/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static String GetEnumName(this R600CmdType type) => ToEnumName(type);
    }
}
