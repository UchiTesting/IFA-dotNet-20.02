using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly.OtherSquares
{
    class FreeParking : OtherSquare
    {
        private FreeParking(string newName) : base(newName) { }
        public FreeParking() : this("Free Parking") {
            SetEffect("Free Parking. Have a cool stay.");
        }
    }
}
