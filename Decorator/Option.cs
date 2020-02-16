using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    class Option : Voiture
    {
        protected Voiture voiture { get; set; }

        public Option(double prix, Voiture voiture) : base(prix)
        {
            this.voiture = voiture;
            this.voiture.Prix += voiture.Prix;
        }

        public Option(Voiture v) : this(v.Prix, v)
        {
            //
        }

        public override string ToString()
        {
            return "Prix du véhicule avec les options: "+Prix;
        }
    }
}
