using System;

public class ContractModel
{
    public int ContractId { get; set; }
    public int RoomId { get; set; }
    public int TenantId { get; set; }
    public DateTime ContractFrom{ get; set; }
    public DateTime ContractTo { get; set; }
    public double DepositAmount{ get; set; }
    public double PayedAmount { get; set; }
}
