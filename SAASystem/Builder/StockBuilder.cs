using SAASystem.Models.Context;
using System;

namespace SAASystem.Builder
{
    public class StockBuilder
    {
        private StockContextModel _contextModel = new StockContextModel();
        public StockBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new StockContextModel();
        }
        public void Set(StockContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public StockBuilder SetStockId(int stockId)
        {
            _contextModel.StockId = stockId;
            return this;
        }
        public StockBuilder SetApartmentId(int apartmentId)
        {
            _contextModel.ApartmentId = apartmentId;
            return this;
        }
        public StockBuilder SetName(string name)
        {
            _contextModel.Name = name;
            return this;
        }
        public StockBuilder SetStatus(string status)
        {
            _contextModel.Status = status;
            return this;
        }
        public StockContextModel Build()
        {
            StockContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}