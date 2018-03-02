using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestingCSharp
{
	public class RegexTest
	{
		public static void SimpleMatch()
		{
			Regex reg = new Regex("the");
			string str1 = "the quick brown fox jumped over the lazy dog";
			// only one single match (the first)
			Match matchSet;
			int matchPos;
			matchSet = reg.Match(str1);
			if (matchSet.Success)
			{
				matchPos = matchSet.Index;
				Console.WriteLine("found match at position:" + matchPos);
			}

			// multiple matches
			MatchCollection matchSetCollection;
			matchSetCollection = reg.Matches(str1);
			if (matchSetCollection.Count > 0)
				foreach (Match aMatch in matchSetCollection)
					Console.WriteLine("found a match at: " + aMatch.Index);
			Console.Read();
		}

		public static void Quantifiers()
		{
			string[] words = new string[] { "bad", "boy", "baaad", "bear", "bend" };
			foreach (string word in words)
				if (Regex.IsMatch(word, "ba+"))
				{
					// outputs "bad", "baaad"
					Console.WriteLine(word);
				}		
		}

		public static void CharacterClasses()
		{
			string str1 = "THE quick BROWN fox JUMPED over THE lazy DOG";
			MatchCollection matchSet;
			// The letters matched are those that make up the words “quick”, “fox”, “over”, and “lazy”.
			matchSet = Regex.Matches(str1, "[a-z]"); // other options: [A-Za-z] or [0–9]
			foreach (Match aMatch in matchSet)
				Console.WriteLine("Matches at: " + aMatch.Index);
		}


	}
}
