using System;
using System.Collections.Generic;
using System.Text;
using DBank.Domain.Entities;

namespace DBank.Application.Customers.Queries.GetCustomer
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Givenname { get; set; }
        public string Surname { get; set; }
        public string Fullname => Givenname + " " + Surname;

        public string Streetaddress { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string Emailaddress { get; set; }
        public string NationalId { get; set; }

        public static CustomerViewModel Create(Customer customer)
        {
            return new CustomerViewModel
            {
                Id = customer.CustomerId,
                Givenname = customer.Givenname,
                Surname = customer.Surname,
                Streetaddress = customer.Streetaddress,
                City = customer.City,
                Zipcode = customer.Zipcode,
                Country = customer.Country,
                Emailaddress = customer.Emailaddress,
                NationalId = customer.NationalId
            };
        }
    }
}
