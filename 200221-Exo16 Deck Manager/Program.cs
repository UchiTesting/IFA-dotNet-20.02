using IHMConsole;
using System;
using System.Collections.Generic;
using System.Text;
using static Simple_IO.AskData;

namespace _200221_Exo16_Deck_Manager
{
    class Program
    {
        static MainCanvas mc;
        static Canvas CollectionPane;
        static Canvas DeckPane;
        static Canvas TrumpInfoPane;
        static List<Trump> TrumpCollection;
        static List<(Trump, int)> Deck;
        static void Main(string[] args)
        {
            Console.WriteLine("Exo 16: Deck Manager");

            InitObjects();
            InitDisplay();

        }

        private static void InitObjects()
        {
            TrumpCollection = new List<Trump>();
            Deck = new List<(Trump,int)>();
        }

        private static void InitDisplay()
        {
            /**
             * On th left a list of available trump
             * On the right a list of selected trumps
             * No more than 4 instances of a trump.
             * Terrain trumps are not limited.
             */
            Console.Clear();
            mc = MainCanvas.Instance;

            // Setting up the left pane which contains the full collection of trumps.
            CollectionPane = new Canvas(0, 0, Console.WindowWidth / 2 - 1, Console.WindowHeight - 20);
            CollectionPane.Add(new Label("Test", CollectionPane.X, CollectionPane.Y));

            // Setting up the right pane which contains the selected trumps.
            DeckPane = new Canvas(Console.WindowWidth / 2, 0, Console.WindowWidth / 2 - 1, Console.WindowHeight - 20);
            DeckPane.Add(new Label("Test", DeckPane.X, DeckPane.Y));

            // Setting up the bottom Trump info pane
            TrumpInfoPane = new Canvas(0, CollectionPane.Height, Console.WindowWidth, 20);
            TrumpInfoPane.Add(new Label("Test", TrumpInfoPane.X, TrumpInfoPane.Y));

            mc.Show();
        }

        static Trump CreateTrump()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("What type of trump?:")
                .AppendLine("1) Terrain.")
                .AppendLine("2) Creature.")
                .AppendLine("3) Magic spell.")
                .AppendLine("0) Leave this menu.");

            char choice = '\0';
            Trump t = null;

            do
            {
                Console.WriteLine(sb.ToString());

                switch (choice)
                {
                    case '1':
                        t = new TerrainTrump(askString("Name: "),
                            askString("Description: "));
                        break;
                    case '2':
                        t = new CreatureTrump(askString("Name: "),
                            askString("Description: "),
                            askInt("Mana Cost: "),
                            askInt("ATK: "),
                            askInt("DEF: "));
                        break;
                    case '3':
                        t = new SpellTrump(askString("Name: "),
                            askString("Description: "),
                            askInt("Mana Cost: "),
                            askString("Effect: "));
                        break;
                }

            } while (choice != '0');

            return t;

        }
        static void AddTrumpToCollection()
        {
            if (TrumpCollection.Count < 20) // Limit the number of different trumps 
            {
                Trump t = CreateTrump();
                TrumpCollection.Add(t);
            }

        }
        static void ListTrumpFromCollection()
        {
            TrumpCollection.ForEach(x => Console.WriteLine(x));
        }

        static void AddTrumpToDeck()
        {
            if (Deck.Count < 60)
            {
                ListTrumpFromCollection();
                int trumpNumber = askInt("Trump Number to pick: ");
                Trump t = TrumpCollection[trumpNumber];
                bool alreadyInDeck = CheckIfTrumpAlreadyExistsInDeck(t);

                if (alreadyInDeck)
                {
                    int idx = Deck.FindIndex(x => x.Equals(t));


                }
            }
            else
            {
                Console.WriteLine("Cannot add anymore trumps to the deck for it already has 60 items.");
            }
        }

        private static bool CheckIfTrumpAlreadyExistsInDeck(Trump t)
        {
            return Deck.Exists(x => x.Equals(t));
        }

        static void LoadTrumpCollection()
        {
            throw new NotImplementedException();
        }

        static void SaveTrumpCollection()
        {
            throw new NotImplementedException();
        }

        static void LoadDeck()
        {
            throw new NotImplementedException();
        }

        static void SaveDeck()
        {
            /**
             * A deck cannot exceed 60 trumps.
             * No more than 4 instances of a same trump in the deck.
             */
            throw new NotImplementedException();
        }
    }
}
