﻿namespace Microsoft.Research.DynamicDataDisplay.Controls
{
	using System.Windows;
	using System.Windows.Input;
	using Microsoft.Research.DynamicDataDisplay.Charts.Navigation;

	public sealed class SelectorAxisNavigation : AxisNavigation
	{
		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			Point mousePosition = e.GetPosition(ListeningPanel);
			if (mousePosition == LmbInitialPosition)
			{
				RaiseMouseLeftButtonClick(e);
			}
			base.OnMouseLeftButtonUp(e);
		}

		private void RaiseMouseLeftButtonClick(MouseButtonEventArgs e)
		{
			if (MouseLeftButtonClick != null)
			{
				MouseLeftButtonClick(this, e);
			}
		}

		public event MouseButtonEventHandler MouseLeftButtonClick;
	}
}
