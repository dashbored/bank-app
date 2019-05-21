using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBank.Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<CustomersListViewModel>
    {
        public GetCustomersListQuery(int pageNumber = 1)
        {
            LinesPerPage = 50;
            PageNumber = pageNumber;
        }

        public int LinesPerPage { get; set; }
        public int PageNumber { get; set; }
        public int Offset { get { return LinesPerPage * (PageNumber - 1); } }
    }
}
