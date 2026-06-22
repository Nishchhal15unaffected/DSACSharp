namespace StackImplementation
{
	public class Stack
	{
		List<int> list;
		public Stack() { list = new List<int>(); }
		public void push(int x) { list.Add(x);}
		public int pop()
		{
			if(list.Count == 0)
			{
				throw new InvalidOperationException("Stack is empty.");
			}
			int result = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
			return result;
		}

		public int Peek()
		{
			return list[list.Count-1];
		}
	}

	public class program
	{
		static void Main(string[] args)
		{
			Stack stack = new Stack();
			stack.push(1);
			stack.push(2);
			stack.push(3);
			stack.push(4);
			int peekValue = stack.Peek();
			Console.WriteLine(peekValue);
			Console.WriteLine(stack.pop());
			Console.WriteLine(stack.pop());
			Console.WriteLine(stack.Peek());
		}
	}
}