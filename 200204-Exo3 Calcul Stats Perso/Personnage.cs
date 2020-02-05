using System;
using System.Collections.Generic;
using System.Text;

namespace _200204_Exo3_Calcul_Stats_Perso
{
    class Personnage
    {
        private string nom = null;
        private Stats statsBase = null;
        private Stats statsBonus = null;
        List<Equipement> equipements = new List<Equipement>();

        public Personnage(string nom, Stats statsBase, Stats statsBonus)
        {
            this.nom = nom; 
            this.statsBase = statsBase;
            this.statsBonus = new Stats(AskData.askInt());
        }

        private Stats calculStatsBonus()
        {
            int bonusPdv = 0;
            int bonusAtk = 0;
            int bonusDef = 0;
            int bonusVit = 0;

            foreach( Equipement e in equipements)
            {
                bonusPdv += e.getStats().
            }


            return new Stats(bonusAtk, bonusDef, bonusVit, bonusPdv, 'b');
        }
    }
}
