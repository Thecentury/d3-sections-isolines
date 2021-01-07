﻿namespace Microsoft.Research.DynamicDataDisplay.Charts.Selectors
{
	using System.Windows;
	using System.Windows.Input;

	public class ClickAndDragHandler : RectangleSelectorModeHandler
	{
		private Point firstPoint;
		private bool mousePressed;

		protected override void AttachCore(RectangleSelector selector, Plotter plotter)
		{
			base.AttachCore(selector, plotter);

			Plotter.CentralGrid.MouseLeftButtonDown += OnMouseLeftButtonDown;
			Plotter.CentralGrid.MouseLeftButtonUp += OnMouseLeftButtonUp;
			Plotter.CentralGrid.MouseMove += OnMouseMove;
		}

		protected override void DetachCore()
		{
			Plotter.CentralGrid.MouseLeftButtonDown -= OnMouseLeftButtonDown;
			Plotter.CentralGrid.MouseLeftButtonUp -= OnMouseLeftButtonUp;
			Plotter.CentralGrid.MouseMove -= OnMouseMove;

			base.DetachCore();
		}

		private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			var secondPoint = e.GetPosition(Plotter.CentralGrid);
			if (secondPoint != firstPoint)
			{
				var transform = Plotter.Transform;
				Selector.SelectedRectangle = new DataRect(firstPoint.ScreenToViewport(transform), secondPoint.ScreenToViewport(transform));
				e.Handled = true;
			}
			mousePressed = false;
		}

		private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			firstPoint = e.GetPosition(Plotter.CentralGrid);
			e.Handled = true;
			mousePressed = true;
		}

		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			if (!mousePressed)
				return;

			var secondPoint = e.GetPosition(Plotter.CentralGrid);
			if (secondPoint != firstPoint)
			{
				var transform = Plotter.Transform;
				Selector.SelectedRectangle = new DataRect(firstPoint.ScreenToViewport(transform), secondPoint.ScreenToViewport(transform));
				e.Handled = true;
			}
		}
	}
}
