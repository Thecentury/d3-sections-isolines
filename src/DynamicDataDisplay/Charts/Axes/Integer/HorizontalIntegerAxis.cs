namespace Microsoft.Research.DynamicDataDisplay.Charts.Axes
{
	using System;
	using Microsoft.Research.DynamicDataDisplay.Strings;

	public class HorizontalIntegerAxis : IntegerAxis
	{
		public HorizontalIntegerAxis()
		{
			Placement = AxisPlacement.Bottom;
		}

		protected override void ValidatePlacement(AxisPlacement newPlacement)
		{
			if (newPlacement == AxisPlacement.Left || newPlacement == AxisPlacement.Right)
				throw new ArgumentException(Exceptions.HorizontalAxisCannotBeVertical);
		}
	}
}
