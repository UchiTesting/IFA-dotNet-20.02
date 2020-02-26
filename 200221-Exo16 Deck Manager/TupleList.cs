using System;
using System.Collections.Generic;
using System.Text;

namespace _200221_Exo16_Deck_Manager
{
    public class NumberedTrumpList<T1, T2> : List<Tuple<T1, T2>>
    {
        public void Add(T1 t, T2 n)
        {
            Add(new Tuple<T1, T2>(t, n));
        }
    }
}
