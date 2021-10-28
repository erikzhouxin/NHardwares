﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// R200数据接口类
    /// </summary>
    public class R2000Interfaces
    {
        /// <summary>
        /// 结果消息
        /// </summary>
        public interface IReceiveMessage
        {
            /// <summary>
            /// 当前消息
            /// </summary>
            IR600Message Current { get; set; }
            /// <summary>
            /// 阅读器标识
            /// </summary>
            byte ReadId { get; set; }
        }
        /// <summary>
        /// 获取射频规范结果
        /// <see cref="R600CmdType.GetFrequencyRegion"/>
        /// </summary>
        public interface GetFrequencyRegion : IReceiveMessage
        {
            /// <summary>
            /// 射频类型
            /// </summary>
            R600FreqRegionType FreqType { get; set; }
            /// <summary>
            /// 频率值
            /// </summary>
            double FreqValue { get; set; }
        }
        /// <summary>
        /// 盘点结存
        /// <see cref="R600CmdType.InventoryReal"/>
        /// </summary>
        public interface InventoryReal : IReceiveMessage
        {
            /// <summary>
            /// 读取速率
            /// </summary>
            int CurrentReadRate { get; set; }
            /// <summary>
            /// 读取计数
            /// </summary>
            int CurrentReadCount { get; set; }
            /// <summary>
            /// 当前标签列表
            /// </summary>
            Dictionary<string, R600TagInfo> CurrentTags { get; }
            /// <summary>
            /// 尝试添加标签
            /// </summary>
            /// <param name="tag"></param>
            bool TryAddTag(R600TagInfo tag);
        }
        /// <summary>
        /// 快速四天线盘存
        /// <see cref="R600CmdType.FastSwitchInventory"/>
        /// </summary>
        public interface FastSwitchInventory : InventoryReal, IReceiveMessage
        {

        }
        /// <summary>
        /// 读标签
        /// <see cref="R600CmdType.ReadTag"/>
        /// </summary>
        public interface ReadTag : IReceiveMessage
        {
            /// <summary>
            /// 当前标签列表
            /// </summary>
            Dictionary<string, R600TagInfo> CurrentTags { get; }
            /// <summary>
            /// 尝试添加标签
            /// </summary>
            /// <param name="tag"></param>
            /// <param name="area"></param>
            bool TryAddReadTag(R600TagInfo tag, R600AreaType area);
        }
        /// <summary>
        /// 取得选定标签
        /// <see cref="R600CmdType.GetAccessEpcMatch"/>
        /// </summary>
        public interface GetAccessEpcTag : IReceiveMessage
        {
            /// <summary>
            /// 当前标签
            /// </summary>
            byte[] CurrentEpc { get; set; }
            /// <summary>
            /// 比较当前EPC
            /// </summary>
            /// <param name="epc"></param>
            /// <returns></returns>
            bool EqualCurrentEpc(byte[] epc);
        }
        /// <summary>
        /// 设置选定标签
        /// <see cref="R600CmdType.SetAccessEpcMatch"/>
        /// </summary>
        public interface SetAccessEpcMatch : GetAccessEpcTag
        {
        }
        /// <summary>
        /// 设置工作天线
        /// <see cref="R600CmdType.SetWorkAntenna"/>
        /// </summary>
        public interface SetWorkAntenna: IReceiveMessage
        {
            /// <summary>
            /// 工作天线
            /// </summary>
            R600AntennaType CurrentAnt { get; set; }
        }
    }
}
