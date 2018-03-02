using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// interesting using static
using static TestingCSharp.ClassesInheritanceContructors.ClassesTest;

namespace TestingCSharp
{
	public class LinqTest
	{
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
