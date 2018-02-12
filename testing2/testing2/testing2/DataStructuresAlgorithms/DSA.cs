using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing2.DataStructuresAlgorithms
{
	public class DSA
	{
		public static int SumNums(params int[] nums)
		{
			int sum = 0;
			for (int i = 0; i <= nums.GetUpperBound(0); i++)
				sum += nums[i];
			return sum;
		}
		public static void BuildArray(int[] arr)
		{
			//Thread.Sleep(3000);
			for (int i = 0, size = arr.GetUpperBound(0); i < size; i++)
				arr[i] = i;
		}
		public static void DisplayNums<T>(IEnumerable<T> arr)
		{
			//for (int i = 0, size = arr.Count(); i < size; i++)
			//{
			//	Console.Write(arr(i) + " ");
			//}				
			foreach(var item in arr)
			{
				Console.Write(item + " ");
			}
		}

		public static void InsertRandomNumbers(int seed, ArrayList arr)
		{			
			Random rnd = new Random(seed);
			for (int i = 0; i < 10; i++)
			{
				arr.Add((int)(rnd.NextDouble() * 100));
			}
		}

		public static void InsertRandomNumbers(int limit, CArray arr)
		{			
			Random rnd = new Random();
			for (int i = 0, size = arr.Size; i < size; i++)
			{
				arr.Insert(rnd.Next(1, limit));				
			}
			arr.DisplayElements();
		}
		
	}
}
