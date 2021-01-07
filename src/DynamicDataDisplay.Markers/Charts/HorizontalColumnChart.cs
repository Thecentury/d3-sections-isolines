namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System.Windows;

	public class HorizontalColumnChart : ColumnChartBase
	{
		protected override void SetCommonBindings(FrameworkElement marker)
		{
			base.SetCommonBindings(marker);

			marker.SetValue(ViewportPanel.XProperty, 0.0);
			marker.SetBinding(ViewportPanel.ViewportWidthProperty, DependentValueBinding);
			marker.SetBinding(ViewportPanel.ViewportHeightProperty, ColumnWidthBinding);
			marker.SetValue(ViewportPanel.ViewportHorizontalAlignmentProperty, HorizontalAlignment.Left);
			marker.SetBinding(ViewportPanel.YProperty, IndexBinding);
		}
	}
}
