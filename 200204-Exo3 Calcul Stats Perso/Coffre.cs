using System.Collections.Generic;
using System.Text;

namespace _200204_Exo3_Calcul_Stats_Perso
{
    public class Coffre 
    {
        public List<Equipement> ListeEquipements { get; set; }

        public Coffre()
        {
            ListeEquipements = new List<Equipement>();
        }

        public void ajouterEquipement(Equipement e)
        {
            ListeEquipements.Add(e);
        }

        public string afficherEquipements()
        {
            StringBuilder builder = new StringBuilder();

            if (ListeEquipements.Count > 0)
            {
                builder.AppendLine("Liste des équipements:\n========");

                foreach (Equipement e in ListeEquipements)
                {
                    builder.AppendLine(string.Format("--------"));
                    builder.AppendLine(string.Format("Nom: {0}", e.Nom));
                    builder.AppendLine(string.Format("ATK: {0}", e.Atk));
                    builder.AppendLine(string.Format("DEF: {0}", e.Def));
                }
            }
            else
            {
                builder.AppendLine("Ce coffre n'a pas d'équipement.");
            }

            return builder.ToString();
        }

        public override string ToString()
        {
            return "Coffre contenant " + ListeEquipements.Count + " objets.";
        }

    }
}