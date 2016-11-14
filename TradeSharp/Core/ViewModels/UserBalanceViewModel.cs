namespace TradeSharp.Core.ViewModels
{
    public class UserBalanceViewModel
    {
        public string UserId { get; set; }
        public decimal Balance { get; set; }

        public decimal Deposit { get; set; }
    }
}