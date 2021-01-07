namespace Microsoft.Research.DynamicDataDisplay.DataSources
{
	using System.Collections.Generic;

	internal sealed class EnumerableYDataSource<T> : EnumerableDataSource<T>
	{
		public EnumerableYDataSource(IEnumerable<T> data) : base(data) { }
	}
}
