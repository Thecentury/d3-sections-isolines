﻿namespace DynamicDataDisplay.Test.D3
{
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay;
	using Microsoft.Research.DynamicDataDisplay.Charts;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class ViewportShapeTest
	{
		[TestMethod]
		public void TestAddingToPlotter()
		{
			HorizontalLine line = new HorizontalLine { Value = 0.2 };
			ChartPlotter plotter = new ChartPlotter();
			plotter.Children.Add(line);

			VerticalLine line2 = new VerticalLine { Value = 0.1 };
			plotter.Children.Add(line2);

			VerticalRange range = new VerticalRange { Value1 = 0.1, Value2 = 0.3 };
			plotter.Children.Add(range);

			RectangleHighlight rect = new RectangleHighlight { Bounds = new Rect(0, 0, 1, 1) };
			plotter.Children.Add(rect);
		}
	}
}
