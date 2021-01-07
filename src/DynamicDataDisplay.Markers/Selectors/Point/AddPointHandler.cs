﻿namespace Microsoft.Research.DynamicDataDisplay.Charts.Selectors
{
	using System;
	using System.Windows.Input;

	public class AddPointHandler : PointSelectorModeHandler
	{
		private PointSelector selector;
		private MouseClickWrapper leftButtonClickWrapper;
		private Plotter2D plotter;
		protected override void AttachCore(PointSelector selector, Plotter plotter)
		{
			if (selector == null)
				throw new ArgumentNullException("selector");
			if (plotter == null)
				throw new ArgumentNullException("plotter");

			this.selector = selector;
			this.plotter = (Plotter2D)plotter;

			leftButtonClickWrapper = new MouseClickWrapper(plotter.CentralGrid, MouseButton.Left);
			leftButtonClickWrapper.Click += OnLeftButtonClick;
		}

		protected override void DetachCore()
		{
			leftButtonClickWrapper.Click -= OnLeftButtonClick;
			leftButtonClickWrapper.Unsubscribe();
		}

		#region Click processing

		private void OnLeftButtonClick(object sender, MouseButtonEventArgs e)
		{
			var transform = plotter.Viewport.Transform;
			var newPoint = e.GetPosition(plotter.CentralGrid).ScreenToViewport(transform);

			if (selector.AddPointCommand.CanExecute(newPoint))
			{
				selector.AddPointCommand.Execute(newPoint);
			}

			//plotter.UndoProvider.AddAction(new CollectionAddAction<Point>(selector.Points, newPoint));
		}

		#endregion // end of Click processing
	}
}
