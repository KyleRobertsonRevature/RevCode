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

        Dictionary<int, I_Account> Accounts = new Dictionary<int, I_Account>();

        public Customer(string name, string email, string address, int ssn)
        {
            Name = name;
            Email = email;
            Address = address;
            SSN = ssn;
        }
    }
}
