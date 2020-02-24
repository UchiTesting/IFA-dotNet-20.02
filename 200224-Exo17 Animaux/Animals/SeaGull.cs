using System;
using System.Collections.Generic;
using System.Text;

namespace _200224_Exo17_Animals.Animals
{
    public class SeaGull : Animal
    {
        public SeaGull(int age) : base(age) { }

        public void DoYourThing()
        {
            Console.WriteLine("A seagull aged {0} has Done.", Age);
        }

        public override string ToString()
        {
            string s = string.Format("This is a seagull aged {0}", Age);
            return s;
        }

        public override void DoSomething()
        {
            DoYourThing();
        }
    }
}
