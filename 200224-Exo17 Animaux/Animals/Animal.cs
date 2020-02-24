using System;
using System.Collections.Generic;
using System.Text;

namespace _200224_Exo17_Animals.Animals
{
    public abstract class Animal
    {
        public int Age {get;set;}

        protected Animal(int age)
        {
            Age = age;
        }

        public abstract void DoSomething();
    }
}
