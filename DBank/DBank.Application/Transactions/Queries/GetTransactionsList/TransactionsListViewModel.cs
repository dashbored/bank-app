using System;
using System.Collections.Generic;
using System.Text;

namespace DBank.Application.Transactions.Queries.GetTransactionsList
{
    public class TransactionsListViewModel
    {
        public TransactionsListViewModel()
        {
            Transactions = new List<TransactionViewModel>();
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalNumberOfItems { get; set; }

        public bool CanShowMore { get; set; }

        public IList<TransactionViewModel> Transactions { get; set; }
    }
}
