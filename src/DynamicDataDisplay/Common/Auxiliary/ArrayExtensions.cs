namespace Microsoft.Research.DynamicDataDisplay.Common.Auxiliary
{
	using System;
	using System.Collections.Generic;
	using Microsoft.Research.DynamicDataDisplay.Charts;

	internal static class ArrayExtensions
	{
		internal static T Last<T>(this T[] array) {
			return array[array.Length - 1];
		}

		internal static T[] CreateArray<T>(int length, T defaultValue)
		{
			T[] res = new T[length];
			for (int i = 0; i < res.Length; i++)
			{
				res[i] = defaultValue;
			}
			return res;
		}

		internal static IEnumerable<Range<T>> GetPairs<T>(this IList<T> array)
		{
			if (array == null)
				throw new ArgumentNullException("array");

			for (int i = 0; i < array.Count - 1; i++)
			{
				yield return new Range<T>(array[i], array[i + 1]);
			}
		}
	}
}
