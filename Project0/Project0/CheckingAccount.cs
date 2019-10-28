using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    /// <summary>
    /// Checking account class. overdrafting is not allowed, interest is earned on the balance.
    /// </summary>
    class CheckingAccount : Account
    {
        // CONSTRUCTOR ********************************************************
        public CheckingAccount(int accNum, double rate, double initialBalance)
        {
            AccountNumber = accNum;
            Balance = initialBalance;
            InterestRate = rate;
            AccountType = AccType.Checking;
            Transactions.Add($"Initial Balance: ${Balance}");
        }

        // METHODS ************************************************************
        /// <summary>
        /// Applies interest to the balance of the account.
        /// </summary>
        public override void ApplyInterest()
        {
            if (Balance > 0d)
            {
                double earned = Balance * (InterestRate / 100d);
                Balance += earned;
                Transactions.Add($"Interest earned: ${earned}\nBalance = ${Balance}");
            }
        }

        /// <summary>
        /// Deposits an amount of money into the account, if positive
        /// </summary>
        /// <param name="amount">The amount of money to be deposited. Invalid if negative or zero.</param>
        /// <returns>A boolean represention of whether the transaction was completed.</returns>
        public override bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Transactions.Add($"Deposit: ${amount}\nBalance = ${Balance}");
                return true;
            }
            else
            {
                Console.WriteLine("Error: Cannot deposit a non-positive amount.");
                return false;
            }
        }

        /// <summary>
        /// Displays details of the checking account.
        /// </summary>
        public override void DisplayDetails()
        {
            Console.WriteLine($"Checking account #{AccountNumber} has a balance of ${Balance} and an interest rate of {InterestRate}%.");
        }

        /// <summary>
        /// Withdraws the requested amount, if the balance is high enough.
        /// </summary>
        /// <param name="amount">The amount of money to be withdrawn. invalid if non-positive.</param>
        /// <returns>A boolean representation of whether the transaction was completed.</returns>
        public override bool Withdraw(double amount)
        {
            double dif = Balance - amount;
            if (amount > 0)
            {
                if (dif >= 0)
                {
                    Balance -= amount;
                    Transactions.Add($"Withdrawl: ${amount}\nBalance = ${Balance}");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: Not enough money in account for this withdrawl.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Error: Cannot withdraw non-positive amount.");
                return false;
            }
        }
    }
}
