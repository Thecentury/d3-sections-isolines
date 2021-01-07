namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Media;

	public class VectorFieldChartItem : Control
	{
		static VectorFieldChartItem()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(VectorFieldChartItem), new FrameworkPropertyMetadata(typeof(VectorFieldChartItem)));
		}

		#region Properties

		public Point StartPoint
		{
			get => (Point)GetValue(StartPointProperty);
			set => SetValue(StartPointProperty, value);
		}

		public static readonly DependencyProperty StartPointProperty = DependencyProperty.Register(
		  "StartPoint",
		  typeof(Point),
		  typeof(VectorFieldChartItem),
		  new FrameworkPropertyMetadata(new Point(), OnCommonPropertyChanged));

		private static void OnCommonPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			VectorFieldChartItem owner = (VectorFieldChartItem)d;
			owner.CoerceValue(EndPointProperty);
		}

		public Vector Direction
		{
			get => (Vector)GetValue(DirectionProperty);
			set => SetValue(DirectionProperty, value);
		}

		public static readonly DependencyProperty DirectionProperty = DependencyProperty.Register(
		  "Direction",
		  typeof(Vector),
		  typeof(VectorFieldChartItem),
		  new FrameworkPropertyMetadata(new Vector(), OnCommonPropertyChanged));

		public Point EndPoint
		{
			get => (Point)GetValue(EndPointProperty);
			protected set => SetValue(EndPointPropertyKey, value);
		}

		private static readonly DependencyPropertyKey EndPointPropertyKey = DependencyProperty.RegisterReadOnly(
		  "EndPoint",
		  typeof(Point),
		  typeof(VectorFieldChartItem),
		  new FrameworkPropertyMetadata(new Point(), null, CoerceEndPoint));

		private static object CoerceEndPoint(DependencyObject d, object value)
		{
			VectorFieldChartItem item = (VectorFieldChartItem)d;

			return item.StartPoint + item.Direction;
		}

		public static readonly DependencyProperty EndPointProperty = EndPointPropertyKey.DependencyProperty;

		public Brush Stroke
		{
			get => (Brush)GetValue(StrokeProperty);
			set => SetValue(StrokeProperty, value);
		}

		public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register(
		  "Stroke",
		  typeof(Brush),
		  typeof(VectorFieldChartItem),
		  new FrameworkPropertyMetadata(Brushes.Peru));

		#endregion
	}
}
