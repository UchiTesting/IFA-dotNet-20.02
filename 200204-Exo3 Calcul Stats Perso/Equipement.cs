using System;
using System.Collections.Generic;
using System.Text;

namespace _200204_Exo3_Calcul_Stats_Perso
{
    class Equipement
    {
        string nom;
        Stats stats;

        public Equipement(string nom, Stats stats)
        {
            this.nom = nom;
            this.stats = stats;
        }

        public Stats getStats()
        {
            return this.stats;
        }
    }
}
