namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System.Windows;
	using System.Windows.Media;

	/// <summary>
	/// Represents simple line bound to viewport coordinates.
	/// </summary>
	public abstract class SimpleLine : ViewportShape
	{
		/// <summary>
		/// Gets or sets the value of line - e.g., its horizontal or vertical coordinate.
		/// </summary>
		/// <value>The value.</value>
		public double Value
		{
			get => (double)GetValue(ValueProperty);
			set => SetValue(ValueProperty, value);
		}

		/// <summary>
		/// Identifies Value dependency property.
		/// </summary>
		public static readonly DependencyProperty ValueProperty =
			DependencyProperty.Register(
			  "Value",
			  typeof(double),
			  typeof(SimpleLine),
			  new PropertyMetadata(
				  0.0, OnValueChanged));

		private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			SimpleLine line = (SimpleLine)d;
			line.OnValueChanged();
		}

		protected virtual void OnValueChanged()
		{
			UpdateUIRepresentation();
		}

		private LineGeometry lineGeometry = new LineGeometry();
		protected LineGeometry LineGeometry => lineGeometry;

		protected override Geometry DefiningGeometry => lineGeometry;
	}
}
