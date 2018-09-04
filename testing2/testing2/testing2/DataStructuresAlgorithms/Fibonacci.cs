using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.DataStructuresAlgorithms
{
    public class Fibonacci
    {
        public static void GenerateFibonacci(int n)
        {
            int x = 1, y = 1, aux;
            Console.Write(x + " " + y + " ");

            for (int i = 3; i < n; i++)
            {
                aux = y;
                y = x + y;
                x = aux;

                Console.Write(y + " ");
            }
        }
    }
}
