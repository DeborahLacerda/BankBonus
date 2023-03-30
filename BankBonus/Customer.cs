using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBonus
{
    public class Customer
    {
        public string Name { get; }

        private List<Account> accounts;

        public Customer(string name)
        {
            Name = name;
            accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }
    }
}