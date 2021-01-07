namespace Microsoft.Research.DynamicDataDisplay.Common.Auxiliary
{
	using System.Windows.Media;

	public static class DoubleCollectionHelper
	{
		public static DoubleCollection Create(params double[] collection)
		{
			return new DoubleCollection(collection);
		}
	}
}
