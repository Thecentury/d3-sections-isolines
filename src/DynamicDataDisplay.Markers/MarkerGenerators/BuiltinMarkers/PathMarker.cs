﻿namespace DynamicDataDisplay.Markers
{
	using System.Windows.Media;
	using System.Windows.Shapes;

	public abstract class PathMarker : ShapeMarker
	{
		protected sealed override Shape CreateShape()
		{
			Path path = new Path();
			path.Data = CreateGeometry();
			return path;
		}

		protected abstract Geometry CreateGeometry();
	}
}
