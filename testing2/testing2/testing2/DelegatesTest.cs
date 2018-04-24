using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp
{
	public class DelegatesTest
	{
		public delegate void WriteToConsoleDelegate(string str);
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

		public class Student
		{
			public int StudentID { get; set; }
			public String StudentName { get; set; }
			public int Age { get; set; }
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

