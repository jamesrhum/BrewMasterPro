namespace BrewMaster.Core.Contracts
{
    public interface IPaymentService
    {
        bool TryProcessPayment(decimal total, decimal paid, out decimal change);
    }
}