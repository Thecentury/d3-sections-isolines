namespace Microsoft.Research.DynamicDataDisplay
{
	using System;

	public static class DataDomains
	{
		private static readonly DataRect xPositive = DataRect.FromPoints(Double.Epsilon, Double.MinValue / 2, Double.MaxValue, Double.MaxValue / 2);
		public static DataRect XPositive => xPositive;

		private static readonly DataRect yPositive = DataRect.FromPoints(Double.MinValue / 2, Double.Epsilon, Double.MaxValue / 2, Double.MaxValue);
		public static DataRect YPositive => yPositive;

		private static readonly DataRect xyPositive = DataRect.FromPoints(Double.Epsilon, Double.Epsilon, Double.MaxValue, Double.MaxValue);
		public static DataRect XYPositive => xyPositive;
	}
}
