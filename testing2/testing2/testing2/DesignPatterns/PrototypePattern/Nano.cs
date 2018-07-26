﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.DesignPatterns.PrototypePattern
{
    public class Nano : BasicCar
    {
        public Nano(string m)
        {
            ModelName = m;
        }

        public override BasicCar Clone()
        {
            return (Nano)this.MemberwiseClone();//shallow Clone
        }
    }
}
