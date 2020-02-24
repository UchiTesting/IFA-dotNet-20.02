using System;
using System.Collections.Generic;
using System.Text;

namespace _200224_Exo17_Animals.Animals
{
    public class Cat : Pet
    {
        public Cat(int age, string name) : base(age, name) { }

        public void Meow()
        {
            Console.WriteLine(Name+" says Meow!");
        }

        public void Hunt()
        {
            Console.WriteLine(Name+" haz hunted prey.");
        }

        public override string ToString()
        {
            string s = string.Format("This is a cat named {0} aged {1}", Name, Age);
            return s;
        }

        public override void DoSomething()
        {
            Hunt();
        }
    }
}
