namespace Microsoft.Research.DynamicDataDisplay.Common.Auxiliary
{
	using Microsoft.Research.DynamicDataDisplay.Charts;

	internal static class PlacementExtensions
	{
		public static bool IsBottomOrTop(this AxisPlacement placement)
		{
			return placement == AxisPlacement.Bottom || placement == AxisPlacement.Top;
		}
	}
}
