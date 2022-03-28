using Simple_IO;

using System;

namespace Decorator
{
    class Program
    {
        enum OptionsMenu
        {
            MERCI_MAIS_NON_MERCI,
            PEINTURE_PREMIUM,
            PACK_SPORT,
            TOIT_DECAPOTABLE
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Design Pattern Decorator");
            Voiture v = CreerVoiture();

            Console.WriteLine("Ajouter des options: ");
            OptionsMenu choix = OptionsMenu.MERCI_MAIS_NON_MERCI;

            do
            {
                AfficheOptions();
                choix = (OptionsMenu)AskData.AskInt();


                switch (choix)
                {
                    case OptionsMenu.PEINTURE_PREMIUM:
                        v = new OptionPeinture(200, v);
                        break;
                    case OptionsMenu.TOIT_DECAPOTABLE:
                        v = new OptionDecapotable(500, v);
                        break;
                    case OptionsMenu.PACK_SPORT:
                        v = new OptionSport(300, v);
                        break;
                    default:
                        break;
                }

                Console.WriteLine(v);
            } while (choix != OptionsMenu.MERCI_MAIS_NON_MERCI);
        }

        private static Voiture CreerVoiture()
        {
            return new Voiture(AskData.AskDouble("Prix de base du véhicule: ")); ;
        }

        public static void AfficheOptions()
        {
            Console.WriteLine("Option disponibles: ");
            Console.WriteLine("1. Peinture Premium. ");
            Console.WriteLine("2. Pack sport.");
            Console.WriteLine("3. Toit décapotable.");
        }
    }
}
