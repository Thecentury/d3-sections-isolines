namespace Microsoft.Research.DynamicDataDisplay.MarkupExtensions
{
	using System.Windows;
	using System.Windows.Data;

	public class SelfBinding : Binding
	{
		public SelfBinding()
		{
			RelativeSource = new RelativeSource { Mode = RelativeSourceMode.Self };
		}

		public SelfBinding(string propertyPath)
			: this()
		{
			Path = new PropertyPath(propertyPath);
		}
	}
}
