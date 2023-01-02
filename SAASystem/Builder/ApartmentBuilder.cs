using SAASystem.Models.Context;

namespace SAASystem.Builder
{
    public class ApartmentBuilder
    {
        private ApartmentContextModel _contextModel = new ApartmentContextModel();
        public ApartmentBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new ApartmentContextModel();
        }
        public void Set(ApartmentContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public ApartmentBuilder SetApartmentId(int apartmentId)
        {
            _contextModel.ApartmentId = apartmentId;
            return this;
        }
        public ApartmentBuilder SetPropertyId(int propertyId)
        {
            _contextModel.PropertyId = propertyId;
            return this;
        }
        public ApartmentBuilder SetSuiteId(int suiteId)
        {
            _contextModel.SuiteId = suiteId;
            return this;
        }
        public ApartmentBuilder SetCode(string code)
        {
            _contextModel.Code = code;
            return this;
        }
        public ApartmentContextModel Build()
        {
            ApartmentContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}