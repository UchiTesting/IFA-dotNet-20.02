using System;
using System.Collections.Generic;
using System.Text;

namespace _200221_Exo16_Deck_Manager
{
    public class SpellTrump : Trump
    {
        protected int manaCost;
        protected string effect ;

        public SpellTrump(string name, string description, int manaCost, string effect): base(name, description)
        {
            SetManaCost(manaCost);
            SetEffect(effect);
        }

        public int GetManaCost()
        {
            return manaCost;
        }

        public string GetEffect()
        {
            return effect;
        }

        public void SetManaCost(int newValue)
        {
            manaCost = newValue;
        }

        public void SetEffect(string newValue)
        {
            effect = newValue;
        }
    }
}
