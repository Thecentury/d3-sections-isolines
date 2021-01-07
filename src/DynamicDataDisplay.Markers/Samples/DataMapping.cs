namespace DynamicDataDisplay.Markers.Samples
{
	using System;
	using Microsoft.Research.DynamicDataDisplay.Charts.Axes;

	class DataMapping<T>
	{
		public Func<T, object> XMapping;
		public Func<T, object> YMapping;
		public GeneralAxis XAxis { get; set; }
		public GeneralAxis YAxis { get; set; }
	}
}
