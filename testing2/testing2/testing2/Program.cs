using Oracle.DataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Numerics;
using TestingCSharp.DataStructuresAlgorithms;
using TestingCSharp.DesignPatterns.PaymentFactory;
using TestingCSharp.ClassesInheritanceContructors;
using TestingCSharp.Hackerrank;
using static TestingCSharp.PrimitiveTypesTest;
using TestingCSharp.DesignPatterns.DecoratorPattern;
using TestingCSharp.Threading;

namespace TestingCSharp
{
	class Program
	{
		public static int TestValue = 6;
		static int[] TestArray = new int[] { 12, 34, 67, 23, 89, 28, 76, 45, 90, 21, 32, 43, 54, 65, 76, 87, 98, 123, 435, 16, 19, 37, 35, 39, 59, 48, 82, 83, 85 };
		static void Main(string[] args)
		{
			Timing tObj = new Timing();
			tObj.StartTime();

            ParallelClass.Test();

            tObj.StopTime();
			Console.WriteLine("\ntime (.NET): " + tObj.ElapsedMs + " milliseconds");
			Console.WriteLine("DONE Main");
			Console.ReadKey();
		}
        
		static void PrintLine<T>(T line)
		{
			Console.WriteLine(line);
		}

		public static void OracleTest()
		{
			OracleConnection con;
			try
			{
				con = new OracleConnection
				{
					ConnectionString = "User Id=ANONYMOUS;Password=scar34;Data Source=localhost:1521/orcl2"
				};
				con.Open();
				Console.WriteLine("Connected to Oracle" + con.ServerVersion);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}            
    }
}
