using DBank.Application.Customers.Queries.GetCustomer;
using DBank.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DBank.Application.Customers.Queries.GetCustomersList
{
    class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, CustomersListViewModel>
    {
        private readonly IBankAppDataContext _context;

        public GetCustomersListQueryHandler(IBankAppDataContext context)
        {
            _context = context;
        }
        public async Task<CustomersListViewModel> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers.Skip(request.Offset).Take(request.LinesPerPage).Select(c => CustomerViewModel.Create(c)).ToListAsync();

            if (entity == null)
            {
                //TODO: Implement better exception
                throw new Exception("Could not find customers");
            }


            var model = new CustomersListViewModel
            {
                Customers = entity,
                PageNumber = request.PageNumber
            };

            return model;
            
        }
    }
}
