namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System;
	using Microsoft.Research.DynamicDataDisplay.Charts.Axes;

	public abstract class DateTimeLabelProviderBase : LabelProviderBase<DateTime>
	{
		private string dateFormat;
		protected string DateFormat
		{
			get => dateFormat;
			set => dateFormat = value;
		}

		protected override string GetStringCore(LabelTickInfo<DateTime> tickInfo)
		{
			return tickInfo.Tick.ToString(dateFormat);
		}

		protected virtual string GetDateFormat(DifferenceIn diff)
		{
			string format = null;

			switch (diff)
			{
				case DifferenceIn.Year:
					format = "yyyy";
					break;
				case DifferenceIn.Month:
					format = "MMM";
					break;
				case DifferenceIn.Day:
					format = "%d";
					break;
				case DifferenceIn.Hour:
					format = "HH:mm";
					break;
				case DifferenceIn.Minute:
					format = "%m";
					break;
				case DifferenceIn.Second:
					format = "ss";
					break;
				case DifferenceIn.Millisecond:
					format = "fff";
					break;
			}

			return format;
		}
	}
}
