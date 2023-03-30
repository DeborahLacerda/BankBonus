using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBonus
{
    public abstract class Account
    {
        public string Owner { get; }
        public decimal Balance { get; protected set; }
        protected decimal MinBalance;

        public Account(string owner, decimal balance, decimal minBalance = 0)
        {
            Owner = owner;
            Balance = balance;
            MinBalance = minBalance;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0.0m)
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
                return;
            }
            Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0.0m)
            {
                Console.WriteLine("Withdrawal amount must be greater than zero.");
                return;
            }
            if (Balance - amount < MinBalance)
            {
                Console.WriteLine($"Insufficient funds. Current balance: ${Balance}");
                return;
            }
            Balance -= amount;
        }

        public virtual void Transfer(Account toAccount, decimal amount)
        {
            if (amount <= 0.0m)
            {
                Console.WriteLine("Transfer amount must be greater than zero.");
                return;
            }
            if (Balance - amount < MinBalance)
            {
                Console.WriteLine($"Insufficient funds. Current balance: ${Balance}");
                return;
            }
            Balance -= amount;
            toAccount.Deposit(amount);
        }
    }
}
