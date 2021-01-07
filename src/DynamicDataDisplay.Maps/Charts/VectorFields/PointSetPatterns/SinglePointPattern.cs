namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields.Convolution
{
	using System.Collections.Generic;
	using System.Windows;

	public sealed class SinglePointPattern : PointSetPattern
	{
		private Point point = new Point(0.5, 0.5);
		public Point Point
		{
			get => point;
			set => point = value;
		}

		public override IEnumerable<Point> GeneratePoints()
		{
			yield return point;
		}
	}
}
