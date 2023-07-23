using System;
using System.Runtime.CompilerServices;

namespace System.Data.NMQTT
{
    public static class MqttMemoryHelper
    {
#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void Copy(byte[] source, int sourceIndex, byte[] destination, int destinationIndex, int length)
        {
#if NETCOREAPP3_1_OR_GREATER || NETSTANDARD2_1
            source.AsSpan(sourceIndex, length).CopyTo(destination.AsSpan(destinationIndex, length));
#elif NET461_OR_GREATER || NETSTANDARD1_3_OR_GREATER
            unsafe
            {
                fixed (byte* sourceHandle = &source[sourceIndex])
                {
                    fixed (byte* destinationHandle = &destination[destinationIndex])
                    {
                        System.Buffer.MemoryCopy(sourceHandle, destinationHandle, length, length);
                    }
                }
            }
#else
            Array.Copy(source, sourceIndex, destination, destinationIndex, length);
#endif
        }
    }
}
