using System.ComponentModel.DataAnnotations;

namespace TradeSharp.Core.ViewModels
{
    public class ProfitAndLossViewModel
    {
        [Display(Name = "Balance")]
        public decimal BankAccountBalance { get; set; }

        [Display(Name = "Asset Value")]
        public decimal InvestmentAmount { get; set; }

        [Display(Name = "Final Balance")]
        public decimal FinalAmount { get; set; }
    }
}