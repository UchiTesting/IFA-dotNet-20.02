using _200220_Exo14_Concessionnaires_JSON.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _200220_Exo14_Concessionnaires_JSON
{
    [Serializable]
    class Concessionary
    {
        public List<Car> listOfCars;
        public  string Brand { get; set; }

        public Concessionary(string brand)
        {
            Brand = brand;
            listOfCars = new List<Car>();
        }

        public void AddCar(string brand, string model, int power)
        {
            Car car = new Car(brand, model, power);
            listOfCars.Add(car);
        }

        public void RemoveCar(int index)
        {
            if (listOfCars.Count > 0 && index < listOfCars.Count && index >= 0)
            {
                listOfCars.RemoveAt(index);
            } 
            else
                throw new ListException("Cannot remove the car for the index given is out of bound or inexisent.");
        }

        public string ListCars()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                if (listOfCars.Count > 0)
                    listOfCars.ForEach(x => sb.AppendLine(x.ToString()));
                else
                    Console.WriteLine("No cars.");
            }
            catch (ListException)
            {
                Console.WriteLine("The list of cars is empty.");
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return string.Format("Brand {0} has {1} car(s)", Brand,listOfCars.Count);
        }
    }
}
