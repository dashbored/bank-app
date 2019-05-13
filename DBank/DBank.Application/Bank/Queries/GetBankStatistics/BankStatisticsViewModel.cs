using System;
using System.Collections.Generic;
using System.Text;

namespace DBank.Application.Bank.Queries.GetBankStatistics
{
    public class BankStatisticsViewModel
    {
        public int NumberOfAccounts { get; set; }
        public int NumberOfCustomers { get; set; }
        public decimal? TotalBalance { get; set; }

    }
}
