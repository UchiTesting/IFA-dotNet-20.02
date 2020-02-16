using System;
using System.Collections.Generic;
using System.Text;

namespace _200204_Exo1
{
    class Femme: Personne
    {
        private string nomJF;

        public Femme(string nom, string prenom, string dateDeNaissance, string nomDeJeuneFille) : base(nom, prenom, dateDeNaissance)
        {
            nomJF = nomDeJeuneFille;
        }

        public Femme(Personne p, string nomDeJeuneFille): this(p.getNom(), p.getPrenom(), p.getDateDeNaissance(), nomDeJeuneFille)
        {

        }

        public string NomJF { get => nomJF; set => nomJF = value; }

        override public string ToString()
        {
            return "Frau: Nom: " + nom + ", Prenom: " + prenom + ", Date de naissance: " + dateDeNaissance;
        }
    }
}
