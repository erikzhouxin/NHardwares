using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ZycooSIPNetSDK
{
    /// <summary>
    /// 终端信息模型
    /// <see cref="IZycooSIPNetApiProxyV1.DeviceSearch(int, int, string)"/>
    /// id int 设备 ID
    /// model String 设备型号（未识别的型号为空）
    /// name String 设备名称
    /// exten String 设备绑定的 SIP 账号
    /// contact String 联系人
    /// contactPhone String 联系电话
    /// address String 设备地址
    /// type_id int 设备类型 ID
    /// user_id int 操作员 ID
    /// allowed_pa String 是否允许被喊话（“yes”或”no”)
    /// mac String 设备 MAC 地址，未上报则为空
    /// fault_monitoring String 是否监控设备故障
    /// createdAt String 设备创建时间
    /// updatedAt String 设备最后一次修改时间
    /// type Object 类型信息
    /// tag Object 标签
    /// group Object[] 设备所在的组
    /// info Object 设备的当前状态信息
    ///  pbxstatus String SIP 业务状态
    ///  status String 设备状态
    ///  playerstatus String 广播业务状态
    ///  soft-volume int 广播音量
    ///  hard-volume int 全局音量
    ///  sessionlevel int 当前会话级别
    ///  sessionuserid int 当前会话操作员 ID
    ///  private_ip String 设备当前的内网地址
    /// 返回结果内容
    /// {
    ///     "id": 14,
    ///     "model": "SW15",
    ///     "name": "壁挂 12.135 无声音情况挂机测试",
    ///     "exten": "5003",
    ///     "contact": null,
    ///     "contactPhone": null,
    ///     "address": null,
    ///     "type_id": 1,
    ///     "user_id": null,
    ///     "allowed_pa": "yes",
    ///     "mac": "68692e220217",
    ///     "remark": null,
    ///     "rtspUrl": null,
    ///     "thingId": null,
    ///     "features": "{\"rtspUrls\":[],\"pushRTSP\":\"no\"}",
    ///     "fault_monitoring": "yes",
    ///     "createdAt": "2020-05-28T01:21:07.000Z",
    ///     "updatedAt": "2020-05-28T01:24:24.000Z",
    ///     "type": {
    ///         "id": 1,
    ///         "name": "paging_terminal",
    ///         "icon": "fas fa-bullhorn",
    ///         "remark": null,
    ///         "createdAt": "2019-08-02T08:46:07.000Z",
    ///         "updatedAt": "2019-08-05T11:07:41.000Z"
    ///     },
    ///     "tag": [],
    ///     "group": [
    ///     {
    ///         "id": 1,
    ///         "name": "zxm",
    ///         "exten": "6001",
    ///         "remark": "",
    ///         "createdAt": "2020-05-15T09:38:50.000Z",
    ///         "updatedAt": "2020-06-28T09:44:07.000Z",
    ///         "t_paging_deviceGroups": {
    ///             "DeviceId": 14,
    ///             "GroupId": 1
    ///         }
    ///     }],
    ///     "info": {
    ///         "pbxstatus": "idle",
    ///         "status": "online",
    ///         "statusText": "Idle",
    ///         "soft-volume": 6,
    ///         "hard-volume": 9,
    ///         "hard-volume-control": "on",
    ///         "exten": "5003",
    ///         "model": "SW15",
    ///         "private_ip": "192.168.12.121",
    ///         "mac": "68692e220217",
    ///         "ip": "192.168.12.121",
    ///         "playerstatus": "idle",
    ///         "sessionlevel": null,
    ///         "sessionuserid": null,
    ///         "sourceId": null,
    ///         "url": null
    ///     }
    /// }
    /// </summary>
    public class ZycooDeviceModel
    {
        /// <summary>
        /// 设备 ID
        /// </summary>
        public virtual Int32 Id { get; set; }
        /// <summary>
        /// 设备型号（未识别的型号为空）
        /// </summary>
        public virtual String Model { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public virtual String Name { get; set; }
        /// <summary>
        /// 设备绑定的 SIP 账号
        /// </summary>
        public virtual String Exten { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public virtual String Contact { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public virtual String ContactPhone { get; set; }
        /// <summary>
        /// 设备地址
        /// </summary>
        public virtual String Address { get; set; }
        /// <summary>
        /// 设备类型 ID
        /// </summary>
        public virtual int Type_id { get; set; }
        /// <summary>
        /// 操作员 ID
        /// </summary>
        public virtual int User_id { get; set; }
        /// <summary>
        /// 是否允许被喊话（“yes”或”no”)
        /// </summary>
        public virtual String Allowed_pa { get; set; }
        /// <summary>
        /// 设备 MAC 地址，未上报则为空
        /// </summary>
        public virtual String Mac { get; set; }
        /// <summary>
        /// 是否监控设备故障
        /// </summary>
        public virtual String Fault_monitoring { get; set; }
        /// <summary>
        /// 设备创建时间
        /// </summary>
        public virtual String CreateAt { get; set; }
        /// <summary>
        /// 设备最后一次修改时间
        /// </summary>
        public virtual String UpdateAt { get; set; }
        /// <summary>
        /// 类型信息
        /// </summary>
        public virtual ZycooDeviceTypeModel Type { get; set; }
        /// <summary>
        /// 标签信息
        /// </summary>
        public virtual ZycooDeviceTagModel Tag { get; set; }
        /// <summary>
        /// 设备所在的组
        /// </summary>
        public virtual ZycooDeviceGroupModel Group { get; set; }
        /// <summary>
        /// 设备的当前状态信息
        /// </summary>
        public virtual ZycooDeviceStatusModel Info { get; set; }
    }
    /// <summary>
    /// 终端类型信息
    /// </summary>
    public class ZycooDeviceTypeModel
    {

    }
    /// <summary>
    /// 终端标签信息
    /// </summary>
    public class ZycooDeviceTagModel
    {

    }
    /// <summary>
    /// 终端分组信息
    /// </summary>
    public class ZycooDeviceGroupModel
    {

    }
    /// <summary>
    /// 终端状态信息
    /// {
    ///     "pbxstatus": "idle",
    ///     "status": "online",
    ///     "statusText": "Idle",
    ///     "soft-volume": 6,
    ///     "hard-volume": 9,
    ///     "hard-volume-control": "on",
    ///     "exten": "5003",
    ///     "model": "SW15",
    ///     "private_ip": "192.168.12.121",
    ///     "mac": "68692e220217",
    ///     "ip": "192.168.12.121",
    ///     "playerstatus": "idle",
    ///     "sessionlevel": null,
    ///     "sessionuserid": null,
    ///     "sourceId": null,
    ///     "url": null
    /// }
    /// </summary>
    public class ZycooDeviceStatusModel
    {
        /// <summary>
        /// 状态
        /// </summary>
        public virtual String Pbxstatus { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public virtual String Status { get; set; }
        /// <summary>
        /// 状态文本
        /// </summary>
        public virtual String StatusText { get; set; }
        /// <summary>
        /// 软件音量
        /// </summary>
        public virtual int Soft_volume { get; set; }
        /// <summary>
        /// 硬件音量
        /// </summary>
        public virtual int Hard_volume { get; set; }
        /// <summary>
        /// 硬件音量控制(on/off)
        /// </summary>
        public virtual String Hard_volume_control { get; set; }
        /// <summary>
        /// 设备绑定的 SIP 账号
        /// </summary>
        public virtual String Exten { get; set; }
        /// <summary>
        /// 设备型号（未识别的型号为空）
        /// </summary>
        public virtual String Model { get; set; }
        /// <summary>
        /// 内网地址
        /// </summary>
        public virtual String Private_ip { get; set; }
        /// <summary>
        /// 物理地址
        /// </summary>
        public virtual String Mac { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public virtual String Ip { get; set; }
        /// <summary>
        /// 播放状态
        /// </summary>
        public virtual String Playerstatus { get; set; }
        /// <summary>
        /// 会话级别
        /// </summary>
        public virtual String Sessionlevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual String Sessionuserid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual String SourceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual String Url { get; set; }
    }
}
