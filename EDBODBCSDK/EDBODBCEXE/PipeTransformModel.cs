using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.EDBODBCEXE
{
    /// <summary>
    /// 命名管道转换模型
    /// </summary>
    public class PipeTransformModel
    {
        /// <summary>
        /// 未找到代码
        /// </summary>
        public const String NotFoundCode = "404";
        /// <summary>
        /// 未找到命令
        /// </summary>
        public const String NotFoundCmd = "notfound";
        /// <summary>
        /// 响应代号
        /// </summary>
        public const String ResponseCode = "200";
        /// <summary>
        /// 响应命令
        /// </summary>
        public const String ResponseCmd = "response";
        /// <summary>
        /// 错误代号
        /// </summary>
        public const String ErrorCode = "500";
        /// <summary>
        /// 错误命令
        /// </summary>
        public const String ErrorCmd = "error";
        /// <summary>
        /// 标识
        /// </summary>
        public virtual String I { get; set; }
        /// <summary>
        /// 命令
        /// </summary>
        public virtual String C { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public virtual String M { get; set; }
        /// <summary>
        /// 参数值(Json模型)
        /// </summary>
        public virtual String P { get; set; }
        /// <summary>
        /// 返回值(Json模型)
        /// </summary>
        public virtual String R { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public virtual DateTime T { get; set; }
        /// <summary>
        /// 键
        /// </summary>
        public virtual String K { get; set; }
        /// <summary>
        /// 返回
        /// </summary>
        public virtual Boolean F { get; set; }
        /// <summary>
        /// 获取Json字符串
        /// </summary>
        /// <returns></returns>
        public string ToJson() => JsonConvert.SerializeObject(this);
        /// <summary>
        /// 得到JsonString
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string GetJson(PipeTransformModel model) => JsonConvert.SerializeObject(model);
        /// <summary>
        /// 得到模型
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static PipeTransformModel GetModel(string json) => JsonConvert.DeserializeObject<PipeTransformModel>(json);
    }
}
