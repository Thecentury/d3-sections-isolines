namespace Microsoft.Research.DynamicDataDisplay.Charts.Shapes
{
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Data;

	public class TemplateableDraggablePoint : DraggablePoint
	{
		private readonly Control marker = new Control { Focusable = false };
		public TemplateableDraggablePoint()
		{
			marker.SetBinding(TemplateProperty, new Binding { Source = this, Path = new PropertyPath("MarkerTemplate") });
			Content = marker;	
		}

		public ControlTemplate MarkerTemplate
		{
			get => (ControlTemplate)GetValue(MarkerTemplateProperty);
			set => SetValue(MarkerTemplateProperty, value);
		}

		public static readonly DependencyProperty MarkerTemplateProperty = DependencyProperty.Register(
		  "MarkerTemplate",
		  typeof(ControlTemplate),
		  typeof(TemplateableDraggablePoint),
		  new FrameworkPropertyMetadata(null));

	}
}
