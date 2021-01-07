namespace DynamicDataDisplay.Markers.DataSources.DataSourceFactories
{
	using System.Collections.Generic;
	using System.Windows;

	public class IEnumerablePointFactory : DataSourceFactory
	{
		public override PointDataSourceBase TryBuild(object data)
		{
			IEnumerable<Point> collection = data as IEnumerable<Point>;
			if (collection != null)
			{
				var dataSource = new EnumerablePointDataSource(collection);
				return dataSource;
			}

			return null;
		}
	}
}
