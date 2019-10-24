using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    /// <summary>
    /// Account for a CD. Cannot be deposited into, can only be withdrawn from when mature.
    /// </summary>
    class CD : Account
    {
        // PARAMETERS *********************************************************
        /// <summary>
        /// boolean representing whether the CD is mature.
        /// </summary>
        public bool IsMature;

        // CONSTRUCTOR ********************************************************
        public CD(int accNum, double rate)
        {
            AccountNumber = accNum;
            Balance = 0d;
            InterestRate = rate;
            AccountType = AccType.CD;
            IsMature = false;
        }

        // METHODS ************************************************************
        /// <summary>
        /// Applies interest to the CD's balance
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
        /// Returns an arror message. CDs cannot be deposited into.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public override bool Deposit(double amount)
        {
            throw new NotImplementedException();
        }

        public override void DisplayDetails()
        {
            throw new NotImplementedException();
        }

        public override bool Withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
