using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    class CreatureFactory
    {
        CreatureFactory()
        {
        }

        public AbstractFactory Create() // cf AbstractFactory
        {
            CreatureFactory cf = new CreatureFactory();
            return null;
        }
    }

    class Creature
    {

    }
}
