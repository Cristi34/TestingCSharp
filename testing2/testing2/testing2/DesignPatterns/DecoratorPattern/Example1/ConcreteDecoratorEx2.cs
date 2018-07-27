using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.DesignPatterns.DecoratorPattern
{
    class ConcreteDecoratorEx2 : AbstractDecorator
    {
        public override void MakeHouse()
        {
            Console.WriteLine("");
            base.MakeHouse();
            Console.WriteLine("***Using another decorator***");
            //Decorating now.
            PaintTheHouse();
            //You can add additional stuffs as per your need
        }
        private void PaintTheHouse()
        {
            Console.WriteLine("Now I am painting the house.");
        }
    }
}
