namespace ArrayDSA
{
	class ArrayOperations
	{
		static void Main()
		{
			int capacity = 6;
			int length = 0;
			int[] array = new int[capacity];
			insert(array,2,0, length++, capacity);
			insert(array,1,1, length++,capacity);
			insert(array,5,2,length++,capacity);
			insert(array,8,3,length++,capacity);
			insert(array,1,4,length++,capacity);
			printArray(array,length);

			InsertAtMiddle(array,18,1, length++,capacity);
			printArray(array,length);

			RemoveAtMiddle(array, 1, length--,capacity);
			printArray(array, length);

			RemoveEnd(array, length--,capacity);
			printArray(array, length);
		}
		private static void RemoveEnd(int[] array, int length, int capacity)
		{
			if (length <= capacity)
			{
				array[length - 1] = 0;
			}
		}
		private static void RemoveAtMiddle(int [] array, int index, int length, int capacity)
		{
			if (length <= capacity)
			{
				for (int i = index; i < length - 1; i++)
				{
					array[i] = array[i + 1];
				}
				array[length - 1] = 0;
			}
		}

		//insert middle
		private static void InsertAtMiddle(int[] array, int value, int index, int length, int capacity)
		{
			if(length <= capacity)
			{
				for (int i = length - 1; i >= index; i--)
				{
					array[i + 1] = array[i];
				}
				array[index] = value;
			}
		}

		private static void printArray(int[] array, int capacity)
		{
			foreach (int i in array)
			{
				Console.WriteLine(i);
			}
			Console.ReadLine();
		}

		//Insert at end
		private static void insert(int[] array, int value, int index, int length, int capacity)
		{
			if (length <= capacity)
			{
				array[index] = value;
			}
		}
	}
}