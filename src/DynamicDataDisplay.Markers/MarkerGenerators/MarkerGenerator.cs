﻿namespace DynamicDataDisplay.Markers
{
	using System;
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay;
	using Microsoft.Research.DynamicDataDisplay.Charts;
	using Microsoft.Research.DynamicDataDisplay.Common;

	public abstract class MarkerGenerator : FrameworkElement, IDisposable
	{
		static MarkerGenerator()
		{
			Type thisType = typeof(MarkerGenerator);
			LiveToolTipService.IsPropertyProxyProperty.OverrideMetadata(thisType, new FrameworkPropertyMetadata(true));
		}

		public virtual bool IsReady => true;

		public virtual FrameworkElement CreateMarker(object dataItem)
		{
			FrameworkElement marker = null;
			if (pool.Count > 0)
			{
				marker = pool.Get();
			}
			else
			{
				marker = CreateMarkerCore(dataItem);
			}

			// todo properly use binding to set a DataContext.
			marker.DataContext = dataItem;

			return marker;
		}

		protected virtual FrameworkElement CreateMarkerCore(object dataItem) { throw new NotImplementedException(); }

		protected void RaiseChanged()
		{
			Changed.Raise(this);
		}
		public event EventHandler Changed;

		private readonly ResourcePool<FrameworkElement> pool = new ResourcePool<FrameworkElement>();
		public virtual void Release(FrameworkElement marker)
		{
			pool.Put(marker);
		}

		#region IDisposable Members

		public void Dispose()
		{
			pool.Clear();
		}

		#endregion
	}
}
