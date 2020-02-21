using System;
using System.Collections.Generic;
using IHMConsole;
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
        static List<Trump> Deck;
        static void Main(string[] args)
        {
            Console.WriteLine("Exo 16: Deck Manager");

            InitObjects();
            InitDisplay();

        }

        private static void InitObjects()
        {
            TrumpCollection = new List<Trump>();
            Deck = new List<Trump>();
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
            CollectionPane = new Canvas(0, 0, Console.WindowWidth/2 - 1, Console.WindowHeight - 20);
            CollectionPane.Add(new Label("Test",CollectionPane.X,CollectionPane.Y));

            // Settng up the right pane chich contains the selected trumps.
            DeckPane = new Canvas(Console.WindowWidth / 2, 0, Console.WindowWidth/2 - 1, Console.WindowHeight - 20);
            DeckPane.Add(new Label("Test",DeckPane.X,DeckPane.Y));

            // Setting up the bottom Trump info pane
            TrumpInfoPane = new Canvas(0, CollectionPane.Height, Console.WindowWidth, 20);
            TrumpInfoPane.Add(new Label("Test",TrumpInfoPane.X,TrumpInfoPane.Y));

            mc.Show();
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
