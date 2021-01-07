namespace Microsoft.Research.DynamicDataDisplay.Common
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Windows;

	[DebuggerDisplay("Count = {Cache.Count}")]
	public sealed class VisualBindingCollection
	{
		private Dictionary<IPlotterElement, UIElement> cache = new Dictionary<IPlotterElement, UIElement>();

		internal Dictionary<IPlotterElement, UIElement> Cache => cache;

		public UIElement this[IPlotterElement element] => cache[element];

		public bool Contains(IPlotterElement element)
		{
			return cache.ContainsKey(element);
		}
	}
}
