using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ZycooSIPNetSDK
{
    /// <summary>
    /// 账号信息模型
    /// id int SIP 账号 ID
    /// exten String SIP 账号
    /// fullname String SIP 账号显示名称
    /// secret String SIP 账号的密码
    /// context String 拨号规则
    /// videosupport String 是否开启视频功能
    /// g722 int 是否开启 G722 编码
    /// ulaw int 是否开启 G711u 编码
    /// alaw int 是否开启 G711a 编码
    /// g729 int 是否开启 G729 编码
    /// opus int 是否开启 opus 编码
    /// h264 int 是否开启 H264 编码
    /// recordin int 是否开启呼入录音
    /// recordout int 是否开启呼出录音
    /// createdAt String 账号创建时间
    /// updatedAt String 账号最后一次修改时间
    /// <see cref="IZycooSIPNetApiProxyV1.AccountSearch(int, int, string)"/>
    /// {
    ///     "id": 11,
    ///     "exten": "1001",
    ///     "fullname": "1001",
    ///     "secret": "123456",
    ///     "context": "DialRule_1001",
    ///     "videosupport": "yes",
    ///     "g722": 1,
    ///     "ulaw": 1,
    ///     "alaw": 1,
    ///     "g729": 0,
    ///     "h264": 1,
    ///     "recordin": "1",
    ///     "recordout": "1",
    ///     "createdAt": "2020-05-15T10:30:15.000Z",
    ///     "updatedAt": "2020-05-29T08:34:06.000Z"
    /// }
    /// </summary>
    public class ZycooAccountModel : IZycooResModel
    {
        /// <summary>
        /// SIP 账号 ID
        /// </summary>
        public virtual Int32 Id { get; set; }
        /// <summary>
        /// SIP 账号
        /// </summary>
        public virtual String Exten { get; set; }
        /// <summary>
        /// SIP 账号显示名称
        /// </summary>
        public virtual String Fullname { get; set; }
        /// <summary>
        /// SIP 账号的密码
        /// </summary>
        public virtual String Secret { get; set; }
        /// <summary>
        /// 拨号规则
        /// </summary>
        public virtual String Context { get; set; }
        /// <summary>
        /// 是否开启视频功能
        /// </summary>
        public virtual string Videosupport { get; set; }
        /// <summary>
        /// 是否开启 G722 编码
        /// </summary>
        public virtual Int32 G722 { get; set; }
        /// <summary>
        /// 是否开启 G711u 编码
        /// </summary>
        public virtual Int32 Ulaw { get; set; }
        /// <summary>
        /// 是否开启 G711a 编码
        /// </summary>
        public virtual Int32 Alaw { get; set; }
        /// <summary>
        /// 是否开启 G729 编码
        /// </summary>
        public virtual Int32 G729 { get; set; }
        /// <summary>
        /// 是否开启 opus 编码
        /// </summary>
        public virtual Int32 Opus { get; set; }
        /// <summary>
        /// 是否开启 H264 编码
        /// </summary>
        public virtual Int32 H264 { get; set; }
        /// <summary>
        /// 是否开启呼入录音
        /// </summary>
        public virtual Int32 Recordin { get; set; }
        /// <summary>
        /// 是否开启呼出录音
        /// </summary>
        public virtual Int32 Recordout { get; set; }
        /// <summary>
        /// 账号创建时间
        /// </summary>
        public virtual String CreatedAt { get; set; }
        /// <summary>
        /// 账号最后一次修改时间
        /// </summary>
        public virtual String UpdatedAt { get; set; }
        /// <inheritdoc />
        public virtual String ResponseJson { get; set; }
    }
    /// <summary>
    /// 账号添加模型
    /// exten String 是 SIP 账号
    /// secret String 是 SIP 账号的密码
    /// fullname String 是 显示名称
    /// transport String 是 udp/tcp/tls
    /// videosupport String 是 “yes”或“no”
    /// ulaw int 是 0 或 1
    /// alaw int 是 0 或 1
    /// g722 int 是 0 或 1
    /// g729 int 是 0 或 1
    /// </summary>
    public class ZycooAccountAddModel
    {
        /// <summary>
        /// SIP 账号
        /// </summary>
        public virtual String Exten { get; set; }
        /// <summary>
        /// SIP 账号的密码
        /// </summary>
        public virtual String Secret { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public virtual String Fullname { get; set; }
        /// <summary>
        /// udp/tcp/tls
        /// </summary>
        public virtual String Transport { get; set; }
        /// <summary>
        /// “yes”或“no”
        /// </summary>
        public virtual String Videosupport { get; set; }
        /// <summary>
        /// 是否开启 G722 编码
        /// </summary>
        public virtual Int32 G722 { get; set; }
        /// <summary>
        /// 是否开启 G711u 编码
        /// </summary>
        public virtual Int32 Ulaw { get; set; }
        /// <summary>
        /// 是否开启 G711a 编码
        /// </summary>
        public virtual Int32 Alaw { get; set; }
        /// <summary>
        /// 是否开启 G729 编码
        /// </summary>
        public virtual Int32 G729 { get; set; }
    }
    /// <summary>
    /// 账号编辑模型
    /// </summary>
    public class ZycooAccountEditModel : ZycooAccountAddModel
    {
        /// <summary>
        /// 账号标识
        /// </summary>
        public int Id { get; set; }
    }
}