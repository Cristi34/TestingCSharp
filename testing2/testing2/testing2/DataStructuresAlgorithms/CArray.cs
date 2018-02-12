using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing2.DataStructuresAlgorithms
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
	}
}
