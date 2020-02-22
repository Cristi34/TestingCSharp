using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp
{
    public class Car : Vehicle
    {
        new int HorsePower;
        public string Name { get; set; }
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public int Speed { get; set; }
        
        public Car(int horsePower, string name)
        {
            HorsePower = horsePower;
            Name = name;
        }
        public Car(string name, int topSpeed)
        {
            this.Name = name;
            this.CurrentSpeed = topSpeed;
        }
        public Car() { }
        
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

