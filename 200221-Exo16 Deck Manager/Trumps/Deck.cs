using System;
using System.Collections.Generic;
using System.Text;

namespace _200221_Exo16_Deck_Manager.Trumps
{
    class Deck
    {
        List<DeckTrump> deckTrumps = null;
        private static Deck Instance = null;

        protected Deck(){}

        public Deck GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Deck();
            }

            return Instance;
        }

        public void Add(Trump t)
        {
        }
        
    }
}
