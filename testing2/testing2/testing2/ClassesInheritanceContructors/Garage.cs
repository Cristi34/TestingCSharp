using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.ClassesInheritanceContructors
{
    public class Garage
    {
        private Car[] carArray = new Car[4];
        //public Garage() { }
        // Fill with some Car objects upon startup.
        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 30);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Car c in carArray)
            {
                yield return c;
            }
        }

        // simple array get enumerator
        //public IEnumerator GetEnumerator()
        //{
        //    // Return the array object’s IEnumerator.
        //    return carArray.GetEnumerator();
        //}
        public static void GarageTest()
        {
            Console.WriteLine("***** Fun with IEnumerable / IEnumerator *****\n");
            Garage carLot = new Garage();

            // Hand over each car in the collection?
            foreach (Car c in carLot)
            {

                Console.WriteLine("{0} is going {1} MPH",
                  c.Name, c.CurrentSpeed);
            }
        }
    }   
}
