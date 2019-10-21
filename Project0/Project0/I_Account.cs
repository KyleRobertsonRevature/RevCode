using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    interface I_Account
    {
        int AccountNumber { get; set; }
        decimal Balance { get; set; }
        float InterestRate { get; set; }
        Customer Owner { get; set; }
        List<string> Transactions { get; set; }

        void PrintTransactions();
    }
}
