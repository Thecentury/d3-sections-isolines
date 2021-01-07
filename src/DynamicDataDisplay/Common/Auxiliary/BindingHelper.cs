namespace Microsoft.Research.DynamicDataDisplay.Common.Auxiliary
{
	using System.Windows;
	using System.Windows.Data;

	public static class BindingHelper
	{
		public static Binding CreateAttachedPropertyBinding(DependencyProperty attachedProperty)
		{
			return new Binding { Path = new PropertyPath("(0)", attachedProperty) };
		}
	}
}
