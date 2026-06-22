namespace DynamicPrograming
{
	public class OneDDP
	{
		//Fibonacci by recursion
		public int FibByRecursion (int n)
		{
			if (n<=1)
			{
				return n;
			}
			int fib = FibByRecursion(n - 1) + FibByRecursion(n - 2);
			return fib;
		}

		// fib by top down
		public int FibByTopDow(int n, int[] cache)
		{
			if (n>=1)
			{
				return n;
			}
			cache[n]= FibByTopDow(n - 1,cache) + FibByTopDow(n - 2,cache);
			return cache[n];
		}

		// fib by bottom up
		public int FibByBottomUp(int n)
		{
			int[] cache = { 0, 1 };
			int i = 2;
			while (i<=n)
			{
				int temp = cache[1];
				cache[1] = cache[0] + cache[1];
				cache[0] = temp;
				i++;
			}
			return cache[1];
		}
	}

	public class TwoDDP
	{
		public int CountPathByMemiozation(int r, int c,int R, int C,int [][]cache)
		{
			if (r==R || c == C)
			{
				return 0;
			}
			if ( r== R-1 && c == C-1)
			{
				return 1;
			}
			cache[r][c] = CountPathByMemiozation(r + 1, c, R, C, cache) + CountPathByMemiozation(r, c + 1, R, C, cache);
			return cache[r][c];
		}

		public int CountPathByTabulation(int r, int c)
		{
			int[] prevRow = new int[c];
			for (int i = r - 1; i >= 0; i--)
			{
				int[] currRow = new int[c];
				currRow[c - 1] = 1;
				for(int j = c-2; j>=0; j--)
				{
					currRow[j] = currRow[j + 1] + prevRow[j];
				}
				prevRow = currRow;
			}
			return prevRow[0];
		}
	}
}