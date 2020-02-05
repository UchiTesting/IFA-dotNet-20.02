using System;

namespace _200204_Exo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exo1: Gestion patients d'un hôpital.");
            Personne[] personnes = new Personne[0];
            char choix;
            int taille = 0;

            do
            {
                Console.Write("Veuillez choisir un type de personne (h: Homme, f: Femme, m: Mineure): ");
                choix = Console.ReadKey().KeyChar;
                switch (choix)
                {
                    case 'h':
                        taille++;
                        Array.Resize(ref personnes, taille);
                        personnes[taille - 1] = askPersonne();

                        break;
                    case 'f':
                        taille++;
                        Array.Resize(ref personnes, taille);
                        personnes[taille - 1] = askFemme();
                        break;
                    case 'm':
                        taille++;
                        Array.Resize(ref personnes, taille);
                        personnes[taille - 1] = askMineur();
                        break;
                    default:
                        Console.WriteLine("Veuillez saisir une option valide (h: Homme, f: Femme, m: Mineure ou q pour quitter).");
                        break;
                }

            } while (choix != 'q');

            // Affichage
            foreach (Personne p in personnes)
            {
                Console.WriteLine(p);
            }

        }

        static Personne askPersonne()
        {
            bool ok = false;
            Personne p = null;
            do
            {
                try
                {
                    Console.Write("Nom: ");
                    string nom = Console.ReadLine();
                    Console.Write("Prenom: ");
                    string prenom = Console.ReadLine();
                    Console.Write("Date de Naissance: ");
                    string dateDeNaissance = Console.ReadLine();
                    p = new Personne(nom, prenom, dateDeNaissance);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Veuillez saisir des chaines de caractères valides.");
                }

            } while (!ok);

            return p;
        }

        static Mineur askMineur()
        {
            bool ok = false;
            Personne p;
            Personne tuteur;
            Mineur m = null;
            do
            {
                try
                {
                    Console.WriteLine("Mienur:\n======== ");
                    p = askPersonne();
                    Console.WriteLine("Tuteur:\n======== ");
                    tuteur = askPersonne();
                    m = new Mineur(p, tuteur);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Arrêtez de faire n'imp. SVP.");
                }
            } while (!ok);

            return m;
        }

        static Femme askFemme()
        {
            bool ok = false;
            Personne p = null;
            Femme f = null;
            string nomDeJeuneFille;

            do
            {
                try
                {
                    p = askPersonne();
                    Console.WriteLine("Nom de jeune fille: ");
                    nomDeJeuneFille = Console.ReadLine();
                    f = new Femme(p, nomDeJeuneFille);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Arrêtez de faire n'imp. SVP.");
                }
            } while (!ok);

            return f;
        }


    }
}