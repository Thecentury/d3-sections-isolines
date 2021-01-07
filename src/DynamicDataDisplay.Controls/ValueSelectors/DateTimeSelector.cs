namespace Microsoft.Research.DynamicDataDisplay.Controls
{
	using System;
	using Microsoft.Research.DynamicDataDisplay.Charts;

	/// <summary>
	/// Represents a control for precise selecting <see cref="T:System.DateTime"/> values.
	/// </summary>
	public class DateTimeSelector : GenericValueSelector<DateTime>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DateTimeSelector"/> class.
		/// </summary>
		public DateTimeSelector()
		{
			var axis = new HorizontalDateTimeAxis();
			MainHorizontalAxis = axis;
			ValueConversion = axis;

			Range = new Range<DateTime>(DateTime.Now, DateTime.Now.AddHours(1));
		}
	}
}
