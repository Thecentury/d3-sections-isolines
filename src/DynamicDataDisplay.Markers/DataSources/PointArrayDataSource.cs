namespace DynamicDataDisplay.Markers.DataSources
{
	using System;
	using System.Collections;
	using System.Linq;
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Filters;

	public sealed class PointArrayDataSource : PointDataSourceBase
	{
		public PointArrayDataSource(Point[] collection)
		{
			if (collection == null)
				throw new ArgumentNullException("data");

			this.collection = collection;
		}

		private readonly Point[] collection;
		public Point[] Collection => collection;

		protected override IEnumerable GetDataCore()
		{
			return Filters.Filter(IndexWrapper.Generate(collection), Environment);
		}

		public override IEnumerable GetData(int startingIndex)
		{
			return collection.Skip(startingIndex);
		}

		public override object GetDataType()
		{
			return typeof(Point);
		}

		protected override void OnEnvironmentChanged()
		{
			base.OnEnvironmentChanged();
		}
	}
}
