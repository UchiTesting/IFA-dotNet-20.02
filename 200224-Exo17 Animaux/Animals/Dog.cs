using System;
using System.Collections.Generic;
using System.Text;

namespace _200224_Exo17_Animals.Animals
{
    public class Dog : Pet
    {
        public Dog(int age, string name) : base(age, name) { }

        public void Bark()
        {
            Console.WriteLine(Name+" says Wan!");
        }

        public void FoolingAround()
        {
            Console.WriteLine(":O");
        }

        public override string ToString()
        {
            string s = string.Format("This is a dog named {0} aged{1}", Name, Age);
            return s;
        }

        public override void DoSomething()
        {
            Bark();
        }
    }
}
