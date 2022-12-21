namespace SAASystem.Strategy
{
    public class Tenant : UserService<TenantUserModel>
    {
        protected override void MakePayment(TenantUserModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}