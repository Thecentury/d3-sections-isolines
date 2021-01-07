namespace Microsoft.Research.DynamicDataDisplay.Common.Auxiliary
{
	using System;
	using System.Windows.Threading;

	public static class DispatcherExtensions
	{
		public static DispatcherOperation BeginInvoke(this Dispatcher dispatcher, Action action)
		{
			return dispatcher.BeginInvoke(action);
		}

		public static DispatcherOperation BeginInvoke(this Dispatcher dispatcher, Action action, DispatcherPriority priority)
		{
			return dispatcher.BeginInvoke(action, priority);
		}

		public static void Invoke(this Dispatcher dispatcher, Action action, DispatcherPriority priority)
		{
			dispatcher.Invoke(action, priority);
		}
	}
}
