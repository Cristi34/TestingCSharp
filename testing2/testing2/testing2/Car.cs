using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing2
{
    public class Car : Vehicle
    {
        new int HorsePower;
        string Name;

        public Car(int horsePower, string name)
        {
            HorsePower = horsePower;
            Name = name;
        }
        public Car()
        {

        }
        public void ChangeName(string name)
        {
            Name = name;
        }
        new public virtual void DriveTo(string whereToDrive)
        {
            Console.WriteLine("Car drives to " + whereToDrive);
        } 
               
    }
}

