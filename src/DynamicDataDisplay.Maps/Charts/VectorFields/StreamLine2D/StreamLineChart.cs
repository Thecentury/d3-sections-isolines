namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields.Streamlines
{
	using System.Windows;
	using System.Windows.Markup;
	using System.Windows.Threading;
	using Microsoft.Research.DynamicDataDisplay.Common.Auxiliary;
	using Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields.Convolution;

	[ContentProperty("Pattern")]
	public class StreamLineChart : StreamLineChartBase
	{
		static StreamLineChart()
		{
			LineLengthFactorProperty.OverrideMetadata(typeof(StreamLineChart), new FrameworkPropertyMetadata(3.0));
		}

		private PointSetPattern pattern = new XPattern();
		public PointSetPattern Pattern
		{
			get => pattern;
			set => pattern = value;
		}


		protected override void RebuildUICore()
		{
			Pattern.PointsCount = LinesCount;
			foreach (var point in Pattern.GeneratePoints())
			{
				Point p = point;
				Dispatcher.BeginInvoke(() =>
				{
					DrawLine(p);
				}, DispatcherPriority.Background);
			}
		}
	}
}
