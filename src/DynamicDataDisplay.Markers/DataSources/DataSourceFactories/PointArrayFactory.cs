namespace DynamicDataDisplay.Markers.DataSources.DataSourceFactories
{
	using System.Windows;

	public sealed class PointArrayFactory : DataSourceFactory
	{
		public override PointDataSourceBase TryBuild(object data)
		{
			Point[] array = data as Point[];
			if (array != null)
			{
				var dataSource = new PointArrayDataSource(array);
			}

			return null;
		}
	}
}
