namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System;

	/// <summary>
	/// Contains default axis value conversions.
	/// </summary>
	public static class DefaultAxisConversions
	{
		#region double

		private static readonly Func<double, double> doubleToDouble = d => d;
		public static Func<double, double> DoubleToDouble => doubleToDouble;

		private static readonly Func<double, double> doubleFromDouble = d => d;
		public static Func<double, double> DoubleFromDouble => doubleFromDouble;

		#endregion

		#region DateTime

		private static readonly long minDateTimeTicks = DateTime.MinValue.Ticks;
		private static readonly long maxDateTimeTicks = DateTime.MaxValue.Ticks;
		private static readonly Func<double, DateTime> dateTimeFromDouble = d =>
		{
			long ticks = (long)(d * 10000000000L);

			// todo should we throw an exception if number of ticks is too big or small?
			if (ticks < minDateTimeTicks)
				ticks = minDateTimeTicks;
			else if (ticks > maxDateTimeTicks)
				ticks = maxDateTimeTicks;

			return new DateTime(ticks);
		};
		public static Func<double, DateTime> DateTimeFromDouble => dateTimeFromDouble;

		private static readonly Func<DateTime, double> dateTimeToDouble = dt => dt.Ticks / 10000000000.0;
		public static Func<DateTime, double> DateTimeToDouble => dateTimeToDouble;

		#endregion

		#region TimeSpan

		private static readonly long minTimeSpanTicks = TimeSpan.MinValue.Ticks;
		private static readonly long maxTimeSpanTicks = TimeSpan.MaxValue.Ticks;

		private static readonly Func<double, TimeSpan> timeSpanFromDouble = d =>
		{
			long ticks = (long)(d * 10000000000L);

			// todo should we throw an exception if number of ticks is too big or small?
			if (ticks < minTimeSpanTicks)
				ticks = minTimeSpanTicks;
			else if (ticks > maxTimeSpanTicks)
				ticks = maxTimeSpanTicks;

			return new TimeSpan(ticks);
		};

		public static Func<double, TimeSpan> TimeSpanFromDouble => timeSpanFromDouble;

		private static readonly Func<TimeSpan, double> timeSpanToDouble = timeSpan =>
		{
			return timeSpan.Ticks / 10000000000.0;
		};

		public static Func<TimeSpan, double> TimeSpanToDouble => timeSpanToDouble;

		#endregion

		#region integer

		private readonly static Func<double, int> intFromDouble = d => (int)d;
		public static Func<double, int> IntFromDouble => intFromDouble;

		private readonly static Func<int, double> intToDouble = i => (double)i;
		public static Func<int, double> IntToDouble => intToDouble;

		#endregion
	}
}
