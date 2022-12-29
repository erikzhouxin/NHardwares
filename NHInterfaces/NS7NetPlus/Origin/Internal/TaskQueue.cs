using System;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.NS7NetPlus
{
    internal class TaskQueue
    {
        private static readonly object Sentinel = new object();

        private Task prev = TestTry.TaskFromResult(Sentinel);

        public async Task<T> Enqueue<T>(Func<Task<T>> action)
        {
            var tcs = new TaskCompletionSource<object>();
            await Interlocked.Exchange(ref prev, tcs.Task).ConfigureAwait(false);

            try
            {
                return await action.Invoke().ConfigureAwait(false);
            }
            finally
            {
                tcs.SetResult(Sentinel);
            }
        }
    }
}