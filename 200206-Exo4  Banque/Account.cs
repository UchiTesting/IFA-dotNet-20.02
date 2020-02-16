using System;
using System.Collections.Generic;
using System.Text;
using Simple_IO;

namespace _200206_Exo4_Banque
{
    public class Account
    {
        public string Id { get; set; }
        public decimal Balance { get; set; }
        public float Ratio { get; set; }
        public string Currency { get; set; }

        public Account(string id, decimal balance, float ratio, string currency = "€")
        {
            Id = id;
            Balance = balance;
            Ratio = ratio;
            Currency = currency;
        }

        public void Deposit(decimal d)
        {
            Balance += d;
        }

        public void Withdraw(decimal d)
        {
            if (d > Balance)
            {
                throw new MoneyWithdrawExceedException();
            }
            else
            {
                Balance -= d;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Account #: " + Id);
            builder.Append(" | Balance: " + Balance + " " + Currency);
            builder.AppendLine(" | Rate: " + Ratio);

            return builder.ToString();
        }

        public void DisplayBalance()
        {
            Console.WriteLine("Balance: " + Balance);
        }

        protected decimal ComputeInterest()
        {
            decimal interest;
            interest = Balance * (decimal)Ratio;
            return interest;
        }
    }
}
