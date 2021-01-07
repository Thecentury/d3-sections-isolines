namespace Microsoft.Research.DynamicDataDisplay.Common.Palettes
{
	using System.Windows.Media;

	public static class UniformLinearPalettes
	{
		static UniformLinearPalettes()
		{
			blackAndWhitePalette.IncreaseBrightness = false;
			rgbPalette.IncreaseBrightness = false;
			blueOrangePalette.IncreaseBrightness = false;
		}

		private static readonly UniformLinearPalette blackAndWhitePalette =
			new UniformLinearPalette(Colors.Black, Colors.White);

		public static UniformLinearPalette BlackAndWhitePalette => blackAndWhitePalette;

		private static readonly UniformLinearPalette rgbPalette =
			new UniformLinearPalette(Colors.Blue, Color.FromRgb(0, 255, 0), Colors.Red);

		public static UniformLinearPalette RedGreenBluePalette => rgbPalette;

		private static readonly UniformLinearPalette blueOrangePalette = new UniformLinearPalette(
			Colors.Blue,
			Colors.Cyan,
			Colors.Yellow,
			Colors.Orange);

		public static UniformLinearPalette BlueOrangePalette => blueOrangePalette;
	}
}
