namespace Recursion
{
	public class RecursionQue
	{
		// Factorial
		public int OneBranchRecursion(int n)
		{
			if (n <= 1)
			{
				return 1;
			}
			return n * OneBranchRecursion(n - 1);
		}

		// Fibonacchi
		public int TwoBranchesRecursion(int n)
		{
			if (n <= 1)
			{
				return n;
			}
			return TwoBranchesRecursion(n - 1) + TwoBranchesRecursion(n-2);
		}
	}

	public class Program
	{
		static void Main(string[] args)
		{
			int n = 5;
			RecursionQue recursionQue = new RecursionQue();
			Console.WriteLine(recursionQue.OneBranchRecursion(n));
			Console.WriteLine(recursionQue.TwoBranchesRecursion(n));
		}
	}
}
