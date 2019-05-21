using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBank.Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<CustomersListViewModel>
    {

        public GetCustomersListQuery()
        {
            LinesPerPage = 50;
            PageNumber = 1;
        }

        public int LinesPerPage { get; set; }
        public int PageNumber { get; set; }
        public int Offset { get { return LinesPerPage * (PageNumber - 1); } }
    }
}
