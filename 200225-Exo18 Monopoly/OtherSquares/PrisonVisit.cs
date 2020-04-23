using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly.OtherSquares
{
    public class PrisonVisit : OtherSquare
    {
        public PrisonVisit(string newName) : base(newName) { }

        public PrisonVisit() : this("Prison Visit")
        {
            SetEffect("Simple visit in prison");
        }
    }
}
