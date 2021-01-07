namespace Microsoft.Research.DynamicDataDisplay.Common
{
	using System;

	internal interface INotifyingPanel
	{
		NotifyingUIElementCollection NotifyingChildren { get; }
		event EventHandler ChildrenCreated;
	}
}
