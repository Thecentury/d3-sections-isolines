﻿namespace Microsoft.Research.DynamicDataDisplay.DataSources.MultiDimensional
{
	using System;

	public class FilteringDataSource<T> : IDataSource3D<T>
	{
		private readonly int xStep;
		private readonly int yStep;
		private readonly int zStep;

		private readonly IDataSource3D<T> child;

		private readonly FilteringData<T> filteringData;
		private readonly FilteringGrid filteringGrid;

		public FilteringDataSource(IDataSource3D<T> child, int xStep = 2, int yStep = 2, int zStep = 2)
		{
			if (child == null)
				throw new ArgumentNullException("child");

			this.child = child;
			this.child.Changed += OnChildChanged;

			this.filteringData = new FilteringData<T>(child.Data, xStep, yStep, zStep);
			this.filteringGrid = new FilteringGrid(child.Grid, xStep, yStep, zStep);

			this.xStep = xStep;
			this.yStep = yStep;
			this.zStep = zStep;
		}

		public static FilteringDataSource<T> Create<T>(IDataSource3D<T> child, int xStep, int yStep, int zStep)
		{
			return new FilteringDataSource<T>(child, xStep, yStep, zStep);
		}

		private void OnChildChanged(object sender, EventArgs e)
		{
			Changed.Raise(this);
		}

		#region IDataSource3D<T> Members

		public IData3D<T> Data => filteringData;

		public event EventHandler Changed;

		#endregion

		#region IGridSource3D Members

		public int Width => child.Width / xStep;

		public int Height => child.Height / yStep;

		public int Depth => child.Depth / zStep;

		public IGrid3D Grid => filteringGrid;

		#endregion
	}
}
