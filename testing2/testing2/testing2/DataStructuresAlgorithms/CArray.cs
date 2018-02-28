using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.DataStructuresAlgorithms
{
	public class CArray
	{
		private int[] arr;
		// upper = index of last element
		private int upper;
		public int Size { get; set; }
		private int numElements;
		public CArray(int size)
		{
			Size = size;
			arr = new int[Size];
			upper = Size - 1;
			numElements = 0;
		}
		public void Insert(int item)
		{
			arr[numElements] = item;
			numElements++;
		}
		public void DisplayElements()
		{
			Console.WriteLine("\ndisplay CArray elements");
			for (int i = 0; i <= upper; i++)
			{				
				Console.Write(arr[i] + " ");
			}
			Console.WriteLine();
		}
		public void Clear()
		{
			for (int i = 0; i <= upper; i++)
				arr[i] = 0;
			numElements = 0;
		}

		public void BubbleSort()
		{
			//Console.WriteLine("\nbegin bubble sort");
			int temp;
			for (int outer = upper; outer >= 1; outer--)
			{
				//Console.WriteLine("outer = " + outer);
				for (int inner = 0; inner <= outer - 1; inner++)
				{
					//Console.WriteLine("inner = " + inner);
					if ((int)arr[inner] > arr[inner + 1])
					{
						temp = arr[inner];
						arr[inner] = arr[inner + 1];
						arr[inner + 1] = temp;
					}
					//DisplayElements();
				}
			}
			//Console.WriteLine("\nCArray sorted");
			//DisplayElements();
		}

		public void SelectionSort()
		{
			int min, temp;
			for (int outer = 0; outer <= upper; outer++)
			{
				min = outer;
				for (int inner = outer + 1; inner <= upper; inner++)
				{
					if (arr[inner] < arr[min])
					{
						min = inner;
					}
				}
				temp = arr[outer];
				arr[outer] = arr[min];
				arr[min] = temp;
			}
		}

		public static void SelectionSort(ref int[] arr)
		{
			int min, temp, upper = arr.Length - 1;
			for (int outer = 0; outer <= upper; outer++)
			{
				min = outer;
				for (int inner = outer + 1; inner <= upper; inner++)
				{
					if (arr[inner] < arr[min])
					{
						min = inner;
					}
				}
				temp = arr[outer];
				arr[outer] = arr[min];
				arr[min] = temp;
			}
		}

		public void InsertionSort()
		{
			int inner, temp;
			for (int outer = 1; outer <= upper; outer++)
			{
				temp = arr[outer];
				inner = outer;
				while (inner > 0 && arr[inner - 1] >= temp)
				{
					arr[inner] = arr[inner - 1];
					inner -= 1;
				}
				arr[inner] = temp;
			}
		}

		// Pareto distributions
		public int SequentialSearchSelfAdjusted(int sValue)
		{
			for (int index = 0; index < arr.Length - 1; index++)
				if (arr[index] == sValue)
				{
					Swap(ref arr[index], ref arr[index - 1]);
					return index;
				}
			return -1;
		}

		public static void Swap<T>(ref T a,ref T b)
		{
			T temp;
			temp = a;
			a = b;
			b = temp;
		}

		public static int BinarySearch(int[] arr, int searchValue)
		{			
			int lowerBound = 0, upperBound = arr.Length;
			int middle, nr = 0;
			SelectionSort(ref arr);

			while (lowerBound <= upperBound)
			{
				nr++;
				middle = (upperBound + lowerBound) / 2;
				if (arr[middle] == searchValue)
				{
					Console.WriteLine("nr of iterations = " + nr);
					Console.WriteLine("item at index = " + middle + " is " + arr[middle]);
					return middle;
				}
				if (arr[middle] > searchValue) // searchValue is to the left
				{
					upperBound = middle - 1;
				}
				else
				{
					lowerBound = middle + 1;
				}				
			}

			return -1;
		}

		public static int RecursiveBinarySearch(int[] arr, int value, int lower, int upper)
		{
			if (lower > upper)
				return -1;
			else
			{
				int mid;
				mid = (int)(upper + lower) / 2;
				if (value < arr[mid])
					RecursiveBinarySearch(arr, value, lower, mid - 1);
				else if (value == arr[mid])
					return mid;
				else
					RecursiveBinarySearch(arr, value, mid + 1, upper);
			}

			return -1;
		}
	}
}
