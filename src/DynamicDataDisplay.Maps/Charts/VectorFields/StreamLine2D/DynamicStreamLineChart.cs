namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields.Streamlines
{
	using System.Windows;
	using System.Windows.Input;
	using System.Windows.Media;

	public class DynamicStreamLineChart : StreamLineChartBase
	{
		static DynamicStreamLineChart()
		{
			LineStrokeProperty.OverrideMetadata(typeof(DynamicStreamLineChart), new FrameworkPropertyMetadata(Brushes.Plum));
			LineThicknessProperty.OverrideMetadata(typeof(DynamicStreamLineChart), new FrameworkPropertyMetadata(2.0));
		}

		public override void OnPlotterAttached(Plotter plotter)
		{
			base.OnPlotterAttached(plotter);

			plotter.CentralGrid.MouseMove += CentralGrid_MouseMove;
		}

		private void CentralGrid_MouseMove(object sender, MouseEventArgs e)
		{
			Point dataPosition = e.GetPosition(Plotter.CentralGrid).ScreenToData(Plotter.Transform);

			double x = (dataPosition.X - bounds.XMin) / bounds.Width;
			double y = (dataPosition.Y - bounds.YMin) / bounds.Height;

			if (0 <= x && x <= 1 && 0 <= y && y <= 1)
				point = new Point(x, y);
			else
				point = null;

			RebuildUI();
		}

		public override void OnPlotterDetaching(Plotter plotter)
		{
			plotter.CentralGrid.MouseMove -= CentralGrid_MouseMove;

			base.OnPlotterDetaching(plotter);
		}

		Point? point;
		protected override void RebuildUICore()
		{
			if (point == null)
				return;

			DrawLine(point.Value);
		}
	}
}
