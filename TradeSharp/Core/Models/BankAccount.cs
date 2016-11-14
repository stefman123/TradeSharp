using System.Collections.Generic;

namespace TradeSharp.Core.Models
{
    public class BankAccount : ITransaction
    {
        public int Id { get; set; }

        //[ForeignKey("UserId")]
        //public virtual ApplicationUser User { get; set; }

        //[Required]
        //public string UserId { get; set; }
        public ICollection<Investment> Investments { get; set; }

        public decimal Balance { get; set; }
        public ApplicationUser User { get; set; }

        public bool CheckBalanceGreaterThanZero()
        {
            return Balance >= 0;
        }


        public decimal IncreaseBankAccountBalance(decimal value)
        {
            return Balance += value;
        }

        public decimal DecreaseBankAccountBalance(decimal value)
        {
            return Balance -= value;
        }

        public decimal CalculateProfitOrLoss(decimal investments)
        {
            return Balance + investments;
        }
    }
}