using System;

namespace _200204_Exo1
{
    class Program
    {
        static Personne[] personnes = new Personne[0];

        static void Main(string[] args)
        {
            Console.WriteLine("Exo1: Gestion patients d'un hôpital.");
            char choix;
            int taille = 0;

            do
            {
                choix = '\0';
                Console.Write("Veuillez choisir un type de personne (h: Homme, f: Femme, m: Mineur(e), v: visualiser, q:quitter): ");
                choix = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (string.Format("hfm").Contains(choix))
                {
                    taille++;
                    Array.Resize(ref personnes, taille);
                }

                switch (choix)
                {
                    case 'h':
                        Console.WriteLine("Homme\n========\n");
                        personnes[taille - 1] = askPersonne();

                        break;
                    case 'f':
                        Console.WriteLine("Femme\n========\n");
                        personnes[taille - 1] = askFemme();
                        break;
                    case 'm':
                        personnes[taille - 1] = askMineur();
                        break;
                    case 'v':
                        voirListePersonnes();
                        break;
                    default:
                        Console.WriteLine("Veuillez saisir une option valide (h: Homme, f: Femme, m: Mineur(e), v: voir liste ou q pour quitter).");
                        break;
                }

            } while (choix != 'q');
        }

        private static void voirListePersonnes()
        {
            if (personnes.Length > 0)
            {
                foreach (Personne p in personnes)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            else
            {
                Console.WriteLine("La liste est vide.");
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
                    ok = true;
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
                    Console.WriteLine("Mineur:\n======== ");
                    p = askPersonne();
                    Console.WriteLine("Tuteur:\n======== ");
                    tuteur = askPersonne();
                    m = new Mineur(p, tuteur);
                    ok = true;
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
                    ok = true;
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