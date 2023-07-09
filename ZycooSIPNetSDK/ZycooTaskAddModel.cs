using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ZycooSIPNetSDK
{
    /// <summary>
    /// 任务立即执行播放
    /// </summary>
    public class ZycooTaskAddModel
    {
    }
    /// <summary>
    /// 任务常规播放
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
    /// <see cref="IZycooSIPNetApiProxyV1.TaskAdd(ZycooTaskTimerModel)"/>
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
    /// 返回请求结果 <see cref="ZycooTaskAddResModel"/>
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
    /// 执行结果：<see cref="ZycooTaskAddResModel"/>
    /// </summary>
    public class ZycooTaskTimerModel
    {
        /// <summary>
        /// 是否开启/关闭任务 “yes/no”
        /// </summary>
        public virtual String Enable { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        public virtual String Name { get; set; }
        /// <summary>
        /// 任务类型：
        /// 即时任务：realtimerule 
        /// 时间任务：timerule 
        /// 号码任务：numberrule
        /// </summary>
        public virtual String Type { get; set; }
        /// <summary>
        /// 播放策略:缺省值，顺序—order；random：随机播放 
        /// </summary>
        public virtual String Play_strategy { get; set; }
        /// <summary>
        /// 音频类型 音乐：music， TTS：text， 采集录音：acquisition，告警音频：alarm
        /// </summary>
        public virtual String Sound_type { get; set; }
        /// <summary>
        /// 创建子任务时，其所属的主任务 id
        /// </summary>
        public virtual String Main_id { get; set; }
        /// <summary>
        /// Normal
        /// </summary>
        public virtual String Paging_type { get; set; }
        /// <summary>
        /// 资源信息
        /// sourceId String 是 播放列表值 sound_type 为 music
        /// content String 是 文字转语音内容，sound_type 为 text
        /// path String 是 文字转语音文件存储路径
        /// </summary>
        public virtual ZycooTaskTimerSrcModel Source_info { get; set; }
        /// <summary>
        /// 广播终端号码数组
        /// </summary>
        public virtual string[] Extensions { get; set; }
        /// <summary>
        /// 循环次数（0 表示无限循环）；sound_type 为 music 时，此参数无效
        /// </summary>
        public virtual int Times { get; set; }
        /// <summary>
        /// 播放音量，范围为 0~100
        /// </summary>
        public virtual int? Volume { get; set; }
        /// <summary>
        /// 表达式
        /// mode String 是 loop
        /// date String 否
        /// time Object[] 是 起止时间数组
        /// weekDays Object[] 是 周天数组，"mon", "tues", "wed", "thur", "fri", "sat", "sun"
        /// </summary>
        public virtual ZycooTaskTimerCornModel Conditions { get; set; }
    }
    /// <summary>
    /// 任务常规资源
    /// </summary>
    public class ZycooTaskTimerSrcModel
    {
        /// <summary>
        /// 播放列表值 sound_type 为 music
        /// </summary>
        public virtual String SourceId { get; set; }
        /// <summary>
        /// 文字转语音内容，sound_type 为 text
        /// </summary>
        public virtual String Content { get; set; }
        /// <summary>
        /// 文字转语音文件存储路径
        /// </summary>
        public virtual String Path { get; set; }
    }
    /// <summary>
    /// 任务常规表达式
    /// </summary>
    public class ZycooTaskTimerCornModel
    {
        /// <summary>
        /// loop
        /// </summary>
        public virtual String Mode { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public virtual String Date { get; set; }
        /// <summary>
        /// 起止时间数组
        /// </summary>
        public virtual String[] Time { get; set; }
        /// <summary>
        /// 周天数组，"mon", "tues", "wed", "thur", "fri", "sat", "sun"
        /// </summary>
        public virtual string[] WeekDays { get; set; }
    }
    /// <summary>
    /// 任务添加结果模型
    /// <see cref="ZycooTaskTimerModel"/>
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
    /// <see cref="ZycooTaskTimerModel"/>
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
    public class ZycooTaskAddResModel : ZycooTaskTimerModel
    {
        /// <summary>
        /// 标识
        /// </summary>
        public virtual int Id { get; set; }
    }
}
