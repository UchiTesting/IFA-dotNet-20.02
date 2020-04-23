using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly.OtherSquares
{
    class ChanceSquare : OtherSquare
    {
        private ChanceSquare(string newName) : base(newName) { }

        public ChanceSquare() : this("Chance Square")
        {
            SetEffect("Pick a chance card.");
        }
    }
}
