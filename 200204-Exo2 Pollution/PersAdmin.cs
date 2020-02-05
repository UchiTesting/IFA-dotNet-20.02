using System;
using System.Collections.Generic;
using System.Text;

namespace _200204_Exo2_Pollution
{
    class PersAdmin : Personne
    {
        private string numSecu = null;

        public PersAdmin(string nom, string prenom, string dateDeNaissance, string adresse, string numSecu): base(nom, prenom,dateDeNaissance,adresse)
        {
            this.numSecu = numSecu;
        }

        public string getLieuDeNaissance()
        {
            return this.adresse;
        }

        public void setLieuDeNaissance(string value)
        {
            this.adresse = value;
        }
    }
}
