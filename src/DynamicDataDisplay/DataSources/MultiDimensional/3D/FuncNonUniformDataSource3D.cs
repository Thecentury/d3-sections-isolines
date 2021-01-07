namespace Microsoft.Research.DynamicDataDisplay.DataSources.MultiDimensional
{
	using System;
	using System.Windows.Media.Media3D;

	public sealed class FuncNonUniformDataSource3D<T> : INonUniformDataSource3D<T>
	{
		public FuncNonUniformDataSource3D(Func<int, int, int, T> dataGetter, double[] x, double[] y, double[] z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.data = new FuncData3D<T>(dataGetter);
		}

		#region INonUniformDataSource3D<T> Members

		private readonly double[] x;
		public double[] XCoordinates => x;

		private readonly double[] y;
		public double[] YCoordinates => y;

		private readonly double[] z;
		public double[] ZCoordinates => z;

		#endregion

		#region IDataSource3D<T> Members

		private readonly FuncData3D<T> data;
		public IData3D<T> Data => data;

		public event EventHandler Changed;

		#endregion

		#region IGridSource3D Members

		public int Width => x.Length;

		public int Height => y.Length;

		public int Depth => z.Length;

		private sealed class NonUniformGrid3D : IGrid3D
		{
			private readonly double[] x;
			private readonly double[] y;
			private readonly double[] z;

			#region IGrid3D Members

			public Point3D this[int i, int j, int k] => new Point3D(x[i], y[j], z[k]);

			#endregion
		}

		private readonly NonUniformGrid3D grid;
		public IGrid3D Grid => grid;

		#endregion
	}
}
