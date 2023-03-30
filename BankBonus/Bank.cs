using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankBonus
{
    class Bank
    {
        static void Main(string[] args)
        {
            // Prompt the user for their name
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            // Create a new customer with the entered name
            Customer customer = new Customer(name);

            // Create a checking account and a savings account for the customer
            Checking checking = new Checking(customer.Name, 0);
            Saving saving = new Saving(customer.Name, 0);

            // Loop until the user chooses to exit
            while (true)
            {
                // Display the account balances
                Console.WriteLine($"\n{name}'s Account Balances:");
                Console.WriteLine($"Checking Account: ${checking.Balance}");
                Console.WriteLine($"Saving Account: ${saving.Balance}");

                // Display the menu
                Console.WriteLine("\nSelect one of the following activities:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Activity Enquiry");
                Console.WriteLine("5. Balance Enquiry");
                Console.WriteLine("6. Exit");
                Console.Write("\nEnter your Selection (1 to 6): ");

                // Prompt the user for their choice
                int choice = int.Parse(Console.ReadLine());

                // Perform the selected action
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nSelect the account to deposit to:");
                        Console.WriteLine("1. Checking");
                        Console.WriteLine("2. Saving");
                        Console.Write("\nEnter your Selection (1 or 2): ");
                        int accountChoiceForDeposit = int.Parse(Console.ReadLine());
                        Console.Write("\nEnter the deposit amount: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());
                        if (accountChoiceForDeposit == 1)
                        {
                            checking.Deposit(depositAmount);
                        }
                        else if (accountChoiceForDeposit == 2)
                        {
                            saving.Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid choice. Please try again.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("\nSelect the account to withdraw from:");
                        Console.WriteLine("1. Checking");
                        Console.WriteLine("2. Saving");
                        Console.Write("\nEnter your Selection (1 or 2): ");
                        int accountChoiceForWithdraw = int.Parse(Console.ReadLine());
                        Console.Write("\nEnter the withdrawal amount: ");
                        decimal withdrawalAmount = decimal.Parse(Console.ReadLine());
                        if (accountChoiceForWithdraw == 1)
                        {
                            checking.Withdraw(withdrawalAmount);
                        }
                        else if (accountChoiceForWithdraw == 2)
                        {
                            saving.Withdraw(withdrawalAmount);
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid choice. Please try again.");
                        }
                        break;

                    case 3:
                       
                    case 4:
                  

                    case 5:
                        Console.WriteLine("\nSelect the account to view balance:");
                        Console.WriteLine("1. Checking");
                        Console.WriteLine("2. Saving");
                        Console.Write("\nEnter your Selection (1 or 2): ");
                        int accountChoiceForBalance = int.Parse(Console.ReadLine());
                        if (accountChoiceForBalance == 1)
                        {
                            Console.WriteLine($"\nChecking Account Balance: ${checking.Balance}");
                        }
                        else if (accountChoiceForBalance == 2)
                        {
                            Console.WriteLine($"\nSaving Account Balance: ${saving.Balance}");
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid choice. Please try again.");
                        }
                        break;

                    case 6:
                        Console.WriteLine("\nThank you for using our banking system. Goodbye!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
