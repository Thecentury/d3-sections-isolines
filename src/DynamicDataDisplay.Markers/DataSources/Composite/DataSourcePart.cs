namespace DynamicDataDisplay.Markers.DataSources
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public sealed class DataSourcePart
	{
		public DataSourcePart(IEnumerable collection, string propertyName)
		{
			if (collection == null)
				throw new ArgumentNullException("collection");
			if (String.IsNullOrEmpty(propertyName))
				throw new ArgumentNullException("propertyName");

			this.collection = collection;
			this.propertyName = propertyName;

			Type[] types = IEnumerableHelper.GetGenericInterfaceArgumentTypes(collection, typeof(IEnumerable<>));
			propertyType = (types != null && types.Length == 1) ? types[0] : typeof(Object);
		}

		private readonly string propertyName;
		public string PropertyName => propertyName;

		private readonly IEnumerable collection;
		public IEnumerable Collection => collection;

		private readonly Type propertyType;
		public Type PropertyType => propertyType;
	}
}
