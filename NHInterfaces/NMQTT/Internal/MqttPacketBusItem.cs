using System;
using System.Threading.Tasks;

namespace System.Data.NMQTT
{
    public sealed class MqttPacketBusItem
    {
        readonly AsyncTaskCompletionSource<bool> _promise = new AsyncTaskCompletionSource<bool>();
        
        public MqttPacketBusItem(MqttPacket packet)
        {
            Packet = packet ?? throw new ArgumentNullException(nameof(packet));
        }

        public event EventHandler Completed;

        public MqttPacket Packet { get; }

        public void Cancel()
        {
            _promise.TrySetCanceled();
        }

        public void Complete()
        {
            _promise.TrySetResult(true);
            Completed?.Invoke(this, EventArgs.Empty);
        }

        public void Fail(Exception exception)
        {
            _promise.TrySetException(exception);
        }

        public Task WaitAsync()
        {
            return _promise.Task;
        }
    }
}