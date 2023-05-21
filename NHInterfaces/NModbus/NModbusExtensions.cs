using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.NModbus
{
    /// <summary>
    ///     Utility extensions for the Enron Modbus dialect.
    /// </summary>
    public static class EnronModbus
    {
        /// <summary>
        ///    Reads contiguous block of input registers with 32 bit register size.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>Input registers status.</returns>
        public static uint[] ReadInputRegisters32(this IModbusMaster master, byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 62);

            var request = new ReadHoldingInputRegisters32Request(
                ModbusFunctionCodes.ReadInputRegisters,
                slaveAddress,
                startAddress,
                numberOfPoints);

            return PerformReadRegisters(master, request);
        }

        /// <summary>
        ///    Reads contiguous block of holding registers.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>Holding registers status.</returns>
        public static uint[] ReadHoldingRegisters32(this IModbusMaster master, byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 62);

            var request = new ReadHoldingInputRegisters32Request(
                ModbusFunctionCodes.ReadHoldingRegisters,
                slaveAddress,
                startAddress,
                numberOfPoints);

            return PerformReadRegisters(master, request);
        }

        /// <summary>
        ///    Asynchronously reads contiguous block of input registers with 32 bit register size.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public static Task<uint[]> ReadInputRegisters32Async(this IModbusMaster master, byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 125);

            var request = new ReadHoldingInputRegisters32Request(
                ModbusFunctionCodes.ReadInputRegisters,
                slaveAddress,
                startAddress,
                numberOfPoints);

            return PerformReadRegistersAsync(master, request);
        }

        /// <summary>
        ///    Asynchronously reads contiguous block of holding registers.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public static Task<uint[]> ReadHoldingRegisters32Async(this IModbusMaster master, byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            ValidateNumberOfPoints("numberOfPoints", numberOfPoints, 125);

            var request = new ReadHoldingInputRegisters32Request(
                ModbusFunctionCodes.ReadHoldingRegisters,
                slaveAddress,
                startAddress,
                numberOfPoints);

            return PerformReadRegistersAsync(master, request);
        }

        /// <summary>
        ///     Write a single 16 bit holding register.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="registerAddress">Address to write.</param>
        /// <param name="value">Value to write.</param>
        public static void WriteSingleRegister32(
            this IModbusMaster master,
            byte slaveAddress,
            ushort registerAddress,
            uint value)
        {
            if (master == null)
            {
                throw new ArgumentNullException(nameof(master));
            }

            master.WriteMultipleRegisters32(slaveAddress, registerAddress, new[] { value });
        }

        /// <summary>
        ///     Write a block of contiguous 32 bit holding registers.
        /// </summary>
        /// <param name="master">The Modbus master.</param>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        public static void WriteMultipleRegisters32(
            this IModbusMaster master,
            byte slaveAddress,
            ushort startAddress,
            uint[] data)
        {
            if (master == null)
            {
                throw new ArgumentNullException(nameof(master));
            }

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (data.Length == 0 || data.Length > 61)
            {
                throw new ArgumentException("The length of argument data must be between 1 and 61 inclusive.");
            }

            master.WriteMultipleRegisters(slaveAddress, startAddress, Convert(data).ToArray());
        }

        private static Task<uint[]> PerformReadRegistersAsync(IModbusMaster master, ReadHoldingInputRegisters32Request request)
        {
            return Task.Factory.StartNew(() => PerformReadRegisters(master, request));
        }

        private static uint[] PerformReadRegisters(IModbusMaster master, ReadHoldingInputRegisters32Request request)
        {
            ReadHoldingInputRegistersResponse response = master.Transport.UnicastMessage<ReadHoldingInputRegistersResponse>(request);

            uint[] registers = new uint[request.NumberOfPoints];

            if (response.Data is IModbusMessageDataCollection data)
            {
                for (int i = 0; i < response.Data.ByteCount; i += 4)
                {
                    registers[i / 4] = (uint)(data.NetworkBytes[i + 0] << 24 | data.NetworkBytes[i + 1] << 16 | data.NetworkBytes[i + 2] << 8 | data.NetworkBytes[i + 3]);
                }
            }

            return registers.Take(request.NumberOfPoints).ToArray();
        }

        private static void ValidateNumberOfPoints(string argumentName, ushort numberOfPoints, ushort maxNumberOfPoints)
        {
            if (numberOfPoints < 1 || numberOfPoints > maxNumberOfPoints)
            {
                string msg = $"Argument {argumentName} must be between 1 and {maxNumberOfPoints} inclusive.";
                throw new ArgumentException(msg);
            }
        }

        /// <summary>
        ///     Convert the 32 bit registers to two 16 bit values.
        /// </summary>
        private static IEnumerable<ushort> Convert(uint[] registers)
        {
            foreach (var register in registers)
            {
                // low order value
                yield return BitConverter.ToUInt16(BitConverter.GetBytes(register), 2);

                // high order value
                yield return BitConverter.ToUInt16(BitConverter.GetBytes(register), 0);
            }
        }
    }
    /// <summary>
    /// Class containing functions to covert endian from network device to host this code is running on.
    /// </summary>
    public class Endian
    {
        /// <summary>
        /// Converts BigEndian source bytes to Endian format of system.
        /// Source BE: 0x0A,0x0B,0x0C,0x0D. 
        /// Target BE: 0x0A,0x0B,0x0C,0x0D.
        /// Target LE: 0x0D,0x0C,0x0B,0x0A.
        /// </summary>
        /// <param name="sourceBytes">Byte array from device</param>
        /// <returns>Bytes in Endian format for system</returns>
        public static byte[] BigEndian(byte[] sourceBytes)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(sourceBytes);
            }
            return sourceBytes;
        }

        /// <summary>
        /// Converts LittleEndian source bytes to Endian format of system. 
        /// Source LE: 0x0D,0x0C,0x0B,0x0A. 
        /// Target BE: 0x0A,0x0B,0x0C,0x0D.
        /// Target LE: 0x0D,0x0C,0x0B,0x0A.
        /// </summary>
        /// <param name="sourceBytes">Byte array from device</param>
        /// <returns>Bytes in Endian format for system</returns>
        public static byte[] LittleEndian(byte[] sourceBytes)
        {
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(sourceBytes);
            }
            return sourceBytes;
        }

    }
    /// <summary>
    ///   This class provides some functions that can be used to read/write values of a set word size.
    /// </summary>
    public class RegisterFunctions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="startAddress"></param>
        /// <param name="numberOfPoints"></param>
        /// <param name="master"></param>
        /// <param name="wordSize"></param>
        /// <param name="endianConverter"></param>
        /// <param name="wordSwap"></param>
        /// <returns></returns>
        public static byte[][] ReadRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints, IModbusMaster master, uint wordSize, Func<byte[], byte[]> endianConverter, bool wordSwap = false)
        {
            var registerMultiplier = RegisterFunctions.GetRegisterMultiplier(wordSize);
            var registersToRead = (ushort)(numberOfPoints * registerMultiplier);
            var values = master.ReadHoldingRegisters(slaveAddress, startAddress, registersToRead);
            if (wordSwap) Array.Reverse(values);
            return RegisterFunctions.ConvertRegistersToValues(values, registerMultiplier).Select(endianConverter).ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="startAddress"></param>
        /// <param name="data"></param>
        /// <param name="master"></param>
        /// <param name="wordSize"></param>
        /// <param name="endianConverter"></param>
        /// <param name="wordSwap"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void WriteRegistersFunc(byte slaveAddress, ushort startAddress, byte[][] data, IModbusMaster master, uint wordSize, Func<byte[], byte[]> endianConverter, bool wordSwap = false)
        {
            var wordByteArraySize = RegisterFunctions.GetRegisterMultiplier(wordSize) * 2;
            if (data.Any(e => e.Length != wordByteArraySize))
            {
                throw new ArgumentException("All data values must be of the correct word length.");
            }
            var dataCorrectEndian = data.Select(endianConverter).ToArray();
            var registerValues = RegisterFunctions.ConvertValuesToRegisters(dataCorrectEndian);
            if (wordSwap) Array.Reverse(registerValues);
            master.WriteMultipleRegisters(slaveAddress, startAddress, registerValues);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="frontPadding"></param>
        /// <param name="singleCharPerRegister"></param>
        /// <returns></returns>
        public static char[] ByteValueArraysToChars(byte[][] data, bool frontPadding = true, bool singleCharPerRegister = true)
        {
            if (singleCharPerRegister)
            {
                return frontPadding
                  ? data.Select(e => BitConverter.ToChar(e, e.Length - 2)).ToArray()
                  : data.Select(e => BitConverter.ToChar(e, 0)).ToArray();
            }
            var flatData = data.SelectMany(e => e).ToArray();
            var count = flatData.Length / 2;
            var chars = new char[count];
            for (var index = 0; index < count; index++)
            {
                chars[index] = BitConverter.ToChar(flatData, index);
            }
            return chars;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="frontPadding"></param>
        /// <returns></returns>
        public static short[] ByteValueArraysToShorts(byte[][] data, bool frontPadding = true)
        {
            return frontPadding
              ? data.Select(e => BitConverter.ToInt16(e, e.Length - 2)).ToArray()
              : data.Select(e => BitConverter.ToInt16(e, 0)).ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="frontPadding"></param>
        /// <returns></returns>
        public static ushort[] ByteValueArraysToUShorts(byte[][] data, bool frontPadding = true)
        {
            return frontPadding
              ? data.Select(e => BitConverter.ToUInt16(e, e.Length - 2)).ToArray()
              : data.Select(e => BitConverter.ToUInt16(e, 0)).ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="frontPadding"></param>
        /// <returns></returns>
        public static int[] ByteValueArraysToInts(byte[][] data, bool frontPadding = true)
        {
            return frontPadding
              ? data.Select(e => BitConverter.ToInt32(e, e.Length - 4)).ToArray()
              : data.Select(e => BitConverter.ToInt32(e, 0)).ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="frontPadding"></param>
        /// <returns></returns>
        public static uint[] ByteValueArraysToUInts(byte[][] data, bool frontPadding = true)
        {
            return frontPadding
              ? data.Select(e => BitConverter.ToUInt32(e, e.Length - 4)).ToArray()
              : data.Select(e => BitConverter.ToUInt32(e, 0)).ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="frontPadding"></param>
        /// <returns></returns>
        public static float[] ByteValueArraysToFloats(byte[][] data, bool frontPadding = true)
        {
            return frontPadding
              ? data.Select(e => BitConverter.ToSingle(e, e.Length - 4)).ToArray()
              : data.Select(e => BitConverter.ToSingle(e, 0)).ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="wordSize"></param>
        /// <param name="frontPadding"></param>
        /// <param name="singleCharPerRegister"></param>
        /// <returns></returns>
        public static byte[][] CharsToByteValueArrays(char[] data, uint wordSize, bool frontPadding = true, bool singleCharPerRegister = true)
        {
            var bytesPerWord = RegisterFunctions.GetRegisterMultiplier(wordSize) * 2;
            if (!singleCharPerRegister)
            {
                var remainder = data.Length % bytesPerWord;
                var registerBytes = remainder > 0
                  ? data.Length + (bytesPerWord - remainder)
                  : data.Length;
                var byteArray = new byte[registerBytes];
                for (var index = 0; index < byteArray.Length; index++)
                {
                    byteArray[index] = index < data.Length
                      ? Convert.ToByte(data[index])
                      : Convert.ToByte('\0'); //Unicode Null Charector
                }
                var byteValueArrays = new byte[byteArray.Length / bytesPerWord][];
                for (var index = 0; index < byteValueArrays.Length; index++)
                {
                    var offset = index * bytesPerWord;
                    byteValueArrays[index] = new ArraySegment<byte>(byteArray, offset, bytesPerWord).ToArray();
                }
                return byteValueArrays;
            }
            return (frontPadding)
              ? data.Select(e =>
              {
                  var bytes = new byte[bytesPerWord];
                  bytes[bytes.Length - 1] = Convert.ToByte(e);
                  return bytes;
              }).ToArray()
              : data.Select(e =>
              {
                  var bytes = new byte[bytesPerWord];
                  bytes[0] = Convert.ToByte(e);
                  return bytes;
              }).ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="wordSize"></param>
        /// <param name="frontPadding"></param>
        /// <returns></returns>
        public static byte[][] ShortsToByteValueArrays(short[] data, uint wordSize, bool frontPadding = true)
          => data.Select(e => RegisterFunctions.PadBytesToWordSize(
            wordSize, BitConverter.GetBytes(e), frontPadding)).ToArray();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="wordSize"></param>
        /// <param name="frontPadding"></param>
        /// <returns></returns>
        public static byte[][] UShortsToByteValueArrays(ushort[] data, uint wordSize, bool frontPadding = true)
          => data.Select(e => RegisterFunctions.PadBytesToWordSize(
            wordSize, BitConverter.GetBytes(e), frontPadding)).ToArray();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="wordSize"></param>
        /// <param name="frontPadding"></param>
        /// <returns></returns>
        public static byte[][] IntToByteValueArrays(int[] data, uint wordSize, bool frontPadding = true)
          => data.Select(e => RegisterFunctions.PadBytesToWordSize(
            wordSize, BitConverter.GetBytes(e), frontPadding)).ToArray();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="wordSize"></param>
        /// <param name="frontPadding"></param>
        /// <returns></returns>
        public static byte[][] UIntToByteValueArrays(uint[] data, uint wordSize, bool frontPadding = true)
          => data.Select(e => RegisterFunctions.PadBytesToWordSize(
            wordSize, BitConverter.GetBytes(e), frontPadding)).ToArray();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="wordSize"></param>
        /// <param name="frontPadding"></param>
        /// <returns></returns>
        public static byte[][] FloatToByteValueArrays(float[] data, uint wordSize, bool frontPadding = true)
          => data.Select(e => RegisterFunctions.PadBytesToWordSize(
            wordSize, BitConverter.GetBytes(e), frontPadding)).ToArray();


        private static byte[] PadBytesToWordSize(uint wordSize, byte[] source, bool frontPadding)
        {
            var targetLength = RegisterFunctions.GetRegisterMultiplier(wordSize) * 2;
            var target = new byte[targetLength];
            if (source.Length > target.Length)
            {
                throw new ArgumentException("Source bytes can not greater than target");
            }
            var offset = frontPadding
              ? target.Length - source.Length
              : 0;
            Array.Copy(
              source, 0, target, offset, source.Length);
            return target;
        }

        private static ushort[] ConvertValuesToRegisters(byte[][] data)
        {
            var flatData = data.SelectMany(e => e).ToArray();
            var count = flatData.Count() / 2;
            var registers = new ushort[count];
            for (var index = 0; index < count; index++)
            {
                registers[index] = BitConverter.ToUInt16(flatData, (index * 2));
            }
            return registers;
        }

        private static byte[][] ConvertRegistersToValues(ushort[] registers, int registerMultiplier) //TODO::Convert to function pass in everything it needs
        {
            if ((registers.Length % registerMultiplier) != 0)
            {
                throw new InvalidDataException("registers.Length is not a multiple of RegisterMultiplier");
            }
            var count = registers.Length / registerMultiplier;
            var values = new byte[count][];
            for (var index = 0; index < count; index++)
            {
                var offset = index * registerMultiplier;
                var segment = new ArraySegment<ushort>(registers, offset, registerMultiplier);
                var bytes = segment.SelectMany(BitConverter.GetBytes).ToArray();
                values[index] = bytes;
            }
            return values;
        }

        private static int GetRegisterMultiplier(uint wordSize)
        {
            switch (wordSize)
            {
                case (16):
                    return 1;
                case (32):
                    return 2;
                case (64):
                    return 4;
                default: throw new ArgumentException("Word size mus be 16/32/64");
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static class CrcExtensions
    {
        /// <summary>
        /// Determines whether the crc stored in the message matches the calculated crc.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool DoesCrcMatch(this byte[] message)
        {
            var messageFrame = message.Take(message.Length - 2).ToArray();

            //Calculate the CRC with the given set of bytes
            var calculatedCrc = BitConverter.ToUInt16(ModbusUtility.CalculateCrc(messageFrame), 0);

            //Get the crc that is stored in the message
            var messageCrc = message.GetCRC();

            //Determine if they match
            return calculatedCrc == messageCrc;
        }

        /// <summary>
        /// Gets the CRC of the message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ushort GetCRC(this byte[] message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            if (message.Length < 4)
                throw new ArgumentException("message must be at least four bytes long");

            return BitConverter.ToUInt16(message, message.Length - 2);
        }
    }
    internal static class DictionaryExtensions
    {
        /// <summary>
        /// Gets the specified value in the dictionary. If not found, returns default for TValue.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        internal static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;

            if (dictionary.TryGetValue(key, out value))
                return value;

            return default(TValue);
        }
    }
    internal static class ModbusFactoryExtensions
    {
        private const int MinRequestFrameLength = 3;

        public static IModbusMessage CreateModbusRequest(this IModbusFactory factory, byte[] frame)
        {
            if (frame.Length < MinRequestFrameLength)
            {
                string msg = $"Argument 'frame' must have a length of at least {MinRequestFrameLength} bytes.";
                throw new FormatException(msg);
            }

            byte functionCode = frame[1];

            var functionService = factory.GetFunctionService(functionCode);

            return functionService.CreateRequest(frame);
        }

        public static IModbusFunctionService GetFunctionServiceOrThrow(this IModbusFactory factory, byte functionCode)
        {
            IModbusFunctionService service = factory.GetFunctionService(functionCode);

            if (service == null)
            {
                string msg = $"Function code {functionCode} not supported.";
                factory.Logger.Warning(msg);

                throw new NotImplementedException(msg);
            }

            return service;
        }
    }
    /// <summary>
    /// Utility Class to support Modbus 32/64bit devices. 
    /// </summary>
    public class ModbusMasterEnhanced
    {
        private readonly IModbusMaster master;
        private readonly uint wordSize;
        private readonly Func<byte[], byte[]> endian;
        private readonly bool wordSwapped;


        /// <summary>
        /// Constructor with values to be used by all methods. 
        /// Default is 32bit, LittleEndian, with wordswapping.
        /// </summary>
        /// <param name="master">The Modbus master</param>
        /// <param name="wordSize">Wordsize used by device. 16/32/64 are valid.</param>
        /// <param name="endian">The endian encoding of the device.</param>
        /// <param name="wordSwapped">Should the ushort words mirrored then flattened to bytes.</param>
        public ModbusMasterEnhanced(IModbusMaster master, uint wordSize = 32, Func<byte[], byte[]> endian = null, bool wordSwapped = false)
        {
            this.master = master;
            this.wordSize = wordSize;
            this.endian = endian ?? Endian.LittleEndian;
            this.wordSwapped = wordSwapped;
        }

        /// <summary>
        /// Reads registers and converts the result into a char array.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of chars to read.</param>
        /// <returns></returns>
        public char[] ReadCharHoldingRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
          => RegisterFunctions.ByteValueArraysToChars(
            RegisterFunctions.ReadRegisters(slaveAddress, startAddress, numberOfPoints, this.master, this.wordSize, this.endian, this.wordSwapped));

        /// <summary>
        /// Reads registers and converts the result into a ushort array.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of ushorts to read.</param>
        /// <returns></returns>
        public ushort[] ReadUshortHoldingRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
            => RegisterFunctions.ByteValueArraysToUShorts(
              RegisterFunctions.ReadRegisters(slaveAddress, startAddress, numberOfPoints, this.master, this.wordSize, this.endian, this.wordSwapped));

        /// <summary>
        /// Reads registers and converts the result into a short array.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of shots to read.</param>
        /// <returns></returns>
        public short[] ReadShortHoldingRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
          => RegisterFunctions.ByteValueArraysToShorts(
            RegisterFunctions.ReadRegisters(slaveAddress, startAddress, numberOfPoints, this.master, this.wordSize, this.endian, this.wordSwapped));

        /// <summary>
        /// Reads registers and converts the result into a uint array.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of uints to read.</param>
        /// <returns></returns>
        public uint[] ReadUintHoldingRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
          => RegisterFunctions.ByteValueArraysToUInts(
            RegisterFunctions.ReadRegisters(slaveAddress, startAddress, numberOfPoints, this.master, this.wordSize, this.endian, this.wordSwapped));

        /// <summary>
        /// Reads registers and converts the result into a int array.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of ints to read.</param>
        /// <returns></returns>
        public int[] ReadIntHoldingRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
          => RegisterFunctions.ByteValueArraysToInts(
            RegisterFunctions.ReadRegisters(slaveAddress, startAddress, numberOfPoints, this.master, this.wordSize, this.endian, this.wordSwapped));

        /// <summary>
        /// Reads registers and converts the result into a float array.
        /// </summary>
        /// <param name="slaveAddress">Address of device to read values from.</param>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of floats to read.</param>
        /// <returns></returns>
        public float[] ReadFloatHoldingRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
          => RegisterFunctions.ByteValueArraysToFloats(
               RegisterFunctions.ReadRegisters(slaveAddress, startAddress, numberOfPoints, this.master, this.wordSize, this.endian, this.wordSwapped));

        /// <summary>
        ///     Write a char array to registers.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to start writting values at.</param>
        /// <param name="data">Chars to write to device.</param>
        public void WriteCharHoldingRegisters(byte slaveAddress, ushort startAddress, char[] data)
          => RegisterFunctions.WriteRegistersFunc(
            slaveAddress,
            startAddress,
            RegisterFunctions.CharsToByteValueArrays(data, this.wordSize),
            this.master,
            this.wordSize,
            this.endian, this.wordSwapped);

        /// <summary>
        ///     Write a ushort array to registers.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to start writting values at.</param>
        /// <param name="data">Ushorts to write to device.</param>
        public void WriteUshortHoldingRegisters(byte slaveAddress, ushort startAddress, ushort[] data)
          => RegisterFunctions.WriteRegistersFunc(
            slaveAddress,
            startAddress,
            RegisterFunctions.UShortsToByteValueArrays(data, this.wordSize),
            this.master,
            this.wordSize,
            this.endian, this.wordSwapped);

        /// <summary>
        ///     Write a short array to registers.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to start writting values at.</param>
        /// <param name="data">Shorts to write to device.</param>
        public void WriteShortHoldingRegisters(byte slaveAddress, ushort startAddress, short[] data)
          => RegisterFunctions.WriteRegistersFunc(
            slaveAddress,
            startAddress,
            RegisterFunctions.ShortsToByteValueArrays(data, this.wordSize),
            this.master,
            this.wordSize,
            this.endian, this.wordSwapped);

        /// <summary>
        ///     Write a int array to registers.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to start writting values at.</param>
        /// <param name="data">Ints to write to device.</param>
        public void WriteIntHoldingRegisters(byte slaveAddress, ushort startAddress, int[] data)
          => RegisterFunctions.WriteRegistersFunc(
            slaveAddress,
            startAddress,
            RegisterFunctions.IntToByteValueArrays(data, this.wordSize),
            this.master,
            this.wordSize,
            this.endian, this.wordSwapped);

        /// <summary>
        ///     Write a uint array to registers.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to start writting values at.</param>
        /// <param name="data">Uints to write to device.</param>
        public void WriteUIntHoldingRegisters(byte slaveAddress, ushort startAddress, uint[] data)
          => RegisterFunctions.WriteRegistersFunc(
            slaveAddress,
            startAddress,
            RegisterFunctions.UIntToByteValueArrays(data, this.wordSize),
            this.master,
            this.wordSize,
            this.endian, this.wordSwapped);

        /// <summary>
        ///     Write a float array to registers.
        /// </summary>
        /// <param name="slaveAddress">Address of the device to write to.</param>
        /// <param name="startAddress">Address to start writting values at.</param>
        /// <param name="data">Floats to write to device.</param>
        public void WriteFloatHoldingRegisters(byte slaveAddress, ushort startAddress, float[] data)
          => RegisterFunctions.WriteRegistersFunc(
            slaveAddress,
            startAddress,
            RegisterFunctions.FloatToByteValueArrays(data, this.wordSize),
            this.master,
            this.wordSize,
            this.endian, this.wordSwapped);
    }
}
