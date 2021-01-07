namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields.Convolution
{
	using System.Collections.Generic;
	using System.Windows;

	public abstract class PointSetPattern
	{
		public abstract IEnumerable<Point> GeneratePoints();

		private int pointsCount = 100;
		public int PointsCount
		{
			get => pointsCount;
			set => pointsCount = value;
		}
	}
}
