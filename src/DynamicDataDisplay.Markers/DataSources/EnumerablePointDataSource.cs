namespace DynamicDataDisplay.Markers.DataSources
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Filters;

	public class EnumerablePointDataSource : PointDataSourceBase
	{
		public EnumerablePointDataSource(IEnumerable<Point> collection)
		{
			if (collection == null)
				throw new ArgumentNullException("collection");

			this.collection = collection;
			TrySubscribeOnCollectionChanged(collection);
		}

		private readonly IEnumerable<Point> collection;
		public IEnumerable<Point> Collection => collection;

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
	}
}
