using System;
using System.Collections.Generic;
using System.Text;

namespace _200225_Exo18_Monopoly
{
    public abstract class NamedElement
    {
        public string name;

        public NamedElement(string newName)
        {
            name = newName;
        }
    }
}
