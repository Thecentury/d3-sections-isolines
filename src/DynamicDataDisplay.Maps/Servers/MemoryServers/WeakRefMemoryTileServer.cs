namespace Microsoft.Research.DynamicDataDisplay.Charts.Maps
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Windows.Media.Imaging;

	public sealed class WeakRefMemoryTileServer : TileServerBase, ITileSystem
	{

		public WeakRefMemoryTileServer(string name)
		{
			ServerName = name;
		}

		protected override string GetCustomName()
		{
			return "Memory " + ServerName;
		}

		// todo change that this cache is beeing cleaned by GC when simply panning map.

		private readonly Dictionary<TileIndex, WeakReference> cache = new Dictionary<TileIndex, WeakReference>(new TileIndex.TileIndexEqualityComparer());

		public override bool Contains(TileIndex id)
		{
			if (cache.ContainsKey(id))
			{
				bool isAlive = cache[id].IsAlive;
				if (isAlive)
				{
					return true;
				}

				//removing dead reference
				cache.Remove(id);
				return false;
			}

			return false;
		}

		public override void BeginLoadImage(TileIndex id)
		{
			if (Contains(id))
			{
				var img = (BitmapSource)cache[id].Target;
				ReportSuccess(img, id);
			}
			else
			{
				ReportFailure(id);
			}
		}

		public BitmapSource this[TileIndex id] => (BitmapSource)cache[id].Target;

		#region ITileStore Members

		public void BeginSaveImage(TileIndex id, BitmapSource image, Stream stream)
		{
            if (image == null)
                throw new ArgumentNullException("image");

			cache[id] = new WeakReference(image);
			Statistics.IntValues["ImagesSaved"]++;
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
