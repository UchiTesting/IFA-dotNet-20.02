using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    class OptionSport : Option
    {
        public OptionSport(double prix, Voiture voiture) : base(prix, voiture) { }
    }
}
