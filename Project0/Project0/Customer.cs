using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int SSN { get; set; }

        List<int> AccountNums = new List<int>();

        public Customer(string name, string email, string address, int ssn)
        {
            Name = name;
            Email = email;
            Address = address;
            SSN = ssn;
        }
        public void OpenAccount(AccType accType, double initialBalance)
        {
            // return accnum?
            //TODO
        }

        public void CloseAccount(int accNum)
        {
            // can only close accounts w/ 0 balance
            //TODO
        }
        public void Withdraw(int accNum, double amount)
        {
            //TODO
        }
        public void Deposit(int accNum, double amount)
        {
            //TODO
        }
        public void Transfer(int fromAcc, int toAcc, double amount)
        {
            //TODO
        }

        public void DisplayAccounts()
        {
            //TODO
        }
        public void DisplayTransactions(int accNum)
        {
            //TODO
        }
    }
}
