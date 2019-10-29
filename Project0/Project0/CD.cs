using System;

namespace Project0
{
    /// <summary>
    /// Account for a CD. Cannot be deposited into, can only be withdrawn from when mature.
    /// </summary>
    class CD : Account
    {
        // PARAMETERS *********************************************************
        /// <summary>
        /// boolean representing whether the CD is mature.
        /// </summary>
        public bool IsMature;

        // CONSTRUCTOR ********************************************************
        public CD(int accNum, double rate, double initialBalance)
        {
            AccountNumber = accNum;
            Balance = initialBalance;
            InterestRate = rate;
            AccountType = AccType.CD;
            IsMature = false;
            Transactions.Add($"Initial Balance: ${Balance}");
        }

        // METHODS ************************************************************
        /// <summary>
        /// Applies interest to the CD's balance, if not mature yet.
        /// </summary>
        public override void ApplyInterest()
        {
            if (Balance > 0d && !IsMature)
            {
                double earned = Balance * (InterestRate / 100d);
                Balance += earned;
                Transactions.Add($"Interest earned: ${earned}\nBalance = ${Balance}");
            }
        }

        /// <summary>
        /// Returns an arror message. CDs cannot be deposited into.
        /// </summary>
        /// <param name="amount">The amount to be deposited. never valid.</param>
        /// <returns>false. CD canot be deposited into.</returns>
        public override bool Deposit(double amount)
        {
            Console.WriteLine("Error: Cannot deposit into a Term Deposit account");
            return false;
        }

        /// <summary>
        /// Displays details of the CD
        /// </summary>
        public override void DisplayDetails()
        {
            string matureString = IsMature ? "": "not ";
            Console.WriteLine($"Term Deposit #{AccountNumber} is {matureString}mature, has a balance of ${Balance}, and an interest rate of {InterestRate}%.");
        }

        /// <summary>
        /// Withdraws from the CD, if amount is valid and the CD is mature.
        /// </summary>
        /// <param name="amount">The amount of money to be withdrawn.</param>
        /// <returns>A boolean representation of whether the transaction was completed.</returns>
        public override bool Withdraw(double amount)
        {
            if (IsMature)
            {
                if (amount > 0)
                {
                    double dif = Balance - amount;
                    if (dif >= 0)
                    {
                        Balance = dif;
                        Transactions.Add($"Withdrawl: ${amount}\nBalance = ${Balance}");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Error: Not enough money in account for this withdrawl.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Error: Cannot withdraw non-positive amount.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Error: Cannot withdraw from Term Deposit until it is mature.");
                return false;
            }
        }
    }
}
