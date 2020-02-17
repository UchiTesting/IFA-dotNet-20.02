using System;
using System.Threading;

namespace _200217_Exo10_Mutex
{
    class Program
    {
        static Mutex myMutex;
        static void Main(string[] args)
        {
            Console.WriteLine("Exo 10: Mutex");

            if (!IsSingleInstance())
            {
                Console.WriteLine("More than 1 insance.");
            } else
            {
                Console.WriteLine("First instance.");
            }

            Console.ReadKey();


        }

        public static bool IsSingleInstance()
        {
            try
            {
                Mutex.OpenExisting("フェライン");
            }
            catch (Exception)
            {

                Program.myMutex = new Mutex(true,"フェライン");
                return true;
            }

            return false;
        }

    }
}
