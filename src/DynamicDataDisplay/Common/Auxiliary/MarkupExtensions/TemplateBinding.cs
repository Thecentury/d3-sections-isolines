namespace Microsoft.Research.DynamicDataDisplay.MarkupExtensions
{
	using System.Windows;
	using System.Windows.Data;

	public class TemplateBinding : Binding
	{
		public TemplateBinding()
		{
			RelativeSource = new RelativeSource { Mode = RelativeSourceMode.TemplatedParent };
		}

		public TemplateBinding(string propertyPath)
			: this()
		{
			Path = new PropertyPath(propertyPath);
		}
	}
}
