using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
	public static partial class Graph
	{
		public class FloydWarshall
		{
			int[,] next;
			int[,] distances;
			public bool HasNegativeCycle { get; private set; }

			public FloydWarshall(int[] edges, int[] weights)
			{
				if (edges.Length != 2 * weights.Length)
					throw new ArgumentException("edges.Length != 2 * weights.Length");
				var n = 0;
				for (var i = 0; i < edges.Length; ++i)
					if (n < edges[i])
						n = edges[i];
				if (edges.Length > 0)
					++n;
				next = new int[n, n];
				distances = new int[n, n];
				for (var i = 0; i < n; ++i)
					for (var j = 0; j < n; ++j)
					{
						next[i, j] = -1;
						distances[i, j] = int.MaxValue;
					}
				for (var i = 0; i < edges.Length; i += 2)
				{
					next[edges[i], edges[i + 1]] = edges[i + 1];
					distances[edges[i], edges[i + 1]] = weights[i / 2];
				}
				for (var i = 0; i < n; ++i)
					if (distances[i, i] > 0)
					{
						next[i, i] = i;
						distances[i, i] = 0;
					}
				for (var p = 0; p < n; ++p)
					for (var i = 0; i < n; ++i)
					{
						if (next[i, p] != -1)
							for (var j = 0; j < n; ++j)
								if (next[p, j] != -1 && distances[i, j] > checked(distances[i, p] + distances[p, j]))
								{
									next[i, j] = next[i, p];
									distances[i, j] = distances[i, p] + distances[p, j];
								}
						if (distances[i, i] < 0)
						{
							HasNegativeCycle = true;
							return;
						}
					}
			}

			public int GetDistance(int u, int v)
			{
				if (HasNegativeCycle)
					throw new InvalidOperationException("There is a negative cycle.");
				return distances[u, v];
			}

			public bool HasPath(int u, int v)
			{
				return next[u, v] != -1;
			}

			public IEnumerable<int> GetPath(int u, int v)
			{
				if (HasNegativeCycle)
					throw new InvalidOperationException("There is a negative cycle.");
				if (next[u, v] != -1)
				{
					yield return u;
					while (u != v)
					{
						u = next[u, v];
						yield return u;
					}
				}
			}
		}
	}
}
