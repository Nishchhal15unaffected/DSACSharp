namespace QueueImplementation
{
	class ListNode
	{
		public int _val;
		public ListNode _next;
		public ListNode(int val)
		{
			_val= val;
		}
	}

	class QueueImp
	{
		private ListNode left;
		private ListNode right;

		public QueueImp()
		{ 
			left= new ListNode(-1);
			right = left;
		}

		public void Enqueue(int val)
		{
			ListNode node = new ListNode(val);
			right._next = node;
			right = node;
		}

		public bool Dequeue()
		{
			if (left._next == null)
			{
				return false;
			}
			int val = left._next._val;
			left._next = left._next._next;
			if (left._next == null) 
			{ right = left; }
			return true;
		}

		public List<int> GetValue() 
		{
			ListNode listNode = left._next;
			List<int> list = new List<int>();
			while (listNode != null)
			{
				Console.WriteLine(listNode._val);
				list.Add(listNode._val);
				listNode = listNode._next;
			}
			return list;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			QueueImp queueImp = new QueueImp();
			queueImp.Enqueue(1);
			queueImp.Enqueue(2);
			queueImp.Enqueue(3);
			queueImp.Enqueue(4);
			queueImp.Enqueue(5);
			queueImp.GetValue();
			queueImp.Dequeue();
			queueImp.GetValue();
		}
	}
}