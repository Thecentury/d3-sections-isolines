namespace Microsoft.Research.DynamicDataDisplay.Markers.MarkerGenerators.Rendering
{
	using System.Windows;
	using System.Windows.Media;

	public abstract class MarkerRenderer : FrameworkElement
	{
		public abstract void Render(DrawingContext dc, CoordinateTransform transform);
	}
}
