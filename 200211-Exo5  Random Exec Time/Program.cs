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


            for (int i = 1; i < numberOfThreads; i++)
            {
                Thread T = new Thread(randomExecTimeThread);
                T.Start(i);

            }

            Console.SetCursorPosition(0, numberOfThreads + 3);

        }

        static void randomExecTimeThread(object number)
        {
            Random rnd = new Random();
            var sw = Stopwatch.StartNew();
            var startTime = sw.ElapsedMilliseconds;
            Console.SetCursorPosition(0, (int)number + 1);
            Console.Write("Starting Thread {0}: {1} ms", (int)number, startTime);
            Thread.Sleep(rnd.Next(1000,5000));
            var endTime = sw.ElapsedMilliseconds;
            Console.SetCursorPosition(30, (int)number + 1);
            Console.Write("Stopping Thread {0}: {1} ms", (int)number, endTime);

            Console.WriteLine("ExecTime for thread {1}: {0} ms",endTime-startTime, (int)number);

        }
    }
}
