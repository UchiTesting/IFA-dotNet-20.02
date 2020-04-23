using System;
using System.Collections.Generic;
using System.Text;
using static Simple_IO.AskData;
using _200225_Exo18_Monopoly.Exceptions;
using _200225_Exo18_Monopoly.OtherSquares;

namespace _200225_Exo18_Monopoly
{
    class Engine
    {
        List<Dice> dices;
        List<Player> players;
        public static List<BoardSquare> squares;

        private static Engine Instance = null;
        private const int MAX_PLAYERS = 4;
        private byte selectedPieces;

        private Engine()
        {
            selectedPieces = 0;
        }
        /// <summary>
        /// Singleton Pattern for there is only one instance of the engine.
        /// </summary>
        /// <returns></returns>
        public static Engine getInstance()
        {
            if (Instance == null)
            {
                Instance = new Engine();
            }

            return Instance;
        }

        /// <summary>
        /// Initializes the game engine.
        /// </summary>
        public void InitGame()
        {
            dices = new List<Dice>();
            dices.Add(new Dice());
            dices.Add(new Dice());

            players = new List<Player>();
            InitPlayers();

            squares = new List<BoardSquare>();
            InitBoard();
        }

        private void InitPlayers()
        {
            SetupNbPlayers();

            foreach (Player p in players)
            {
                ShowAvailablePieces();
                p.SetPiece(AssignPiece());
                Console.WriteLine("Player got assigned piece " + p.GetPiece());
            }
        }

        /// <summary>
        /// Shows the pieces that were not selected yet by any player.
        /// </summary>
        private void ShowAvailablePieces()
        {
            if ((selectedPieces & 1 << 0) == 0)
                Console.WriteLine("1) CAT");
            if ((selectedPieces & 1 << 1) == 0)
                Console.WriteLine("2) DOG");
            if ((selectedPieces & 1 << 2) == 0)
                Console.WriteLine("3) HAT");
            if ((selectedPieces & 1 << 3) == 0)
                Console.WriteLine("4) SHOE");
        }
        /// <summary>
        /// Returns a Piece to be assigned to a player.
        /// </summary>
        /// <returns>PIECES</returns>
        private PIECES AssignPiece()
        {
            int option;
            do
            {
                option = askInt("What piece do you want to pick?: ");
            } while ((selectedPieces & 1 << (option - 1)) != 0);

            switch (option)
            {
                case 1:
                    ToggleBit(ref selectedPieces, 0);
                    return PIECES.CAT;
                case 2:
                    ToggleBit(ref selectedPieces, 1);
                    return PIECES.DOG;
                case 3:
                    ToggleBit(ref selectedPieces, 2);
                    return PIECES.HAT;
                case 4:
                    ToggleBit(ref selectedPieces, 3);
                    return PIECES.SHOE;
            }
            return 0;
        }
        /// <summary>
        /// Toggles the bit at position pos in a byte.
        /// Therefore pos cannot take a value over 7.
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="pos"></param>
        private void ToggleBit(ref byte b, byte pos)
        {
            if (pos < 7)
                b = (byte)(b ^ 1 << pos);
            else
                throw new OutOfBytePositionException("A byte is 8 bits hence max position must sit in interval [0,7]");
        }

        private static void InitBoard()
        {
            squares.Add(new StartSquare());
            squares.Add(new BuildableLand("", 1000, 500, "brown"));
            squares.Add(new CommunityChest());
            squares.Add(new BuildableLand("", 1000, 500, "brown"));
            squares.Add(new IncomeTax());
            squares.Add(new Land("Station A", 1000, 500));
            squares.Add(new BuildableLand("", 1000, 500, "Cyan"));
            squares.Add(new ChanceSquare());
            squares.Add(new BuildableLand("", 1000, 500, "Cyan"));
            squares.Add(new BuildableLand("", 1000, 500, "Cyan"));

            squares.Add(new PrisonVisit());
            squares.Add(new BuildableLand("", 1000, 500, "Magenta"));
            squares.Add(new Land("Electricity", 100, 500));
            squares.Add(new BuildableLand("", 1000, 500, "Magenta"));
            squares.Add(new BuildableLand("", 1000, 500, "Magenta"));
            squares.Add(new Land("Station B", 1000, 500));
            squares.Add(new BuildableLand("", 1000, 500, "Orange"));
            squares.Add(new CommunityChest());
            squares.Add(new BuildableLand("", 1000, 500, "Orange"));
            squares.Add(new BuildableLand("", 1000, 500, "Orange"));

            squares.Add(new FreeParking());
            squares.Add(new BuildableLand("", 1000, 500, "Red"));
            squares.Add(new ChanceSquare());
            squares.Add(new BuildableLand("", 1000, 500, "Red"));
            squares.Add(new BuildableLand("", 1000, 500, "Red"));
            squares.Add(new Land("Station C", 1000, 500));
            squares.Add(new BuildableLand("", 1000, 500, "Yellow"));
            squares.Add(new BuildableLand("", 1000, 500, "Yellow"));
            squares.Add(new Land("Water", 100, 500));
            squares.Add(new BuildableLand("", 1000, 500, "Yellow"));

            squares.Add(new GoToPrison());
            squares.Add(new BuildableLand("", 1000, 500, "Green"));
            squares.Add(new BuildableLand("", 1000, 500, "Green"));
            squares.Add(new CommunityChest());
            squares.Add(new BuildableLand("", 1000, 500, "Green"));
            squares.Add(new Land("Station D", 1000, 500));
            squares.Add(new ChanceSquare());
            squares.Add(new BuildableLand("", 1000, 500, "Blue"));
            squares.Add(new LuxuryTax());
            squares.Add(new BuildableLand("", 1000, 500, "Blue"));
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
                if (!p.GetPrisonState())
                {
                    RollDices();
                    // GetDiceValues()[0] is the sum of the dice values
                    p.Move(GetDicesValues()[0]);

                    BoardSquare bs = squares[p.GetPosition()];

                    if (bs.GetType() == typeof(OtherSquare))
                    {
                        ((OtherSquare)bs).GetEffect();
                    }
                    else if (SquareIsBuyable(bs))
                    {
                        ProposeTerrainAquisition(p, bs as IBuyable);
                    }
                    else if (((AbstractTerrain)bs).HasOwner())
                    {
                        AbstractTerrain RentableTerrain = ((AbstractTerrain)bs);
                        p.TransferFund(RentableTerrain.GetOwner(), RentableTerrain.GetCost());
                    }
                }
                else
                {
                    // Try to get out of prison
                    RollDices();

                    if (DicesHasSameValues())
                    {
                        p.SetPrisonState(false);
                    }
                }
            }

        }

        private void RollDices()
        {
            foreach (Dice d in dices)
            {
                d.roll();
            }
        }

        private void ProposeTerrainAquisition(Player p, IBuyable b)
        {
            char choice;
            do
            {
                choice = askChar("Do you want to buy " + b.BuyableInfo() + "? (y/n): ");
            } while (!"yn".Contains(choice));

            if (choice == 'y')
                b.Buy(p);
        }

        private bool SquareIsBuyable(BoardSquare b)
        {
            if (b is IBuyable)
            {
                if (!((IBuyable)b).HasOwner())
                    return true;
            }

            return false;
        }

        /// <summary>
        /// An Array of 3 integers.
        /// 0 is the sum.
        /// 1 and further are the value of their resepective dices.
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
            int count = players.Count;
            foreach (Player p in players)
            {
                if (p.GetBankruptState())
                    count--;

                if (count <= 1)
                    return true;
            }

            return false;
        }
    }
}
