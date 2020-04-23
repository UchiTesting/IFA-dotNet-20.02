using System;
using System.Collections.Generic;
using System.Text;
using _200225_Exo18_Monopoly.Exceptions;

namespace _200225_Exo18_Monopoly
{
    public class Player : NamedElement
    {
        private int number;
        private int Balance;
        private PIECES Piece;
        private int Position;
        private bool CanPlay; // Player is allowed to play
        private bool IsInPrison;
        private bool IsBankrupt;


        public Player() : this("") { }

        public Player(string name) : base(name)
        {
            Piece = PIECES.NONE;
            Position = 0;
            Balance = 0;
            CanPlay = true;
            IsInPrison = false;
            IsBankrupt = false;
        }


        /**
         * 
         * Methods related to Balance property
         * 
         */

        public int GetNumber() { return number; }
        public void SetNumber(int newValue) { number = newValue; }
        public int GetBalance() { return Balance; }

        /// <summary>
        /// Changes the balance of the player.
        /// </summary>
        /// <param name="amount">Positive values to give credit. Negative values to make the player pay.</param>
        private void ChangeBalance(int amount)
        {
            if (!(Balance + amount < 0)) Balance += amount; else { Balance = 0; IsBankrupt = true; }
        }

        /// <summary>
        /// Transfer funds to another player.
        /// </summary>
        /// <param name="p">Player to whom the money is transfered</param>
        /// <param name="amount"></param>
        public void TransferFund(Player p, int amount)
        {
            if (amount > 0)
            {
                this.ChangeBalance(-amount);
                p.ChangeBalance(amount);
            }
            else
            {
                throw new FundTransferException("You cannot transfer negative amounts of money to another player.");
            }
        }

        /**
         * 
         * Methods related to CanPlay
         * 
         */

        public bool GetCanPLay() { return CanPlay; }
        public void SetCanPlay(bool newState) { CanPlay = newState; }
        /**
         * 
         * Methods related to bankrupt state
         * 
         */

        public bool GetBankruptState() { return IsBankrupt; }
        public void SetBankruptState(bool newState) { IsBankrupt = newState; }

        /**
         * 
         * Methods related to prison state
         * 
         */

        public bool GetPrisonState() { return IsInPrison; }
        public void SetPrisonState(bool newState) { IsInPrison = newState; }

        /**
         * 
         * Methods related to the piece chosen by a player
         * 
         */

        public PIECES GetPiece() { return Piece; }
        public void SetPiece(PIECES p) { Piece = p; }

        /**
         * 
         * Methods related to the player position
         * 
         */

        public int GetPosition() { return Position; }
        public void Move(int nbSquares) // Replaces the common SetPosition
        {
            if (nbSquares + Position > Engine.squares.Count)
            {
                Position = (Position + nbSquares) % Engine.squares.Count;
                Balance += 20000;
            }
            else
                Position += nbSquares;
        }
    }
}
