using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    /// <summary>
    /// Account for a loan. Cannot have a negative amount owed.
    /// </summary>
    class Loan : Account
    {
        // CONSTRUCTOR ********************************************************
        public Loan(int accNum, double rate, double initialBalance)
        {
            AccountNumber = accNum;
            Balance = initialBalance;
            InterestRate = rate;
            AccountType = AccType.Loan;
            Transactions.Add($"Initial Amount Owed: ${Balance}");
        }

        // METHODS ************************************************************
        /// <summary>
        /// Applies interest if the loan has a balance.
        /// </summary>
        public override void ApplyInterest()
        {
            if (Balance > 0d)
            {
                double charged = Balance * (InterestRate / 100d);
                Balance += charged;
                Transactions.Add($"Interest charged: ${charged}\nBalance Owed = ${Balance}");
            }
        }

        /// <summary>
        /// Pays the specified amount off the loan. Fails if given a non-positive amount or payment is greater than current balance.
        /// </summary>
        /// <param name="amount">The amount to be paid off the loan.</param>
        /// <returns>A boolean representing whether the transaction was completed.</returns>
        public override bool Deposit(double amount)
        {
            if (amount > 0d)
            {
                double dif = Balance - amount;
                if (dif < 0d)
                {
                    Console.WriteLine("Error: Cannot pay more than balance owed.");
                    return false;
                }
                else
                {
                    Balance = dif;
                    Transactions.Add($"Payment made: ${amount}\nBalance Owed = ${Balance}");
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Error: Cannot pay a non-positive amount.");
                return false;
            }
        }

        /// <summary>
        /// Displays details of the loan.
        /// </summary>
        public override void DisplayDetails()
        {
            Console.WriteLine($"Loan #{AccountNumber} has a balance owed of ${Balance} and an interest rate of {InterestRate}%.");
        }

        /// <summary>
        /// Prints an error message and returns false. Money cannot be withdrawn from loans.
        /// </summary>
        /// <param name="amount">Amount of money to be withdrawn, never valid in this class.</param>
        /// <returns>false for this class.</returns>
        public override bool Withdraw(double amount)
        {
            Console.WriteLine("Error: Cannot withdraw money from a loan.");
            return false;
        }
    }
}
