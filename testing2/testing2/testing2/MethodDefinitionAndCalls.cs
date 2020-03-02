using System;
using TestingCSharp.Helpers;

namespace TestingCSharp
{
	public class MethodDefinitionAndCalls
    {
        public static void TestPassingRefTypesByRef()
        {
            // Passing ref-types by ref.
            Console.WriteLine("***** Passing Person object by reference *****");

            Person mel = new Person("Mel", 23);
            Console.WriteLine("Before by ref call, Person is:");
            mel.Display();

            SendAPersonByReference(ref mel);
            Console.WriteLine("After by ref call, Person is:");
            mel.Display();
        }

        public static void TestPassingRefTypesByValue()
        {
            // Passing ref-types by value.
            Console.WriteLine("***** Passing Person object by value *****");
            Person fred = new Person("Fred", 12);
            Console.WriteLine("\nBefore by value call, Person is:");
            fred.Display();

            SendAPersonByValue(fred);
            Console.WriteLine("\nAfter by value call, Person is:");
            fred.Display();
        }

        static void SendAPersonByReference(ref Person p)
        {
            // Change some data of "p".
            p.Age = 555;

            // "p" is now pointing to a new object on the heap!
            p = new Person("Nikki", 999);
        }

        static void SendAPersonByValue(Person p)
        {
            // Change the age of "p"?
            p.Age = 69;
            p.FirstName = "changed";

            // Will the caller see this reassignment?
            p = new Person("Nikki", 999);
        }

        static void WhyDoesThisWorkJesus()
        {
            p();
            void p()
            {
                Console.WriteLine("hi");
            }
        }
    }
}
