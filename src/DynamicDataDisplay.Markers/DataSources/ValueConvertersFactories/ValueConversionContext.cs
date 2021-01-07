namespace DynamicDataDisplay.Markers.DataSources.ValueConvertersFactories
{
	using Microsoft.Research.DynamicDataDisplay;

	internal sealed class ValueConversionContext : IValueConversionContext
	{
		#region IValueConversionContext Members

		public Plotter Plotter { get; set; }

		#endregion
	}
}
