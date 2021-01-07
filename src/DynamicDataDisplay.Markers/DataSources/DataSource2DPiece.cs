namespace DynamicDataDisplay.Markers.DataSources
{
	using System.Windows;

	internal sealed class DataSource2DPiece<T>
	{
		public Point Position { get; set; }
		public T Data { get; set; }
	}
}
