using System;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public interface ISuiteContext
    {
        SuiteModel Select(int suiteId);
        IEnumerable<SuiteModel> SelectAll();
        int Insert(string name, double cpw, double size, double securityDeposit,
            int daysAvailable, DateTime contractFrom, DateTime conractTo,
            int maximumStay, int isShortTermLet, int isAmneties, int isFurnish,
            int isReference, int isBills, int isBroadband);
        int Delete(int suiteId);
    }
}