using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingCSharp.DataStructuresAlgorithms;

namespace TestingCSharp.DataStructuresAlgorithms
{
	public struct PqItem
	{
		public int priority;
		public string name;
	}


	public class PQueue //: Queue<PqItem>
	{
		public ArrayList Items = new ArrayList();
		
		public void Enqueue(PqItem item)
		{
			Items.Add(item);
		}
		
		public PqItem Dequeue()
		{
			PqItem maxItem = (PqItem)Items[0];
			foreach(PqItem item in Items)
			{
				if(item.priority > maxItem.priority)
				{
					maxItem = item;
				}
			}
			
			Items.Remove(maxItem);
				
			return maxItem;
		}
		public static void PQueueTest()
		{
			PQueue priorityQueue = new PQueue();
			priorityQueue.Enqueue(new PqItem
			{
				name = "Boss Nigga",
				priority = 33
			});
			priorityQueue.Enqueue(new PqItem
			{
				name = "Ma Nigga",
				priority = 10
			}); priorityQueue.Enqueue(new PqItem
			{
				name = "Kyle Nigga",
				priority = 0
			}); priorityQueue.Enqueue(new PqItem
			{
				name = "Shit Nigga",
				priority = 1
			}); priorityQueue.Enqueue(new PqItem
			{
				name = "Calm Nigga",
				priority = 12
			}); priorityQueue.Enqueue(new PqItem
			{
				name = "Damn Nigga",
				priority = 5
			});

			while (priorityQueue.Items.Count > 0)
			{
				var dequeued = priorityQueue.Dequeue();
				Console.WriteLine("dequeued item with name " + dequeued.name + " priority " + dequeued.priority);
			}
		}
	}
}

