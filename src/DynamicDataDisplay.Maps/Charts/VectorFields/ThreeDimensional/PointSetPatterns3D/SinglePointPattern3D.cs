namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields
{
	using System.Collections.Generic;
	using System.Windows.Media.Media3D;

	public sealed class SinglePointPattern3D : PointSetPattern3D
	{
		private Point3D point;
		public Point3D Point
		{
			get => point;
			set => point = value;
		}

		public override IEnumerable<Point3D> GeneratePoints()
		{
			yield return point;
		}
	}
}
