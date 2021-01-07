namespace Microsoft.Research.DynamicDataDisplay
{
	using System;
	using Microsoft.Research.DynamicDataDisplay.DataSources;

	public interface IOneDimensionalChart
	{
		IPointDataSource DataSource { get; set; }
		event EventHandler DataChanged;
	}
}
