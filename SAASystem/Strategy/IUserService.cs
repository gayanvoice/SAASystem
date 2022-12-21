using System;

namespace SAASystem.Strategy
{
    public interface IUserService {
        void MakePayment<T>(T model) where T : IUserModel;
        bool AppliesTo(Type provider);
    }
}