using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace _200221_Exo15_Serialisation_multiple
{
    class Program
    {
        static List<Car> cars = new List<Car>();
        const string fileName = "XMLFile.xml";
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WriteLine("Exo 15 : Multiple Serialisation");
            //int max = 1000000;
            //Stopwatch watch = new Stopwatch();
            //long startTime = watch.ElapsedMilliseconds;
            //for (int i = 0; i < max;i++)
            //{
            //    cars.Add(new Car(i));
            //    Console.SetCursorPosition(0, 1);
            //    DisplayProgressBar(i,max);
            //}
            //long endTime = watch.ElapsedMilliseconds;

            //Console.WriteLine("Time elapsed filling the table: {0} ms", endTime-startTime);
            //startTime = watch.ElapsedMilliseconds;
            //SerializeATonOfCars();

            //endTime = watch.ElapsedMilliseconds;
            //Console.WriteLine("Time elapsed writting to file: {0} ms", endTime-startTime);

            DeserializeCars();


        }

        private static void DisplayProgressBar(int currentValue, int maxValue, int MaxLength = 30)
        {
            // Compute the progress
            int currentLength = ((currentValue * MaxLength) / maxValue);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < currentLength; i++)
            {
                sb.Append('*');
            }

            Console.WriteLine(sb.ToString());
          
        }

        static void SerializeATonOfCars()
        {
            for (int i = 0; i < cars.Count; i++)
            {
                SerializeACar(cars[i]);
                Console.SetCursorPosition(0, 2);
                DisplayProgressBar(i, cars.Count);
            }
        }

        static void SerializeACar(Car obj)
        {

            XmlSerializer x = new XmlSerializer(typeof(Car));
            Stream stream = new StreamWriter(fileName,true).BaseStream;
            x.Serialize(stream, obj);
            stream.Close();
        }

        static Car DeserializeACar()
        {
            XmlSerializer x = new XmlSerializer(typeof(Car));
            StreamReader sr = new StreamReader(fileName);
            Car c = (Car)x.Deserialize(sr);
            sr.Close();

            return c;
        }

        static void DeserializeCars() {
            StreamReader sr = new StreamReader(fileName);

            while (!sr.EndOfStream)
            {
                Car c  = DeserializeACar();
                c.ToString();
            }
        }
    }
}
