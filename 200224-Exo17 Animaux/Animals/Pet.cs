using System;
using System.Collections.Generic;
using System.Text;

namespace _200224_Exo17_Animals.Animals
{
    public abstract class Pet : Animal
    {
        public string Name { get; set; }
         protected Pet(int age, string name) : base(age)
        {
            Name = name;
        }

        //public abstract override void DoSomething();
    }
}
