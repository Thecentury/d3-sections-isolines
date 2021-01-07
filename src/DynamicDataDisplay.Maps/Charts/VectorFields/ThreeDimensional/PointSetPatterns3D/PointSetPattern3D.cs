namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields
{
	using System.Collections.Generic;
	using System.Windows.Media.Media3D;

	public abstract class PointSetPattern3D
	{
		public abstract IEnumerable<Point3D> GeneratePoints();

		private int pointsCount = 100;
		public int PointsCount
		{
			get => pointsCount;
			set => pointsCount = value;
		}
	}
}
