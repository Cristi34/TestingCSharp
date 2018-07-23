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

		static void TimeConversion()
		{
			string time = Console.ReadLine();
			//while (Console.ReadLine() != "null")
			//{
			string meridian = time.Substring(time.Length - 2, 2);
			string hours = time.Substring(0, 2);
			string restOfTime = "", returnedTime = "";
			var hoursInt = int.Parse(hours);
			//string hoursString = "";
			if (meridian == "PM")
			{
				hoursInt = hoursInt + 12;
				restOfTime = time.Substring(2, time.Length - 4);
				if (hoursInt == 24)
				{
					hoursInt = 12;
					//hoursString = hoursInt + "0";
				}
				else
				{
					//hoursString = hoursInt.ToString();
				}
				returnedTime = hoursInt + restOfTime;

				Console.Write(returnedTime);
			}
			else
			{

				Console.Write(time.Substring(0, time.Length - 2));
			}

			Console.ReadLine();
		}

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
            public Person() { }

            public void Display()
            {
                Console.WriteLine("Name: {0}, Age: {1}", FirstName, Age);
            }
        }       
    }
}
