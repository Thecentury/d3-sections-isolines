﻿//using System.Threading.Tasks;

namespace Microsoft.Research.DynamicDataDisplay.Charts.Maps
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Windows.Media.Imaging;
    using Microsoft.Research.DynamicDataDisplay.Common.Auxiliary;
    using Microsoft.Research.DynamicDataDisplay.Maps;

    public class WriteableFileSystemTileServer : FileSystemTileServer, ITileStore, IWriteableTileServer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WriteableFileSystemTileServer"/> class.
        /// </summary>
        public WriteableFileSystemTileServer()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WriteableFileSystemTileServer"/> class.
        /// </summary>
        /// <param name="serverName">Name of the server.</param>
        public WriteableFileSystemTileServer(string serverName) : base(serverName) { }

        #region IWritableTileSource Members

        private SaveOption saveOption = SaveOption.ForceUpdate;
        public SaveOption SaveOption
        {
            get => saveOption;
            set => saveOption = value;
        }

        public void BeginSaveImage(TileIndex id, BitmapSource image, Stream stream)
        {
            string imagePath = GetImagePath(id);

            bool errorWhileDeleting = false;

            bool containsOld = Contains(id);
            if (containsOld && saveOption == SaveOption.ForceUpdate)
            {
                try
                {
                    File.Delete(imagePath);
                }
                catch (IOException exc)
                {
                    // todo возможно, тут добавить файл в очередь на удаление или перезапись новым содержимым
                    // когда он перестанет быть блокированным
                    MapsTraceSource.Instance.ServerInformationTraceSource.TraceInformation("{0} - error while deleting tile {1}: {2}", ServerName, id, exc.Message);
                    errorWhileDeleting = true;
                }
            }

            bool shouldSave = saveOption == SaveOption.ForceUpdate && !errorWhileDeleting ||
                saveOption == SaveOption.PreserveOld && !containsOld;
            if (shouldSave)
            {
                MapsTraceSource.Instance.ServerInformationTraceSource.TraceInformation("{0}: begin to save: id = {1}", ServerName, id);
                FileMap[id] = true;

                Statistics.IntValues["ImagesSaved"]++;

                BitmapSource bmp = image;
                if (!bmp.IsFrozen) { 
                }

                ThreadPool.QueueUserWorkItem(unused =>
                {
                    // Try to write tile to cache. Conflicts are possible
                    // especially in case of multiple Map control instances.
                    // That's why exception is only dumped to debug output.
                    try 
                    {
                        if (stream == null)
                        {
                            ScreenshotHelper.SaveBitmapToFile(bmp, imagePath);
                        }
                        else
                        {
                            ScreenshotHelper.SaveStreamToFile(stream, imagePath);
                        }
                    }
                    catch (Exception exc)
                    {
                        Debug.WriteLine(String.Format("Error writing tile to cache: {0}", exc.Message));
                    }
                });
            }
        }

        #endregion

        #region ITileStore Members

        public virtual void Clear()
        {
            if (Directory.Exists(CachePath))
            {
                try
                {
                    Directory.Delete(CachePath, true);
                }
                catch (IOException)
                {

                }
            }

            FileMap.Clear();
        }

        #endregion
    }

    public enum SaveOption
    {
        ForceUpdate,
        PreserveOld
    }
}
