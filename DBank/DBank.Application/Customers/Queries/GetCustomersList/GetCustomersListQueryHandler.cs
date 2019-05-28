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
            IList<CustomerViewModel> entity;
            IQueryable<Domain.Entities.Customer> query;

            if (request.Query == null)
            {
                 query =  _context.Customers;
                    //.Skip(request.Offset).Take(request.LinesPerPage).Select(c => CustomerViewModel.Create(c)).ToListAsync(cancellationToken);
            }
            else
            {
                query = _context.Customers.Where(c =>
                        c.City.Contains(request.Query, StringComparison.InvariantCultureIgnoreCase) ||
                        c.Surname.Contains(request.Query, StringComparison.InvariantCultureIgnoreCase) ||
                        c.Givenname.Contains(request.Query, StringComparison.InvariantCultureIgnoreCase));
                    //.Skip(request.Offset).Take(request.LinesPerPage).Select(c => CustomerViewModel.Create(c))
                    //.ToListAsync(cancellationToken);
            }

            if (query == null)
            {
                //TODO: Implement better exception
                throw new Exception("Could not find customers");
            }

            entity = await query.Skip(request.Offset).Take(request.LinesPerPage).Select(c => CustomerViewModel.Create(c))
                    .ToListAsync(cancellationToken);

            var isLastPage = (request.Offset + entity.Count()).Equals(query.Count());

            var model = new CustomersListViewModel
            {
                Customers = entity,
                PageNumber = request.PageNumber,
                Query = request.Query,
                IsLastPage = isLastPage
            };

            return model;

        }
    }
}
