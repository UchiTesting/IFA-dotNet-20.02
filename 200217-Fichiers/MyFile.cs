using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _200217_Exo9_Fichiers
{
    public class MyFile
    {
        private string Path {get;set;}
        private StreamReader sr = null;
        private StreamWriter sw = null;

        public MyFile(string path)
        {
            Path = path;
        }

        public void ReadLine()
        {
            try
            {
                sr = new StreamReader(Path);
                Console.WriteLine(sr.ReadLine());
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Opening file in read mode failed:\n\t{0}", ioe.Message);

            } finally
            {
                sr.Close();
            }
        }

        public void ReadFile() {
            try
            {
                sr = new StreamReader(Path);
                Console.WriteLine(sr.ReadToEnd());
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Opening file in read mode failed:\n\t{0}", ioe.Message);

            } finally
            {
                sr.Close();
            }
        }

        public void WriteFile(string content) {
            try
            {
                sw = new StreamWriter(Path, false);
                sw.Write(content);
            }
            catch (IOException ioe)
            {

                Console.WriteLine("Opening file in write mode failed:\n\t{0}", ioe.Message);
            } finally
            {
                sw.Close();
            }
        }

        public void AppendFile(string content) {
            try
            {
                sw = new StreamWriter(Path, true);
                sw.Write(content);
            }
            catch (IOException ioe)
            {

                Console.WriteLine("Opening file in write mode failed:\n\t{0}", ioe.Message);
            } finally
            {
                sw.Close();
            }
        }



    }
}
