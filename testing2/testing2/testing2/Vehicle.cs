using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing2
{
    public abstract class Vehicle
    {
        public int HorsePower;
        
        protected void DriveTo(string whereToDrive)
        {
            Console.WriteLine("abstract vehicle drives to " + whereToDrive);
        } 
    }
}
