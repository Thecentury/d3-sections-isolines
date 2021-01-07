namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields.Convolution
{
	using System;
	using System.Collections.Generic;
	using System.Windows;

	public sealed class GridPattern : PointSetPattern
	{
		public override IEnumerable<Point> GeneratePoints()
		{
			int inLineCount = (int)Math.Sqrt(PointsCount);
			double delta = 1.0 / (inLineCount + 1);
			for (int ix = 0; ix < inLineCount; ix++)
			{
				for (int iy = 0; iy < inLineCount; iy++)
				{
					yield return new Point(ix * delta, iy * delta);
				}
			}
		}
	}
}
