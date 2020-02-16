using System;
using System.Collections.Generic;
using System.Text;

namespace _200204_Exo1
{
    class Personne
    {
        protected string nom;
        protected string prenom;
        protected string dateDeNaissance;

        public Personne(string nom, string prenom, string dateDeNaissance="01-01-1970")
        {
            this.nom = nom;
            this.prenom = prenom;
            this.dateDeNaissance = dateDeNaissance;
        }

        public string getNom()
        {
            return nom;
        }

        public string getPrenom()
        {
            return prenom;
        }

        public string getDateDeNaissance()
        {
            return dateDeNaissance;
        }

        public void setNom(string value)
        {
            nom = value;
        }

        public void setPrenom(string value)
        {
            prenom = value;
        }

        public void setDateDeNaissance(string value)
        {
            dateDeNaissance = value;
        }

        override public string ToString()
        {
            return "Nom: "+nom+", Prenom: "+prenom+", Date de naissance: " + dateDeNaissance;
        }
    }

    
}
