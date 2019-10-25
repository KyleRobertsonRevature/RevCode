using System;

namespace Project0
{
    class Demo
    {
        // PROPERTIES *********************************************************
        static string CurrentUser { get; set; }

        // MAIN ***************************************************************
        static void Main(string[] args)
        {
            //TODO "UI" goes here.
            MainDisplay();

        }

        // METHODS ************************************************************
        static void LoggedIn()
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
                    LoggedIn();
                    break;
                case "2":
                    LoggedIn();
                    break;
                case "3":
                    LoggedIn();
                    break;
                case "4":
                    LoggedIn();
                    break;
                case "5":
                    LoggedIn();
                    break;
                case "6":
                    LoggedIn();
                    break;
                case "7":
                    LoggedIn();
                    break;
                case "8":
                    LoggedIn();
                    break;
                case "9":
                    break;
                default:
                    LoggedIn();
                    break;
            }
            
        }

        static void LogIn()
        {
            string username = "";
            while (username.Equals(""))
            {
                Console.WriteLine("\nPlease enter your username:");
                username = Console.ReadLine();
                if (Bank.UsernameAvailable(username)) Console.WriteLine("\nError: Username not found.");
            }
            Console.WriteLine($"\nPassword for user {username}:");
            string password = Console.ReadLine();

        }

        static void MainDisplay()
        {
            Console.WriteLine("\nWelcome! Please create a new account or log in an existing user.\n" +
                "< 1 > Create New Account\n< 2 > Log In\n");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    NewAccount();
                    break;
                case "2":
                    LogIn();
                    break;
                default:
                    Console.WriteLine("\nError: Invalid input.\n");
                    break;
            }
            MainDisplay();
        }

        static void NewAccount()
        {
            string username = "";
            while (username.Equals(""))
            {
                Console.WriteLine("\nWelcome, new user! To create an account, please enter a username:");
                username = Console.ReadLine();
                if (username.Equals("")) Console.WriteLine("\nError: Username field cannot be blank.");
            }
            if (Bank.UsernameAvailable(username))
            {
                string password = "";
                while (password.Equals(""))
                {
                    Console.WriteLine($"\nPlease enter a password for user {username}:");
                    string firstPW = Console.ReadLine();
                    Console.WriteLine("\nConfirm password:");
                    string secondPW = Console.ReadLine();
                    if (firstPW.Equals(secondPW)) password = firstPW;
                    else if (firstPW.Equals("")) Console.WriteLine("\nError: Password field cannot be blank.");
                    else Console.WriteLine("\nError: Passwords did not match.");
                }
                Bank.AddUser(username, password);
                CurrentUser = username;
                LoggedIn();
            }
            else
            {
                Console.WriteLine("\nError: Username already in use. Please try again with a different username.");
                NewAccount();
            }
        }
    }
}
