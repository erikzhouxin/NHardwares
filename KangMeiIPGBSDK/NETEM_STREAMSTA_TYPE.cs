using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 广播流状态信息
     * typedef enum __EM_STREAMSTA_TYPE 
     * {
     *   GBSTREAM_CREATE_OK=0,//广播流创建成功
     *   GBSTREAM_CREATE_ERROR,     //广播流创建失败
     *   GBSTREAM_DEL            //广播流已删除
     * }EM_STREAMSTA_TYPE;
     **/
    public enum NETEM_STREAMSTA_TYPE
    {
        /// <summary>
        /// 广播流已删除
        /// </summary>
        GBSTREAM_DEL = 2,
        /// <summary>
        /// 广播流创建失败
        /// </summary>
        GBSTREAM_CREATE_ERROR = 1,
        /// <summary>
        /// 广播流创建成功
        /// </summary>
        GBSTREAM_CREATE_OK = 0
    }
}
