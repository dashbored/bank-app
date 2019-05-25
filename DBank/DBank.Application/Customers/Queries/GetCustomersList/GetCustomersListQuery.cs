using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBank.Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<CustomersListViewModel>
    {
        public GetCustomersListQuery(int pageNumber = 1, string query = null)
        {
            LinesPerPage = 50;
            PageNumber = pageNumber;
            Query = query;
        }



        public int LinesPerPage { get; set; }
        public int PageNumber { get; set; }
        public int Offset => LinesPerPage * (PageNumber - 1);
        public string Query { get; set; }
    }
}
