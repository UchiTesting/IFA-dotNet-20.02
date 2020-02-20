using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using static Simple_IO.AskData; // static allows using a class directly.
using IHMConsole;
using _200220_Exo14_Concessionnaires_JSON.Exceptions;

namespace _200220_Exo14_Concessionnaires_JSON
{
    class Program
    {
        private const string Path = "MyListOfConcessionaries.bin";
        static List<Concessionary> listOfConcessionaries = null;
        static MainCanvas mc = null;
        static Canvas DisplayCanvas = null;
        static Canvas MenuCanvas = null;
        static void Main(string[] args)
        {
            listOfConcessionaries = new List<Concessionary>();
            InitDisplay();

            Console.WriteLine("Exo 14: JSON Car Dealers.");

            char choice = '\0';

            do
            {
                InitDisplay();

                choice = askChar();

                switch (choice)
                {
                    case '1':
                        AddConcessionary();
                        break;
                    case '2':
                        ListConcessionary();
                        RemoveConcessionary(askInt("What concessionary / line would you like to delete?: "));
                        break;
                    case '3':
                        SaveConcessionaries();
                        break;
                    case '4':
                        LoadConcessionaries();
                        break;
                    case '5':
                        ListConcessionary();
                        break;
                    case '6':

                        Concessionary c = SearchConcessionary();
                        if (c != null)
                        {
                            ProcessConcessionary(c);
                        }
                        break;
                }
                Console.ReadKey();
            } while (choice != '0');
        }

        private static void InitDisplay()
        {
            Console.Clear();
            mc = MainCanvas.Instance;

            // Setting Up the display canvas.
            DisplayCanvas = new Canvas(1, 1, 78, 17);
            Label infoLabel = new Label("", 1, 1);

            DisplayCanvas.Add(infoLabel);

            // Setting Up the menu canvas.
            MenuCanvas = new Canvas(1, DisplayCanvas.Height, 78, 8);
            Label MenuLabel = new Label(DisplayMainMenu(), 1, 1);

            MenuCanvas.Add(MenuLabel);

            mc.Add(DisplayCanvas);
            mc.Add(MenuCanvas);

            mc.Show();
        }

        private static string DisplayMainMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Menu\n========");
            sb.AppendLine("1) Add Concessionary.");
            sb.AppendLine("2) Remove Concessionary.");
            sb.AppendLine("3) Save Concessionaries.");
            sb.AppendLine("4) Load Concessionaries.");
            sb.AppendLine("5) List Concessionaries.");
            sb.AppendLine("6) Edit a Concessionary.");
            sb.AppendLine("0) Quit.");

            return sb.ToString();
        }

        private static void LoadConcessionaries()
        {
            string jsonString;
            StreamReader sr = new StreamReader(Path);
            jsonString = sr.ReadLine();
            sr.Close();
        }

        private static void SaveConcessionaries()
        {
            throw new NotImplementedException();
        }

        private static void RemoveConcessionary(int index)
        {
            if (listOfConcessionaries.Count > 0 && index < listOfConcessionaries.Count && index >= 0)
            {
                listOfConcessionaries.RemoveAt(index);
            }
        }

        private static void AddConcessionary()
        {
            Concessionary concessionary = new Concessionary(askString("Name: "));
            listOfConcessionaries.Add(concessionary);
        }

        private static void ListConcessionary()
        {
            if (listOfConcessionaries.Count > 0)
                listOfConcessionaries.ForEach(x => Console.WriteLine(x.ToString()));
            else
                Console.WriteLine("The list of concessions is empty.");
        }

        private static Concessionary SearchConcessionary()
        {
            Concessionary c = null;
            if (listOfConcessionaries.Count > 0)
            {

                string name = askString("Concessionary Name: ");
                c = listOfConcessionaries.Find(x => x.Brand.Equals(name));
            }
            else
            {
                throw new ListException("There is no concessionary to lookup for.");

            }

            return c;
        }

        // MANAGE A CONCESSIONARY

        private static string DisplayConcessionaryMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Concessionary Menu\n========");
            sb.AppendLine("1) Add a Car");
            sb.AppendLine("2) Remove a Car");
            sb.AppendLine("3) List Cars");
            sb.AppendLine("0) Exit Concessionary menu.");

            return sb.ToString();
        }

        private static void ProcessConcessionary(Concessionary c)
        {
            char choice;
            do
            {
                Console.WriteLine(DisplayConcessionaryMenu());
                choice = askChar("Choice: ");

                switch (choice)
                {
                    case '1':
                        c.AddCar(c.Brand,askString("Model: "),askInt("Power: "));
                        break;
                    case '2':
                        Console.WriteLine(c.ListCars());
                        c.RemoveCar(askInt("Which car/ line to be removed?: "));
                        break;
                    case '3':
                        Console.WriteLine(c.ListCars());
                        break;
                }



            } while (choice != '0');
        }
    }
}
