namespace Microsoft.Research.DynamicDataDisplay.Charts.Axes
{
	using System;
	using Microsoft.Research.DynamicDataDisplay.Strings;

	public class VerticalIntegerAxis : IntegerAxis
	{
		public VerticalIntegerAxis()
		{
			Placement = AxisPlacement.Left;
		}

		protected override void ValidatePlacement(AxisPlacement newPlacement)
		{
			if (newPlacement == AxisPlacement.Bottom || newPlacement == AxisPlacement.Top)
				throw new ArgumentException(Exceptions.VerticalAxisCannotBeHorizontal);
		}
	}
}
