using System;
using System.Collections.Generic;
using System.Text;

namespace _200220_Exo14_Concessionnaires_JSON
{
    class Concessionary
    {
        private List<Car> listOfCars;
        private string Name { get; set; }

        public Concessionary()
        {
            listOfCars = new List<Car>();
        }

        private void AddCar(string brand, string model, int power)
        {
            Car car = new Car(brand, model, power);
            listOfCars.Add(car);
        }

        private void RemoveCar(int index)
        {
            if (listOfCars.Count > 0 && index < listOfCars.Count && index >= 0)
            {
                listOfCars.RemoveAt(index);
            }
        }

        private string ListCars()
        {
            StringBuilder sb = new StringBuilder();
            if (listOfCars.Count > 0)
                listOfCars.ForEach(x => Console.WriteLine(x.ToString()));
            else
                Console.WriteLine("The list of cars is empty.");

            return 
        }
    }
}
