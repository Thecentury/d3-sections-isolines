namespace Microsoft.Research.DynamicDataDisplay.MarkupExtensions
{
	using System;
	using System.ComponentModel;
	using System.Windows;
	using System.Windows.Markup;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class XbapConditionalExpression : MarkupExtension
	{
		public XbapConditionalExpression() { }

		public XbapConditionalExpression(object value)
		{
			this.Value = value;
		}

		[ConstructorArgument("value")]
		public object Value { get; set; }

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
#if RELEASEXBAP
			return null;
#else
			return ((ResourceDictionary)Application.LoadComponent(new Uri("/DynamicDataDisplay;component/Themes/Generic.xaml", UriKind.Relative)))[Value];
#endif
		}
	}
}
