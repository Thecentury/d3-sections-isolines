namespace Microsoft.Research.DynamicDataDisplay.Charts.Filters
{
	using System.Collections.Generic;
	using System.Windows;

	public sealed class EmptyFilter : PointsFilterBase
	{
		public override List<Point> Filter(List<Point> points)
		{
			return points;
		}
	}
}
