using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class Loan : Account
    {
        // PROPERTIES *********************************************************
        public int TermYears { get; set; }
        // CONSTRUCTOR ********************************************************
        public Loan(int accNum, double rate)
        {
            AccountNumber = accNum;
            Balance = 0d;
            InterestRate = rate;
            AccountType = AccType.Loan;
        }
        // METHODS ************************************************************
        public override void ApplyInterest()
        {
            throw new NotImplementedException();
        }

        public override bool Deposit(double amount)
        {
            throw new NotImplementedException();
        }

        public override void DisplayDetails()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Prints an error message and returns false. Money cannot be withdrawn from loans.
        /// </summary>
        /// <param name="amount">Amount of money to be withdrawn, never valid in this class.</param>
        /// <returns>false for this class</returns>
        public override bool Withdraw(double amount)
        {
            Console.WriteLine("Error: Cannot withdraw money from a loan.");
            return false;
        }
    }
}
