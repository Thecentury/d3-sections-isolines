namespace Microsoft.Research.DynamicDataDisplay.Maps.Servers
{
	using System.Windows.Media.Imaging;
	using Microsoft.Research.DynamicDataDisplay.Charts.Maps;

	public class LRUMemoryCache : LRUMemoryCacheBase<BitmapSource>, ITileSystem
	{
		public LRUMemoryCache(string name)
			: base(name)
		{

		}
	}
}
