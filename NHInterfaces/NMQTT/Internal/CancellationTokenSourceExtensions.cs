using System;
using System.Threading;

namespace System.Data.NMQTT
{
    public static class CancellationTokenSourceExtensions
    {
        public static bool TryCancel(this CancellationTokenSource cancellationTokenSource, bool throwOnFirstException = false)
        {
            if (cancellationTokenSource == null)
            {
                return false;
            }

            try
            {
                // Checking the _IsCancellationRequested_ here will not throw an
                // "ObjectDisposedException" as the getter of the property "Token" will do!
                if (cancellationTokenSource.IsCancellationRequested)
                {
                    return false;
                }

                cancellationTokenSource.Cancel(throwOnFirstException);
                return true;
            }
            catch (ObjectDisposedException)
            {
                return false;
            }
        }
    }
}