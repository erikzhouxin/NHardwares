using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.NModbus
{
    internal static class DisposableUtility
    {
        public static void Dispose<T>(ref T item)
            where T : class, IDisposable
        {
            if (item == null)
            {
                return;
            }

            item.Dispose();
            item = default(T);
        }
    }
    internal static class SequenceUtility
    {
        public static IEnumerable<T> Slice<T>(this IEnumerable<T> source, int startIndex, int size)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var enumerable = source as T[] ?? source.ToArray();
            int num = enumerable.Count();

            if (startIndex < 0 || num < startIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (size < 0 || startIndex + size > num)
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            return enumerable.Skip(startIndex).Take(size);
        }
    }
}
