using System;

namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 广播流状态信息
    /// typedef enum __EM_PUSHSTREAMSTA_TYPE 
    /// {
    ///   PSTREAM_OK=0,//正在推流
    ///   PSTREAM_Conning,     //正在连接
    ///   PSTREAM_ErrConn1,     //连接服务器失败
    ///   PSTREAM_ErrConn2,       //非法连接 
    ///   PSTREAM_UnConn,       //断开连接
    ///   PSTREAM_Complete          //推流完成 (如文件流时)
    /// }EM_PUSHSTREAMSTA_TYPE ;
    /// </summary>
    public enum NETEM_PUSHSTREAMSTA_TYPE
    {
        /// <summary>
        /// 推流完成 (如文件流时)
        /// </summary>
        PSTREAM_Complete = 5,
        /// <summary>
        /// 断开连接
        /// </summary>
        PSTREAM_UnConn = 4,
        /// <summary>
        /// 非法连接 
        /// </summary>
        PSTREAM_ErrConn2 = 3,
        /// <summary>
        /// 连接服务器失败
        /// </summary>
        PSTREAM_ErrConn1 = 2,
        /// <summary>
        /// 正在连接
        /// </summary>
        PSTREAM_Conning = 1,
        /// <summary>
        /// 正在推流
        /// </summary>
        PSTREAM_OK = 0
    }
}
