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
            Voiture v = creerVoiture();

            Console.WriteLine("Ajouter des options: ");
            Program.OptionsMenu choix = OptionsMenu.MERCI_MAIS_NON_MERCI;
            do
            {
            afficheOptions();
                choix = (OptionsMenu)AskData.askInt();
                switch (choix)
                {
                    case OptionsMenu.PEINTURE_PREMIUM:
                        v = new OptionPeinture(0,v); // TODO
                        break;
                    case OptionsMenu.TOIT_DECAPOTABLE:
                        break;
                    case OptionsMenu.PACK_SPORT:
                        break;
                    default:
                        break;

            }
            } while (choix == OptionsMenu.MERCI_MAIS_NON_MERCI);


        }

    private static Voiture creerVoiture()
    {
        return new Voiture(AskData.askDouble("Prix de base du véhicule: ")); ;
    }

    public static void afficheOptions()
    {
        Console.WriteLine("Option disponibles: ");
        Console.WriteLine("1. Peinture Premium. ");
        Console.WriteLine("2. Pack sport.");
        Console.WriteLine("3. Toit décapotable.");
    }
}
}
