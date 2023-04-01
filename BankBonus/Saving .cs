using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankBonus.TransactionType;

namespace BankBonus
{
    public class Saving : Account
    {
        public static decimal InterestRate = 0.03m;
        public static decimal Penalty = 10;

        public Saving(string owner, decimal balance) : base(owner, balance, 0)
        { }

        public override void Deposit(decimal amount, TransactionType depositType)
        {
            if (amount <= 0.0m)
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
                return;
            }

            decimal interest = amount * InterestRate;

            base.Deposit(amount, depositType);
            base.Deposit(interest, TransactionType.Interest);

            Console.WriteLine($"Deposit complete, interest earned: ${interest}");
        }

        public override bool CanWithdraw(decimal amount)
        {
            if (amount <= 0.0m)
            {
                Console.WriteLine("Withdrawal amount must be greater than zero.");
                return false;
            }
            else if (Balance - amount - Penalty <= MinBalance)
            {
                Console.WriteLine($"Withdrawal amount + penalty cannot exceed current balance of ${Balance}.");
                return false;
            }

            return true;
        }

        public override void Withdraw(decimal amount, TransactionType withdrawType)
        {
            if (!CanWithdraw(amount)) {
                return;
            }

            base.Withdraw(amount, withdrawType);
            base.Withdraw(Penalty, TransactionType.Penalty);

            Console.WriteLine($"Penalty applied: ${Penalty}");
            Console.WriteLine($"Withdraw completed, account current balance ${Balance}");
        }
    }
}
