using System;

public class SuiteModel
{
    public int SuiteId { get; set; }
    public string Name { get; set; }
    public double CPW { get; set; }
    public double Size { get; set; }
    public double SecurityDeposit { get; set; }
    public int DaysAvailable { get; set; }
    public DateTime ContractFrom { get; set; }
    public DateTime ContractTo { get; set; }
    public int MaximumStay { get; set; }
    public double Size { get; set; }
    public bool IsShortTermAt { get; set; }
    public bool IsAmneties { get; set; }
    public bool IsFurnish { get; set; }
    public bool IsReference { get; set; }
    public bool IsBills { get; set; }
    public bool IsBroadband { get; set; }
}
