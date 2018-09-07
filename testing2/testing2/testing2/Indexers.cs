using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingCSharp.Helpers;

namespace TestingCSharp
{
    public class Indexers
    {
        // Add the indexer to the existing class definition.
        public class PersonCollection : IEnumerable
        {
            //private ArrayList arPeople = new ArrayList();

            // Custom indexer for this class.
            //public Person this[int index]
            //{
            //    get { return (Person)arPeople[index]; }
            //    set { arPeople.Insert(index, value); }
            //}

            private Dictionary<string, Person> listPeople = new Dictionary<string, Person>();

            // This indexer returns a person based on a string index.
            public Person this[string name]
            {
                get { return (Person)listPeople[name]; }
                set { listPeople[name] = value; }
            }
            public void ClearPeople()
            { listPeople.Clear(); }

            public int Count
            { get { return listPeople.Count; } }

            IEnumerator IEnumerable.GetEnumerator()
            { return listPeople.GetEnumerator(); }
        }
                
        public static void TestStringIndexer()
        {
            Console.WriteLine("***** Fun with Indexers *****\n");

            PersonCollection myPeople = new PersonCollection();

            myPeople["Homer"] = new Person("Homer", "Simpson", 40);
            myPeople["Marge"] = new Person("Marge", "Simpson", 38);

            // Get "Homer" and print data.
            Person homer = myPeople["Homer"];
            Console.WriteLine(homer.ToString());

            Console.ReadLine();
        }

        // indexers can also be defined within Interfaces
        public interface IStringContainer
        {
            string this[int index] { get; set; }
        }
        public class SomeClass : IStringContainer
        {
            private List<string> myStrings = new List<string>();

            public string this[int index]
            {
                get { return myStrings[index]; }
                set { myStrings.Insert(index, value); }
            }
        }


    }
}
