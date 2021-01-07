namespace Microsoft.Research.DynamicDataDisplay.Common.Auxiliary
{
	using System;
	using System.Diagnostics;
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Strings;

	internal static class DebugVerify
	{
		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public static void Is(bool condition)
		{
			if (!condition)
			{
				throw new ArgumentException(Exceptions.AssertionFailed);
			}
		}

		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public static void IsNotNaN(double d)
		{
			Is(!Double.IsNaN(d));
		}

		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public static void IsNotNaN(Vector vec)
		{
			IsNotNaN(vec.X);
			IsNotNaN(vec.Y);
		}

		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public static void IsNotNaN(Point point)
		{
			IsNotNaN(point.X);
			IsNotNaN(point.Y);
		}

		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public static void IsFinite(double d)
		{
			Is(!Double.IsInfinity(d) && !(Double.IsNaN(d)));
		}

		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public static void IsNotNull(object obj)
		{
			Is(obj != null);
		}
	}
}
