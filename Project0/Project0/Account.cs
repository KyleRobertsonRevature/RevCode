using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    /// <summary>
    /// Abstract account class to be extended by account subtypes.
    /// </summary>
    abstract class Account
    {
        // PROPERTIES *********************************************************

        /// <summary>
        /// Account identification number.
        /// </summary>
        public int AccountNumber { get; set; }

        /// <summary>
        /// Amount of money in the account.
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Interest rate on the account.
        /// </summary>
        public double InterestRate { get; set; }

        /// <summary>
        /// Type of account.
        /// </summary>
        public AccType AccountType { get; set; }

        /// <summary>
        /// List of strings reepresenting account transactions in a user-friendly format. Members should not end with newline characters.
        /// </summary>
        readonly List<string> Transactions = new List<string>();

        // METHODS ************************************************************
        /// <summary>
        /// 
        /// </summary>
        public abstract void DisplayDetails();

        /// <summary>
        /// 
        /// </summary>
        public void DisplayTransactions()
        {
            foreach (string transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public abstract bool Deposit(double amount);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public abstract bool Withdraw(double amount);
    }
}
