namespace Microsoft.Research.DynamicDataDisplay.Charts.NewLine
{
	using System.Collections.Generic;
	using System.Windows;

	public sealed class LinePart
	{
		public IEnumerable<Point> Points { get; set; }
		public double Parameter { get; set; }
	}
}
