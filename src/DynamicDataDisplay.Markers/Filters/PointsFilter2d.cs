namespace Microsoft.Research.DynamicDataDisplay.Charts.Filters
{
	using System;
	using System.Collections.Generic;
	using System.Windows;
	using System.Windows.Threading;
	using global::DynamicDataDisplay.Markers.DataSources;
	using Microsoft.Research.DynamicDataDisplay.Common.Auxiliary;
	using Microsoft.Research.DynamicDataDisplay.Filters;

	public abstract class PointsFilter2d : DependencyObject, IDisposable, IWeakEventListener
	{
		private IDataSourceEnvironment environment;
		protected internal IDataSourceEnvironment Environment
		{
			get => environment;
			set
			{
				environment = value;

				environment.Plotter.Dispatcher.Invoke(() =>
				{
					Viewport = environment.Plotter.Viewport;
				}, DispatcherPriority.Send);
			}
		}

		private Viewport2D viewport;
		protected Viewport2D Viewport
		{
			get => viewport;
			set
			{
				if (viewport != value)
				{
					viewport = value;
					// Use weak events to prevent memory leak. Fast, but not best solution
					ExtendedPropertyChangedEventManager.AddListener(viewport, this);
				}

				viewport.Dispatcher.Invoke(() =>
				{
					Visible = viewport.Visible;
					Output = viewport.Output;
					Transform = viewport.Transform;
				}, DispatcherPriority.Send);
			}
		}

		protected virtual void OnViewportPropertyChanged(ExtendedPropertyChangedEventArgs e) { }

		protected CoordinateTransform Transform { get; private set; }

		protected DataRect Visible { get; private set; }

		protected Rect Output { get; private set; }

		protected static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			PointsFilter2d filter = (PointsFilter2d)d;
			filter.RaiseChanged();
		}

		protected void RaiseChanged()
		{
			Changed.Raise(this);
		}

		protected internal event EventHandler Changed;

		protected internal abstract IEnumerable<IndexWrapper<Point>> Filter(IEnumerable<IndexWrapper<Point>> series);

		#region IDisposable Members

        public void Dispose() // Do this method ever called?
		{
            ExtendedPropertyChangedEventManager.RemoveListener(viewport, this);
		}

		#endregion

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(ExtendedPropertyChangedEventManager))
            {
                OnViewportPropertyChanged((ExtendedPropertyChangedEventArgs)e);
                return true;
            }
            return false;
        }

        #endregion
    }

    public class ExtendedPropertyChangedEventManager : WeakEventManager
    {
        private ExtendedPropertyChangedEventManager() { }

        public static void AddListener(Viewport2D vp, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(vp, listener);
        }

        public static void RemoveListener(Viewport2D vp, IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(vp, listener);
        }

        protected override void StartListening(object source)
        {
            Viewport2D vp = (Viewport2D)source;
            vp.PropertyChanged += ViewportPropertyChanged;
        }

        void ViewportPropertyChanged(object sender, ExtendedPropertyChangedEventArgs e)
        {
            DeliverEvent(sender, e);
        }

        protected override void StopListening(object source)
        {
            Viewport2D vp = (Viewport2D)source;
            vp.PropertyChanged -= ViewportPropertyChanged; 
        }

        private static ExtendedPropertyChangedEventManager CurrentManager
        {
            get
            {
                Type managerType = typeof(ExtendedPropertyChangedEventManager);
                ExtendedPropertyChangedEventManager manager = (ExtendedPropertyChangedEventManager)GetCurrentManager(managerType);
                if (manager == null)
                {
                    manager = new ExtendedPropertyChangedEventManager();
                    SetCurrentManager(managerType, manager);
                }
                return manager;
            }
        }
    }
}
