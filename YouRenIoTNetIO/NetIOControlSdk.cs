using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Extter;
using System.Data.NHInterfaces;
using System.Linq;
using System.Text;

namespace System.Data.YouRenIoTNetIO
{
    /// <summary>
    /// 网络IO控制器SDK
    /// </summary>
    public static class NetIOControlSdk
    {
        static NetIOControlSdk()
        {
        }
        /// <summary>
        /// 创建一个IO控制器
        /// </summary>
        /// <param name="controlType"></param>
        /// <returns></returns>
        public static IUsrIOControlProxy CreateIOControl(IOControlType controlType)
        {
            return new UsrIOControlProxy(controlType);
        }
        /// <summary>
        /// 获取序号值
        /// </summary>
        /// <param name="noType"></param>
        /// <returns></returns>
        public static Tuble<int[], int[]> GetNoType(this IOControlNoType noType) => GetNoType2((ulong)noType);
        /// <summary>
        /// 获取序号值 推荐使用
        /// </summary>
        /// <returns></returns>
        public static Tuble<int[], int[]> GetNoType2(ulong typeVal)
        {
            var outList = new List<int>(7);
            for (int i = 0; i < 32; i++)
            {
                if (((typeVal >> i) & 1) == 1) { outList.Add(i); }
            }
            var inList = new List<int>(7);
            for (int i = 32; i < 64; i++)
            {
                if (((typeVal >> i) & 1) == 1) { inList.Add(i - 32); }
            }
            return new Tuble<int[], int[]>(outList.ToArray(), inList.ToArray());
        }
        /// <summary>
        /// 获取序号值
        /// <see cref="GetNoType2(ulong)"/>
        /// </summary>
        /// <returns></returns>
        public static Tuble<int[], int[]> GetNoType(ulong typeVal)
        {
            return new Tuble<int[], int[]>(InnerGetNoType((uint)typeVal), InnerGetNoType((uint)(typeVal >> 32)));
            static int[] InnerGetNoType(uint outVal)
            {
                var outList = new List<int>(7);
                for (int i = 0; i < 32; i++)
                {
                    if (((outVal >> i) & 1) == 1) { outList.Add(i); }
                }
                return outList.ToArray();
            }
        }
        /// <summary>
        /// 获取序号值 推荐使用
        /// </summary>
        /// <returns></returns>
        public static Tuble<int[], int[]> GetNoType3(ulong typeVal)
        {
            var bitArray = new BitArray(typeVal.GetBytes());
            var outList = new List<int>(7);
            for (int i = 0; i < 32; i++)
            {
                if (bitArray[i]) { outList.Add(i); }
            }
            var inList = new List<int>(7);
            for (int i = 32; i < 64; i++)
            {
                if (bitArray[i]) { inList.Add(i - 32); }
            }
            return new Tuble<int[], int[]>(outList.ToArray(), inList.ToArray());
        }
    }
}
