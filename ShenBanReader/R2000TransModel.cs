using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 模型
    /// </summary>
    public class R2000TransModel :
        R2000Interfaces.GetFrequencyRegion,
        R2000Interfaces.InventoryReal,
        R2000Interfaces.FastSwitchInventory,
        R2000Interfaces.SetAccessEpcMatch,
        R2000Interfaces.GetAccessEpcTag,
        R2000Interfaces.ReadTag,
        R2000Interfaces.WriteTag,
        R2000Interfaces.SetWorkAntenna
    {
        /// <summary>
        /// 当前消息
        /// </summary>
        public virtual IReadMessage Current { get; set; }
        /// <summary>
        /// 阅读器标识
        /// </summary>
        public virtual byte ReadId { get; set; } = 0xFF;
        /// <summary>
        /// 射频类型
        /// </summary>
        public virtual ReadFreqRegionType FreqType { get; set; }
        /// <summary>
        /// 射频值
        /// </summary>
        public virtual double FreqValue { get; set; }
        /// <summary>
        /// 当前读取速率
        /// </summary>
        public int CurrentReadRate { get; set; }
        /// <summary>
        /// 当前读取计数
        /// </summary>
        public int CurrentReadCount { get; set; }
        /// <summary>
        /// 当前标签
        /// </summary>
        public Dictionary<string, R600TagInfo> CurrentTags { get; } = new Dictionary<string, R600TagInfo>();
        /// <summary>
        /// 当前选定的EPC
        /// </summary>
        public byte[] CurrentEpc { get; set; } = new byte[] { };
        /// <summary>
        /// 工作天线
        /// </summary>
        public ReadAntennaType CurrentAnt { get; set; }

        /// <summary>
        /// 比较当前EPC相等
        /// </summary>
        /// <param name="epc"></param>
        /// <returns></returns>
        public bool EqualCurrentEpc(byte[] epc) => ReaderCaller.EqualBytes(CurrentEpc, epc, false);

        /// <summary>
        /// 尝试添加读标签内容
        /// </summary>
        /// <param name="tag"></param>
        public bool TryAddReadTag(R600TagInfo tag)
        {
            if (CurrentTags.TryGetValue(tag.Key, out R600TagInfo tagInfo))
            {
                tagInfo.AntId = tag.AntId;
                tagInfo.CRC = tag.CRC;
                tagInfo.Data = tag.Data;
                if (tag.User != null && tag.User.Length > 0)
                {
                    tagInfo.User = tag.User;
                }
                if (tag.Tid != null && tag.Tid.Length > 0)
                {
                    tagInfo.Tid = tag.Tid;
                }
                if (tag.Reserved != null && tag.Reserved.Length > 0)
                {
                    tagInfo.Reserved = tag.Reserved;
                }
                return false;
            }
            CurrentTags[tag.Key] = tag;
            return true;
        }
        /// <summary>
        /// 尝试添加标签
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="key"></param>
        public bool TryAddWriteTag(R600TagInfo tag, string key)
        {
            byte[] tid = null;
            if (CurrentTags.TryGetValue(key, out R600TagInfo tagInfo))
            {
                tid = tagInfo.Tid;
            }
            if(tag.Tid == null)
            {
                tag.Tid = tid;
            }
            CurrentTags[tag.Key] = tag;
            return true;
        }
        /// <summary>
        /// 尝试添加盘存标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public bool TryAddRealTag(R600TagInfo tag)
        {
            if (CurrentTags.TryGetValue(tag.Key, out R600TagInfo model))
            {
                model.PC = tag.PC;
                model.AntId = tag.AntId;
                model.INVCNT = tag.INVCNT;
                model.FREQ = tag.FREQ;
                model.RSSI = tag.RSSI;
                return false;
            }
            CurrentTags[tag.Key] = tag;
            return true;
        }
        /// <summary>
        /// 尝试添加快速标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public bool TryAddFastTag(R600TagInfo tag)
        {
            if (CurrentTags.TryGetValue(tag.Key, out R600TagInfo model))
            {
                model.PC = tag.PC;
                model.AntId = tag.AntId;
                model.INVCNT = tag.INVCNT;
                model.FREQ = tag.FREQ;
                model.RSSI = tag.RSSI;
                return false;
            }
            CurrentTags[tag.Key] = tag;
            return true;
        }
    }
}
