using System;
using System.Collections.Generic;
using System.Text;

namespace _200204_Exo2_Pollution
{
    interface IPolluant
    {
        abstract double calculerPollution(int nbJours);
        abstract double payerPollution(double quantitePollution, double tauxPollution);
    }
}
