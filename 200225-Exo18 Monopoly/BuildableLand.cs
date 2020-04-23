using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly
{
    class BuildableLand : AbstractTerrain, IBuyable
    {
        string Color;
        public BuildableLand(string name, int cost, int rent, string color) : base(name, cost, rent)
        {
            Color = color;
        }

        public void Buy(Player p)
        {
            SetOwner(p);
        }

        public string BuyableInfo()
        {
            return GetName() + " priced " + GetCost();
        }

        public bool HasOwner()
        {
            if (GetOwner() != null)
                return true;

            return false;
        }
    }
}
