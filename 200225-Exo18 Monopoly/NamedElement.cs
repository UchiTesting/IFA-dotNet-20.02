using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly
{
    public abstract class NamedElement
    {
        public string name;

        public string GetName() { return name; }
        public void SetName(string newName) { name = newName; }

        public NamedElement(string newName)
        {
            SetName(newName);
        }
    }
}
