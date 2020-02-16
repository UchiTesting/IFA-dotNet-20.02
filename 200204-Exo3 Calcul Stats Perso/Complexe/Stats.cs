using System;
using System.Collections.Generic;
using System.Text;
using Simple_IO;

namespace _200204_Exo3_Calcul_Stats_Perso
{
    class Stats
    {
        int atk;
        int def;
        int vitesse;
        int pdv;
        char type;

        public Stats(int atk, int def, int vitesse, int pdv, char type = 'g')
        {
            this.atk = atk;
            this.def = def;
            this.vitesse = vitesse;
            this.pdv = pdv;
            this.type = type;
        }

        public Stats() : this(0, 0, 0, 0) // Default Constructor
        {
            //
        }

        public int Atk { get => atk; set => atk = value; }
        public int Def { get => def; set => def = value; }
        public int Vitesse { get => vitesse; set => vitesse = value; }
        public int Pdv { get => pdv; set => pdv = value; }

        override public string ToString()
        {
            string typeStats;

            if (type == 'g')
            {
                typeStats = "générales";
            }
            else
            {
                typeStats = "bonus";
            }
            //string str;

            return "Stats "+typeStats+" -> [PDV: "+pdv+", ATK: "+atk+", DEF: "+def+", VIT: "+vitesse+"]";
        }


        public void add(Stats stats)
        {
            this.atk += stats.atk;
            this.def += stats.def;
            this.pdv += stats.pdv;
            this.vitesse += stats.vitesse;
        }

        internal static Stats sumList(List<Stats> statList, char forcedType='g')
        {
            Stats stats = new Stats(0, 0, 0, 0, forcedType);

            foreach (Stats statItem in statList)
            {
                stats.add(statItem);
            }

            return stats;
        }

        internal static Stats createStats(char forcedType='g')
        {
            Console.WriteLine("Creation des stats:\n========\n");

            return new Stats(
                AskData.askInt("ATK: "),
                AskData.askInt("DEF: "),
                AskData.askInt("PDV: "),
                AskData.askInt("VIT: "),
                AskData.askChar("Type (g/b): ")
                );
        }

    }
}
