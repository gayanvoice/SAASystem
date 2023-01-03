using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Context.Interface
{
    public interface IStockContext
    {
        int Delete(int stockId);
        int Insert(StockContextModel stockContextModel);
        StockContextModel Select(int stockId);
        IEnumerable<StockContextModel> SelectAll();
        int Update(StockContextModel stockContextModel);
    }
}