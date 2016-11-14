using TradeSharp.Core.Models;

namespace TradeSharp.Core.ViewModels
{
    public class BankAccountViewModel
    {
        public string UserId { get; set; }


        public string UserName { get; set; }

        public decimal Balance { get; set; }

        public TransactionType Type { get; set; }

        public decimal Amount { get; set; }
    }
}