namespace SAASystem.Strategy
{
    public interface IUserStrategy {
        void MakePayment<T>(T model) where T : IUserModel;
    }
}