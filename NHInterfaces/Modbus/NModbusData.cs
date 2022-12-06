using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace System.Data.NModbus
{
    public class SlaveDataStore : ISlaveDataStore
    {
        public PointSource<ushort> HoldingRegisters { get; } = new PointSource<ushort>();

        public PointSource<ushort> InputRegisters { get; } = new PointSource<ushort>();

        public PointSource<bool> CoilDiscretes { get; } = new PointSource<bool>();

        public PointSource<bool> CoilInputs { get; } = new PointSource<bool>();

        #region ISlaveDataStore

        IPointSource<ushort> ISlaveDataStore.HoldingRegisters => HoldingRegisters;

        IPointSource<ushort> ISlaveDataStore.InputRegisters => InputRegisters;

        IPointSource<bool> ISlaveDataStore.CoilDiscretes => CoilDiscretes;

        IPointSource<bool> ISlaveDataStore.CoilInputs => CoilInputs;

        #endregion
    }
    /// <summary>
    ///     Collection of 16 bit registers.
    /// </summary>
    public class RegisterCollection : Collection<ushort>, IModbusMessageDataCollection
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterCollection" /> class.
        /// </summary>
        public RegisterCollection()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterCollection" /> class.
        /// </summary>
        /// <param name="bytes">Array for register collection.</param>
        public RegisterCollection(byte[] bytes)
            : this((IList<ushort>)ModbusUtility.NetworkBytesToHostUInt16(bytes))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterCollection" /> class.
        /// </summary>
        /// <param name="registers">Array for register collection.</param>
        public RegisterCollection(params ushort[] registers)
            : this((IList<ushort>)registers)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterCollection" /> class.
        /// </summary>
        /// <param name="registers">List for register collection.</param>
        public RegisterCollection(IList<ushort> registers)
            : base(registers.IsReadOnly ? new List<ushort>(registers) : registers)
        {
        }

        public byte[] NetworkBytes
        {
            get
            {
                var bytes = new MemoryStream(ByteCount);

                foreach (ushort register in this)
                {
                    var b = BitConverter.GetBytes((ushort)IPAddress.HostToNetworkOrder((short)register));
                    bytes.Write(b, 0, b.Length);
                }

                return bytes.ToArray();
            }
        }

        /// <summary>
        ///     Gets the byte count.
        /// </summary>
        public byte ByteCount => (byte)(Count * 2);

        /// <summary>
        ///     Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </returns>
        public override string ToString()
        {
            return string.Concat("{", string.Join(", ", this.Select(v => v.ToString()).ToArray()), "}");
        }
    }
    /// <summary>
    /// A simple implementation of the point source. Memory for all points is allocated the first time a point is accessed. 
    /// This is useful for cases where many points are used.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PointSource<T> : IPointSource<T> where T : struct
    {
        public event EventHandler<PointEventArgs> BeforeRead;

        public event EventHandler<PointEventArgs<T>> BeforeWrite;

        public event EventHandler<PointEventArgs> AfterWrite;

        //Only create this if referenced.
        private readonly Lazy<T[]> _points;

        private readonly object _syncRoot = new object();

        private const int NumberOfPoints = ushort.MaxValue + 1;

        public PointSource()
        {
            _points = new Lazy<T[]>(() => new T[NumberOfPoints]);
        }

        public T[] ReadPoints(ushort startAddress, ushort numberOfPoints)
        {
            lock (_syncRoot)
            {
                return _points.Value
                    .Slice(startAddress, numberOfPoints)
                    .ToArray();
            }
        }

        T[] IPointSource<T>.ReadPoints(ushort startAddress, ushort numberOfPoints)
        {
            BeforeRead?.Invoke(this, new PointEventArgs(startAddress, numberOfPoints));
            return ReadPoints(startAddress, numberOfPoints);
        }

        public void WritePoints(ushort startAddress, T[] points)
        {
            lock (_syncRoot)
            {
                for (ushort index = 0; index < points.Length; index++)
                {
                    _points.Value[startAddress + index] = points[index];
                }
            }
        }

        void IPointSource<T>.WritePoints(ushort startAddress, T[] points)
        {
            BeforeWrite?.Invoke(this, new PointEventArgs<T>(startAddress, points));
            WritePoints(startAddress, points);
            AfterWrite?.Invoke(this, new PointEventArgs(startAddress, (ushort)points.Length));
        }
    }
    /// <summary>
    ///     Modbus message containing data.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
    public interface IModbusMessageDataCollection
    {
        /// <summary>
        ///     Gets the network bytes.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        byte[] NetworkBytes { get; }

        /// <summary>
        ///     Gets the byte count.
        /// </summary>
        byte ByteCount { get; }
    }
    internal class FileRecordCollection : IModbusMessageDataCollection
    {
        private IReadOnlyList<byte> networkBytes;
        private IReadOnlyList<byte> dataBytes;

        public FileRecordCollection(ushort fileNumber, ushort startingAddress, byte[] data)
        {
            Build(fileNumber, startingAddress, data);
            FileNumber = fileNumber;
            StartingAddress = startingAddress;
        }

        public FileRecordCollection(byte[] messageFrame)
        {
            var fileNumber = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(messageFrame, 4));
            var startingAdress = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(messageFrame, 6));
            var count = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(messageFrame, 8));
            var data = messageFrame.Slice(10, count * 2).ToArray();

            Build(fileNumber, startingAdress, data);
            FileNumber = fileNumber;
            StartingAddress = startingAdress;
        }

        private void Build(ushort fileNumber, ushort startingAddress, byte[] data)
        {
            if (data.Length % 2 != 0)
            {
                throw new FormatException("Number of bytes has to be even");
            }

            var values = new List<byte>
            {
                6, // Reference type, demanded by standard definition
            };

            void addAsBytes(int value)
            {
                values.AddRange(BitConverter.GetBytes((ushort)IPAddress.HostToNetworkOrder((short)value)));
            }

            addAsBytes(fileNumber);
            addAsBytes(startingAddress);
            addAsBytes(data.Length / 2);

            values.AddRange(data);

#if NET40
            dataBytes = new EReadOnlyCollection<byte>(data);
            networkBytes = new EReadOnlyCollection<byte>(values);
#else
            dataBytes = data;
            networkBytes = values;
#endif
        }

        /// <summary>
        /// The Extended Memory file number
        /// </summary>
        public ushort FileNumber { get; }

        /// <summary>
        /// The starting register address within the file.
        /// </summary>
        public ushort StartingAddress { get; }

        /// <summary>
        ///  The bytes written to the extended memory file.
        /// </summary>
        public IReadOnlyList<byte> DataBytes => dataBytes;

        public byte[] NetworkBytes => networkBytes.ToArray();

        /// <summary>
        ///     Gets the byte count.
        /// </summary>
        public byte ByteCount => (byte)networkBytes.Count;

        /// <summary>
        ///     Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </returns>
        public override string ToString()
        {
            return string.Concat("{", string.Join(", ", this.networkBytes.Select(v => v.ToString()).ToArray()), "}");
        }
    }
    /// <summary>
    ///     Collection of discrete values.
    /// </summary>
    internal class DiscreteCollection : Collection<bool>, IModbusMessageDataCollection
    {
        /// <summary>
        ///     Number of bits per byte.
        /// </summary>
        private const int BitsPerByte = 8;
        private readonly List<bool> _discretes;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DiscreteCollection" /> class.
        /// </summary>
        public DiscreteCollection()
            : this(new List<bool>())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DiscreteCollection" /> class.
        /// </summary>
        /// <param name="bits">Array for discrete collection.</param>
        public DiscreteCollection(params bool[] bits)
            : this((IList<bool>)bits)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DiscreteCollection" /> class.
        /// </summary>
        /// <param name="bytes">Array for discrete collection.</param>
        public DiscreteCollection(params byte[] bytes)
            : this()
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            _discretes.Capacity = bytes.Length * BitsPerByte;

            foreach (byte b in bytes)
            {
                _discretes.Add((b & 1) == 1);
                _discretes.Add((b & 2) == 2);
                _discretes.Add((b & 4) == 4);
                _discretes.Add((b & 8) == 8);
                _discretes.Add((b & 16) == 16);
                _discretes.Add((b & 32) == 32);
                _discretes.Add((b & 64) == 64);
                _discretes.Add((b & 128) == 128);
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DiscreteCollection" /> class.
        /// </summary>
        /// <param name="bits">List for discrete collection.</param>
        public DiscreteCollection(IList<bool> bits)
            : this(new List<bool>(bits))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DiscreteCollection" /> class.
        /// </summary>
        /// <param name="bits">List for discrete collection.</param>
        internal DiscreteCollection(List<bool> bits)
            : base(bits)
        {
            Debug.Assert(bits != null, "Discrete bits is null.");
            _discretes = bits;
        }

        /// <summary>
        ///     Gets the network bytes.
        /// </summary>
        public byte[] NetworkBytes
        {
            get
            {
                byte[] bytes = new byte[ByteCount];

                for (int index = 0; index < _discretes.Count; index++)
                {
                    if (_discretes[index])
                    {
                        bytes[index / BitsPerByte] |= (byte)(1 << (index % BitsPerByte));
                    }
                }

                return bytes;
            }
        }

        /// <summary>
        ///     Gets the byte count.
        /// </summary>
        public byte ByteCount => (byte)((Count + 7) / 8);

        /// <summary>
        ///     Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </returns>
        public override string ToString()
        {
            return string.Concat("{", string.Join(", ", this.Select(discrete => discrete ? "1" : "0").ToArray()), "}");
        }
    }
    internal class DefaultSlaveDataStore : ISlaveDataStore
    {
        private readonly IPointSource<ushort> _holdingRegisters = new DefaultPointSource<ushort>();
        private readonly IPointSource<ushort> _inputRegisters = new DefaultPointSource<ushort>();
        private readonly IPointSource<bool> _coilDiscretes = new DefaultPointSource<bool>();
        private readonly IPointSource<bool> _coilInputs = new DefaultPointSource<bool>();

        public IPointSource<ushort> HoldingRegisters => _holdingRegisters;

        public IPointSource<ushort> InputRegisters => _inputRegisters;

        public IPointSource<bool> CoilDiscretes => _coilDiscretes;

        public IPointSource<bool> CoilInputs => _coilInputs;
    }
    /// <summary>
    /// A simple implementation of the point source. All registers are 
    /// </summary>
    /// <typeparam name="TPoint"></typeparam>
    internal class DefaultPointSource<TPoint> : IPointSource<TPoint>
    {
        //Only create this if referenced.
        private readonly Lazy<TPoint[]> _points;

        private readonly object _syncRoot = new object();

        public DefaultPointSource()
        {
            _points = new Lazy<TPoint[]>(() => new TPoint[ushort.MaxValue]);
        }

        public TPoint[] ReadPoints(ushort startAddress, ushort numberOfPoints)
        {
            lock (_syncRoot)
            {
                return _points.Value
                    .Slice(startAddress, numberOfPoints)
                    .ToArray();
            }
        }

        public void WritePoints(ushort startAddress, TPoint[] points)
        {
            lock (_syncRoot)
            {
                for (ushort index = 0; index < points.Length; index++)
                {
                    _points.Value[startAddress + index] = points[index];
                }
            }
        }
    }
}
