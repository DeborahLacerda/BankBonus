using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankBonus.TransactionType;

namespace BankBonus
{
    public class Checking : Account
    {
        public static decimal DailyWithdrawLimit = 300;

        public Checking(string owner, decimal balance) : base(owner, balance)
        { }

        public override bool CanWithdraw(decimal amount)
        {
            if (amount <= 0.0m)
            {
                Console.WriteLine("Withdrawal amount must be greater than zero.");
                return false;
            }
            else if (amount > DailyWithdrawLimit)
            {
                Console.WriteLine($"Withdrawal amount cannot exceed daily limit of ${DailyWithdrawLimit}.");
                return false;
            }
            else if(Balance - amount < MinBalance)
            {
                Console.WriteLine($"Insufficient funds. Current balance: ${Balance}");
                return false;
            }

            return true;
        }
    }
}
