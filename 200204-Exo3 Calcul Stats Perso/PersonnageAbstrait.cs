using System;
using System.Collections.Generic;
using System.Text;

namespace _200204_Exo3_Calcul_Stats_Perso
{
    class PersonnageAbstrait
    {
        public string Nom {  get; protected set; }

        public int Atk { get; protected set; }

        public int Def { get; protected set; }
        public int Pdv { get; protected set; }
        public int Vit { get; protected set; }
        protected List<Equipement> Equipements { get; set; }
        public PersonnageAbstrait(string nom, int atk, int def, int pdv, int vit)
        {
            Nom = nom;
            Atk = atk;
            Pdv = pdv;
            Vit = vit;
            Equipements = new List<Equipement>();
        }

        public virtual void ajouterEquipement(Equipement e)
        {
            Equipements.Add(e);
        }

        public virtual void ajouterEquipements(List<Equipement> le)
        {
            Console.WriteLine(string.Format("Nombre d'équipements: {0}", le.Count));
            if (le.Count > 0)
            {
                try
                {
                    Equipements.AddRange(le);
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

        public virtual int[] calculerStatsBonus()
        {
            // O is ATk 1 is DEF
            int[] bonus = { 0, 0 };
            if (Equipements.Count > 0)
            {

                foreach (Equipement e in Equipements)
                {
                    bonus[0] += e.Atk;
                    bonus[1] += e.Def;
                }
            }

            return bonus;
        }

        public virtual string afficherEquipements()
        {
            StringBuilder builder = new StringBuilder();

            if (Equipements.Count > 0)
            {
                builder.AppendLine("Liste des équipements:\n========");

                foreach (Equipement e in Equipements)
                {
                    builder.AppendLine(string.Format("--------"));
                    builder.AppendLine(string.Format("Nom: {0}", e.Nom));
                    builder.AppendLine(string.Format("ATK: {0}", e.Atk));
                    builder.AppendLine(string.Format("DEF: {0}", e.Def));
                }
            }
            else
            {
                builder.AppendLine("Ce Personnage n'a pas d'équipement.");
            }

            return builder.ToString();
        }
    }

}
