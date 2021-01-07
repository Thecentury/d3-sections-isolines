﻿namespace Microsoft.Research.DynamicDataDisplay
{
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Charts;

	public static class RangeExtensions
	{
		public static double GetLength(this Range<Point> range)
		{
			Point p1 = range.Min;
			Point p2 = range.Max;

			return (p1 - p2).Length;
		}

		public static double GetLength(this Range<double> range)
		{
			return range.Max - range.Min;
		}
	}
}
