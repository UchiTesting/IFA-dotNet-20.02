using System;
using System.Collections.Generic;
using System.Text;
using Simple_IO;

namespace _200204_Exo3_Calcul_Stats_Perso
{
    class PersonnageComplexe
    {
        private string nom = null;
        private Stats baseStats = null;
        private Stats bonusStats = null;
        List<EquipementComplexe> equipements = new List<EquipementComplexe>();

        public string Nom { get => nom; set => nom = value; }
        internal Stats BaseStats { get => baseStats; set => baseStats = value; }
        internal Stats BonusStats { get => bonusStats; set => bonusStats = value; }

        public PersonnageComplexe(string nom, Stats statsBase, Stats statsBonus, List<EquipementComplexe> equipements)
        {
            this.Nom = nom;
            this.BaseStats = statsBase;
            this.BonusStats = calculStatsBonus();
            this.equipements = equipements;
        }

        private Stats calculStatsBonus()
        {
            int bonusPdv = 0;
            int bonusAtk = 0;
            int bonusDef = 0;
            int bonusVit = 0;

            if (equipements.Count > 0)
            {
                foreach (EquipementComplexe e in equipements)
                {
                    bonusAtk += e.Stats.Atk;
                    bonusDef += e.Stats.Def;
                    bonusPdv += e.Stats.Pdv;
                    bonusVit += e.Stats.Vitesse;
                }
            }

            return new Stats(bonusAtk, bonusDef, bonusVit, bonusPdv, 'b');
        }

        public void addEquipment(EquipementComplexe e)
        {
            equipements.Add(e);
        }

        public void listEquipments()
        {
            if (equipements.Count > 0)
            {
                foreach (EquipementComplexe e in equipements)
                {
                    Console.WriteLine(e.Nom + " " + e.Stats);
                }
            }
        }
    }
}
