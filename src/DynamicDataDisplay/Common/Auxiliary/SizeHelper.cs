namespace Microsoft.Research.DynamicDataDisplay.Common.Auxiliary
{
	using System;
	using System.Windows;

	internal static class SizeHelper
	{
		public static Size CreateInfiniteSize()
		{
			return new Size(Double.PositiveInfinity, Double.PositiveInfinity);
		}
	}
}
