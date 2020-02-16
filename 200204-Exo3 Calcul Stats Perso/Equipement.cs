using System;
using System.Collections.Generic;
using System.Text;

namespace _200204_Exo3_Calcul_Stats_Perso
{
    public class Equipement
    {
        public string Nom { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }

        public Equipement(string nom, int atk, int def)
        {
            Nom = nom;
            Atk = atk;
            Def = def;
        }

        override public string ToString()
        {
            return Nom + " -> " + "ATK: "+ Atk +", DEF: "+Def;
        }
    }
}
