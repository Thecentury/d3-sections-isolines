﻿namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	public class MarkerChart : MarkerChartBase
	{
		public MarkerChart()
		{
			PropertyMappings[IndependentValuePathProperty] = ViewportPanel.XProperty;
			PropertyMappings[DependentValuePathProperty] = ViewportPanel.YProperty;
		}

		private readonly PointSetUpdateHandler updateHandler = new PointSetUpdateHandler();
		protected override DataSourceUpdateHandler GetUpdateHandler()
		{
			return updateHandler;
		}
	}
}
