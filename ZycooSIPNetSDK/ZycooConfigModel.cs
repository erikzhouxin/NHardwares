using System;

namespace System.Data.ZycooSIPNetSDK
{
    /// <summary>
    /// 智科通信SIP融合通信中心接口模型
    /// 版本v1.0.9
    /// </summary>
    public class ZycooConfigModelV1
    {
        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Address { get; set; } = "192.168.1.100";
        /// <summary>
        /// 端口
        /// </summary>
        public virtual Int32 PortRate { get; set; } = 443;
        /// <summary>
        /// 账号
        /// </summary>
        public virtual String Account { get; set; } = "admin";
        /// <summary>
        /// 密码
        /// </summary>
        public virtual String Password { get; set; } = "admin";
        /// <summary>
        /// 是检查
        /// </summary>
        public virtual bool IsCheck { get; set; } = true;
        /// <summary>
        /// 检查间隔(单位分钟)
        /// </summary>
        public virtual int CheckInterval { get; set; } = 30;
        /// <summary>
        /// 是HTTPS访问
        /// </summary>
        public virtual bool IsHttps { get; set; } = true;
        /// <summary>
        /// 访问令牌
        /// </summary>
        public virtual String Token { get; set; } = string.Empty;
        /// <summary>
        /// 默认Header中的Accept内容
        /// application/json
        /// </summary>
        public virtual String DefaultAccept { get; set; } = "application/json";
        /// <summary>
        /// 权限认证接口地址
        /// POST => http://192.168.12.178:8000/coocenter-api/local/login
        /// <see cref="IZycooSIPNetApiProxyV1.Login()"/>
        /// </summary>
        public virtual String ZApiLocalLogin { get; set; } = "coocenter-api/local/login";
        /// <summary>
        /// SIP账号查询
        /// GET => http://192.168.12.178:8000/coocenter-api/plugin-config/extensions
        /// <see cref="IZycooSIPNetApiProxyV1.AccountSearch(int, int, String)"/>
        /// </summary>
        public virtual String ZApiAccountSearch { get; set; } = "coocenter-api/plugin-config/extensions";
        /// <summary>
        /// SIP 账号创建
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-config/extensions
        /// <see cref="IZycooSIPNetApiProxyV1.AccountAdd(ZycooAccountAddModel)"/>
        /// </summary>
        public virtual String ZApiAccountAdd { get; set; } = "coocenter-api/plugin-config/extensions";
        /// <summary>
        /// SIP 账号修改
        /// PUT => http://192.168.12.178:8000/coocenter-api/plugin-config/extensions
        /// <see cref="IZycooSIPNetApiProxyV1.AccountEdit(ZycooAccountEditModel)"/>
        /// </summary>
        public virtual String ZApiAccountEdit { get; set; } = "coocenter-api/plugin-config/extensions";
        /// <summary>
        /// SIP 账号删除
        /// DELETE => http://192.168.12.178:8000/coocenter-api/plugin-config/extensions
        /// </summary>
        public virtual String ZApiAccountDelete { get; set; } = "coocenter-api/plugin-config/extensions";
        /// <summary>
        /// 成功状态名称
        /// </summary>
        public static String ZStatusSuccess { get; set; } = "success";
        /// <summary>
        /// 未认证状态名称
        /// </summary>
        public static String ZStatusUnauthorized { get; set; } = "unauthorized";
    }
}
