using System;
using System.Collections.Generic;
using System.Text;

namespace _200221_Exo16_Deck_Manager.Trumps
{
    abstract class DeckTrump
    {
        Trump t = null;
        short instances;
        int maxInstances;

        DeckTrump(Trump t, int maxInstances = 4)
        {
            this.t = t;
            instances = 0;
        }

        public void AddInstance()
        {
            if (instances < maxInstances)
            {
                instances++;
            }
        }

        public void RemoveInstance()
        {
            if (instances > 0)
            {
                instances--;
            }
        }

        public void UpdateTrump(Trump t)
        {
            this.t = t;
        }
    }
}
