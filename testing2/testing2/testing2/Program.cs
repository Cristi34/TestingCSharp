using Oracle.DataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Numerics;
using testing2.DataStructuresAlgorithms;

namespace testing2
{    
    class Program
    {
        public static int TestValue = 6;
		static int[] testArray = new int[] { 12, 34, 67, 23, 89, 28, 76, 45, 90, 21, 32, 43, 54, 65, 76, 87, 98, 123, 435, 16, 19, 37, 35, 39, 59, 48, 82, 83, 85 };
		static void Main(string[] args)
        {            
            //int[] nums = new int[size];
            
            Timing tObj = new Timing();
            tObj.StartTime();

			Console.WriteLine(CStack.BalancedParanthesesOneStack("{[[{([()])}]]}"));
			
			tObj.StopTime();
            Console.WriteLine("\ntime (.NET): " + tObj.ElapsedMs + " milliseconds");
			Console.WriteLine("DONE Main");
            Console.ReadKey();
        }
		
		static void PrintLine<T>(T line)
		{
			Console.WriteLine(line);
		}

		public static void ArrayListTest()
		{
			ArrayList x = new ArrayList() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
			x.TrimToSize();
			x.Add(18.5f);
			PrintLine(x[0].GetType());
			PrintLine(x[17]);
			PrintLine(x[17].GetType());
		}

        public static void EnumerableTest()
        {
            IEnumerable<int> result = from value in Enumerable.Range(0, 20)
                                      select value;

            // Loop.
            foreach (int value in result)
            {
                Console.WriteLine(value);
            }

            // We can use extension methods on IEnumerable<int>
            double average = result.Average();

        }

		static int maxDifference(int[] a)
		{
			int maxDifference = a[1] - a[0];
			int minElement = a[0];
			for (int i = 1; i < a.Length; i++)
			{
				if (a[i] > minElement)
				{
					int difference = a[i] - minElement;
					if (difference > maxDifference)
					{
						maxDifference = difference;
					}
				}
				else
				{
					minElement = a[i];
				}
			}
			return maxDifference;
		}

		static void testDeriv()
		{
			BaseClass b = new Derived();
			b.f1();
			b.f2();
			b.f3();
			b.AbstractMe();
			//b.DerivedClassMethod();
		}

		abstract class BaseClass
		{
			public void f1() { Console.WriteLine("base f1"); }
			public virtual void f2() { Console.WriteLine("base f2"); }
			public virtual void f3() { Console.WriteLine("base f3"); }
			public abstract void AbstractMe();
		}
		class Derived : BaseClass
		{
			new public void f1() { Console.WriteLine("derived f1"); }
			public override void f2() { Console.WriteLine("derived f2"); }
			public new void f3() { Console.WriteLine("derived f3"); }
			public override void AbstractMe()
			{
				Console.WriteLine("implemented abstract method from Derived class");
			}
			public void DerivedClassMethod()
			{
				Console.WriteLine("dervied class method");
			}
		}

		public class BaseClassSample
		{
			public int x = 100;
			public int y = 150;
			public void TestMethod()
			{
				Console.WriteLine("base class method");
			}
		}
		public class DerivedClass : BaseClassSample
		{
			new public static int x = 1000;
			int w, q;
			void TestBase()
			{
				w = base.y;
				q = base.x;
			}
		}

		//enum test
		enum Days { Mon, Tue, Wed, Thu, Fri, Sat, Sun }		
		public static void EnumTest()
		{
			// casting needed
			int x = (int)Days.Mon;			
		}

