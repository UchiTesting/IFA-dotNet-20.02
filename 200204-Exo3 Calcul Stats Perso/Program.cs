using System;
using System.Collections.Generic;
using System.Text;
using Simple_IO;

namespace _200204_Exo3_Calcul_Stats_Perso
{
    class Program
    {
        /**
         * Générer une liste de personnages possédant une liste d'item.
         * Calculer les stats des personnages avec leur items.
         */

        static List<PersonnageAbstrait> persos = new List<PersonnageAbstrait>();
        static void Main(string[] args)
        {
            Console.WriteLine("Exo 3: Calcul de stats de personnages.");

            char choix;

            do
            {
                choix = AskData.askChar("Menu -> p: ajout perso / v: voir stats. / q: quitter. : ");
                Console.WriteLine(" ");

                switch (choix)
                {
                    case 'p': // Créer un perso
                        persos.Add(creerPerso());
                        break;
                    case 'v': // Voir les stats des persos
                        voirStats(persos);
                        break;
                    case 'l': // voir la liste des persos
                        afficherListePerso();
                        break;
                    default:
                        Console.WriteLine("Veuillez fournir une saisie valide, SVP.");
                        break;
                }
            } while (choix != 'q');
        }

        public static PersonnageAbstrait creerPerso()
        {

            PersonnageAbstrait p = null;

            bool ok = false;

            do
            {
                char coffre = AskData.askChar("Utiliser un coffre ? (o/n): ");
                Console.Write("\r\n");

                if (coffre == 'o')
                {
                    p = new PersoCoffreux(AskData.askString("Nom: "),
                    AskData.askInt("ATK: "),
                    AskData.askInt("DEF: "),
                    AskData.askInt("PDV: "),
                    AskData.askInt("VIT: "));
                    ok = true;
                }
                else if (coffre == 'n')
                {
                    p = new Personnage(AskData.askString("Nom: "),
                    AskData.askInt("ATK: "),
                    AskData.askInt("DEF: "),
                    AskData.askInt("PDV: "),
                    AskData.askInt("VIT: "));

                    ok = true;
                }

            } while (!ok);

            List<Equipement> le = creerListeEquipements();

            p.ajouterEquipements(le);

            return p;
        }

        public static List<Equipement> creerListeEquipements()
        {
            List<Equipement> le = new List<Equipement>();
            char choix;

            do
            {
                choix = AskData.askChar("Ajouter un équipement ? (o/n): ");
                Console.WriteLine(" ");

                if (choix == 'o')
                {
                    Equipement e = creerEquipement();
                    le.Add(e);
                }

            } while (choix != 'n');

            return le;
        }

        private static Equipement creerEquipement()
        {
            return new Equipement(AskData.askString("Nom: "),
                AskData.askInt("ATK: "),
                AskData.askInt("DEF: "));

        }

        public static void voirStats(List<PersonnageAbstrait> persos)
        {
            if (persos.Count > 0)
            {
                foreach (PersonnageAbstrait p in persos)
                {
                    Console.WriteLine(p);
                }
            }
            else
            {
                Console.WriteLine("Aucune stat à afficher. Ajoutez des personnages.");
            }
        }

        public static void afficherListePerso()
        {
            Console.Clear();
            if (persos.Count > 0)
            {
                int i = 1;
                StringBuilder builder = new StringBuilder();

                foreach (Personnage perso in persos)
                {
                    builder.AppendLine(i + ") " + perso.Nom);
                    i += 1;
                }

                Console.WriteLine(builder.ToString());
            }
            else
            {
                Console.WriteLine("Liste de personnages vide.");
            }
        }
    }
}
