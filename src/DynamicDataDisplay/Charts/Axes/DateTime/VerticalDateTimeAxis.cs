namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System;
	using Microsoft.Research.DynamicDataDisplay.Strings;
	using Microsoft.Research.DynamicDataDisplay.ViewportConstraints;

	public class VerticalDateTimeAxis : DateTimeAxis
	{
		public VerticalDateTimeAxis()
		{
			Placement = AxisPlacement.Left;
			Constraint = new DateTimeVerticalAxisConstraint();
		}

		protected override void ValidatePlacement(AxisPlacement newPlacement)
		{
			if (newPlacement == AxisPlacement.Bottom || newPlacement == AxisPlacement.Top)
				throw new ArgumentException(Exceptions.VerticalAxisCannotBeHorizontal);
		}
	}
}
