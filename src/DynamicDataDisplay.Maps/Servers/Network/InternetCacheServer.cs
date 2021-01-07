﻿namespace Microsoft.Research.DynamicDataDisplay.Maps.Servers.Network
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Cache;
    using System.Windows.Markup;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Microsoft.Research.DynamicDataDisplay.Charts.Maps;

    [ContentProperty("TileServer")]
    public class InternetCacheServer : SourceTileServer, IWriteableTileServer
    {
        public NetworkTileServer TileServer { get; set; }

        public override bool Contains(TileIndex id)
        {
            return true;
        }

        private Dictionary<BitmapFrame, TileIndex> downloadingTiles = new Dictionary<BitmapFrame, TileIndex>();
        public override void BeginLoadImage(TileIndex id)
        {
            string uriString = TileServer.CreateRequestUri(id);
            Uri tileUri = new Uri(uriString);

            var bmp = BitmapFrame.Create(tileUri, new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable));
            downloadingTiles.Add(bmp, id);
            if (bmp.IsDownloading)
            {
                bmp.DownloadCompleted += bmp_DownloadCompleted;
                bmp.DownloadFailed += bmp_DownloadFailed;
            }
            else
            {
                ReportSuccess(bmp, id);
            }
        }

        void bmp_DownloadFailed(object sender, ExceptionEventArgs e)
        {
            BitmapFrame bmp = (BitmapFrame)sender;
            var id = downloadingTiles[bmp];
            downloadingTiles.Remove(bmp);
            UnsubscribeBitmapEvents(bmp);
            bmp.Freeze();

            ReportFailure(id);
        }

        void bmp_DownloadCompleted(object sender, EventArgs e)
        {
            BitmapFrame bmp = (BitmapFrame)sender;
            var id = downloadingTiles[bmp];
            downloadingTiles.Remove(bmp);
            UnsubscribeBitmapEvents(bmp);
            bmp.Freeze();

            ReportSuccess(bmp, id);
        }

        private void UnsubscribeBitmapEvents(BitmapFrame bmp)
        {
            bmp.DownloadCompleted -= bmp_DownloadCompleted;
            bmp.DownloadFailed -= bmp_DownloadFailed;
        }

        #region ITileStore Members

        public void BeginSaveImage(TileIndex id, BitmapSource image, Stream stream)
        {
            // do nothing here
        }

        #endregion

        #region ITileStore Members

        public void Clear()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
