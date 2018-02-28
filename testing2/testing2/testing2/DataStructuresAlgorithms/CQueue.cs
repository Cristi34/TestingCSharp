using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.DataStructuresAlgorithms
{
	public class CQueue
	{
		private ArrayList pqueue;
		public CQueue()
		{
			pqueue = new ArrayList();
		}
		public void EnQueue(object item)
		{
			pqueue.Add(item);
		}
		public void DeQueue()
		{
			pqueue.RemoveAt(0);
		}
		public object Peek()
		{
			return pqueue[0];
		}
		public void ClearQueue()
		{
			pqueue.Clear();
		}
		public int Count()
		{
			return pqueue.Count;
		}

		#region Dancers Queue Problem
		public struct Dancer
		{
			public string name;
			public string sex;
			public void GetName(string n)
			{
				name = n;
			}
			public override string ToString()
			{
				return name;
			}
		}

		static void NewDancers(Queue male, Queue female)
		{
			Dancer m, w;
			m = new Dancer();
			w = new Dancer();
			if (male.Count > 0 && female.Count > 0)
			{
				m.GetName(male.Dequeue().ToString());
				w.GetName(female.Dequeue().ToString());
			}
			else if ((male.Count > 0) && (female.Count == 0))
				Console.WriteLine("Waiting on a female dancer.");
			else if ((female.Count > 0) && (male.Count == 0))
				Console.WriteLine("Waiting on a male dancer.");
		}

		static void HeadOfLine(Queue male, Queue female)
		{
			Dancer w, m;
			m = new Dancer();
			w = new Dancer();
			if (male.Count > 0)
				m.GetName(male.Peek().ToString());
			if (female.Count > 0)
				w.GetName(female.Peek().ToString());
			if (m.name != " " && w.name != "")
				Console.WriteLine("Next in line are: " + m.name + "\t" + w.name);
			else if (m.name != "")
				Console.WriteLine("Next in line is: " + m.name);
			else
				Console.WriteLine("Next in line is: " + w.name);
		}

		static void StartDancing(Queue male, Queue female)
		{
			Dancer m, w;
			m = new Dancer();
			w = new Dancer();
			Console.WriteLine("Dance partners are: ");
			Console.WriteLine();
			for (int i = 0; i <= 3; i++)
			{
				m.GetName(male.Dequeue().ToString());
				w.GetName(female.Dequeue().ToString());
				Console.WriteLine(w.name + "\t" + m.name);
			}
		}

		static void FormLines(Queue male, Queue female)
		{
			Dancer d = new Dancer();
			StreamReader inFile;
			inFile = File.OpenText("c:\\dancers.txt");
			string line;
			while (inFile.Peek() != -1)
			{
				line = inFile.ReadLine();
				d.sex = line.Substring(0, 1);
				d.name = line.Substring(2, line.Length - 2);
				if (d.sex == "M")
					male.Enqueue(d);
				else
					female.Enqueue(d);
			}
		}

		public static void DancersQueueTest()
		{
			Queue males = new Queue();
			Queue females = new Queue();
			FormLines(males, females);
			StartDancing(males, females);
			if (males.Count > 0 || females.Count > 0)
				HeadOfLine(males, females);
			NewDancers(males, females);
			if (males.Count > 0 || females.Count > 0)
				HeadOfLine(males, females);
			NewDancers(males, females);
			Console.Write("press enter");
			Console.Read();
		}
		#endregion
	}
}
