﻿namespace DynamicDataDisplay.Markers.DataSources
{
	using System;
	using System.Collections;

	public class EnumerableDataSource : PointDataSourceBase
	{
		public EnumerableDataSource(IEnumerable collection)
		{
			if (collection == null)
				throw new ArgumentNullException("collection");

			this.collection = collection;
			TrySubscribeOnCollectionChanged(collection);
		}

		private readonly IEnumerable collection;

		protected override IEnumerable GetDataCore()
		{
			return collection;
		}

		public override IEnumerable GetData(int startingIndex)
		{
			throw new NotImplementedException();
		}

		public override object GetDataType()
		{
			throw new NotImplementedException();
		}
	}
}
