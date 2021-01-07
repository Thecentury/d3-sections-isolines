namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System.Windows;

	public class VectorFieldChart : MarkerChart
	{
		static VectorFieldChart()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(VectorFieldChart), new FrameworkPropertyMetadata(typeof(VectorFieldChart)));
		}

		public VectorFieldChart()
		{
			MarkerBuilder = new VectorFieldItemGenerator();
		}

		public string LocationPath { get; set; }
		public string DirectionPath { get; set; }

		public override void EndInit()
		{
			VectorFieldItemGenerator generator = (VectorFieldItemGenerator)MarkerBuilder;
			generator.LocationPath = LocationPath;
			generator.DirectionPath = DirectionPath;
			generator.EndInit();
	
			base.EndInit();
		}
	}
}
