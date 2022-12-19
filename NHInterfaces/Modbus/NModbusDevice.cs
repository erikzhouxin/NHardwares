using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.NModbus
{
    /// <summary>
    /// Provides concurrency control across multiple Modbus readers/writers.
    /// </summary>
    public class ConcurrentModbusMaster : IConcurrentModbusMaster
    {
        private readonly IModbusMaster _master;
        private readonly TimeSpan _minInterval;

        private bool _isDisposed;

        private readonly Stopwatch _stopwatch = new Stopwatch();

        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="master"></param>
        /// <param name="minInterval"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ConcurrentModbusMaster(IModbusMaster master, TimeSpan minInterval)
        {
            _master = master ?? throw new ArgumentNullException(nameof(master));
            _minInterval = minInterval;

            _stopwatch.Start();
        }

        private Task WaitAsync(CancellationToken cancellationToken)
        {
            int difference = (int)(_minInterval - _stopwatch.Elapsed).TotalMilliseconds;

            if (difference > 0)
            {
                TestTry.TaskDelay(difference, cancellationToken);
            }
            return TestTry.TaskFromResult(false);
        }
        private async Task<T> PerformFuncAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken)
        {
            T value = default(T);

            await PerformAsync(async () => value = await action(), cancellationToken);

            return value;
        }

        private async Task PerformAsync(Func<Task> action, CancellationToken cancellationToken)
        {
            await _semaphore.WaitAsync(cancellationToken);

            try
            {
                await WaitAsync(cancellationToken);

                await action();
            }
            finally
            {
                _semaphore.Release();

                _stopwatch.Restart();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="startAddress"></param>
        /// <param name="numberOfPoints"></param>
        /// <param name="blockSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ushort[]> ReadInputRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints, ushort blockSize, CancellationToken cancellationToken)
        {
            return await PerformFuncAsync(async () =>
            {
                List<ushort> registers = new List<ushort>(numberOfPoints);

                int soFar = 0;
                int thisRead = blockSize;

                while (soFar < numberOfPoints)
                {
                    //If we're _not_ on the first run through here, wait for the min time
                    if (soFar > 0)
                    {
                        await TestTry.TaskDelay(_minInterval, cancellationToken);
                    }

                    //Check to see if we've ben cancelled
                    cancellationToken.ThrowIfCancellationRequested();

                    if (thisRead > (numberOfPoints - soFar))
                    {
                        thisRead = numberOfPoints - soFar;
                    }

                    //Perform this operation
                    ushort[] registersFromThisRead = await _master.ReadInputRegistersAsync(slaveAddress, (ushort)(startAddress + soFar), (ushort)thisRead);

                    //Add these to the result
                    registers.AddRange(registersFromThisRead);

                    //Increment where we're at
                    soFar += thisRead;
                }

                return registers.ToArray();

            }, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="startAddress"></param>
        /// <param name="numberOfPoints"></param>
        /// <param name="blockSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ushort[]> ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints, ushort blockSize, CancellationToken cancellationToken)
        {
            return PerformFuncAsync(async () =>
            {
                List<ushort> registers = new List<ushort>(numberOfPoints);

                int soFar = 0;
                int thisRead = blockSize;

                while (soFar < numberOfPoints)
                {
                    //If we're _not_ on the first run through here, wait for the min time
                    if (soFar > 0)
                    {
                        await TestTry.TaskDelay(_minInterval, cancellationToken);
                    }

                    //Check to see if we've ben cancelled
                    cancellationToken.ThrowIfCancellationRequested();

                    if (thisRead > (numberOfPoints - soFar))
                    {
                        thisRead = numberOfPoints - soFar;
                    }

                    //Perform this operation
                    ushort[] registersFromThisRead = await _master.ReadHoldingRegistersAsync(slaveAddress, (ushort)(startAddress + soFar), (ushort)thisRead);

                    //Add these to the result
                    registers.AddRange(registersFromThisRead);

                    //Increment where we're at
                    soFar += thisRead;
                }

                return registers.ToArray();

            }, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="startAddress"></param>
        /// <param name="data"></param>
        /// <param name="blockSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task WriteMultipleRegistersAsync(byte slaveAddress, ushort startAddress, ushort[] data, ushort blockSize, CancellationToken cancellationToken)
        {
            return PerformAsync(async () =>
            {
                int soFar = 0;
                int thisWrite = blockSize;

                while (soFar < data.Length)
                {
                    //If we're _not_ on the first run through here, wait for the min time
                    if (soFar > 0)
                    {
                        await TestTry.TaskDelay(_minInterval, cancellationToken);
                    }

                    if (thisWrite > (data.Length - soFar))
                    {
                        thisWrite = data.Length - soFar;
                    }

                    ushort[] registers = data.Skip(soFar).Take(thisWrite).ToArray();

                    await _master.WriteMultipleRegistersAsync(slaveAddress, (ushort)(startAddress + soFar), registers);

                    soFar += thisWrite;
                }

            }, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task WriteSingleRegisterAsync(byte slaveAddress, ushort address, ushort value, CancellationToken cancellationToken)
        {
            return PerformAsync(() => _master.WriteSingleRegisterAsync(slaveAddress, address, value), cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="startAddress"></param>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task WriteCoilsAsync(byte slaveAddress, ushort startAddress, bool[] data, CancellationToken cancellationToken)
        {
            return PerformAsync(() => _master.WriteMultipleCoilsAsync(slaveAddress, startAddress, data), cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="startAddress"></param>
        /// <param name="number"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool[]> ReadCoilsAsync(byte slaveAddress, ushort startAddress, ushort number,
            CancellationToken cancellationToken)
        {
            return PerformFuncAsync(() => _master.ReadCoilsAsync(slaveAddress, startAddress, number), cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="startAddress"></param>
        /// <param name="number"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool[]> ReadDiscretesAsync(byte slaveAddress, ushort startAddress, ushort number, CancellationToken cancellationToken)
        {
            return PerformFuncAsync(() => _master.ReadInputsAsync(slaveAddress, startAddress, number), cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="coilAddress"></param>
        /// <param name="value"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task WriteSingleCoilAsync(byte slaveAddress, ushort coilAddress, bool value, CancellationToken cancellationToken)
        {
            return PerformAsync(() => _master.WriteSingleCoilAsync(slaveAddress, coilAddress, value), cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;

                _master.Dispose();
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PointEventArgs<T> : PointEventArgs where T : struct
    {
        private readonly T[] _points;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="points"></param>
        public PointEventArgs(ushort startAddress, T[] points) : base(startAddress, (ushort)points.Length)
        {
            _points = points;
        }
        /// <summary>
        /// 
        /// </summary>
        public T[] Points => _points;
    }
    /// <summary>
    ///     Modbus device.
    /// </summary>
    internal abstract class ModbusDevice : IDisposable
    {
        private IModbusTransport _transport;

        internal ModbusDevice(IModbusTransport transport)
        {
            _transport = transport;
        }

        /// <summary>
        ///     Gets the Modbus Transport.
        /// </summary>
        public IModbusTransport Transport => _transport;

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources;
        ///     <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposableUtility.Dispose(ref _transport);
            }
        }
    }
    /// <summary>
    /// Base class for 
    /// </summary>
    /// <typeparam name="TRequest">The type of request to handle.</typeparam>
    internal abstract class ModbusFunctionServiceBase<TRequest> : IModbusFunctionService
        where TRequest : class
    {
        private readonly byte _functionCode;

        protected ModbusFunctionServiceBase(byte functionCode)
        {
            _functionCode = functionCode;
        }

        public byte FunctionCode => _functionCode;

        public abstract IModbusMessage CreateRequest(byte[] frame);

        public IModbusMessage HandleSlaveRequest(IModbusMessage request, ISlaveDataStore dataStore)
        {
            //Attempt to cast the message
            TRequest typedRequest = request as TRequest;

            if (typedRequest == null)
                throw new InvalidOperationException($"Unable to cast request of type '{request.GetType().Name}' to type '{typeof(TRequest).Name}");

            //Do the implementation specific logic
            return Handle(typedRequest, dataStore);
        }

        public abstract int GetRtuRequestBytesToRead(byte[] frameStart);

        public abstract int GetRtuResponseBytesToRead(byte[] frameStart);

        protected abstract IModbusMessage Handle(TRequest request, ISlaveDataStore dataStore);

        protected static T CreateModbusMessage<T>(byte[] frame)
            where T : IModbusMessage, new()
        {
            IModbusMessage message = new T();
            message.Initialize(frame);

            return (T)message;
        }
    }
    /// <summary>
    ///    Modbus IP master device.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Breaking change.")]
    internal class ModbusIpMaster : ModbusMaster
    {
        /// <summary>
        ///     Modbus IP master device.
        /// </summary>
        /// <param name="transport">Transport used by this master.</param>
        public ModbusIpMaster(IModbusTransport transport)
            : base(transport)
        {
        }

        /// <summary>
        ///    Reads from 1 to 2000 contiguous coils status.
        /// </summary>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of coils to read.</param>
        /// <returns>Coils status.</returns>
        public bool[] ReadCoils(ushort startAddress, ushort numberOfPoints)
        {
            return base.ReadCoils(Modbus.DefaultIpSlaveUnitId, startAddress, numberOfPoints);
        }

        /// <summary>
        ///    Asynchronously reads from 1 to 2000 contiguous coils status.
        /// </summary>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of coils to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public Task<bool[]> ReadCoilsAsync(ushort startAddress, ushort numberOfPoints)
        {
            return base.ReadCoilsAsync(Modbus.DefaultIpSlaveUnitId, startAddress, numberOfPoints);
        }

        /// <summary>
        ///    Reads from 1 to 2000 contiguous discrete input status.
        /// </summary>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of discrete inputs to read.</param>
        /// <returns>Discrete inputs status.</returns>
        public bool[] ReadInputs(ushort startAddress, ushort numberOfPoints)
        {
            return base.ReadInputs(Modbus.DefaultIpSlaveUnitId, startAddress, numberOfPoints);
        }

        /// <summary>
        ///    Asynchronously reads from 1 to 2000 contiguous discrete input status.
        /// </summary>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of discrete inputs to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public Task<bool[]> ReadInputsAsync(ushort startAddress, ushort numberOfPoints)
        {
            return base.ReadInputsAsync(Modbus.DefaultIpSlaveUnitId, startAddress, numberOfPoints);
        }

        /// <summary>
        ///    Reads contiguous block of holding registers.
        /// </summary>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>Holding registers status.</returns>
        public ushort[] ReadHoldingRegisters(ushort startAddress, ushort numberOfPoints)
        {
            return base.ReadHoldingRegisters(Modbus.DefaultIpSlaveUnitId, startAddress, numberOfPoints);
        }

        /// <summary>
        ///    Asynchronously reads contiguous block of holding registers.
        /// </summary>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public Task<ushort[]> ReadHoldingRegistersAsync(ushort startAddress, ushort numberOfPoints)
        {
            return base.ReadHoldingRegistersAsync(Modbus.DefaultIpSlaveUnitId, startAddress, numberOfPoints);
        }

        /// <summary>
        ///    Reads contiguous block of input registers.
        /// </summary>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>Input registers status.</returns>
        public ushort[] ReadInputRegisters(ushort startAddress, ushort numberOfPoints)
        {
            return base.ReadInputRegisters(Modbus.DefaultIpSlaveUnitId, startAddress, numberOfPoints);
        }

        /// <summary>
        ///    Asynchronously reads contiguous block of input registers.
        /// </summary>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public Task<ushort[]> ReadInputRegistersAsync(ushort startAddress, ushort numberOfPoints)
        {
            return base.ReadInputRegistersAsync(Modbus.DefaultIpSlaveUnitId, startAddress, numberOfPoints);
        }

        /// <summary>
        ///    Writes a single coil value.
        /// </summary>
        /// <param name="coilAddress">Address to write value to.</param>
        /// <param name="value">Value to write.</param>
        public void WriteSingleCoil(ushort coilAddress, bool value)
        {
            base.WriteSingleCoil(Modbus.DefaultIpSlaveUnitId, coilAddress, value);
        }

        /// <summary>
        ///    Asynchronously writes a single coil value.
        /// </summary>
        /// <param name="coilAddress">Address to write value to.</param>
        /// <param name="value">Value to write.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteSingleCoilAsync(ushort coilAddress, bool value)
        {
            return base.WriteSingleCoilAsync(Modbus.DefaultIpSlaveUnitId, coilAddress, value);
        }

        /// <summary>
        ///     Write a single holding register.
        /// </summary>
        /// <param name="registerAddress">Address to write.</param>
        /// <param name="value">Value to write.</param>
        public void WriteSingleRegister(ushort registerAddress, ushort value)
        {
            base.WriteSingleRegister(Modbus.DefaultIpSlaveUnitId, registerAddress, value);
        }

        /// <summary>
        ///    Asynchronously writes a single holding register.
        /// </summary>
        /// <param name="registerAddress">Address to write.</param>
        /// <param name="value">Value to write.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteSingleRegisterAsync(ushort registerAddress, ushort value)
        {
            return base.WriteSingleRegisterAsync(Modbus.DefaultIpSlaveUnitId, registerAddress, value);
        }

        /// <summary>
        ///     Write a block of 1 to 123 contiguous registers.
        /// </summary>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        public void WriteMultipleRegisters(ushort startAddress, ushort[] data)
        {
            base.WriteMultipleRegisters(Modbus.DefaultIpSlaveUnitId, startAddress, data);
        }

        /// <summary>
        ///    Asynchronously writes a block of 1 to 123 contiguous registers.
        /// </summary>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteMultipleRegistersAsync(ushort startAddress, ushort[] data)
        {
            return base.WriteMultipleRegistersAsync(Modbus.DefaultIpSlaveUnitId, startAddress, data);
        }

        /// <summary>
        ///     Force each coil in a sequence of coils to a provided value.
        /// </summary>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        public void WriteMultipleCoils(ushort startAddress, bool[] data)
        {
            base.WriteMultipleCoils(Modbus.DefaultIpSlaveUnitId, startAddress, data);
        }

        /// <summary>
        ///    Asynchronously writes a sequence of coils.
        /// </summary>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        /// <returns>A task that represents the asynchronous write operation</returns>
        public Task WriteMultipleCoilsAsync(ushort startAddress, bool[] data)
        {
            return base.WriteMultipleCoilsAsync(Modbus.DefaultIpSlaveUnitId, startAddress, data);
        }

        /// <summary>
        ///     Performs a combination of one read operation and one write operation in a single MODBUS transaction.
        ///     The write operation is performed before the read.
        ///     Message uses default TCP slave id of 0.
        /// </summary>
        /// <param name="startReadAddress">Address to begin reading (Holding registers are addressed starting at 0).</param>
        /// <param name="numberOfPointsToRead">Number of registers to read.</param>
        /// <param name="startWriteAddress">Address to begin writing (Holding registers are addressed starting at 0).</param>
        /// <param name="writeData">Register values to write.</param>
        public ushort[] ReadWriteMultipleRegisters(
            ushort startReadAddress,
            ushort numberOfPointsToRead,
            ushort startWriteAddress,
            ushort[] writeData)
        {
            return base.ReadWriteMultipleRegisters(
                Modbus.DefaultIpSlaveUnitId,
                startReadAddress,
                numberOfPointsToRead,
                startWriteAddress,
                writeData);
        }

        /// <summary>
        ///    Asynchronously performs a combination of one read operation and one write operation in a single Modbus transaction.
        ///    The write operation is performed before the read.
        /// </summary>
        /// <param name="startReadAddress">Address to begin reading (Holding registers are addressed starting at 0).</param>
        /// <param name="numberOfPointsToRead">Number of registers to read.</param>
        /// <param name="startWriteAddress">Address to begin writing (Holding registers are addressed starting at 0).</param>
        /// <param name="writeData">Register values to write.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task<ushort[]> ReadWriteMultipleRegistersAsync(
            ushort startReadAddress,
            ushort numberOfPointsToRead,
            ushort startWriteAddress,
            ushort[] writeData)
        {
            return base.ReadWriteMultipleRegistersAsync(
                Modbus.DefaultIpSlaveUnitId,
                startReadAddress,
                numberOfPointsToRead,
                startWriteAddress,
                writeData);
        }
    }
    /// <summary>
    ///     Modbus master device.
    /// </summary>
    internal abstract class ModbusMaster : ModbusDevice, IModbusMaster
    {
        internal ModbusMaster(IModbusTransport transport)
            : base(transport)
        {
        }

        /// <summary>
        ///    Reads from 1 to 2000 contiguous coils status.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of coils to read.</param>
        /// <returns>Coils status.</returns>
        public bool[] ReadCoils(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 2000);

            var request = new ReadCoilsInputsRequest(
                ModbusFunctionCodes.ReadCoils,
                slaveAddress,
                startAddress,
                numberOfPoints);

            return PerformReadDiscretes(request);
        }

        /// <summary>
        ///    Asynchronously reads from 1 to 2000 contiguous coils status.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of coils to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public Task<bool[]> ReadCoilsAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 2000);

            var request = new ReadCoilsInputsRequest(
                ModbusFunctionCodes.ReadCoils,
                slaveAddress,
                startAddress,
                numberOfPoints);

            return PerformReadDiscretesAsync(request);
        }

        /// <summary>
        ///    Reads from 1 to 2000 contiguous discrete input status.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of discrete inputs to read.</param>
        /// <returns>Discrete inputs status.</returns>
        public bool[] ReadInputs(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 2000);

            var request = new ReadCoilsInputsRequest(
                ModbusFunctionCodes.ReadInputs,
                slaveAddress,
                startAddress,
                numberOfPoints);

            return PerformReadDiscretes(request);
        }

        /// <summary>
        ///    Asynchronously reads from 1 to 2000 contiguous discrete input status.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of discrete inputs to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public Task<bool[]> ReadInputsAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 2000);

            var request = new ReadCoilsInputsRequest(
                ModbusFunctionCodes.ReadInputs,
                slaveAddress,
                startAddress,
                numberOfPoints);

            return PerformReadDiscretesAsync(request);
        }

        /// <summary>
        ///    Reads contiguous block of holding registers.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>Holding registers status.</returns>
        public ushort[] ReadHoldingRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 125);

            var request = new ReadHoldingInputRegistersRequest(
                ModbusFunctionCodes.ReadHoldingRegisters,
                slaveAddress,
                startAddress,
                numberOfPoints);

            return PerformReadRegisters(request);
        }

        /// <summary>
        ///    Asynchronously reads contiguous block of holding registers.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public Task<ushort[]> ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 125);

            var request = new ReadHoldingInputRegistersRequest(
                ModbusFunctionCodes.ReadHoldingRegisters,
                slaveAddress,
                startAddress,
                numberOfPoints);

            return PerformReadRegistersAsync(request);
        }

        /// <summary>
        ///    Reads contiguous block of input registers.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>Input registers status.</returns>
        public ushort[] ReadInputRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 125);

            var request = new ReadHoldingInputRegistersRequest(
                ModbusFunctionCodes.ReadInputRegisters,
                slaveAddress,
                startAddress,
                numberOfPoints);

            return PerformReadRegisters(request);
        }

        /// <summary>
        ///    Asynchronously reads contiguous block of input registers.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public Task<ushort[]> ReadInputRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 125);

            var request = new ReadHoldingInputRegistersRequest(
                ModbusFunctionCodes.ReadInputRegisters,
                slaveAddress,
                startAddress,
                numberOfPoints);

            return PerformReadRegistersAsync(request);
        }

        /// <summary>
        ///    Writes a single coil value.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="coilAddress">Address to write value to.</param>
        /// <param name="value">Value to write.</param>
        public void WriteSingleCoil(byte slaveAddress, ushort coilAddress, bool value)
        {
            var request = new WriteSingleCoilRequestResponse(slaveAddress, coilAddress, value);
            Transport.UnicastMessage<WriteSingleCoilRequestResponse>(request);
        }

        /// <summary>
        ///    Asynchronously writes a single coil value.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="coilAddress">Address to write value to.</param>
        /// <param name="value">Value to write.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteSingleCoilAsync(byte slaveAddress, ushort coilAddress, bool value)
        {
            var request = new WriteSingleCoilRequestResponse(slaveAddress, coilAddress, value);
            return PerformWriteRequestAsync<WriteSingleCoilRequestResponse>(request);
        }

        /// <summary>
        ///    Writes a single holding register.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="registerAddress">Address to write.</param>
        /// <param name="value">Value to write.</param>
        public void WriteSingleRegister(byte slaveAddress, ushort registerAddress, ushort value)
        {
            var request = new WriteSingleRegisterRequestResponse(
                slaveAddress,
                registerAddress,
                value);

            Transport.UnicastMessage<WriteSingleRegisterRequestResponse>(request);
        }

        /// <summary>
        ///    Asynchronously writes a single holding register.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="registerAddress">Address to write.</param>
        /// <param name="value">Value to write.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteSingleRegisterAsync(byte slaveAddress, ushort registerAddress, ushort value)
        {
            var request = new WriteSingleRegisterRequestResponse(
                slaveAddress,
                registerAddress,
                value);

            return PerformWriteRequestAsync<WriteSingleRegisterRequestResponse>(request);
        }

        /// <summary>
        ///     Write a block of 1 to 123 contiguous 16 bit holding registers.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        public void WriteMultipleRegisters(byte slaveAddress, ushort startAddress, ushort[] data)
        {
            ValidateData("data", data, 123);

            var request = new WriteMultipleRegistersRequest(
                slaveAddress,
                startAddress,
                new RegisterCollection(data));

            Transport.UnicastMessage<WriteMultipleRegistersResponse>(request);
        }

        /// <summary>
        ///    Asynchronously writes a block of 1 to 123 contiguous registers.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteMultipleRegistersAsync(byte slaveAddress, ushort startAddress, ushort[] data)
        {
            ValidateData("data", data, 123);

            var request = new WriteMultipleRegistersRequest(
                slaveAddress,
                startAddress,
                new RegisterCollection(data));

            return PerformWriteRequestAsync<WriteMultipleRegistersResponse>(request);
        }

        /// <summary>
        ///    Writes a sequence of coils.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        public void WriteMultipleCoils(byte slaveAddress, ushort startAddress, bool[] data)
        {
            ValidateData("data", data, 1968);

            var request = new WriteMultipleCoilsRequest(
                slaveAddress,
                startAddress,
                new DiscreteCollection(data));

            Transport.UnicastMessage<WriteMultipleCoilsResponse>(request);
        }

        /// <summary>
        ///    Asynchronously writes a sequence of coils.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteMultipleCoilsAsync(byte slaveAddress, ushort startAddress, bool[] data)
        {
            ValidateData("data", data, 1968);

            var request = new WriteMultipleCoilsRequest(
                slaveAddress,
                startAddress,
                new DiscreteCollection(data));

            return PerformWriteRequestAsync<WriteMultipleCoilsResponse>(request);
        }

        /// <summary>
        ///    Performs a combination of one read operation and one write operation in a single Modbus transaction.
        ///    The write operation is performed before the read.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startReadAddress">Address to begin reading (Holding registers are addressed starting at 0).</param>
        /// <param name="numberOfPointsToRead">Number of registers to read.</param>
        /// <param name="startWriteAddress">Address to begin writing (Holding registers are addressed starting at 0).</param>
        /// <param name="writeData">Register values to write.</param>
        public ushort[] ReadWriteMultipleRegisters(
            byte slaveAddress,
            ushort startReadAddress,
            ushort numberOfPointsToRead,
            ushort startWriteAddress,
            ushort[] writeData)
        {
            ValidateNumberOfPoints("numberOfPointsToRead", numberOfPointsToRead, 125);
            ValidateData("writeData", writeData, 121);

            var request = new ReadWriteMultipleRegistersRequest(
                slaveAddress,
                startReadAddress,
                numberOfPointsToRead,
                startWriteAddress,
                new RegisterCollection(writeData));

            return PerformReadRegisters(request);
        }

        /// <summary>
        ///    Asynchronously performs a combination of one read operation and one write operation in a single Modbus transaction.
        ///    The write operation is performed before the read.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startReadAddress">Address to begin reading (Holding registers are addressed starting at 0).</param>
        /// <param name="numberOfPointsToRead">Number of registers to read.</param>
        /// <param name="startWriteAddress">Address to begin writing (Holding registers are addressed starting at 0).</param>
        /// <param name="writeData">Register values to write.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task<ushort[]> ReadWriteMultipleRegistersAsync(
            byte slaveAddress,
            ushort startReadAddress,
            ushort numberOfPointsToRead,
            ushort startWriteAddress,
            ushort[] writeData)
        {
            ValidateNumberOfPoints("numberOfPointsToRead", numberOfPointsToRead, 125);
            ValidateData("writeData", writeData, 121);

            var request = new ReadWriteMultipleRegistersRequest(
                slaveAddress,
                startReadAddress,
                numberOfPointsToRead,
                startWriteAddress,
                new RegisterCollection(writeData));

            return PerformReadRegistersAsync(request);
        }

        /// <summary>
        /// Write a file record to the device.
        /// </summary>
        /// <param name="slaveAdress">Address of device to write values to</param>
        /// <param name="fileNumber">The Extended Memory file number</param>
        /// <param name="startingAddress">The starting register address within the file</param>
        /// <param name="data">The data to be written</param>
        public void WriteFileRecord(byte slaveAdress, ushort fileNumber, ushort startingAddress, byte[] data)
        {
            ValidateMaxData("data", data, 244);
            var request = new WriteFileRecordRequest(slaveAdress, new FileRecordCollection(
                fileNumber, startingAddress, data));

            Transport.UnicastMessage<WriteFileRecordResponse>(request);
        }

        /// <summary>
        ///    Executes the custom message.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="request">The request.</param>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        [SuppressMessage("Microsoft.Usage", "CA2223:MembersShouldDifferByMoreThanReturnType")]
        public TResponse ExecuteCustomMessage<TResponse>(IModbusMessage request)
            where TResponse : IModbusMessage, new()
        {
            return Transport.UnicastMessage<TResponse>(request);
        }

        private static void ValidateData<T>(string argumentName, T[] data, int maxDataLength)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (data.Length == 0 || data.Length > maxDataLength)
            {
                string msg = $"The length of argument {argumentName} must be between 1 and {maxDataLength} inclusive.";
                throw new ArgumentException(msg);
            }
        }

        private static void ValidateMaxData<T>(string argumentName, T[] data, int maxDataLength)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (data.Length > maxDataLength)
            {
                string msg = $"The length of argument {argumentName} must not be greater than {maxDataLength}.";
                throw new ArgumentException(msg);
            }
        }

        private static void ValidateNumberOfPoints(string argumentName, ushort numberOfPoints, ushort maxNumberOfPoints)
        {
            if (numberOfPoints < 1 || numberOfPoints > maxNumberOfPoints)
            {
                string msg = $"Argument {argumentName} must be between 1 and {maxNumberOfPoints} inclusive.";
                throw new ArgumentException(msg);
            }
        }

        private bool[] PerformReadDiscretes(ReadCoilsInputsRequest request)
        {
            ReadCoilsInputsResponse response = Transport.UnicastMessage<ReadCoilsInputsResponse>(request);
            return response.Data.Take(request.NumberOfPoints).ToArray();
        }

        private Task<bool[]> PerformReadDiscretesAsync(ReadCoilsInputsRequest request)
        {
            return Task.Factory.StartNew(() => PerformReadDiscretes(request));
        }

        private ushort[] PerformReadRegisters(ReadHoldingInputRegistersRequest request)
        {
            ReadHoldingInputRegistersResponse response =
                Transport.UnicastMessage<ReadHoldingInputRegistersResponse>(request);

            return response.Data.Take(request.NumberOfPoints).ToArray();
        }

        private Task<ushort[]> PerformReadRegistersAsync(ReadHoldingInputRegistersRequest request)
        {
            return Task.Factory.StartNew(() => PerformReadRegisters(request));
        }

        private ushort[] PerformReadRegisters(ReadWriteMultipleRegistersRequest request)
        {
            ReadHoldingInputRegistersResponse response =
                Transport.UnicastMessage<ReadHoldingInputRegistersResponse>(request);

            return response.Data.Take(request.ReadRequest.NumberOfPoints).ToArray();
        }

        private Task<ushort[]> PerformReadRegistersAsync(ReadWriteMultipleRegistersRequest request)
        {
            return Task.Factory.StartNew(() => PerformReadRegisters(request));
        }

        private Task PerformWriteRequestAsync<T>(IModbusMessage request)
            where T : IModbusMessage, new()
        {
            return Task.Factory.StartNew(() => Transport.UnicastMessage<T>(request));
        }
    }
    /// <summary>
    /// Represents an incoming connection from a Modbus master. Contains the slave's logic to process the connection.
    /// </summary>
    internal class ModbusMasterTcpConnection : ModbusDevice, IDisposable
    {

        private readonly TcpClient _client;
        private readonly string _endPoint;
        private readonly Stream _stream;
        private readonly IModbusSlaveNetwork _slaveNetwork;
        private readonly IModbusFactory _modbusFactory;
        private readonly Task _requestHandlerTask;

        private readonly byte[] _mbapHeader = new byte[6];
        private byte[] _messageFrame;

        public ModbusMasterTcpConnection(TcpClient client, IModbusSlaveNetwork slaveNetwork, IModbusFactory modbusFactory, IModbusLogger logger)
            : base(new ModbusIpTransport(new TcpClientAdapter(client), modbusFactory, logger))
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _endPoint = client.Client.RemoteEndPoint.ToString();
            _stream = client.GetStream();
            _slaveNetwork = slaveNetwork ?? throw new ArgumentNullException(nameof(slaveNetwork));
            _modbusFactory = modbusFactory ?? throw new ArgumentNullException(nameof(modbusFactory));
            _requestHandlerTask = TestTry.TaskRun((Func<Task>)HandleRequestAsync);
        }

        /// <summary>
        ///     Occurs when a Modbus master TCP connection is closed.
        /// </summary>
        public event EventHandler<TcpConnectionEventArgs> ModbusMasterTcpConnectionClosed;

        public IModbusLogger Logger { get; }

        public string EndPoint => _endPoint;

        public Stream Stream => _stream;

        public TcpClient TcpClient => _client;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _stream.Dispose();
            }

            base.Dispose(disposing);
        }

        private async Task HandleRequestAsync()
        {
            while (true)
            {
                Logger.Debug($"Begin reading header from Master at IP: {EndPoint}");

                int readBytes = await Stream.ReadAsync(_mbapHeader, 0, 6).ConfigureAwait(false);
                if (readBytes == 0)
                {
                    Logger.Debug($"0 bytes read, Master at {EndPoint} has closed Socket connection.");
                    ModbusMasterTcpConnectionClosed?.Invoke(this, new TcpConnectionEventArgs(EndPoint));
                    return;
                }

                ushort frameLength = (ushort)IPAddress.HostToNetworkOrder(BitConverter.ToInt16(_mbapHeader, 4));
                Logger.Debug($"Master at {EndPoint} sent header: \"{string.Join(", ", _mbapHeader)}\" with {frameLength} bytes in PDU");

                _messageFrame = new byte[frameLength];
                readBytes = await Stream.ReadAsync(_messageFrame, 0, frameLength).ConfigureAwait(false);
                if (readBytes == 0)
                {
                    Logger.Debug($"0 bytes read, Master at {EndPoint} has closed Socket connection.");
                    ModbusMasterTcpConnectionClosed?.Invoke(this, new TcpConnectionEventArgs(EndPoint));
                    return;
                }

                Logger.Debug($"Read frame from Master at {EndPoint} completed {readBytes} bytes");
                byte[] frame = _mbapHeader.Concat(_messageFrame).ToArray();
                Logger.Trace($"RX from Master at {EndPoint}: {string.Join(", ", frame)}");

                var request = _modbusFactory.CreateModbusRequest(_messageFrame);
                request.TransactionId = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 0));

                IModbusSlave slave = _slaveNetwork.GetSlave(request.SlaveAddress);

                if (slave != null)
                {
                    //TODO: Determine if this is appropriate

                    // perform action and build response
                    IModbusMessage response = slave.ApplyRequest(request);
                    response.TransactionId = request.TransactionId;

                    // write response
                    byte[] responseFrame = Transport.BuildMessageFrame(response);
                    Logger.Information($"TX to Master at {EndPoint}: {string.Join(", ", responseFrame)}");
                    await Stream.WriteAsync(responseFrame, 0, responseFrame.Length).ConfigureAwait(false);
                }
            }
        }
    }
    /// <summary>
    ///     Modbus serial master device.
    /// </summary>
    internal class ModbusSerialMaster : ModbusMaster, IModbusSerialMaster
    {
        internal ModbusSerialMaster(IModbusSerialTransport transport)
            : base(transport)
        {
        }

        /// <summary>
        ///     Gets the Modbus Transport.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        IModbusSerialTransport IModbusSerialMaster.Transport => (IModbusSerialTransport)Transport;

        /// <summary>
        ///     Serial Line only.
        ///     Diagnostic function which loops back the original data.
        ///     NModbus only supports looping back one ushort value, this is a limitation of the "Best Effort" implementation of
        ///     the RTU protocol.
        /// </summary>
        /// <param name="slaveAddress">Address of device to test.</param>
        /// <param name="data">Data to return.</param>
        /// <returns>Return true if slave device echoed data.</returns>
        public bool ReturnQueryData(byte slaveAddress, ushort data)
        {
            DiagnosticsRequestResponse request = new DiagnosticsRequestResponse(
                ModbusFunctionCodes.DiagnosticsReturnQueryData,
                slaveAddress,
                new RegisterCollection(data));

            DiagnosticsRequestResponse response = Transport.UnicastMessage<DiagnosticsRequestResponse>(request);

            return response.Data[0] == data;
        }
    }
    internal class ModbusSerialSlaveNetwork : ModbusSlaveNetwork
    {
        private readonly IModbusSerialTransport _serialTransport;
        private readonly IModbusFactory _modbusFactory;

        public ModbusSerialSlaveNetwork(IModbusSerialTransport transport, IModbusFactory modbusFactory, IModbusLogger logger)
            : base(transport, modbusFactory, logger)
        {
            _serialTransport = transport ?? throw new ArgumentNullException(nameof(transport));
            _modbusFactory = modbusFactory;
        }

        private IModbusSerialTransport SerialTransport => _serialTransport;

        public override Task ListenAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    // read request and build message
                    byte[] frame = SerialTransport.ReadRequest();

                    //Create the request
                    IModbusMessage request = _modbusFactory.CreateModbusRequest(frame);

                    //Check the message
                    if (SerialTransport.CheckFrame && !SerialTransport.ChecksumsMatch(request, frame))
                    {
                        string msg = $"Checksums failed to match {string.Join(", ", request.MessageFrame)} != {string.Join(", ", frame)}.";
                        Logger.Warning(msg);
                        throw new IOException(msg);
                    }

                    //Apply the request
                    IModbusMessage response = ApplyRequest(request);

                    if (response == null)
                    {
                        _serialTransport.IgnoreResponse();
                    }
                    else
                    {
                        Transport.Write(response);
                    }
                }
                catch (IOException ioe)
                {
                    Logger.Warning($"IO Exception encountered while listening for requests - {ioe.Message}");
                    SerialTransport.DiscardInBuffer();
                }
                catch (TimeoutException te)
                {
                    Logger.Trace($"Timeout Exception encountered while listening for requests - {te.Message}");
                    SerialTransport.DiscardInBuffer();
                }
                catch (InvalidOperationException)
                {
                    // when the underlying transport is disposed
                    break;
                }
                catch (Exception ex)
                {
                    Logger.Error($"{GetType()}: {ex.Message}");
                    SerialTransport.DiscardInBuffer();
                }
            }

            return TestTry.TaskFromResult(0);
        }
    }
    internal class ModbusSlave : IModbusSlave
    {
        private readonly byte _unitId;
        private readonly ISlaveDataStore _dataStore;

        private readonly IDictionary<byte, IModbusFunctionService> _handlers;

        public ModbusSlave(byte unitId, ISlaveDataStore dataStore, IEnumerable<IModbusFunctionService> handlers)
        {
            if (dataStore == null) throw new ArgumentNullException(nameof(dataStore));
            if (handlers == null) throw new ArgumentNullException(nameof(handlers));

            _unitId = unitId;
            _dataStore = dataStore;
            _handlers = handlers.ToDictionary(h => h.FunctionCode, h => h);
        }

        public byte UnitId => _unitId;

        public ISlaveDataStore DataStore => _dataStore;

        public IModbusMessage ApplyRequest(IModbusMessage request)
        {
            IModbusMessage response;

            try
            {
                //Try to get a handler for this function.
                IModbusFunctionService handler = _handlers.GetValueOrDefault(request.FunctionCode);

                //Check to see if we found a handler for this function code.
                if (handler == null)
                {
                    throw new InvalidModbusRequestException(SlaveExceptionCodes.IllegalFunction);
                }

                //Process the request
                response = handler.HandleSlaveRequest(request, DataStore);
            }
            catch (InvalidModbusRequestException ex)
            {
                // Catches the exception for an illegal function or a custom exception from the ModbusSlaveRequestReceived event.
                response = new SlaveExceptionResponse(
                    request.SlaveAddress,
                    (byte)(Modbus.ExceptionOffset + request.FunctionCode),
                    ex.ExceptionCode);
            }
#if NET45 || NET46
            catch (Exception ex)
            {
                //Okay - this is no beuno.
                response = new SlaveExceptionResponse(request.SlaveAddress,
                    (byte) (Modbus.ExceptionOffset + request.FunctionCode),
                    SlaveExceptionCodes.SlaveDeviceFailure);

                //Give the consumer a chance at seeing what the *(&& happened.
                Trace.WriteLine(ex.ToString());
            }
#else
            catch (Exception)
            {
                //Okay - this is no beuno.
                response = new SlaveExceptionResponse(request.SlaveAddress,
                    (byte)(Modbus.ExceptionOffset + request.FunctionCode),
                    SlaveExceptionCodes.SlaveDeviceFailure);
            }
#endif


            return response;
        }
    }
    internal abstract class ModbusSlaveNetwork : ModbusDevice, IModbusSlaveNetwork
    {
        private readonly IModbusLogger _logger;
        private readonly IDictionary<byte, IModbusSlave> _slaves = new ConcurrentDictionary<byte, IModbusSlave>();

        protected ModbusSlaveNetwork(IModbusTransport transport, IModbusFactory modbusFactory, IModbusLogger logger)
            : base(transport)
        {
            ModbusFactory = modbusFactory;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected IModbusFactory ModbusFactory { get; }

        protected IModbusLogger Logger
        {
            get { return _logger; }
        }

        /// <summary>
        /// Start slave listening for requests.
        /// </summary>
        public abstract Task ListenAsync(CancellationToken cancellationToken = new CancellationToken());

        /// <summary>
        /// Apply the request.
        /// </summary>
        /// <param name="request"></param>
        protected IModbusMessage ApplyRequest(IModbusMessage request)
        {
            //Check for broadcast requests
            if (request.SlaveAddress == 0)
            {
                //Grab each slave
                foreach (var slave in _slaves.Values)
                {
                    try
                    {
                        //Apply the request
                        slave.ApplyRequest(request);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error($"Error applying request to slave {slave.UnitId}: {ex.Message}");
                    }
                }
            }
            else
            {
                //Attempt to find a slave for this address
                IModbusSlave slave = GetSlave(request.SlaveAddress);

                // only service requests addressed to our slaves
                if (slave == null)
                {
                    Console.WriteLine($"NModbus Slave Network ignoring request intended for NModbus Slave {request.SlaveAddress}");
                }
                else
                {
                    // perform action
                    return slave.ApplyRequest(request);
                }
            }

            return null;
        }

        public void AddSlave(IModbusSlave slave)
        {
            if (slave == null) throw new ArgumentNullException(nameof(slave));

            _slaves.Add(slave.UnitId, slave);

            Logger.Information($"Slave {slave.UnitId} added to slave network.");
        }

        public void RemoveSlave(byte unitId)
        {
            _slaves.Remove(unitId);

            Logger.Information($"Slave {unitId} removed from slave network.");
        }

        public IModbusSlave GetSlave(byte unitId)
        {
            return _slaves.GetValueOrDefault(unitId);
        }
    }
    /// <summary>
    ///     Modbus TCP slave device.
    /// </summary>
    internal class ModbusTcpSlaveNetwork : ModbusSlaveNetwork
    {
        private const int TimeWaitResponse = 1000;
        private readonly object _serverLock = new object();

        private readonly ConcurrentDictionary<string, ModbusMasterTcpConnection> _masters =
            new ConcurrentDictionary<string, ModbusMasterTcpConnection>();

        private TcpListener _server;
#if TIMER
        private Timer _timer;
#endif
        internal ModbusTcpSlaveNetwork(TcpListener tcpListener, IModbusFactory modbusFactory, IModbusLogger logger)
            : base(new EmptyTransport(modbusFactory), modbusFactory, logger)
        {
            if (tcpListener == null)
            {
                throw new ArgumentNullException(nameof(tcpListener));
            }

            _server = tcpListener;
        }

#if TIMER
        private ModbusTcpSlave(byte unitId, TcpListener tcpListener, double timeInterval)
            : base(unitId, new EmptyTransport())
        {
            if (tcpListener == null)
            {
                throw new ArgumentNullException(nameof(tcpListener));
            }

            _server = tcpListener;
            _timer = new Timer(timeInterval);
            _timer.Elapsed += OnTimer;
            _timer.Enabled = true;
        }
#endif

        /// <summary>
        ///     Gets the Modbus TCP Masters connected to this Modbus TCP Slave.
        /// </summary>
        public ReadOnlyCollection<TcpClient> Masters
        {
            get
            {
                return new ReadOnlyCollection<TcpClient>(_masters.Values.Select(mc => mc.TcpClient).ToList());
            }
        }

        /// <summary>
        ///     Gets the server.
        /// </summary>
        /// <value>The server.</value>
        /// <remarks>
        ///     This property is not thread safe, it should only be consumed within a lock.
        /// </remarks>
        private TcpListener Server
        {
            get
            {
                if (_server == null)
                {
                    throw new ObjectDisposedException("Server");
                }

                return _server;
            }
        }

        ///// <summary>
        /////     Modbus TCP slave factory method.
        ///// </summary>
        //public static ModbusTcpSlave CreateTcp(byte unitId, TcpListener tcpListener)
        //{
        //    return new ModbusTcpSlave(unitId, tcpListener);
        //}

#if TIMER
        /// <summary>
        ///     Creates ModbusTcpSlave with timer which polls connected clients every
        ///     <paramref name="pollInterval"/> milliseconds on that they are connected.
        /// </summary>
        public static ModbusTcpSlave CreateTcp(byte unitId, TcpListener tcpListener, double pollInterval)
        {
            return new ModbusTcpSlave(unitId, tcpListener, pollInterval);
        }
#endif

        /// <summary>
        ///     Start slave listening for requests.
        /// </summary>
        public override async Task ListenAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            Logger.Information("Start Modbus Tcp Server.");
            // TODO: add state {stopped, listening} and check it before starting
            Server.Start();
            // Cancellation code based on https://stackoverflow.com/a/47049129/11066760
            using (cancellationToken.Register(() => Server.Stop()))
            {
                try
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        TcpClient client = await Server.AcceptTcpClientAsync().ConfigureAwait(false);
                        var masterConnection = new ModbusMasterTcpConnection(client, this, ModbusFactory, Logger);
                        masterConnection.ModbusMasterTcpConnectionClosed += OnMasterConnectionClosedHandler;
                        _masters.TryAdd(client.Client.RemoteEndPoint.ToString(), masterConnection);
                    }
                }
                catch (InvalidOperationException)
                {
                    // Either Server.Start wasn't called (a bug!)
                    // or the CancellationToken was cancelled before
                    // we started accepting (giving an InvalidOperationException),
                    // or the CancellationToken was cancelled after
                    // we started accepting (giving an ObjectDisposedException).
                    //
                    // In the latter two cases we should surface the cancellation
                    // exception, or otherwise rethrow the original exception.
                    cancellationToken.ThrowIfCancellationRequested();
                    throw;
                }
            }
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
        ///     unmanaged resources.
        /// </param>
        /// <remarks>Dispose is thread-safe.</remarks>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // double-check locking
                if (_server != null)
                {
                    lock (_serverLock)
                    {
                        if (_server != null)
                        {
                            _server.Stop();
                            _server = null;

#if TIMER
                            if (_timer != null)
                            {
                                _timer.Dispose();
                                _timer = null;
                            }
#endif

                            foreach (var key in _masters.Keys)
                            {
                                ModbusMasterTcpConnection connection;

                                if (_masters.TryRemove(key, out connection))
                                {
                                    connection.ModbusMasterTcpConnectionClosed -= OnMasterConnectionClosedHandler;
                                    connection.Dispose();
                                }
                            }
                        }
                    }
                }
            }
        }

        private static bool IsSocketConnected(Socket socket)
        {
            bool poll = socket.Poll(TimeWaitResponse, SelectMode.SelectRead);
            bool available = (socket.Available == 0);
            return poll && available;
        }

