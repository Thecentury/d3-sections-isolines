namespace Microsoft.Research.DynamicDataDisplay.Charts.Selectors
{
	using System.Windows;
	using System.Windows.Input;

	public class TwoClicksHandler : RectangleSelectorModeHandler
	{
		protected override void AttachCore(RectangleSelector selector, Plotter plotter)
		{
			base.AttachCore(selector, plotter);
			Plotter.CentralGrid.MouseUp += CentralGrid_MouseUp;
		}

		protected override void DetachCore()
		{
			Plotter.CentralGrid.MouseUp -= CentralGrid_MouseUp;
			base.DetachCore();
		}

		private int clickIndex;
		private Point firstPoint;
		private void CentralGrid_MouseUp(object sender, MouseButtonEventArgs e)
		{
			clickIndex++;

			Point mousePos = e.GetPosition(Plotter.CentralGrid);

			if (clickIndex % 2 == 1)
			{
				firstPoint = mousePos;
			}
			else
			{
				var transform = Plotter.Transform;
				Selector.SelectedRectangle = new DataRect(mousePos.ScreenToData(transform), firstPoint.ScreenToData(transform));
			}
		}
	}
}
