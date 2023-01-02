using SAASystem.Models.Context;
using System;

namespace SAASystem.Builder
{
    public class ContractBuilder
    {
        private ContractContextModel _contextModel = new ContractContextModel();
        public ContractBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new ContractContextModel();
        }
        public void Set(ContractContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public ContractBuilder SetContractId(int contractId)
        {
            _contextModel.ContractId = contractId;
            return this;
        }
        public ContractBuilder SetRoomId(int roomId)
        {
            _contextModel.RoomId = roomId;
            return this;
        }
        public ContractBuilder SetTenantId(int tenantId)
        {
            _contextModel.TenantId = tenantId;
            return this;
        }
        public ContractBuilder SetDateTimeContractFrom(DateTime dateTimeContractFrom)
        {
            _contextModel.DateTimeContractFrom = dateTimeContractFrom;
            return this;
        }
        public ContractBuilder SetDateTimeContractTo(DateTime dateTimeContractTo)
        {
            _contextModel.DateTimeContractTo = dateTimeContractTo;
            return this;
        }
        public ContractBuilder SetDepositAmount(double depositAmount)
        {
            _contextModel.DepositAmount = depositAmount;
            return this;
        }
        public ContractBuilder SetPayedAmount(double payedAmount)
        {
            _contextModel.PayedAmount = payedAmount;
            return this;
        }
        public ContractContextModel Build()
        {
            ContractContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}