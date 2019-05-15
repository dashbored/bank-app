using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DBank.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBank.Application.Bank.Queries.GetBankStatistics
{
    public class GetBankStatisticsQueryHandler : IRequestHandler<GetBankStatisticsQuery, BankStatisticsViewModel>
    {
        private readonly IBankAppDataContext _context;

        public GetBankStatisticsQueryHandler(IBankAppDataContext context)
        {
            _context = context;
        }

        public async Task<BankStatisticsViewModel> Handle(GetBankStatisticsQuery request, CancellationToken cancellationToken)
        {
            var numberOfAccounts = await _context.Accounts.CountAsync(cancellationToken);
            var numberOfCustomers = await _context.Customers.CountAsync(cancellationToken);
            var totalBalance = await _context.Accounts.SumAsync(b => b.Balance, cancellationToken);

            var model = new BankStatisticsViewModel
            {
                NumberOfAccounts = numberOfAccounts,
                NumberOfCustomers = numberOfCustomers,
                TotalBalance = totalBalance
            };

            return model;


        }
    }
}
