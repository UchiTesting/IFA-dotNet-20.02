using System;
using System.Collections.Generic;
using System.Text;

namespace _200221_Exo15_Serialisation_multiple
{
    [Serializable]
    public class Car
    {
        public int id;
        public string name;
        public Car(int id)
        {
            this.id = id;
            name = "CAR"+id;
        }

        public Car(): this(0)
        { 
            name = "CAR"+id;
        }

        public override string ToString()
        {
            return "ID: "+id+" name: "+name;
        }


    }
}
