using System;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace _200217_Partage_de_Fichier
{
    class Program
    {
        static object locker = new object();
        static Mutex myMutex = null;
        static string filename = "sharedFile.txt";
        static StreamWriter sw = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Exo10: Shared file");
            Console.CursorVisible = false;
            Console.Clear();

            myMutex = new Mutex(false, "IOwnTheFile");

            Console.Write("Nommez le thread avec un nom unique, SVP: ");
            string threadName = Console.ReadLine();
            int threadTimeout = 5000;
            int pause = 100;
            char saisie = '\0';
            Stopwatch myStopWatch = new Stopwatch();
            long startTime;
            long endTime;

            while (saisie != ' ')
            {
                myStopWatch = Stopwatch.StartNew();
                startTime = myStopWatch.ElapsedMilliseconds;
                if (Console.KeyAvailable)
                {
                    saisie = Console.ReadKey().KeyChar;
                }

                if (myMutex.WaitOne(1))
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Appuyez sur espace pour quitter. Thread nommé {0}", threadName);
                    Console.WriteLine("Got Mutex");


                    Thread myThread = new Thread(myFileAccessThread);
                    myThread.Start(threadName);
                    myThread.Join(threadTimeout);
                    Thread.Sleep(pause);
                    myMutex.ReleaseMutex();
                    Console.WriteLine("Released Mutex");
                }
                myStopWatch.Stop();
                endTime = myStopWatch.ElapsedMilliseconds;

                Console.SetCursorPosition(70, 0);
                Console.WriteLine("Time elapsed: {0} ms", (float)((endTime -startTime)));
            }

        }

        public static void myFileAccessThread(object o)
        {
            DateTime date = DateTime.Now;
            string threadName = (string)o;
            string outputLine = string.Format("{0} wrote in the file at {1}", threadName, date);

            try
            {
                sw = new StreamWriter(filename, true);
                Console.WriteLine(outputLine);
                sw.WriteLine(outputLine);
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Something did not go well...\n\t{0}", ioe.Message);
            }
            finally
            {
                sw.Close();
            }

        }
    }
}
