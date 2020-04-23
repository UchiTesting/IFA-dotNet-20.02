using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly.OtherSquares
{
    class CommunityChest : OtherSquare
    {
        private CommunityChest(string newName) : base(newName)
        {
        }

        public CommunityChest() : this("Community Chest") {
            SetEffect("Pick a comunity chest card.");
        }
    }
}
