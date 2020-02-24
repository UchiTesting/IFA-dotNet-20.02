using System;
using System.Collections.Generic;
using System.Text;
using static Simple_IO.AskData;
using _200224_Exo17_Animals.Animals;

namespace _200224_Exo17_Animals.Factory
{
    public class DogFactory : PetFactory
    {
        public override Animal Create()
        {
            Dog d = new Dog(askInt("Age: "),
                askString("Name: "));
            return (Animal)d;
        }
    }
}
