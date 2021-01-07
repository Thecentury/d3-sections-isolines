namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System.Windows;

	public class ColumnChart : ColumnChartBase
	{
		protected override void SetCommonBindings(FrameworkElement marker)
		{
			base.SetCommonBindings(marker);

			marker.SetValue(ViewportPanel.YProperty, 0.0);
			marker.SetBinding(ViewportPanel.ViewportHeightProperty, DependentValueBinding);
			marker.SetBinding(ViewportPanel.ViewportWidthProperty, ColumnWidthBinding);
			marker.SetValue(ViewportPanel.ViewportVerticalAlignmentProperty, VerticalAlignment.Bottom);
			marker.SetBinding(ViewportPanel.XProperty, IndexBinding);
		}
	}
}
