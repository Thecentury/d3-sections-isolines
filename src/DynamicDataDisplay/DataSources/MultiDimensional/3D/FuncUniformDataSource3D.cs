namespace Microsoft.Research.DynamicDataDisplay.DataSources.MultiDimensional
{
	using System;
	using System.Linq;

	public sealed class FuncUniformDataSource3D<T> : IUniformDataSource3D<T>
	{
		private readonly double x;
		private readonly double y;
		private readonly double z;

		private readonly double xSize;
		private readonly double ySize;
		private readonly double zSize;

		private readonly FuncData3D<T> data;

		private readonly int width;
		private readonly int height;
		private readonly int depth;

		public FuncUniformDataSource3D(Func<int, int, int, T> dataGetter, 
			double x = 0, double xSize = 1, 
			double y = 0, double ySize = 1, 
			double z = 0, double zSize = 1, 
			int width = 10, int height = 10, int depth = 10)
		{
			this.data = new FuncData3D<T>(dataGetter);

			this.x = x;
			this.xSize = xSize;
			this.y = y;
			this.ySize = ySize;
			this.z = z;
			this.zSize = zSize;

			this.width = width;
			this.height = height;
			this.depth = depth;

			this.grid = new UniformGrid3D(x, y, z, xSize / width, ySize / height, zSize / depth);
		}

		#region IUniformDataSource3D<T> Members

		public double X => x;

		public double Y => y;

		public double Z => z;

		public double XSize => xSize;

		public double YSize => ySize;

		public double ZSize => zSize;

		#endregion

		#region INonUniformDataSource3D<T> Members

		private double[] xCoordinates;
		public double[] XCoordinates
		{
			get
			{
				if (xCoordinates == null)
				{
					double delta = xSize / width;
					xCoordinates = Enumerable.Range(0, Width).Select(i => x + i * delta).ToArray();
				}
				return xCoordinates;
			}
		}

		private double[] yCoordinates;
		public double[] YCoordinates
		{
			get
			{
				if (yCoordinates == null)
				{
					double delta = ySize / height;
					yCoordinates = Enumerable.Range(0, height).Select(i => y + i * delta).ToArray();
				}
				return yCoordinates;
			}
		}

		private double[] zCoordinates;
		public double[] ZCoordinates
		{
			get
			{
				if (zCoordinates == null)
				{
					double delta = zSize / depth;
					zCoordinates = Enumerable.Range(0, depth).Select(i => z + i * delta).ToArray();
				}
				return zCoordinates;
			}
		}

		#endregion

		#region IDataSource3D<T> Members

		public IData3D<T> Data => data;

		public event EventHandler Changed;

		#endregion

		#region IGridSource3D Members

		public int Width => width;

		public int Height => height;

		public int Depth => depth;

		private readonly UniformGrid3D grid;
		public IGrid3D Grid => grid;

		#endregion
	}
}
