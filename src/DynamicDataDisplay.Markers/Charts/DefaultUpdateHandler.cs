namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System.Collections.Specialized;

	public class DefaultUpdateHandler : DataSourceUpdateHandler
	{
		public override void OnUpdate(NotifyCollectionChangedEventArgs e, PointChartBase chart)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					chart.OnAdded(e);
					break;
				case NotifyCollectionChangedAction.Move:
					chart.OnMoved(e);
					break;
				case NotifyCollectionChangedAction.Remove:
					chart.OnRemoved(e);
					break;
				case NotifyCollectionChangedAction.Replace:
					chart.OnReplaced(e);
					break;
				case NotifyCollectionChangedAction.Reset:
					chart.OnReset();
					break;
			}
		}
	}
}
