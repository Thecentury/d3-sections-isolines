namespace Microsoft.Research.DynamicDataDisplay.DataSources.MultiDimensional
{
	using System;
	using System.Windows.Media.Media3D;

	public class FuncDataSource3D<T> : IDataSource3D<T>
	{
		public FuncDataSource3D(int width, int height, int depth, Func<int, int, int, Point3D> fieldGetter, Func<int, int, int, T> dataGetter)
		{
			this.width = width;
			this.height = height;
			this.depth = depth;

			this.grid = new FuncGrid3D(fieldGetter);
			this.data = new FuncData3D<T>(dataGetter);
		}

		#region IDataSource3D<T> Members

		private readonly FuncData3D<T> data;
		public IData3D<T> Data => data;

		public event EventHandler Changed;

		#endregion

		#region IGridSource3D Members

		private int width;
		public int Width => width;

		private int height;
		public int Height => height;

		private int depth;
		public int Depth => depth;

		private readonly FuncGrid3D grid;
		public IGrid3D Grid => grid;

		#endregion
	}
}
