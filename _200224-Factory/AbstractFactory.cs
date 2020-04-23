using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public abstract class AbstractFactory
    {
        public AbstractFactory()
        {

        }

        public abstract Card Create(); // Devrait renvoyer une instance de l'objet a créer donc pas void
    }

    public class Card
    {
        public string Name { get; set; }
        public string Description { get; set; }
        Card(string name, string desc)
        {
            Name = name;
            Description = desc;
        }
    }
}
