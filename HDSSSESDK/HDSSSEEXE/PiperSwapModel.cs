using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace System.Data.HDSSSEEXE
{
    /// <summary>
    /// 管道交换模型
    /// </summary>
    internal class PiperSwapModel
    {
        /// <summary>
        /// 命令/方法名
        /// </summary>
        public string Cmd { get; }
        /// <summary>
        /// IsTrue请求成功
        /// </summary>
        public bool IT { get; set; }
        /// <summary>
        /// 异常消息
        /// </summary>
        public String Msg { get; set; }
        /// <summary>
        /// 返回值
        /// </summary>
        public Int32 R { get; set; }
        /// <summary>
        /// ReaderHandle
        /// </summary>
        public Int32 RH { get; set; }
        /// <summary>
        /// 字符串1
        /// </summary>
        public StringBuilder S1 { get; set; }
        /// <summary>
        /// 字符串2
        /// </summary>
        public StringBuilder S2 { get; set; }
        /// <summary>
        /// 字符串3
        /// </summary>
        public StringBuilder S3 { get; set; }
        /// <summary>
        /// 字符串4
        /// </summary>
        public StringBuilder S4 { get; set; }
        /// <summary>
        /// 字符串5
        /// </summary>
        public StringBuilder S5 { get; set; }
        /// <summary>
        /// 字符串6
        /// </summary>
        public StringBuilder S6 { get; set; }
        /// <summary>
        /// 字符串7
        /// </summary>
        public StringBuilder S7 { get; set; }
        /// <summary>
        /// 字符串8
        /// </summary>
        public StringBuilder S8 { get; set; }
        /// <summary>
        /// 字符串9
        /// </summary>
        public StringBuilder S9 { get; set; }
        /// <summary>
        /// 字符串10
        /// </summary>
        public StringBuilder SA { get; set; }
        /// <summary>
        /// 字符串11
        /// </summary>
        public StringBuilder SB { get; set; }
        /// <summary>
        /// byte值
        /// </summary>
        public byte B1 { get; set; }
        /// <summary>
        /// byte值2
        /// </summary>
        public byte B2 { get; set; }
        /// <summary>
        /// int值
        /// </summary>
        public Int32 I1 { get; set; }
        /// <summary>
        /// ByteArray
        /// </summary>
        public byte[] A1 { get; set; }
        /// <summary>
        /// ByteArray
        /// </summary>
        public byte[] A2 { get; set; }
        /// <summary>
        /// byteArray
        /// </summary>
        public byte[] A3 { get; set; }
        /// <summary>
        /// byteArray
        /// </summary>
        public byte[] A4 { get; set; }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="cmd"></param>
        public PiperSwapModel(string cmd)
        {
            Cmd = cmd;
        }
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
        public static string GetJson(PiperSwapModel model) => JsonConvert.SerializeObject(model);
        /// <summary>
        /// 得到模型
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static PiperSwapModel GetModel(string json) => JsonConvert.DeserializeObject<PiperSwapModel>(json);
    }
}
