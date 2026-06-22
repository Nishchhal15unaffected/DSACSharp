namespace BinarySearchTree
{
	public class TreeNode
	{
		public TreeNode left, right;
		public int _val;
		public TreeNode(int val)
		{
			_val = val;
			left = null;
			right = null;
		}
	}
	public class BST
	{
		// root
		// val
		// return TreeNode
		public TreeNode Insert(TreeNode root, int val)
		{
			if (root == null)
			{
				new TreeNode(val);
			}
			if (root._val < val)
			{
				root.right = Insert(root.right, val);
			}
			else if (root._val > val)
			{
				root.left = Insert(root.left, val);
			}
			return root;
		}

		// root
		// value
		// return true if found else false
		public bool Search(TreeNode root, int val)
		{
			if (root == null)
			{
				return false;
			}
			if (root._val < val)
			{
				return Search(root.right, val);
			}
			else if (root._val > val)
			{
				return Search(root.left, val);
			}
			else
			{
				return true;
			}
		}

		public TreeNode Remove(TreeNode root, int val)
		{
			if (root == null)
			{
				return null;
			}

			if (root._val < val)
			{
				root.right = Remove(root.right, val);
			}
			else if (root._val > val)
			{
				root.left = Remove(root.left, val);
			}
			else
			{
				if (root.left == null)
				{
					return root.right;
				}
				else if (root.right == null)
				{
					return root.left;
				}
				else
				{
					var minNode = MinValueNode(root);
					root._val = minNode._val;
					root.right = Remove(root.right, minNode._val);
				}
			}
			return root;
		}

		private TreeNode MinValueNode(TreeNode root)
		{
			var curr = root;
			while (curr != null && curr.left != null)
			{
				curr = curr.left;
			}
			return curr;
		}
		// DFS Implementation
		public void InOrder(TreeNode root)
		{
			if (root == null)
			{
				return;
			}
			InOrder(root.left);
			Console.WriteLine(root._val);
			InOrder(root.right);
		}
		public void PreOrder(TreeNode root)
		{
			if(root == null)
			{ return; }

			Console.WriteLine(root._val);
			PreOrder(root.left);
			PreOrder(root.right);
		}

		public void PostOrder(TreeNode root)
		{
			if (root == null)
			{
				return;
			}
			PostOrder(root.left);
			PostOrder(root.right);
			Console.WriteLine(root._val);
		}

		//BFS Implementation
		public void BFSImp(TreeNode root)
		{
			Queue<TreeNode> queue = new Queue<TreeNode>();
			var level = 1;
			if (root != null)
			{
				queue.Enqueue(root);
			}
			while (queue.Count > 0)
			{
				Console.WriteLine($"Level: {level}");
				var levelCount = queue.Count;
				for(int i=0; i< levelCount; i++)
				{
					var levelElm = queue.Dequeue();
					Console.WriteLine();
					if (levelElm.right != null)
					{
						queue.Enqueue(levelElm.right);
					}
					if (levelElm.left != null)
					{
						queue.Enqueue(levelElm.left);
					}
				}
				level++;
			}
		}
	}
}