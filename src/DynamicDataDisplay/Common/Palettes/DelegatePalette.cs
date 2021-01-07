namespace Microsoft.Research.DynamicDataDisplay.Common.Palettes
{
	using System;
	using System.Windows.Media;

	public sealed class DelegatePalette : PaletteBase
	{
		public DelegatePalette(Func<double, Color> func)
		{
			if (func == null)
				throw new ArgumentNullException("func");

			this.func = func;
		}

		private readonly Func<double, Color> func;

		public override Color GetColor(double t)
		{
			return func(t);
		}
	}
}
