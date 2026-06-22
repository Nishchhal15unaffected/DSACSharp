namespace Sorting
{
	public class AllSorting
	{
		// left side sort array,
		// start from second position and compare prev until found smaller
		public void InsertionSort(int [] array)
		{
			int i = 1;
			while (i<array.Length)
			{
				int j = i-1;
				while(j>=0 && array[j] > array[j+1])
				{
					int temp = array[j];
					array[j] = array[j+1];
					array[j+1] = temp;
					j--;
				}
				i++;
			}
		}

		// divide array till 1 element 
		// merge both the sorted array as both have 1 value and they are sorted
		public int[] MergeSort(int[] array, int s, int e)
		{
			if ((e-s)+1 <= 1)
			{
				return array;
			}
			int m = (s + e) / 2;
			MergeSort(array, s, m);
			MergeSort(array, m+1,e);
			MergeArray(array,s,m,e);
			return array;
		}

		private void MergeArray(int[] array, int s, int m, int e)
		{
			int[] left= new int[(m-s)+1];
			int[] right= new int[e-m];
			Array.Copy(array,s,left,0, (m - s) + 1);
			Array.Copy(array,m+1,right,0,e-m);
			int i = 0;
			int j = 0;
			int k = s;
			while(i<left.Length && j< right.Length)
			{
				if (left[i] <= right[j]) 
				{
					array[k] = left[i++];
				}
				else
				{
					array[k] = right[j++];
				}
				k++;
			}

			while(i<left.Length)
			{
				array[k] = left[i++];
			}

			while (i < right.Length)
			{
				array[k] = right[i++];
			}
		}

		public int[] Quicksort(int[] array,int s, int e)
		{
			if ((e-s)+1<=1)
			{
				return array;
			}

			int pivotIndex = Partision(array,s, e);
			Quicksort(array,s,pivotIndex-1);
			Quicksort(array,pivotIndex+1,e);
			return array;
		}

		private int Partision(int[] array,int s, int e)
		{
			int pivot = array[e];
			int left = s;
			for (int i = s; i< e; i++)
			{
				if (array[i]<pivot)
				{
					Swap(array, i, left++);
				}
			}
			array[e] = array[left];
			array[left] = pivot;
			return left;
		}

		private void Swap(int[] array, int i , int left)
		{
			int temp  = array[i];
			array[i] = array[left];
			array[left] = temp;
		}

		public void BucketSort(int[] array, int length)
		{
			int[] rangeArray = new int[length];
			for (int i =0; i<array.Length; i++)
			{
				rangeArray[array[i]]++;
			}
			int k = 0;
			for (int i = 0; i < rangeArray.Length; i++)
			{
				int j = 0;
				while (j < rangeArray[i] )
				{
					array[k] = i;
					k++;
					j++;
				}
			}
		}
	}

	public class Program
	{
		static void Main(string[] args)
		{
			int[] array = new int[] { 56,1,2,7,1,5};
			int[] array1 = new int[] { 56,1,2,7,1,5};
			int[] array2 = new int[] { 56,1,2,7,1,5};
			int[] array3 = new int[] { 0,1,2,2,0,1};
			
			AllSorting allSorting = new AllSorting();
			allSorting.InsertionSort(array);
			foreach(int i in array)
			{
				Console.WriteLine(i);
			}
			allSorting.MergeSort(array1,0,array1.Length-1);
			foreach (int i in array1)
			{
				Console.WriteLine(i);
			}
			allSorting.Quicksort(array2,0,array2.Length-1);
			foreach(int i in array2)
			{
				Console.WriteLine(i);
			}
			allSorting.BucketSort(array3, 3);
			foreach(int i in array3)
			{
				Console.WriteLine(i);
			}
		}
	}
}