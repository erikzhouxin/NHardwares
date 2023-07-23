using System;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.NMQTT
{
    public sealed class AsyncTaskCompletionSource<TResult>
    {
        readonly TaskCompletionSource<TResult> _taskCompletionSource;

        public AsyncTaskCompletionSource()
        {
#if NET452 || NET40 || NET45
            _taskCompletionSource = new TaskCompletionSource<TResult>();
#else
            _taskCompletionSource = new TaskCompletionSource<TResult>(TaskCreationOptions.RunContinuationsAsynchronously);
#endif
        }

        public Task<TResult> Task => _taskCompletionSource.Task;

        public void TrySetCanceled()
        {
#if NET452 || NET40 || NET45
            // To prevent deadlocks it is required to call the _TrySetCanceled_ method
            // from a new thread because the awaiting code will not(!) be executed in
            // a new thread automatically (due to await). Furthermore _this_ thread will
            // do it. But _this_ thread is also reading incoming packets -> deadlock.
            // NET452 does not support RunContinuationsAsynchronously
            TestTry.TaskRun(() => _taskCompletionSource.TrySetCanceled());
            SpinWait.SpinUntil(() => _taskCompletionSource.Task.IsCompleted);
#else
            _taskCompletionSource.TrySetCanceled();
#endif
        }

        public void TrySetException(Exception exception)
        {
#if NET452 || NET40 || NET45
            // To prevent deadlocks it is required to call the _TrySetException_ method
            // from a new thread because the awaiting code will not(!) be executed in
            // a new thread automatically (due to await). Furthermore _this_ thread will
            // do it. But _this_ thread is also reading incoming packets -> deadlock.
            // NET452 does not support RunContinuationsAsynchronously
            TestTry.TaskRun(() => _taskCompletionSource.TrySetException(exception));
            SpinWait.SpinUntil(() => _taskCompletionSource.Task.IsCompleted);
#else
            _taskCompletionSource.TrySetException(exception);
#endif
        }

        public bool TrySetResult(TResult result)
        {
#if NET452 || NET40 || NET45
            // To prevent deadlocks it is required to call the _TrySetResult_ method
            // from a new thread because the awaiting code will not(!) be executed in
            // a new thread automatically (due to await). Furthermore _this_ thread will
            // do it. But _this_ thread is also reading incoming packets -> deadlock.
            // NET452 does not support RunContinuationsAsynchronously
            if (_taskCompletionSource.Task.IsCompleted)
            {
                return false;
            }

            TestTry.TaskRun(() => _taskCompletionSource.TrySetResult(result));
            SpinWait.SpinUntil(() => _taskCompletionSource.Task.IsCompleted);

            return true;
#else
            return _taskCompletionSource.TrySetResult(result);
#endif
        }
    }
}