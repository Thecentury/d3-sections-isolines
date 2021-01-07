namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System;

	public sealed class RemoveAll : IPlotterElement
	{
		private Type type;
		[NotNull]
		public Type Type
		{
			get => type;
			set
			{
				if (value == null)
					throw new ArgumentNullException("value");
	
				type = value;
			}
		}

		private Plotter plotter;
		public Plotter Plotter => plotter;

		public void OnPlotterAttached(Plotter plotter)
		{
			this.plotter = plotter;
			if (type != null)
			{
				plotter.Children.RemoveAll(type);
			}
		}

		public void OnPlotterDetaching(Plotter plotter)
		{
			this.plotter = null;
		}
	}
}
