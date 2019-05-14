using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace DBank.Application.Customers.Queries.GetCustomer
{
    public class GetCustomerQuery : IRequest<CustomerViewModel>
    {
        public int Id { get; set; }
    }
}
