namespace DynamicDataDisplay.Markers.DataSources
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class GenericIListDataSource<T> : PointDataSourceBase
	{
		public GenericIListDataSource(IList<T> collection)
		{
			if (collection == null)
				throw new ArgumentNullException("collection");

			this.collection = collection;
			TrySubscribeOnCollectionChanged(collection);
		}

		private readonly IList<T> collection;

		public IList<T> Collection => collection;

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
			return typeof(T);
		}
	}
}
