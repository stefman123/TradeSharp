using System;

namespace TradeSharp.Core.Models
{
    public class BankAccountTransaction : Transaction
    {
        public override ITransaction AddTransaction(ITransaction investment, TransactionType type)
        {
            var bankAccount = (BankAccount) investment;

            Amount = bankAccount.Balance;
            DateTime = DateTime.Now;
            Type = type;
            AccountId = bankAccount.Id;
            Balance = bankAccount.Balance;

            return investment;
        }
    }
}