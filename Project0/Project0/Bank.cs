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
        private static Dictionary<string, string> Users = new Dictionary<string, string>();
        private static int CurrentAccNum = 1111111111;

        // METHODS ************************************************************
        public static void AddUser(string username, string password)
        {
            if (UsernameAvailable(username))
            {
                Users.Add(username, password);
            }
            else Console.WriteLine("Error: username already in use.");
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

        public static void CreateAccount(AccType type, double initialAmount)
        {

        }

        private static int GenerateAccNum()
        {
            // TODO
            return CurrentAccNum++;
        }

        public static bool LogIn(string username, string passwordAttempt)
        {
            if (Users.TryGetValue(username, out string password))
            {
                if (passwordAttempt.Equals(password)) return true;
                else
                {
                    Console.WriteLine("Error: Incorrect password.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Error: No such username.");
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
            return !(Users.ContainsKey(username));
        }
    }
}
