using System;
using System.Diagnostics;
using System.Threading;

namespace _200211_Exo6_MultiThread_Fibonacci
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Exo 6: Multithreaded Fibonacci");

            int numberOfThreads = 10;
            Thread[] tabThreads = new Thread[numberOfThreads];

            Random rnd = new Random();


            for (int i = 0; i < tabThreads.Length; i++)
            {
                int[] values = { rnd.Next(20, 50), i };
                tabThreads[i] = new Thread(SuiteFibonacciIterative);
                tabThreads[i].Start(values);
            }

            Thread recurThread = new Thread(ThreadRecursif);
            recurThread.Start();
            recurThread.Join();

            foreach (Thread t in tabThreads)
            {
                t.Join();
            }

            Console.SetCursorPosition(0, numberOfThreads + 1);
        }

        static readonly object synlock = new object();

        static void SuiteFibonacciIterative(object values)
        {
            int[] tabVal = (int[])values;
            int n = tabVal[0];
            int m = tabVal[1]+1;

            Stopwatch sw = Stopwatch.StartNew();
            long startTime = sw.ElapsedMilliseconds;

            lock (synlock)
            {
                Console.SetCursorPosition(0, m + 1);
                Console.WriteLine($"Starting Fibonacci {m,2} with n = {n}");
            }

            int nb1 = 0;
            int nb2 = 1;
            int tmp = 0;

            if (n > 1)
            {
                for (int i = 2; i <= n; i++)
                {
                    tmp = nb1 + nb2;
                    nb1 = nb2;
                    nb2 = tmp;
                }

                lock (synlock)
                {
                    Console.SetCursorPosition(40, m + 1);
                    Console.WriteLine(tmp);

                }
            }
            else if (n == 0 || n == 1)
            {
                lock (synlock)
                {
                    Console.SetCursorPosition(40, m + 1);
                    Console.WriteLine(n);
                }

            }

            //Console.WriteLine(-1);
            long stopTime = sw.ElapsedMilliseconds;
            lock (synlock)
            {
                Console.SetCursorPosition(70, m + 1);
                Console.WriteLine("Stopping Fibonacci {0}. Time elapsed: {2} ms.", m, n, stopTime - startTime);
            }

        }

        static void ThreadRecursif()
        {
            Random rnd = new Random();
            lock (synlock)
            {
                Stopwatch sw = new Stopwatch();
                long startTime = sw.ElapsedMilliseconds;
                long stopTime = sw.ElapsedMilliseconds;
                Console.SetCursorPosition(0, Console.WindowHeight - 2);
                int valN = rnd.Next(20, 30);
                int n = SuiteFibonacciRecursive(valN);
                lock (synlock)
                {
                    Console.SetCursorPosition(0, Console.WindowHeight - 1);
                    Console.WriteLine("Fibo Recursif -> n: {0}, result: {2}, time: {1} ms.", valN, stopTime - startTime, n);
                }
            }
        }

        static int SuiteFibonacciRecursive(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else if (n > 1)
            {
                return SuiteFibonacciRecursive(n - 1) + SuiteFibonacciRecursive(n - 2);
            }
            else
            {
                return -1;
            }
        }

    }
}
