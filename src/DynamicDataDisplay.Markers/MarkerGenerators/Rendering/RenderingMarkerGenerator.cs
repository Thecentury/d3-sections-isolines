namespace Microsoft.Research.DynamicDataDisplay.Markers.MarkerGenerators.Rendering
{
	using System.Windows;
	using System.Windows.Markup;
	using global::DynamicDataDisplay.Markers;

	[ContentProperty("RendererTemplate")]
	public class RenderingMarkerGenerator : MarkerGenerator
	{
		private MarkerRenderer cachedRenderer;

		public override FrameworkElement CreateMarker(object dataItem)
		{
			return cachedRenderer;
		}

		private bool isReady;
		public override bool IsReady => isReady;

		public DataTemplate RendererTemplate
		{
			get => (DataTemplate)GetValue(RendererTemplateProperty);
			set => SetValue(RendererTemplateProperty, value);
		}

		public static readonly DependencyProperty RendererTemplateProperty = DependencyProperty.Register(
		  "RendererTemplate",
		  typeof(DataTemplate),
		  typeof(RenderingMarkerGenerator),
		  new FrameworkPropertyMetadata(null, OnRendererTemplateChanged));

		private static void OnRendererTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			RenderingMarkerGenerator owner = (RenderingMarkerGenerator)d;
			owner.OnRendererTemplateChanged();
		}

		private void OnRendererTemplateChanged()
		{
			isReady = true;
			cachedRenderer = (MarkerRenderer)RendererTemplate.LoadContent();
			RaiseChanged();
		}
	}
}
