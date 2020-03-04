using Oracle.DataAccess.Client;
using System;
using TestingCSharp.DataStructuresAlgorithms;

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

			CollectionsTest.DictionaryTest();

			tObj.StopTime();
			Console.WriteLine("\ntime (.NET): " + tObj.ElapsedMs + " milliseconds");
			Console.WriteLine("DONE Main");
			Console.ReadKey();
		}

		public static double Operatii(int a, int b)
		{
			var t = (a + b) * 2;
			Console.WriteLine($"t = {t}");
			return Math.Sqrt(t);
		}

        public static int CalculateMax(int[] buildingHeights)
        {
            // to be called in main
            int[] a = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            //Console.WriteLine(Calculate(a));

            int[] aMax = { 1, 2, 1, 5, 2, 4, 1, 0, 1, 2, 6, 4, 5, 2, 3, 4, 1, 2 };
            int[] amax2 = { 10, 8, 10, 8, 10, 8, 10 };
            Console.WriteLine("result: " + CalculateMax(a));
            //int[] a = { 13, 22, 24, 5, 3, 7, 12, 67, 34, 68, 31, 17 };
            //int n = 18;

            int result = 0;
            int maxHeight = 0;
            int maxIndex = -1, maxLeftHeight = 0, maxLeftIndex = 0, maxRightHeight = 0, maxRightIndex = 0;

            // compute total max height and it's index
            for (int j = 0; j < buildingHeights.Length; j++)
            {
                if (buildingHeights[j] > maxHeight)
                {
                    maxHeight = buildingHeights[j];
                    maxIndex = j;
                }
            }
            //Console.WriteLine("maxHeight= " + maxHeight + " maxIndex= " + maxIndex);

            //compute left maxHeight and index
            for (int j = 0; j < maxIndex; j++)
            {
                if (buildingHeights[j] > maxLeftHeight)
                {
                    maxLeftHeight = buildingHeights[j];
                    maxLeftIndex = j;
                }
            }
            //Console.WriteLine("maxLeftHeight= " + maxLeftHeight + " maxLeftIndex= " + maxLeftIndex);

            //compute right maxHeight and index
            for (int j = buildingHeights.Length - 1; j > maxIndex; j--)
            {
                if (buildingHeights[j] > maxRightHeight)
                {
                    maxRightHeight = buildingHeights[j];
                    maxRightIndex = j;
                }
            }
            //Console.WriteLine("maxRightHeight= " + maxRightHeight + " maxRightIndex= " + maxRightIndex);

            int maxQ = 0, resultLeft = 0, resultRight = 0;
            for (int j = maxLeftIndex; j <= maxIndex; j++)
            {
                maxQ = Math.Max(maxQ, buildingHeights[j]);
                resultLeft += maxQ - buildingHeights[j];
            }
            maxQ = 0;
            for (int j = maxRightIndex; j >= maxIndex; j--)
            {
                maxQ = Math.Max(maxQ, buildingHeights[j]);
                resultRight += maxQ - buildingHeights[j];
            }

            //Console.WriteLine("left: " + resultLeft + " right: " + resultRight);
            result = Math.Max(resultLeft, resultRight);
                    
            return result;
        }
        public static bool IsPrime(int n)
        {
            for (int i = 2; i < n / 2; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }                
            }
            return true;
        }

        public static int Calculate(int[] buildingHeights)
        {
            int result = 0;
            int maxHeight = 0;
            int maxIndex = -1;

            // compute total max height and it's index
            for (int j = 0; j < buildingHeights.Length; j++)
            {
                if (buildingHeights[j] > maxHeight)
                {
                    maxHeight = buildingHeights[j];
                    maxIndex = j;
                }
            }

            var leftMax = 0;
            for (int j = 0; j < maxIndex; j++)
            {
                leftMax = Math.Max(leftMax, buildingHeights[j]);
                result += leftMax - buildingHeights[j];
            }
            var rightMax = 0;
            for (int j = buildingHeights.Length - 1; j >= maxIndex; j--)
            {
                rightMax = Math.Max(rightMax, buildingHeights[j]);
                result += rightMax - buildingHeights[j];
            }

            return result;
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
