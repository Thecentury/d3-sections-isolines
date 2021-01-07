namespace Microsoft.Research.DynamicDataDisplay.Common.Palettes
{
	using System;
	using System.Windows.Media;

	public class PowerPalette : DecoratorPaletteBase
	{
		public PowerPalette() { }

		public PowerPalette(double power = 2) { Power = power; }

		public PowerPalette(IPalette palette, double power = 2) : base(palette) { Power = power; }

		private double power = 2;
		public double Power
		{
			get => power;
			set
			{
				power = value;
				RaiseChanged();
			}
		}

		public override Color GetColor(double t)
		{
			return base.GetColor(Math.Pow(t, power));
		}
	}
}
