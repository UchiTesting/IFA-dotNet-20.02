using System;
using System.Collections.Generic;
using System.Text;

namespace _200204_Exo2_Pollution
{
    class Voiture : IPolluant
    {
        private string marque = null;
        private PersAdmin proprio = null;
        private string couleur = null;
        private int puissance;

        public Voiture(string marque, string couleur, int puissance, PersAdmin proprio)
        {
            this.marque = marque;
            this.proprio = proprio;
            this.couleur = couleur;
            this.puissance = puissance;
        }

        public double calculerPollution(int nbJours)
        {
            return puissance * nbJours * 0.3;
        }

        public double payerPollution(double quantitePollution, double tauxPollution)
        {
            double taxe = quantitePollution * tauxPollution;
            Console.WriteLine(proprio + " payes " + taxe);
            return taxe;
        }
    }
}
