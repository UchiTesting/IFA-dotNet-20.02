using System;
using System.Diagnostics;
using System.Threading;

namespace _200211_Exo5__Random_Exec_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ex 5: Random Execution Time");

            int numberOfThreads = 10;
            Thread[] threads = new Thread[numberOfThreads];


            for (int i = 1; i <= numberOfThreads; i++)
            {
                threads[i - 1] = new Thread(randomExecTimeThread);
                threads[i - 1].Start(i);
            }

            for (int i = 0; i < numberOfThreads-1; i++)
            {
                threads[i].Join();
            }

            Console.SetCursorPosition(0, numberOfThreads + 3);
            Console.WriteLine($"Threads Length: {threads.Length}");
        }

        private static readonly object synlock = new object();
        static void randomExecTimeThread(object number)
        {
            Random rnd = new Random();
            var sw = Stopwatch.StartNew();
            var startTime = sw.ElapsedMilliseconds;
            lock (synlock)
            {
                Console.SetCursorPosition(0, (int)number + 1);
                Console.Write("Starting Thread {0}: {1} ms", (int)number, startTime);
            }

            Thread.Sleep(rnd.Next(1000,5000));
            var endTime = sw.ElapsedMilliseconds;
            lock (synlock)
            {
                Console.SetCursorPosition(30, (int)number + 1);
                Console.Write("Stopping Thread {0}: {1} ms", (int)number, endTime);
            }

            Console.WriteLine("ExecTime for thread {1}: {0} ms",endTime-startTime, (int)number);

        }
    }
}
