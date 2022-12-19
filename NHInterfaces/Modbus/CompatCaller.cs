using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.NModbus
{
    internal static class CompatCaller
    {
#if NET40
        public static T[] ToArray<T>(this ArraySegment<T> array)
        {
            if (array == null) { return null; }
            var result = new T[array.Count];
            for (int i = 0; i < array.Count; i++)
            {
                result[i] = array.Array[i];
            }
            return result;
        }
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (TSource item in source)
            {
                foreach (TResult item2 in selector(item))
                {
                    yield return item2;
                }
            }
        }
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this ArraySegment<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (TSource item in source.Array)
            {
                foreach (TResult item2 in selector(item))
                {
                    yield return item2;
                }
            }
        }
        /// <summary>
        /// 轻量级的信号量异步等待
        /// </summary>
        /// <param name="slim"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task WaitAsync(this SemaphoreSlim slim, CancellationToken cancellationToken)
        {
            await Task.Factory.StartNew(() => slim.Wait(), cancellationToken);
        }
        [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
        public static Task<UdpReceiveResult> ReceiveAsync(this UdpClient udpClient)
        {
            return Task<UdpReceiveResult>.Factory.FromAsync((AsyncCallback callback, object state) => udpClient.BeginReceive(callback, state), delegate (IAsyncResult ar)
            {
                IPEndPoint remoteEP = null;
                byte[] buffer = udpClient.EndReceive(ar, ref remoteEP);
                return new UdpReceiveResult(buffer, remoteEP);
            }, null);
        }
#endif
    }
}

#if NET40
namespace System.Net.Sockets
{
    /// <summary>
    /// 
    /// </summary>
    public struct UdpReceiveResult : IEquatable<UdpReceiveResult>
    {
        private byte[] m_buffer;

        private IPEndPoint m_remoteEndPoint;
        /// <summary>
        /// 
        /// </summary>
        public byte[] Buffer => m_buffer;
        /// <summary>
        /// 
        /// </summary>
        public IPEndPoint RemoteEndPoint => m_remoteEndPoint;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="remoteEndPoint"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UdpReceiveResult(byte[] buffer, IPEndPoint remoteEndPoint)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            if (remoteEndPoint == null)
            {
                throw new ArgumentNullException("remoteEndPoint");
            }

            m_buffer = buffer;
            m_remoteEndPoint = remoteEndPoint;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (m_buffer == null)
            {
                return 0;
            }

            return m_buffer.GetHashCode() ^ m_remoteEndPoint.GetHashCode();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is UdpReceiveResult))
            {
                return false;
            }

            return Equals((UdpReceiveResult)obj);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(UdpReceiveResult other)
        {
            if (object.Equals(m_buffer, other.m_buffer))
            {
                return object.Equals(m_remoteEndPoint, other.m_remoteEndPoint);
            }

            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(UdpReceiveResult left, UdpReceiveResult right)
        {
            return left.Equals(right);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(UdpReceiveResult left, UdpReceiveResult right)
        {
            return !left.Equals(right);
        }
    }
}
#endif