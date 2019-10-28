using System;

namespace Project0
{
    class UI
    {
        // PROPERTIES *********************************************************
        static string CurrentUser { get; set; }


        // MAIN ***************************************************************
        static void Main(string[] args)
        {
            // loop back to login page until program terminated
            bool running;
            do
            {
                running = MainDisplay();
            }
            while (running);
        }

        // METHODS ************************************************************
        static void LoggedIn()
        {
            bool loggedIn = true;
            while (loggedIn)
            {
                Console.WriteLine($"\nWelcome, {CurrentUser}. What would you like to do?\n" +
                    $"< 1 > Open a new account\n< 2 > Close an account\n< 3 > Withdraw funds\n" +
                    $"< 4 > Deposit funds\n< 5 > Transfar funds\n< 6 > Make a loan payment\n" +
                    $"< 7 > Display all accounts\n< 8 > Display transactions for an account\n" +
                    $"< 9 > Log out\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":
                        break;
                    case "9":
                        loggedIn = false;
                        break;
                    default:
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
                "< 0 > End Program\n< 1 > Create New Account\n< 2 > Log In\n");
            string input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    return false;
                case "1":
                    NewAccount();
                    return true;
                case "2":
                    LogIn();
                    return true;
                default:
                    Console.WriteLine("\nError: Invalid input.\n");
                    return true;
            }
        }

        static void NewAccount()
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
    }
}
