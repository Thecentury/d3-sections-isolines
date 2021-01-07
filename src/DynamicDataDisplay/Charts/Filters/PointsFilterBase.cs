namespace Microsoft.Research.DynamicDataDisplay.Charts.Filters
{
	using System;
	using System.Collections.Generic;
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Filters;

	public abstract class PointsFilterBase : IPointsFilter
	{
		#region IPointsFilter Members

		public abstract List<Point> Filter(List<Point> points);

		public virtual void SetScreenRect(Rect screenRect) { }

		protected void RaiseChanged()
		{
			Changed.Raise(this);
		}
		public event EventHandler Changed;

		#endregion
	}
}
