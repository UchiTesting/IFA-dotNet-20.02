using System;
using System.Collections.Generic;
using System.Text;

namespace _200221_Exo16_Deck_Manager
{
    public class CreatureTrump : Trump
    {
        protected int manaCost;
        protected int atk;
        protected int def;

        public CreatureTrump(string name, string description, int manaCost, int atk, int def): base(name, description)
        {
            SetManaCost(manaCost);
            SetAtk(atk);
            SetDef(def);
        }

        public int GetManaCost()
        {
            return manaCost;
        }

        public int GetAtk()
        {
            return atk;
        }

        public int GetDef()
        {
            return def;
        }

        public void SetManaCost(int newValue)
        {
            manaCost = newValue;
        }

        public void SetAtk(int newValue)
        {
            atk = newValue;
        }

        public void SetDef(int newValue)
        {
            def = newValue;
        }
    }
}
