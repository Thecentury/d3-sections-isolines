namespace Microsoft.Research.DynamicDataDisplay
{
	using System;
	using System.Threading;
	using System.Windows.Controls.Primitives;

	public class PopupTip : Popup
	{
		private TimeSpan showDurationInerval = new TimeSpan(0, 0, 10);
		private Timer timer;

		public void ShowDelayed(TimeSpan delay)
		{
			if (timer != null)
				timer.Change((int)delay.TotalMilliseconds, Timeout.Infinite);
			else
				timer = new Timer(OnTimerFinished, null, (int)delay.TotalMilliseconds, Timeout.Infinite);
		}

		public void HideDelayed(TimeSpan delay)
		{
			if (timer != null)
			{
				timer.Change((int)delay.TotalMilliseconds, Timeout.Infinite);
			}
			else
				timer = new Timer(OnTimerFinished, null, (int)delay.TotalMilliseconds, Timeout.Infinite);
		}

		public void Hide()
		{
			if (timer != null)
			{
				timer.Change(Timeout.Infinite, Timeout.Infinite);
			}
			this.IsOpen = false;
		}

		private void OnTimerFinished(object state)
		{
			this.Dispatcher.BeginInvoke(new Action(() =>
				{
					bool show = !this.IsOpen;
					this.IsOpen = show;
					if (show)
						HideDelayed(showDurationInerval);
				}));
		}
	}
}
