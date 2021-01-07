namespace Microsoft.Research.DynamicDataDisplay.Common
{
	using System;
	using System.Windows;

	public class PlotterChangedEventArgs : RoutedEventArgs
	{
		public PlotterChangedEventArgs(Plotter prevPlotter, Plotter currPlotter, RoutedEvent routedEvent) : base(routedEvent)
		{
			if (prevPlotter == null && currPlotter == null) {
				throw new ArgumentException("Both Plotters cannot be null.");
			}

			this.prevPlotter = prevPlotter;
			this.currPlotter = currPlotter;
		}

		private readonly Plotter prevPlotter;
		public Plotter PreviousPlotter => prevPlotter;

		private readonly Plotter currPlotter;
		public Plotter CurrentPlotter => currPlotter;
	}
}
