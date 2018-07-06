using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.ClassesInheritanceContructors
{
    public class PointClone : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PointClone(int xPos, int yPos) { X = xPos; Y = yPos; }
        public PointClone() { }

        // Override Object.ToString().
        public override string ToString()
        {
            return string.Format("X = {0}; Y = {1}", X, Y);
        }

        // Return a copy of the current object.
        //public object Clone()
        //{
        //    return new PointClone(this.X, this.Y);
        //}

        // Because the Point type does not contain any internal reference type variables:
        public object Clone()
        {            
            // Copy each field of the Point member by member.
            return this.MemberwiseClone();
        }

        public static void PointCloneTest()
        {
            Console.WriteLine("***** Fun with Object Cloning *****\n");
            // Notice Clone() returns a plain object type.
            // You must perform an explicit cast to obtain the derived type.
            PointClone p3 = new PointClone(100, 100);
            PointClone p4 = (PointClone)p3.Clone();

            // Change p4.X (which will not change p3.X).
            p4.X = 0;

            // Print each object.
            Console.WriteLine(p3);
            Console.WriteLine(p4);
        }
    }
    
}
