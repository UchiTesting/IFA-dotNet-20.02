using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly
{
    class Player : NamedElement
    {
        public int balance;
        public int position;
        public bool CanPlay; // Player is allowed to play
        public bool isInPrison;
        public bool isBankrupt;


        public Player() : this("")
        {
            CanPlay = true;
            position = 0;
            balance = 0;
            isInPrison = false;
            isBankrupt = false;
        }

        public Player(string name) : base(name) { }

        public bool checkPrison()
        {
            return isInPrison;
        }

        public void avancer(int nbSquares)
        {
            if (nbSquares + position > Engine.squares.Count)
            {
                position = Engine.squares.Count - position - 1;
                balance += 20000;
            }
            else
                position += nbSquares;
        }


    }

    enum PIECES
    {
        NONE,
        CAT,
        DOG,
        HAT,
        SHOE
    }
}
