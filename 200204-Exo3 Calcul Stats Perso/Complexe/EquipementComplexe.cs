using System;
using System.Collections.Generic;
using System.Text;

namespace _200204_Exo3_Calcul_Stats_Perso
{
    class EquipementComplexe
    {
        string nom;
        Stats stats;

        public EquipementComplexe(string nom, Stats stats)
        {
            this.Nom = nom;
            this.Stats = stats;
        }

        public string Nom { get => nom; set => nom = value; }
        internal Stats Stats { get => stats; set => stats = value; }
        
        override public string ToString()
        {
            return Nom + " -> " + Stats;
        }
    }
}
