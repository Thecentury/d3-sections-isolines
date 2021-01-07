namespace Microsoft.Research.DynamicDataDisplay.Charts.Maps
{
	using System.Collections.Generic;
	using System.Windows.Media.Imaging;

	internal sealed class PendingBitmapSet
	{
		private readonly Dictionary<BitmapSource, TileIndex> cache = new Dictionary<BitmapSource, TileIndex>();

		public void Add(BitmapSource key, TileIndex value)
		{
			cache.Add(key, value);
		}

		public TileIndex this[BitmapSource key] => cache[key];

		public bool Remove(BitmapSource key)
		{
			return cache.Remove(key);
		}
	}
}
