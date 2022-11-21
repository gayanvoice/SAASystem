using System;


public class ApartmentModel
{
    public enum Code
    {
        Active, Deactive, Reserved, Maintenance
    }

    public int ApartmentId { get; set; }
    public int PropertyId { get; set; }
    public int SuiteId { get; set; }
    public Code Code { get; set; }

}
