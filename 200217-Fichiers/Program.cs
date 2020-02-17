using System;
using System.IO;
using System.Text;

namespace _200217_Exo9_Fichiers
{
    class Program
    {
        static string path = "file.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Exo 9: Files");

            MyFile file = new MyFile(path);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("This is the string made with a string builder.");
            sb.AppendLine("It has 3 lines.");
            sb.AppendLine("Does it display correctly?");

            Console.WriteLine("Writting the content of {0}", path);
            file.WriteFile(sb.ToString());
            Console.WriteLine("Reading the content of {0}", path);
            file.ReadFile();
            Console.WriteLine("Appending a line.");
            file.AppendFile("This line got added afterwards.");
            Console.WriteLine("Reading the file anew.");
            file.ReadFile();
        }
    }
}
