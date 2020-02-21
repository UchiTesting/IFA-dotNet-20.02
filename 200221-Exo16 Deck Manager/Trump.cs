using System;
using System.Collections.Generic;
using System.Text;

namespace _200221_Exo16_Deck_Manager
{
    [Serializable]
    public abstract class Trump
    {
        protected string name;
        protected string description;

        public string GetDescription()
        {
            return description;
        }

        public string GetName()
        {
            return name;
        }

        public void SetDescription(string newDescription)
        {
            description = newDescription;
        }

        public void SetName(string newName)
        {
            name = newName;
        }

        public override string ToString()
        {

            return "Name: "+name+" Description: "+description;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || (!this.GetType().Equals(obj.GetType()))){
                return false;
            } else
            {
                Trump t = (Trump)obj;
                return (name == t.name) && (description == t.description);
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, description);
        }
    }
}
