namespace Microsoft.Research.DynamicDataDisplay.Maps.DeepZoom
{
    using Microsoft.Research.DynamicDataDisplay.Charts.Maps;

    public class DeepZoomViewer : Map
    {
        private DeepZoomTileServer tileServer = new DeepZoomTileServer();

        public DeepZoomViewer()
        {
            SourceTileServer = tileServer;
            Mode = TileSystemMode.OnlineOnly;
            TileProvider = new DeepZoomTileProvider();

            ProportionsConstraint.ProportionRatio = 1;
        }

        public DeepZoomViewer(string imagePath)
            : this()
        {
            ImagePath = imagePath;
        }

        public string ImagePath
        {
            get => tileServer.ImagePath;
            set => tileServer.ImagePath = value;
        }

    }
}
