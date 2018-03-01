using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingCSharp.DataStructuresAlgorithms;

namespace testing2.DataStructuresAlgorithms
{
	public struct PqItem
	{
		public int priority;
		public string name;
	}


	public class PQueue<T> : Queue<PqItem>
	{
		PqItem[] Items;
		//ArrayList ItemsArrayList = new ArrayList();
		public PQueue()
		{
			Items = base.ToArray();
		}
		public new PqItem Dequeue()
		{
			Items = base.ToArray();
			PqItem maxItem = Items[0];
			foreach(var item in Items)
			{
				if(item.priority > maxItem.priority)
				{
					maxItem = item;
				}
			}

			Items = Items.Where(x => !x.Equals(maxItem)).ToArray();
			// todo fix this
			base.Dequeue();
			return maxItem;
		}
	}
}

