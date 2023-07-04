namespace System.Data.ZycooSIPNetSDK
{
    /// <summary>
    /// 权限认证登录结果模型
    /// 返回认证成功结果
    /// {
    ///     "status": "success",
    ///     "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6ImFkbWluIiwidXNlcklkIjoxLCJleHAiOjE1OTY3NzkwMjksImlhdCI6MTU5NDE4NzAyOX0.DZ1t0juJLXLO7rFQ48y9yGLQRd0G_jcKBRWE48UhC1U",
    ///     "username": "admin",
    ///     "userId": 1
    /// }
    /// 返回认证失败结果
    /// { "status": "Unauthorized" }
    /// 参数名 类型 描述
    /// status String 认证结果
    /// token String 认证成功返回 token，调用接口会使用该 token 进行认证
    /// username String 认证用户名
    /// userId int 认证用户的 ID
    /// <see cref="IZycooSIPNetApiProxyV1.Login"/>
    /// </summary>
    public class ZycooLoginModel : IZycooResModel
    {
        /// <summary>
        /// 判断登录结果是成功
        /// </summary>
        public static Func<ZycooLoginModel, bool> FuncGetSuccess { get; set; } = (m) => m.Status == ZycooConfigModelV1.ZStatusSuccess;
        /// <summary>
        /// 状态
        /// </summary>
        public virtual String Status { get; set; }
        /// <summary>
        /// 是成功
        /// </summary>
        public virtual bool IsSuccess => FuncGetSuccess.Invoke(this);
        /// <summary>
        /// 用户名
        /// </summary>
        public virtual String Username { get; set; }
        /// <summary>
        /// 用户标识
        /// </summary>
        public virtual Int32 UserId { get; set; }
        /// <summary>
        /// 令牌内容
        /// </summary>
        public virtual String Token { get; set; }
        /// <inheritdoc />
        public virtual String ResponseJson { get; set; }
    }
}