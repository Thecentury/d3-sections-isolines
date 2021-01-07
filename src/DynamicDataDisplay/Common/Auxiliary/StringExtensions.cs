namespace Microsoft.Research.DynamicDataDisplay.Common.Auxiliary
{
	using System;

	internal static class StringExtensions
	{
		public static string F(this string formatString, object param)
		{
			return String.Format(formatString, param);
		}

		public static string F(this string formatString, object param1, object param2)
		{
			return String.Format(formatString, param1, param2);
		}

		public static string F(this string formatString, params object[] parameters)
		{
			return String.Format(formatString, parameters);
		}
	}
}
