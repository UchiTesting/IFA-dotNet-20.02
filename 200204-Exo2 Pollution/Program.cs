using System;

namespace _200204_Exo2_Pollution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exo 2: Taxation de la pollution");

			int taille = 0;
			IPolluant[] polluants = new IPolluant[0];
			char choix;
			double taxe;

			do
			{
				Console.WriteLine("Choix → v: Voiture / e: Entreprise / s: Simulation / q: quitter");
				choix = Console.ReadKey().KeyChar;
				Console.WriteLine("\n");

				switch (choix)
				{
					case 'v':
						modifTable(ref taille, ref polluants, creerVoiture());
						break;
					case 'e':
						modifTable(ref taille, ref polluants, creerEntreprise());
						break;
					case 's':
						taxe = askDouble("Taxe: ");
						simulation(polluants, taille, taxe);
						break;
					default:
						Console.WriteLine("Veuillez fournir une saisie valide, SVP.");
						break;
				}
			} while (choix != 'q');
        }

		static double askDouble()
		{
			bool ok = false;
			double n = -1.0;

			do
			{
				try
				{
					n = Convert.ToDouble(Console.ReadLine());
					ok = true;
				}
				catch (FormatException)
				{
					Console.WriteLine("Veuillez saisir un décimal, SVP.");
				}
			} while (!ok);

			return n;
		}

		static double askDouble(string message)
		{
			Console.Write(message);
			return askDouble();
		}

		static int askInt()
		{
			bool ok = false;
			int n = -1;

			do
			{
				try
				{
					n = Convert.ToInt16(Console.ReadLine());
					ok = true;
				}
				catch (FormatException)
				{
					Console.WriteLine("Veuillez saisir un entier, SVP.");
				}
			} while (!ok);

			return n;
		}

		static int askInt(string message)
		{
			Console.Write(message);
			return askInt();
		}

		static string askString(string message)
		{
			Console.WriteLine(message);
			string str = Console.ReadLine();
			return str;
		}

		static PersAdmin creerPersonneAdmin()
		{
			Console.WriteLine("Création d'une Personne administrative:\n========");

			return new PersAdmin(askString("Nom: "), askString("Prenom: "), askString("DDN: "), askString("ADR: "), askString("INSEE: "));
		}

		static PersMorale creerEntreprise()
		{
			Console.WriteLine("Création d'une Entreprise:\n========");

			return new PersMorale(askString("Nom: "), "", askString("DDC: "), askString("ADR: "), askString("SIRET: "), askInt("Coeff. Pollution: "), creerPersonneAdmin());
		}

		static Voiture creerVoiture()
		{
			Console.WriteLine("Création d'une Voiture:\n========");

			return new Voiture(askString("Marque: "), askString("Couleur: "), askInt("Puissance: "), creerPersonneAdmin());
		}

		static void modifTable(ref int taille, ref IPolluant[] tab, IPolluant polluant)
		{
			if (polluant != null)
			{
				taille++;
				Array.Resize(ref tab, taille);
				tab[taille - 1] = polluant;
			}
		}

		static void simulation(IPolluant[] tab, int taille, double taxe)
		{
			for (int i=1; i <=12; i++)
			{
				Console.WriteLine("Mois "+i);
				for (int j = 0; j < taille; j++)
				{
					int nbJours = 30;
					switch (i)
					{
						case 1: case 3: case 5: case 7: case 8: case 10: case 12:
							nbJours = 31;
							break;
						case 2: nbJours = 28;
							break;
					}
					tab[j].payerPollution(tab[j].calculerPollution(nbJours), taxe * (1+i/10));
				}
			}
		}
	}
}
