using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    /// <summary>
    /// Static class that handles user-hidden data and functions.
    /// </summary>
    public static class Bank
    {
        // PROPERTIES *********************************************************
        private static Dictionary<int, Account> Accounts = new Dictionary<int, Account>();
        private static Dictionary<string, List<int>> UserAccounts = new Dictionary<string, List<int>>();
        private static Dictionary<string, string> UserLogins = new Dictionary<string, string>();
        private static int CurrentAccNum = 1111111111;
        private static double CheckingRate = 2.13;
        private static double BusinessRate = 13.13;
        private static double LoanRate = 31.13;
        private static double CDRate = 4.02;

        // METHODS ************************************************************
        public static bool AddUser(string username, string password)
        {
            if (UsernameAvailable(username))
            {
                UserLogins.Add(username, password);
                UserAccounts.Add(username, new List<int>());
                return true;
            }
            else
            {
                Console.WriteLine("Error: username already in use.");
                return false;
            }
        }
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

        public static void CreateAccount(string user, AccType type, double initialAmount)
        {
            List<int> userAccs;
            int accNum = GenerateAccNum();
            Account newAcc = type switch
            {
                AccType.Checking => new CheckingAccount(accNum, CheckingRate, initialAmount),
                AccType.Business => new BusinessAccount(accNum, BusinessRate, initialAmount),
                AccType.Loan => new Loan(accNum, LoanRate, initialAmount),
                AccType.CD => new CD(accNum, CDRate, initialAmount),
                _ => null
            };
            Accounts.Add(accNum, newAcc);
            UserAccounts.TryGetValue(user, out userAccs);
            userAccs.Add(accNum);
        }

        private static int GenerateAccNum()
        {
            // TODO
            return CurrentAccNum++;
        }

        public static bool LogIn(string username, string passwordAttempt)
        {
            if (UserLogins.TryGetValue(username, out string password))
            {
                if (passwordAttempt.Equals(password)) return true;
                else
                {
                    Console.WriteLine("\nError: Incorrect password.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("\nError: No such username.");
                return false;
            }
        }

        /// <summary>
        /// Returns whether the username is available.
        /// </summary>
        /// <param name="username">The username to be checked</param>
        /// <returns>Whether the username is available as a bool</returns>
        public static bool UsernameAvailable(string username)
        {
            return !(UserLogins.ContainsKey(username));
        }
    }
}
