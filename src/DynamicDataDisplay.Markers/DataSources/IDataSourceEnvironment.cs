namespace DynamicDataDisplay.Markers.DataSources
{
	using Microsoft.Research.DynamicDataDisplay;

	public interface IDataSourceEnvironment
	{
		Plotter2D Plotter { get; }
		bool FirstDraw { get; }
	}
}
