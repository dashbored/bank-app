using DBank.Application.Customers.Queries.GetCustomer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBank.Application.Customers.Queries.GetCustomersList
{
    public class CustomersListViewModel
    {
        public IList<CustomerViewModel> Customers { get; set; }
        public int PageNumber { get; set; }
        public int NextPageNumber => PageNumber + 1;
        public string Query { get; set; }
        public bool IsLastPage { get; set; }
    }
}
