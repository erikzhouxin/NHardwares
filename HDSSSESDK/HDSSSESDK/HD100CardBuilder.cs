using System;
using System.Collections.Generic;
using System.Text;

namespace System.Data.HDSSSESDK
{
    /// <summary>
    /// 创建类
    /// </summary>
    public class HD100CardBuilder
    {
        /// <summary>
        /// 创建一个实例
        /// SDK原生不支持64位,所以64位可能有性能损耗
        /// </summary>
        /// <returns></returns>
        public static IHD100CardApi Create()
        {
            if(IntPtr.Size == 8)
            {
                return HD100CardApi64.Instance;
            }
            return new HD100CardApi();
        }
    }
}
