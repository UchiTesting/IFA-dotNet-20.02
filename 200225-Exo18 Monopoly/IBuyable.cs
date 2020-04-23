using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly
{
    interface IBuyable
    {
        public void Buy(Player p);
        public bool HasOwner();
        public string BuyableInfo();
    }
}
