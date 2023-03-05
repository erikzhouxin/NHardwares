using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Extter;
using System.Linq;
using System.Text;

namespace System.Data.NHInterfaces
{
    /// <summary>
    /// 硬件接口调用类
    /// </summary>
    public static class NHInterfacesCaller
    {
        #region // IO控制器
        /// <summary>
        /// 获取序号值 推荐使用
        /// </summary>
        /// <returns></returns>
        public static Tuble<int[], int[]> GetIONoType(this IOControlNoType type) => GetIONoType((ulong)type);
        /// <summary>
        /// 获取序号值 推荐使用
        /// </summary>
        /// <returns></returns>
        public static Tuble<IOControlDOType[], IOControlDIType[]> GetIOEnumType(this IOControlNoType type)
        {
            var typeVal = (ulong)type;
            var outList = new List<IOControlDOType>(4);
            for (int i = 0; i < 32; i++)
            {
                if (((typeVal >> i) & 1) == 1) { outList.Add((IOControlDOType)(i + 1)); }
            }
            var inList = new List<IOControlDIType>(4);
            for (int i = 32; i < 64; i++)
            {
                if (((typeVal >> i) & 1) == 1) { inList.Add((IOControlDIType)(i - 31)); }
            }
            return new Tuble<IOControlDOType[], IOControlDIType[]>(outList.ToArray(), inList.ToArray());
        }
        /// <summary>
        /// 获取序号值 推荐使用
        /// </summary>
        /// <returns></returns>
        public static Tuble<int[], int[]> GetIONoType(ulong typeVal)
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
        #endregion IO控制器
    }
}
