using System;

namespace Project0
{
    class UI
    {
        // PROPERTIES *********************************************************
        static string CurrentUser { get; set; }

        // MAIN ***************************************************************
        static void Main()
        {
            // loop back to login page until program terminated
            bool running;
            do
            {
                running = MainDisplay();
            }
            while (running);
            Console.WriteLine("\nEnding Program...");
        }

        // METHODS ************************************************************
        static void CloseAccount()
        {
            if (Bank.HasAccounts(CurrentUser))
            {
                Console.WriteLine("\nWhich account would you like to close?");
                int numAccounts = Bank.ListAccountOptions(CurrentUser);
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    if (input > 0 && input <= numAccounts)
                    {
                        Bank.CloseAccount(CurrentUser, (input - 1));
                        Console.WriteLine("\nAccount closed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("\nError: Invalid input.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: invalid input format.");
                    return;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\nError: Amount entered was too large.");
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message);
                    return;
                }
            }
            else
            {
                Console.WriteLine("\nThere are no accounts listed for this user.");
                return;
            }
        }

        static void Deposit()
        {
            if (Bank.HasAccounts(CurrentUser))
            {
                Console.WriteLine("\nWhich account would you like to deposit to?");
                int numAccounts = Bank.ListAccountOptions(CurrentUser);
                Console.WriteLine();
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    if (input > 0 && input <= numAccounts)
                    {
                        if (Bank.CanDeposit(CurrentUser, input - 1))
                        {
                            Console.WriteLine("\nHow much would you like to deposit?");
                            try
                            {
                                double amount = Convert.ToDouble(Console.ReadLine());
                                if (amount > 0)
                                {
                                    if (Bank.Deposit(CurrentUser, input - 1, amount))
                                    {
                                        Console.WriteLine("\nDeposit completed successfully.");
                                    }
                                }
                                else Console.WriteLine("\nError: Amount must be positive.");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\nError: Invalid input format.");
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("\nError: Input was too large.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else Console.WriteLine("\nError: cannot deposit to this account.");
                    }
                    else Console.WriteLine("\nError: Invalid input.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: Invalid input format.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\nError: Input was too large.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message);
                }
            }
            else Console.WriteLine("\nThere are no accounts listed for this user.");
        }

        static void LoggedIn()
        {
            bool loggedIn = true;
            while (loggedIn)
            {
                Console.WriteLine($"\nWelcome, {CurrentUser}. What would you like to do?\n" +
                    $"< 1 > Open a new account\n< 2 > Close an account\n< 3 > Withdraw funds\n" +
                    $"< 4 > Deposit funds\n< 5 > Transfar funds\n< 6 > Display all accounts\n" +
                    $"< 7 > Display transactions for an account\n< 8 > Log out\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        NewAccount();
                        break;
                    case "2":
                        CloseAccount();
                        break;
                    case "3":
                        Withdraw();
                        break;
                    case "4":
                        Deposit();
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":
                        loggedIn = false;
                        Console.WriteLine("\nLogout successful.");
                        break;
                    default:
                        Console.WriteLine("\nError: Invalid input.");
                        break;
                }
            }
        }

        static void LogIn()
        {
            Console.WriteLine("\nPlease enter your username:");
            string username = Console.ReadLine();
            if (Bank.UsernameAvailable(username))
            {
                Console.WriteLine("\nError: Username not found.");
                return;
            }
            else
            {
                Console.WriteLine($"\nPassword for user {username}:");
                string password = Console.ReadLine();

                if (Bank.LogIn(username, password))
                {
                    CurrentUser = username;
                    LoggedIn();
                    return;
                }
                else return;
            }
        }

        static bool MainDisplay()
        {
            Console.WriteLine("\nWelcome! Please create a new account or log in an existing user.\n" +
                "< 0 > End Program\n< 1 > Create New User Account\n< 2 > Log In\n");
            string input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    return false;
                case "1":
                    NewUser();
                    return true;
                case "2":
                    LogIn();
                    return true;
                default:
                    Console.WriteLine("\nError: Invalid input.");
                    return true;
            }
        }

        static void NewAccount()
        {
            Console.WriteLine("\nWhat type of account would you like to open?\n< 1 > Checking Account" +
                "\n< 2 > Business Account\n< 3 > Loan\n< 4 > Term Deposit\n");
            string input = Console.ReadLine();
            AccType type;
            switch (input)
            {
                case "1":
                    type = AccType.Checking;
                    Console.WriteLine("\nPlease enter the initial balance:\n");
                    break;
                case "2":
                    type = AccType.Business;
                    Console.WriteLine("\nPlease enter the initial balance:\n");
                    break;
                case "3":
                    type = AccType.Loan;
                    Console.WriteLine("\nPlease enter the loan amount:\n");
                    break;
                case "4":
                    type = AccType.CD;
                    Console.WriteLine("\nPlease enter the deposit amount:\n");
                    break;
                default:
                    Console.WriteLine("\nError: Invalid input.");
                    return;
            }
            try
            {
                double amount = Convert.ToDouble(Console.ReadLine());
                if (amount > 0)
                {
                    Bank.CreateAccount(CurrentUser, type, amount);
                    Console.WriteLine("\nAccount created succesfully.");
                    return;
                }
                else
                {
                    Console.WriteLine("\nError: Amount must be positive.");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nError: Entry was not of a numeric type.");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nError: Entered amount was too large.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        static void NewUser()
        {
            Console.WriteLine("\nWelcome, new user! To create an account, please enter a username:");
            string username = Console.ReadLine();
            if (username.Equals(""))
            {
                Console.WriteLine("\nError: Username field cannot be blank.");
                return;
            }
            else if (Bank.UsernameAvailable(username))
            {
                Console.WriteLine($"\nPlease enter a password for user {username}:");
                string firstPW = Console.ReadLine();
                Console.WriteLine("\nConfirm password:");
                string secondPW = Console.ReadLine();
                if (firstPW.Equals(secondPW))
                {
                    if (firstPW.Equals(""))
                    {
                        Console.WriteLine("\nError: Password field cannot be blank.");
                        return;
                    }
                    else
                    {
                        if (Bank.AddUser(username, firstPW))
                        {
                            CurrentUser = username;
                            LoggedIn();
                            return;
                        }
                        else return;
                    }
                }
                else
                {
                    Console.WriteLine("\nError: Passwords did not match.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("\nError: Username already in use.");
                return;
            }
        }

        static void Withdraw()
        {
            if (Bank.HasAccounts(CurrentUser))
            {
                Console.WriteLine("\nWhich account would you like to withdraw from?");
                int numAccounts = Bank.ListAccountOptions(CurrentUser);
                Console.WriteLine();
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    if (input > 0 && input <= numAccounts)
                    {
                        if (Bank.CanWithdraw(CurrentUser, input - 1))
                        {
                            Console.WriteLine("\nHow much would you like to withdraw?");
                            try
                            {
                                double amount = Convert.ToDouble(Console.ReadLine());
                                if (amount > 0)
                                {
                                    if (Bank.Withdraw(CurrentUser, input - 1, amount))
                                    {
                                        Console.WriteLine("\nWithdrawl completed successfully.");
                                    }
                                }
                                else Console.WriteLine("\nError: Amount must be positive.");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\nError: Invalid input format.");
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("\nError: Input was too large.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else Console.WriteLine("\nError: cannot withdraw from this account.");
                    }
                    else Console.WriteLine("\nError: Invalid input.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: Invalid input format.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\nError: Input was too large.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message);
                }
            }
            else Console.WriteLine("\nThere are no accounts listed for this user.");
        }
    }
}
