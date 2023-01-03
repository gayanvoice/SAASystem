using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Context.Interface
{
    public interface IApartmentContext
    {
        int Delete(int apartmentId);
        int Insert(ApartmentContextModel apartmentContextModel);
        ApartmentContextModel Select(int apartmentId);
        IEnumerable<ApartmentContextModel> SelectAll();
        int Update(ApartmentContextModel apartmentContextModel);
    }
}