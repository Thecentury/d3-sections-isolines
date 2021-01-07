namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System.Collections.Specialized;

	public abstract class DataSourceUpdateHandler
	{
		public abstract void OnUpdate(NotifyCollectionChangedEventArgs e, PointChartBase chart);

		public virtual void OnPlotterAttached(Plotter2D plotter, PointChartBase chart) { }
		public virtual void OnPlotterDetached(Plotter2D plotter, PointChartBase chart) { }
	}
}
