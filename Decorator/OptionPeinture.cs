using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    class OptionPeinture : Option
    {
        public OptionPeinture(double prix, Voiture voiture) : base(prix, voiture)
        {
            Prix = 500 + base.Prix;
            this.voiture = voiture;
        }
    }
}
