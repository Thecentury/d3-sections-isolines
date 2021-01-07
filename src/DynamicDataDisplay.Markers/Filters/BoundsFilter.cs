namespace Microsoft.Research.DynamicDataDisplay.Filters
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Charts.Filters;

	public class BoundsFilter : PointsFilter2d
	{
		protected internal override IEnumerable<IndexWrapper<Point>> Filter(IEnumerable<IndexWrapper<Point>> series)
		{
			var visible = this.Environment.Plotter.Viewport.Visible;
			var increasedVisible = visible.ZoomOutFromCenter(2.0);

			return series.Where(wrapper => increasedVisible.Contains(wrapper.Data));
		}
	}
}
