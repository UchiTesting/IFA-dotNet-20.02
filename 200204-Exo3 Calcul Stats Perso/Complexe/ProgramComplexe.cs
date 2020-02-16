using System;
using System.Collections.Generic;
using Simple_IO;

namespace _200204_Exo3_Calcul_Stats_Perso
{
    class ProgramComplexe
    {
        /**
         * Générer une liste de personnages possédant une liste d'item.
         * Calculer les stats des personnages avec leur items.
         */

        /*static void Main(string[] args)
        {
            Console.WriteLine("Exo 3: Calcul de stats de personnages.");

            List<Personnage> persos = null;
            char choix;

            do
            {
                choix = AskData.askChar("Menu -> p: ajout perso / v: voir stats. / q: quitter. : ");

                switch (choix)
                {
                    case 'p': // Créer un perso
                        persos.Add(creerPerso());
                        break;
                    case 'v': // Voir les stats des persos
                        voirStats(persos);
                        break;
                    default:
                        Console.WriteLine("Veuillez fournir une saisie valide, SVP.");
                        break;
                }
            } while (choix != 'q');

        }
        public static Personnage creerPerso()
        {
            Console.WriteLine("Création d'un personnage\n========");
            string nom = AskData.askString("Nom: ");
            List<Equipement> le = new List<Equipement>();
            char choix;

            do
            {
                choix = AskData.askChar("Ajouter un équipement ? (o/n): ");

                if (choix == 'o')
                {
                    le.Add(creerEquipement());
                }

            } while (choix != 'n');

            return new Personnage(nom, Stats.createStats(), Stats.createStats(),le);
        }

        public static void creerEquipement(Personnage perso)
        {
            perso.addEquipment(creerEquipement());
        }

        public static Equipement creerEquipement()
        {
            Console.WriteLine("Création d'un équipement\n========");
            string nom = AskData.askString("Nom: ");
            Equipement tempEquipment = new Equipement(nom, Stats.createStats());

            return tempEquipment;
        }

        public static void voirStatsPerso(Personnage p)
        {
            // Utilise ToString pour afficher les détails.
            Console.WriteLine("Stats du Personnage: "+p.Nom);
        }

        public static void voirStats(List<Personnage> persos)
        {
            foreach (Personnage p in persos)
            {
                voirStatsPerso(p);
            }
        }*/
    }
}
