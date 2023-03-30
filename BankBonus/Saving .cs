using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankBonus
{
    public class Saving : Account
    {
        public static decimal InterestRate = 0.03m;
        public static decimal Penalty = 10;

        public Saving(string owner, decimal balance) : base(owner, balance, 0)
        {
        }

        public override void Deposit(decimal amount)
        {
            if (amount <= 0.0m)
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
                return;
            }
            decimal interest = amount * InterestRate;
            Balance += amount + interest;
            Console.WriteLine($"Deposit complete, interest earned: ${interest}");
        }

        public override void Withdraw(decimal amount)
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
            if (Balance - amount - Penalty < MinBalance)
            {
                Console.WriteLine($"Withdrawal amount + penalty cannot exceed current balance of ${Balance}. Penalty of ${Penalty} will apply.");
                amount = Balance - MinBalance + Penalty;
            }
            Balance -= amount + Penalty;
            Console.WriteLine($"Withdraw complete, penalty applied: ${Penalty}");
        }
    
    }
}