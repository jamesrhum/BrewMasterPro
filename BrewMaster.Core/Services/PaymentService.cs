using BrewMaster.Core.Contracts;

namespace BrewMaster.Core.Services
{
    public class PaymentService : IPaymentService
    {
        public bool TryProcessPayment(decimal total, decimal paid, out decimal change)
        {
            if (paid < total)
            {
                change = 0m;
                return false;
            }

            change = paid - total;
            return true;
        }
    }
}
