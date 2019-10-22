using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    /// <summary>
    /// 
    /// </summary>
    class BusinessAccount : Account
    {
        // CONSTRUCTOR ********************************************************
        public BusinessAccount(int accNum, double rate)
        {
            AccountNumber = accNum;
            Balance = 0d;
            InterestRate = rate;
            AccountType = AccType.Business;
        }

        // METHODS ************************************************************
        /// <summary>
        /// 
        /// </summary>
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
