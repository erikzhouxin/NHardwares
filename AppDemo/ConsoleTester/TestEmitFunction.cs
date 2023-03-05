using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTester
{
    internal class TestEmitFunction
    {
        public TestEmitFunction()
        {

        }
        public static void Test()
        {

        }
        //public static void TestMethodChange()
        //{
        //    var sdk = new System.Data.KangMeiIPGBSDK.IPGBNET.NETfTerminalSta((user, info, target) =>
        //    {

        //    });
        //    ChagneDelegateType(sdk, new Type[] { typeof(int), typeof(System.Data.KangMeiIPGBSDK.IPGBSDK_TMINFO), typeof(long) });
        //}
        //public static Delegate ChagneDelegateType(Delegate src, Type[] tagTypes)
        //{
        //    return new IPGBNET.NETfTerminalSta((user, info, target) =>
        //    {
        //        var srcObjs = ChangeTargetType(new object[] { user, info, target }, tagTypes);
        //        src.DynamicInvoke(srcObjs);
        //    });
        //}
        //private static object[] ChangeTargetType(object[] srcObjs, Type[] tagTypes)
        //{
        //    var res = new object[srcObjs.Length];
        //    for (int i = 0; i < srcObjs.Length; i++)
        //    {
        //        var srcObject = srcObjs[i];
        //        var tagType = tagTypes[i];
        //        Type srcType = srcObject.GetType();
        //        if (srcType.Equals(tagType)) { res[i] = srcObject; continue; }
        //        TinyMapper.Bind(srcType, tagType);
        //        res[i] = TinyMapper.Map(srcType, tagType, srcObject);
        //    }
        //    return res;
        //}
    }
}
