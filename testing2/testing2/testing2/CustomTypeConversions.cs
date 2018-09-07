using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp
{
    public class CustomTypeConversions
    {
        /* You’ll notice in the Square and Rectangle constructors, I am explicitly chaining to the default constructor. The reason is that if 
         * you have a structure, which makes use of automatic property syntax (as you do here), the default constructor must be explicitly called 
         * (from all custom constructors) to initialize the private backing fields (for example, if the structures had any additional fields/properties,
         * this default constructor would initialize these fields to default values). Yes, this is a quirky rule of C#, but after all, this is an 
         * advanced topics chapter
         */

        public struct Rectangle
        {
            // struct with automatic property syntax -> chaining to the default constructor needed!
            public int Width { get; set; }
            public int Height { get; set; }

            public Rectangle(int w, int h) : this()
            {
                Width = w; Height = h;
            }

            public void Draw()
            {
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }

            public override string ToString()
            {
                return string.Format("[Width = {0}; Height = {1}]",
                  Width, Height);
            }

            public static implicit operator Rectangle(Square s)
            {
                Rectangle r = new Rectangle();
                r.Height = s.Length;

                // Assume the length of the new Rectangle with
                // (Length x 2).
                r.Width = s.Length * 2;
                return r;
            }
        }

        public struct Square
        {
            // struct with automatic property syntax -> chaining to the default constructor needed!
            public int Length { get; set; }
            public Square(int l) : this()
            {
                Length = l;
            }

            public void Draw()
            {
                for (int i = 0; i < Length; i++)
                {
                    for (int j = 0; j < Length; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }

            public override string ToString()
            { return string.Format("[Length = {0}]", Length); }

            // Rectangles can be explicitly converted
            // into Squares.
            public static explicit operator Square(Rectangle r)
            {
                Square s = new Square();
                s.Length = r.Height;
                return s;
            }

            public static explicit operator Square(int sideLength)
            {
                Square newSq = new Square();
                newSq.Length = sideLength;
                return newSq;
            }

            public static explicit operator int(Square s)
            { return s.Length; }
        }

        /* Notice that this iteration of the Square type defines an explicit conversion operator. Like the process of overloading an operator, 
         * conversion routines make use of the C# operator keyword, in conjunction with the explicit or implicit keyword, and must be defined as 
         * static. The incoming parameter is the entity you are converting from, while the operator type is the entity you are converting to.
         * In this case, the assumption is that a square (being a geometric pattern in which all sides are of equal length) can be obtained from 
         * the height of a rectangle. Thus, you are free to convert a Rectangle into a Square, as follows:
         */
        public static void TestExplicitConversion()
        {
            Console.WriteLine("***** Fun with Conversions *****\n");
            // Make a Rectangle.
            Rectangle r = new Rectangle(15, 4);
            Console.WriteLine(r.ToString());
            r.Draw();

            Console.WriteLine();

            // Convert r into a Square,
            // based on the height of the Rectangle.
            Square s = (Square)r;
            Console.WriteLine(s.ToString());
            s.Draw();
            Console.WriteLine();

            // Converting an int to a Square.
            Square sq2 = (Square)90;
            Console.WriteLine("sq2 = {0}", sq2);

            // Converting a Square to an int.
            int side = (int)sq2;
            Console.WriteLine("Side length of sq2 = {0}", side);
            Console.ReadLine();
        }

        public static void TestImplicitConversion()
        {
            // Implicit cast OK!
            Square s3 = new Square();
            s3.Length = 7;

            Rectangle rect2 = s3;
            Console.WriteLine("rect2 = {0}", rect2);

            // Explicit cast syntax still OK!
            Square s4 = new Square();
            s4.Length = 3;
            Rectangle rect3 = (Rectangle)s4;

            Console.WriteLine("rect3 = {0}", rect3);
            Console.ReadLine();
        }
    }
}
