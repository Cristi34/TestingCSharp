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

            int sumInt = 708;
            // build list from int
            ListNode ll1 = new ListNode(sumInt % 10);
            sumInt = sumInt / 10;
            ListNode prevNode = ll1;
            while (sumInt != 0)
            {
                ListNode newNode = new ListNode(sumInt % 10);
                sumInt = sumInt / 10;
                prevNode.next = newNode;

                prevNode = newNode;
            }


            tObj.StopTime();
            Console.WriteLine("\ntime (.NET): " + tObj.ElapsedMs + " milliseconds");
            Console.WriteLine("DONE Main");
            Console.ReadKey();
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        var ret = new int[2] { i, j };
                        return ret;
                    }
                }
            }
            return null;
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
