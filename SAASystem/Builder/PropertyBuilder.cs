using SAASystem.Models.Context;
using System;

namespace SAASystem.Builder
{
    public class PropertyBuilder
    {
        private PropertyContextModel _contextModel = new PropertyContextModel();
        public PropertyBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new PropertyContextModel();
        }
        public void Set(PropertyContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public PropertyBuilder SetPropertyId(int propertyId)
        {
            _contextModel.PropertyId = propertyId;
            return this;
        }
        public PropertyBuilder SetName(string name)
        {
            _contextModel.Name = name;
            return this;
        }
        public PropertyBuilder SetAddress(string address)
        {
            _contextModel.Address = address;
            return this;
        }
        public PropertyBuilder SetCity(string city)
        {
            _contextModel.City = city;
            return this;
        }
        public PropertyBuilder SetPostalCode(string postalCode)
        {
            _contextModel.PostalCode = postalCode;
            return this;
        }
        public PropertyContextModel Build()
        {
            PropertyContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}