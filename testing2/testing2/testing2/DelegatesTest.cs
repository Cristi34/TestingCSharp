using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingCSharp.Helpers;

namespace TestingCSharp
{
    // When the C# compiler processes delegate types, it automatically generates a sealed class deriving 
    // from System.MulticastDelegate which derives from System.Delegate
	public class DelegatesTest
	{
        #region C# 6.0 and the .NET 4.6 Framework, Seventh Edition - Delegates part I - basic delegate example

        // This delegate can point to any method,
        // taking two integers and returning an integer.
        public delegate int BinaryOp(int x, int y);

        // This class contains methods BinaryOp will
        // point to.
        public class SimpleMath
        {
            public static int Add(int x, int y)
            { return x + y; }
            public static int Subtract(int x, int y)
            { return x - y; }
        }

        static void DisplayDelegateInfo(Delegate delObj)
        {
            // Print the names of each member in the
            // delegate’s invocation list.
            foreach (Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine("Method Name: {0}", d.Method);
                Console.WriteLine("Type Name: {0}", d.Target); // Target is empty if method is static because Target point to the instance !!!
            }
        }

        public static void TestSimpleMathDelegate()
        {
            Console.WriteLine("***** Simple Delegate Example *****\n");

            // Create a BinaryOp delegate object that
            // "points to" SimpleMath.Add().
            BinaryOp b = new BinaryOp(SimpleMath.Add);

            // Invoke Add() method indirectly using delegate object.
            Console.WriteLine("10 + 10 is {0}", b(10, 10));

            DisplayDelegateInfo(b);
        }

        #endregion

        #region C# 6.0 and the .NET 4.6 Framework, Seventh Edition - Delegates part II - a more concrete example

        public class Car
        {
            // Internal state data.
            public int CurrentSpeed { get; set; }
            public int MaxSpeed { get; set; } = 100;
            public string PetName { get; set; }

            // Is the car alive or dead?
            private bool carIsDead;

            // Class constructors.
            public Car() { }
            public Car(string name, int maxSp, int currSp)
            {
                CurrentSpeed = currSp;
                MaxSpeed = maxSp;
                PetName = name;
            }

            // 1) Define a delegate type.
            public delegate void CarEngineHandler(string msgForCaller);

            // 2) Define a member variable of this delegate.
            private CarEngineHandler listOfHandlers;

            // 3) Add registration function for the caller.
            public void RegisterWithCarEngine(CarEngineHandler methodToCall)
            {
                listOfHandlers = methodToCall;
            }
        }

        #endregion

        public delegate void WriteToConsoleDelegate(string str);
		public delegate void Print(int value);

		public static void AnonymousMethodTest()
		{
			int i = 10;

			Print prnt = delegate (int val) {
				val += i;
				Console.WriteLine("Anonymous method: {0}", val);
			};

			prnt(100);
		}

		public static void DelegateTest()
		{
			WriteToConsoleDelegate del1 = new WriteToConsoleDelegate(WriteString);
			WriteToConsoleDelegate del2 = new WriteToConsoleDelegate(WritePaddedString);
			// or you can do this
			WriteToConsoleDelegate del3 = PrintAllCaps;

			var testString = "alabala";
			del1(testString);
			del2(testString);
			del3(testString);
		}

		private static void WriteString(string str)
		{
			Console.WriteLine("string: " + str);
		}
		private static void WritePaddedString(string str)
		{
			Console.WriteLine("string padded: " + "000000" + str);
		}
		private static void PrintAllCaps(string str)
		{
			Console.WriteLine("All Caps: " + str.ToUpper());
		}
        	
		public delegate bool FindStudent(Student std);		

		public class StudentExtension
		{
			public static Student[] FindStudents(Student[] stdArray, FindStudent del)
			{
				int i = 0;
				Student[] result = new Student[10];
				foreach (Student std in stdArray)
					if (del(std))
					{
						result[i] = std;
						i++;
					}

				return result;
			}
		}

		public static void StudentExtensionTest()
		{
			Student[] studentArray = {
				new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
				new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
				new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
				new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
				new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 } ,
				new Student() { StudentID = 6, StudentName = "Chris",  Age = 17 } ,
				new Student() { StudentID = 7, StudentName = "Rob",Age = 19  } ,
			};

			var students = StudentExtension.FindStudents(studentArray, delegate (Student std)
			{
				return std.Age > 12 && std.Age < 20;
			});
			
			foreach (var std in students)
			{
				if (std != null && !string.IsNullOrEmpty(std.StudentName))
				{
					Console.WriteLine(std.StudentName);
				}
			}
			//Also, use another criteria using same delegate
			students = StudentExtension.FindStudents(studentArray, delegate (Student std) {
				return std.StudentID == 5;
			});			
		}
	}
}

