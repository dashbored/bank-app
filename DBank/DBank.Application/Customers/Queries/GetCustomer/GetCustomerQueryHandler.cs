using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DBank.Application.Interfaces;
using MediatR;

namespace DBank.Application.Customers.Queries.GetCustomer
{
    class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerViewModel>
    {
        private readonly IBankAppDataContext _context;

        public GetCustomerQueryHandler(IBankAppDataContext context)
        {
            _context = context;
        }

        public async Task<CustomerViewModel> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers.FindAsync(request.Id);

            if (entity == null)
            {
                //TODO: Throw better exception
                throw new Exception($"Could not find customer with id: {request.Id}");
            }

            return CustomerViewModel.Create(entity);
        }
    }
}
