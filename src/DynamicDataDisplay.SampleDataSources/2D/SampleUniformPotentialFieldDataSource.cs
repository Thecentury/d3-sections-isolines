namespace Microsoft.Research.DynamicDataDisplay.SampleDataSources
{
	using System;
	using System.Linq;
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Charts;
	using Microsoft.Research.DynamicDataDisplay.DataSources;
	using Microsoft.Research.DynamicDataDisplay.DataSources.MultiDimensional;

	public class SampleUniformPotentialFieldDataSource : INonUniformDataSource2D<Vector>
	{
		private readonly PotentialField field;
		private readonly int width;
		private readonly int height;

		public SampleUniformPotentialFieldDataSource(PotentialField field, int width = 200, int height = 200)
		{
			this.field = field;
			this.width = width;
			this.height = height;

			field.Changed += OnFieldChanged;
		}

		private void OnFieldChanged(object sender, EventArgs e)
		{
			Changed.Raise(this);
		}

		#region IDataSource2D<Vector> Members

		public Vector[,] Data
		{
			get
			{
				return DataSource2DHelper.CreateVectorData(width, height, (x, y) =>
				{
					return field.GetTangentVector(new Point(x, y));
				});
			}
		}

		public IDataSource2D<Vector> GetSubset(int x0, int y0, int countX, int countY, int stepX, int stepY)
		{
			throw new NotImplementedException();
		}

		public Range<Vector>? Range => throw new NotImplementedException();

		public Vector? MissingValue => throw new NotImplementedException();

		#endregion

		#region IGridSource2D Members

		private Point[,] grid;
		public Point[,] Grid
		{
			get
			{
				if (grid == null)
				{
					grid = new Point[width, height];
					for (int ix = 0; ix < width; ix++)
					{
						for (int iy = 0; iy < height; iy++)
						{
							grid[ix, iy] = new Point(ix, iy);
						}
					}
				}

				return grid;
			}
		}

		public int Width => width;

		public int Height => height;

		public event EventHandler Changed;

		#endregion

		#region INonUniformDataSource2D<Vector> Members

		private double[] xs;
		public double[] XCoordinates
		{
			get
			{
				if (xs == null)
					xs = Enumerable.Range(0, width).Select(i => (double)i).ToArray();

				return xs;
			}
		}

		private double[] ys;
		public double[] YCoordinates
		{
			get {
				if (ys == null)
					ys = Enumerable.Range(0, width).Select(i => (double)i).ToArray();

				return ys;
			}
		}

		#endregion
	}
}
