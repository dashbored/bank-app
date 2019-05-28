using DBank.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DBank.Application.Transactions.Queries.GetTransactionsList
{
    public class GetTransactionsListQueryHandler : IRequestHandler<GetTransactionsListQuery, TransactionsListViewModel>
    {
        private readonly IBankAppDataContext _context;

        public GetTransactionsListQueryHandler(IBankAppDataContext context)
        {
            _context = context;
        }

        public async Task<TransactionsListViewModel> Handle(GetTransactionsListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.Transactions.Where(t => t.AccountId == request.AccountId).Skip(50).Take(50).ToListAsync(cancellationToken);

            if (entities == null)
            {
                throw new Exception($"Could not find account with id: {request.AccountId}");
            }

            var transactions = new List<TransactionViewModel>();

            foreach (var transaction in entities)
            {
                transactions.Add(TransactionViewModel.Create(transaction));
            }

            var model = new TransactionsListViewModel
            {
                Transactions = transactions,
                PageSize = request.PageSize,
                PageNumber = request.PageNumber,
                TotalNumberOfItems = request.TotalNumberOfItems,
                CanShowMore = (request.PageSize * request.PageNumber) < request.TotalNumberOfItems
            };

            throw new NotImplementedException();
        }
    }
}
