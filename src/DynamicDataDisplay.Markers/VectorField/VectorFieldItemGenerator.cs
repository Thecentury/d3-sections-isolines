﻿namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System.Windows;
	using System.Windows.Data;
	using global::DynamicDataDisplay.Markers;

	public class VectorFieldItemGenerator : MarkerGenerator
	{
		protected override FrameworkElement CreateMarkerCore(object dataItem)
		{
			VectorFieldChartItem item = new VectorFieldChartItem();
			item.SetBinding(VectorFieldChartItem.StartPointProperty, locationBinding);
			item.SetBinding(VectorFieldChartItem.DirectionProperty, directionBinding);

			item.DataContext = dataItem;

			return item;
		}

		public string LocationPath { get; set; }
		public string DirectionPath { get; set; }

		private Binding locationBinding;
		private Binding directionBinding;

		public override void EndInit()
		{
			locationBinding = new Binding(LocationPath);
			directionBinding = new Binding(DirectionPath);
		}
	}
}
