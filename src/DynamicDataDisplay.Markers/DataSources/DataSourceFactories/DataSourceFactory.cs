namespace DynamicDataDisplay.Markers.DataSources.DataSourceFactories
{
	public abstract class DataSourceFactory
	{
		public abstract PointDataSourceBase TryBuild(object data);
	}
}
