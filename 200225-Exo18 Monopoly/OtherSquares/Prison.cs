using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly.OtherSquares
{
    class Prison : OtherSquare
    {
        private Prison(string newName) : base(newName) { }

        public Prison() : this("Prison") {
            SetEffect("You can't get out unless you have a twice the same value.");
        }
    }
}
