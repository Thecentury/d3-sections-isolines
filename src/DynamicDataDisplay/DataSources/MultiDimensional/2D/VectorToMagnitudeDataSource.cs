namespace Microsoft.Research.DynamicDataDisplay.DataSources.MultiDimensional
{
	using System;
	using System.Threading.Tasks;
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Charts;
	using Microsoft.Research.DynamicDataDisplay.Common.Auxiliary;

	public class VectorToMagnitudeDataSource : IDataSource2D<double>
	{
		private readonly IDataSource2D<Vector> dataSource;

		public VectorToMagnitudeDataSource(IDataSource2D<Vector> dataSource)
		{
			if (dataSource == null)
				throw new ArgumentNullException("dataSource");

			this.dataSource = dataSource;
			dataSource.Changed += OnDataSource_Changed;
			Update();
		}

		private void Update()
		{
			int width = dataSource.Width;
			int height = dataSource.Height;

			var foreignData = dataSource.Data;

			data = new double[width, height];
			Parallel.For(0, width, ix =>
			{
				for (int iy = 0; iy < height; iy++)
				{
					data[ix, iy] = foreignData[ix, iy].Length;
				}
			});

			range = this.GetMinMax();
		}

		void OnDataSource_Changed(object sender, EventArgs e)
		{
			Update();
			Changed.Raise(this);
		}

		#region IDataSource2D<double> Members

		private double[,] data;
		public double[,] Data => data;

		public IDataSource2D<double> GetSubset(int x0, int y0, int countX, int countY, int stepX, int stepY)
		{
			throw new NotImplementedException();
		}

		private Range<double>? range;
		public Range<double>? Range
		{
			get
			{
				if (range == null)
				{

				}
				return range;
			}
		}

		public double? MissingValue => Double.NaN;

		#endregion

		#region IGridSource2D Members

		public Point[,] Grid => dataSource.Grid;

		public int Width => dataSource.Width;

		public int Height => dataSource.Height;

		public event EventHandler Changed;

		#endregion
	}
}
