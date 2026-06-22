namespace LinkedListImplementation
{
	class ListNode
	{
		public int _val;
		public ListNode _address;
		public ListNode(int val)
		{
			_val = val;
			_address = null;
		}
		public ListNode(int val, ListNode address) { 
		_val = val;
		_address = address;
		}
	}

	public class LinkedListImp
	{
		private ListNode head;
		private ListNode tail;
		public LinkedListImp()
		{
			head = new ListNode(-1);
			tail = this.head;
		}

		public void InsertAtHead(int val)
		{
			ListNode listNode = new ListNode(val);
			listNode._address = head._address;
			head._address = listNode;
			if (listNode._address == null)
			{
				tail = listNode;
			}
		}

		public void InsertAtTail(int val)
		{
			ListNode listNode = new ListNode(val);
			tail._address= listNode;
			tail = listNode;
		}
		public bool RemoveAt(int index)
		{
			int i = 0;
			ListNode node = head;
			// loop till prev to index
			while (i < index && node != null)
			{
				node = node._address;
				i++;
			}
			if (node!= null && node._address != null)
			{
				node._address = node._address._address;
				if (node._address == null) { 
				tail = node;}
				return true;
			}
			return false;
		}

		public int Get(int index)
		{
			int i = 0;
			ListNode node = head;
			while(i<=index && node != null)
			{
				node = node._address; i++;
			}
			Console.WriteLine(node._val.ToString());
			return node._val;
		}
		
		public List<int> GetValues()
		{
			ListNode node = head._address;
			List<int> values = new List<int>();
			while (node != null)
			{
				values.Add(node._val);
				Console.WriteLine(node._val.ToString());
				node = node._address;
			}
			return values;
		}
	}

	class program 
	{ 
		static void Main(string[] args)
		{
			LinkedListImp list = new LinkedListImp();
			list.InsertAtHead(0);
			list.InsertAtTail(0);
			list.InsertAtTail(1);
			list.InsertAtTail(2);
			list.InsertAtTail(3);
			list.InsertAtTail(4);
			list.GetValues();
			list.InsertAtHead(5);
			list.GetValues();
			list.RemoveAt(1);
			list.GetValues();
			list.Get(0);
		}
	}

}