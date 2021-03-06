﻿namespace Microsoft.Research.DynamicDataDisplay.Common
{
	using System;
	using System.Windows;
	using System.Windows.Controls;

	internal sealed class NotifyingStackPanel : StackPanel, INotifyingPanel
	{
		#region INotifyingPanel Members

		private NotifyingUIElementCollection notifyingChildren;
		public NotifyingUIElementCollection NotifyingChildren => notifyingChildren;

		protected override UIElementCollection CreateUIElementCollection(FrameworkElement logicalParent)
		{
			notifyingChildren = new NotifyingUIElementCollection(this, logicalParent);
			ChildrenCreated.Raise(this);

			return notifyingChildren;
		}

		public event EventHandler ChildrenCreated;

		#endregion

		public override string ToString()
		{
			return typeof(NotifyingStackPanel).Name + " Name: " + Name;
		}
	}
}
