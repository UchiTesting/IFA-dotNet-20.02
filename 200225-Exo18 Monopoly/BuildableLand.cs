using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly
{
    class BuildableLand : AbstractTerrain
    {
        public BuildableLand(string name, int cost, int rent) : base(name, cost, rent)
        {
        }
    }
}
