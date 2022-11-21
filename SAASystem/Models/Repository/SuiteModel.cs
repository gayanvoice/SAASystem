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
}