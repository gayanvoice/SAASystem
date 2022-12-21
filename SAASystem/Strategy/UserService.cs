using System;

namespace SAASystem.Strategy
{
    public abstract class UserService<TModel> : IUserService
    where TModel : IUserModel
    {
        public virtual bool AppliesTo(Type provider)
        {
            return typeof(TModel).Equals(provider);
        }

        public void MakePayment<T>(T model) where T : IUserModel
        {
            MakePayment((TModel)(object)model);
        }

        protected abstract void MakePayment(TModel model);
    }
}