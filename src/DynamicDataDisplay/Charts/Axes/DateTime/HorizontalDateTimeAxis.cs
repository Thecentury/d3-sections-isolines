﻿namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System;
	using Microsoft.Research.DynamicDataDisplay.Strings;

	/// <summary>
	/// Represents an axis with ticks of <see cref="System.DateTime"/> type, which can be placed only from bottom or top of <see cref="Plotter"/>.
	/// By default is placed from bottom.
	/// </summary>
	public class HorizontalDateTimeAxis : DateTimeAxis
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HorizontalDateTimeAxis"/> class.
		/// </summary>
		public HorizontalDateTimeAxis()
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
