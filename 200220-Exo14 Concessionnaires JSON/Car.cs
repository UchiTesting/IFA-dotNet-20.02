using System;
using System.Collections.Generic;
using System.Text;

namespace _200220_Exo14_Concessionnaires_JSON
{
    [Serializable]
    class Car
    {
        private string Brand { get; set; }
        private string Model { get; set; }
        private int Power { get; set; }

        public Car(): this("defaultBrand","defaultModel",0){}

        public Car(string brand, string model, int power)
        {
            Brand = brand;
            Model = model;
            Power = power;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} cc", Brand, Model, Power);
        }
    }
}
