using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    class OptionDecapotable : Option
    {
        protected double Prix = 3000;
        public OptionDecapotable(double prix, Voiture voiture) : base(prix, voiture) { }
    }
}
