namespace Microsoft.Research.DynamicDataDisplay.PointMarkers
{
	using System.Windows;
	using System.Windows.Media;

	/// <summary>Renders circle around each point of graph</summary>
	public class CirclePointMarker : ShapePointMarker {

        public override void Render(DrawingContext dc, Point screenPoint) {
			dc.DrawEllipse(Fill, Pen, screenPoint, Size / 2, Size / 2);
		}
	}

}
