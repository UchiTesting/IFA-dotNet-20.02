using System;
using System.Threading;

namespace _200213_Exo7_Thread_et_var_partagée
{
    class Program
    {
        static int sharedValue = 0;
        static readonly object synlock = new object();
        static void Main(string[] args)
        {
            Console.WriteLine("Exo7: Variable partagée entre threads");

            int numberOfThreads = 2;
            Thread[] tabThread = new Thread[numberOfThreads];

            tabThread[0] = new Thread(incrementSharedValue);
            tabThread[1] = new Thread(decrementSharedValue);

            for (int i = 0; i < tabThread.Length; i++)
            {
                tabThread[i].Start();
            }

            for (int i = 0; i < tabThread.Length; i++)
            {
                tabThread[i].Join();
            }
        }

        // Atomicité avec Lock
        static void incrementSharedValue()
        {
            for (int i = 0; i < 200; i++)
            {
                sharedValue++;
                lock (synlock)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine("________\nincrB:" + sharedValue);
                    Console.WriteLine("incrF:" + sharedValue);
                    Thread.Sleep(100);
                }
            }
        }

        // Atomicité avec Monitor
        static void decrementSharedValue()
        {
            for (int i = 0; i < 200; i++)
            {
                sharedValue--;
                Monitor.Enter(synlock);
                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(20, Console.CursorTop);
                    Console.WriteLine("________");
                    Console.SetCursorPosition(20, Console.CursorTop);
                    Console.WriteLine("decrB:" + sharedValue);
                    Console.SetCursorPosition(20, Console.CursorTop);
                    Console.WriteLine("decrF:" + sharedValue);
                    Thread.Sleep(100);
                }
                finally
                {
                    Monitor.Exit(synlock);
                }
            }
        }
    }
}
