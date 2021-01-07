namespace Microsoft.Research.DynamicDataDisplay.DataSources.MultiDimensional
{
	public interface IUniformDataSource3D<T> : INonUniformDataSource3D<T>
	{
		double X { get; }
		double Y { get; }
		double Z { get; }

		double XSize { get; }
		double YSize { get; }
		double ZSize { get; }
	}
}
