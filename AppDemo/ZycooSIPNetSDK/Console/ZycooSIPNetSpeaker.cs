using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Data.ZycooSIPNetSDK;
using System.Reflection;
using System.Text;

namespace ZycooSIPNetSDK.CmdConsole
{
    internal class ZycooSIPNetSpeaker : ConsoleCli
    {
        /// <summary>
        /// 实例
        /// </summary>
        public static ZycooSIPNetSpeaker Instance = new ZycooSIPNetSpeaker();
        IZycooSIPNetApiProxyV1 _proxy;
        public ZycooSIPNetSpeaker()
        {
            Name = "智科通信语音对讲广播系统";
            Welcome = $"欢迎使用测试命令行测试{Name}";
            Readme = "1:设置参数set\n2:登录功能login\n3:操作内容\n4:help获取帮助";
            _proxy = ZycooSIPNetSdk.Create();
        }
        /// <inheritdoc />
        public override void Start()
        {
            var cmdList = new Dictionary<string, Func<string, string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "set", SetProperty },
                { "config", SetProperty },
                { "center", SetProperty },
                { nameof(_proxy.Login), Login },
                { nameof(_proxy.AccountAdd), AccountAdd },
                { nameof(_proxy.AccountDelete), AccountDelete },
                { nameof(_proxy.AccountEdit), AccountEdit },
                { nameof(_proxy.AccountSearch), AccountSearch },
                { nameof(_proxy.BroadcastDevice), BroadcastDevice },
                { nameof(_proxy.BroadcastPlay), BroadcastPlay },
                { nameof(_proxy.BroadcastSearch), BroadcastSearch },
                { nameof(_proxy.ConferenceAdd), ConferenceAdd },
                { nameof(_proxy.ConferenceInfo), ConferenceInfo },
                { nameof(_proxy.ConferenceLock), ConferenceLock },
                { nameof(_proxy.ConferenceMute), ConferenceMute },
                { nameof(_proxy.ConferenceRemove), ConferenceRemove },
                { nameof(_proxy.ConferenceSearch), ConferenceSearch },
                { nameof(_proxy.ConferenceUnlock), ConferenceUnlock },
                { nameof(_proxy.ConferenceUnmute), ConferenceUnmute },
                { nameof(_proxy.ConfigActive), ConfigActive },
                { nameof(_proxy.DeviceAdd), DeviceAdd },
                { nameof(_proxy.DeviceDelete), DeviceDelete },
                { nameof(_proxy.DeviceEdit), DeviceEdit },
                { nameof(_proxy.DeviceSearch), DeviceSearch },
                { nameof(_proxy.GroupAdd), GroupAdd },
                { nameof(_proxy.GroupDelete), GroupDelete },
                { nameof(_proxy.GroupEdit), GroupEdit },
                { nameof(_proxy.GroupSearch), GroupSearch },
                { nameof(_proxy.MusicDelete), MusicDelete },
                { nameof(_proxy.MusicSearch), MusicSearch },
                { nameof(_proxy.MusicUpload), MusicUpload },
                { nameof(_proxy.PhoneBargeIn), PhoneBargeIn },
                { nameof(_proxy.PhoneBargeOut), PhoneBargeOut },
                { nameof(_proxy.PhoneCalls), PhoneCalls },
                { nameof(_proxy.PhoneDialog), PhoneDialog },
                { nameof(_proxy.PhoneEmergency), PhoneEmergency },
                { nameof(_proxy.PhoneHangup), PhoneHangup },
                { nameof(_proxy.PhoneHintStatus), PhoneHintStatus },
                { nameof(_proxy.PhoneIntercom), PhoneIntercom },
                { nameof(_proxy.PhoneRegStatus), PhoneRegStatus },
                { nameof(_proxy.PhoneSpy), PhoneSpy },
                { nameof(_proxy.PhoneTransfer), PhoneTransfer },
                { nameof(_proxy.PhoneWhisper), PhoneWhisper },
                { nameof(_proxy.PlayAdd), PlayAdd },
                { nameof(_proxy.PlayDelete), PlayDelete },
                { nameof(_proxy.PlayEdit), PlayEdit },
                { nameof(_proxy.PlaySearch), PlaySearch },
                { nameof(_proxy.PushPhoneCallLog), PushPhoneCallLog },
                { nameof(_proxy.PushPhoneEnd), PushPhoneEnd },
                { nameof(_proxy.PushPhoneSpeakLog), PushPhoneSpeakLog },
                { nameof(_proxy.PushPhoneStart), PushPhoneStart },
                { nameof(_proxy.PushPhoneStatus), PushPhoneStatus },
                { nameof(_proxy.PushPhoneStop), PushPhoneStop },
                { nameof(_proxy.PushPhoneTalkLog), PushPhoneTalkLog },
                { nameof(_proxy.SetPushUrl), SetPushUrl },
                { nameof(_proxy.SystemHandle), SystemHandle },
                { nameof(_proxy.SystemInfo), SystemInfo },
                { nameof(_proxy.SystemPing), SystemPing },
                { nameof(_proxy.TaskAdd), TaskAdd },
                { nameof(_proxy.TaskDelete), TaskDelete },
                { nameof(_proxy.TaskEdit), TaskEdit },
                { nameof(_proxy.TaskLogSearch), TaskLogSearch },
                { nameof(_proxy.TaskLoopMode), TaskLoopMode },
                { nameof(_proxy.TaskPhone), TaskPhone },
                { nameof(_proxy.TaskSearch), TaskSearch },
                { nameof(_proxy.TaskToday), TaskToday },
                { nameof(_proxy.TTSAdd), TTSAdd },
                { nameof(_proxy.TTSPlay), TTSPlay },
                { nameof(_proxy.UserAdd), UserAdd },
                { nameof(_proxy.UserDelete), UserDelete },
                { nameof(_proxy.UserEdit), UserEdit },
                { nameof(_proxy.UserSearch), UserSearch },
                { nameof(_proxy.WaveUpload), WaveUpload },
            };
            try
            {
                do
                {
                    var key = Console.ReadLine();
                    if (string.IsNullOrEmpty(key)) { break; }
                    if (cmdList.TryGetValue(key, out var cmd))
                    {
                        try
                        {
                            Console.WriteLine($"请输入执行{cmd.GetMethodInfo()}参数，如果没有参数请按回车");
                            Console.WriteLine(cmd.Invoke(Console.ReadLine()));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                } while (true);
            }
            catch { }
        }
        private string SetProperty(string key)
        {
            do
            {
                try
                {
                    var center = _proxy.Center;
                    var access = PropertyAccess.GetAccess(center);
                    var ix = key.IndexOf(' ');
                    string property = key.Substring(0, ix);
                    string value = key.Substring(++ix);
                    foreach (var item in access.FuncInfoDic)
                    {
                        if (item.Key.Equals(property, StringComparison.OrdinalIgnoreCase))
                        {
                            try
                            {
                                if (value == "null") { item.Value.SetValue(center, value); }
                                else { item.Value.SetValue(center, value.GetJsonObject(item.Value.PropertyInfo.PropertyType)); }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"设置属性{property}的值[{value}]错误\n{ex.Message}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"设置格式错误，应该是【[属性] [值]】\n{ex.Message}");
                }
                key = Console.ReadLine();
                if (string.IsNullOrEmpty(key)) { break; }
            } while (true);
            return _proxy.Center.GetJsonFormatString();
        }
        private static T GetArgs<T>(string key)
        {
            if (key.StartsWith("f:", StringComparison.OrdinalIgnoreCase)) // 文件Json内容
            {
                var value = System.IO.File.ReadAllText(System.IO.Path.GetFullPath(key.Substring(2)));
                return value.GetJsonObject<T>();
            }
            if (key.StartsWith("fi:", StringComparison.OrdinalIgnoreCase)) // 文件Json数组中的序号
            {
                var fi = key.Substring(3);
                var sp = fi.IndexOf(':');
                var ix = fi.Substring(0, sp).ToCInt32();
                var value = System.IO.File.ReadAllText(System.IO.Path.GetFullPath(fi.Substring(sp + 1)));
                var jarray = JArray.Parse(value);
                var jval = jarray[ix];
                return jval.ToObject<T>();
            }
            if (key.StartsWith("fm:", StringComparison.OrdinalIgnoreCase))
            {
                var fi = key.Substring(3);
                var sp = fi.IndexOf(':');
                var ix = fi.Substring(0, sp);
                var value = System.IO.File.ReadAllText(System.IO.Path.GetFullPath(fi.Substring(sp + 1)));
                var jarray = JObject.Parse(value);
                var jval = jarray[ix];
                return jval.ToObject<T>();
            }
            if (key == "null") { return default; }
            return key.GetJsonObject<T>();
        }
        #region // 方法代理
        private string AccountAdd(string key)
        {
            var args = GetArgs<ZycooAccountModel>(key);
            return _proxy.AccountAdd(args).GetJsonFormatString();
        }

        private string AccountDelete(string key)
        {
            var args = GetArgs<ZycooAccountModel>(key);
            return _proxy.AccountDelete(args).GetJsonFormatString();
        }
        private string AccountEdit(string key)
        {
            var args = GetArgs<ZycooAccountModel>(key);
            return _proxy.AccountEdit(args).GetJsonFormatString();
        }
        private string AccountSearch(string key)
        {
            var args = GetArgs<(int Limit, int Page, String FilterInfo)>(key);
            return _proxy.AccountSearch(args.Limit, args.Page, args.FilterInfo).GetJsonFormatString();
        }
        private string BroadcastDevice(string key)
        {
            var args = GetArgs<ZycooBroadcastDeviceModel>(key);
            return _proxy.BroadcastDevice(args).GetJsonFormatString();
        }
        private string BroadcastPlay(string key)
        {
            var args = GetArgs<ZycooBroadcastPlayModel>(key);
            return _proxy.BroadcastPlay(args).GetJsonFormatString();
        }
        private string BroadcastSearch(string key)
        {
            return _proxy.BroadcastSearch().GetJsonFormatString();
        }
        private string ConferenceAdd(string key)
        {
            var args = GetArgs<(string ConfNum, string Extensions)>(key);
            return _proxy.ConferenceAdd(args.ConfNum, args.Extensions).GetJsonFormatString();
        }
        private string ConferenceInfo(string key)
        {
            var args = GetArgs<string>(key);
            return _proxy.ConferenceInfo(args).GetJsonFormatString();
        }
        private string ConferenceLock(string key)
        {
            var args = GetArgs<string>(key);
            return _proxy.ConferenceLock(args).GetJsonFormatString();
        }
        private string ConferenceMute(string key)
        {
            var args = GetArgs<(string ConfNum, String Channel)>(key);
            return _proxy.ConferenceMute(args.ConfNum, args.Channel).GetJsonFormatString();
        }
        private string ConferenceRemove(string key)
        {
            var args = GetArgs<(string ConfNum, String Channel)>(key);
            return _proxy.ConferenceRemove(args.ConfNum, args.Channel).GetJsonFormatString();
        }
        private string ConferenceSearch(string key)
        {
            return _proxy.ConferenceSearch().GetJsonFormatString();
        }
        private string ConferenceUnlock(string key)
        {
            var args = GetArgs<string>(key);
            return _proxy.ConferenceUnlock(args).GetJsonFormatString();
        }
        private string ConferenceUnmute(string key)
        {
            var args = GetArgs<(string ConfNum, String Channel)>(key);
            return _proxy.ConferenceUnmute(args.ConfNum, args.Channel).GetJsonFormatString();
        }
        private string ConfigActive(string key)
        {
            return _proxy.ConfigActive().GetJsonFormatString();
        }
        private string DeviceAdd(string key)
        {
            var args = GetArgs<ZycooDeviceModel>(key);
            return _proxy.DeviceAdd(args).GetJsonFormatString();
        }
        private string DeviceDelete(string key)
        {
            var args = GetArgs<ZycooDeviceModel>(key);
            return _proxy.DeviceDelete(args).GetJsonFormatString();
        }
        private string DeviceEdit(string key)
        {
            var args = GetArgs<ZycooDeviceModel>(key);
            return _proxy.DeviceEdit(args).GetJsonFormatString();
        }
        private string DeviceSearch(string key)
        {
            var args = GetArgs<(int Limit, int Page, String FilterInfo)>(key);
            return _proxy.DeviceSearch(args.Limit, args.Page, args.FilterInfo).GetJsonFormatString();
        }
        private string GroupAdd(string key)
        {
            var args = GetArgs<ZycooGroupModel>(key);
            return _proxy.GroupAdd(args).GetJsonFormatString();
        }
        private string GroupDelete(string key)
        {
            var args = GetArgs<ZycooGroupModel>(key);
            return _proxy.GroupDelete(args).GetJsonFormatString();
        }
        private string GroupEdit(string key)
        {
            var args = GetArgs<ZycooGroupModel>(key);
            return _proxy.GroupEdit(args).GetJsonFormatString();
        }
        private string GroupSearch(string key)
        {
            var args = GetArgs<(int Limit, int Page, String FilterInfo)>(key);
            return _proxy.GroupSearch(args.Limit, args.Page, args.FilterInfo).GetJsonFormatString();
        }
        private string Login(string key)
        {
            return _proxy.Login().GetJsonFormatString();
        }
        private string MusicDelete(string key)
        {
            if (key.Contains(','))
            {
                if (!key.StartsWith("[")) { key = $"[{key}]"; }
                var ids = GetArgs<int[]>(key);
                return _proxy.MusicDelete(ids).GetJsonFormatString();
            }
            var args = GetArgs<int>(key);
            return _proxy.MusicDelete(args).GetJsonFormatString();
        }
        private string MusicSearch(string key)
        {
            var args = GetArgs<(int Limit, int Page, String FilterInfo)>(key);
            return _proxy.MusicSearch(args.Limit, args.Page, args.FilterInfo).GetJsonFormatString();
        }
        private string MusicUpload(string key)
        {
            var args = GetArgs<(string File, String Type)>(key);
            return _proxy.MusicUpload(args.File, args.Type).GetJsonFormatString();
        }
        private string PhoneBargeIn(string key)
        {
            var args = GetArgs<ZycooPhoneBargeInModel>(key);
            return _proxy.PhoneBargeIn(args).GetJsonFormatString();
        }
        private string PhoneBargeOut(string key)
        {
            var args = GetArgs<ZycooPhoneBargeOutModel>(key);
            return _proxy.PhoneBargeOut(args).GetJsonFormatString();
        }
        private string PhoneCalls(string key)
        {
            return _proxy.PhoneCalls().GetJsonFormatString();
        }
        private string PhoneDialog(string key)
        {
            var args = GetArgs<ZycooPhoneDialogModel>(key);
            return _proxy.PhoneDialog(args).GetJsonFormatString();
        }
        private string PhoneEmergency(string key)
        {
            var args = GetArgs<ZycooPhoneEmergencyModel>(key);
            return _proxy.PhoneEmergency(args).GetJsonFormatString();
        }
        private string PhoneHangup(string key)
        {
            var args = GetArgs<string>(key);
            return _proxy.PhoneHangup(args).GetJsonFormatString();
        }
        private string PhoneHintStatus(string key)
        {
            return _proxy.PhoneHintStatus().GetJsonFormatString();
        }
        private string PhoneIntercom(string key)
        {
            var args = GetArgs<ZycooPhoneIntercomModel>(key);
            return _proxy.PhoneIntercom(args).GetJsonFormatString();
        }
        private string PhoneRegStatus(string key)
        {
            return _proxy.PhoneRegStatus().GetJsonFormatString();
        }
        private string PhoneSpy(string key)
        {
            var args = GetArgs<ZycooPhoneSpyModel>(key);
            return _proxy.PhoneSpy(args).GetJsonFormatString();
        }
        private string PhoneTransfer(string key)
        {
            var args = GetArgs<ZycooPhoneTransferModel>(key);
            return _proxy.PhoneTransfer(args).GetJsonFormatString();
        }
        private string PhoneWhisper(string key)
        {
            var args = GetArgs<ZycooPhoneWhisperModel>(key);
            return _proxy.PhoneWhisper(args).GetJsonFormatString();
        }
        private string PlayAdd(string key)
        {
            var args = GetArgs<ZycooPlayAddModel>(key);
            return _proxy.PlayAdd(args).GetJsonFormatString();
        }
        private string PlayDelete(string key)
        {
            var args = GetArgs<int>(key);
            return _proxy.PlayDelete(args).GetJsonFormatString();
        }
        private string PlayEdit(string key)
        {
            var args = GetArgs<ZycooPlayEditModel>(key);
            return _proxy.PlayEdit(args).GetJsonFormatString();
        }
        private string PlaySearch(string key)
        {
            var args = GetArgs<(int Limit, int Page, string Type)>(key);
            return _proxy.PlaySearch(args.Limit, args.Page, args.Type).GetJsonFormatString();
        }
        private string PushPhoneCallLog(string key)
        {
            return _proxy.PushPhoneCallLog().GetJsonFormatString();
        }
        private string PushPhoneEnd(string key)
        {
            return _proxy.PushPhoneEnd().GetJsonFormatString();
        }
        private string PushPhoneSpeakLog(string key)
        {
            return _proxy.PushPhoneSpeakLog().GetJsonFormatString();
        }
        private string PushPhoneStart(string key)
        {
            return _proxy.PushPhoneStart().GetJsonFormatString();
        }
        private string PushPhoneStatus(string key)
        {
            return _proxy.PushPhoneStatus().GetJsonFormatString();
        }
        private string PushPhoneStop(string key)
        {
            return _proxy.PushPhoneStop().GetJsonFormatString();
        }
        private string PushPhoneTalkLog(string key)
        {
            return _proxy.PushPhoneTalkLog().GetJsonFormatString();
        }
        private string SetPushUrl(string key)
        {
            var args = GetArgs<string>(key);
            return _proxy.SetPushUrl(args).GetJsonFormatString();
        }
        private string SystemHandle(string key)
        {
            return _proxy.SystemHandle().GetJsonFormatString();
        }
        private string SystemInfo(string key)
        {
            return _proxy.SystemInfo().GetJsonFormatString();
        }
        private string SystemPing(string key)
        {
            return _proxy.SystemPing().GetJsonFormatString();
        }
        private string TaskAdd(string key)
        {
            var type = GetArgs<int>(key);
            if (type == 0)
            {
                var timer = GetArgs<ZycooTaskTimerModel>(Console.ReadLine());
                return _proxy.TaskAdd(timer).GetJsonFormatString();
            }
            var args = GetArgs<ZycooTaskAddModel>(key);
            return _proxy.TaskAdd(args).GetJsonFormatString();
        }
        private string TaskDelete(string key)
        {
            var args = GetArgs<int>(key);
            return _proxy.TaskDelete(args).GetJsonFormatString();
        }
        private string TaskEdit(string key)
        {
            var args = GetArgs<ZycooTaskEditModel>(key);
            return _proxy.TaskEdit(args).GetJsonFormatString();
        }
        private string TaskLogSearch(string key)
        {
            var args = GetArgs<(int Limit, int Page)>(key);
            return _proxy.TaskLogSearch(args.Limit, args.Page).GetJsonFormatString();
        }
        private string TaskLoopMode(string key)
        {
            var args = GetArgs<int>(key);
            if (args == 0)
            {
                var m1 = GetArgs<ZycooTaskLoopM1Model>(Console.ReadLine());
                return _proxy.TaskLoopMode(m1).GetJsonFormatString();
            }
            var m2 = GetArgs<ZycooTaskLoopM2Model>(Console.ReadLine());
            return _proxy.TaskLoopMode(m2).GetJsonFormatString();
        }
        private string TaskPhone(string key)
        {
            var args = GetArgs<ZycooTaskPhoneModel>(key);
            return _proxy.TaskPhone(args).GetJsonFormatString();
        }
        private string TaskSearch(string key)
        {
            var args = GetArgs<(int Limit, int Page, String Name, String Type, String SoundType)>(key);
            return _proxy.TaskSearch(args.Limit, args.Page, args.Name, args.Type, args.SoundType).GetJsonFormatString();
        }
        private string TaskToday(string key)
        {
            return _proxy.TaskToday().GetJsonFormatString();
        }
        private string TTSAdd(string key)
        {
            var args = GetArgs<ZycooTTSAddModel>(key);
            return _proxy.TTSAdd(args).GetJsonFormatString();
        }
        private string TTSPlay(string key)
        {
            var args = GetArgs<ZycooTTSPlayModel>(key);
            return _proxy.TTSPlay(args).GetJsonFormatString();
        }
        private string UserAdd(string key)
        {
            var args = GetArgs<ZycooUserModel>(key);
            return _proxy.UserAdd(args).GetJsonFormatString();
        }
        private string UserDelete(string key)
        {
            var args = GetArgs<ZycooUserModel>(key);
            return _proxy.UserDelete(args).GetJsonFormatString();
        }
        private string UserEdit(string key)
        {
            var args = GetArgs<ZycooUserModel>(key);
            return _proxy.UserEdit(args).GetJsonFormatString();
        }
        private string UserSearch(string key)
        {
            var args = GetArgs<(int Limit, int Page, string FilterInfo)>(key);
            return _proxy.UserSearch(args.Limit, args.Page, args.FilterInfo).GetJsonFormatString();
        }
        private string WaveUpload(string key)
        {
            var args = GetArgs<(string File, String Type)>(key);
            return _proxy.WaveUpload(args.File, args.Type).GetJsonFormatString();
        }
        #endregion 方法代理
    }
}
