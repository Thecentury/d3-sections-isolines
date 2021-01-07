namespace Microsoft.Research.DynamicDataDisplay.Common.Auxiliary
{
	using System;
	using System.Diagnostics;
	using Microsoft.Research.DynamicDataDisplay.Strings;

	internal static class Verify
	{
		[DebuggerStepThrough]
		public static void IsTrue(this bool condition)
		{
			if (!condition)
			{
				throw new ArgumentException(Exceptions.AssertionFailedSearch);
			}
		}

		[DebuggerStepThrough]
		public static void IsTrue(this bool condition, string paramName)
		{
			if (!condition)
			{
				throw new ArgumentException(Exceptions.AssertionFailedSearch, paramName);
			}
		}

		public static void IsTrueWithMessage(this bool condition, string message)
		{
			if (!condition)
				throw new ArgumentException(message);
		}

		[DebuggerStepThrough]
		public static void AssertNotNull(object obj)
		{
			(obj != null).IsTrue();
		}

		public static void VerifyNotNull(this object obj, string paramName)
		{
			if (obj == null)
				throw new ArgumentNullException(paramName);
		}

		public static void VerifyNotNull(this object obj)
		{
			VerifyNotNull(obj, "value");
		}

		[DebuggerStepThrough]
		public static void AssertIsNotNaN(this double d)
		{
			(!Double.IsNaN(d)).IsTrue();
		}

		[DebuggerStepThrough]
		public static void AssertIsFinite(this double d)
		{
			(!Double.IsInfinity(d) && !(Double.IsNaN(d))).IsTrue();
		}
	}
}
