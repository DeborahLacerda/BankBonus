using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBonus
{
    public class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public TransactionType Type { get; }

        public Transaction(decimal amount, DateTime date, TransactionType type)
        {
            Amount = amount;
            Date = date;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Amount,12:C2} {Date,15:MM/dd/yyyy} {Type,20}";
        }
    }

    public enum TransactionType
    {
        Deposit,
        Withdraw,
        TransferIn,
        TransferOut,
        Interest,
        Penalty
    }
}