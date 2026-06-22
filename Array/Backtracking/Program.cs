namespace backtracking
{
	public class Node
	{
		public int _value;
		public Node _right;
		public Node _left; 
		public Node(int value)
		{
			_value = value;
		}
	}
	public class TreeMaze
	{
		List<int> path = new List<int>();
		// print the path till leaf node , where 0 not exits
		// travel through the path if 0 exits or node is null (its parent is not leaf node bcz it have left or right node)
		// return false otherwise add value to the list and check if this is leaf node if yes the return true
		// on traversal we are adding and if it return false means wrong path for node from both the left and right side
		// means this is not valid  remove node from list mean undo and explore different path
		public bool TreeMazePrint (Node node)
		{
			if (node != null || node._value== 0)
			{
				return false;
			}
			path.Add(node._value);
			if (node._right == null && node._left == null) 
			{ 
				return true;
			}
			if (TreeMazePrint(node._right))
			{
				return true;
			}
			if (TreeMazePrint(node._left))
			{
				return true;
			}
			path.RemoveAt(path.Count-1);
			return false;
		}

	}

}