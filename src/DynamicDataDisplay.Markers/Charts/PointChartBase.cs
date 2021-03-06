﻿namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System;
	using System.Collections.Specialized;
	using System.ComponentModel;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Data;
	using global::DynamicDataDisplay.Markers.DataSources;
	using global::DynamicDataDisplay.Markers.DataSources.DataSourceFactories;
	using Microsoft.Research.DynamicDataDisplay.Charts.Filters;
	using Microsoft.Research.DynamicDataDisplay.Common;
	using Microsoft.Research.DynamicDataDisplay.Common.Auxiliary;

	public abstract class PointChartBase : ContentControl, IPlotterElement
	{
		static PointChartBase()
		{
			//var store = LegendItemFactoryStore.Current;
			//store.RegisterFactory(new PieChartLegendItemFactory());
			//store.RegisterFactory(new MarkerChartLegendItemFactory());
		}

		private DefaultUpdateHandler defaultUpdateHandler = new DefaultUpdateHandler();
		private BoundsUnionMode boundsUnionMode;

		protected PointChartBase()
		{
			AttachToItemsPanel();

			filters.CollectionChanged += filters_CollectionChanged;

		}

		protected void AttachToItemsPanel()
		{
			currentItemsPanel = (Panel)ItemsPanel.LoadContent();
			currentItemsPanel.IsItemsHost = false;

			var notifyingChildren = currentItemsPanel.Children as INotifyCollectionChanged;
			if (notifyingChildren != null)
			{
				notifyingChildren.CollectionChanged += OnItemsCollectionChanged;
			}

			if (currentItemsPanel is ViewportHostPanel)
			{
				var viewportItemsPanel = (ViewportHostPanel)currentItemsPanel;
				viewportItemsPanel.IsMarkersHost = true;
				viewportItemsPanel.ContentBoundsChanged += viewportItemsPanel_ContentBoundsChanged;

				this.Content = viewportItemsPanel.HostingCanvas;

				if (plotter != null)
				{
					viewportItemsPanel.OnPlotterAttached(plotter);
				}
			}

			else
			{
				this.Content = currentItemsPanel;
			}
		}

		void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			ItemsChanged.Raise(this, e);
		}

		private void viewportItemsPanel_ContentBoundsChanged(object sender, EventArgs e)
		{
			var contentBounds = Viewport2D.GetContentBounds(currentItemsPanel);
			Viewport2D.SetContentBounds(this, contentBounds);
		}

		public BoundsUnionMode BoundsUnionMode
		{
			get => boundsUnionMode;
			set
			{
				boundsUnionMode = value;
				ViewportHostPanel panel = CurrentItemsPanel as ViewportHostPanel;
				if (panel != null)
				{
					panel.BoundsUnionMode = value;
				}
			}
		}

		protected void ForceUpdateContentBounds()
		{
			ViewportHostPanel viewportPanel = CurrentItemsPanel as ViewportHostPanel;
			if (viewportPanel != null)
			{
				viewportPanel.UpdateContentBounds();
			}
		}

		protected void DetachFromItemsPanel()
		{
			ViewportHostPanel viewportItemsPanel = currentItemsPanel as ViewportHostPanel;
			if (viewportItemsPanel != null)
			{
				viewportItemsPanel.ContentBoundsChanged -= viewportItemsPanel_ContentBoundsChanged;
			}
			if (viewportItemsPanel != null && plotter != null)
			{
				viewportItemsPanel.OnPlotterDetaching(plotter);
			}

			var notifyingChildren = currentItemsPanel.Children as INotifyCollectionChanged;
			if (notifyingChildren != null)
			{
				notifyingChildren.CollectionChanged -= OnItemsCollectionChanged;
			}

			Content = null;
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public UIElementCollection Items => currentItemsPanel.Children;

		public event NotifyCollectionChangedEventHandler ItemsChanged;

		#region IPlotterElement Members

		private Plotter2D plotter;
		public virtual void OnPlotterAttached(Plotter plotter)
		{
			this.plotter = (Plotter2D)plotter;
			this.plotter.Viewport.PropertyChanged += Viewport_PropertyChanged;

			var viewportRectPanel = currentItemsPanel as ViewportHostPanel;
			if (viewportRectPanel != null)
			{
				viewportRectPanel.OnPlotterAttached(plotter);
			}

			plotter.CentralGrid.Children.Add(this);

			var updateHandler = GetUpdateHandler();
			updateHandler.OnPlotterAttached(this.plotter, this);
		}

		private void Viewport_PropertyChanged(object sender, ExtendedPropertyChangedEventArgs e)
		{
			OnViewportPropertyChanged(e);
		}

		protected virtual void OnViewportPropertyChanged(ExtendedPropertyChangedEventArgs e) { }

		void IPlotterElement.OnPlotterDetaching(Plotter plotter)
		{
			var updateHandler = GetUpdateHandler();
			updateHandler.OnPlotterDetached(this.plotter, this);

			OnPlotterDetaching(this.plotter);

			var viewportItemsPanel = currentItemsPanel as ViewportHostPanel;
			if (viewportItemsPanel != null)
			{
				viewportItemsPanel.OnPlotterDetaching(plotter);
			}

			plotter.CentralGrid.Children.Remove(this);

			this.plotter.Viewport.PropertyChanged -= Viewport_PropertyChanged;
			this.plotter = null;
		}

		protected virtual void OnPlotterDetaching(Plotter2D plotter) { }

		public Plotter2D Plotter => plotter;

		Plotter IPlotterElement.Plotter => plotter;

		#endregion

		#region Properties

		private Panel currentItemsPanel;
		public Panel CurrentItemsPanel => currentItemsPanel;

		#region PanelTemplate

		[Bindable(false)]
		public ItemsPanelTemplate ItemsPanel
		{
			get => (ItemsPanelTemplate)GetValue(PanelTemplateProperty);
			set => SetValue(PanelTemplateProperty, value);
		}

		public static readonly DependencyProperty PanelTemplateProperty = DependencyProperty.Register(
		  "ItemsPanel",
		  typeof(ItemsPanelTemplate),
		  typeof(PointChartBase),
		  new FrameworkPropertyMetadata(GetDefaultItemsPanelTemplate(), OnItemsPanelTemplateChanged));

		private static ItemsPanelTemplate GetDefaultItemsPanelTemplate()
		{
			var root = new FrameworkElementFactory(typeof(ViewportHostPanel));
			ItemsPanelTemplate template = new ItemsPanelTemplate(root);
			template.Seal();
			return template;
		}

		private static void OnItemsPanelTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			PointChartBase chart = (PointChartBase)d;
			if (e.NewValue != null)
			{
				chart.OnItemsPanelChanged();
			}
		}

		protected virtual void OnItemsPanelChanged()
		{
			DetachFromItemsPanel();
			AttachToItemsPanel();
		}

		#endregion

		#region ItemsSource

		public object ItemsSource
		{
			get => GetValue(ItemsSourceProperty);
			set => SetValue(ItemsSourceProperty, value);
		}

		public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
		  "ItemsSource",
		  typeof(object),
		  typeof(PointChartBase),
		  new FrameworkPropertyMetadata(null, OnItemsSourceReplaced));

		private static void OnItemsSourceReplaced(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			PointChartBase chart = (PointChartBase)d;
			chart.OnItemsSourceReplaced(e);
		}

		protected virtual void OnItemsSourceReplaced(DependencyPropertyChangedEventArgs e)
		{
			object itemsSource = e.NewValue;

			if (itemsSource != null)
			{
				var store = DataSourceFactoryStore.Current;
				var dataSource = store.BuildDataSource(itemsSource);

				if (dataSource != null)
				{
					DataSource = dataSource;
				}
			}
			else
			{
				DataSource = null;
			}
		}

		#endregion // ItemsSource

		#region DataSource

		public PointDataSourceBase DataSource
		{
			get => (PointDataSourceBase)GetValue(DataSourceProperty);
			set => SetValue(DataSourceProperty, value);
		}

		public static readonly DependencyProperty DataSourceProperty = DependencyProperty.Register(
		  "DataSource",
		  typeof(PointDataSourceBase),
		  typeof(PointChartBase),
		  new FrameworkPropertyMetadata(null, OnDataSourceReplaced));

		private static void OnDataSourceReplaced(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			PointChartBase owner = (PointChartBase)d;
			owner.OnDataSourceReplaced((PointDataSourceBase)e.OldValue, (PointDataSourceBase)e.NewValue);
		}

		protected virtual void OnDataSourceReplaced(PointDataSourceBase prevSource, PointDataSourceBase currSource)
		{
			if (prevSource != null)
			{
				prevSource.CollectionChanged -= OnDataSourceChanged;
				prevSource.DataPrepaired -= DataSource_OnDataPrepaired;
			}
			if (currSource != null)
			{
				currSource.CollectionChanged += OnDataSourceChanged;
				currSource.DataPrepaired += DataSource_OnDataPrepaired;

				currSource.Filters.AddMany(filters);
			}

			RaiseDataSourceReplaced(prevSource, currSource);
		}

		protected virtual void DataSource_OnDataPrepaired(object sender, EventArgs e) { }

		private void RaiseDataSourceReplaced(PointDataSourceBase prevSource, PointDataSourceBase currSource)
		{
			DataSourceReplaced.Raise(this, prevSource, currSource);
		}

		public event EventHandler<ValueChangedEventArgs<PointDataSourceBase>> DataSourceReplaced;

		private void OnDataSourceChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			OnDataSourceChanged(e);
		}

		protected DefaultUpdateHandler DefaultUpdateHandler => defaultUpdateHandler;

		protected virtual DataSourceUpdateHandler GetUpdateHandler()
		{
			return defaultUpdateHandler;
		}

		protected virtual void OnDataSourceChanged(NotifyCollectionChangedEventArgs e) { }

		#region DataSource update handlers

		protected internal virtual void OnAdded(NotifyCollectionChangedEventArgs e) { }

		protected internal virtual void OnReplaced(NotifyCollectionChangedEventArgs e) { }

		protected internal virtual void OnRemoved(NotifyCollectionChangedEventArgs e) { }

		protected internal virtual void OnMoved(NotifyCollectionChangedEventArgs e) { }

		protected internal virtual void OnReset() { }

		#endregion // end of DataSource update handlers

		#endregion // DataSource

		#region Paths

		public string DependentValuePath
		{
			get => (string)GetValue(DependentValuePathProperty);
			set => SetValue(DependentValuePathProperty, value);
		}

		public static readonly DependencyProperty DependentValuePathProperty = DependencyProperty.Register(
		  "DependentValuePath",
		  typeof(string),
		  typeof(PointChartBase),
		  new FrameworkPropertyMetadata(null, OnDependentValueMappingChanged, CoerceDependentValuePath));

		private static void OnDependentValueMappingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			PointChartBase owner = (PointChartBase)d;

			string path = (string)e.NewValue;
			if (path == null)
			{
				owner.DependentValueBinding = null;
			}
			else if (owner.DependentValueBinding == null || owner.DependentValueBinding.Path.Path != path)
			{
				owner.DependentValueBinding = new Binding(path);
			}
		}

		private static object CoerceDependentValuePath(DependencyObject d, object value)
		{
			PointChartBase chart = (PointChartBase)d;

			string path = (string)value;

			if (!String.IsNullOrEmpty(path))
				return value;

			if (chart.dependentValueBinding != null)
				return chart.dependentValueBinding.Path.Path;

			return null;
		}

		private Binding dependentValueBinding;
		public Binding DependentValueBinding
		{
			get
			{
				if (dependentValueBinding == null && DependentValuePath != null)
				{
					dependentValueBinding = new Binding(DependentValuePath);
				}
				return dependentValueBinding;
			}
			set
			{
				if (dependentValueBinding != value)
				{
					this.dependentValueBinding = value;
					CoerceValue(DependentValuePathProperty);
					// todo refresh
				}
			}
		}

		public string IndependentValuePath
		{
			get => (string)GetValue(IndependentValuePathProperty);
			set => SetValue(IndependentValuePathProperty, value);
		}

		public static readonly DependencyProperty IndependentValuePathProperty = DependencyProperty.Register(
		  "IndependentValuePath",
		  typeof(string),
		  typeof(PointChartBase),
		  new FrameworkPropertyMetadata(null, OnIndependentValueMappingChanged, CoerceIndependentValuePath));

		private static object CoerceIndependentValuePath(DependencyObject d, object value)
		{
			PointChartBase chart = (PointChartBase)d;

			string path = (string)value;

			if (!String.IsNullOrEmpty(path))
				return value;

			if (chart.independentValueBinding != null)
				return chart.independentValueBinding.Path.Path;

			return null;
		}

		private static void OnIndependentValueMappingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			PointChartBase owner = (PointChartBase)d;

			string path = (string)e.NewValue;
			if (path == null)
				owner.IndependentValueBinding = null;
			else
				owner.IndependentValueBinding = new Binding(path);
		}

		private Binding independentValueBinding;
		public Binding IndependentValueBinding
		{
			get => independentValueBinding;
			set
			{
				if (independentValueBinding != value)
				{
					this.independentValueBinding = value;
					CoerceValue(IndependentValuePathProperty);
					// todo refresh
				}
			}
		}

		#endregion // Mappings

		#region Filters

		private readonly NewFilterCollection filters = new NewFilterCollection();
		public NewFilterCollection Filters => filters;

		private void filters_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Reset)
			{
				// todo is dirty.
				OnDataSourceChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
			}
			else
			{
				var dataSource = DataSource;
				if (dataSource != null)
				{
					using (dataSource.Filters.BlockEvents(true))
					{
						dataSource.Filters.ApplyChanges(e);
					}
				}
			}
		}

		#endregion // end of Filters

		#endregion

		#region Index attached property

		public static int GetIndex(DependencyObject obj)
		{
			return (int)obj.GetValue(IndexProperty);
		}

		protected static void SetIndex(DependencyObject obj, int value)
		{
			obj.SetValue(IndexPropertyKey, value);
		}

		private static readonly DependencyPropertyKey IndexPropertyKey = DependencyProperty.RegisterAttachedReadOnly(
		  "Index",
		  typeof(int),
		  typeof(PointChartBase),
		  new FrameworkPropertyMetadata(0));

		public static readonly DependencyProperty IndexProperty = IndexPropertyKey.DependencyProperty;

		#endregion // end of Index attached property

		#region Legend

		public object LegendDescription
		{
			get => NewLegend.GetDescription(this);
			set => NewLegend.SetDescription(this, value);
		}

		#endregion // end of Legend
	}
}
