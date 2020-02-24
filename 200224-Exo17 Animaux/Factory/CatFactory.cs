using System;
using System.Collections.Generic;
using System.Text;
using static Simple_IO.AskData;
using _200224_Exo17_Animals.Animals;

namespace _200224_Exo17_Animals.Factory
{
    public class CatFactory : PetFactory
    {

        public override Animal Create()
        {
            Cat c = new Cat(askInt("Age: "),
                askString("Name: "));

            return (Animal)c;
        }
    }
}