		static void WhyDoesThisWorkJesus()
		{
			p();
			void p()
			{
				Console.WriteLine("hi");
			}
		}
		static decimal fun(int i, Single j, double k)
		{
			return 5;
		}
		static void DataConversion()
		{
			int a = 22;
			long b = 44;
			double c = 1.406;
			b = a;
			c = a;
			a = (int)b;
			b = (long)c;
			// not like this:
			//a = b;
			//b = c;
		}
		static void Days1()
		{
			var days = "MTWTFSS";
			//var daysArray = days.ToCharArray().Cast<string>().ToArray();
			var daysArray = days.ToCharArray().Select(c => c.ToString()).ToArray();
			for (var i = 0; i < daysArray.Length; i++)
			{
				switch (daysArray[i])
				{
					case "M":
						daysArray[i] = "Monday";
						break;
					case "T":
						daysArray[i] = "Tuesday";
						break;
					case "W":
						daysArray[i] = "Wednesday";
						break;
					case "R":
						daysArray[i] = "Thursday";
						break;
					case "F":
						daysArray[i] = "Friday";
						break;
					case "S":
						daysArray[i] = "Saturday";
						break;
					case "U":
						daysArray[i] = "Sunday";
						break;
				}
			}
			daysArray[daysArray.Length - 1] = "and " + daysArray[daysArray.Length - 1];
			Console.WriteLine(string.Join(", ", daysArray));
		}
		static void charIntCalcul()
		{
			char l = 'k';
			float b = 19.0f;
			int c;

			//ASCII k=107
			c = Convert.ToInt32(l / b);
			Console.WriteLine(c);

			// note
			float x = (float)12.502d;
			float y = 2.123456789f;
			double q = 14.45654764;
			double w = 13.45678D;

			Console.Write("12.123456789f = " + y);
		}
		static void interestingResult()
		{
			int x = 1;
			float y = 2.4f;
			short z = 1;
			Console.WriteLine((float)x + y * z - (x += (short)y));
			Console.ReadLine();
		}
		static void calcultest()
		{
			int a = 12;
			float b = 6.2f;
			int c;
			//c = a / Convert.ToInt32(b) + a * Convert.ToInt32(b);
			// works but differnt result because of approximation
			c = Convert.ToInt32(a / b) + Convert.ToInt32(a * b);
			Console.WriteLine(c);
		}

		static void refTest()
		{
			int age1 = 20;
			ChangeInt(ref age1);
			Console.WriteLine("Effective parameter " + age1);
		}
		static void ChangeInt(ref int age2)
		{
			age2 = 30;
			Console.WriteLine("Formal parameter " + age2);
		}

		static void CielFloor()
		{
			double x = 4.56, y = 4.15;
			Console.WriteLine("for Ceiling(" + x + ") = " + Math.Ceiling(x));
			Console.WriteLine("for Ceiling(" + y + ") = " + Math.Ceiling(y));
			Console.WriteLine("for Floor(" + x + ") = " + Math.Floor(x));
			Console.WriteLine("for Floor(" + y + ") = " + Math.Floor(y));
		}

		void FloatTest()
		{
			int i = 3, j = 4;
			float f1 = (float)i / j;
			Console.Write(f1);
			Console.ReadLine();
		}

		struct book
		{
			private String name;
			private int pages;
			private Single price;
		}
		void StructTest()
		{
			book b = new book();
		}

		public static void TestTryCatchFinally()
        {
            try
            {
                int x = 0;
                int y = 5 / x;
            }
            catch (Exception ex)
            {
                var msg = ex.ToString();
                //try
                //{
                    throw new FormatException();
                //}
                //catch(Exception ex2)
                //{
                //    var msg2 = ex2.ToString();                    
                //}
            }
            finally
            {
                
            }
        }

        public static void testGroupBy()
        {
            // Create a list of pets.
            List<Pet> pets =
                new List<Pet>{
                       new Pet { Name="Barley", Age=8, testList = new List<int> {1,2,3 } },
                       new Pet { Name="Boots", Age=4, testList = new List<int> {6,8,34 }  },
                       new Pet { Name="Whiskers", Age=1, testList = new List<int> {556,12,345 }  },
                       new Pet { Name="Daisy", Age=4, testList = new List<int> {13,26,36 } }
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
                    foreach (var testListItem in listItem.testList)
                    {
                        Console.Write(testListItem + " ");
                    }
                    Console.WriteLine("");
                }
            }
        }

