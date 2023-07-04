using System;
using System.Collections.Generic;
using System.Data.NS7NET;

namespace ZycooSIPNetSDK.CmdConsole
{
    internal class Program
    {
        public static Dictionary<string, IConsoleCli> Register { get; } = new Dictionary<string, IConsoleCli>(StringComparer.OrdinalIgnoreCase)
        {
            { nameof(ZycooSIPNetSDK), ZycooSIPNetSpeaker.Instance },
            { "Zycoo", ZycooSIPNetSpeaker.Instance },
            { "SIP", ZycooSIPNetSpeaker.Instance },
            { "SIPNet", ZycooSIPNetSpeaker.Instance },
        };
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("请输入所需要的的功能码：");
                foreach (var item in Register)
                {
                    Console.WriteLine("{0}=> {1}", item.Key.PadRight(30, ' '), item.Value.Name);
                }
                var key = Console.ReadLine() ?? string.Empty;
                if (Register.TryGetValue(key, out var cmd))
                {
                    Console.WriteLine(cmd.Welcome);
                    Console.WriteLine(cmd.Readme);
                    cmd.Start();
                    continue;
                }
                if (!string.IsNullOrEmpty(key))
                {
                    Console.WriteLine($"无效的功能码【{key}】");
                    continue;
                }
                return;
            }
            while (true);
        }
    }
}
