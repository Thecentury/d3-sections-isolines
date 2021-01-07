namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System;
	using System.Windows;
	using System.Windows.Media;
	using System.Windows.Shapes;

	/// <summary>
	/// Represents a base class for simple shapes with viewport-bound coordinates.
	/// </summary>
	public abstract class ViewportShape : Shape, IPlotterElement
	{
		static ViewportShape()
		{
			Type type = typeof(ViewportShape);
			StrokeProperty.AddOwner(type, new FrameworkPropertyMetadata(Brushes.Blue));
			StrokeThicknessProperty.AddOwner(type, new FrameworkPropertyMetadata(2.0));
		}

		protected void UpdateUIRepresentation()
		{
			if (Plotter == null)
				return;

			UpdateUIRepresentationCore();
		}
		protected virtual void UpdateUIRepresentationCore() { }

		#region IPlotterElement Members

		private Plotter2D plotter;
		void IPlotterElement.OnPlotterAttached(Plotter plotter)
		{
			plotter.CentralGrid.Children.Add(this);

			Plotter2D plotter2d = (Plotter2D)plotter;
			this.plotter = plotter2d;
			plotter2d.Viewport.PropertyChanged += Viewport_PropertyChanged;

			UpdateUIRepresentation();
		}

		private void Viewport_PropertyChanged(object sender, ExtendedPropertyChangedEventArgs e)
		{
			OnViewportPropertyChanged(e);
		}

		protected virtual void OnViewportPropertyChanged(ExtendedPropertyChangedEventArgs e)
		{
			UpdateUIRepresentation();
		}

		void IPlotterElement.OnPlotterDetaching(Plotter plotter)
		{
			Plotter2D plotter2d = (Plotter2D)plotter;
			plotter2d.Viewport.PropertyChanged -= Viewport_PropertyChanged;
			plotter.CentralGrid.Children.Remove(this);

			this.plotter = null;
		}

		public Plotter2D Plotter => plotter;

		Plotter IPlotterElement.Plotter => plotter;

		#endregion
	}
}
