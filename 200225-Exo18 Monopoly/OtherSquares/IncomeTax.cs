using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly.OtherSquares
{
    class IncomeTax : OtherSquare
    {
        private IncomeTax(string newName) : base(newName) { }

        public IncomeTax() : this("Income Tax") {
            SetEffect("Pay $100.");
        }
    }
}
