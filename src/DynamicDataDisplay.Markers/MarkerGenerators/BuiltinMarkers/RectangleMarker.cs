namespace DynamicDataDisplay.Markers
{
	using System.Windows.Shapes;

	public class RectangleMarker : ShapeMarker
	{
		protected override Shape CreateShape()
		{
			return new Rectangle();
		}
	}
}
