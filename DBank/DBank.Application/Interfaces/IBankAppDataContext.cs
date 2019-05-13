using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using DBank.Domain.Entities;


namespace DBank.Application.Interfaces
{
    public interface IBankAppDataContext
    {

        DbSet<Account> Accounts { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Disposition> Dispositions { get; set; }
        DbSet<Transaction> Transactions { get; set; }
    }
}
