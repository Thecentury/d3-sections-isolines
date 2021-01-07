namespace DynamicDataDisplay.Markers
{
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Charts;

	public class BarChart : MarkerChart
	{
		static BarChart()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(BarChart), new FrameworkPropertyMetadata(typeof(BarChart)));
		}

		public BarChart()
		{
			PropertyMappings[DependentValuePathProperty] = ViewportPanel.ViewportWidthProperty;
			MarkerBuilder = new TemplateMarkerGenerator();
		}
	}
}
