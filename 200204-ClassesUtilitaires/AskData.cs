using System;
using System.Collections.Generic;
using System.Text;

namespace _200204_ClassesUtilitaires
{
    static class AskData
    {
        public static int askInt()
        {
            bool ok = false;
            int n = 0;

            do
            {
                try
                {
                    n = Convert.ToInt16(Console.ReadLine());
                    ok = true;
                } catch(FormatException)
                {
                    Console.WriteLine("Veuillez saisir un entier, SVP.");
                }
            } while (!ok);

            return n;
        }

        public static int askInt(string message)
        {
            Console.Write(message);
            return askInt();
        }
    }
}
