namespace Microsoft.Research.DynamicDataDisplay.DataSources
{
	using System.Collections.Generic;
	using System.Windows;

	public sealed class RawDataSource : EnumerableDataSourceBase<Point> {
		public RawDataSource(params Point[] data) : base(data) { }
		public RawDataSource(IEnumerable<Point> data) : base(data) { }

		public override IPointEnumerator GetEnumerator(DependencyObject context) {
			return new RawPointEnumerator(this);
		}
	}
}
