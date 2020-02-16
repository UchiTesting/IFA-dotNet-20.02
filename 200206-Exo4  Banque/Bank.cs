using System;
using System.Collections.Generic;
using System.Text;
using _200206_Exo4_Banque.Exceptions;
using Simple_IO;

namespace _200206_Exo4_Banque
{
    public class Bank
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Account> Accounts { get; }

        public Bank(string nom, string adresse)
        {
            Name = nom;
            Address = adresse;
            Accounts = new List<Account>();
        }

        public void CreateAccount()
        {
            Account c = new Account(AskData.askString("Account ID:: "),
                            AskData.askDecimal("Initial balance: "),
                            AskData.askFloat("Rate: "));

            Accounts.Add(c);
            Console.WriteLine();
        }

        public void DeleteAccount(Account c)
        {
            Accounts.Remove(c);
        }

        public void depositOn(string id, decimal montant)
        {
            Account c = LookupAccount(id);
            c.Deposit(montant);
        }

        public void withdrawOn(string id, decimal montant)
        {
            Account c = LookupAccount(id);
            c.Withdraw(montant);
        }

        public Account LookupAccount(string id)
        {

            Account c = Accounts.Find(item => item.Id.Equals(id, StringComparison.InvariantCulture));

            if (c == null)
                throw new AccountNotFoundException("Account not found.");
            else
                return c;
        }

        public void listAccounts()
        {
            if (Accounts.Count > 0)
            {
                foreach (Account c in Accounts)
                {
                    Console.WriteLine(c.ToString());
                }
            } else
                Console.WriteLine("No account in this bank yet.");
        }

        public override string ToString()
        {
            // TODO
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Bank " + Name + "\n========\n");
            builder.Append("Address:")
                .Append(Address)
                .Append("");

            return builder.ToString();
        }

        public string ToListItem()
        {
            return string.Format("{0} located in {1}. Having {2} account(s).", Name, Address, Accounts.Count);
        }

        // Optional
        private string generateId()
        {
            throw new NotImplementedException();
        }
        private bool checkId()
        {
            //
            throw new NotImplementedException();
        }
    }
}
