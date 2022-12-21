namespace SAASystem.Strategy
{
    public class Employee : UserService<EmployeeUserModel>
    {
        protected override void MakePayment(EmployeeUserModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}