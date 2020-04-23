using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly
{
    class Building : BuildableLand
    {
        public int price;

        public Building(string name, int cost, int rent) : base(name, cost, rent)
        {
        }
    }
}
