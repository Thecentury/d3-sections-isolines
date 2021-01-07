namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields.StreamLine2D.Filters
{
	using System.Collections.Generic;
	using System.Windows;

	public abstract class FilterBase
	{
		public abstract IEnumerable<Point> Filter(IEnumerable<Point> points);
	}
}
