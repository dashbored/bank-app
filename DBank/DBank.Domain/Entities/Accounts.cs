using System;
using System.Collections.Generic;

namespace DBank.Domain.Entities
{
    public partial class Accounts
    {
        public Accounts()
        {
            Dispositions = new HashSet<Dispositions>();
            Transactions = new HashSet<Transactions>();
        }

        public int AccountId { get; set; }
        public string Frequency { get; set; }
        public DateTime Created { get; set; }
        public decimal? Amount { get; set; }

        public virtual ICollection<Dispositions> Dispositions { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
