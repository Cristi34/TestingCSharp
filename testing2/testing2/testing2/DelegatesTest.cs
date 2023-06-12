using System;
using TestingCSharp.Helpers;

namespace TestingCSharp
{
	// When the C# compiler processes delegate types, it automatically generates a SEALED class deriving 
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
            {
				return x + y;
			}
            public static int Subtract(int x, int y)
            {
				return x - y;
			}
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

        // Important! When the C# compiler processes delegate types, it automatically generates a sealed class deriving from System.MulticastDelegate
        /* As you can see, the compiler-generated BinaryOp class defines three public methods. Invoke() is perhaps the key method, as it is used to 
         * invoke each method maintained by the delegate object in a synchronous manner, meaning the caller must wait for the call to complete before 
         * continuing on its way. Strangely enough, the synchronous Invoke() method may not need to be called explicitly from your C# code. As you 
         * will see in just a bit, Invoke() is called behind the scenes when you use the appropriate C# syntax.

         * BeginInvoke() and EndInvoke() provide the ability to call the current method asynchronously on a separate thread of execution. If you have 
         * a background in multithreading, you know that one of the most common reasons developers create secondary threads of execution is to invoke 
         * methods that require time to complete. Although the .NET base class libraries supply several namespaces devoted to multithreaded and 
         * parallel programming, delegates provide this functionality out of the box.

         * Now, how exactly does the compiler know how to define the Invoke(), BeginInvoke(), and EndInvoke() methods? To understand the process, here 
         * is the crux of the compiler-generated BinaryOp class type (bold italic marks the items specified by the defined delegate type)
         
         *  sealed class BinaryOp : System.MulticastDelegate
            {
              public int Invoke(int x, int y);
              public IAsyncResult BeginInvoke(int x, int y, AsyncCallback cb, object state);
              public int EndInvoke(IAsyncResult result);
            }

         */
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
            // Now with multicasting support!
            // Note we are now using the += operator, not
            // the assignment operator (=).
            public void RegisterWithCarEngine(CarEngineHandler methodToCall)
            {
                //When you use the += operator on a delegate object, the compiler resolves this to a call on the static Delegate.Combine() method.
                //In fact, you could call Delegate.Combine() directly; however, the += operator offers a simpler alternative                
                listOfHandlers += methodToCall;

                // calling Delegate.Combine()
                //if (listOfHandlers == null)
                //    listOfHandlers = methodToCall;
                //else
                //    Delegate.Combine(listOfHandlers, methodToCall);
            }

            // ability to unsubscribe
            public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
            {
                listOfHandlers -= methodToCall;
            }

            // 4) Implement the Accelerate() method to invoke the delegate’s
            //    invocation list under the correct circumstances.
            public void Accelerate(int delta)
            {
                // If this car is "dead," send dead message.
                if (carIsDead)
                {
                    if (listOfHandlers != null)
                        listOfHandlers("Sorry, this car is dead...");
                }
                else
                {
                    CurrentSpeed += delta;

                    // Is this car "almost dead"?
                    if (10 == (MaxSpeed - CurrentSpeed)
                        && listOfHandlers != null)
                    {
                        listOfHandlers("Careful buddy! Gonna blow!");
                    }
                    if (CurrentSpeed >= MaxSpeed)
                        carIsDead = true;
                    else
                        Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }
            }

            public static void TestCarDelegate()
            {
                Console.WriteLine("***** Delegates as event enablers *****\n");

                // First, make a Car object.
                Car c1 = new Car("SlugBug", 100, 10);
                c1.RegisterWithCarEngine(new CarEngineHandler(OnCarEngineEvent));
                // or like this
                // c1.RegisterWithCarEngine(OnCarEngineEvent);

                // This time, hold onto the delegate object,
                // so we can unregister later.
                Car.CarEngineHandler handler2 = new CarEngineHandler(OnCarEngineEvent2);
                c1.RegisterWithCarEngine(handler2);

                // Speed up (this will trigger the events).
                Console.WriteLine("***** Speeding up *****");
                for (int i = 0; i < 6; i++)
                    c1.Accelerate(20);

                // Unregister from the second handler.
                c1.UnRegisterWithCarEngine(handler2);
                // c1.UnRegisterWithCarEngine(CallMeHere);

                // We won’t see the "uppercase" message anymore!
                Console.WriteLine("***** Speeding up *****");
                for (int i = 0; i < 6; i++)
                    c1.Accelerate(20);

                Console.ReadLine();
            }

            // This is the target for incoming events.
            public static void OnCarEngineEvent(string msg)
            {
                Console.WriteLine("\n***** Message From Car Object *****");
                Console.WriteLine("=> {0}", msg);                
            }

            public static void OnCarEngineEvent2(string msg)
            {
                Console.WriteLine("=> {0}", msg.ToUpper());
                Console.WriteLine("***********************************\n");
            }

        }

        #endregion

        #region C# 6.0 and the .NET 4.6 Framework, Seventh Edition - Delegates part III - Action<> and Func<>

        // This is a target for the Action<> delegate.
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            // Set color of console text.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }

            // Restore color.
            Console.ForegroundColor = previous;
        }

        // Target for the Func<> delegate.
        static int Add(int x, int y)
        {
            return x + y;
        }

        static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }

        public static void TestActionDelegate()
        {
            Console.WriteLine("***** Fun with Action and Func *****");

            // Use the Action<> delegate to point to DisplayMessage.
            Action<string, ConsoleColor, int> actionTarget =
              new Action<string, ConsoleColor, int>(DisplayMessage);
            actionTarget("Action Message!", ConsoleColor.Yellow, 5);

            Console.ReadLine();
        }

        public static void TestFuncDelegate()
        {
            Func<int, int, int> funcTarget = Add;
            int result = funcTarget.Invoke(40, 40);
            Console.WriteLine($"40 + 40 = {result}");

            Func<int, int, string> funcTarget2 = SumToString;
            string sum = funcTarget2(90, 300);
            Console.WriteLine(sum);
        }

		#endregion

		#region Other Examples

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

		public class TestDelegate2
		{
			public static Func<int, int, int> MathOp;

			public static void Test()
			{
				MathOp = (x, y) =>
				{
					Console.WriteLine("hello from inside the delegate method");
					return x * y;
				};

				var result = MathOp(5, 6);
				Console.WriteLine($"MathOp = {result}");
			}
		}

		#endregion
	}
}

