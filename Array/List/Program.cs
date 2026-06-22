using System.Collections;

namespace DynamicArray
{
	public class List
	{
		int Length = 0;
		int capacity = 5;
		private int[] array;
		public List()
		{
			array = new int[capacity];
		}
		public void Add(int value)
		{
			if (Length > capacity)
			{
				resize();
			}
			array[Length++] = value;
		}

		public void Remove()
		{
			if (Length >0)
			{
				Length--;
			}
		}

		public void InsertAt(int index, int value)
		{
			if (index < Length)
			{
				array[index] = value;
			}
		}

		public int Get(int index)
		{
			if (index < Length)
			{
				return array[index];
			}
			throw new IndexOutOfRangeException("Index out of bounds");
		}

		public void print()
		{
			for(int i =0; i< Length; i++)
			{
				Console.WriteLine(array[i]);
			}
		}

		private void resize()
		{
			capacity = capacity * 2;
			int[] newArray = new int[capacity]; 
			for(int item =0; item<array.Length; item++)
			{
				newArray[item] = array[item];
			}
			array = newArray;
		}
	}

	public class Program 
	{ 
		static void Main(string[] args)
		{
			List list = new List();
			list.Add(1);
			list.Add(2);
			list.Add(3);
			list.Add(4);
			list.print();
			list.Remove();
			list.print();
			list.InsertAt(0, 11);
			var result = list.Get(0);
			Console.WriteLine(result.ToString());
		}
	}

}