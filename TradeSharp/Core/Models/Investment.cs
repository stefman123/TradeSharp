namespace TradeSharp.Core.Models
{
    public class Investment : ITransaction
    {
        public Investment()
        {
        }

        public Investment(BankAccount account, Company company)
        {
            BankAccount = account;
            Company = company;
            //Amount = amount;
            //SharePrice = investment.SharePrice;
            //ShareQuantity = investment.ShareQuantity;
        }

        public int Id { get; set; }
        public BankAccount BankAccount { get; set; }
        //public string UserAccountId { get; set; }
        public Company Company { get; set; }
        //public string CompanyId { get; set; }
        public int ShareQuantity { get; set; }
        public decimal SharePrice { get; set; }
        public decimal Amount { get; set; }

        public void CalCurrentInvestmentAmountAndShareQuantity(decimal sharePrice, int shareQuantity,
            TransactionType type)
        {
            SharePrice = sharePrice;

            if (type == TransactionType.Buy)
            {
                ShareQuantity += shareQuantity;
                Amount += CalculateInvestment(sharePrice, shareQuantity);
            }
            else
            {
                ShareQuantity -= shareQuantity;
                Amount -= CalculateInvestment(sharePrice, shareQuantity);
            }
        }

        public decimal CalculateInvestment(decimal sharePrice, int shareQuantity)
        {
            return sharePrice*shareQuantity;
        }


        public void CalculateNewInvestmentAmount(decimal sharePrice, int shareQuantity)
        {
            SharePrice = sharePrice;
            ShareQuantity = shareQuantity;
            Amount = CalculateInvestment(sharePrice, shareQuantity);
        }

        public void AddInvestmentSaleToBankAccount(BankAccount account)
        {
            account.DecreaseBankAccountBalance(Amount);
        }

        public void DecreaseInvestmentCostToBankAccount(BankAccount account)
        {
            account.DecreaseBankAccountBalance(Amount);
        }
    }
}