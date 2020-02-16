using System;
using System.Collections.Generic;
using System.Text;

namespace _200204_Exo3_Calcul_Stats_Perso
{
    class Personnage : PersonnageAbstrait
    {
        private List<Equipement> Equipements { get; set; }

        public Personnage(string nom, int atk, int def, int pdv, int vit) : base(nom, atk, def, pdv, vit)
        {

        }

        public override void ajouterEquipement(Equipement e)
        {
            base.ajouterEquipement(e);
        }

        public override void ajouterEquipements(List<Equipement> le)
        {
            base.ajouterEquipements(le);
        }

        public override int[] calculerStatsBonus()
        {
            return base.calculerStatsBonus();
        }

        public override string afficherEquipements()
        {
            return base.afficherEquipements();
        }

        override public string ToString()
        {
            int[] bonus = calculerStatsBonus();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("Stats du personnage: {0} \n========", Nom));
            builder.AppendLine(string.Format("ATK: {0} ({1}) -> {2}", Atk, bonus[0], bonus[0] + Atk));
            builder.AppendLine(string.Format("DEF: {0} ({1}) -> {2}", Def, bonus[1], bonus[1] + Def));
            builder.AppendLine(string.Format("PDV: {0}", Pdv));
            builder.AppendLine(string.Format("VIT: {0}", Vit));
            builder.AppendLine(string.Format(""));
            builder.AppendLine(afficherEquipements());

            return builder.ToString();
        }
    }
}
