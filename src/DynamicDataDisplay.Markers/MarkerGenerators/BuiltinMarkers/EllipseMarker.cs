namespace DynamicDataDisplay.Markers
{
	using System.Windows.Shapes;

	public class EllipseMarker : ShapeMarker
	{
		protected override Shape CreateShape()
		{
			return new Ellipse();
		}
	}
}
