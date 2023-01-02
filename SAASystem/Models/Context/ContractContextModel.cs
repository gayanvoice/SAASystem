using System;
//`ContractId` int (11) NOT NULL AUTO_INCREMENT
//`RoomId` int (11) NOT NULL
//`TenantId` int (11) NOT NULL
//`DatetimeContractFrom` datetime NOT NULL
//`DatetimeContractTo` datetime NOT NULL
//`DepositAmount` double NOT NULL
//`PayedAmount` double NOT NULL
namespace SAASystem.Models.Context
{
    public class ContractContextModel
    {
        public int ContractId { get; set; }
        public int RoomId { get; set; }
        public int TenantId { get; set; }
        public DateTime DateTimeContractFrom { get; set; }
        public DateTime DateTimeContractTo { get; set; }
        public double DepositAmount { get; set; }
        public double PayedAmount { get; set; }
    }
}