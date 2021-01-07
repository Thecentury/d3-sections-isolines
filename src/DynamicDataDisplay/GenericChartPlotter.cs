namespace Microsoft.Research.DynamicDataDisplay
{
	using System;
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Charts;
	using Microsoft.Research.DynamicDataDisplay.Strings;

	public sealed class GenericChartPlotter<THorizontal, TVertical>
	{
		private readonly AxisBase<THorizontal> horizontalAxis;
		public AxisBase<THorizontal> HorizontalAxis => horizontalAxis;

		private readonly AxisBase<TVertical> verticalAxis;
		public AxisBase<TVertical> VerticalAxis => verticalAxis;

		private readonly ChartPlotter plotter;
		public ChartPlotter Plotter => plotter;

		public Func<THorizontal, double> HorizontalToDoubleConverter => horizontalAxis.ConvertToDouble;

		public Func<double, THorizontal> DoubleToHorizontalConverter => horizontalAxis.ConvertFromDouble;

		public Func<TVertical, double> VerticalToDoubleConverter => verticalAxis.ConvertToDouble;

		public Func<double, TVertical> DoubleToVerticalConverter => verticalAxis.ConvertFromDouble;

		internal GenericChartPlotter(ChartPlotter plotter) : this(plotter, plotter.MainHorizontalAxis as AxisBase<THorizontal>, plotter.MainVerticalAxis as AxisBase<TVertical>) { }

		internal GenericChartPlotter(ChartPlotter plotter, AxisBase<THorizontal> horizontalAxis, AxisBase<TVertical> verticalAxis)
		{
			if (horizontalAxis == null)
				throw new ArgumentNullException(Exceptions.PlotterMainHorizontalAxisShouldNotBeNull);
			if (verticalAxis == null)
				throw new ArgumentNullException(Exceptions.PlotterMainVerticalAxisShouldNotBeNull);

			this.horizontalAxis = horizontalAxis;
			this.verticalAxis = verticalAxis;

			this.plotter = plotter;
		}

		public GenericRect<THorizontal, TVertical> ViewportRect
		{
			get
			{
				DataRect viewportRect = plotter.Viewport.Visible;
				return CreateGenericRect(viewportRect);
			}
			set
			{
				DataRect viewportRect = CreateRect(value);
				plotter.Viewport.Visible = viewportRect;
			}
		}

		public GenericRect<THorizontal, TVertical> DataRect
		{
			get
			{
				DataRect dataRect = plotter.Viewport.Visible.ViewportToData(plotter.Viewport.Transform);
				return CreateGenericRect(dataRect);
			}
			set
			{
				DataRect dataRect = CreateRect(value);
				plotter.Viewport.Visible = dataRect.DataToViewport(plotter.Viewport.Transform);
			}
		}

		private DataRect CreateRect(GenericRect<THorizontal, TVertical> value)
		{
			double xMin = HorizontalToDoubleConverter(value.XMin);
			double xMax = HorizontalToDoubleConverter(value.XMax);
			double yMin = VerticalToDoubleConverter(value.YMin);
			double yMax = VerticalToDoubleConverter(value.YMax);

			return new DataRect(new Point(xMin, yMin), new Point(xMax, yMax));
		}

		private GenericRect<THorizontal, TVertical> CreateGenericRect(DataRect rect)
		{
			double xMin = rect.XMin;
			double xMax = rect.XMax;
			double yMin = rect.YMin;
			double yMax = rect.YMax;

			GenericRect<THorizontal, TVertical> res = new GenericRect<THorizontal, TVertical>(
				DoubleToHorizontalConverter(xMin),
				DoubleToVerticalConverter(yMin),
				DoubleToHorizontalConverter(xMax),
				DoubleToVerticalConverter(yMax));

			return res;
		}

	}
}
