//using System.Threading.Tasks;
//using System.Threading.Collections;

namespace Microsoft.Research.DynamicDataDisplay.Charts.Maps
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;
	using System.Threading;
	using System.Windows.Media.Imaging;
	using System.Windows.Threading;
	using Microsoft.Research.DynamicDataDisplay.Common.Auxiliary;

	public class AsyncFileSystemServer : WriteableFileSystemTileServer
	{
		public AsyncFileSystemServer()
		{ }

		public AsyncFileSystemServer(string name)
			: base(name)
		{
			corruptedFilesDeleteTimer.Tick += corruptedFilesDeleteTimer_Tick;
		}

		// todo is this neccessary?
		private int maxParallelRequests = Int32.MaxValue;
		public int MaxParallelRequests
		{
			get => maxParallelRequests;
			set => maxParallelRequests = value;
		}

		private bool CanRunNextRequest => runningRequests <= maxParallelRequests;

		private int runningRequests;
		//private readonly ConcurrentStack<TileIndex> requests = new ConcurrentStack<TileIndex>();
        private readonly Stack<TileIndex> requests = new Stack<TileIndex>();

		public override void BeginLoadImage(TileIndex id)
		{
			if (ImageLoadedHandler == null) { }

			string imagePath = GetImagePath(id);

			if (CanRunNextRequest)
			{
				runningRequests++;
				Statistics.IntValues["ImagesLoaded"]++;

                ThreadPool.QueueUserWorkItem(unused =>
                {
	                var bmp = BeginLoadImageAsync(id);
	                var stream = BeginLoadStreamAsync(id);
	                OnImageLoadedAsync(id, bmp, stream);
                });
			}
			else
			{
                lock(requests)
				    requests.Push(id);
			}
		}

		private Stream BeginLoadStreamAsync(TileIndex id)
		{
			string imagePath = GetImagePath(id);

			return new FileStream(imagePath, FileMode.Open, FileAccess.Read);
		}

		private readonly DispatcherTimer corruptedFilesDeleteTimer = new DispatcherTimer
		{
			Interval = TimeSpan.FromMilliseconds(2000)
		};
		private readonly List<Action> fileDeleteActions = new List<Action>();

		private void corruptedFilesDeleteTimer_Tick(object sender, EventArgs e)
		{
			Debug.WriteLine("Deleting files: " + Environment.TickCount);

			// todo is this is necessary?
			// GC is called to collect partly loaded corrupted bitmap
			// otherwise it prevented from image file being deleted.
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();

			foreach (var action in fileDeleteActions)
			{
				action.BeginInvoke(null, null);
			}
			fileDeleteActions.Clear();
			corruptedFilesDeleteTimer.Stop();
		}

		protected BitmapImage BeginLoadImageAsync(TileIndex id)
		{
			string imagePath = GetImagePath(id);

			BitmapImage bmp = new BitmapImage();
			bmp.BeginInit();
			bmp.CacheOption = BitmapCacheOption.OnLoad;
			bmp.UriSource = new Uri(imagePath);
			try
			{
				bmp.EndInit();
			}
			catch (NotSupportedException exc)
			{
				Debug.WriteLine("{0}: failed id = {1}. Exc = \"{2}\"", GetCustomName(), id, exc.Message);

				Action corruptedFileDeleteAction = () =>
				{
					try
					{
						File.Delete(imagePath);
					}
					catch (Exception e)
					{
						Debug.WriteLine("Exception while deleting corrupted image file \"" + imagePath + "\": " + e.Message);
					}
				};

				lock (fileDeleteActions)
				{
					fileDeleteActions.Add(corruptedFileDeleteAction);
					if (!corruptedFilesDeleteTimer.IsEnabled)
						corruptedFilesDeleteTimer.Start();
				}

				return null;
			}
			catch (FileNotFoundException exc)
			{
				Debug.WriteLine("{0}: failed id = {1}. Exception = \"{2}\"", GetCustomName(), id, exc.Message);
				return null;
			}
			catch (DirectoryNotFoundException exc)
			{
				Debug.WriteLine("{0}: failed id = {1}, Exception = \"{2}\"", GetCustomName(), id, exc.Message);
				return null;
			}

			return (BitmapImage)bmp.GetAsFrozen();
		}

		private void OnImageLoadedAsync(TileIndex id, BitmapImage bmp, Stream stream)
		{
			Dispatcher.BeginInvoke(() =>
			{
				runningRequests--;
				if (bmp != null)
				{
					ReportSuccess(stream, bmp, id);
				}
				else
				{
					ReportFailure(id);
				}
				if (CanRunNextRequest)
				{
					TileIndex nextId = new TileIndex();
                    lock (requests)
                        if (requests.Count > 0)
                            nextId = requests.Pop();
                        else
                            return;
					BeginLoadImage(nextId);
				}
			}, DispatcherPriority.Background);
		}
	}
}
