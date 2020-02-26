using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly
{
    class AbstractTerrain : NamedElement, BoardSquare
    {
        public int cost;
        public int rent;

        public AbstractTerrain(string name, int cost, int rent):base(name)
        {
            this.cost = cost;
            this.rent = rent;
        }

        public void payRent()
        {

        }
    }
}
