using Oracle.DataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Numerics;
using TestingCSharp.DataStructuresAlgorithms;

namespace TestingCSharp
{
	class Program
	{
		public static int TestValue = 6;
		static int[] testArray = new int[] { 12, 34, 67, 23, 89, 28, 76, 45, 90, 21, 32, 43, 54, 65, 76, 87, 98, 123, 435, 16, 19, 37, 35, 39, 59, 48, 82, 83, 85 };
		static void Main(string[] args)
		{
			Timing tObj = new Timing();
			tObj.StartTime();

			ExceptionsTest.SwallowException();

			tObj.StopTime();
			Console.WriteLine("\ntime (.NET): " + tObj.ElapsedMs + " milliseconds");
			Console.WriteLine("DONE Main");
			Console.ReadKey();
		}

		static void PrintLine<T>(T line)
		{
			Console.WriteLine(line);
		}
		
		#region Threads
		public void threadPlay()
		{
			ThreadStart childref1 = new ThreadStart(Thread1.CallToThread);
			Thread childThread1 = new Thread(childref1);
			childThread1.Start();

			ThreadStart childref2 = new ThreadStart(Thread2.CallToThread);
			Thread childThread2 = new Thread(childref2);
			childThread2.Start();

			Console.ReadKey();
		}
		#endregion

		#region Function definition and calls
		static void WhyDoesThisWorkJesus()
		{
			p();
			void p()
			{
				Console.WriteLine("hi");
			}
		}
		#endregion

		public static void oracleTest()
		{
			OracleConnection con;
			try
			{
				con = new OracleConnection();
				con.ConnectionString = "User Id=ANONYMOUS;Password=scar34;Data Source=localhost:1521/orcl2";
				con.Open();
				Console.WriteLine("Connected to Oracle" + con.ServerVersion);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		static void timeConversion()
		{
			string time = Console.ReadLine();
			//while (Console.ReadLine() != "null")
			//{
			string meridian = time.Substring(time.Length - 2, 2);
			string hours = time.Substring(0, 2);
			string restOfTime = "", returnedTime = "";
			var hoursInt = int.Parse(hours);
			string hoursString = "";
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
		
	}
}
