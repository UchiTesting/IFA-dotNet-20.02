using System;
using System.Collections.Generic;
using System.Text;
using _200224_Exo17_Animals.Animals;

namespace _200224_Exo17_Animals.Factory
{
    public abstract class PetFactory : AnimalFactory
    {
        public PetFactory() { }
        public abstract override Animal Create();
        
    }

}
