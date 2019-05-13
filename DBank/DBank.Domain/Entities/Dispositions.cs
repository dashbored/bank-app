using System;
using System.Collections.Generic;

namespace DBank.Domain.Entities
{
    public partial class Dispositions
    {
        public int DispositionId { get; set; }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public string Type { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
