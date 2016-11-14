using System.Collections.Generic;
using TradeSharp.Core.Models;

namespace TradeSharp.Core.ViewModels
{
    public class UserAccountCompainesViewModel
    {
        public string UserId { get; set; }


        public decimal Balance { get; set; }

        public IEnumerable<Company> Companies { get; set; }
    }
}