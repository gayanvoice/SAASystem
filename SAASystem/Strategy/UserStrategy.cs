using System;
using System.Collections.Generic;
using System.Linq;

namespace SAASystem.Strategy
{
    public class UserStrategy : IUserStrategy
    {
        private readonly IEnumerable<IUserService> paymentServices;

        public UserStrategy(IEnumerable<IUserService> paymentServices)
        {
            this.paymentServices = paymentServices ?? throw new ArgumentNullException(nameof(paymentServices));
        }

        public void MakePayment<T>(T model) where T : IUserModel
        {
            GetPaymentService(model).MakePayment(model);
        }

        private IUserService GetPaymentService<T>(T model) where T : IUserModel
        {
            var result = paymentServices.FirstOrDefault(p => p.AppliesTo(model.GetType()));
            if (result == null)
            {
                throw new InvalidOperationException($"Payment service for {model.GetType().ToString()} not registered.");
            }
            return result;
        }
    }
}