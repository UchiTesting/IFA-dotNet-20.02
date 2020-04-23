using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly.OtherSquares
{
    class LuxuryTax : OtherSquare
    {
        private LuxuryTax(string newName) : base(newName) { }

        public LuxuryTax() : this("Luxury Tax") {
            SetEffect("Pay $1000");
                }
    }
}
