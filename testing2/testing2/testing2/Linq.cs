using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingCSharp.Helpers;
// interesting using static
using static TestingCSharp.ClassesInheritanceContructors.ClassesTest;

namespace TestingCSharp
{
	public class Linq
	{
        public static void QueryOverStrings()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            // Build a query expression to find the items in the array
            // that have an embedded space.
            IEnumerable<string> subset = from g in currentVideoGames
                                         where g.Contains(" ")
                                         orderby g
                                         select g;

            // Print out the results.
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);


        }

        /* The Role of Deferred Execution
         * Another important point regarding LINQ query expressions is that they are not actually evaluated until you iterate over the sequence. 
         * Formally speaking, this is termed deferred execution. The benefit of this approach is that you are able to apply the same LINQ query 
         * multiple times to the same container and rest assured you are obtaining the latest and greatest results
         */
        public static void DefferedExecution()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            // Get numbers less than ten.
            var subset = from i in numbers where i < 10 select i;

            // LINQ statement evaluated here!
            foreach (var i in subset)
                Console.WriteLine("{0} < 10", i);
            Console.WriteLine();
            // Change some data in the array.
            numbers[0] = 4;

            // Evaluated again!
            foreach (var j in subset)
                Console.WriteLine("{0} < 10", j);

            Console.WriteLine();
            Utils.ReflectOverType(subset);
        }
        // versus Immediate Execution
        public static void ImmediateExecution()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            // Get data RIGHT NOW as int[].
            int[] subsetAsIntArray =
              (from i in numbers where i < 10 select i).ToArray<int>();

            // Get data RIGHT NOW as List<int>.
            List<int> subsetAsListOfInts =
              (from i in numbers where i < 10 select i).ToList<int>();
        }

        // LINQ over nongeneric collections
        static void LINQOverArrayList()
        {
            Console.WriteLine("***** LINQ over ArrayList *****");

            // Here is a nongeneric collection of cars.
            ArrayList myCars = new ArrayList() {
                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
             };

            // Transform ArrayList into an IEnumerable<T>-compatible type.
            var myCarsEnum = myCars.OfType<Car>();

            // Create a query expression targeting the compatible type.
            var fastCars = from c in myCarsEnum where c.Speed > 55 select c;

            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
        }

        public static void testGroupBy()
		{
			// Create a list of pets.
			List<Pet> pets =
				new List<Pet>{
					   new Pet { Name="Barley", Age=8, TestList = new List<int> {1,2,3 } },
					   new Pet { Name="Boots", Age=4, TestList = new List<int> {6,8,34 }  },
					   new Pet { Name="Whiskers", Age=1, TestList = new List<int> {556,12,345 }  },
					   new Pet { Name="Daisy", Age=4, TestList = new List<int> {13,26,36 } }
				};

			// Group the pets using Age as the key value 
			// and selecting only the pet's Name for each value.
			var query =
				pets.GroupBy(pet => pet.Age);

			// Iterate over each IGrouping in the collection.
			foreach (var petGroup in query)
			{
				// Print the key value of the IGrouping.
				Console.WriteLine(petGroup.Key);
				// Iterate over each value in the 
				// IGrouping and print the value.
				foreach (var listItem in petGroup)
				{
					Console.Write("listItem " + listItem.Name + " ");
					foreach (var testListItem in listItem.TestList)
					{
						Console.Write(testListItem + " ");
					}
					Console.WriteLine("");
				}
			}
		}
	}
}
