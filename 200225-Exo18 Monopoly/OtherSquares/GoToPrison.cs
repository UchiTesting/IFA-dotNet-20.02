using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly.OtherSquares
{
    public class GoToPrison : OtherSquare
    {
        private GoToPrison(string newName) : base(newName) { }

        public GoToPrison() : this("Go to Prison") {
            SetEffect("Go to prison.");
        }
    }
}
