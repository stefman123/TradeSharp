using System;

namespace TradeSharp.Core.Models
{
    public class InvestmentTransaction : Transaction
    {
        public override ITransaction AddTransaction(ITransaction transInvestment, TransactionType type)
        {
            var investment = (Investment) transInvestment;

            AccountId = investment.BankAccount.Id;
            CompanyId = investment.Company.Id;
            ShareQuantity = investment.ShareQuantity;
            Price = investment.SharePrice;
            Type = type;
            Balance = investment.BankAccount.Balance;
            Amount = investment.CalculateInvestment(investment.SharePrice, investment.ShareQuantity);
            DateTime = DateTime.Now;

            return investment;
        }
    }
}