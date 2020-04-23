using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly.OtherSquares
{
    public class OtherSquare : BoardSquare
    {
        public string effect;

        public OtherSquare(string newName) : base(newName)
        {
        }
        public string GetEffect() { return effect; }

        public void SetEffect(string newEffect) { effect = newEffect; }
    }
}
