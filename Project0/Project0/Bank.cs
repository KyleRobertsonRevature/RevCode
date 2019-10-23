using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    /// <summary>
    /// Static class that handles account creation, interest rates and application, and CD maturity.
    /// </summary>
    public static class Bank
    {
        // PROPERTIES *********************************************************
        private static readonly Dictionary<int, Account> Accounts = new Dictionary<int, Account>();
        private static int CurrentAccNum = 0;

        // METHODS ************************************************************
        public static bool CanDeposit(int accNum)
        {
            // TODO
            return false;
        }

        public static bool CanWithdraw(int accNum)
        {
            // TODO
            return false;
        }

        public static void ChargeInterest()
        {
            // TODO
        }

        private static int GenerateAccNum()
        {
            // TODO
            return 0;
        }
    }
}
