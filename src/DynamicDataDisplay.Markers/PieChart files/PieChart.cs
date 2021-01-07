using d3 = Microsoft.Research.DynamicDataDisplay;

namespace DynamicDataDisplay.Markers
{
	using System;
	using System.Windows;
	using System.Windows.Media;
	using Microsoft.Research.DynamicDataDisplay.Charts;

	public class PieChart : IndexedChart
	{
		static PieChart()
		{
			Type thisType = typeof(PieChart);
			DefaultStyleKeyProperty.OverrideMetadata(thisType, new FrameworkPropertyMetadata(thisType));
		}

		private static void OnPlotterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			PieChart chart = (PieChart)d;
			d3.ChartPlotter currPlotter = e.NewValue as d3.ChartPlotter;
			if (currPlotter != null)
			{
				chart.OnPlotterAttached(currPlotter);
			}
			else
			{
				d3.ChartPlotter prevPlotter = e.OldValue as d3.ChartPlotter;
				chart.OnPlotterDetaching(prevPlotter);
			}
		}

		public override void OnPlotterAttached(d3.Plotter plotter)
		{
		}

		protected override void OnPlotterDetaching(d3.Plotter2D plotter)
		{
		}

		public PieChart()
		{
			MarkerBuilder = new TemplateMarkerGenerator();
			PropertyMappings.Clear();
		}

		protected override void SetCommonBindings(FrameworkElement marker)
		{
			base.SetCommonBindings(marker);

			marker.SetBinding(PieChartItem.AngleProperty, IndependentValueBinding);
		}

		#region Properties

		public double StartAngle
		{
			get => (double)GetValue(StartAngleProperty);
			set => SetValue(StartAngleProperty, value);
		}

		public static readonly DependencyProperty StartAngleProperty = DependencyProperty.Register(
		  "StartAngle",
		  typeof(double),
		  typeof(PieChart),
		  new FrameworkPropertyMetadata(0.0));

		#endregion // end of Properties

		#region API

		public void AddPieItem(string caption, double value)
		{
			if (String.IsNullOrEmpty(caption))
				throw new ArgumentNullException("caption");

			Items.Add(new PieChartItem { Caption = caption, Angle = value });
		}

		public void AddPieItem(string caption, double value, Brush fill)
		{
			if (String.IsNullOrEmpty(caption))
				throw new ArgumentNullException("caption");

			Items.Add(new PieChartItem { Caption = caption, Angle = value, Background = fill });
		}

		#endregion // end of API
	}
}
