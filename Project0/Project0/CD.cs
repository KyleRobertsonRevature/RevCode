using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    /// <summary>
    /// 
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

        public override bool Withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
