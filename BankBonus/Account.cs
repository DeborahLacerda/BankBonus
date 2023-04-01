using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankBonus.TransactionType;

namespace BankBonus
{
    public abstract class Account
    {
        public string Owner { get; }
        public decimal Balance { get; protected set; }
        protected decimal MinBalance;

        
        protected List<Transaction> transactions;

        public Account(string owner, decimal balance, decimal minBalance = 0)
        {
            Owner = owner;
            Balance = balance;
            MinBalance = minBalance;
            transactions = new List<Transaction>(); 
                
        }

        public virtual void Deposit(decimal amount)
        {
            Deposit(amount, TransactionType.Deposit);
        }
        public virtual void Deposit(decimal amount, TransactionType type)
        {
            if (amount <= 0.0m)
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
                return;
            }
            Balance += amount;
            transactions.Add(new Transaction(amount, DateTime.Now, type));

        }

        public abstract bool CanWithdraw(decimal amount);
        public virtual void Withdraw(decimal amount)
        {
            Withdraw(amount, TransactionType.Withdraw);
        }
        public virtual void Withdraw(decimal amount, TransactionType type)
        {
            if (!CanWithdraw(amount))
            {
                return;
            }

            Balance -= amount;
            transactions.Add(new Transaction(amount, DateTime.Now, type));
            Console.WriteLine($"Withdraw complete.");
        }

        public void Transfer(Account toAccount, decimal amount)
        {
            if (!CanWithdraw(amount))
            {
                return;
            }

            Withdraw(amount, TransactionType.TransferOut);
            toAccount.Deposit(amount, TransactionType.TransferIn);
        }

        public void PrintActivity()
        {
            Console.WriteLine("Transaction history for Checking Account:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }

    }
}
