using System;
using System.Collections.Generic;
using System.Text;

namespace _200204_Exo2_Pollution
{
    abstract class Personne
    {
        protected string nom = null;
        protected string prenom = null;
        protected string dateDeNaissance = null;
        protected string adresse = null;

        public Personne(string nom, string prenom, string dateDeNaissance, string adresse)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.dateDeNaissance = dateDeNaissance;
            this.adresse = adresse;
        }

        public Personne() : this("Fleck", "Arthur", "01-01-1970", "Gotham City")
        {
            //
        }

        override public string ToString()
        {
            return "Nom: "+nom+", Prenom: "+prenom+", DDN: "+dateDeNaissance+", ADR: " + adresse;
        }
    }
}
