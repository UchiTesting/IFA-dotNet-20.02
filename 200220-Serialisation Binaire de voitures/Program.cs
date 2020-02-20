using Simple_IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace _200220_Exo13_Serialisation_Binaire_de_voitures
{
    class Program
    {
        private const string Path = "MyListOfCars.bin";
        static List<Car> listOfCars = null;
        static void Main(string[] args)
        {
            listOfCars = new List<Car>();

            Console.WriteLine("Exo 13: Binary serialization of Cars.");

            char choice = '\0';

            do
            {
                Console.Clear();
                Console.WriteLine(DisplayMenu());
                choice = AskData.askChar();

                switch (choice)
                {
                    case '1':
                        AddCar();
                        break;
                    case '2':
                        ListCars();
                        RemoveCar(AskData.askInt("What car / line would you like to delete?: "));
                        break;
                    case '3':
                        SaveCars();
                        break;
                    case '4':
                        LoadCars();
                        break;
                    case '5':
                        ListCars();
                        break;
                }
                Console.ReadKey();
            } while (choice != '0');
        }

        private static string DisplayMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Menu\n========");
            sb.Append("1) Add Cars.");
            sb.Append("2) Remove Cars.");
            sb.Append("3) Save Cars.");
            sb.Append("4) Load Cars.");
            sb.Append("5) List Cars.");
            sb.Append("0) Quit.");

            return sb.ToString();
        }

        private static void LoadCars()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.None);
            listOfCars = (List<Car>)formatter.Deserialize(stream);
            stream.Close();
        }

        private static void SaveCars()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(Path, FileMode.Create,FileAccess.Write,FileShare.None);
            formatter.Serialize(stream, listOfCars);
            stream.Close();
        }

        private static void RemoveCar(int index)
        {
            if (listOfCars.Count > 0 && index < listOfCars.Count && index >=0)
            {
                listOfCars.RemoveAt(index);
            }
        }

        private static void AddCar()
        {
            Car car = new Car(AskData.askString("Brand: "), AskData.askString("Model: "),AskData.askInt("Power: "));
            listOfCars.Add(car);
        }

        private static void ListCars()
        {
            if (listOfCars.Count > 0)
                listOfCars.ForEach(x => Console.WriteLine(x.ToString()));
            else
                Console.WriteLine("The list of cars is empty.");
        }
    }
}
