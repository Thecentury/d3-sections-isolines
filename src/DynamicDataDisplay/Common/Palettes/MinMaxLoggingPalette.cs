namespace Microsoft.Research.DynamicDataDisplay.Common.Palettes
{
	using System;
	using System.Diagnostics;
	using System.Windows.Media;

	/// <summary>
	/// Represents a palette that calculates minimal and maximal values of interpolation coefficient and every 100000 calls writes these values 
	/// to DEBUG console.
	/// </summary>
	public class MinMaxLoggingPalette : DecoratorPaletteBase
	{
		double min = Double.MaxValue;
		double max = Double.MinValue;
		int counter;
		public override Color GetColor(double t)
		{
			if (t < min) min = t;
			if (t > max) max = t;
			counter++;

			if (counter % 100000 == 0)
			{
				Debug.WriteLine("Palette: Min = " + min + ", max = " + max);
			}

			return base.GetColor(t);
		}
	}
}
