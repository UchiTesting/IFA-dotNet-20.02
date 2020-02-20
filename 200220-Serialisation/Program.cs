using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace _200220_Serialisation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cours: Serialisation");
        }


        static void seriBinary()
        {
            MySerialisableObject obj = new MySerialisableObject();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();
        }

        static void seriJSON()
        {
            MySerialisableObject obj = new MySerialisableObject();
            IFormatter formater = new
        }

        static void seriXML()
        {
            MySerialisableObject obj = new MySerialisableObject();
            //
        }

        //

        static void deseriBinary() { }
        static void deseriJSON()
        {
            StreamReader sr = new StreamReader("path");
        }
        static void deseriXML()
        {
            XmlSerializer x = new XmlSerializer(typeof(MySerialisableObject));
            StreamReader sr = new StreamReader("path");
        }
    }

    [Serializable]
    class MySerialisableObject
    {
        private string Info1 { get; set; }
        private int Info2 { get; set; }
        private double Info3 { get; set; }
    }
}
