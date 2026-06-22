namespace Graphs
{
	public class AdjacencyList
	{
		public Dictionary<string,List<string>> CreateAdjacencyList(string[][] list)
		{
			Dictionary<string, List<string>> adjacencyList = new Dictionary<string, List<string>>();
			foreach (var i in list)
			{
				if (!adjacencyList.ContainsKey(i[0]))
				{
					adjacencyList[i[0]] = new List<string>();
				}
				else if (!adjacencyList.ContainsKey(i[1]))
				{
					adjacencyList[i[1]] = new List<string>();
				}
				adjacencyList[i[0]].Add(i[1]);
			}
			return adjacencyList;
		}
	}
	public class GraphDFS
	{
		//when recursion will free memory for node that time node will be marked as non visit
		public int NoOfPath(int[][] matrix, int r, int c, HashSet<(int,int)> visited)
		{
			int Row = matrix.Length;
			int Col = matrix[0].Length;
			if (Math.Min(r,c)<0 || Row == r || Col == c || visited.Contains((r,c)) || matrix[r][c] == 1)
			{
				return 0;
			}
			if (r == Row-1 && c == Col-1)
			{
				return 1;
			}
			visited.Add((r,c));

			int count = 0;
			count += NoOfPath(matrix, r + 1, c, visited);
			count += NoOfPath(matrix, r - 1, c, visited);
			count += NoOfPath(matrix, r, c+1, visited);
			count += NoOfPath(matrix, r, c-1, visited);

			visited.Remove((r,c));
			return count;
		}

		public int NoOfPathAdjacency(string node, string target,Dictionary<string,List<string>> adjacecnyList,HashSet<string> visited)
		{
			if(visited.Contains(node))
			{
				return 0;
			}
			if ( node == target)
			{
				return 1;
			}
			int count = 0;
			visited.Add(node);
			foreach(var c in adjacecnyList[node]) 
			{
				count += NoOfPathAdjacency(c, target, adjacecnyList, visited);
			}
			visited.Remove(node);
			return count;
		}
	}

	class GraphBFS
	{
		//matrix bfs
		// queue gives direction in which direction we have to go, visited help us to restrict from visiting twise
		// first loop alows to go till end
		// second loop run for each child of prev vertices(node)
		//if this node is at last or we reach last position we return the total length of path
		// third loop run for each direction left right down up and see is the path correct in the direction
		// if correct then we add to queue so next time when loop execute it go in this node direction as well
		// length we are mantaining through adding each time 1 when we take step
		// first we add the node into queue and during second thrid loop workflow we remove from queue
		public int ShortestPath(int[][] grid)
		{
			int Row = grid.Length;
			int Col = grid[0].Length;
			Queue<(int,int)> queue = new Queue<(int,int)>();
			queue.Append((0, 0));
			HashSet<(int,int)> visited = new HashSet<(int,int)>();
			int length = 0;
			while(queue.Count > 0 )
			{
				int size = queue.Count;
				for (int i = 0; i < size; i++)
				{
					(int r,int c) = queue.Dequeue();
					if (r == Row-1 && c == Col-1)
					{
						return length;
					}
					HashSet<(int, int)> direction = new HashSet<(int, int)>() {(0,1),(0,-1),(1,0),(-1,0) };
					foreach((var dr,var dc) in direction)
					{
						if (Math.Min(r+dr,c+dc)<0 || r+dr == Row || c+dc == Col || visited.Contains((r,c)) || grid[r][c] == 1)
						{
							continue;
						}
						queue.Enqueue((r,c));
						visited.Add((r,c));
					}
				}
				length++;
			}
			return length;
		}

		public int ShortestPathAdjacencyList(Dictionary<string,List<string>> adjacencyList, string target, string node)
		{
			int length = 0;
			Queue<string> queue = new Queue<string>();
			HashSet<string> visited = new HashSet<string>();
			visited.Add(node);
			queue.Enqueue(node);
			while(queue.Count > 0 )
			{
				int len = queue.Count;
				for (int i = 0; i < len; i++)
				{
					string nod = queue.Dequeue();

					if (nod == target)
					{
						return length;
					}
					
					foreach (var n in adjacencyList[node])
					{
						if (!visited.Contains(n))
						{
							queue.Enqueue(n);
							visited.Add(n);
						}
					}
				}
				length++;
			}

			return length;
		}
	}
}