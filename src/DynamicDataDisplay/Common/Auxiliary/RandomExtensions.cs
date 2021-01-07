namespace Microsoft.Research.DynamicDataDisplay.Common
{
	using System;
	using System.Windows;

	internal static class RandomExtensions
	{
		public static Point NextPoint(this Random rnd)
		{
			return new Point(rnd.NextDouble(), rnd.NextDouble());
		}

		public static Point NextPoint(this Random rnd, double xMin, double xMax, double yMin, double yMax)
		{
			double x = rnd.NextDouble() * (xMax - xMin) + xMin;
			double y = rnd.NextDouble() * (yMax - yMin) + yMin;
			return new Point(x, y);
		}

		public static Vector NextVector(this Random rnd)
		{
			return new Vector(rnd.NextDouble(), rnd.NextDouble());
		}
	}
}
