namespace Microsoft.Research.DynamicDataDisplay.Charts.Maps
{
	using System.Windows.Media.Imaging;

	public interface IDirectAccessTileServer : ITileServer
	{
		BitmapSource this[TileIndex id] { get; }
	}
}
