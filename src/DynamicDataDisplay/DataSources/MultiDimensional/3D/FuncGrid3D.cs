namespace Microsoft.Research.DynamicDataDisplay.DataSources.MultiDimensional
{
	using System;
	using System.Windows.Media.Media3D;

	public sealed class FuncGrid3D : IGrid3D
	{
		private readonly Func<int, int, int, Point3D> getter;

		public FuncGrid3D(Func<int, int, int, Point3D> getter)
		{
			this.getter = getter;
		}

		#region IGrid3D Members

		public Point3D this[int i, int j, int k] => getter(i, j, k);

		#endregion
	}
}
