﻿using System;
using System.Collections.Generic;

namespace TestingCSharp
{
	public class DFSAlgorithm
	{
		public HashSet<T> DFS<T>(Graph<T> graph, T start)
		{
			var visited = new HashSet<T>();

			if (!graph.AdjacencyList.ContainsKey(start))
			{
				return visited;
			}

			var stack = new Stack<T>();
			stack.Push(start);

			while (stack.Count > 0)
			{
				var vertex = stack.Pop();

				if (visited.Contains(vertex))
				{
					continue;
				}

				visited.Add(vertex);

				foreach (var neighbor in graph.AdjacencyList[vertex])
				{
					if (!visited.Contains(neighbor))
					{
						stack.Push(neighbor);
					}
				}
			}

			return visited;
		}
	}

	public static class TestDFS
	{
		public static void Test()
		{
			var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			var edges = new[] {
				Tuple.Create(1,2), Tuple.Create(1,3),
				Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
				Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
				Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)
			};

			var graph = new Graph<int>(vertices, edges);
			var algorithms = new DFSAlgorithm();

			Console.WriteLine(string.Join(", ", algorithms.DFS(graph, 1)));
			// # 1, 3, 6, 5, 8, 9, 10, 7, 4, 2
		}
	}

}
