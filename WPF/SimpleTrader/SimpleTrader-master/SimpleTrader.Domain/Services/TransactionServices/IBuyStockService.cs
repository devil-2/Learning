using SimpleTrader.Domain.Models;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services.TransactionServices
{
    public interface IBuyStockService
    {
        Task<Account> BuyStock(Account buyer, string symbol, int shares);
    }

    public interface ISellStockService
    {
        Task<Account> SellStock(Account buyer, string symbol, int shares);
    }
}
