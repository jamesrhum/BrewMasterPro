using BrewMaster.Core.Models;

namespace BrewMaster.Core.Contracts
{
    public interface IOrderable
    {
        bool TryProcessPayment(decimal total, decimal paid, out decimal change);
    }
}