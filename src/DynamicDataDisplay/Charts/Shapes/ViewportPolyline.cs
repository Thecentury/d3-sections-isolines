﻿namespace Microsoft.Research.DynamicDataDisplay.Charts.Shapes
{
	using System.Windows;
	using System.Windows.Media;

	/// <summary>
	/// Represents a polyline with points in Viewport coordinates.
	/// </summary>
	public sealed class ViewportPolyline : ViewportPolylineBase
	{
		protected override void UpdateUIRepresentationCore()
		{
			var transform = Plotter.Viewport.Transform;

			PathGeometry geometry = PathGeometry;

			PointCollection points = Points;
			geometry.Clear();

			if (points == null) { }
			else
			{
				PathFigure figure = new PathFigure();
				if (points.Count > 0)
				{
					figure.StartPoint = points[0].DataToScreen(transform);
					if (points.Count > 1)
					{
						Point[] pointArray = new Point[points.Count - 1];
						for (int i = 1; i < points.Count; i++)
						{
							pointArray[i - 1] = points[i].DataToScreen(transform);
						}
						figure.Segments.Add(new PolyLineSegment(pointArray, true));
					}
				}
				geometry.Figures.Add(figure);
				geometry.FillRule = this.FillRule;
			}
		}
	}
}
