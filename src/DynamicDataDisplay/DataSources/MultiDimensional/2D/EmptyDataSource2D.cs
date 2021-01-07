namespace Microsoft.Research.DynamicDataDisplay.DataSources.MultiDimensional
{
	using System;
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Charts;

	/// <summary>
	/// Defines empty two-dimensional data source.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class EmptyDataSource2D<T> : IDataSource2D<T> where T : struct
	{
		#region IDataSource2D<T> Members

		private T[,] data = new T[0, 0];
		public T[,] Data => data;

		private Point[,] grid = new Point[0, 0];
		public Point[,] Grid => grid;

		public int Width => 0;

		public int Height => 0;

		private void RaiseChanged()
		{
			if (Changed != null)
			{
				Changed(this, EventArgs.Empty);
			}
		}
		public event EventHandler Changed;

		#endregion

		#region IDataSource2D<T> Members


		public Range<T>? Range => throw new NotImplementedException();

		public T? MissingValue => throw new NotImplementedException();

		#endregion

		#region IDataSource2D<T> Members


		public IDataSource2D<T> GetSubset(int x0, int y0, int countX, int countY, int stepX, int stepY)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
