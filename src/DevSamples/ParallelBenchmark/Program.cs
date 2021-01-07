namespace ParallelBenchmark
{
	using System;
	using Microsoft.Research.DynamicDataDisplay.Common.Auxiliary;

	class Program
	{
		static void Main(string[] args)
		{
			Func<int, int, double> func = ((ix, iy) => ix * iy);

			const int width = 1000;
			const int height = 1000;

			using (new DisposableTimer("sequential #1"))
			{
				var grid = func.ToGrid(width, height);
			}

			using (new DisposableTimer("sequential #2"))
			{
				var grid = func.ToGrid(width, height);
			}


			Console.ReadLine();
		}
	}
}
