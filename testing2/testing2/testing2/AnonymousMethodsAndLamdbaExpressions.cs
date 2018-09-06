using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestingCSharp.DelegatesEvents;

namespace TestingCSharp
{
    public class AnonymousMethodsAndLamdbaExpressions
    {
        #region Events and Local Variables
        /* It is possible to associate an event directly to a block of code statements at the time of event registration. Formally, such code
         * is termed an anonymous method
        */
        public static void TestEventsWithAnonymousMethods()
        {
            Console.WriteLine("***** Anonymous Methods *****\n");
            CarEventArgsTest c1 = new CarEventArgsTest("SlugBug", 100, 10);

            // Register event handlers as anonymous methods.
            c1.AboutToBlow += delegate
            {
                Console.WriteLine("Eek! Going too fast!");
            };

            c1.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine("Message from Car: {0}", e.msg);
            };

            c1.Exploded += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine("Fatal Message from Car: {0}", e.msg);
            };

            // This will eventually trigger the events.
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            Console.ReadLine();
        }

        public static void TestLocalVariables()
        {
            Console.WriteLine("***** Anonymous Methods *****\n");
            int aboutToBlowCounter = 0;

            // Make a car as usual.
            CarEventArgsTest c1 = new CarEventArgsTest("SlugBug", 100, 10);

            // Register event handlers as anonymous methods.
            c1.AboutToBlow += delegate
            {
                aboutToBlowCounter++;
                Console.WriteLine("Eek! Going too fast!");
            };

            c1.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                aboutToBlowCounter++;
                Console.WriteLine("Critical Message from Car: {0}", e.msg);
            };

            // This will eventually trigger the events.
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            Console.WriteLine("AboutToBlow event was fired {0} times.",
              aboutToBlowCounter);
            Console.ReadLine();
        }
        #endregion

        #region Traditional Delegate Syntax
        static void TraditionalDelegateSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Call FindAll() using traditional delegate syntax.
            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);

            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        // Target for the Predicate<> delegate.
        static bool IsEvenNumber(int i)
        {
            // Is it an even number?
            return (i % 2) == 0;
        }

        static void AnonymousMethodSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Now, use an anonymous method.
            List<int> evenNumbers = list.FindAll(
              delegate (int i)
              {
                  return (i % 2) == 0;
              }
            );

            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }
        #endregion

        #region Lambda Expressions
        /*   i => (i % 2) == 0
         *   Before I break this syntax down, first understand that lambda expressions can be used anywhere you would have used an anonymous method 
         *   or a strongly typed delegate (typically with far fewer keystrokes). Under the hood, the C# compiler translates the expression into a
         *   standard anonymous method making use of the Predicate<T> delegate type
         */

        static void LambdaExpressionSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Now process each argument within a group of
            // code statements.
            List<int> evenNumbers = list.FindAll((i) =>
            {
                Console.WriteLine("value of i is currently: {0}", i);
                bool isEven = ((i % 2) == 0);
                return isEven;
            });

            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        public class SimpleMath
        {
            public delegate void MathMessage(string msg, int result);
            private MathMessage mmDelegate;

            public void SetMathHandler(MathMessage target)
            { mmDelegate = target; }

            public void Add(int x, int y)
            {
                mmDelegate?.Invoke("Adding has completed!", x + y);
            }
        }

        public static void RetrofitCarEventsWithLambdas()
        {
            Console.WriteLine("***** More Fun with Lambdas *****\n");

            // Make a car as usual.
            CarEventArgsTest c1 = new CarEventArgsTest("SlugBug", 100, 10);

            // Hook into events with lambdas!
            c1.AboutToBlow += (sender, e) => { Console.WriteLine(e.msg); };
            c1.Exploded += (sender, e) => { Console.WriteLine(e.msg); };

            // Speed up (this will generate the events).
            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            Console.ReadLine();
        }
        #endregion
    }
}
