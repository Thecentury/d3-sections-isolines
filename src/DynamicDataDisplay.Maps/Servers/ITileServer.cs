namespace Microsoft.Research.DynamicDataDisplay.Charts.Maps
{
    using System;

    public interface ITileServer
    {
        bool Contains(TileIndex id);
        void BeginLoadImage(TileIndex id);
        event EventHandler<TileLoadResultEventArgs> ImageLoaded;

        string ServerName { get; }

        event EventHandler Changed;
    }
}
