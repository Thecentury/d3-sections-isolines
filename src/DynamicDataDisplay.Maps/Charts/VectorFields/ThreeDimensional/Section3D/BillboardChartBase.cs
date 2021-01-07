namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields
{
	using System.Windows;
	using System.Windows.Media.Media3D;

	public abstract class BillboardChartBase : ModelVisual3D
	{
		protected BillboardChartBase()
		{
			UpdateUI();
		}

		#region CenterProperty

		private static void UpdateUI(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BillboardChartBase owner = (BillboardChartBase)d;
			owner.UpdateUI();
		}

		public Point Center
		{
			get => (Point)GetValue(CenterProperty);
			set => SetValue(CenterProperty, value);
		}

		public static readonly DependencyProperty CenterProperty = DependencyProperty.Register(
		  "Center",
		  typeof(Point),
		  typeof(BillboardChartBase),
		  new FrameworkPropertyMetadata(new Point(0.5, 0.5), UpdateUI));

		#endregion CenterProperty

		#region Width property

		public double Width
		{
			get => (double)GetValue(WidthProperty);
			set => SetValue(WidthProperty, value);
		}

		public static readonly DependencyProperty WidthProperty = DependencyProperty.Register(
		  "Width",
		  typeof(double),
		  typeof(BillboardChartBase),
		  new FrameworkPropertyMetadata(1.0, UpdateUI));

		#endregion Width property

		#region Height property

		public double Height
		{
			get => (double)GetValue(HeightProperty);
			set => SetValue(HeightProperty, value);
		}

		public static readonly DependencyProperty HeightProperty = DependencyProperty.Register(
		  "Height",
		  typeof(double),
		  typeof(BillboardChartBase),
		  new FrameworkPropertyMetadata(1.0, UpdateUI));

		#endregion Height property

		#region ThirdCoordinate property

		public double ThirdCoordinate
		{
			get => (double)GetValue(ThirdCoordinateProperty);
			set => SetValue(ThirdCoordinateProperty, value);
		}

		public static readonly DependencyProperty ThirdCoordinateProperty = DependencyProperty.Register(
		  "ThirdCoordinate",
		  typeof(double),
		  typeof(BillboardChartBase),
		  new FrameworkPropertyMetadata(0.0, UpdateUI));

		#endregion ThirdCoordinate property

		public abstract void UpdateUI();
	}
}
