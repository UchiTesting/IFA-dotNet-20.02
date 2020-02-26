using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly
{
    class Card : NamedElement
    {
        public string effect;

        public Card(string name, string effect):base(name)
        {
            this.effect = effect;
        }
    }
}
