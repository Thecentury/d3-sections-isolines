namespace Microsoft.Research.DynamicDataDisplay.Maps.Servers
{
	using System.IO;
	using System.Windows.Media.Imaging;
	using Microsoft.Research.DynamicDataDisplay.Charts.Maps;

	public class EmptyWriteableTileServer : EmptyTileServer, ITileStore, IWriteableTileServer
	{
		#region ITileStore Members

		protected override string GetCustomName()
		{
			return "Empty writeable";
		}

		public void BeginSaveImage(TileIndex id, BitmapSource image, Stream stream)
		{
			// do nothing
		}

        public void Clear()
        {
            // do nothing
        }

        #endregion
    }
}
