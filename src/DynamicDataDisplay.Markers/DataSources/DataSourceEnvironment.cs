namespace DynamicDataDisplay.Markers.DataSources
{
	using Microsoft.Research.DynamicDataDisplay;

	internal class DataSourceEnvironment : IDataSourceEnvironment
	{
		#region IDataSourceEnvironment Members

		private Plotter2D plotter;
		public Plotter2D Plotter
		{
			get => plotter;
			internal set => this.plotter = value;
		}

		private bool firstDraw;
		public bool FirstDraw
		{
			get => firstDraw;
			internal set => firstDraw = value;
		}

		#endregion
	}
}
