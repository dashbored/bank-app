using DBank.Application.Customers.Queries.GetCustomer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBank.Application.Customers.Queries.GetCustomersList
{
    public class CustomersListViewModel
    {
        public IList<CustomerViewModel> Customers { get; set; }
    }
}
