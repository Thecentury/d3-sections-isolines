namespace Microsoft.Research.DynamicDataDisplay.Common.Palettes
{
	using System;
	using System.ComponentModel;
	using System.Windows.Media;
	using Microsoft.Research.DynamicDataDisplay.Common.Auxiliary;

	public sealed class HsbPalette : IPalette
	{
		private double start;
		[DefaultValue(0.0)]
		public double Start
		{
			get => start;
			set
			{
				if (start != value)
				{
					start = value;
					Changed.Raise(this);
				}
			}
		}

		private double width = 360;
		[DefaultValue(360.0)]
		public double Width
		{
			get => width;
			set
			{
				if (width != value)
				{
					width = value;
					Changed.Raise(this);
				}
			}
		}

		#region IPalette Members

		public Color GetColor(double t)
		{
			(0 <= t && t <= 1).IsTrue();

			return new HsbColor(start + t * width, 1, 1).ToArgbColor();
		}

		public event EventHandler Changed;

		#endregion
	}
}