        public class Pet
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public List<int> testList { get; set; }
        }

        public class BaseClass2
        {
            public int x;
            string name;

            public BaseClass2()
            {
                Console.WriteLine("base class default constructor");
            }
            public BaseClass2(string name)
            {
                Console.WriteLine("base class constructor with parameter name = " + name);
                this.name = name;
            }
            public virtual void a()
            {
                Console.WriteLine("a from base class");
            }
            public override bool Equals(object obj)
            {
                var converted = obj as BaseClass2;
                if(converted.x == this.x)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public override string ToString()
            {
                return this.name;
            }

        }
        public class DerivedClass2 : BaseClass2
        {
            new public void a()
            {
                Console.WriteLine("a from derived class");
            }
            //public override void a()
            //{
            //    Console.WriteLine("a overriden in derived class");
            //}
            public void aFromBase()
            {
                base.a();
            }
            public void DerivedClassMethod()
            {
                Console.WriteLine("derived class method");
            }
        }

        // for test weird
        static void forTest()
        {
            float f;
            for (f = 0.1f; f <= 0.5; f += 1)
                Console.WriteLine(++f);
        }

        // Euler p9
        static void SpecialPythagoreanTriplet()
        {
            int a = 2, b = 3, c = 4, s = 0;
            while (s != 1000 && a <= 1000 && b <= 1000)
            {                
                if(int.TryParse(Math.Sqrt(a * a + b * b).ToString(), out c))
                {
                    s = a + b + c;
                    Console.WriteLine(a + " " + b);
                }
                if(s == 1000)
                {
                    Console.WriteLine("found a=" + a + " b=" + b + " c=" + c);
                    return;
                }
                if(s > 1000)
                {
                    a++;
                    b = a + 1;
                }
                b++;
                
            }
        }
        static bool Pythagora(int a, int b, int c)
        {
            if((a*a + b*b) == c*c)
            {
                return true;
            }
            return false;
        }
        // Euler p8
        static void LargestProduct()
        {
            string bigFNumber = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
            //Console.WriteLine(bigFNumber.Length);
            List<long> productList = new List<long>();
            for(int i = 0; i<1000 - 13; i++)
            {
                long number13 = Convert.ToInt64(bigFNumber.Substring(i, 13));
                productList.Add(DigitProduct(number13));
            }
            Console.WriteLine("largest product: " + productList.Max());
        }
        static long DigitProduct(long number)
        {
            long product = 1;
            while(number != 0)
            {
                product = product * (number % 10);
                number = number / 10;
            }
            return product;
        }
        // project Euler p7
        static void NPrime(int n)
        {
            int count = 0, number = 2;            
            while(count <= n)
            {
                if(IsPrime(number))
                {
                    count++;
                    if(count == n)
                    {
                        break;
                    }
                }
                number++;
            }
            Console.WriteLine("the " + n + "th prime is " + (number));
        }
        // project Euler problem 6
        static void SumSquareDiff()
        {
            int sumOfSquares = 0, sum = 0;
            for(int i = 1; i <= 100; i++)
            {
                sumOfSquares = sumOfSquares + i * i;
                sum = sum + i;
            }
            int squareOfSum = sum * sum;
            Console.WriteLine("sumOfSquares = " + sumOfSquares + " squareOfSum = " + squareOfSum + " dif = " + (squareOfSum - sumOfSquares));
        } 
        // project Euler problem 5
        static void SmallestMultiple()
        {
            int number = 21;
            while(true)
            {
                bool isNotValid = false;
                for (int i = 2; i <= 20; i++)
                {                    
                    if(number % i != 0)
                    {
                        isNotValid = true;                        
                        break;
                    }    
                }
                if(isNotValid == false)
                {
                    Console.WriteLine("found " + number);
                    return;
                }
                number++;
            }
        }
        // project Euler problem 4
        static void PalindromeProduct()
        {
            int first = 999, second = 999;
            List<int> foundPalindromesList = new List<int>();
            while(first != 0)
            {
                second = 999;
                while(second != 0)
                {
                    var product = first * second;
                    if (IsPalindrome(product))
                    {
                        foundPalindromesList.Add(product);
                        //Console.WriteLine("found " + product + " from " + first + " " + second);
                        //if(product == 906609)
                        //{
                        //    Console.WriteLine("found " + product + " from " + first + " " + second);
                        //}
                        break;
                    }
                    second--;
                }
                first--;
            }
            Console.WriteLine(foundPalindromesList.Max());
        }
        static bool IsPalindrome(int number)
        {
            int aux = number, reverse = 0;
            while(number != 0)
            {
                reverse = reverse*10 + number % 10;
                number = number / 10;
            }
            if (reverse == aux)
                return true;
            else
                return false;
        }
        public static void fibonacci1000()
        {
            int i = 0;
            int cnt = 2;
            BigInteger limit = BigInteger.Pow(10, 999);
            //Console.WriteLine("limit = " + limit);
            BigInteger[] fib = new BigInteger[3];

            fib[0] = 1;
            fib[2] = 1;

            while (fib[i] <= limit)
            {
                i = (i + 1) % 3;
                cnt++;
                fib[i] = fib[(i + 1) % 3] + fib[(i + 2) % 3];                
            }
            Console.WriteLine("fib[" + cnt + "] = " + fib[i]);
        }

        // Project Euler problem 3
        public static long maxPrimeFactor(long number)
        {
            var primeFactors = new List<long>();
            long largestPrimeFactor = 0;
            for(long i=number/2; i >= 2; i--)
            {
                //Console.WriteLine(String.Format("{0:0.000000000000000000}", (Convert.ToDouble(i) * 100) / fullPercent) + "%");
                //Console.WriteLine(((i * 100) / fullPercent).ToString() + "%");   
                
                if (number % i == 0)
                {                    
                    if (IsPrime(i))
                    {
                        //primeFactors.Add(i);
                        Console.WriteLine("FOUND MAX PRIME FACTOR " + i);
                        largestPrimeFactor = i;
                        break;
                    }
                }
                //Console.WriteLine(" ");
            }
            return largestPrimeFactor;
            //return primeFactors.Max();
        }
        public static bool IsPrime(long number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
        public static void problemaTriunghiNr()
        {
            displayNrPyramid();
            Console.WriteLine("press enter to continue or ESC to exit");
            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                displayNrPyramid();
                Console.WriteLine("press enter to continue or ESC to exit");
            }
        }
        public static void displayNrPyramid()
        {
            Console.Write("enter how many rows to be computed: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int m = computeOddNumber(n);
            // initialise 2d array with spaces
            string[,] a = new string[n, m];
            for(int i = 0; i<n; i++)
            {
                for(int j = 0; j<m; j++)
                {
                    a[i,j] = " ";
                }
            }

            // actually compute this freaking thing
            int middleColumnIndex = n - 1; 
            for(int i = 0; i<n; i++)
            {
                a[i, middleColumnIndex] = (i + 1).ToString();

                //int k = i;
                int q = 1;
                for (int k = i; k > 0; k--)
                {                    
                    a[i, middleColumnIndex - k] = q.ToString();
                    a[i, middleColumnIndex + k] = q.ToString();
                    q++;
                    
                }
                
            }

            // display 2d array
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                   Console.Write(a[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }

        // calculeaza al n-lea nr impar
        public static int computeOddNumber(int n)
        {
            int x = 1, count = 1, result = 1;            
            while(count <= n)
            {
                if(x%2 != 0)
                {
                    count++;
                    result = x;
                }
                x++;
            }
            return result;
        }
        //public static void display2DArray(char a[,])
        //{

        //}
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
        public static void LiskovPrinciple()
        {
            Car myLamborghini = new Car();
            myLamborghini.DriveTo("Los Santos");

            Vehicle myVehicle = new Car();

            Car myToyota = new Toyota();
            myToyota.DriveTo("Pitesti");
        }
        public static void UpperBoundTest()
        {
            int[,] intMyArr = { { 7, 1, 3 }, { 2, 9, 6 } };
            Console.WriteLine(intMyArr.GetUpperBound(1));
            Console.WriteLine(intMyArr.Length);
            Console.WriteLine(intMyArr.GetUpperBound(0));
        }
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
        static int tryCatchFinally()
        {
            try
            {
                howManyTimesNumberAppears();
                return 1;
            }
            catch (Exception ex)
            {
                return 2;
            }
            finally
            {
                //return 3;
            }

        }
        static void howManyTimesNumberAppears()
        {
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, int.Parse);
            Hashtable ht = new Hashtable();
            HashSet<int> hs = new HashSet<int>();

            foreach (var element in a)
            {
                if (hs.Add(element))
                {
                    ht.Add(element, 1);
                }
                else
                {
                    ht[element] = (int)ht[element] + 1;
                }
            }

            foreach (DictionaryEntry element in ht)
            {
                Console.WriteLine(element.Key + " appears " + element.Value + " times");
            }
        }
        static void performRotationsUsingQueue()
        {
            string[] a_temp = Console.ReadLine().Split(' ');
            Queue q = new Queue(a_temp);

            for (int i = 0; i < 3; i++)
            {
                var firstElem = q.Dequeue();
                q.Enqueue(firstElem);
                foreach (var element in q)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine("");
            }
        }
        static void performRotations()
        {
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            var n = a.Length;
            for (int i = 0; i < 3; i++)
            {
                int first = a[0];
                Array.Copy(a, 1, a, 0, n - 1);
                a[n - 1] = first;

                foreach (var element in a)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine("");
            }
        }
        static void performRotationsInefficiently(/*int k, int[] a*/)
        {
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            int[] aux = new int[a.Length];
            for (int i = 0; i < 3; i++)
            {
                Array.Clear(aux, 0, aux.Length - 1);
                for (int j = 1; j < a.Length; j++)
                {
                    aux[j] = a[j - 1];
                }
                aux[0] = a[a.Length - 1];
                Array.Copy(aux, a, a.Length);
            }
        }
        static void StairCase(int n)
        {
            string[] hashtag = new string[n];
            hashtag[0] = " ";
            for (int i = 1; i < n; i++)
            {
                hashtag[i] = " ";
            }
            for (int i = n - 1; i >= 0; i--)
            {
                hashtag[i] = "#";
                foreach (string s in hashtag)
                {
                    Console.Write(s);
                }
                Console.WriteLine("");
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
            //}
        }
        static void TestYield()
        {
            foreach (var i in Integers())
            {
                Console.WriteLine(i);
            }
        }
        public static IEnumerable Integers()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 123, 456, 1234 };
            yield return list;
        }
    }
}
