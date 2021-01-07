namespace Microsoft.Research.DynamicDataDisplay.Common
{
	using System.Windows;

	public static class PlotterEvents
	{
		internal static void Notify(FrameworkElement target, PlotterChangedEventArgs args)
		{
			plotterAttachedEvent.Notify(target, args);
			plotterChangedEvent.Notify(target, args);
			plotterDetachingEvent.Notify(target, args);
		}

		private static readonly PlotterEventHelper plotterAttachedEvent = new PlotterEventHelper(Plotter.PlotterAttachedEvent);
		public static PlotterEventHelper PlotterAttachedEvent => plotterAttachedEvent;

		private static readonly PlotterEventHelper plotterDetachingEvent = new PlotterEventHelper(Plotter.PlotterDetachingEvent);
		public static PlotterEventHelper PlotterDetachingEvent => plotterDetachingEvent;

		private static readonly PlotterEventHelper plotterChangedEvent = new PlotterEventHelper(Plotter.PlotterChangedEvent);
		public static PlotterEventHelper PlotterChangedEvent => plotterChangedEvent;
	}
}
