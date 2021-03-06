﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _200220_Exo13_Serialisation_Binaire_de_voitures
{
    [Serializable]
    class Car
    {
        private string Brand { get; set; }
        private string Model { get; set; }
        private int Power { get; set; }

        public Car()
        {

        }

        public Car(string brand, string model, int power)
        {
            Brand = brand;
            Model = model;
            Power = power;
        }

        public string ToString()
        {
            return string.Format("{0} {1} {2} cc", Brand, Model, Power);
        }
    }
}
