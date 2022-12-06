using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.NModbus
{
    internal class DiagnosticsService : ModbusFunctionServiceBase<IModbusMessage>
    {
        public DiagnosticsService()
            : base(ModbusFunctionCodes.Diagnostics)
        {
        }

        public override IModbusMessage CreateRequest(byte[] frame)
        {
            return CreateModbusMessage<DiagnosticsRequestResponse>(frame);
        }

        public override int GetRtuRequestBytesToRead(byte[] frameStart)
        {
            return 1;
        }

        public override int GetRtuResponseBytesToRead(byte[] frameStart)
        {
            return 4;
        }

        protected override IModbusMessage Handle(IModbusMessage request, ISlaveDataStore dataStore)
        {
            return request;
        }
    }
    internal class ReadCoilsService : ModbusFunctionServiceBase<ReadCoilsInputsRequest>
    {
        public ReadCoilsService()
            : base(ModbusFunctionCodes.ReadCoils)
        {
        }

        public override IModbusMessage CreateRequest(byte[] frame)
        {
            return CreateModbusMessage<ReadCoilsInputsRequest>(frame);
        }

        public override int GetRtuRequestBytesToRead(byte[] frameStart)
        {
            return 1;
        }

        public override int GetRtuResponseBytesToRead(byte[] frameStart)
        {
            return frameStart[2] + 1;
        }

        protected override IModbusMessage Handle(ReadCoilsInputsRequest request, ISlaveDataStore dataStore)
        {
            bool[] discretes = dataStore.CoilDiscretes.ReadPoints(request.StartAddress, request.NumberOfPoints);

            DiscreteCollection data = new DiscreteCollection(discretes);

            return new ReadCoilsInputsResponse(
                request.FunctionCode,
                request.SlaveAddress,
                data.ByteCount, data);
        }
    }
    internal class ReadHoldingRegistersService : ModbusFunctionServiceBase<ReadHoldingInputRegistersRequest>
    {
        public ReadHoldingRegistersService()
            : base(ModbusFunctionCodes.ReadHoldingRegisters)
        {
        }

        public override IModbusMessage CreateRequest(byte[] frame)
        {
            return CreateModbusMessage<ReadHoldingInputRegistersRequest>(frame);
        }

        public override int GetRtuRequestBytesToRead(byte[] frameStart)
        {
            return 1;
        }

        public override int GetRtuResponseBytesToRead(byte[] frameStart)
        {
            return frameStart[2] + 1;
        }

        protected override IModbusMessage Handle(ReadHoldingInputRegistersRequest request, ISlaveDataStore dataStore)
        {
            ushort[] registers = dataStore.HoldingRegisters.ReadPoints(request.StartAddress, request.NumberOfPoints);

            RegisterCollection data = new RegisterCollection(registers);

            return new ReadHoldingInputRegistersResponse(request.FunctionCode, request.SlaveAddress, data);
        }
    }
    internal class ReadInputRegistersService : ModbusFunctionServiceBase<ReadHoldingInputRegistersRequest>
    {
        public ReadInputRegistersService()
            : base(ModbusFunctionCodes.ReadInputRegisters)
        {
        }

        public override IModbusMessage CreateRequest(byte[] frame)
        {
            return CreateModbusMessage<ReadHoldingInputRegistersRequest>(frame);
        }

        public override int GetRtuRequestBytesToRead(byte[] frameStart)
        {
            return 1;
        }

        public override int GetRtuResponseBytesToRead(byte[] frameStart)
        {
            return frameStart[2] + 1;
        }

        protected override IModbusMessage Handle(ReadHoldingInputRegistersRequest request, ISlaveDataStore dataStore)
        {
            ushort[] registers = dataStore.InputRegisters.ReadPoints(request.StartAddress, request.NumberOfPoints);

            RegisterCollection regsiterCollection = new RegisterCollection(registers);

            return new ReadHoldingInputRegistersResponse(request.FunctionCode, request.SlaveAddress, regsiterCollection);
        }
    }
    internal class ReadInputsService : ModbusFunctionServiceBase<ReadCoilsInputsRequest>
    {
        public ReadInputsService()
            : base(ModbusFunctionCodes.ReadInputs)
        {
        }

        public override IModbusMessage CreateRequest(byte[] frame)
        {
            return CreateModbusMessage<ReadCoilsInputsRequest>(frame);
        }

        public override int GetRtuRequestBytesToRead(byte[] frameStart)
        {
            return 1;
        }

        public override int GetRtuResponseBytesToRead(byte[] frameStart)
        {
            return frameStart[2] + 1;
        }

        protected override IModbusMessage Handle(ReadCoilsInputsRequest request, ISlaveDataStore dataStore)
        {
            bool[] discretes = dataStore.CoilInputs.ReadPoints(request.StartAddress, request.NumberOfPoints);

            DiscreteCollection data = new DiscreteCollection(discretes);

            return new ReadCoilsInputsResponse(
                request.FunctionCode,
                request.SlaveAddress,
                data.ByteCount,
                data);
        }
    }
    internal class ReadWriteMultipleRegistersService : ModbusFunctionServiceBase<ReadWriteMultipleRegistersRequest>
    {
        public ReadWriteMultipleRegistersService()
            : base(ModbusFunctionCodes.ReadWriteMultipleRegisters)
        {
        }

        public override IModbusMessage CreateRequest(byte[] frame)
        {
            return CreateModbusMessage<ReadWriteMultipleRegistersRequest>(frame);
        }

        public override int GetRtuRequestBytesToRead(byte[] frameStart)
        {
            throw new NotSupportedException();
        }

        public override int GetRtuResponseBytesToRead(byte[] frameStart)
        {
            throw new NotSupportedException();
        }

        protected override IModbusMessage Handle(ReadWriteMultipleRegistersRequest request, ISlaveDataStore dataStore)
        {
            ushort[] pointsToWrite = request.WriteRequest.Data
                .ToArray();

            dataStore.HoldingRegisters.WritePoints(request.ReadRequest.StartAddress, pointsToWrite);

            ushort[] readPoints = dataStore.HoldingRegisters.ReadPoints(request.ReadRequest.StartAddress,
                request.ReadRequest.NumberOfPoints);

            RegisterCollection data = new RegisterCollection(readPoints);

            return new ReadHoldingInputRegistersResponse(
                request.FunctionCode,
                request.SlaveAddress,
                data);
        }
    }
    internal class WriteFileRecordService
        : ModbusFunctionServiceBase<WriteFileRecordRequest>
    {
        public WriteFileRecordService()
            : base(ModbusFunctionCodes.WriteFileRecord)
        {
        }

        public override IModbusMessage CreateRequest(byte[] frame)
        {
            return CreateModbusMessage<WriteFileRecordRequest>(frame);
        }

        public override int GetRtuRequestBytesToRead(byte[] frameStart)
        {
            return frameStart[2] + 1;
        }

        public override int GetRtuResponseBytesToRead(byte[] frameStart)
        {
            return frameStart[2] + 1;
        }

        protected override IModbusMessage Handle(WriteFileRecordRequest request, ISlaveDataStore dataStore)
        {
            throw new NotImplementedException("WriteFileRecordService::Handle");
        }
    }
    internal class WriteMultipleCoilsService : ModbusFunctionServiceBase<WriteMultipleCoilsRequest>
    {
        public WriteMultipleCoilsService()
            : base(ModbusFunctionCodes.WriteMultipleCoils)
        {
        }

        public override IModbusMessage CreateRequest(byte[] frame)
        {
            return CreateModbusMessage<WriteMultipleCoilsRequest>(frame);
        }

        public override int GetRtuRequestBytesToRead(byte[] frameStart)
        {
            return frameStart[6] + 2;
        }

        public override int GetRtuResponseBytesToRead(byte[] frameStart)
        {
            return 4;
        }

        protected override IModbusMessage Handle(WriteMultipleCoilsRequest request, ISlaveDataStore dataStore)
        {
            bool[] points = request.Data
                .Take(request.NumberOfPoints)
                .ToArray();

            dataStore.CoilDiscretes.WritePoints(request.StartAddress, points);

            return new WriteMultipleCoilsResponse(
               request.SlaveAddress,
               request.StartAddress,
               request.NumberOfPoints);
        }
    }
    internal class WriteMultipleRegistersService
        : ModbusFunctionServiceBase<WriteMultipleRegistersRequest>
    {
        public WriteMultipleRegistersService()
            : base(ModbusFunctionCodes.WriteMultipleRegisters)
        {
        }

        public override IModbusMessage CreateRequest(byte[] frame)
        {
            return CreateModbusMessage<WriteMultipleRegistersRequest>(frame);
        }

        public override int GetRtuRequestBytesToRead(byte[] frameStart)
        {
            return frameStart[6] + 2;
        }

        public override int GetRtuResponseBytesToRead(byte[] frameStart)
        {
            return 4;
        }

        protected override IModbusMessage Handle(WriteMultipleRegistersRequest request, ISlaveDataStore dataStore)
        {
            ushort[] registers = request.Data.ToArray();

            dataStore.HoldingRegisters.WritePoints(request.StartAddress, registers);

            return new WriteMultipleRegistersResponse(
                request.SlaveAddress,
                request.StartAddress,
                request.NumberOfPoints);
        }
    }
    internal class WriteSingleCoilService : ModbusFunctionServiceBase<WriteSingleCoilRequestResponse>
    {
        public WriteSingleCoilService()
            : base(ModbusFunctionCodes.WriteSingleCoil)
        {
        }

        public override IModbusMessage CreateRequest(byte[] frame)
        {
            return CreateModbusMessage<WriteSingleCoilRequestResponse>(frame);
        }

        public override int GetRtuRequestBytesToRead(byte[] frameStart)
        {
            return 1;
        }

        public override int GetRtuResponseBytesToRead(byte[] frameStart)
        {
            return 4;
        }

        protected override IModbusMessage Handle(WriteSingleCoilRequestResponse request, ISlaveDataStore dataStore)
        {
            bool[] values = new bool[]
            {
                request.Data[0] == Modbus.CoilOn
            };

            dataStore.CoilDiscretes.WritePoints(request.StartAddress, values);

            return request;
        }
    }
    internal class WriteSingleRegisterService : ModbusFunctionServiceBase<WriteSingleRegisterRequestResponse>
    {
        public WriteSingleRegisterService()
            : base(ModbusFunctionCodes.WriteSingleRegister)
        {
        }

        public override IModbusMessage CreateRequest(byte[] frame)
        {
            return CreateModbusMessage<WriteSingleRegisterRequestResponse>(frame);
        }

        public override int GetRtuRequestBytesToRead(byte[] frameStart)
        {
            return 1;
        }

        public override int GetRtuResponseBytesToRead(byte[] frameStart)
        {
            return 4;
        }

        protected override IModbusMessage Handle(WriteSingleRegisterRequestResponse request, ISlaveDataStore dataStore)
        {
            ushort[] points = request.Data
                .ToArray();

            dataStore.HoldingRegisters.WritePoints(request.StartAddress, points);

            return request;
        }
    }
}
