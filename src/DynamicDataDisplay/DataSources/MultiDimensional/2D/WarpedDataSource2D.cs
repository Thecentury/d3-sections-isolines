namespace Microsoft.Research.DynamicDataDisplay.DataSources.MultiDimensional
{
	using System;
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Charts;
	using Microsoft.Research.DynamicDataDisplay.Common.Auxiliary;

	/// <summary>
	/// Defines warped two-dimensional data source.
	/// </summary>
	/// <typeparam name="T">Data piece type</typeparam>
	public sealed class WarpedDataSource2D<T> : IDataSource2D<T> where T : struct
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="WarpedDataSource2D&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="data">Data.</param>
		/// <param name="grid">Grid.</param>
		public WarpedDataSource2D(T[,] data, Point[,] grid)
		{
			if (data == null)
				throw new ArgumentNullException("data");
			if (grid == null)
				throw new ArgumentNullException("grid");

			(data.GetLength(0) == grid.GetLength(0)).IsTrue();
			(data.GetLength(1) == grid.GetLength(1)).IsTrue();

			this.data = data;
			this.grid = grid;
			width = data.GetLength(0);
			height = data.GetLength(1);
		}

		#region DataSource<T> Members

		private readonly T[,] data;
		/// <summary>
		/// Gets two-dimensional data array.
		/// </summary>
		/// <value>The data.</value>
		public T[,] Data => data;

		private readonly Point[,] grid;
		/// <summary>
		/// Gets the grid of data source.
		/// </summary>
		/// <value>The grid.</value>
		public Point[,] Grid => grid;

		private readonly int width;
		/// <summary>
		/// Gets data grid width.
		/// </summary>
		/// <value>The width.</value>
		public int Width => width;

		private readonly int height;
		/// <summary>
		/// Gets data grid height.
		/// </summary>
		/// <value>The height.</value>
		public int Height => height;

		public IDataSource2D<T> GetSubset(int x0, int y0, int countX, int countY, int stepX, int stepY)
		{
			throw new NotImplementedException();
		}

		private void RaiseChanged()
		{
			if (Changed != null)
			{
				Changed(this, EventArgs.Empty);
			}
		}
		/// <summary>
		/// Occurs when data source changes.
		/// </summary>
		public event EventHandler Changed;

		#endregion

		#region IDataSource2D<T> Members

		private Range<T>? range = null;
		public Range<T>? Range => range;

		private T? missingValue = null;
		public T? MissingValue => missingValue;

		#endregion
	}
}
