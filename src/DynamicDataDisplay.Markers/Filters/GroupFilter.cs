namespace Microsoft.Research.DynamicDataDisplay.Charts.Filters
{
	public abstract class GroupFilter : PointsFilter2d
	{
		private double markerSize = 10; // px
		public double MarkerSize
		{
			get => markerSize;
			set
			{
				markerSize = value;
				RaiseChanged();
			}
		}
	}
}
