using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp
{
    public class Toyota : Car
    {
        public override void DriveTo(string whereToDrive)
        {
            //base.DriveTo(whereToDrive);
            Console.WriteLine("Toyota drives patiently to " + whereToDrive);
        }
    }
}
