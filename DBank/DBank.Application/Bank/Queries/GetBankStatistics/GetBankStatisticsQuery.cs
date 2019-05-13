using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace DBank.Application.Bank.Queries.GetBankStatistics
{
    public class GetBankStatisticsQuery : IRequest<BankStatisticsViewModel>
    {
    }
}
