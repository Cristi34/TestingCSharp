using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.Helpers
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age;

        public Person(string name, int age)
        {
            FirstName = name;
            Age = age;
        }
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        public Person() { }

        public void Display()
        {
            Console.WriteLine("Name: {0}, Age: {1}", FirstName, Age);
        }
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
