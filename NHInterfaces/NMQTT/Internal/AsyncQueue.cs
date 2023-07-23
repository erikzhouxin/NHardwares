using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.NMQTT
{
    public sealed class AsyncQueue<TItem> : IDisposable
    {
        readonly AsyncSignal _signal = new AsyncSignal();
        readonly object _syncRoot = new object();

        ConcurrentQueue<TItem> _queue = new ConcurrentQueue<TItem>();

        bool _isDisposed;
        
        public int Count => _queue.Count;

        public void Clear()
        {
            Interlocked.Exchange(ref _queue, new ConcurrentQueue<TItem>());
        }

        public void Dispose()
        {
            lock (_syncRoot)
            {
                _signal.Dispose();

                _isDisposed = true;
            }
        }

        public void Enqueue(TItem item)
        {
            lock (_syncRoot)
            {
                _queue.Enqueue(item);
                _signal.Set();
            }
        }

        public AsyncQueueDequeueResult<TItem> TryDequeue()
        {
            if (_queue.TryDequeue(out var item))
            {
                return AsyncQueueDequeueResult<TItem>.Success(item);
            }

            return AsyncQueueDequeueResult<TItem>.NonSuccess;
        }

        public async Task<AsyncQueueDequeueResult<TItem>> TryDequeueAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    Task task = null;
                    lock (_syncRoot)
                    {
                        if (_isDisposed)
                        {
                            return AsyncQueueDequeueResult<TItem>.NonSuccess;
                        }

                        if (_queue.IsEmpty)
                        {
                            task = _signal.WaitAsync(cancellationToken);
                        }
                    }

                    if (task != null)
                    {
                        await task.ConfigureAwait(false);    
                    }
                    
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return AsyncQueueDequeueResult<TItem>.NonSuccess;
                    }

                    if (_queue.TryDequeue(out var item))
                    {
                        return AsyncQueueDequeueResult<TItem>.Success(item);
                    }
                }
                catch (OperationCanceledException)
                {
                    return AsyncQueueDequeueResult<TItem>.NonSuccess;
                }
            }

            return AsyncQueueDequeueResult<TItem>.NonSuccess;
        }
    }
}