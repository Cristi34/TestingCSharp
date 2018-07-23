using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestingCSharp.Program;

namespace TestingCSharp
{
    public class IntCollection : IEnumerable
    {
        private ArrayList arInts = new ArrayList();

        // Get an int (performs unboxing!).
        public int GetInt(int pos)
        { return (int)arInts[pos]; }

        // Insert an int (performs boxing)!
        public void AddInt(int i)
        { arInts.Add(i); }

        public void ClearInts()
        { arInts.Clear(); }

        public int Count
        { get { return arInts.Count; } }

        IEnumerator IEnumerable.GetEnumerator()
        { return arInts.GetEnumerator(); }
    }

    class SortPeopleByAge : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            if (firstPerson.Age > secondPerson.Age)
                return 1;
            if (firstPerson.Age < secondPerson.Age)
                return -1;
            else
                return 0;
        }
    }

    public class CollectionsTest
    {
        public enum NotifyCollectionChangedAction
        {
            Add = 0,
            Remove = 1,
            Replace = 2,
            Move = 3,
            Reset = 4,
        }

        public static void ObservableCollectionTest()
        {
            // Make a collection to observe and add a few Person objects.
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person{ FirstName = "Peter", LastName = "Murphy", Age = 52 },
                 new Person{ FirstName = "Kevin", LastName = "Key", Age = 48 },
            };

            // Wire up the CollectionChanged event.
            people.CollectionChanged += people_CollectionChanged;
        }

        static void people_CollectionChanged(object sender,
          System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // What was the action that caused the event?
            Console.WriteLine("Action for this event: {0}", e.Action);

            // They removed something.
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the OLD items:");
                foreach (Person p in e.OldItems)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine();
            }

            // They added something.
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                // Now show the NEW items that were inserted.
                Console.WriteLine("Here are the NEW items:");
                foreach (Person p in e.NewItems)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }

        public static void TestSortedSet()
        {
            // Make some people with different ages.
            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge())
              {
                new Person {FirstName= "Homer", LastName="Simpson", Age=47},
                new Person {FirstName= "Marge", LastName="Simpson", Age=45},
                new Person {FirstName= "Lisa",  LastName="Simpson", Age=9},
                new Person {FirstName= "Bart",  LastName="Simpson", Age=8}
              };

            // Note the items are sorted by age!
            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            // Add a few new people, with various ages.
            setOfPeople.Add(new Person { FirstName = "Saku", LastName = "Jones", Age = 1 });
            setOfPeople.Add(new Person { FirstName = "Mikko", LastName = "Jones", Age = 32 });

            // Still sorted by age!
            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
        }

        public static void TestYield()
        {
            foreach (var i in Integers())
            {
                Console.WriteLine(i);
            }
        }

        public static IEnumerable Integers()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 123, 456, 1234 };
            yield return list;
        }

        /// <summary>
        /// an Array's length is found using Length property, it doesn't have Count property
        /// </summary>
        public static void ArrayTest()
        {
            int[,] intMyArr = { { 7, 1, 3 }, { 2, 9, 6 } };
            Console.WriteLine(intMyArr.GetUpperBound(1));
            Console.WriteLine(intMyArr.Length);
            Console.WriteLine(intMyArr.GetUpperBound(0));
        }

        /// <summary>
        /// an ArrayList contains only type Object so casting is needed
        /// an ArrayList has Count property same as Lists
        /// </summary>		
        public static void ArrayListTest()
        {
            ArrayList x = new ArrayList() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            x.TrimToSize();
            x.Add(18.5f);
            var length = x.Count;
            //PrintLine(x[0].GetType());
            //PrintLine(x[17]);
            //PrintLine(x[17].GetType());
        }

        public static void EnumerableTest()
        {
            IEnumerable<int> result = from value in Enumerable.Range(0, 20)
                                      select value;

            // Loop.
            foreach (int value in result)
            {
                Console.WriteLine(value);
            }

            // We can use extension methods on IEnumerable<int>
            double average = result.Average();

        }
    }
}
