using DBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBank.Application.Transactions.Queries.GetTransactionsList
{
    public class TransactionViewModel
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public decimal Balance { get; set; }

        public static TransactionViewModel Create(Transaction transaction)
        {
            return new TransactionViewModel
            {
                Id = transaction.TransactionId,
                Balance = transaction.Balance,
                Amount = transaction.Amount
            };
        }
    }
}
