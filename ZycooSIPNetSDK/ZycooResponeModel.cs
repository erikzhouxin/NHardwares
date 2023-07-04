using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ZycooSIPNetSDK
{
    /// <summary>
    /// 接口响应模型
    /// </summary>
    public interface IZycooResModel
    {
        /// <summary>
        /// 响应Json结果
        /// </summary>
        String ResponseJson { get; }
    }
    /// <summary>
    /// 接口相应模型
    /// </summary>
    public interface IZycooDataModel : IZycooResModel
    {
        /// <summary>
        /// 状态
        /// </summary>
        String Status { get; }
        /// <summary>
        /// 消息
        /// </summary>
        String Message { get; }
    }
    /// <summary>
    /// 接口响应模型
    /// </summary>
    public interface IZycooDataModel<T> : IZycooDataModel, IZycooResModel
    {
        /// <summary>
        /// 数据
        /// </summary>
        T Data { get; }
    }
    /// <summary>
    /// 接口消息模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IZycooMsgModel<T>
    {
        /// <summary>
        /// 消息信息
        /// </summary>
        T Message { get; }
    }
    /// <summary>
    /// 接口相应结果列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IZycooResModels<T> : IZycooDataModel, IZycooResModel
    {
        /// <summary>
        /// 查询结果总数
        /// </summary>
        Int32 Count { get; }
        /// <summary>
        /// 列表
        /// </summary>
        T[] Rows { get; }
    }
    /// <summary>
    /// 查询列表结果
    /// {
    ///     "count": 2,
    ///     "rows": []
    /// }
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ZycooResModels<T> : IZycooResModels<T>
    {
        /// <inheritdoc />
        public virtual String Status { get; }
        /// <inheritdoc />
        public virtual String Message { get; }
        /// <inheritdoc />
        public virtual Int32 Count { get; set; }
        /// <inheritdoc />
        public virtual T[] Rows { get; set; }
        /// <inheritdoc />
        public virtual String ResponseJson { get; set; }
    }
}
