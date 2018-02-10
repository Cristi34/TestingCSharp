using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
	public class DataStructuresAlgorithms
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
		public static void DisplayNums(int[] arr)
		{
			for (int i = 0, size = arr.GetUpperBound(0); i <= size; i++)
				Console.Write(arr[i] + " ");
		}
	}
}
