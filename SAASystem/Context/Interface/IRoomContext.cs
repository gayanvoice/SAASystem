using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Context.Interface
{
    public interface IRoomContext
    {
        int Delete(int roomId);
        int Insert(RoomContextModel roomContextModel);
        RoomContextModel Select(int roomId);
        IEnumerable<RoomContextModel> SelectAll();
        int Update(RoomContextModel roomContextModel);
    }
}