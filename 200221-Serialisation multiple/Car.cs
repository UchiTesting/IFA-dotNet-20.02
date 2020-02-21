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
            name = "SomeFairlyLongString CAR"+id;
        }

        public Car(): this(0)
        { 
            name = "SomeFairlyLongString CAR"+id;
        }
    }
}
