namespace Microsoft.Research.DynamicDataDisplay.DataSources.MultiDimensional
{
	using System;
	using System.Windows.Media.Media3D;

	public class VectorToMagnitudeDataSource3D : IDataSource3D<double>
	{
		private readonly IDataSource3D<Vector3D> dataSource;

		public VectorToMagnitudeDataSource3D(IDataSource3D<Vector3D> dataSource)
		{
			if (dataSource == null)
				throw new ArgumentNullException("dataSource");

			//todo subscribe on dataSource Changed event
			this.dataSource = dataSource;
			this.data = new MagnitudeData3D(dataSource.Data);
		}

		#region IDataSource3D<double> Members

		private readonly MagnitudeData3D data;
		public IData3D<double> Data => data;

		private sealed class MagnitudeData3D : IData3D<double>
		{
			private readonly IData3D<Vector3D> data;
			public MagnitudeData3D(IData3D<Vector3D> data)
			{
				this.data = data;
			}

			#region IData3D<double> Members

			public double this[int i, int j, int k]
			{
				get
				{
					double length = data[i, j, k].Length;
					return length;
				}
			}

			#endregion
		}

		public event EventHandler Changed;

		#endregion

		#region IGridSource3D Members

		public int Width => dataSource.Width;

		public int Height => dataSource.Height;

		public int Depth => dataSource.Depth;

		public IGrid3D Grid => dataSource.Grid;

		#endregion
	}
}
