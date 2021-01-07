namespace Microsoft.Research.DynamicDataDisplay.Common.Auxiliary
{
	using System.Windows.Media;

	public static class ColorExtensions
	{
		public static Color MakeTransparent(this Color color, int alpha)
		{
			color.A = (byte)alpha;
			return color;
		}

		public static Color MakeTransparent(this Color color, double opacity)
		{
			return MakeTransparent(color, (int)(255 * opacity));
		}
	}
}
