using System;
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
            IReadMessage Current { get; set; }
            /// <summary>
            /// 阅读器标识
            /// </summary>
            byte ReadId { get; set; }
        }
        /// <summary>
        /// 获取射频规范结果
        /// <see cref="ReadCmdType.GetFrequencyRegion"/>
        /// </summary>
        public interface GetFrequencyRegion : IReceiveMessage
        {
            /// <summary>
            /// 射频类型
            /// </summary>
            ReadFreqRegionType FreqType { get; set; }
            /// <summary>
            /// 频率值
            /// </summary>
            double FreqValue { get; set; }
        }
        /// <summary>
        /// 盘点结存
        /// <see cref="ReadCmdType.InventoryReal"/>
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
            bool TryAddRealTag(R600TagInfo tag);
        }
        /// <summary>
        /// 快速四天线盘存
        /// <see cref="ReadCmdType.FastSwitchInventory"/>
        /// </summary>
        public interface FastSwitchInventory : IReceiveMessage
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
            /// 尝试添加快速读标签
            /// </summary>
            /// <param name="tag"></param>
            /// <returns></returns>
            bool TryAddFastTag(R600TagInfo tag);
        }
        /// <summary>
        /// 读标签
        /// <see cref="ReadCmdType.ReadTag"/>
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
            bool TryAddReadTag(R600TagInfo tag);
        }
        /// <summary>
        /// 写标签
        /// <see cref="ReadCmdType.WriteTag"/>
        /// </summary>
        public interface WriteTag : IReceiveMessage
        {
            /// <summary>
            /// 当前标签列表
            /// </summary>
            Dictionary<string, R600TagInfo> CurrentTags { get; }
            /// <summary>
            /// 尝试添加标签
            /// </summary>
            /// <param name="tag"></param>
            /// <param name="key"></param>
            bool TryAddWriteTag(R600TagInfo tag, string key);
        }
        /// <summary>
        /// 取得选定标签
        /// <see cref="ReadCmdType.GetAccessEpcMatch"/>
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
        /// <see cref="ReadCmdType.SetAccessEpcMatch"/>
        /// </summary>
        public interface SetAccessEpcMatch : GetAccessEpcTag
        {
        }
        /// <summary>
        /// 设置工作天线
        /// <see cref="ReadCmdType.SetWorkAntenna"/>
        /// </summary>
        public interface SetWorkAntenna : IReceiveMessage
        {
            /// <summary>
            /// 工作天线
            /// </summary>
            ReadAntennaType CurrentAnt { get; set; }
        }
    }
}
