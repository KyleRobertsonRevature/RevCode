using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    /// <summary>
    /// A business account. overdrafting is allowed, and interest is applied only to a negative balance.
    /// </summary>
    class BusinessAccount : Account
    {
        // CONSTRUCTOR ********************************************************
        public BusinessAccount(int accNum, double rate, double initialBlanace)
        {
            AccountNumber = accNum;
            Balance = initialBlanace;
            InterestRate = rate;
            AccountType = AccType.Business;
            Transactions.Add($"Initial Balance: ${Balance}");
        }

        // METHODS ************************************************************
        /// <summary>
        /// Applies interest to the balance if negative.
        /// </summary>
        public override void ApplyInterest()
        {
            if (Balance < 0d)
            {
                double interest = Balance * (InterestRate / 100);
                Balance -= interest;
                Transactions.Add($"Interest charged: ${interest}\nBalance = ${Balance}");
            }
        }

        /// <summary>
        /// Deposits the specified amount of money into the account, if valid.
        /// </summary>
        /// <param name="amount">The amount of money to be deposited.</param>
        /// <returns>A boolean representation of whether the transaction was completed.</returns>
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
        /// Displays details of the business account.
        /// </summary>
        public override void DisplayDetails()
        {
            Console.WriteLine($"Business account #{AccountNumber} has a balance of ${Balance} and an interest rate of {InterestRate}%.");
        }

        /// <summary>
        /// Withdraws the specified amount of money, if positive.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public override bool Withdraw(double amount)
        {
            if (amount > 0)
            {
                Balance -= amount;
                Transactions.Add($"Withdrawl: ${amount}\nBalance = ${Balance}");
                return true;
            }
            else
            {
                Console.WriteLine("Error: Cannot withdraw non-positive amount.");
                return false;
            }
        }
    }
}
