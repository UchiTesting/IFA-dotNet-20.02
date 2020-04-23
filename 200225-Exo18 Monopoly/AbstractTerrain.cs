using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly
{
    public abstract class AbstractTerrain : BoardSquare, IBuyable
    {
        private int Cost; // Cost of the terrain
        private int BaseRent; // Rent to be paid when a player that does not own the terrain step in it.
        private Player Owner;
        private int NumberOfBuildings;

        public int GetCost() { return Cost; }
        public void SetCost(int newCost) { Cost = newCost; }
        public int GetBaseRent() { return BaseRent; }
        public void SetBaseRent(int newBaseRent) { BaseRent = newBaseRent; }
        public Player GetOwner() { return Owner; }
        public void SetOwner(Player p) { Owner = p; }
        public int GetNumberOfBuildings() { return NumberOfBuildings; }
        public void SetNumberOfBuildings(int newNumberOfBuildings) { NumberOfBuildings = newNumberOfBuildings; }
        
        public AbstractTerrain(string name, int cost, int rent) : base(name)
        {
            SetCost(cost);
            SetBaseRent(rent);
            SetNumberOfBuildings(0);
        }

        public void performActions(Player p)
        {
            if (!p.Equals(Owner))
            {
                payRent(p);
            }
        }

        public void payRent(Player p)
        {
            p.TransferFund(Owner, BaseRent);

        }

        private int ComputeRent()
        {
            return BaseRent + (int)(NumberOfBuildings * (0.2 * BaseRent));
        }

        public void AddHouse()
        {
            NumberOfBuildings++;
        }

        public void AddHouse(int number)
        {
            NumberOfBuildings += number;
        }

        public void RemoveHouse()
        {
            NumberOfBuildings--;
        }

        public void RemoveHouse(int number)
        {
            NumberOfBuildings -= number;
        }

        public override string ToString()
        {
            return GetName();
        }

        public void Buy(Player p)
        {
            SetOwner(p);
        }

        public bool HasOwner()
        {
            if (GetOwner() == null)
                return false;

            return true;
        }

        public string BuyableInfo()
        {
            return GetName() + " priced " + GetCost();
        }
    }
}
