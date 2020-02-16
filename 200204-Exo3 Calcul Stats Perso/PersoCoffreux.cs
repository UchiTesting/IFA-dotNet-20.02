using System;
using System.Collections.Generic;
using System.Text;

namespace _200204_Exo3_Calcul_Stats_Perso
{
    class PersoCoffreux: PersonnageAbstrait
    {
        public Coffre coffre = new Coffre();
        public PersoCoffreux(string nom, int atk, int def, int pdv, int vit) : base(nom, atk, def, pdv, vit)
        {
            Equipements = coffre.ListeEquipements;

        }

        public override void ajouterEquipement(Equipement e)
        {
            coffre.ajouterEquipement(e);
        }

        public override void ajouterEquipements(List<Equipement> le)
        {
            if (le.Count > 0)
            {
                try
                {
                    coffre.ListeEquipements.AddRange(le);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Liste d'équipements vide.");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("C'est quoi ce délire ?");
                }
            }        
        }

        public override int[] calculerStatsBonus()
        {
            int[] bonus = { 0, 0 };

            if (coffre.ListeEquipements.Count > 0)
            {
                foreach (Equipement e in coffre.ListeEquipements)
                {
                    bonus[0] = e.Atk;
                    bonus[1] = e.Def;
                }
            }

            return bonus;
        }

        public override string afficherEquipements()
        {
            StringBuilder builder = new StringBuilder();

            if (coffre.ListeEquipements.Count > 0)
            {
                builder.AppendLine("Liste des équipements dans le coffre:\n========");

                foreach (Equipement e in coffre.ListeEquipements)
                {
                    builder.AppendLine(string.Format("--------"));
                    builder.AppendLine(string.Format("Nom: {0}", e.Nom));
                    builder.AppendLine(string.Format("ATK: {0}", e.Atk));
                    builder.AppendLine(string.Format("DEF: {0}", e.Def));
                }
            }
            else
            {
                builder.AppendLine("Ce coffre ne contient pas d'équipement.");
            }

            return builder.ToString();
        }

        public override string ToString()
        {
            int[] bonus = calculerStatsBonus();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("Stats du personnage à coffre: {0} \n========", Nom));
            builder.AppendLine(string.Format("ATK: {0} ({1}) -> {2}", Atk, bonus[0], bonus[0] + Atk));
            builder.AppendLine(string.Format("DEF: {0} ({1}) -> {2}", Def, bonus[1], bonus[1]+Def));
            builder.AppendLine(string.Format("PDV: {0}", Pdv));
            builder.AppendLine(string.Format("VIT: {0}", Vit));
            builder.AppendLine(string.Format(""));
            builder.AppendLine(afficherEquipements());

            return builder.ToString();
        }
    }

}
