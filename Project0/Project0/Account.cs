using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    abstract class Account
    {
        public int AccountNumber { get; set; }
        public double Balance { get; set; }
        public double InterestRate { get; set; }
    }
}
