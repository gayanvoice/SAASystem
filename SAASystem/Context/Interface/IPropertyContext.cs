using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Context.Interface
{
    public interface IPropertyContext
    {
        int Delete(int propertyId);
        int Insert(PropertyContextModel propertyContextModel);
        PropertyContextModel Select(int propertyId);
        IEnumerable<PropertyContextModel> SelectAll();
        int Update(PropertyContextModel propertyContextModel);
    }
}