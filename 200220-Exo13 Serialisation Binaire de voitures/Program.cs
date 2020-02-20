using Simple_IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using IHMConsole;

namespace _200220_Exo13_Serialisation_Binaire_de_voitures
{
    class Program
    {
        private const string Path = "MyListOfCars.bin";
        static List<Car> listOfCars = null;
        static void Main(string[] args)
        {
            listOfCars = new List<Car>();
            InitDisplay();

            Console.WriteLine("Exo 13: Binary serialization of Cars.");

            char choice = '\0';

            do
            {
                InitDisplay();

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

        private static void InitDisplay()
        {
            Console.Clear();
            MainCanvas mc = MainCanvas.Instance;

            // Setting Up the display canvas.
            Canvas DisplayCanvas = new Canvas(1, 1, 78, 17);
            Label infoLabel = new Label("", 1, 1);

            DisplayCanvas.Add(infoLabel);

            // Setting Up the menu canvas.
            Canvas MenuCanvas = new Canvas(1,DisplayCanvas.Height,78,8);
            Label MenuLabel = new Label(DisplayMenu(), 1, 1);

            MenuCanvas.Add(MenuLabel);

            mc.Add(DisplayCanvas);
            mc.Add(MenuCanvas);

            mc.Show();
        }

        private static string DisplayMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Menu\n========");
            sb.AppendLine("1) Add Cars.");
            sb.AppendLine("2) Remove Cars.");
            sb.AppendLine("3) Save Cars.");
            sb.AppendLine("4) Load Cars.");
            sb.AppendLine("5) List Cars.");
            sb.AppendLine("0) Quit.");

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
            Stream stream = new FileStream(Path, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, listOfCars);
            stream.Close();
        }

        private static void RemoveCar(int index)
        {
            if (listOfCars.Count > 0 && index < listOfCars.Count && index >= 0)
            {
                listOfCars.RemoveAt(index);
            }
        }

        private static void AddCar()
        {
            Car car = new Car(AskData.askString("Brand: "), AskData.askString("Model: "), AskData.askInt("Power: "));
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
