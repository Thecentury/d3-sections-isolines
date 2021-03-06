﻿namespace DynamicDataDisplay.Markers.DataSources.DataSourceFactories
{
	using System;
	using System.Collections.Generic;

	public class GenericIEnumerableFactory : DataSourceFactory
	{
		public override PointDataSourceBase TryBuild(object data)
		{
			var types = IEnumerableHelper.GetGenericInterfaceArgumentTypes(data, typeof(IEnumerable<>));
			if (types != null && types.Length == 1)
			{
				Type genericIEnumerableType = typeof(GenericIEnumerableDataSource<>).MakeGenericType(types);
				var result = Activator.CreateInstance(genericIEnumerableType, data);
				var dataSource = (PointDataSourceBase)result;
				return dataSource;
			}

			return null;
		}
	}
}
