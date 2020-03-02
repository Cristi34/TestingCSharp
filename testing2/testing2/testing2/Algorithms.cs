using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace TestingCSharp
{
	public class AlgorithmsOfAllSorts
	{
		static int MaxDifference(int[] a)
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

		static void HowManyTimesNumberAppears()
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
		static void PerformRotationsUsingQueue()
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
		static void PerformRotations()
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
		static void PerformRotationsInefficiently(/*int k, int[] a*/)
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

		// Euler p9
		static void SpecialPythagoreanTriplet()
		{
			int a = 2, b = 3, c = 4, s = 0;
			while (s != 1000 && a <= 1000 && b <= 1000)
			{
				if (int.TryParse(Math.Sqrt(a * a + b * b).ToString(), out c))
				{
					s = a + b + c;
					Console.WriteLine(a + " " + b);
				}
				if (s == 1000)
				{
					Console.WriteLine("found a=" + a + " b=" + b + " c=" + c);
					return;
				}
				if (s > 1000)
				{
					a++;
					b = a + 1;
				}
				b++;

			}
		}
		static bool Pythagora(int a, int b, int c)
		{
			if ((a * a + b * b) == c * c)
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
			for (int i = 0; i < 1000 - 13; i++)
			{
				long number13 = Convert.ToInt64(bigFNumber.Substring(i, 13));
				productList.Add(DigitProduct(number13));
			}
			Console.WriteLine("largest product: " + productList.Max());
		}
		static long DigitProduct(long number)
		{
			long product = 1;
			while (number != 0)
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
			while (count <= n)
			{
				if (IsPrime(number))
				{
					count++;
					if (count == n)
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
			for (int i = 1; i <= 100; i++)
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
			while (true)
			{
				bool isNotValid = false;
				for (int i = 2; i <= 20; i++)
				{
					if (number % i != 0)
					{
						isNotValid = true;
						break;
					}
				}
				if (isNotValid == false)
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
			while (first != 0)
			{
				second = 999;
				while (second != 0)
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
			while (number != 0)
			{
				reverse = reverse * 10 + number % 10;
				number = number / 10;
			}
			if (reverse == aux)
				return true;
			else
				return false;
		}
		public static void Fibonacci1000()
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
		public static long MaxPrimeFactor(long number)
		{
			var primeFactors = new List<long>();
			long largestPrimeFactor = 0;
			for (long i = number / 2; i >= 2; i--)
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
		public static void ProblemaTriunghiNr()
		{
			DisplayNrPyramid();
			Console.WriteLine("press enter to continue or ESC to exit");
			while (Console.ReadKey(true).Key != ConsoleKey.Escape)
			{
				DisplayNrPyramid();
				Console.WriteLine("press enter to continue or ESC to exit");
			}
		}
		public static void DisplayNrPyramid()
		{
			Console.Write("enter how many rows to be computed: ");
			int n = Convert.ToInt32(Console.ReadLine());
			int m = ComputeOddNumber(n);
			// initialise 2d array with spaces
			string[,] a = new string[n, m];
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					a[i, j] = " ";
				}
			}

			// actually compute this freaking thing
			int middleColumnIndex = n - 1;
			for (int i = 0; i < n; i++)
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
		public static int ComputeOddNumber(int n)
		{
			int x = 1, count = 1, result = 1;
			while (count <= n)
			{
				if (x % 2 != 0)
				{
					count++;
					result = x;
				}
				x++;
			}
			return result;
		}

        public static void TimeConversion()
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
    }
}
