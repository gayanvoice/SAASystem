using SAASystem.Models.Context;
using System;

namespace SAASystem.Builder
{
    public class SuiteBuilder
    {
        private SuiteContextModel _contextModel = new SuiteContextModel();
        public SuiteBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new SuiteContextModel();
        }
        public void Set(SuiteContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public SuiteBuilder SetSuiteId(int suiteId)
        {
            _contextModel.SuiteId = suiteId;
            return this;
        }
        public SuiteBuilder SetName(string name)
        {
            _contextModel.Name = name;
            return this;
        }
        public SuiteBuilder SetCpw(double cpw)
        {
            _contextModel.Cpw = cpw;
            return this;
        }
        public SuiteBuilder SetSize(double size)
        {
            _contextModel.Size = size;
            return this;
        }
        public SuiteBuilder SetSecurityDeposite(double securityDeposite)
        {
            _contextModel.SecurityDeposit = securityDeposite;
            return this;
        }
        public SuiteBuilder SetDaysAvailable(int daysAvailable)
        {
            _contextModel.DaysAvailable = daysAvailable;
            return this;
        }
        public SuiteBuilder SetMaximumStay(int maximumStay)
        {
            _contextModel.MaximumStay = maximumStay;
            return this;
        }
        public SuiteBuilder SetStatus(string status)
        {
            _contextModel.Status = status;
            return this;
        }
        public SuiteContextModel Build()
        {
            SuiteContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}