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
        protected double Balance { get; set; }

        /// <summary>
        /// Interest rate on the account.
        /// </summary>
        protected double InterestRate { get; set; }

        /// <summary>
        /// Type of account.
        /// </summary>
        public AccType AccountType { get; set; }

        /// <summary>
        /// List of strings reepresenting account transactions in a user-friendly format.
        /// Members should not end with newline characters.
        /// </summary>
        protected List<string> Transactions = new List<string>();

        // METHODS ************************************************************
        /// <summary>
        /// When implemented, applies interest based on the account type.
        /// </summary>
        public abstract void ApplyInterest();

        /// <summary>
        /// When implemented, should deposit the desired amount into the account, if allowed.
        /// </summary>
        /// <param name="amount">The amount of money to be deposited.</param>
        /// <returns>A boolean representation of whether the transaction was completed.</returns>
        public abstract bool Deposit(double amount);

        /// <summary>
        /// When implemented, should display the details of the account in a
        /// user-friendly format ending with a new line.
        /// </summary>
        public abstract void DisplayDetails();

        /// <summary>
        /// Displays all transactions for an account in a user-friendly way,
        /// ending with a new line.
        /// </summary>
        public void DisplayTransactions()
        {
            foreach (string transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        /// <summary>
        /// When implemented, should withdraw the desired amount from the account, if allowed.
        /// </summary>
        /// <param name="amount">The amount of money to be withdrawn.</param>
        /// <returns>A boolean representation of whether the transaction was completed.</returns>
        public abstract bool Withdraw(double amount);
    }
}
