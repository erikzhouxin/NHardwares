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
        R2000Interfaces.SetWorkAntenna
    {
        /// <summary>
        /// 当前消息
        /// </summary>
        public virtual IR600Message Current { get; set; }
        /// <summary>
        /// 阅读器标识
        /// </summary>
        public virtual byte ReadId { get; set; } = 0xFF;
        /// <summary>
        /// 射频类型
        /// </summary>
        public virtual R600FreqRegionType FreqType { get; set; }
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
        public R600AntennaType CurrentAnt { get; set; }

        /// <summary>
        /// 比较当前EPC相等
        /// </summary>
        /// <param name="epc"></param>
        /// <returns></returns>
        public bool EqualCurrentEpc(byte[] epc)
        {
            if (epc == null || CurrentEpc == null) { return false; }
            if (epc.Length != CurrentEpc.Length) { return false; }
            for (int i = 0; i < epc.Length; i++)
            {
                if (epc[i] != CurrentEpc[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 尝试添加读标签内容
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="area"></param>
        public bool TryAddReadTag(R600TagInfo tag, R600AreaType area)
        {
            if (CurrentTags.TryGetValue(tag.Key, out R600TagInfo tagInfo))
            {
                tagInfo.AntId = tag.AntId;
                tagInfo.CRC = tag.CRC;
                switch (area)
                {
                    case R600AreaType.Reserved:
                        tagInfo.Reserved = tag.Data;
                        break;
                    case R600AreaType.TID:
                        tagInfo.Tid = tag.Data;
                        break;
                    case R600AreaType.User:
                        tagInfo.User = tag.Data;
                        break;
                    case R600AreaType.EPC:
                    default:
                        break;
                }
                return true;
            }
            CurrentTags[tag.Key] = tag;
            return false;
        }

        /// <summary>
        /// 尝试添加
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public bool TryAddTag(R600TagInfo tag)
        {
            if (Monitor.TryEnter(CurrentTags, TimeSpan.FromSeconds(1)))
            {
                if (CurrentTags.TryGetValue(tag.Key, out R600TagInfo model))
                {
                    // todo:更新值
                }
                else
                {
                    CurrentTags[tag.Key] = tag;
                }
                Monitor.Exit(CurrentTags);
                return true;
            }
            return false;
        }
    }
}