#if TIMER
        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            foreach (var master in _masters.ToList())
            {
                if (IsSocketConnected(master.Value.TcpClient.Client) == false)
                {
                    master.Value.Dispose();
                }
            }
        }
#endif
        private void OnMasterConnectionClosedHandler(object sender, TcpConnectionEventArgs e)
        {
            ModbusMasterTcpConnection connection;

            if (!_masters.TryRemove(e.EndPoint, out connection))
            {
                string msg = $"EndPoint {e.EndPoint} cannot be removed, it does not exist.";
                throw new ArgumentException(msg);
            }

            connection.Dispose();
            Logger.Information($"Removed Master {e.EndPoint}");
        }
    }
    /// <summary>
    ///     Modbus UDP slave device.
    /// </summary>
    internal class ModbusUdpSlaveNetwork : ModbusSlaveNetwork
    {
        private readonly UdpClient _udpClient;

        public ModbusUdpSlaveNetwork(UdpClient udpClient, IModbusFactory modbusFactory, IModbusLogger logger)
            : base(new ModbusIpTransport(new UdpClientAdapter(udpClient), modbusFactory, logger), modbusFactory, logger)
        {
            _udpClient = udpClient;
        }

        /// <summary>
        ///     Start slave listening for requests.
        /// </summary>
        public override async Task ListenAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            Logger.Information("Start Modbus Udp Server.");

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    UdpReceiveResult receiveResult = await _udpClient.ReceiveAsync().ConfigureAwait(false);
                    IPEndPoint masterEndPoint = receiveResult.RemoteEndPoint;
                    byte[] frame = receiveResult.Buffer;

                    Debug.WriteLine($"Read Frame completed {frame.Length} bytes");

                    Logger.LogFrameRx(frame);

                    IModbusMessage request = ModbusFactory.CreateModbusRequest(frame.Slice(6, frame.Length - 6).ToArray());
                    request.TransactionId = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 0));

                    // perform action and build response
                    IModbusMessage response = ApplyRequest(request);

                    if (response != null)
                    {
                        response.TransactionId = request.TransactionId;

                        // write response
                        byte[] responseFrame = Transport.BuildMessageFrame(response);

                        Logger.LogFrameTx(frame);

                        await _udpClient.SendAsync(responseFrame, responseFrame.Length, masterEndPoint)
                            .ConfigureAwait(false);
                    }
                }
            }
            catch (SocketException se)
            {
                // this hapens when slave stops
                if (se.SocketErrorCode != SocketError.Interrupted)
                {
                    throw;
                }
            }
        }
    }
    /// <summary>
    /// Modbus Slave request event args containing information on the message.
    /// </summary>
    public class PointEventArgs : EventArgs
    {
        private ushort _numberOfPoints;

        private ushort _startAddress;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="numberOfPoints"></param>
        public PointEventArgs(ushort startAddress, ushort numberOfPoints)
        {
            _startAddress = startAddress;
            _numberOfPoints = numberOfPoints;
        }
        /// <summary>
        /// 
        /// </summary>
        public ushort NumberOfPoints => _numberOfPoints;
        /// <summary>
        /// 
        /// </summary>
        public ushort StartAddress => _startAddress;
    }
    internal class TcpConnectionEventArgs : EventArgs
    {
        public TcpConnectionEventArgs(string endPoint)
        {
            if (endPoint == null)
            {
                throw new ArgumentNullException(nameof(endPoint));
            }

            if (endPoint == string.Empty)
            {
                throw new ArgumentException(Resources.EmptyEndPoint);
            }

            EndPoint = endPoint;
        }

        public string EndPoint { get; set; }
    }
}
