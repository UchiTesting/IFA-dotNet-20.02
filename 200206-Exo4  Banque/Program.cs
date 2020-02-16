using System;
using System.Collections.Generic;
using System.Text;
using Simple_IO;
using _200206_Exo4_Banque.Exceptions;

namespace _200206_Exo4_Banque
{
    class Program
    {
        static readonly List<Bank> listOfBanks = new List<Bank>();

        private static void Main()
        {

            /**
             * Ecrire un programme qui permet de créer des compte dans plusieurs banques.
             * On pourra créer des comptes
             * Retirer et déposer de l'argent
             * Calculer le taux d'intéret.
             * On appliquera systématiquement le calcul du taux d'intérêt lors d'un retrait ou un depot.
             */

            Console.WriteLine("Exo 4: Bank accounts.");

            char choix;

            do
            {
                DisplayMainMenu();
                choix = AskData.askChar();
                Console.WriteLine("");
                Bank b;

                switch (choix)
                {
                    case 'a':
                        listOfBanks.Add(CreateBank());
                        break;
                    case 'b':
                        b = SelectBank();
                        if (b != null)
                            listOfBanks.Remove(b);
                        else
                            DisplayColouredMessage("Bank not found.");
                        break;
                    case 'c':
                        DisplayListOfBanks();

                        if (listOfBanks.Count > 0)
                        {
                            b = SelectBank();
                            if (b != null)
                                ProcessBank(b);
                            else
                                DisplayColouredMessage("Bank not found.");
                        }
                        break;
                    case 'd':
                        DisplayListOfBanks();
                        break;
                    default:
                        Console.WriteLine("Please input a valid option.");
                        break;
                }

            } while (choix != 'q');
        }

        /**
         *  GESTION DE LA LISTE DES BANQUES
         */

        public static void DisplayMainMenu()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Menu Principal\n========\n");
            builder.AppendLine("a: Add a bank.");
            builder.AppendLine("b: Remove a bank.");
            builder.AppendLine("c: Select a bank.");
            builder.AppendLine("d: See list of banks.");
            builder.AppendLine("q: Quit.");
            builder.AppendLine("");

            DisplayColouredMessage(builder.ToString(), ConsoleColor.Cyan);
        }

        public static Bank CreateBank()
        {
            DisplayColouredMessage("Add a bank:\n========\n", ConsoleColor.Cyan);
            string nom = AskData.askString("Name: ");
            string adresse = AskData.askString("Address: ");
            return new Bank(nom, adresse);
        }

        public static Bank SelectBank()
        {
            Bank b = null;

            if (listOfBanks.Count > 0)
            {
                string idBanque = AskData.askString("Bank name: ");

                b = listOfBanks.Find(item => item.Name.Equals(idBanque, StringComparison.CurrentCulture));
            }

            return b;
        }

        public static void ProcessBank(Bank b)
        {


            char choice;

            do
            {
                DisplayBankMenu();
                choice = AskData.askChar("Choice: ");

                Account c;

                switch (choice)
                {
                    case 'a': // Create an account

                        b.CreateAccount();
                        break;

                    case 'b': // Remove an account

                        c = SelectAccount(b);
                        if (c != null)
                            b.DeleteAccount(c);
                        else
                            DisplayColouredMessage("Non-existent account.");

                        break;
                    case 'c': // Lookup for an account

                        c = SelectAccount(b);
                        try
                        {
                            ProcessAccount(b.LookupAccount(c.Id));
                        }
                        catch (AccountNotFoundException)
                        {

                            DisplayColouredMessage("Account not found...");
                        }

                        break;
                    case 'd': // List accounts

                        b.listAccounts();
                        break;
                    default:
                        break;
                }
            } while (choice != 'r');
        }

        public static void DisplayListOfBanks()
        {
            if (listOfBanks.Count > 0)
            {
                foreach (Bank b in listOfBanks)
                {
                    Console.WriteLine(b.ToListItem());
                }
            }
            else
            {
                DisplayColouredMessage("There is no bank yet.");
            }
        }

        /**
         * MANAGEMENT OF A BANK
         */

        public static void DisplayBankMenu()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Bank Menu\n========\n");
            builder.AppendLine("a: Create an account.");
            builder.AppendLine("b: Remove an account.");
            builder.AppendLine("c: Lookup for an account.");
            builder.AppendLine("d: List Accounts.");
            builder.AppendLine("r: Exit Bank Menu.");
            builder.AppendLine("");

            Console.WriteLine(builder.ToString());
        }

        public static Account SelectAccount(Bank b)
        {
            b.listAccounts();
            string id = AskData.askString("Account ID: ");
            Account c = b.LookupAccount(id);

            return c;
        }

        public static void ProcessAccount(Account c)
        {


            char choice;
            do
            {
                DisplayAccountMenu();
                choice = AskData.askChar();

                decimal d;

                switch (choice)
                {
                    case 'a': // Deposit
                        d = AskData.askDecimal("Sum to deposit: ");
                        c.Deposit(d);
                        break;
                    case 'b': // Withdrawal
                        d = AskData.askDecimal("Sum to withdraw: ");
                        c.Withdraw(d);
                        break;
                    case 'c': // See balance
                        c.DisplayBalance();
                        break;
                    default:
                        break;
                }
            } while (choice != 'r');
        }

        /**
         * MANAGEMENT OF AN ACCOUNT
         */

        public static void DisplayAccountMenu()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Account Menu\n========\n");
            builder.AppendLine("a: Deposit money.");
            builder.AppendLine("b: Withdraw money.");
            builder.AppendLine("c: See balance.");
            builder.AppendLine("r: Exit Account Menu.");
            builder.AppendLine("");

            Console.WriteLine(builder.ToString());
        }

        static void DisplayColouredMessage(string message, ConsoleColor cc = ConsoleColor.Red)
        {
            Console.ForegroundColor = cc;
            Console.WriteLine(message);
            Console.ResetColor();
        }


    }
}
