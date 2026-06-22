namespace DoublyLinkedListImplementation
{
	class ListNode
	{
		public int _value;
		public ListNode _next;
		public ListNode _prev;
		public ListNode(int value)
		{
			_value= value;
			_next = null;
			_prev = null;
		}
	}
	class DoublyLinkedList
	{
		private ListNode _head;
		private ListNode _tail;
		public DoublyLinkedList()
		{
			_head = new ListNode(-1);
			_tail = _head;
		}

		public void InsertAtTail(int val)
		{
			ListNode newNode = new ListNode(val);
			newNode._prev = _tail;
			_tail._next = newNode;
			_tail = newNode;
		}

		public void InsertAtHead(int val)
		{
			ListNode newNode = new ListNode(val);
			newNode._prev = _head;
			if (_head._next == null)
			{
				_tail = newNode;
			}
			newNode._next = _head._next;
			_head._next= newNode;
		}

		public void RemoveAt(int index)
		{
			int i =0;
			ListNode node = _head;
			while (node._next != null && i < index)
			{
				node = node._next;
				i++;
			}
			node._next._prev = null;
			node._next._next._prev = node;
			node._next = node._next._next;
			node._next._next = null;
		}

		public int GetAt(int index)
		{
			int i = 0;
			ListNode node = _head;
			while(node != null && i<=index)
			{
				node = node._next;
				i++;
			}
			Console.WriteLine(node._value);
			return node._value;
		}

		public List<int> GetValues() 
		{
			ListNode node = _head._next;
			List<int> values = new List<int>();
			while(node != null)
			{
				values.Add(node._value);
				Console.WriteLine(node._value);
				node = node._next;
			}
			return values;
		}
	}
	class Program
	{ 
		static void Main(string[] args)
		{
			DoublyLinkedList doublyLinkedList = new DoublyLinkedList();
			doublyLinkedList.InsertAtTail(0);
			doublyLinkedList.InsertAtTail(1);
			doublyLinkedList.InsertAtTail(2);
			doublyLinkedList.InsertAtTail(3);
			doublyLinkedList.GetValues();
			doublyLinkedList.InsertAtHead(5);
			doublyLinkedList.GetValues();
			doublyLinkedList.RemoveAt(1);
			doublyLinkedList.GetAt(1);
		}
	}

}