using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    class OptionSport : Option
    {
        double Prix = 1000;
        public OptionSport(double prix, Voiture voiture) : base(prix, voiture)
        {
            Prix += base.Prix;
            this.voiture = voiture;
        }
    }
}
