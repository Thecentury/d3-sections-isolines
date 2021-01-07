namespace DynamicDataDisplay.Markers.DataSources.DataSourceFactories
{
	using System.Xml;

	public class XmlElementFactory : DataSourceFactory
	{
		public override PointDataSourceBase TryBuild(object data)
		{
			XmlElement xmlElement = data as XmlElement;
			if (xmlElement != null)
			{
				var dataSource = new XmlElementDataSource(xmlElement);
				return dataSource;
			}

			return null;
		}
	}
}
