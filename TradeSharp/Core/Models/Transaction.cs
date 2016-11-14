using System;

namespace TradeSharp.Core.Models
{
    public abstract class Transaction
    {
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Balance { get; set; }
        public decimal Amount { get; set; }
        public int ShareQuantity { get; set; }
        public decimal Price { get; set; }
        public int AccountId { get; set; }
        public int CompanyId { get; set; }

        public abstract ITransaction AddTransaction(ITransaction investment, TransactionType type);
    }
}