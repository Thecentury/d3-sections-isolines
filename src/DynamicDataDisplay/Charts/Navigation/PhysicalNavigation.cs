﻿namespace Microsoft.Research.DynamicDataDisplay.Charts.Navigation
{
	using System;
	using System.Windows;
	using System.Windows.Input;
	using System.Windows.Threading;

	public class PhysicalNavigation : IPlotterElement
	{
		private readonly DispatcherTimer timer;

		public PhysicalNavigation()
		{
			timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(30) };
			timer.Tick += timer_Tick;
		}

		DateTime startTime;
		private void timer_Tick(object sender, EventArgs e)
		{
			TimeSpan time = DateTime.Now - startTime;
			animation.UseMouse = isMouseDown;
			if (!isMouseDown)
			{
				animation.LiquidFrictionQuadraticCoeff = 1;
			}

			plotter.Viewport.Visible = animation.GetValue(time);
			if (animation.IsFinished && !isMouseDown)
			{
				timer.Stop();
			}
		}

		private bool isMouseDown;
		private PhysicalRectAnimation animation;
		private Point clickPos;
		private void OnMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
			{
				clickPos = e.GetPosition(plotter.CentralGrid);

				isMouseDown = true;
				startTime = DateTime.Now;

				animation = new PhysicalRectAnimation(
					plotter.Viewport,
					e.GetPosition(plotter.ViewportPanel));

				timer.Start();
			}
		}

		private void OnMouseUp(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
			{
				isMouseDown = false;
				if (clickPos == e.GetPosition(plotter.CentralGrid))
				{
					timer.Stop();
					animation = null;
				}
				else
				{
					if (animation.IsFinished)
					{
						timer.Stop();
						animation = null;
					}
					else
					{
						animation.UseMouse = false;
						animation.LiquidFrictionQuadraticCoeff = 1;
					}
				}
			}
		}

		#region IPlotterElement Members

		private Plotter2D plotter;
		void IPlotterElement.OnPlotterAttached(Plotter plotter)
		{
			this.plotter = (Plotter2D)plotter;

			Mouse.AddPreviewMouseDownHandler(plotter.CentralGrid, OnMouseDown);
			Mouse.AddPreviewMouseUpHandler(plotter.CentralGrid, OnMouseUp);
			plotter.CentralGrid.MouseLeave += CentralGrid_MouseLeave;
		}

		private void CentralGrid_MouseLeave(object sender, MouseEventArgs e)
		{
			isMouseDown = false;
		}

		void IPlotterElement.OnPlotterDetaching(Plotter plotter)
		{
			plotter.CentralGrid.MouseLeave -= CentralGrid_MouseLeave;
			Mouse.RemovePreviewMouseDownHandler(plotter.CentralGrid, OnMouseDown);
			Mouse.RemovePreviewMouseUpHandler(plotter.CentralGrid, OnMouseUp);

			this.plotter = null;
		}

		Plotter IPlotterElement.Plotter => plotter;

		#endregion
	}
}
