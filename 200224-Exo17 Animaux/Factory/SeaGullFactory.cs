using System;
using System.Collections.Generic;
using System.Text;
using static Simple_IO.AskData;
using _200224_Exo17_Animals.Animals;

namespace _200224_Exo17_Animals.Factory
{
    public class SeaGullFactory : AnimalFactory
    {
        public SeaGullFactory() : base() { }

        public override Animal Create()
        {
            SeaGull s = new SeaGull(askInt("Age: "));
            return (Animal)s;
        }
    }
}
