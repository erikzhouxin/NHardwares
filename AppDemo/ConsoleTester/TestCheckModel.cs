using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Data.Extter;
using System.Data.RecBarCodeModule;
using System.Text;

namespace ConsoleTester
{
    internal class TestCheckModel
    {
        internal static void Test()
        {
            var list = new List<string>
            {
                "$010000-525C",
                "$010001-616D",
                "$010100-24E8",
                "$010101-17D9",
                "$010200-BF34",
                "$010207-26A3",
                "$010208-369D",
                "$010300-C980",
                "$0103A0-26B8",
                "$010204-73F0",
                "$010205-40C1",
                "$010500-EE19",
                "$020003-C9EF",
                "$020E01-51BD",
                "$020E00-628C",
                "$020503-75AA",
                "$020504-EC3D",
                "$020505-DF0C",
                "$020506-8A5F",
                "$020507-B96E",
                "$020508-A950",
                "$020509-9A61",
                "$020000-9CBC",
                "$020A00-A87D",
                "$020A02-CE1F",
                "$020700-CD91",
                "$020701-FEA0",
                "$020703-98C2",
                "$020705-3264",
                "$02070A-F6F9",
                "$020714-3665",
                "$02071E-0D0D",
                "$020732-F2A3",
                "$020900-6FCB",
                "$020901-5CFA",
            };
            foreach (var item in list)
            {
                var key = item.Substring(0, item.Length - 4);
                var value = item.Substring(item.Length - 4);
                var check = RecBarCodeSdk.XModemShort(key.GetASCIIBytes()).GetBytes().GetHexString();
                Console.WriteLine($"{item}    =>    {check == value}");
            }
        }
    }
}
