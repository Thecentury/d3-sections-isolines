﻿namespace Microsoft.Research.DynamicDataDisplay
{
	using System;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Data;
	using System.Windows.Threading;
	using Microsoft.Research.DynamicDataDisplay.Common;

	[SkipPropertyCheck]
	public class InjectedPlotter : ChartPlotter, IPlotterElement
	{
		public InjectedPlotter()
			: base(PlotterLoadMode.Empty)
		{
			ViewportPanel = new Canvas();
			Grid.SetColumn(ViewportPanel, 1);
			Grid.SetRow(ViewportPanel, 1);

			Viewport = new Viewport2D(ViewportPanel, this);
		}

		protected override void OnChildAdded(IPlotterElement child)
		{
			base.OnChildAdded(child);

			if (plotter != null)
			{
				plotter.PerformChildChecks = false;
				try
				{
					plotter.Children.Add(child);
				}
				finally
				{
					plotter.PerformChildChecks = true;
				}
			}
		}

		protected override void OnChildRemoving(IPlotterElement child)
		{
			base.OnChildRemoving(child);

			if (plotter != null)
			{
				plotter.PerformChildChecks = false;
				try
				{
					plotter.Children.Remove(child);
				}
				finally
				{
					plotter.PerformChildChecks = true;
				}
			}
		}

		public void SetHorizontalTransform(double parentMin, double childMin, double parentMax, double childMax)
		{
			converter.SetHorizontalTransform(parentMin, childMin, parentMax, childMax);
		}

		public void SetVerticalTransform(double parentMin, double childMin, double parentMax, double childMax)
		{
			converter.SetVerticalTransform(parentMin, childMin, parentMax, childMax);
		}

		private IValueConverter viewportBindingConverter;
		public IValueConverter ViewportBindingConverter
		{
			get => viewportBindingConverter;
			set
			{
				viewportBindingConverter = value;
				if (viewportBinding != null)
				{
					viewportBinding.Converter = value;
				}
			}
		}

		private bool setViewportBinding = true;
		public bool SetViewportBinding
		{
			get => setViewportBinding;
			set
			{
				if (setViewportBinding != value)
				{
					setViewportBinding = value;
					UpdateViewportBinding();
				}
			}
		}

		private void UpdateViewportBinding()
		{
			if (plotter == null) return;

			if (setViewportBinding)
			{
				var converter = viewportBindingConverter ?? this.converter;
				viewportBinding = new Binding
				{
					Path = new PropertyPath("Visible"),
					Source = this.plotter.Viewport,
					Converter = converter,
					Mode = BindingMode.TwoWay
				};
				this.Viewport.SetBinding(Viewport2D.VisibleProperty, viewportBinding);
			}
			else
			{
				BindingOperations.ClearBinding(Viewport, Viewport2D.VisibleProperty);
			}
		}

		#region IPlotterElement Members

		Binding viewportBinding;
		ScaleConverter converter = new ScaleConverter();
		void IPlotterElement.OnPlotterAttached(Plotter plotter)
		{
			this.plotter = (Plotter2D)plotter;

			UpdateViewportBinding();

			plotter.MainGrid.Children.Add(ViewportPanel);

			HeaderPanel = plotter.HeaderPanel;
			FooterPanel = plotter.FooterPanel;

			LeftPanel = plotter.LeftPanel;
			BottomPanel = plotter.BottomPanel;
			RightPanel = plotter.RightPanel;
			TopPanel = plotter.BottomPanel;

			MainCanvas = plotter.MainCanvas;
			CentralGrid = plotter.CentralGrid;
			MainGrid = plotter.MainGrid;
			ParallelCanvas = plotter.ParallelCanvas;

			Dispatcher.BeginInvoke((Action)(() => ExecuteWaitingChildrenAdditions()), DispatcherPriority.Background);

			OnLoaded();
		}

		protected override bool IsLoadedInternal => plotter != null;

		void IPlotterElement.OnPlotterDetaching(Plotter plotter)
		{
			plotter.MainGrid.Children.Remove(ViewportPanel);
			BindingOperations.ClearBinding(this.Viewport, Viewport2D.VisibleProperty);

			this.plotter = null;
		}

		private Plotter2D plotter;
		public Plotter2D Plotter => plotter;

		Plotter IPlotterElement.Plotter => plotter;

		#endregion
	}
}
