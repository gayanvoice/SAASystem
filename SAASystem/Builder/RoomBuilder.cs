using SAASystem.Models.Context;
using System;

namespace SAASystem.Builder
{
    public class RoomBuilder
    {
        private RoomContextModel _contextModel = new RoomContextModel();
        public RoomBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _contextModel = new RoomContextModel();
        }
        public void Set(RoomContextModel contextModel)
        {
            _contextModel = contextModel;
        }
        public RoomBuilder SetRoomId(int roomId)
        {
            _contextModel.RoomId = roomId;
            return this;
        }
        public RoomBuilder SetApartmentId(int apartmentId)
        {
            _contextModel.ApartmentId = apartmentId;
            return this;
        }
        public RoomBuilder SetStatus(string status)
        {
            _contextModel.Status = status;
            return this;
        }
        public RoomContextModel Build()
        {
            RoomContextModel model = _contextModel;
            Reset();
            return model;
        }
    }
}