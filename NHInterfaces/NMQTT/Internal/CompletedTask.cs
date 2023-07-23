using System;
using System.Threading.Tasks;

namespace System.Data.NMQTT
{
    public static class CompletedTask
    {
#if NET452 || NET40 || NET45
        public static readonly Task Instance = TestTry.TaskFromResult(true);
#else
        public static readonly Task Instance = Task.CompletedTask;
#endif
    }
}