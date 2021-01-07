namespace Microsoft.Research.DynamicDataDisplay.Charts.Filters
{
	using System;
	using System.Collections.Generic;
	using System.Collections.Specialized;
	using System.Windows;
	using global::DynamicDataDisplay.Markers.DataSources;
	using Microsoft.Research.DynamicDataDisplay.Common;
	using Microsoft.Research.DynamicDataDisplay.Filters;

	public sealed class NewFilterCollection : D3Collection<PointsFilter2d>, IDisposable
	{
		protected override void OnItemAdding(PointsFilter2d item)
		{
			if (item == null)
				throw new ArgumentNullException("item");
		}

		protected override void OnItemAdded(PointsFilter2d item)
		{
			item.Changed += OnItemChanged;
		}

		private void OnItemChanged(object sender, EventArgs e)
		{
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		protected override void OnItemRemoving(PointsFilter2d item)
		{
			item.Changed -= OnItemChanged;
		}

		internal IEnumerable<IndexWrapper<Point>> Filter(IEnumerable<IndexWrapper<Point>> points, IDataSourceEnvironment environment)
		{
			foreach (var filter in Items)
			{
				filter.Environment = environment;
				points = filter.Filter(points);
			}

			return points;
		}

		#region IDisposable Members

		public void Dispose()
		{
			foreach (var filter in this)
			{
				filter.Dispose();
			}
		}

		#endregion
	}
}
