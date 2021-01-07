namespace Microsoft.Research.DynamicDataDisplay.DataSources
{
	using System;
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Charts;

	public abstract class DecoratorDataSource2D<T> : IDataSource2D<T> where T : struct
	{
		private readonly IDataSource2D<T> child;
		protected DecoratorDataSource2D(IDataSource2D<T> child)
		{
			if (child == null)
				throw new ArgumentNullException("child");
			this.child = child;

			child.Changed += OnChildChanged;
		}

		protected IDataSource2D<T> Child => child;

		protected virtual void OnChildChanged(object sender, EventArgs e)
		{
			Changed.Raise(this);
		}

		#region IDataSource2D<T> Members

		public abstract T[,] Data { get; }

		public IDataSource2D<T> GetSubset(int x0, int y0, int countX, int countY, int stepX, int stepY)
		{
			return child.GetSubset(x0, y0, countX, countY, stepX, stepY);
		}

		public Range<T>? Range => child.Range;

		public T? MissingValue => child.MissingValue;

		#endregion

		#region IGridSource2D Members

		public abstract Point[,] Grid { get; }

		public int Width => child.Width;

		public int Height => child.Height;

		public event EventHandler Changed;

		#endregion
	}
}
