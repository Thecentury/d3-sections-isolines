namespace Microsoft.Research.DynamicDataDisplay.DataSources.MultiDimensional
{
	using System;
	using System.Windows.Media.Media3D;

	public sealed class TransformedGridDataSource3D<T> : IDataSource3D<T>
	{
		private readonly IDataSource3D<T> child;
		private readonly TransformedGrid3D transformedGrid;
		public TransformedGridDataSource3D(IDataSource3D<T> child, Transform3D transform)
		{
			if (child == null)
				throw new ArgumentNullException("child");
			if (transform == null)
				throw new ArgumentNullException("transform");

			this.child = child;
			this.transformedGrid = new TransformedGrid3D(child.Grid, transform);
		}

		#region IDataSource3D<T> Members

		public IData3D<T> Data => child.Data;

		public event EventHandler Changed
		{
			add => child.Changed += value;
			remove => child.Changed -= value;
		}

		#endregion

		#region IGridSource3D Members

		public int Width => child.Width;

		public int Height => child.Height;

		public int Depth => child.Depth;

		public IGrid3D Grid => transformedGrid;

		#endregion
	}
}
