namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields
{
	using System.Windows;
	using System.Windows.Media;
	using System.Windows.Media.Imaging;
	using System.Windows.Shapes;

	public class VerticalCrossSectionChart : CrossSectionChartBase
	{
		private readonly Polygon polygon = new Polygon { Width = 100, Stretch = Stretch.Fill };

		public override void OnPlotterAttached(Plotter plotter)
		{
			Plotter = (Plotter2D)plotter;
			plotter.LeftPanel.Children.Insert(0, polygon);

			RebuildUI();
		}

		public override void OnPlotterDetaching(Plotter plotter)
		{
			Plotter = (Plotter2D)plotter;
			plotter.LeftPanel.Children.Remove(polygon);
		}

		UniformField2DWrapper fieldWrapper;
		protected override void RebuildUI()
		{
			if (DataSource == null) return;
			if (Plotter == null) return;
			if (Palette == null) return;

			int width = DataSource.Width;
			int height = DataSource.Height;
			fieldWrapper = new UniformField2DWrapper(DataSource.Data);
			var coordinate = SectionCoordinate;

			var minMaxLength = DataSource.GetMinMaxLength();

			PointCollection points = new PointCollection(height + 2);

			var palette = Palette;
			int[] pixels = new int[height];
			for (int iy = 0; iy < height; iy++)
			{
				double y = iy;
				var value = fieldWrapper.GetVector(coordinate / height, y / height);
				double length = value.Length;
				if (length.IsNaN())
					length = minMaxLength.Min;

				double ratio = (length - minMaxLength.Min) / minMaxLength.GetLength();
				if (ratio < 0)
					ratio = 0;
				if (ratio > 1)
					ratio = 1;
				points.Add(new Point(ratio, height - y));

				var color = palette.GetColor(ratio);
				pixels[iy] = color.ToArgb();
			}

			points.Add(new Point(0, 0));
			points.Add(new Point(0, height));

			polygon.Points = points;
			var paletteBmp = BitmapFrame.Create(1, height, 96, 96, PixelFormats.Pbgra32, null, pixels, (1 * PixelFormats.Pbgra32.BitsPerPixel + 7) / 8);
			var brush = new ImageBrush(paletteBmp);
			polygon.Fill = brush;
		}
	}
}
