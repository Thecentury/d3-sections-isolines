namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields
{
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Common.Palettes;

	public abstract class CrossSectionChartBase : VectorFieldChartBase
	{
		#region Properties

		public double SectionCoordinate
		{
			get => (double)GetValue(SectionCoordinateProperty);
			set => SetValue(SectionCoordinateProperty, value);
		}

		public static readonly DependencyProperty SectionCoordinateProperty = DependencyProperty.Register(
		  "SectionCoordinate",
		  typeof(double),
		  typeof(CrossSectionChartBase),
		  new FrameworkPropertyMetadata(0.0, OnSectionCoordinateReplaced));

		private static void OnSectionCoordinateReplaced(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			CrossSectionChartBase owner = (CrossSectionChartBase)d;
			owner.RebuildUI();
		}

		#endregion

		#region Palette

		public IPalette Palette
		{
			get => (IPalette)GetValue(PaletteProperty);
			set => SetValue(PaletteProperty, value);
		}

		public static readonly DependencyProperty PaletteProperty = DependencyProperty.Register(
		  "Palette",
		  typeof(IPalette),
		  typeof(CrossSectionChartBase),
		  new FrameworkPropertyMetadata(null));

		#endregion
	}
}
