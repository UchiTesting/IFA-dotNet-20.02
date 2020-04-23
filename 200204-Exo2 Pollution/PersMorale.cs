using System;
using System.Collections.Generic;
using System.Text;

namespace _200204_Exo2_Pollution
{
    class PersMorale : Personne, IPolluant
    {
        private string numSiret = null;
        private PersAdmin respLegal = null;
        private int coeffPollution;

        public PersMorale(string nom, string prenom, string dateDeNaissance, string adresse, string numSiret, int coeffPollution, PersAdmin respLegal) : base(nom, prenom, dateDeNaissance, adresse)
        {
            this.numSiret = numSiret;
            this.respLegal = respLegal;
            this.coeffPollution = coeffPollution;
        }

        public double calculerPollution(int nbJours)
        {
            return coeffPollution * nbJours + 5;
        }

        public double payerPollution(double quantitePollution, double tauxPollution)
        {
            double taxe = quantitePollution * tauxPollution;
            Console.WriteLine(respLegal + " pays " + taxe);
            return taxe;
        }
    }
}
