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

        DbSet<Accounts> Accounts { get; set; }
        DbSet<Customers> Customers { get; set; }
        DbSet<Dispositions> Dispositions { get; set; }
        DbSet<Transactions> Transactions { get; set; }
    }
}
