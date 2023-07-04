using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Data.SolutionCore;
using System.Data.Cobber;
using System.Security.Policy;
using System.Timers;
using System.Security.Principal;

namespace System.Data.ZycooSIPNetSDK
{
    /// <summary>
    /// 智科通信SIP网络电话
    /// 版本v1.0.9
    /// </summary>
    public interface IZycooSIPNetApiProxyV1
    {
        /// <summary>
        /// 中心配置
        /// </summary>
        ZycooConfigModelV1 Center { get; }
        #region // 一.权限认证
        /// <summary>
        /// 权限认证接口
        /// POST => http://192.168.12.178:8000/coocenter-api/local/login
        /// <see cref="ZycooConfigModelV1.ZApiLocalLogin"/>
        /// [Header 域]
        /// 参数名          参数值
        /// accept          application/json
        /// Content-Type    application/json
        /// [参数列表]
        /// 参数名    类型   必填 描述
        /// username  String 是   认证用户名
        /// password  String 是   认证密码
        /// <see cref="ZycooLoginModel"/>
        /// {
        ///     "status": "success",
        ///     "token": "jwt...",
        ///     "username": "admin",
        ///     "userId": 1
        /// }
        /// </summary>
        /// <returns>返回结果</returns>
        IAlertMsg<ZycooLoginModel> Login();
        #endregion 一.权限认证
        #region // 二、配置接口
        #region // 2.1、SIP 账号管理
        /// <summary>
        /// SIP 账号查询接口
        /// GET => http://192.168.12.178:8000/coocenter-api/plugin-config/extensions
        /// <see cref="ZycooConfigModelV1.ZApiAccountSearch"/>
        /// Header 域
        /// 参数名        参数值
        /// accept        application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名      类型    必填 描述
        /// limit       int     是   每页显示数量
        /// page        int     是   页码
        /// filterinfo  String  否   模糊匹配 SIP 账号名称或号码
        /// <see cref="ZycooAccountModel"/>
        /// 参数名 类型 描述
        /// count int 查询结果总数
        /// rows Object[] SIP 账号列表
        /// id int SIP 账号 ID
        ///  exten String SIP 账号
        ///  fullname String SIP 账号显示名称
        ///  secret String SIP 账号的密码
        ///  context String 拨号规则
        ///  videosupport String 是否开启视频功能
        ///  g722 int 是否开启 G722 编码
        ///  ulaw int 是否开启 G711u 编码
        ///  alaw int 是否开启 G711a 编码
        ///  g729 int 是否开启 G729 编码
        ///  opus int 是否开启 opus 编码
        ///  h264 int 是否开启 H264 编码
        ///  recordin int 是否开启呼入录音
        ///  recordout int 是否开启呼出录音
        ///  createdAt String 账号创建时间
        ///  updatedAt String 账号最后一次修改时间
        /// 返回查询结果
        /// {
        ///     "count": 2,
        ///     "rows": [
        ///     {
        ///         "id": 11,
        ///         "exten": "1001",
        ///         "fullname": "1001",
        ///         "secret": "123456",
        ///         "context": "DialRule_1001",
        ///         "videosupport": "yes",
        ///         "g722": 1,
        ///         "ulaw": 1,
        ///         "alaw": 1,
        ///         "g729": 0,
        ///         "h264": 1,
        ///         recordin": "1",
        ///         recordout": "1",
        ///         "createdAt": "2020-05-15T10:30:15.000Z",
        ///         "updatedAt": "2020-05-29T08:34:06.000Z"
        ///     }]
        /// }
        /// </summary>
        /// <param name="limit">每页显示数量,必填</param>
        /// <param name="page">页码,必填</param>
        /// <param name="filterinfo">模糊匹配 SIP 账号名称或号码,非必填</param>
        /// <returns>返回结果</returns>
        IAlertMsg<IZycooResModels<ZycooAccountModel>> AccountSearch(int limit, int page, string filterinfo);
        /// <summary>
        /// SIP 账号创建
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-config/extensions
        /// <see cref="ZycooConfigModelV1.ZApiAccountAdd"/>
        /// Header 域
        /// 参数名        参数值
        /// accept        application/json
        /// Authorization Bearer &lt;token&gt;
        /// Content-Type  application/json
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// extension Object
        /// exten String 是 SIP 账号
        /// secret String 是 SIP 账号的密码
        /// fullname String 是 显示名称
        /// transport String 是 udp/tcp/tls
        /// videosupport String 是 “yes”或“no”
        /// ulaw int 是 0 或 1
        /// alaw int 是 0 或 1
        /// g722 int 是 0 或 1
        /// g729 int 是 0 或 1
        /// <see cref="ZycooAccountAddModel"/>
        /// 返回创建 SIP 账号的数据
        /// {
        ///     "exten": 5015,
        ///     "secret": "NewkMDR4",
        ///     "fullname": 5015,
        ///     "transport": "udp",
        ///     "videosupport": "yes",
        ///     "alaw": 1,
        ///     "ulaw": 1,
        ///     "g722": 1,
        ///     "g729": 0,
        ///  }
        /// </summary>
        /// <param name="account">此模型包含在extension中</param>
        /// <returns>返回结果</returns>
        IAlertMsg<ZycooAccountModel> AccountAdd(ZycooAccountAddModel account);
        /// <summary>
        /// SIP 账号修改
        /// PUT => http://192.168.12.178:8000/coocenter-api/plugin-config/extensions
        /// <see cref="ZycooConfigModelV1.ZApiAccountEdit"/>
        /// Header 域
        /// 参数名        参数值
        /// accept        application/json
        /// Authorization Bearer &lt;token&gt;
        /// Content-Type  application/json
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// id Int (path) 是 修改 SIP 账号的 ID
        /// extension Object (body)
        /// exten String 否 SIP 账号
        /// secret String 否 SIP 账号的密码
        /// fullname String 否 显示名称
        /// videosupport String 否 “yes”或“no”
        /// ulaw int 否 0 或 1
        /// alaw int 否 0 或 1
        /// g722 int 否 0 或 1
        /// g729 int 否 0 或 1
        /// <see cref="ZycooAccountEditModel"/>
        /// 返回更新的数量
        /// [ 1 ]
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        IAlertMsg AccountEdit(ZycooAccountEditModel account);
        /// <summary>
        /// SIP 账号修改
        /// PUT => http://192.168.12.178:8000/coocenter-api/plugin-config/extensions
        /// <see cref="ZycooConfigModelV1.ZApiAccountEdit"/>
        /// Header 域
        /// 参数名        参数值
        /// accept        application/json
        /// Authorization Bearer &lt;token&gt;
        /// Content-Type  application/json
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// id Int (path) 是 修改 SIP 账号的 ID
        /// extension Object (body)
        /// exten String 否 SIP 账号
        /// secret String 否 SIP 账号的密码
        /// fullname String 否 显示名称
        /// videosupport String 否 “yes”或“no”
        /// ulaw int 否 0 或 1
        /// alaw int 否 0 或 1
        /// g722 int 否 0 或 1
        /// g729 int 否 0 或 1
        /// <see cref="ZycooAccountEditModel"/>
        /// { "extension": {"videosupport":"no"}}
        /// 返回更新的数量
        /// [ 1 ]
        /// </summary>
        /// <param name="id"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        IAlertMsg AccountEdit(int id, object account);
        /// <summary>
        /// SIP 账号删除
        /// DELETE => http://192.168.12.178:8000/coocenter-api/plugin-config/extensions
        /// <see cref="ZycooConfigModelV1.ZApiAccountDelete"/>
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// id Int (path) 是 删除 SIP 账号的 ID
        /// 返回删除成功的数量
        /// 1
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        IAlertMsg AccountDelete(int account);
        #endregion 2.1、SIP 账号管理
        #region // 2.2、终端管理
        /// <summary>
        /// 终端查询
        /// GET => http://192.168.12.178:8000/coocenter-api/plugin-coopaging/device
        /// Header 域
        /// 参数名        参数值
        /// accept        application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// limit int 是 每页显示数量
        /// page int 是 页码
        /// filterinfo String 否 模糊匹配设备账号或设备名称
        /// 参数名 类型 描述
        /// count int 查询结果总数
        /// rows Object[] 设备列表
        ///  id int 设备 ID
        ///  model String 设备型号（未识别的型号为空）
        ///  name String 设备名称
        ///  exten String 设备绑定的 SIP 账号
        ///  contact String 联系人
        ///  contactPhone String 联系电话
        ///  address String 设备地址
        ///  type_id int 设备类型 ID
        ///  user_id int 操作员 ID
        ///  allowed_pa String 是否允许被喊话（“yes”或”no”)
        ///  mac String 设备 MAC 地址，未上报则为空
        ///  fault_monitoring String 是否监控设备故障
        ///  createdAt String 设备创建时间
        ///  updatedAt String 设备最后一次修改时间
        ///  type Object 类型信息
        ///  tag Object 标签
        ///  group Object[] 设备所在的组
        ///  info Object 设备的当前状态信息
        ///   pbxstatus String SIP 业务状态
        ///   status String 设备状态
        ///   playerstatus String 广播业务状态
        ///   soft-volume int 广播音量
        ///   hard-volume int 全局音量
        ///   sessionlevel int 当前会话级别
        ///   sessionuserid int 当前会话操作员 ID
        ///   private_ip String 设备当前的内网地址
        /// <see cref="ZycooDeviceModel"/>
        /// 返回查询结果
        /// {
        ///     "count": 1,
        ///     "rows": [
        ///     {
        ///         "id": 14,
        ///         "model": "SW15",
        ///         "name": "壁挂 12.135 无声音情况挂机测试",
        ///         "exten": "5003",
        ///         "contact": null,
        ///         "contactPhone": null,
        ///         "address": null,
        ///         "type_id": 1,
        ///         "user_id": null,
        ///         "allowed_pa": "yes",
        ///         "mac": "68692e220217",
        ///         "remark": null,
        ///         "rtspUrl": null,
        ///         "thingId": null,
        ///         "features": "{\"rtspUrls\":[],\"pushRTSP\":\"no\"}",
        ///         "fault_monitoring": "yes",
        ///         "createdAt": "2020-05-28T01:21:07.000Z",
        ///         "updatedAt": "2020-05-28T01:24:24.000Z",
        ///         "type": {
        ///             "id": 1,
        ///             "name": "paging_terminal",
        ///             "icon": "fas fa-bullhorn",
        ///             "remark": null,
        ///             "createdAt": "2019-08-02T08:46:07.000Z",
        ///             "updatedAt": "2019-08-05T11:07:41.000Z"
        ///         },
        ///         "tag": [],
        ///         "group": [
        ///         {
        ///             "id": 1,
        ///             "name": "zxm",
        ///             "exten": "6001",
        ///             "remark": "",
        ///             "createdAt": "2020-05-15T09:38:50.000Z",
        ///             "updatedAt": "2020-06-28T09:44:07.000Z",
        ///                 "t_paging_deviceGroups": {
        ///                 "DeviceId": 14,
        ///                 "GroupId": 1
        ///             }
        ///         }],
        ///         "info": {
        ///             "pbxstatus": "idle",
        ///             "status": "online",
        ///             "statusText": "Idle",
        ///             "soft-volume": 6,
        ///             "hard-volume": 9,
        ///             "hard-volume-control": "on",
        ///             "exten": "5003",
        ///             "model": "SW15",
        ///             "private_ip": "192.168.12.121",
        ///             "mac": "68692e220217",
        ///             "ip": "192.168.12.121",
        ///             "playerstatus": "idle",
        ///             "sessionlevel": null,
        ///             "sessionuserid": null,
        ///             "sourceId": null,
        ///             "url": null
        ///         }
        ///     }]
        /// }
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <param name="filterinfo"></param>
        /// <returns></returns>
        IAlertMsg<IZycooResModels<ZycooDeviceModel>> DeviceSearch(int limit, int page, string filterinfo);
        /// <summary>
        /// 设备创建
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-coopaging/device
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// Content-Type application/json
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// device Object
        /// exten String 是 设备绑定的 SIP 账号
        /// name String 是 设备名称
        /// type_id int 是 设备类型
        /// allowed_pa String 是 是否允许喊话，“yes”或“no”
        /// contact String 否 联系人
        /// contactPhone String 否 联系电话
        /// address String 否 设备地址
        /// remark String 否 备注
        /// <see cref="ZycooDeviceModel"/>
        /// 返回创建设备的数据
        /// {
        ///     "id":32,
        ///     "type_id":3,
        ///     "exten":"5006",
        ///     "name":"IP Phone",
        ///     "allowed_pa":"no",
        ///     "updatedAt":"2020-07-08T08:14:19.659Z",
        ///     "createdAt":"2020-07-08T08:14:19.659Z"
        /// }
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        IAlertMsg<ZycooDeviceModel> DeviceAdd(ZycooDeviceModel device);
        /// <summary>
        /// 设备修改
        /// PUT => http://192.168.12.178:8000/coocenter-api/plugin-coopaging/device
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// Content-Type application/json
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// id Int (path) 是 修改设备的 ID
        /// device Object (body)
        /// exten String 否 设备绑定的 SIP 账号
        /// name String 否 设备名称
        /// type_id int 否 设备类型
        /// allowed_pa String 否 是否允许喊话，“yes”或“no”
        /// contact String 否 联系人
        /// contactPhone String 否 联系电话
        /// address String 否 设备地址
        /// remark String 否 备注
        /// 返回更新的数量
        /// [ 1 ]
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        IAlertMsg DeviceEdit(ZycooDeviceModel device);
        /// <summary>
        /// 设备删除
        /// DELETE => http://192.168.12.178:8000/coocenter-api/plugin-coopaging/device
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// id Int (path) 是 删除设备的 ID
        /// 返回删除成功的数量
        /// 1
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        IAlertMsg DeviceDelete(ZycooDeviceModel device);
        #endregion 2.2、终端管理
        #region // 2.3、分组管理
        /// <summary>
        /// 分组查询
        /// GET => http://192.168.12.178:8000/coocenter-api/plugin-coopaging/group
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// limit int 是 每页显示数量
        /// page int 是 页码
        /// 参数名 类型 描述
        /// count int 查询结果总数
        /// rows Object[] 分组列表
        /// id int 分组 ID
        ///  name String 分组名称
        ///  exten String 分组号码
        /// paging_mode String 广播模式 ，支持单工(simplex)/双工(duplex)两种
        ///  remark String 备注信息
        ///  createdAt String 分组创建时间
        ///  updatedAt String 分组最后一次修改时间
        ///  device Object[] 设备列表
        ///  user Object[] 该组的操作员列表
        /// <see cref="ZycooGroupModel"/>
        /// 返回查询结果
        /// {
        ///     "count": 4,
        ///     "rows": [
        ///     {
        ///        "id": 1,
        ///        "name": "zxm",
        ///        "exten": "6001",
        ///        "remark": "",
        ///        "createdAt": "2020-05-15T09:38:50.000Z",
        ///        "updatedAt": "2020-06-28T09:44:07.000Z",
        ///        "device": [
        ///        {
        ///           "id": 5,
        ///           "model": "IA03",
        ///           "name": "IA03 --12.247",
        ///           "exten": "5007",
        ///           "contact": null,
        ///           "contactPhone": null,
        ///           "address": "会议室",
        ///           "type_id": 1,
        ///           "user_id": null,
        ///           "allowed_pa": "yes",
        ///           "mac": "68692e240808",
        ///           "remark": null,
        ///           "rtspUrl": null,
        ///           "thingId": null,
        ///           "features": "{\"rtspUrls\":[],\"pushRTSP\":\"no\"}",
        ///           "fault_monitoring": "yes",
        ///           "createdAt": "2020-05-15T09:44:26.000Z",
        ///           "updatedAt": "2020-05-27T05:46:11.000Z",
        ///           "t_paging_deviceGroups": {
        ///               "DeviceId": 5,
        ///               "GroupId": 1
        ///           }
        ///        }],
        ///        "user": [
        ///        {
        ///            "id": 2,
        ///            "username": "zxm",
        ///            "secret": "123456",
        ///            "phonenumber": "",
        ///            "address": null,
        ///            "level": 2,
        ///            "phones": [
        ///            "5000",
        ///            "5001"
        ///            ],
        ///            "strategy": "ringall",
        ///            "createdAt": "2020-05-15T09:29:51.000Z",
        ///            "updatedAt": "2020-06-05T03:12:48.000Z",
        ///            "t_paging_userGroups": {
        ///            "UserId": 2,
        ///            "GroupId": 1
        ///            }
        ///        }]
        ///     }]
        /// }
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <param name="filterinfo"></param>
        /// <returns></returns>
        IAlertMsg<IZycooResModels<ZycooGroupModel>> GroupSearch(int limit, int page, string filterinfo);
        /// <summary>
        /// 分组创建
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-coopaging/group
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// Content-Type application/json
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// group Object
        /// exten String 是 分组的号码
        /// name String 是 分组名称
        /// paging_mode String 是 广播模式 ，支持单工(simplex)/双工(duplex)两种
        /// device_ids Object[] 是 分组中的设备 ID 数组
        /// user_ids Object[] 否 操作员 ID 数组
        /// remark String 否 备注
        /// 返回创建分组的数据
        /// {
        ///     "id":5,
        ///     "exten":6005,
        ///     "name":"test",
        ///     "remark":"123456",
        ///     "updatedAt":"2020-07-08T11:14:55.011Z",
        ///     "createdAt":"2020-07-08T11:14:55.011Z"
        /// }
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        IAlertMsg<ZycooGroupModel> GroupAdd(ZycooGroupModel group);
        /// <summary>
        /// 分组修改
        /// PUT => http://192.168.12.178:8000/coocenter-api/plugin-coopaging/group
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// Content-Type application/json
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// id Int (path) 是 修改分组的 ID
        /// group Object (body)
        /// exten String 否 分组的号码
        /// name String 否 分组名称
        /// paging_mode String 否 广播模式 ，支持单工(simplex)/双工(duplex)两种
        /// device_ids Object[] 否 分组中的设备 ID 数组
        /// user_ids Object[] 否 操作员 ID 数组
        /// remark String 否 备注
        /// 返回更新的数量
        /// [ 1 ]
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        IAlertMsg GroupEdit(ZycooGroupModel group);
        /// <summary>
        /// 分组删除
        /// DELETE => http://192.168.12.178:8000/coocenter-api/plugin-coopaging/group
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// id Int (path) 是 删除分组的 ID
        /// 返回删除成功的数量
        /// 1
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        IAlertMsg GroupDelete(ZycooGroupModel group);
        #endregion 2.3、分组管理
        #region // 2.4、操作员管理
        /// <summary>
        /// 操作员查询
        /// GET => http://192.168.12.178:8000/coocenter-api/plugin-coopaging/user
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// limit int 是 每页显示数量
        /// page int 是 页码
        /// 参数名 类型 描述
        /// count int 查询结果总数
        /// rows Object[] 操作员列表
        /// id int 操作员 ID
        ///  name String 操作员名称
        ///  secret String 操作员密码
        ///  phonenumber String 操作员联系电话
        ///  address String 操作员地址
        ///  level int 操作员等级（1～12 越小等级越高）
        ///  phones Object[] 主控话机数组（存储主控话机优先级）
        ///  strategy String 振铃策略（ringall/linear）
        ///  createdAt String 操作员创建时间
        ///  updatedAt String 操作员最后一次修改时间
        ///  group Object[] 操作员管理的分组
        ///  service Object[] 操作员业务权限，当前只支持【1、2、4、7、8、9】1:喊话；2:告警；4:对讲；7:广播任务；8:背景音乐；9:拨打外线
        ///  device Object[] 主控话机信息数组
        ///  ring_duration int 主控话机振铃时长（单位：秒），0 为无限制
        /// 返回查询结果
        /// {
        ///  "count": 5,
        ///  "rows": [
        ///  {
        ///     "id": 2,
        ///     "username": "zxm",
        ///     "secret": "123456",
        ///     "phonenumber": "",
        ///     "address": null,
        ///     "level": 2,
        ///     "phones": [
        ///         "5000",
        ///         "5001"
        ///     ],
        ///     "strategy": "ringall",
        ///     "createdAt": "2020-05-15T09:29:51.000Z",
        ///     "updatedAt": "2020-06-05T03:12:48.000Z",
        ///     "group": [
        ///     {
        ///         "id": 1,
        ///         "name": "zxm",
        ///         "exten": "6001",
        ///         "remark": "",
        ///         "createdAt": "2020-05-15T09:38:50.000Z",
        ///         "updatedAt": "2020-06-28T09:44:07.000Z",
        ///         "t_paging_userGroups": {
        ///         "UserId": 2,
        ///         "GroupId": 1
        ///         }
        ///     }],
        ///     "service": [
        ///     {
        ///        "id": 8,
        ///        "name": "background_music",
        ///        "t_paging_userServices": {
        ///            "UserId": 2,
        ///            "tPagingServiceId": 8
        ///        }
        ///     }],
        ///     "device": [
        ///     {
        ///        "id": 2,
        ///        "model": "",
        ///        "name": "5000",
        ///        "exten": "5000",
        ///        "contact": null,
        ///        "contactPhone": null,
        ///        "address": null,
        ///        "type_id": 3,
        ///        "user_id": 2,
        ///        "allowed_pa": "yes",
        ///        "mac": "",
        ///        "remark": null,
        ///        "rtspUrl": null,
        ///        "thingId": null,
        ///        "features": "{\"rtspUrls\":[],\"pushRTSP\":\"no\"}",
        ///        "fault_monitoring": "yes",
        ///        "createdAt": "2020-05-15T09:37:25.000Z",
        ///        "updatedAt": "2020-06-05T03:30:03.000Z"
        ///     }]
        ///  }]
        /// }
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <param name="filterinfo"></param>
        /// <returns></returns>
        IAlertMsg<IZycooResModels<ZycooUserModel>> UserSearch(int limit, int page, string filterinfo);
        /// <summary>
        /// 操作员创建
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-coopaging/user
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// Content-Type application/json
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// user Object
        /// username String 是 操作员名称
        /// secret String 是 操作员密码
        /// phonenumber String 否 操作员联系电话
        /// address String 否 操作员地址
        /// level int 是 操作员等级（1～12 越小等级越高）
        /// phones Object[] 否 主控话机号码优先级数组（前面的优先级大于后面的）
        /// strategy String 是 振铃策略 ringall（振铃所有）liner（顺序振铃）
        /// ring_duration int 是 主控话机振铃时长（单位：秒），0 为无限制
        /// device_ids Object[] 否 主控话机 ID 数组
        /// group_ids Object[] 否 操作员管理的分组
        /// service_ids Object[] 是 操作员业务权限，当前只支持【1、2、4、7、8、9】1:喊话；2:告警；4:对讲；7:广播任务；8:背景音乐；9:拨打外线
        /// 返回创建 SIP 账号的数据
        /// {
        ///     "id":8,
        ///     "username":"demo",
        ///     "secret":"123456",
        ///     "phonenumber":"",
        ///     "level":1,
        ///     "phones":["5006","5007"],
        ///     "strategy":"ringall",
        ///     "ring_duration":0,
        ///     "updatedAt":"2020-07-08T11:47:25.268Z",
        ///     "createdAt":"2020-07-08T11:47:25.268Z"
        /// }
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        IAlertMsg<ZycooUserModel> UserAdd(ZycooUserModel user);
        /// <summary>
        /// 操作员修改
        /// PUT => http://192.168.12.178:8000/coocenter-api/plugin-coopaging/user
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// Content-Type application/json
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// id Int (path) 是 修改的操作员 ID
        /// user Object (body)
        /// username String 否 操作员名称
        /// secret String 否 操作员密码
        /// phonenumber String 否 操作员联系电话
        /// address String 否 操作员地址
        /// level int 否 操作员等级（1～12 越小等级越高）
        /// phones Object[] 否 主控话机号码优先级数组（前面的优先级大于后面的）
        /// strategy String 否 振铃策略 ringall（振铃所有）liner（顺序振铃）
        /// ring_duration int 是 主控话机振铃时长（单位：秒），0 为无限制
        /// device_ids Object[] 否 主控话机 ID 数组
        /// group_ids Object[] 否 操作员管理的分组
        /// service_ids Object[] 否 操作员业务权限，当前支持【1、2、4、7、8、9】1:喊话；2:告警；4:对讲；7:广播任务；8:背景音乐；9:拨打外线 
        /// 返回更新的数量
        /// [ 1 ]
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        IAlertMsg UserEdit(ZycooUserModel user);
        /// <summary>
        /// 操作员删除
        /// DELETE => http://192.168.12.178:8000/coocenter-api/plugin-coopaging/user
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// id Int (path) 是 删除的操作员 ID
        /// 返回删除成功的数量
        /// 1
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        IAlertMsg UserDelete(ZycooUserModel user);
        #endregion 2.4、操作员管理
        #region // 2.5、配置激活
        /// <summary>
        /// 配置激活
        /// GET => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/system/config-activate
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 返回请求结果
        /// { "status": "success" }
        /// </summary>
        /// <returns></returns>
        IAlertMsg ConfigActive();
        #endregion 2.5、配置激活
        #endregion 二、配置接口
        #region // 三、控制接口
        #region // 3.1、系统信息
        /// <summary>
        /// Ping 包检测
        /// GET => http://192.168.12.178:8000/coocenter-api/systeminfo/ping
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数名 类型 描述
        /// message String 相应 pong
        /// data Object[] 数据
        ///  time int 相应时间
        /// 返回请求结果
        /// {
        ///  "message": "pong",
        ///  "data": {
        ///  "time": 1595052744062
        ///  }
        /// }
        /// </summary>
        /// <returns></returns>
        IAlertMsg SystemPing();
        /// <summary>
        /// 负载信息
        /// GET => http://192.168.12.178:8000/coocenter-api/systeminfo/handle-info
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数名 类型 描述
        /// cputotal String CPU 总量
        /// cpuused String CPU 使用
        /// memtotal String 内存总量
        /// memused String 当前使用内存
        /// currenttime String 当前时间（时间戳）
        /// 返回请求结果
        /// {
        ///  "cputotal": "592",
        ///  "cpuused": "30",
        ///  "memtotal": "3764124",
        ///  "memused": "1201500",
        ///  "currenttime": "1595053305"
        /// }
        /// </summary>
        /// <returns></returns>
        IAlertMsg<ZycooSystemHandleModel> SystemHandle();
        /// <summary>
        /// 系统信息
        /// GET => http://192.168.12.178:8000/coocenter-api/systeminfo/system-info
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数名 类型 描述
        /// systemVer String 当前系统版本
        /// apiKey String 访问密钥
        /// ftotal String 存储空间
        /// fused String 当前使用空间
        /// upTime String 系统运行时长
        /// 返回请求结果
        /// {
        ///     "systemVer": "v1.0.3",
        ///     "apiKey": "84ce6930-9663-11ea-bd14-1f1c85df5737",
        ///     "ftotal": "50G",
        ///     "fused": "6.2G",
        ///     "upTime": "12 days, 3:34 "
        /// }
        /// </summary>
        /// <returns></returns>
        IAlertMsg<ZycooSystemInfoModel> SystemInfo();
        #endregion 3.1、系统信息
        #region // 3.2、电话调度接口
        #region // 3.2.1、电话状态
        /// <summary>
        /// 分机注册状态
        /// GET => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/extension/extension-status
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数名 类型 描述
        /// status String 请求状态
        /// message String 描述
        /// data Object[] 分机注册状态列表
        /// Exten String 分机号码
        /// Type String 协议类型
        /// IPAddr String 注册地址
        /// Status String 注册状态（响应时延）
        /// 返回请求结果
        /// {
        ///     "status": "success",
        ///     "message": "Peer status list will follow",
        ///     "data": [
        ///     {
        ///        "Exten": "1001",
        ///        "Type": "SIP",
        ///        "IPAddr": "-none-",
        ///        "Status": "UNKNOWN"
        ///     }]
        /// }
        /// </summary>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel<ZycooPhoneRegStatusModel[]>> PhoneRegStatus();
        /// <summary>
        /// 分机状态
        /// GET http://192.168.12.178:8000/coocenter-api/plugin-asterisk/extension/extension-hints-status
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数名 类型 描述
        /// status String 请求状态
        /// message String 描述
        /// data Object[] 分机状态列表
        /// Exten String 分机号码
        /// Interface String 号码通道
        /// Status String 状态码 --- 0:待机，1:通话中，2:忙线，4:离线，8:振铃中，16:保持
        /// StatusText String 状态描述
        /// 返回请求结果
        /// {
        ///     "status": "success",
        ///     "message": "Extension Statuses will follow",
        ///     "data": [
        ///     {
        ///         "Exten": "1004",
        ///         "Interface": "SIP/1004",
        ///         "Status": "0",
        ///         "StatusText": "Idle"
        ///     }]
        /// }
        /// </summary>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel<ZycooPhoneHintStatusModel[]>> PhoneHintStatus();
        /// <summary>
        /// 当前通话
        /// GET => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/extension/current-calls
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数名 类型 描述
        /// status String 请求状态
        /// data Object[] 通话列表
        /// bridgeid String 通道唯一标识
        /// callerIdName String 主叫名称
        /// callerIdNum String 主叫号码
        /// channel String 被叫通道
        /// connectedLineName String 被叫名称
        /// connectedLineNum String 被叫号码
        /// duration String 通话时长
        /// 返回请求结果
        /// {
        ///     "status": "success",
        ///     "data": [
        ///     { 
        ///         "bridgeid": "65d61a06-f9e3-45e5-9e12-e752c4ac9153",
        ///         "callerIdName": "2002",
        ///         "callerIdNum": "2002",
        ///         "channel": "SIP/2001-0000000d",
        ///         "connectedLineName": "2001",
        ///         "connectedLineNum": "2001",
        ///         "duration": "00:01:37" 
        ///     }]
        /// }
        /// </summary>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel<ZycooPhoneCallModel[]>> PhoneCalls();
        #endregion 3.2.1、电话状态
        #region // 3.2.2、通话控制
        /// <summary>
        /// 点击拨号
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/extension/click-number
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// src String 否 主叫号码， 号码为空使用当前登录帐号分配的分机
        /// dst String 是 被叫号码
        /// callerId String 否 呼出显示号码
        /// clientUserId String 否 标记本次呼叫 ID（预留）
        /// limitSec String 否 限制本次通话时长（预留）
        /// 返回请求结果
        /// {
        ///  "status": "success",
        ///  "message": "clickToCall extension success"
        /// }
        /// </summary>
        /// <param name="dialog"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> PhoneDialog(ZycooPhoneDialogModel dialog);
        /// <summary>
        /// 点击对讲
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/extension/click-intercom
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// src String 否 主叫号码， 号码为空使用当前登录帐号分配的分机
        /// dst String 是 被叫号码
        /// 返回请求结果
        /// {
        ///  "status": "success",
        ///  "message": "clickToIntercom extension success"
        /// }
        /// </summary>
        /// <param name="intercom"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> PhoneIntercom(ZycooPhoneIntercomModel intercom);
        /// <summary>
        /// 呼叫转接
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/extension/transfer
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// src String 是 通话的分机号码
        /// dst String 是 转接到的目的号码
        /// 返回请求结果
        /// {
        ///  "status": "success",
        ///  "message": "forward extension success"
        /// }
        /// </summary>
        /// <param name="transfer"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> PhoneTransfer(ZycooPhoneTransferModel transfer);
        /// <summary>
        /// 通话监听
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/extension/extension-spy
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// src String 否 主叫号码， 号码为空使用当前登录帐号分配的分机
        /// dst String 是 被监听的号码
        /// 返回请求结果
        /// {
        ///  "status": "success",
        ///  "message": "spy extension success"
        /// }
        /// </summary>
        /// <param name="spy"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> PhoneSpy(ZycooPhoneSpyModel spy);
        /// <summary>
        /// 强插通话
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/extension/extension-barge-in
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// src String 否 主叫号码， 号码为空使用当前登录帐号分配的分机
        /// dst String 是 被强制插话的号码
        /// 返回请求结果
        /// {
        ///  "status": "success",
        ///  "message": "barge in extension success"
        /// }
        /// </summary>
        /// <param name="bargeIn"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> PhoneBargeIn(ZycooPhoneBargeInModel bargeIn);
        /// <summary>
        /// 强拆通话
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/extension/clear
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// local String 否 主叫号码，号码为空使用当前登录帐号分配的分机
        /// exten String 是 被强制拆话的号码
        /// 返回请求结果
        /// {
        ///  "status": "success",
        ///  "message": "split extension success"
        /// }
        /// </summary>
        /// <param name="bargeOut"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> PhoneBargeOut(ZycooPhoneBargeOutModel bargeOut);
        /// <summary>
        /// 通话密语
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/extension/extension-whisper
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// src String 否 主叫号码， 号码为空使用当前登录帐号分配的分机
        /// dst String 是 被强制拆话的号码
        /// 返回请求结果
        /// {
        ///  "status": "success",
        ///  "message": "whisper extension success"
        /// }
        /// </summary>
        /// <param name="whisper"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> PhoneWhisper(ZycooPhoneWhisperModel whisper);
        /// <summary>
        /// 挂断电话/结束播放
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/extension/hangup
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// extensions [String] 是 挂断电话/结束播放的号码数组
        /// 返回请求结果
        /// {
        ///  "status": "success",
        ///  "message": "hangup extension success"
        /// }
        /// </summary>
        /// <param name="phones"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> PhoneHangup(string phones);
        #endregion 3.2.2、通话控制
        #region // 3.2.3、紧急喊话
        /// <summary>
        /// 紧急喊话
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/paging/click-paging
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// src String 否 主叫号码，号码为空使用当前登录帐号分配的分机
        /// dst [String] 是 终端号码数组
        /// 返回请求结果
        /// {
        ///  "status": "success",
        ///  "message": "clickToPaging success"
        /// }
        /// </summary>
        /// <param name="emergency"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> PhoneEmergency(ZycooPhoneEmergencyModel emergency);
        #endregion 3.2.3、紧急喊话
        #region // 3.2.4、电话会议
        /// <summary>
        /// 会议列表
        /// GET => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/conference/conf-list
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数名 类型 描述
        /// status String 请求状态
        /// data Object[] 当前会议室列表
        /// conference String 会议室名称
        /// parties String 参会人数
        /// marked String 会议中被标记人员数量
        /// locked String 会议室是否锁定
        /// muted String 该成员使用的通道
        /// answeredtime String 会议室是否静音
        /// id String 会议室 ID
        /// 返回请求结果
        /// {
        ///     "status": "success",
        ///     "data": [
        ///     {
        ///         "conference": "1585642185",
        ///         "parties": "2",
        ///         "marked": "0",
        ///         "locked": "No",
        ///         "muted": "No",
        ///         "id": "1585642185"
        ///     }]
        /// }
        /// </summary>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel<ZycooConferenceModel[]>> ConferenceSearch();
        /// <summary>
        /// 会议信息
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/conference/conf-info
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// confnum String 是 会议室号码
        /// 参数名 类型 描述
        /// status String 请求状态
        /// message String 描述
        /// data Object[] 会议成员信息列表
        /// conference String 会议室名称
        /// admin String 是否为会议管理员
        /// markeduser String 该成员是否被标记
        /// muted String 该成员是否被禁言
        /// channel String 该成员使用的通道
        /// answeredtime String 在会议中的时间（单位：秒）
        /// id String 会议室 ID
        /// exten String 该成员分机号码
        /// 返回请求结果
        /// {
        ///     "status": "success",
        ///     "message": "Confbridge user list will follow",
        ///     "data": [
        ///     {
        ///        "conference": "1585642185",
        ///        "admin": "No",
        ///        "markeduser": "No",
        /// "      muted": "No",
        ///        "channel": "SIP/2002-00000007",
        ///        "answeredtime": "6834",
        ///        "calleridnum": "2002",
        ///        "calleridname": "Meeting",
        ///        "id": "1585642185",
        ///        "exten": "2002"
        ///     }]
        /// }
        /// </summary>
        /// <param name="confnum"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel<ZycooConferenceDetailModel[]>> ConferenceInfo(string confnum);
        /// <summary>
        /// 加入会议
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/conference/join-conf
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// confnum String 是 会议室号码
        /// extensions [String] 是 加入会议的成员号码数组
        /// 参数名 类型 描述
        /// message Object[] 加入会议成员列表
        /// exten String 成员号码
        /// status String 状态（成功或失败）
        /// 返回请求结果
        /// {
        ///     "message": [
        ///     {
        ///         "exten": "1002",
        ///         "status": "Success"
        ///     }]
        /// }
        /// </summary>
        /// <param name="confnum"></param>
        /// <param name="extensions"></param>
        /// <returns></returns>
        IAlertMsg<IZycooMsgModel<ZycooConferencePhoneModel[]>> ConferenceAdd(string confnum, string extensions);
        /// <summary>
        /// 成员禁言
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/conference/mute-user
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// confnum String 是 会议室号码
        /// channel String 是 会议成员通道
        /// 返回请求结果
        /// {
        ///  "status": "success",
        ///  "message": "Mute user success"
        /// }
        /// </summary>
        /// <param name="confnum"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> ConferenceMute(string confnum, string channel);
        /// <summary>
        /// 成员取消禁言
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/conference/unmute-user
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// confnum String 是 会议室号码
        /// channel String 是 成员通道
        /// 返回请求结果
        /// {
        ///  "status": "success",
        ///  "message": "Unmute user success"
        /// }
        /// </summary>
        /// <param name="confnum"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> ConferenceUnmute(string confnum, string channel);
        /// <summary>
        /// 移出会议室
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/conference/kick-user
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// confnum String 是 会议室号码
        /// channel String 是 成员通道
        /// 返回请求结果
        /// {
        ///  "status": "success",
        ///  "message": "Kick user success"
        /// }
        /// </summary>
        /// <param name="confnum"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> ConferenceRemove(string confnum, string channel);
        /// <summary>
        /// 锁定会议室
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/conference/lock-conf
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// confnum String 是 会议室号码
        /// 返回请求结果
        /// {
        ///  "status": "success",
        ///  "message": "Lock conference success"
        /// }
        /// </summary>
        /// <param name="confnum"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> ConferenceLock(string confnum);
        /// <summary>
        /// 取消会议室锁定
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-asterisk/conference/unlock-conf
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// confnum String 是 会议室号码
        /// 返回请求结果
        /// {
        ///  "status": "success",
        ///  "message": "Unlock conference success"
        /// }
        /// </summary>
        /// <param name="confnum"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> ConferenceUnlock(string confnum);
        #endregion 3.2.4、电话会议
        #endregion 3.2、电话调度接口
        #region // 3.3、广播控制接口
        /// <summary>
        /// 获取广播源信息列表
        /// GET => http://192.168.12.178:8000/coocenter-api/plugin-coopaging/castcontrol
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数名 类型 描述
        /// status String 请求状态
        /// count int 广播源数量
        /// rows Object[] 广播源列表
        /// name String 源名称
        /// sourceId String 源 ID
        /// pause int 当前是否暂停
        /// times int 循环次数，-1 为无限循环
        /// musicId int 当前播放的音乐 ID
        /// model String 播放模式（顺序 order，随机 random，单曲循环 once）
        /// type String 源类型
        /// musicLibraries Object[] 广播源音乐列表
        /// remark String 备注
        /// 返回请求结果
        /// {
        ///     "status": "success",
        ///     "count": 6,
        ///     "rows": [
        ///     {
        ///        "remark": null,
        ///        "pause": 0,
        ///        "name": "air_defence",
        ///        "sourceId": "sourceId-4",
        ///        "musicId": 0,
        ///        "times": -1,
        ///        "url": "sourceId-4",
        ///        "musicLibraries": [
        ///        {
        ///            "duration": null,
        ///            "path": "/music/air_defence.mp3",
        ///            "musicId": 0,
        ///            "id": 4,
        ///            "name": "air defence"
        ///        }],
        ///        "model": "order",
        ///        "type": "alarm"
        ///     }]
        /// }
        /// </summary>
        /// <returns></returns>
        IAlertMsg<IZycooResModels<ZycooBroadcastModel>> BroadcastSearch();
        /// <summary>
        /// 控制广播源
        /// PUT => http://192.168.12.178:8000/coocenter-api/plugin-coopaging/castcontrol
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// id String（path） 是 广播源 ID
        /// data Object 是 控制指令
        /// action String 是 指令类型
        ///                  next：下一首
        ///                  previous：上一首
        ///                  select：播放指定音乐，需指定 musicId 参数
        ///                  pause：暂停/取消暂停
        ///                  remove：移除指定音乐，需指定 musicId 参数
        ///                  model：修改播放模式，需指定 model 参数
        /// musicId int 否
        /// model String 否 order：顺序播放
        ///                 random：随机播放
        ///                 once：单曲循环
        /// 返回请求结果
        /// {
        ///  "status": "success",
        ///  "message": "update success"
        /// }
        /// </summary>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> BroadcastPlay(ZycooBroadcastPlayModel play);
        /// <summary>
        /// 广播终端控制
        /// PUT => http://192.168.12.178:8000/coocenter-api/plugin-coopaging/devicecontrol
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// Content-Type application/json
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// extensions [String] 是 广播终端号码数组
        /// action String 是 控制指令
        ///                  play：播放指定广播源，需指定 sourceId 参数
        ///                  stop：停止播放
        ///                  set-soft-volume：设置软件音量，需 softVolume 参数
        ///                  set-hard-volume：设置硬件音量，需 hardVolume 参数
        /// sourceId String 否 广播源 ID
        /// softVolume int 否 软件音量（0～99）
        /// hardVolume int 否 系统音量（0～9）
        /// 返回请求结果
        /// {
        ///  "status": "success",
        ///  "message": "play success"
        /// }
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> BroadcastDevice(ZycooBroadcastDeviceModel device);
        /// <summary>
        /// TTS 文件生成
        /// POST => https://192.168.12.178/ginapi/xf/createTTS
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// Content-Type application/x-www-form-urlencoded
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// fileType String 是 文件类型，默认使用 mp3
        /// text String 是 TTS 转换内容
        /// downloadFile String 否 参数不存在或为 yes，返回音频文件数据流；
        ///                        参数存在且不为 yes，返回服务器存储的文件路径。
        /// 中文转语音时，注意编码格式的转换，windows 默认不支持 UTF-8
        /// </summary>
        /// <param name="tts"></param>
        /// <returns></returns>
        IAlertMsg<object> TTSAdd(ZycooTTSAddModel tts);
        /// <summary>
        /// TTS 文件播放
        /// POST => http://192.168.12.178:8000/coocenter-api/plugin-coopaging/task
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// Content-Type application/json
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// task Object 是 文件类型，默认使用 mp3
        /// enable String 是 默认“yes"
        /// extensions [String] 是 广播终端 ID 数组
        /// name String 是 任务名称
        /// paging_type String 是 默认使用 “normal”
        /// play_strategy String 是 默认使用 “order”
        /// sound_type String 是 默认使用 “text”
        /// source_info Object 是 播放信息
        ///  content String 是 名称描述
        ///  path String 是 文件路径（创建 TTS 文件返回的内容）
        /// times int 是 播放次数，0 为无限循环
        /// type String 是 默认为 “realtimerule”即时播放
        /// volume int 是 播放音量，范围为 0~100
        /// 返回请求结果
        /// {
        ///  "message": "executed",
        ///  "status": "success"
        /// }
        /// </summary>
        /// <param name="tts"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> TTSPlay(ZycooTTSPlayModel tts);
        /// <summary>
        /// 音乐库文件列表
        /// GET => https://192.168.17.231/coocenter-api/plugin-player/musiclibrary
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// limit int 是 每页显示数量
        /// page int 是 页码
        /// type String 是 music：音乐文件 warning：告警文件
        /// 返回请求结果
        /// {
        ///     "count": 4,
        ///     "rows" : [
        ///     {
        ///         "id": 73,
        ///         "name": "Going Home",
        ///         "duration": 332.75,
        ///         "type": "music",
        ///         "path": "/music/music/b4f77100-d948-11eb-9ef8-2f1e3e65dcfd.mp3",
        ///         "createdAt": "2021-06-30T2:13:06.000Z",
        ///         "updatedAt": "2021-06-30T82:13:06.000Z"
        ///     }]
        /// }
        /// 【说明】id------对应音乐文件的标识
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        IAlertMsg<IZycooResModels<ZycooMusicInfoModel>> MusicSearch(int limit, int page, string type);
        /// <summary>
        /// 音乐库文件上传
        /// POST => https://192.168.17.231/coocenter-api/plugin-player/musiclibrary
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// Content-Type multipart/form-data
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// file [String] 是 仅支持 mp3 类型文件
        /// type String 是 music：音乐文件 warning：告警文件
        /// 返回请求结果
        /// {
        ///     "status": "success",
        ///     "data": {
        ///         "id":59,
        ///         "name":"test",
        ///         "path":"/music/music/d78134d0-9dc5-11ec-92e9-6b969ff91229.mp3",
        ///         "type":"music",
        ///         "duration":"279.72",
        ///         "updatedAt":"2022-03-07T03:22:39.335Z",
        ///         "createdAt":"2022-03-07T03:22:39.335Z"
        ///     }
        /// }
        /// </summary>
        /// <param name="file"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel<ZycooMusicInfoModel>> MusicUpload(string file, string type);
        /// <summary>
        /// 录音文件上传
        /// POST => https://192.168.17.231/coocenter-api/plugin-player/recordlibrary
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// Content-Type multipart/form-data
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// file [String] 是 仅支持 WAV 类型文件
        /// type String 是 music：音乐文件 warning：告警文件
        /// 返回请求结果
        /// {
        ///     "status": "success",
        ///     "path": "/music/recording/45632154897523-45668415-54258.mp3"
        /// }
        /// </summary>
        /// <param name="file"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel<String>> WaveUpload(string file, string type);
        /// <summary>
        /// 单个音乐库文件删除
        /// DELETE => https://192.168.17.231/coocenter-api/plugin-player/musiclibrary/
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// id Int (path) 是 删除音乐文件的 ID
        /// 返回请求结果
        /// { "status": "success" }
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> MusicDelete(int id);
        /// <summary>
        /// 多个音乐库文件删除
        /// POST => https://192.168.17.231/coocenter-api/plugin-player/musiclibrary-bulk-delete
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// ids [Int ] 是 音乐文件 ID 数组
        /// 返回请求结果
        /// { "status": "success" }
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> MusicDelete(int[] ids);
        /// <summary>
        /// 播放列表获取
        /// GET => https://192.168.17.231/coocenter-api/plugin-player/playlist
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// limit int 是 每页显示数量
        /// page int 是 页码
        /// type String 否 music：音乐文件 warning：告警文件,缺省值
        /// 返回请求结果
        /// {
        ///     "count":5,
        ///     "rows":[
        ///     {
        ///         "id":13,
        ///         "name":"test0624",
        ///         "remark":"",
        ///         "other":null,
        ///         "order":[61,59,58,50,54,51,45,46],
        ///         "createdAt":"2021-06-24T06:38:49.000Z",
        ///         "updatedAt":"2021-06-28T02:02:59.000Z",
        ///         "musicLibraries":[
        ///         {
        ///             "id":70,
        ///             "name":"茉莉花",
        ///             "duration":279.72,
        ///             "type":"music",
        ///             "path":"/music/music/43b123c0-d947-11eb-9ef8-2f1e3e65dcfd.mp3",
        ///             "createdAt":"2021-06-30T02:02:46.000Z",
        ///             "updatedAt":"2021-06-30T02:02:46.000Z",
        ///             "t_paging_library_list_map":{
        ///                 "createdAt":"2021-06-30T03:09:55.000Z",
        ///                 "updatedAt":"2021-06-30T03:09:55.000Z",
        ///                 "MusicLibraryId":70,
        ///                 "PlayListId":33
        ///             }
        ///         }]
        ///      }]
        /// }
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        IAlertMsg<IZycooResModels<ZycooPlayInfoModel>> PlaySearch(int limit, int page, string type);
        /// <summary>
        /// 播放列表创建
        /// POST => https://192.168.17.231/coocenter-api/plugin-player/playlist
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// playList Object 是
        /// name String 是 列表名称
        /// musicLibraryIds Object[] 是 列表的音乐文件 ID 数组
        /// remark String 否 备注
        /// 返回请求结果
        /// {
        ///     "status": "success",
        ///     "data": { "sourceId": "sourceId-36" },
        ///     "message": "create cast success"
        /// }
        /// </summary>
        /// <param name="playlist"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel<string>> PlayAdd(ZycooPlayAddModel playlist);
        /// <summary>
        /// 播放列表编辑
        /// PUT => https://192.168.17.231/coocenter-api/plugin-player/playlist
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// id Int 是 播放列表 ID 
        /// playList Object 是
        /// action String 是 update
        /// name String 否 列表名称
        /// remark String 否 备注
        /// ids Object[] 是 列表的音乐文件 ID 数组
        /// 返回请求结果
        /// { "status": "success", "message": "update success" }
        /// </summary>
        /// <param name="playlist"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> PlayEdit(ZycooPlayEditModel playlist);
        /// <summary>
        /// 播放列表删除
        /// DELETE => https://192.168.17.231/coocenter-api/plugin-player/playlist
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// id Int 是 播放列 ID
        /// 返回请求结果
        /// { "status": "success", "message": "stop success" }
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> PlayDelete(int id);
        #endregion 3.3、广播控制接口
        #region // 3.4、广播任务接口
        /// <summary>
        /// 获取广播任务列表
        /// GET => http://192.168.11.109:8000/coocenter-api/plugin-coopaging/task
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// limit int 是 每页显示数量
        /// page int 是 页码
        /// name String 否 任务名称
        /// type String 否 任务类型(时间任务：timerule，号码任务：numberrule）
        /// sound_type String 否 音频类型（音乐：music，TTS：text，采集录音：acquisition，告警音频：alarm）
        /// 参数名 类型 描述
        /// count int 查询结果总数
        /// rows Object[] 任务列表
        /// id int 任务 ID
        ///  enable String 是否开启任务（yes/no)
        ///  main_id int 主任务 ID（null 表示任务为主任务，否则为子任务）
        ///  name String 任务名称
        ///  type String 任务类型
        ///  conditions Object 任务触发条件
        ///  mode String
        ///  extension String
        ///  paging_type String 广播类型
        ///  sound_type String 音乐源类型
        ///  play_strategy String 播放策略
        ///  source_info Object 音乐源信息
        ///  extensions Object[] 终端数组
        ///  volume int 音量设置
        /// times int 播放次数
        /// 返回请求结果
        /// {
        ///     "count": 5,
        ///     "rows": [
        ///     {
        ///         "id": 4,
        ///         "enable": "no",
        ///         "task_type": null,
        ///         "main_id": null,
        ///         "name": "task-3",
        ///         "type": "numberrule",
        ///         "conditions": {
        ///             "mode": "extension",
        ///             "extension": "1024"
        ///         },
        ///         "paging_type": "normal",
        ///         "sound_type": "music",
        ///         "play_strategy": "order",
        ///         "source_info": {
        ///             "sourceId": "sourceId-17"
        ///         },
        ///         "extensions": [
        ///             "1006"
        ///         ],
        ///         "volume": 40,
        ///         "times": -1,
        ///         "createdAt": "2020-11-30T08:46:51.000Z",
        ///         "updatedAt": "2021-03-25T08:43:37.000Z",
        ///         "children": []
        ///     }]
        /// }
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="soundType"></param>
        /// <returns></returns>
        IAlertMsg<IZycooResModels<ZycooTaskInfoModel>> TaskSearch(int limit, int page, string name, string type, string soundType);
        /// <summary>
        /// 创建即时任务（立即执行）
        /// POST => http://192.168.11.109:8000/coocenter-api/plugin-coopaging/task
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// task Object 是
        /// enable String 否 是否开启/关闭任务 “yes/no”
        /// name String 是 任务名称
        /// type String 是 任务类型：即时任务：realtimerule时间任务：timerule 号码任务：numberrule
        /// paging_type String 是 normal
        /// sound_type String 是 音频类型（音乐：music， TTS：text，采集录音：acquisition， 告警音频：alarm）
        /// play_strategy String 否 播放策略: 缺省值，顺序—order；random：随机播放
        /// source_info Object 是
        /// sourceId String 是 播放列表值
        /// extensions [String] 是 广播终端号码数组
        /// times int 否 循环次数，-1 为无限循环
        /// volume int 否 播放音量，范围为 0~100
        /// 返回请求结果
        /// {"status":"success","message":"executed"}
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> TaskAdd(ZycooTaskAddModel task);
        /// <summary>
        /// 创建定时任务（常规）
        /// POST => http://192.168.11.109:8000/coocenter-api/plugin-coopaging/task
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// task Object 是
        /// enable String 是 是否开启/关闭任务 “yes/no”
        /// name String 是 任务名称
        /// type String 是 任务类型：即时任务：realtimerule 时间任务：timerule 号码任务：numberrule
        /// play_strategy String 否 播放策略:缺省值，顺序—order；random：随机播放 
        /// sound_type String 是 音频类型 音乐：music， TTS：text， 采集录音：acquisition，告警音频：alarm
        /// main_id String 否 创建子任务时，其所属的主任务 id
        /// paging_type String 是 Normal
        /// source_info Object 是
        /// sourceId String 是 播放列表值 sound_type 为 music
        /// content String 是 文字转语音内容，sound_type 为 text
        /// path String 是 文字转语音文件存储路径
        /// extensions [String] 是 广播终端号码数组
        /// times int 否 循环次数（0 表示无限循环）；sound_type 为 music 时，此参数无效
        /// volume int 否 播放音量，范围为 0~100
        /// conditions Object 是
        /// mode String 是 loop
        /// date String 否
        /// time Object[] 是 起止时间数组
        /// weekDays Object[] 是 周天数组，"mon", "tues", "wed", "thur", "fri", "sat", "sun"
        /// 音乐定时播放
        /// { 
        ///     "task":{ 
        ///         "enable": "yes",
        ///         "name":"ti00",
        ///         "type": "timerule",
        ///         "paging_type":"normal",
        ///         "sound_type": "music", 
        ///         "source_info": {
        ///             "sourceId": "sourceId-43"},
        ///             "extensions": ["1004"],
        ///             "conditions":{
        ///                 "mode":"loop",
        ///                 "time": ["10:08:00","10:13:00"],
        ///                 "weekDays": ["thur","fri"]
        ///             }
        ///         }
        ///     }
        /// }
        /// 返回请求结果
        /// {
        ///     "id": 28,
        ///     "enable": "yes",
        ///     "name": "ti00",
        ///     "type": "timerule",
        ///     "paging_type": "normal",
        ///     "sound_type": "music",
        ///     "source_info": {
        ///         "sourceId": "sourceId-43"
        ///     },
        ///     "extensions": [ "1004" ],
        ///     "conditions": {
        ///         "mode": "loop",
        ///         "time": [ "10:08:00", "10:13:00" ],
        ///         "weekDays": [ "thur", "fri" ]
        ///     },
        ///     "updatedAt": "2021-07-01T02:07:52.364Z",
        ///     "createdAt": "2021-07-01T02:07:52.364Z"
        /// }
        /// 文字转语音(按指定次数循环播放:eg:times=2)
        /// {
        ///     "task":{ 
        ///         "enable": "yes",
        ///         "name":"tts001",
        ///         "type": "timerule",
        ///         "paging_type":"normal",
        ///         "sound_type": "text", 
        ///         "source_info": {
        ///             "content": "这是一个测试活动！",
        ///             "path":"/music/tts/tts-sox-1625556572106829443.mp3"
        ///         },
        ///         "extensions": ["1004"],
        ///         "times":2,
        ///         "conditions":{
        ///             "mode":"loop",
        ///             "time": ["11:40:00","11:42:00"],
        ///             "weekDays": ["mon","tues","wed"]
        ///         }
        ///     }
        /// }
        /// 执行结果：
        /// {
        ///     "id": 14,
        ///     "enable": "yes",
        ///     "name": "tts001",
        ///     "type": "timerule",
        ///     "paging_type": "normal",
        ///     "sound_type": "text",
        ///     "source_info": {
        ///         "content": "����һ�����Ի ��",
        ///         "path": "/music/tts/tts-sox-1625556572106829443.mp3"
        ///     },
        ///     "extensions": [ "1004" ],
        ///     "times": 2,
        ///     "conditions": {
        ///         "mode": "loop",
        ///         "time": [ "11:40:00", "11:42:00" ],
        ///         "weekDays": [ "mon", "tues", "wed" ]
        ///     },
        ///     "updatedAt": "2021-07-07T03:39:28.942Z",
        ///     "createdAt": "2021-07-07T03:39:28.942Z"
        /// }
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> TaskAdd(ZycooTaskTimerModel task);
        /// <summary>
        /// 创建定时任务（循环模式一）
        /// POST => http://192.168.11.109:8000/coocenter-api/plugin-coopaging/task
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// task Object 是
        /// enable String 是 是否开启/关闭任务 “yes/no”
        /// name String 是 任务名称
        /// type String 是 任务类型：即时任务：realtimerule 时间任务：timerule  号码任务：numberrule
        /// play_strategy String 否 播放策略: 缺省值，顺序—order；random：随机播放
        /// sound_type String 是 音频类型（音乐：music，TTS：text，采集录音：acquisition，告警音频：alarm）
        /// main_id String 否 创建子任务时，其所属的主任务 id
        /// paging_type String 是 Normal
        /// source_info Object 是
        /// sourceId String 是 播放列表值
        /// extensions [String] 是 广播终端号码数组
        /// times int 否 循环次数（0 表示无限循环）；sound_type 为 music 时，此参数无效
        /// volume int 否 播放音量，范围为 0~100
        /// conditions Object 是
        /// mode String 是 once，只能在某日执行；loop，可在多日内执行
        /// date Object[] 否 起止日期数组
        /// time Object[] 是 起止时间数组
        /// weekDays Object[] 是 周天数组，"mon", "tues", "wed", "thur", "fri", "sat", "sun"
        /// duration String 是 循环时长（S），即一个循环周期时间
        /// playMode String 是 one,模式一；two，模式二
        /// playLength String 是 一个循环周期中，实际播放时长（S）
        /// 模式一说明 每次循环的周期为 duration 时长，在一次循环中，对象的播放时间为 playLength 时长
        /// {
        ///     "task":{ 
        ///         "enable": "yes",
        ///         "name":"ti10",
        ///         "type": "timerule",
        ///         "paging_type":"normal",
        ///         "sound_type": "music", 
        ///         "source_info": {
        ///             "sourceId": "sourceId-43"
        ///         },
        ///         "extensions": ["1004"],
        ///         "conditions":{
        ///             "mode":"loop", 
        ///             "time": ["11:30:00","11:36:00"],
        ///             "duration":65, 
        ///             "playLength":10, 
        ///             "playMode": "one",
        ///             "weekDays": ["thur","fri"]
        ///         }
        ///     }
        /// }
        /// 执行结果：
        /// {
        ///     "id": 32,
        ///     "enable": "yes",
        ///     "name": "ti10",
        ///     "type": "timerule",
        ///     "paging_type": "normal",
        ///     "sound_type": "music",
        ///     "source_info": {
        ///         "sourceId": "sourceId-43"
        ///     },
        ///     "extensions": [ "1004" ],
        ///     "conditions": {
        ///         "mode": "loop",
        ///         "time": [ "11:30:00", "11:36:00" ],
        ///         "duration": 65,
        ///         "playLength": 10,
        ///         "playMode": "one",
        ///         "weekDays": [ "thur", "fri" ]
        ///     },
        ///     "updatedAt": "2021-07-01T03:29:54.586Z",
        ///     "createdAt": "2021-07-01T03:29:54.586Z"
        /// }
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> TaskLoopMode(ZycooTaskLoopM1Model task);
        /// <summary>
        /// 创建定时任务（循环模式二）
        /// POST => http://192.168.11.109:8000/coocenter-api/plugin-coopaging/task
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// task Object 是
        /// enable String 是 是否开启/关闭任务 “yes/no”
        /// name String 是 任务名称
        /// type String 是 任务类型：即时任务：realtimerule 时间任务：timerule 号码任务：numberrule
        /// play_strategy String 否 播放策略: 缺省值，顺序—order； random：随机播放
        /// sound_type String 是 音频类型： 音乐：music，  TTS：text， 采集录音：acquisition， 告警音频：alarm
        /// main_id String 否 创建子任务时，其所属的主任务 id
        /// paging_type String 是 Normal
        /// source_info Object 是
        /// sourceId String 是 播放列表值
        /// extensions [String] 是 广播终端号码数组
        /// times int 否 循环次数（0 表示无限循环）；sound_type 为 music 时， 此参数无效
        /// volume int 否 播放音量，范围为 0~100
        /// conditions Object 是
        /// mode String 是 loop
        /// date Object[] 否 起止日期数组
        /// time Object[] 是 起止时间数组
        /// weekDays Object[] 是 周天数组， "mon", "tues", "wed", "thur", "fri", "sat", "sun"
        /// playDuration String 否 循环播放的间隔时长，缺省值为 60（S）
        /// playMode String 是 one,模式一；two，模式二
        /// 模式二说明
        /// 如 time 时长大于播放列表的总播放时间（列表中的所有文件播放一次需要的时间），
        /// 当日任务会生成多次循环，循环间隔时间为 playDuration 时长；如 time 时长小于播放列表的
        /// 总播放时间，任务会在指定时间结束，一次大循环所需时间计算示例如下：
        /// 【MUSIC 类型、Alarm 类型】
        /// 一次大循环所需时间=列表播放时长+间隔时长 playDuration
        /// 【TTS 类型、采播类型】
        /// 一次大循环所需时间=TTS(采播)时长*次数+间隔时长 playDuration
        /// 【总结】
        /// 任务会在指定的时间开始执行，在等待间隔时长之后，任务再次播放（前提 time 充裕）。
        /// 定时结束时，停止所有正在执行的循环和播放任务。
        /// {
        ///     "task":{ 
        ///         "enable": "yes",
        ///         "name":"ti20",
        ///         "type": "timerule",
        ///         "paging_type":"normal",
        ///         "sound_type": "music", 
        ///         "source_info": {
        ///             "sourceId": "sourceId-43"
        ///         },
        ///         "extensions": ["1004"],
        ///         "conditions":{
        ///             "mode":"loop", 
        ///             "time": ["11:47:00","11:56:00"],
        ///             "playDuration":30, 
        ///             "playMode": "two",
        ///             "weekDays": ["thur","fri"]
        ///         }
        ///     }
        /// }
        /// 执行结果：
        /// {
        ///     "id": 34,
        ///     "enable": "yes",
        ///     "name": "ti20",
        ///     "type": "timerule",
        ///     "paging_type": "normal",
        ///     "sound_type": "music",
        ///     "source_info": {
        ///         "sourceId": "sourceId-43"
        ///     },
        ///     "extensions": [ "1004" ],
        ///     "conditions": {
        ///         "mode": "loop",
        ///         "time": [ "11:47:00", "11:56:00" ],
        ///         "playDuration": 30,
        ///         "playMode": "two",
        ///         "weekDays": [ "thur", "fri" ]
        ///     },
        ///     "updatedAt": "2021-07-01T03:46:42.764Z",
        ///     "createdAt": "2021-07-01T03:46:42.764Z"
        /// }
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> TaskLoopMode(ZycooTaskLoopM2Model task);
        /// <summary>
        /// 创建拨号任务
        /// POST => http://192.168.11.109:8000/coocenter-api/plugin-coopaging/task
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// task Object 是
        /// enable String 是 是否开启/关闭任务 “yes/no”
        /// name String 是 任务名称
        /// type String 是 任务类型： 即时任务：realtimerule 时间任务：timerule 号码任务：numberrule
        /// play_strategy String 否 播放策略: 缺省值，顺序—order； random：随机播放
        /// sound_type String 是 音频类型： 音乐：music，  TTS：text， 采集录音：acquisition， 告警音频：alarm
        /// main_id String 否 创建子任务时，其所属的主任务 id
        /// paging_type String 是 Normal
        /// source_info Object 是
        /// content String 是 文字内容
        /// path String 是 eg: /music/tts/tts-sox-1624945406386000017.mp3
        /// extensions [String] 是 广播终端号码数组
        /// times int 否 循环次数，-1 为无限循环
        /// volume int 否 播放音量，范围为 0~100
        /// conditions Object 是
        /// 执行示例
        /// {
        ///     "task":{ 
        ///         "enable": "yes",
        ///         "name":"dial30",
        ///         "type": "numberrule",
        ///         "paging_type":"normal",
        ///         "sound_type": "music", 
        ///         "source_info": {
        ///             "sourceId": "sourceId-43"
        ///         },
        ///         "extensions": ["1004"],
        ///         "conditions":{
        ///             "mode":"extension",
        ///             "extension": "30"
        ///         }
        ///     }
        /// }
        /// 执行结果：
        /// {
        ///     "id": 36,
        ///     "enable": "yes",
        ///     "name": "dial30",
        ///     "type": "numberrule",
        ///     "paging_type": "normal",
        ///     "sound_type": "music",
        ///     "source_info": {
        ///         "sourceId": "sourceId-43"
        ///     },
        ///     "extensions": [ "1004" ],
        ///     "conditions": {
        ///         "mode": "extension",
        ///         "extension": "30"
        ///     },
        ///     "updatedAt": "2021-07-01T05:44:24.435Z",
        ///     "createdAt": "2021-07-01T05:44:24.435Z"
        /// }
        /// 【说明】
        /// 通过拨号的方式，触发任务执行
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> TaskPhone(ZycooTaskPhoneModel task);
        /// <summary>
        /// 编辑定时任务（常规）
        /// PUT => http://192.168.11.109:8000/coocenter-api/plugin-coopaging/task
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// id int 是 任务 ID
        /// task Object 是
        /// enable String 否 是否开启/关闭任务 “yes/no”
        /// name String 否 任务名称
        /// type String 否 任务类型： 即时任务：realtimerule 时间任务：timerule  号码任务：numberrule
        /// play_strategy String 否 播放策略: Order： 顺序播放 random：随机播放
        /// sound_type String 否 音频类型 音乐：music，  TTS： text， 采集录音：acquisition， 告警音频：alarm
        /// main_id String 否 创建子任务时，其所属的主任务 id
        /// paging_type String 否 Normal
        /// source_info Object 否
        /// sourceId String 否 播放列表值 sound_type 为 music
        /// content String 否 文字转语音内容，
        /// sound_type 为 text
        /// path String 否 文字转语音文件存储路径
        /// extensions [String] 否 广播终端号码数组
        /// times int 否 循环次数（0 表示无限循环）；sound_type 为 music 时， 此参数无效
        /// volume int 否 播放音量，范围为 0~100
        /// conditions Object 否
        /// mode String 否 loop
        /// date String 否
        /// time Object[] 否 起止时间数组
        /// weekDays Object[] 否 周天数组， "mon", "tues", "wed", "thur", "fri", "sat", "sun"
        /// 示例一:
        /// {
        ///     "task":{ 
        ///         "enable": "yes",
        ///         "name":"ti00",
        ///         "type": "timerule",
        ///         "paging_type":"normal",
        ///         "sound_type": "music", 
        ///         "source_info": {
        ///             "sourceId": "sourceId-43"
        ///         },
        ///         "extensions": ["1004"],
        ///         "conditions":{
        ///             "mode":"loop",
        ///             "time": ["10:08:00","10:13:00"],
        ///             "weekDays": ["thur","fri"]
        ///         }
        ///     }
        /// }
        /// 执行结果：
        /// [1]
        /// 示例二:
        /// {"task":{}}
        /// 执行结果：
        /// [0]
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> TaskEdit(ZycooTaskEditModel task);
        /// <summary>
        /// 删除任务
        /// DELETE => http://192.168.11.109:8000/coocenter-api/plugin-coopaging/task/
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// id Int 是 任务 ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> TaskDelete(int id);
        /// <summary>
        /// 获取今日任务
        /// GET => http://192.168.11.109:8000/coocenter-api/plugin-coopaging/schedule
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// {   
        ///     "status":"success",
        ///     "data":[
        ///     {
        ///         "id":26,
        ///         "taskId":"task-number-stop-26",
        ///         "mode":"stop",
        ///         "name":"dial20",
        ///         "type":"numberrule",
        ///         "times":2,
        ///         "extension":"*1220",
        ///         "paging_type":"normal",
        ///         "sound_type":"text",
        ///         "main_id":null,
        ///         "source_info":{
        ///             "path":"/music/tts/tts-sox-1624945406386000017.mp3",
        ///             "content":"第一课：宁静的力量"
        ///         },
        ///         "extensions":["1004"],
        ///         "volume":30
        ///     },{
        ///         "id":26,
        ///         "taskId":"task-number-start-26",
        ///         "mode":"start",
        ///         "name":"dial20",
        ///         "type":"numberrule",
        ///         "times":2,
        ///         "extension":"*1120",
        ///         "paging_type":"normal",
        ///         "sound_type":"text",
        ///         "main_id":null,
        ///         "source_info":{
        ///             "path":"/music/tts/tts-sox-1624945406386000017.mp3",
        ///             "content":"第一课：宁静的力量"
        ///         },
        ///         "extensions":["1004"],
        ///         "volume":30
        ///     }]
        /// }
        /// </summary>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> TaskToday();
        /// <summary>
        /// 获取任务日志
        /// GET => http://192.168.11.109:8000/coocenter-api/plugin-coopaging/tasklog
        /// Header 域
        /// 参数名 参数值
        /// accept application/json
        /// Authorization Bearer &lt;token&gt;
        /// 参数列表
        /// 参数名 类型 必填 描述
        /// limit int 是 每页显示数量
        /// page int 是 页码
        /// 请求结果
        /// {
        ///     "count": 2,
        ///     "rows": [
        ///     {
        ///         "id": 309,
        ///         "name": "ti00",
        ///         "type": "timerule",
        ///         "mode": "stop",
        ///         "sound_type": "music",
        ///         "source_info": {
        ///             "name": "test01",
        ///             "sourceId": "sourceId-43"
        ///         },
        ///         "extensions": [ "1004" ],
        ///         "status": "executed",
        ///         "createdAt": "2021-07-01T06:43:00.000Z",
        ///         "updatedAt": "2021-07-01T06:43:00.000Z"
        ///     },{
        ///         "id": 308,
        ///         "name": "ti00",
        ///         "type": "timerule",
        ///         "mode": "start",
        ///         "sound_type": "music",
        ///         "source_info": {
        ///             "name": "test01",
        ///             "sourceId": "sourceId-43"
        ///         },
        ///         "extensions": [ "1004" ],
        ///         "status": "executed",
        ///         "createdAt": "2021-07-01T06:27:01.000Z",
        ///         "updatedAt": "2021-07-01T06:27:01.000Z"
        ///     }]
        /// }
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        IAlertMsg<IZycooDataModel> TaskLogSearch(int limit, int page);
        #endregion 3.4、广播任务接口
        #endregion 三、控制接口
        #region // 四、状态推送接口
        #region // 4.1、配置状态推送地址
        /// <summary>
        /// 配置状态推送地址
        /// 访问 url 地址：https://192.168.17.231/coocenter-api/master/public/login，登录 API 接口配置页面
        /// 开启推送功能，并配置推送地址
        /// Enable： 开启消息推送功能
        /// postURL： 配置推送地址，例如：http://192.168.12.220/events
        /// 重启：reload 即可
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        IAlertMsg SetPushUrl(string url);
        #endregion 4.1、配置状态推送地址
        #region // 4.2、主动推送事件
        /// <summary>
        /// 分机状态
        /// {
        ///  event: "extensionstatus",
        ///  exten: "808",
        ///  status: "0",
        ///  statustext: "Idle"
        /// }
        /// 参数名 类型 描述
        /// event String 事件类型
        /// exten String 设备号码
        /// status String 状态码 0:待机，1:通话中，2:忙线，4:离线，8:振铃中，16:保持
        /// statustext String 状态描述
        /// </summary>
        /// <returns></returns>
        IAlertMsg PushPhoneStatus();
        /// <summary>
        /// 呼叫开始事件
        /// {  
        ///    event:"dialbegin",
        ///    timestamp:"1534993059.785012", //主叫通道唯一标识
        ///    channel:"DAHDI/i1/18782985586-51", //主叫通道
        ///    calleridnum:"18782985586", //主叫号码
        ///    destchannel:"SIP/886-00000065", //被叫通道
        ///    destcalleridnum:"886", //被叫号码 
        ///    destuniqueid:"1534993059.630", //被叫通道唯一标识
        ///    dialstring:"SIP/886",
        ///    uniqueid:"1534993030.626", //呼叫唯一标识
        /// }  
        /// 
        /// </summary>
        /// <returns></returns>
        IAlertMsg PushPhoneStart();
        /// <summary>
        /// 呼叫结束事件
        /// {
        ///     event:"dialend",
        ///     timestamp: "1534993059.785012", //时间戳
        ///     channel: "DAHDI/i1/18782985586-51", //主叫通道
        ///     calleridnum: "18782985586", //主叫号码
        ///     destchannel:"SIP/886-00000065", //被叫通道
        ///     destcalleridnum: "886", //被叫号码
        ///     uniqueid: "1534993030.626", //呼叫唯一标识
        ///     dialstatus:"ANSWER" //呼叫结束状态: ABORT:呼叫终止; ANSWER:呼叫被接听; BUSY:线路忙; CANCEL: 呼叫被取消; CHANUNAVAIL:线路不可达; NOANSWER:线路无应答
        /// }
        /// </summary>
        /// <returns></returns>
        IAlertMsg PushPhoneStop();
        /// <summary>
        /// 通话结束事件
        /// {
        ///  event: "hangup"
        ///  calleridnum: "808", //主叫号码
        ///  calleridname: "808", //主叫名称
        ///  connectedlinenum: "809", //被叫号码
        ///  connectedlinename: "809", //被叫名称
        ///  uniqueid: "1325747409.260", //呼叫唯一标识
        /// }
        /// </summary>
        /// <returns></returns>
        IAlertMsg PushPhoneEnd();
        /// <summary>
        /// 通话日志
        /// {
        ///     event: "cdr",
        ///     srcname: "Dispatcher",
        ///     src: "1001",
        ///     dstname: "IP Phone",
        ///     dst: "1002",
        ///     start: "2020-07-15 15:52:02",
        ///     answer: "2020-07-15 15:52:12",
        ///     end: "2020-07-15 15:53:28",
        ///     billsec: "76",
        ///     sessionlevel: "1",
        ///     calltype: "internal",
        ///     record_filename: "asterisk/monitor/recording/20200715/recording-1001-1002-internal-1594799522.4.wav",
        ///     status: "ANSWER",
        ///     uniqueid: "1594799522.4"
        /// }
        /// 参数名 类型 描述
        /// event String 事件类型
        /// srcname String 主叫名称
        /// src String 主叫号码
        /// dstname String 被叫名称
        /// dst String 被叫号码
        /// start String 呼叫开始时间
        /// answer String 呼叫接通时间
        /// end String 呼叫结束时间
        /// billsec String 通话时长
        /// sessionlevel String 会话级别（与操作员等级相关，1 为最高，13 为最低）
        /// calltype String 通话类型（internal 内部通话，incoming 呼入，outgoing呼出）
        /// record_filename String 录音文件
        /// status String 通话状态
        /// uniqueid String 通话唯一标识
        /// </summary>
        /// <returns></returns>
        IAlertMsg PushPhoneCallLog();
        /// <summary>
        /// 对讲日志
        /// {
        ///     event: "idr",
        ///     srcname: "Dispatcher",
        ///     src: "1001",
        ///     dstname: "Intercom",
        ///     dst: "1003",
        ///     start: "2020-07-16 14:52:02",
        ///     answer: "2020-07-16 14:52:12",
        ///     end: "2020-07-16 14:53:28",
        ///     billsec: "76",
        ///     sessionlevel: "1",
        ///     calltype: "intercom",
        ///     record_filename: "asterisk/monitor/recording/20200716/recording-1001-1003-intercom-1594882322.4.wav",
        ///     status: "ANSWER",
        ///     uniqueid: "1594882322.4"
        /// }
        /// 参数名 类型 描述
        /// event String 事件类型
        /// srcname String 主叫名称
        /// src String 主叫号码
        /// dstname String 被叫名称
        /// dst String 被叫号码
        /// start String 呼叫开始时间
        /// answer String 呼叫接通时间
        /// end String 呼叫结束时间
        /// billsec String 通话时长
        /// sessionlevel String 会话级别（与操作员等级相关，1 为最高，13 为最低）
        /// calltype String 通话类型
        /// record_filename String 录音文件
        /// uniqueid String 通话唯一标识
        /// </summary>
        /// <returns></returns>
        IAlertMsg PushPhoneSpeakLog();
        /// <summary>
        /// 喊话日志
        /// {
        ///     event: "pdr",
        ///     srcname: "Dispatcher",
        ///     src: "1001",
        ///     dst: ["1010","1011","1012","1013","1014"],
        ///     start: "2020-07-16 14:32:02",
        ///     end: "2020-07-16 14:33:28",
        ///     billsec: "76",
        ///     sessionlevel: "1",
        ///     calltype: "paging",
        ///     record_filename: "asterisk/monitor/recording/20200715/recording-1001-1003-paging-1594882322.4.wav",
        ///     uniqueid: "1594882322.4"
        /// }   
        /// 参数名 类型 描述
        /// event String 事件类型
        /// srcname String 主叫名称
        /// src String 主叫号码
        /// dst String 被叫号码
        /// start String 呼叫开始时间
        /// end String 呼叫结束时间
        /// billsec String 通话时长
        /// sessionlevel String 会话级别（与操作员等级相关，1 为最高，13 为最低）
        /// calltype String 通话类型
        /// record_filename String 录音文件
        /// uniqueid String 通话唯一标识
        /// </summary>
        /// <returns></returns>
        IAlertMsg PushPhoneTalkLog();
        #endregion 4.2、主动推送事件
        #endregion 四、状态推送接口
    }
    /// <summary>
    /// 智科通信SIP网络电话
    /// 版本v1.0.9
    /// </summary>
    public class ZycooSIPNetApiProxyV1 : IZycooSIPNetApiProxyV1, IDisposable
    {
        /// <summary>
        /// 检查计时器
        /// </summary>
        protected virtual Timer CheckTimer { get; }
        /// <summary>
        /// 中心配置
        /// </summary>
        public virtual ZycooConfigModelV1 Center { get; }
        /// <summary>
        /// 构造
        /// </summary>
        public ZycooSIPNetApiProxyV1() : this(null) { }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="config"></param>
        public ZycooSIPNetApiProxyV1(ZycooConfigModelV1 config)
        {
            Center = config ?? new ZycooConfigModelV1();
            CheckTimer = new Timer(Center.CheckInterval * 60 * 1000) { AutoReset = true };
            CheckTimer.Elapsed += CheckTimer_Elapsed;
        }
        private void CheckTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Login();
        }
        /// <inheritdoc/>
        public IAlertMsg<ZycooLoginModel> Login()
        {
            Center.Token = string.Empty;
            return TryWeb<ZycooLoginModel>((post) =>
            {
                var res = post.GetResponseJsonString();
                var resJson = post.GetJsonFromJsonp(res);
                var data = resJson.GetJsonObject<ZycooLoginModel>();
                if (data != null && !string.IsNullOrEmpty(data.Token))
                {
                    Center.Token = data.Token;
                    if (Center.IsCheck)
                    {
                        CheckTimer.Stop();
                        CheckTimer.Interval = Center.CheckInterval * 60 * 1000;
                        CheckTimer.Start();
                    }
                    return new AlertMsg<ZycooLoginModel>(true, "登录成功") { Data = data };
                }
                return new AlertMsg<ZycooLoginModel>(false, data?.Status) { Data = data };
            }, new HttpClientPostModel(GetRequestUrl(Center.ZApiLocalLogin))
            {
                Accept = Center.DefaultAccept,
                ContentType = Center.DefaultAccept,
                BodyArgs = new
                {
                    username = Center.Account,
                    password = Center.Password
                }
            }, TryException<ZycooLoginModel>);
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooResModels<ZycooAccountModel>> AccountSearch(int limit, int page, string filterinfo)
        {
            return TryWeb<IZycooResModels<ZycooAccountModel>>((post) =>
            {
                var res = post.GetResponseJsonString();
                var resJson = post.GetJsonFromJsonp(res);
                var data = resJson.GetJsonObject<ZycooResModels<ZycooAccountModel>>();
                if (data != null)
                {
                    return new AlertMsg<IZycooResModels<ZycooAccountModel>>(true, "查询成功") { Data = data };
                }
                return new AlertMsg<IZycooResModels<ZycooAccountModel>>(false, data?.Status) { Data = data };
            }, new HttpClientGetModel(GetRequestUrl(Center.ZApiAccountSearch))
            {
                Accept = Center.DefaultAccept,
                //ContentType = Center.DefaultAccept,
                Authorization = GetAuthorization(Center.Token),
            }.SetUrlArgs(new Dictionary<string, string>
            {
                { "limit", limit.ToString() },
                { "page", page.ToString() },
                { "filterinfo", filterinfo },
            }), TryException<IZycooResModels<ZycooAccountModel>>);
        }
        /// <inheritdoc/>
        public IAlertMsg<ZycooAccountModel> AccountAdd(ZycooAccountAddModel account)
        {
            return TryWeb<ZycooAccountModel>((post) =>
            {
                var res = post.GetResponseJsonString();
                var resJson = post.GetJsonFromJsonp(res);
                var data = resJson.GetJsonObject<ZycooAccountModel>();
                if (data != null)
                {
                    return new AlertMsg<ZycooAccountModel>(true, "创建成功") { Data = data };
                }
                return new AlertMsg<ZycooAccountModel>(false, "创建失败") { Data = data };
            }, new HttpClientPostModel(GetRequestUrl(Center.ZApiAccountAdd))
            {
                Accept = Center.DefaultAccept,
                ContentType = Center.DefaultAccept,
                Authorization = GetAuthorization(Center.Token),
                BodyArgs = new
                {
                    extension = account
                },
            }, TryException<ZycooAccountModel>);
        }
        /// <inheritdoc/>
        public IAlertMsg AccountEdit(ZycooAccountEditModel account)
        {
            return TryWeb<ZycooAccountModel>((post) =>
            {
                var res = post.GetResponseJsonString();
                var resJson = post.GetJsonFromJsonp(res);
                var data = resJson.GetJsonObject<ZycooAccountModel>();
                if (data != null)
                {
                    return new AlertMsg<ZycooAccountModel>(true, "创建成功") { Data = data };
                }
                return new AlertMsg<ZycooAccountModel>(false, "创建失败") { Data = data };
            }, new HttpClientPutModel(GetRequestUrl(Center.ZApiAccountEdit))
            {
                Accept = Center.DefaultAccept,
                ContentType = Center.DefaultAccept,
                Authorization = GetAuthorization(Center.Token),
                BodyArgs = new
                {
                    id = account.Id,
                    extension = (ZycooAccountAddModel)account
                },
            }.SetUrlArgs("id", account.Id.ToString()), TryException<ZycooAccountModel>);
        }
        /// <inheritdoc/>
        public IAlertMsg AccountEdit(int id, object account)
        {
            return TryWeb<ZycooAccountModel>((post) =>
            {
                var res = post.GetResponseJsonString();
                var resJson = post.GetJsonFromJsonp(res);
                var data = resJson.GetJsonObject<ZycooAccountModel>();
                if (data != null)
                {
                    return new AlertMsg<ZycooAccountModel>(true, "创建成功") { Data = data };
                }
                return new AlertMsg<ZycooAccountModel>(false, "创建失败") { Data = data };
            }, new HttpClientPutModel(GetRequestUrl(Center.ZApiAccountEdit))
            {
                Accept = Center.DefaultAccept,
                ContentType = Center.DefaultAccept,
                Authorization = GetAuthorization(Center.Token),
                BodyArgs = new
                {
                    id,
                    extension = account
                },
            }.SetUrlArgs("id", id.ToString()), TryException<ZycooAccountModel>);
        }
        /// <inheritdoc/>
        public IAlertMsg AccountDelete(int id)
        {
            return TryWeb<int>((post) =>
            {
                var res = post.GetResponseJsonString();
                var resJson = post.GetJsonFromJsonp(res);
                var data = resJson.GetJsonObject<int>();
                if (data > 0)
                {
                    return new AlertMsg<int>(true, "删除成功") { Data = data };
                }
                return new AlertMsg<int>(false, "创建失败");
            }, new HttpClientDeleteModel(GetRequestUrl(Center.ZApiAccountDelete))
            {
                Accept = Center.DefaultAccept,
                Authorization = GetAuthorization(Center.Token),
            }.SetUrlArgs("id", id.ToString()), TryException<int>);
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooResModels<ZycooDeviceModel>> DeviceSearch(int limit, int page, string filterinfo)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<ZycooDeviceModel> DeviceAdd(ZycooDeviceModel device)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg DeviceEdit(ZycooDeviceModel device)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg DeviceDelete(ZycooDeviceModel device)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooResModels<ZycooGroupModel>> GroupSearch(int limit, int page, string filterinfo)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<ZycooGroupModel> GroupAdd(ZycooGroupModel group)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg GroupEdit(ZycooGroupModel group)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg GroupDelete(ZycooGroupModel group)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooResModels<ZycooUserModel>> UserSearch(int limit, int page, string filterinfo)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<ZycooUserModel> UserAdd(ZycooUserModel user)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg UserEdit(ZycooUserModel user)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg UserDelete(ZycooUserModel user)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg ConfigActive()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg SystemPing()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<ZycooSystemHandleModel> SystemHandle()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<ZycooSystemInfoModel> SystemInfo()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel<ZycooPhoneRegStatusModel[]>> PhoneRegStatus()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel<ZycooPhoneHintStatusModel[]>> PhoneHintStatus()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel<ZycooPhoneCallModel[]>> PhoneCalls()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> PhoneDialog(ZycooPhoneDialogModel dialog)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> PhoneIntercom(ZycooPhoneIntercomModel intercom)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> PhoneTransfer(ZycooPhoneTransferModel transfer)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> PhoneSpy(ZycooPhoneSpyModel spy)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> PhoneBargeIn(ZycooPhoneBargeInModel bargeIn)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> PhoneBargeOut(ZycooPhoneBargeOutModel bargeOut)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> PhoneWhisper(ZycooPhoneWhisperModel whisper)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> PhoneHangup(string phones)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> PhoneEmergency(ZycooPhoneEmergencyModel emergency)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel<ZycooConferenceModel[]>> ConferenceSearch()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel<ZycooConferenceDetailModel[]>> ConferenceInfo(string confnum)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooMsgModel<ZycooConferencePhoneModel[]>> ConferenceAdd(string confnum, string extensions)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> ConferenceMute(string confnum, string channel)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> ConferenceUnmute(string confnum, string channel)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> ConferenceRemove(string confnum, string channel)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> ConferenceLock(string confnum)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> ConferenceUnlock(string confnum)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooResModels<ZycooBroadcastModel>> BroadcastSearch()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> BroadcastPlay(ZycooBroadcastPlayModel play)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> BroadcastDevice(ZycooBroadcastDeviceModel device)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<object> TTSAdd(ZycooTTSAddModel tts)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> TTSPlay(ZycooTTSPlayModel tts)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooResModels<ZycooMusicInfoModel>> MusicSearch(int limit, int page, string type)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel<ZycooMusicInfoModel>> MusicUpload(string file, string type)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel<string>> WaveUpload(string file, string type)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> MusicDelete(int id)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> MusicDelete(int[] ids)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooResModels<ZycooPlayInfoModel>> PlaySearch(int limit, int page, string type)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel<string>> PlayAdd(ZycooPlayAddModel playlist)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> PlayEdit(ZycooPlayEditModel playlist)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> PlayDelete(int id)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooResModels<ZycooTaskInfoModel>> TaskSearch(int limit, int page, string name, string type, string soundType)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> TaskAdd(ZycooTaskAddModel task)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> TaskAdd(ZycooTaskTimerModel task)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> TaskLoopMode(ZycooTaskLoopM1Model task)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> TaskLoopMode(ZycooTaskLoopM2Model task)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> TaskPhone(ZycooTaskPhoneModel task)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> TaskEdit(ZycooTaskEditModel task)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> TaskDelete(int id)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> TaskToday()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public IAlertMsg<IZycooDataModel> TaskLogSearch(int limit, int page)
        {
            throw new NotImplementedException();
        }
        #region // 扩展内容
        /// <inheritdoc/>
        public IAlertMsg SetPushUrl(string url)
        {
            return AlertMsg.NotImplement;
        }
        /// <inheritdoc/>
        public IAlertMsg PushPhoneStatus()
        {
            return AlertMsg.NotImplement;
        }
        /// <inheritdoc/>
        public IAlertMsg PushPhoneStart()
        {
            return AlertMsg.NotImplement;
        }
        /// <inheritdoc/>
        public IAlertMsg PushPhoneStop()
        {
            return AlertMsg.NotImplement;
        }
        /// <inheritdoc/>
        public IAlertMsg PushPhoneEnd()
        {
            return AlertMsg.NotImplement;
        }
        /// <inheritdoc/>
        public IAlertMsg PushPhoneCallLog()
        {
            return AlertMsg.NotImplement;
        }
        /// <inheritdoc/>
        public IAlertMsg PushPhoneSpeakLog()
        {
            return AlertMsg.NotImplement;
        }
        /// <inheritdoc/>
        public IAlertMsg PushPhoneTalkLog()
        {
            return AlertMsg.NotImplement;
        }
        #endregion 扩展内容
        #region // 辅助方法
        private static string GetAuthorization(string token)
        {
            if (token.StartsWith("Bearer ")) { return token; }
            return $"Bearer {token}";
        }
        private string GetRequestUrl(string part)
        {
            var address = Center.Address ?? string.Empty;
            var url = string.Empty;
            if (!address.StartsWith("http://") && !address.StartsWith("https://"))
            { url = Center.IsHttps ? "https://" : "http://"; }
            url += $"{address}:{Center.PortRate}/{part}";
            return url;
        }
        private static IAlertMsg<T> TryException<T>(Exception ex, AZycooHttpClientModel model)
        {
            if (ex is ProtocolViolationException exp)
            { return new AlertMsg<T>($"网络协议错误：【{model.Url}】=> {exp.Message}") { Code = 404 }; }
            if (ex is WebException exw)
            { return new AlertMsg<T>($"请求超时或处理时出错：【{model.Url}】=> {exw.Message}") { Code = 404 }; }
            if (ex is InvalidOperationException exi)
            { return new AlertMsg<T>($"响应已被处理：【{model.Url}】=> {exi.Message}") { Code = 404 }; }
            if (ex is NotSupportedException exn)
            { return new AlertMsg<T>($"接口访问方式不支持：【{model.Url}】=> {exn.Message}") { Code = 404 }; }
            return new AlertMsg<T>($"接口访问异常：【{model.Url}】=> {ex.Message}");
        }
        private IAlertMsg<T> TryWeb<T>(Func<AZycooHttpClientModel, IAlertMsg<T>> action, AZycooHttpClientModel model, Func<Exception, AZycooHttpClientModel, IAlertMsg<T>> catcher)
        {
            try
            {
                return action.Invoke(model);
            }
            catch (Exception ex)
            {
                return catcher.Invoke(ex, model);
            }
        }
        /// <summary>
        /// 释放内容
        /// </summary>
        public void Dispose()
        {
        }
        #endregion 辅助方法
    }
}
