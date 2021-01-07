namespace DynamicDataDisplay.Markers.DataSources.DataSourceFactories
{
	using System;
	using System.Collections.ObjectModel;

	public sealed class DataSourceFactoryStore
	{
		private DataSourceFactoryStore()
		{
			RegisterFactory(new DataSourceDataSourceFactory());
			RegisterFactory(new PointArrayFactory());
			RegisterFactory(new IEnumerablePointFactory());
			RegisterFactory(new GenericIListFactory());
			RegisterFactory(new GenericIEnumerableFactory());
			RegisterFactory(new GenericIDataSource2DFactory());
			RegisterFactory(new XmlElementFactory());
		}

		private static DataSourceFactoryStore current = new DataSourceFactoryStore();
		public static DataSourceFactoryStore Current => current;

		private readonly ObservableCollection<DataSourceFactory> factories = new ObservableCollection<DataSourceFactory>();
		public ObservableCollection<DataSourceFactory> Factories => factories;

		public void RegisterFactory(DataSourceFactory factory)
		{
			if (factory == null)
				throw new ArgumentNullException("factory");

			factories.Add(factory);
		}

		public PointDataSourceBase BuildDataSource(object data)
		{
			if (data == null)
				throw new ArgumentNullException("data");

			foreach (var factory in factories)
			{
				var result = factory.TryBuild(data);
				if (result != null)
					return result;
			}

			return null;
		}
	}
}
