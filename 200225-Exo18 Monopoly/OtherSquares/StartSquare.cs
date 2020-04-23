using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly.OtherSquares
{
    class StartSquare : OtherSquare
    {
        private StartSquare(string newName) : base(newName)
        {

        }

        public StartSquare() : this("Start") {
            SetEffect("Receive $20K.");
        }
    }
}
