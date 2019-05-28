using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBank.Application.Transactions.Queries.GetTransactionsList
{
    public class GetTransactionsListQuery : IRequest<TransactionsListViewModel>
    {
        public int AccountId { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalNumberOfItems { get; set; }

        public bool CanShowMore { get; set; }
    }
}
