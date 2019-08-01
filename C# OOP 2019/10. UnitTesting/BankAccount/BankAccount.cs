using System;
using System.Text;
using System.Collections.Generic;

namespace BankAccount
{
    public class BankAccount
    {
        public BankAccount()
        {

        }

        public decimal Amount { get; set; }

        public void Deposit(decimal amount)
        {
            this.Amount = amount;
        }

        public void Withdraw(decimal amount)
        {
            if (this.Amount - amount >= 0)
            {
                this.Amount -= amount;
            }
        }
    }
}
