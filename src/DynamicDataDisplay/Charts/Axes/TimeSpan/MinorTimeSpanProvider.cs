﻿namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System;

	internal sealed class MinorTimeSpanTicksProvider : MinorTimeProviderBase<TimeSpan>
	{
		public MinorTimeSpanTicksProvider(ITicksProvider<TimeSpan> owner) : base(owner) { }

		protected override bool IsInside(TimeSpan value, Range<TimeSpan> range)
		{
			return range.Min < value && value < range.Max;
		}
	}
}
