using System;
using System.IO;
// Serialisation Binaire
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
// Serialisation JSON
using System.Text.Json;
using System.Text.Json.Serialization;
// Serialisation XML
using System.Xml.Serialization;

namespace _200220_Serialisation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cours: Serialisation");
            
            // BINAIRE
            SeriBinary();
            MySerialisableObject anObject = DeseriBinary();

            Console.WriteLine(anObject.ToString());

            // JSON
            SeriJSON();
            MySerialisableObject aJSON_Object = DeseriJSON();

            Console.WriteLine(aJSON_Object.ToString());
            
            // XML
            SeriXML();
            MySerialisableObject anXML_Object = DeseriXML();
            
            Console.WriteLine(anXML_Object.ToString());

        }


        static void SeriBinary()
        {
            MySerialisableObject obj = new MySerialisableObject();
            obj.Info1 = "Binary Test";
            obj.Info2 = 32;
            obj.Info3 = 3.1415;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();
        }

        static void SeriJSON()
        {
            MySerialisableObject obj = new MySerialisableObject();
            obj.Info1 = "JSON Test";
            obj.Info2 = 10;
            obj.Info3 = 100.99;
            string jsonString = JsonSerializer.Serialize(obj);
            StreamWriter sw = new StreamWriter("MyJSON_File.json");
            sw.WriteLine(jsonString);
            sw.Close();

        }

        static void SeriXML()
        {
            MySerialisableObject obj = new MySerialisableObject();
            obj.Info1 = "XML Test";
            obj.Info2 = 5;
            obj.Info3 = 50.55;
            
            XmlSerializer x = new XmlSerializer(typeof(MySerialisableObject));
            StreamWriter sw = new StreamWriter("MyXML_File.xml");
            x.Serialize(sw, obj);
            sw.Close();  

        }

        //

        static MySerialisableObject DeseriBinary()
        {
            IFormatter formatter = new BinaryFormatter();
            MySerialisableObject obj = null;
            Stream stream = new FileStream("MyFile.bin", FileMode.Open,FileAccess.Read,FileShare.None);
            try
            {
                obj = (MySerialisableObject) formatter.Deserialize(stream);
            }
            catch (SerializationException e)
            {
                Console.WriteLine(e.Message);
            }
            stream.Close();

            return obj;
        }
        static MySerialisableObject DeseriJSON()
        {
            StreamReader sr = new StreamReader("MyJSON_File.json");
            
            string jsonString = sr.ReadLine();
            sr.Close();  

            MySerialisableObject obj;
            obj = JsonSerializer.Deserialize<MySerialisableObject>(jsonString);

            return obj;
        }
        static MySerialisableObject DeseriXML()
        {
            XmlSerializer x = new XmlSerializer(typeof(MySerialisableObject));
            StreamReader sr = new StreamReader("MyXML_File.xml");

            MySerialisableObject obj = (MySerialisableObject) x.Deserialize(sr);
            sr.Close();

            return obj;
        }
    }

    [Serializable]
    public class MySerialisableObject
    {
        public string Info1 { get; set; }
        public int Info2 { get; set; }
        public double Info3 { get; set; }

        public override string ToString()
        {
            return $"Info1: {Info1} Info2: {Info2} Info3: {Info3}";
        }
    }
}
