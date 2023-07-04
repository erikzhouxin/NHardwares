using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Data.Extter;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace System.Data.SolutionCore
{
    /// <summary>
    /// 网络请求模型
    /// </summary>
    public interface IZycooHttpClientModel
    {
        /// <summary>
        /// 获取响应JsonString结果
        /// </summary>
        /// <returns></returns>
        String GetResponseJsonString();
    }
    /// <summary>
    /// 请求类模型
    /// </summary>
    public abstract class AZycooHttpClientModel : HttpClient, IZycooHttpClientModel
    {
        #region // 常量值
        /// <summary>
        /// 
        /// </summary>
        public const string JsonAcceptString = "application/json";
        /// <summary>
        /// 
        /// </summary>
        public const string FormSubmitString = "application/x-www-form-urlencoded";
        #endregion 常量值
        #region // 默认值
        /// <summary>
        /// 默认编码
        /// </summary>
        public static Encoding DefaultEncoding { get; set; } = Encoding.UTF8;
        /// <summary>
        /// 默认超时时间(8秒)
        /// </summary>
        public static Int32 DefaultTimeout { get; set; } = 8;
        /// <summary>
        /// 默认接收格式
        /// </summary>
        public static String DefaultAccept { get; set; } = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        /// <summary>
        /// 默认用户代理
        /// 参考: User-Agent:Mozilla/5.0 (Windows NT 5.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1
        /// </summary>
        public static String DefaultUserAgent { get; set; } = "";
        /// <summary>
        /// 默认内容类型
        /// </summary>
        public static String DefaultContentType { get; set; } = "application/json";
        /// <summary>
        /// 默认头字典
        /// </summary>
        public static Func<Dictionary<string, String>> DefaultHeader { get; set; } = () => new Dictionary<string, String>()
        {
            { "Accept-Language", "zh-CN,zh;q=0." },
            { "Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3" },
        };
        /// <summary>
        /// 转换成Json设置
        /// </summary>
        public static JsonSerializerSettings DefaultJsonFormatSetting { get; } = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DateFormatString = "yyyy-MM-dd HH:mm:ss",
        };
        #endregion 默认值
        #region // 设置属性
        /// <summary>
        /// 链接地址
        /// </summary>
        public virtual String Url { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public virtual Encoding Encoding { get; set; }
        /// <summary>
        /// 请求头
        /// </summary>
        public virtual Dictionary<string, String> Headers { get; set; }
        /// <summary>
        /// 请求方法,默认POST
        /// <see cref="HttpClientMethodType"/>
        /// </summary>
        public virtual string Method { get; set; }
        /// <summary>
        /// 接收
        /// </summary>
        public virtual String Accept { get; set; }
        /// <summary>
        /// 用户代理
        /// </summary>
        public virtual string UserAgent { get; set; }
        /// <summary>
        /// 内容类型
        /// </summary>
        public virtual String ContentType { get; set; }
        /// <summary>
        /// 检测死连接
        /// </summary>
        public virtual bool KeepAlive { get; set; }
        /// <summary>
        /// 参数模型(Post对象)
        /// </summary>
        public virtual object BodyArgs { get; set; }
        /// <summary>
        /// 请求参数字典
        /// </summary>
        public virtual Dictionary<string, string> UrlArgs { get; }
        /// <summary>
        /// Json序列化设置
        /// </summary>
        public virtual JsonSerializerSettings JsonFormatSetting { get; set; }
        /// <summary>
        /// 令牌Headers[Authorization]
        /// 如果Headers存在此内容,则根据此是否为空判断是否覆盖
        /// </summary>
        public virtual String Authorization { get; set; }
        /// <summary>
        /// referer挺重要的，有些网站会根据这个来反盗链
        /// </summary>
        public virtual String Referer { get; set; }
        /// <summary>
        /// 过滤Jsonp正则
        /// </summary>
        public virtual Tuble3CheckString FilterJsonpRegex { get; set; }
        #endregion 设置属性
        /// <summary>
        /// 构造
        /// </summary>
        public AZycooHttpClientModel(string url) : base(GetHttpClientHandler())
        {
            Url = url;
            Method = nameof(HttpClientMethodType.POST);
            Accept = DefaultAccept;
            UserAgent = DefaultUserAgent;
            ContentType = DefaultContentType;
            Headers = DefaultHeader?.Invoke() ?? new Dictionary<string, string>();
            Timeout = TimeSpan.FromSeconds(DefaultTimeout);
            JsonFormatSetting = DefaultJsonFormatSetting;
            Authorization = String.Empty;
            Encoding = DefaultEncoding;
            FilterJsonpRegex = new Tuble3CheckString(true, @"^[\w]*\(([\s\S\r\n]+)\);?$", "$1");
            UrlArgs = new Dictionary<string, string>();
            BodyArgs = new { };
        }

        private static HttpClientHandler GetHttpClientHandler()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
#if NETCore || NET60
            clientHandler.SslProtocols = Security.Authentication.SslProtocols.Tls
                | Security.Authentication.SslProtocols.Tls11
                | Security.Authentication.SslProtocols.Tls12
                | Security.Authentication.SslProtocols.Tls13;
#endif
#if NETFx
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
#endif
            return clientHandler;
        }
        /// <summary>
        /// 响应字符串
        /// </summary>
        public virtual String ResString { get; set; }
        /// <summary>
        /// Json内部字符串
        /// </summary>
        protected string _jsonString;
        /// <summary>
        /// Json字符串
        /// </summary>
        public virtual String JsonString
        {
            get => _jsonString;
            set
            {
                ResString = value;
                _jsonString = GetJsonFromJsonp(value);
            }
        }
        /// <summary>
        /// 从Jsonp获取Json
        /// </summary>
        /// <param name="resJson"></param>
        /// <returns></returns>
        public virtual String GetJsonFromJsonp(string resJson)
        {
            if (string.IsNullOrEmpty(resJson)) { return resJson; }
            if (FilterJsonpRegex == null || !FilterJsonpRegex.Item1) { return resJson; }
            if (resJson.StartsWith("[") || resJson.StartsWith("{")) { return resJson; }
            var regEx = new Regex(FilterJsonpRegex.Item2);
            return regEx.Replace(resJson, FilterJsonpRegex.Item3);
        }
        /// <inheritdoc />
        public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            SendSetting(request);
            return base.SendAsync(request, cancellationToken);
        }
        /// <summary>
        /// 发送设置
        /// </summary>
        /// <param name="request"></param>
        public virtual void SendSetting(HttpRequestMessage request)
        {
            var header = this.DefaultRequestHeaders;
            if (!string.IsNullOrEmpty(this.Accept))
            {
                header.Add(nameof(Accept), this.Accept);
            }
            if (!string.IsNullOrEmpty(this.UserAgent))
            {
                header.Add(nameof(UserAgent), this.UserAgent);
            }
            if (!string.IsNullOrEmpty(this.ContentType))
            {
                header.Add(nameof(ContentType), this.ContentType);
                //header.Add("Content-Type", this.ContentType);
            }
            request.Method = new HttpMethod(Method);
            header.Add("Connection", "keep-alive");
            if (!string.IsNullOrEmpty(this.Referer))
            {
                header.Add(nameof(Referer), this.Referer);
            }
            foreach (var item in this.Headers)
            {
                header.Add(item.Key, item.Value);
            }
            if (!string.IsNullOrEmpty(this.Authorization))
            {
                header.Add(nameof(Authorization), this.Authorization);
            }
        }
        /// <summary>
        /// 获取响应JsonString结果
        /// </summary>
        /// <returns></returns>
        public abstract String GetResponseJsonString();
        /// <summary>
        /// 设置URL参数
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public virtual AZycooHttpClientModel SetUrlArgs(Dictionary<string, string> dictionary)
        {
            foreach (var item in dictionary)
            {
                UrlArgs[item.Key] = item.Value;
            }
            return this;
        }
        /// <summary>
        /// 设置URL参数
        /// </summary>
        /// <returns></returns>
        public virtual AZycooHttpClientModel SetUrlArgs(string key, string value)
        {
            UrlArgs[key] = value;
            return this;
        }
        /// <summary>
        /// 获取请求URL
        /// </summary>
        /// <returns></returns>
        public virtual String GetRequestUrl()
        {
           var url = Url;
            if (UrlArgs.Count() > 0)
            {
                url = url.TrimEnd('?');
                //if (url.Contains("?")) { url += "&"; }
                //else { url += "?"; }
                if (url.Contains('?')) { url += $"&ezxt={DateTime.Now.DistanceFrom1970Seconds()}.{(int)Timeout.TotalSeconds}"; }
                else { url += $"?ezxt={DateTime.Now.DistanceFrom1970Seconds()}.{(int)Timeout.TotalSeconds}"; }
                var urlSb = new StringBuilder(url);
                foreach (var item in UrlArgs)
                //{ urlSb.Append($"{item.Key}={Uri.EscapeDataString(item.Value ?? string.Empty)}&"); }
                { urlSb.Append($"&{item.Key}={Uri.EscapeDataString(item.Value ?? string.Empty)}"); }
                url = urlSb.ToString();
            }
            return url;
        }
    }
    /// <summary>
    /// 推送模型
    /// </summary>
    public class HttpClientPostModel : AZycooHttpClientModel
    {
        /// <summary>
        /// 方法
        /// </summary>
        public override string Method { get => nameof(HttpClientMethodType.POST); set { } }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="url"></param>
        public HttpClientPostModel(string url) : base(url) { }
        /// <summary>
        /// 获取响应JsonString结果
        /// </summary>
        /// <returns></returns>
        public override string GetResponseJsonString()
        {
            string jsonObj = JsonConvert.SerializeObject(this.BodyArgs, this.JsonFormatSetting);
            var content = new StringContent(jsonObj, Encoding);
            if (!string.IsNullOrEmpty(this.ContentType))
            {
                content.Headers.ContentType = new Net.Http.Headers.MediaTypeHeaderValue(this.ContentType);
            }
            var result = this.PostAsync(GetRequestUrl(), content).Result;
            return result.Content.ReadAsStringAsync().Result;
        }
    }
    /// <summary>
    /// 存放模型
    /// </summary>
    public class HttpClientPutModel : AZycooHttpClientModel
    {
        /// <summary>
        /// 方法
        /// </summary>
        public override string Method { get => nameof(HttpClientMethodType.PUT); set { } }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="url"></param>
        public HttpClientPutModel(string url) : base(url) { }
        /// <summary>
        /// 获取响应JsonString结果
        /// </summary>
        /// <returns></returns>
        public override string GetResponseJsonString()
        {
            string jsonObj = JsonConvert.SerializeObject(this.BodyArgs, this.JsonFormatSetting);
            var content = new StringContent(jsonObj, Encoding);
            if (!string.IsNullOrEmpty(this.ContentType))
            {
                content.Headers.ContentType = new Net.Http.Headers.MediaTypeHeaderValue(this.ContentType);
            }
            var result = this.PutAsync(GetRequestUrl(), content).Result;
            return result.Content.ReadAsStringAsync().Result;
        }
    }
    /// <summary>
    /// 推送模型
    /// </summary>
    public class HttpClientGetModel : AZycooHttpClientModel
    {
        /// <summary>
        /// 方法
        /// </summary>
        public override string Method { get => nameof(HttpClientMethodType.GET); set { } }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="url"></param>
        public HttpClientGetModel(string url) : base(url) { }
        /// <summary>
        /// 获取响应JsonString结果
        /// </summary>
        /// <returns></returns>
        public override string GetResponseJsonString()
        {
            using (var msg = new HttpRequestMessage(HttpMethod.Get, GetRequestUrl()))
            {
                SendSetting(msg);
                using (var resp = this.SendAsync(msg).Result)
                {
                    resp.EnsureSuccessStatusCode();
                    return resp.Content.ReadAsStringAsync().Result;
                }
            }
        }
    }
    /// <summary>
    /// 删除模型
    /// </summary>
    public class HttpClientDeleteModel : AZycooHttpClientModel
    {
        /// <summary>
        /// 方法
        /// </summary>
        public override string Method { get => nameof(HttpClientMethodType.DELETE); set { } }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="url"></param>
        public HttpClientDeleteModel(string url) : base(url) { }
        /// <summary>
        /// 获取响应JsonString结果
        /// </summary>
        /// <returns></returns>
        public override string GetResponseJsonString()
        {
            using (var msg = new HttpRequestMessage(HttpMethod.Delete, GetRequestUrl()))
            {
                SendSetting(msg);
                using (var resp = this.SendAsync(msg).Result)
                {
                    resp.EnsureSuccessStatusCode();
                    return resp.Content.ReadAsStringAsync().Result;
                }
            }
        }
    }
    /// <summary>
    /// 请求类型
    /// </summary>
    public enum HttpClientMethodType
    {
        /// <summary>
        /// 默认POST
        /// </summary>
        UNKNOWN = 0,
        /// <summary>
        /// GET
        /// </summary>
        GET = 1,
        /// <summary>
        /// POST
        /// </summary>
        POST = 2,
        /// <summary>
        /// PUT
        /// </summary>
        PUT = 4,
        /// <summary>
        /// DELETE
        /// </summary>
        DELETE = 8,
        /// <summary>
        /// HEAD
        /// </summary>
        HEAD = 16,
        /// <summary>
        /// OPTIONS
        /// </summary>
        OPTIONS = 32,
        /// <summary>
        /// PATCH
        /// </summary>
        PATCH = 64,
        /// <summary>
        /// TRACE
        /// </summary>
        TRACE = 128,
        /// <summary>
        /// CONNECT
        /// </summary>
        CONNECT = 256,
    }
}
