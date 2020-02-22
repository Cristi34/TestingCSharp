using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace TestingCSharp
{
	public class ObjectPool<T> where T : new()
	{
		private readonly ConcurrentBag<T> items = new ConcurrentBag<T>();
		private int counter = 0;
		private int MAX = 10;

		public void Release(T item)
		{
			if (counter < MAX)
			{
				items.Add(item);
				counter++;

				if (item is TestPool)
				{
					Console.Write("Release to Pool Object Serial Number: ");
					Console.WriteLine((item as TestPool).SerialNumber);
				}
			}
		}

		public T Get(T item)
		{
			if (items.TryTake(out item))
			{
				counter--;
				if(item is TestPool)
				{
					Console.Write("Get from Pool Object Serial Number: ");
					Console.WriteLine((item as TestPool).SerialNumber);
				}
				return item;
			}
			else
			{
				T obj = new T();
				items.Add(obj);
				counter++;
				return obj;
			}
		}
		
	}

	public class TestPool
	{
		public int SerialNumber { get; set; }

		public TestPool()
		{
			Random rnd = new Random();
			SerialNumber = rnd.Next(1, 1000);
		}
	}

	public static class ObjectPoolTester
	{
		public static void ObjectPoolTest()
		{
			ObjectPool<TestPool> objPool = new ObjectPool<TestPool>();
			var testPoolObjects = new List<TestPool>
			{
				new TestPool(),
				new TestPool(),
				new TestPool(),
				new TestPool(),
				new TestPool(),
				new TestPool(),
			};
			foreach(var item in testPoolObjects)
			{
				objPool.Get(item);
			}

			objPool.Release(testPoolObjects[0]);
			objPool.Release(testPoolObjects[3]);
			objPool.Release(testPoolObjects[4]);

			Console.Read();
		}
	}


}
