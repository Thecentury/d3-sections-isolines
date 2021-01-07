namespace Microsoft.Research.DynamicDataDisplay.DataSources.MultiDimensional
{
	public interface INonUniformDataSource3D<T> : IDataSource3D<T>
	{
		double[] XCoordinates { get; }
		double[] YCoordinates { get; }
		double[] ZCoordinates { get; }
	}
}
