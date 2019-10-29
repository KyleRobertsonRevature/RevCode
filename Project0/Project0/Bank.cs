using System;
using System.Collections;
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
        private static readonly Dictionary<int, Account> Accounts = new Dictionary<int, Account>();
        private static readonly Dictionary<string, ArrayList> UserAccounts = new Dictionary<string, ArrayList>();
        private static readonly Dictionary<string, string> UserLogins = new Dictionary<string, string>();
        private static int CurrentAccNum = 1111111111;
        private static readonly double CheckingRate = 1.02;
        private static readonly double BusinessRate = 13.13;
        private static readonly double LoanRate = 31.13;
        private static readonly double CDRate = 2.12;

        // METHODS ************************************************************

        /*
         * if (UserAccounts.TryGetValue(username, out ArrayList accNums))
            {
                if (Accounts.TryGetValue((int)accNums[index], out Account account))
                {

                }
                else
                {

                }
            }
            else
            {

            }
         */

        public static bool AddUser(string username, string password)
        {
            if (UsernameAvailable(username))
            {
                UserLogins.Add(username, password);
                UserAccounts.Add(username, new ArrayList());
                return true;
            }
            else
            {
                Console.WriteLine("Error: username already in use.");
                return false;
            }
        }

        public static bool CanDeposit(string username, int index)
        {
            if (UserAccounts.TryGetValue(username, out ArrayList accNums))
            {
                if (Accounts.TryGetValue((int)accNums[index], out Account account))
                {
                    AccType type = account.AccountType;
                    return type switch
                    {
                        AccType.Checking => true,
                        AccType.Business => true,
                        AccType.Loan => true,
                        AccType.CD => false,
                        _ => false,
                    };
                }
                else
                {
                    Console.WriteLine($"\nError: Account not found.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"\nError: Accounts not found for user {username}.");
                return false;
            }
        }

        public static bool CanWithdraw(string username, int index)
        {
            if (UserAccounts.TryGetValue(username, out ArrayList accNums))
            {
                if (Accounts.TryGetValue((int)accNums[index], out Account account))
                {
                    AccType type = account.AccountType;
                    return type switch
                    {
                        AccType.Checking => true,
                        AccType.Business => true,
                        AccType.Loan => false,
                        AccType.CD => ((CD)account).IsMature,
                        _ => false
                    };
                }
                else
                {
                    Console.WriteLine($"\nError: Account not found.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"\nError: Accounts not found for user {username}.");
                return false;
            }
        }

        public static void ChargeInterest()
        {
            // TODO
        }

        public static void CloseAccount(string username, int index)
        {
            if (UserAccounts.TryGetValue(username, out ArrayList accNums))
            {
                if (Accounts.TryGetValue((int)accNums[index], out _))
                {
                    Accounts.Remove((int)accNums[index]);
                    accNums.RemoveAt(index);
                    return;
                }
                else
                {
                    Console.WriteLine($"\nError: Account not found.");
                    return;
                }
            }
            else
            {
                Console.WriteLine($"\nError: Accounts not found for user {username}.");
                return;
            }
        }

        public static void CreateAccount(string user, AccType type, double initialAmount)
        {
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
            UserAccounts.TryGetValue(user, out ArrayList userAccs);
            userAccs.Add(accNum);
        }

        private static int GenerateAccNum()
        {
            return CurrentAccNum++;
        }

        public static bool HasAccounts(string username)
        {
            if (UserAccounts.TryGetValue(username, out ArrayList accNums))
            {
                if (accNums.Count == 0) return false;
                else return true;
            }
            else return false;
        }

        public static int ListAccountOptions(string username)
        {
            if (UserAccounts.TryGetValue(username, out ArrayList accNums))
            {
                for (int i = 0; i < accNums.Count; i++)
                {
                    if (Accounts.TryGetValue((int)accNums[i], out Account account))
                    {
                        Console.Write("< " + (i + 1) + " > ");
                        string typeString = account.AccountType switch
                        {
                            AccType.Checking => "Checking",
                            AccType.Business => "Business",
                            AccType.Loan => "Loan",
                            AccType.CD => "Term Deposit",
                            _ => "Undefined"
                        };
                        Console.WriteLine(typeString + " Account #" + accNums[i]);
                    }
                    else
                    {
                        Console.WriteLine($"\nError: Account referenced at index {i} in UserAccounts was not found in Accounts.");
                        return 0;
                    }
                }
                return accNums.Count;
            }
            else
            {
                Console.WriteLine($"\nError: Accounts not found for user {username}.");
                return 0;
            }
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

        public static bool Withdraw(string username, int index, double amount)
        {
            if (UserAccounts.TryGetValue(username, out ArrayList accNums))
            {
                if (Accounts.TryGetValue((int)accNums[index], out Account account))
                {
                    return account.Withdraw(amount);
                }
                else
                {
                    Console.WriteLine($"\nError: Account not found.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"\nError: Accounts not found for user {username}.");
                return false;
            }
        }
    }
}
