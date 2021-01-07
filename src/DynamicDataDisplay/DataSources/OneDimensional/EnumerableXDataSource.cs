namespace Microsoft.Research.DynamicDataDisplay.DataSources
{
	using System.Collections.Generic;

	internal sealed class EnumerableXDataSource<T> : EnumerableDataSource<T>
	{
		public EnumerableXDataSource(IEnumerable<T> data) : base(data) { }
	}
}
