using System;
using System.Collections.Generic;
using System.Text;
using static Simple_IO.AskData;

namespace _200225_Exo18_Monopoly
{
    class Engine
    {
        List<Dice> dices;
        List<Player> players;
        public static List<BoardSquare> squares;
        private const int MAX_PLAYERS = 4;
        /// <summary>
        /// Initializes the game engine.
        /// </summary>
        public void InitGame()
        {
            dices = new List<Dice>();
            dices.Add(new Dice());
            dices.Add(new Dice());

            players = new List<Player>();
            SetupNbPlayers();

            squares = new List<BoardSquare>();
            squares.Add(new OtherSquare());
        }

        /// <summary>
        /// Asks for the number of players in the game.
        /// </summary>
        private void SetupNbPlayers()
        {
            int numberOfPlayers;
            do
            {
                numberOfPlayers = askInt("Number of players: ");
            } while (numberOfPlayers > MAX_PLAYERS || numberOfPlayers < 1);

            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player());
            }
        }

        /// <summary>
        /// The central method to run the game.
        /// Sequences the operations of a turn.
        /// </summary>
        public void Turn()
        {
            foreach (Player p in players)
            {
                if (!p.checkPrison())
                {
                    foreach (Dice d in dices)
                    {
                        d.roll();
                    }

                    p.avancer(GetDicesValues()[0]);

                    BoardSquare bs = squares[p.position];

                    if (bs.GetType() == typeof(OtherSquare))
                    {
                        //
                    } else if (SquareIsBuyable())
                    {
                        ProposeTerrainAquisition();
                    }
                }
            }

        }

        private bool SquareIsBuyable()
        {

        }

        /// <summary>
        /// An Array of 3 integers.
        /// 0 is the sum.
        /// 1 and 2 are the value of their resepective dices.
        /// </summary>
        /// <returns>An array of integers</returns>
        public int[] GetDicesValues()
        {
            int[] values = new int[3];
            for (int i = 1; i < values.Length; i++)
            {
                values[0] += dices[i].currentValue;
                values[i] = dices[i].currentValue;
            }
            return values;
        }

        /// <summary>
        /// Checks if all the dices in the list have the same value.
        /// </summary>
        /// <returns>bool</returns>
        public bool DicesHasSameValues()
        {
            for (int i = 0; i < dices.Count - 1; i++)
            {
                if (dices[i] != dices[i + 1])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks the conditions for the end of game.
        /// </summary>
        /// <returns></returns>
        public bool checkEndOfGame()
        {
            throw new NotImplementedException();
        }
    }
}
