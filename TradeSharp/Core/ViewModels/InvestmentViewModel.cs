using System.ComponentModel.DataAnnotations;
using TradeSharp.Core.Models;

namespace TradeSharp.Core.ViewModels
{
    public class InvestmentViewModel
    {
        public InvestmentViewModel()
        {
        }

        public InvestmentViewModel(BankAccount account, Company company)
        {
            AccountId = account.Id;
            CompanyName = company.Name;
            CompanyId = company.Id.ToString();
            Amount = 0;
            SharePrice = 0;
            ShareQuantity = 0;
        }

        public InvestmentViewModel(Investment investment)
        {
            AccountId = investment.BankAccount.Id;
            CompanyName = investment.Company.Name;
            CompanyId = investment.Company.Id.ToString();
            CurrentAmount = investment.Amount;
            Amount = 0;
            SharePrice = 0;
            ShareQuantity = 0;
            CurrentShareQuantity = investment.ShareQuantity;
            //Type = "Sel"
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public string CompanyId { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Range(1, 10000)]
        [Required(ErrorMessage = "The share quantity must be between 1 and 10000")]
        [Display(Name = "Share Quantity")]
        public int ShareQuantity { get; set; }

        [Range(1, 1000)]
        [Required(ErrorMessage = "The share price must be between £1 and £100")]
        [Display(Name = "Share Price")]
        public decimal SharePrice { get; set; }

        public TransactionType Type { get; set; }
        //{
        //    get { return Id == 0 && ? TransactionType.Buy : TransactionType.Sell; }
        //}

        public decimal Amount { get; set; }

        [Display(Name = "Current Share Value")]
        public decimal CurrentAmount { get; set; }

        [Display(Name = "Current Share Quantity")]
        public decimal CurrentShareQuantity { get; set; }
    }
}