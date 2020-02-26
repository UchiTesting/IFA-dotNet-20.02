using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly
{
    class Dice
    {
        public int  nbFaces;
        public int currentValue;

        public void roll()
        {
            Random rnd = new Random();

            currentValue = rnd.Next(1, 6 + 1);
        }
    }
}
