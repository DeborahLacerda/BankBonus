using System;

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
                            // Display the account balances
                            Console.WriteLine($"\n{name}'s Account Balances:");
                            Console.WriteLine($"Checking Account: ${checking.Balance}");
                            Console.WriteLine($"Saving Account: ${saving.Balance}");
                        }
                        else if (accountChoiceForDeposit == 2)
                        {
                            saving.Deposit(depositAmount);
                            // Display the account balances
                            Console.WriteLine($"\n{name}'s Account Balances:");
                            Console.WriteLine($"Checking Account: ${checking.Balance}");
                            Console.WriteLine($"Saving Account: ${saving.Balance}");
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
                            // Display the account balances
                            Console.WriteLine($"\n{name}'s Account Balances:");
                            Console.WriteLine($"Checking Account: ${checking.Balance}");
                            Console.WriteLine($"Saving Account: ${saving.Balance}");
                        }
                        else if (accountChoiceForWithdraw == 2)
                        {
                            saving.Withdraw(withdrawalAmount);
                            // Display the account balances
                            Console.WriteLine($"\n{name}'s Account Balances:");
                            Console.WriteLine($"Checking Account: ${checking.Balance}");
                            Console.WriteLine($"Saving Account: ${saving.Balance}");
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid choice. Please try again.");
                            Console.WriteLine("\n--Look your Balance!--");
                            Console.WriteLine($"Checking Account: ${checking.Balance}");
                            Console.WriteLine($"Saving Account: ${saving.Balance}");
                        }
                        break;
                    case 3:
                        Console.WriteLine("\nSelect the account to transfer from:");
                        Console.WriteLine("1. Checking");
                        Console.WriteLine("2. Saving");
                        Console.Write("\nEnter your Selection (1 or 2): ");
                        int accountChoiceForTransferFrom = int.Parse(Console.ReadLine());
                        Console.Write("\nEnter the transfer amount: ");
                        decimal transferAmount = decimal.Parse(Console.ReadLine());
                        if (accountChoiceForTransferFrom == 1)
                        {
                            checking.Transfer(saving, transferAmount);
                            // Display the account balances
                            Console.WriteLine($"\n{name}'s Account Balances:");
                            Console.WriteLine($"Checking Account: ${checking.Balance}");
                            Console.WriteLine($"Saving Account: ${saving.Balance}");
                        }
                        else if (accountChoiceForTransferFrom == 2)
                        {
                            saving.Transfer(checking, transferAmount);
                            // Display the account balances
                            Console.WriteLine($"\n{name}'s Account Balances:");
                            Console.WriteLine($"Checking Account: ${checking.Balance}");
                            Console.WriteLine($"Saving Account: ${saving.Balance}");
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid choice. Please try again.");
                            // Display the account balances
                            Console.WriteLine($"\n{name}'s Account Balances:");
                            Console.WriteLine($"Checking Account: ${checking.Balance}");
                            Console.WriteLine($"Saving Account: ${saving.Balance}");
                        }
                        break;

                    case 4:
                        Console.WriteLine($"\n{name}'s Account Activities:\n");
                        checking.PrintActivity();
                        Console.WriteLine($"\nChecking Account Balance: ${checking.Balance}\n");
                        saving.PrintActivity();
                        Console.WriteLine($"\nSaving Account Balance: ${saving.Balance}");

                        break;

                    case 5:
                        Console.WriteLine($"\n{name}'s Account Balances:\n");
                        Console.WriteLine($"Checking Account: ${checking.Balance}");
                        Console.WriteLine($"Saving Account: ${saving.Balance}");
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