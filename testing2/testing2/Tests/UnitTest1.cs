using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingCSharp;

namespace Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			CollectionsTest.DictionaryTest();
		}
	}
}
