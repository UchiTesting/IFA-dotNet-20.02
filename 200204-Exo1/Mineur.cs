using System;
using System.Collections.Generic;
using System.Text;

namespace _200204_Exo1
{
    class Mineur: Personne
    {
        private Personne tuteur;

        public Mineur(string nom, string prenom, string dateDeNaissance, Personne tuteur): base(nom, prenom, dateDeNaissance)
        {
            this.tuteur = tuteur;
        }

        public Mineur(Personne p, Personne tuteur) : this(p.getNom(), p.getPrenom(), p.getDateDeNaissance(), tuteur)
        {
            //
        }

        public Personne GetTuteur()
        {
            return tuteur;
        }

        public void SetTuteur(Personne value)
        {
            tuteur = value;
        }
    }
}
