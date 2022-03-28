using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    class Option : Voiture
    {
        protected Voiture _voiture { get; set; }
        // Prix = prix;

        public Option(double prix, Voiture voiture) : base(prix)
        {
            _voiture = voiture;
            Prix += _voiture.Prix;
        }

        public Option(Voiture v) : this(v.Prix, v) { }

        public override string ToString() => $"Prix du véhicule avec les options: {Prix}";
    }
}
