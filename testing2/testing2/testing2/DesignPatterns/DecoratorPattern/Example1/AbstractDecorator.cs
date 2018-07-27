using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.DesignPatterns.DecoratorPattern
{
    abstract class AbstractDecorator : Component
    {
        protected Component com;
        public void SetTheComponent(Component c)
        {
            com = c;
        }
        public override void MakeHouse()
        {
            if (com != null)
            {
                com.MakeHouse();//Delegating the task
            }
        }
    }
}
