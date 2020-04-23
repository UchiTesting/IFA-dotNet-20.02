using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly
{
    class Land : AbstractTerrain, IBuyable
    {
        public Land(string name, int cost, int rent) : base(name, cost, rent)
        {
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
            if (GetOwner() == null)
                return false;

            return true;
        }
    }
}
