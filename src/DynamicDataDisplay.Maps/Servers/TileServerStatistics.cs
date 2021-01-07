﻿namespace Microsoft.Research.DynamicDataDisplay.Charts.Maps
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Text;

	public sealed class TileServerStatistics
	{
		private readonly StatisticsDictionary<int> intValues = new StatisticsDictionary<int>();
		public StatisticsDictionary<int> IntValues => intValues;

		private readonly StatisticsDictionary<long> longValues = new StatisticsDictionary<long>();
		public StatisticsDictionary<long> LongValues => longValues;

		private readonly StatisticsDictionary<double> doubleValues = new StatisticsDictionary<double>();
		public StatisticsDictionary<double> DoubleValues => doubleValues;

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			foreach (var item in intValues)
			{
				builder.AppendFormat("{0}: {1}", item.Key, item.Value);
				builder.AppendLine();
			}
			foreach (var item in longValues)
			{
				builder.AppendFormat("{0}: {1}", item.Key, item.Value);
				builder.AppendLine();
			}
			foreach (var item in doubleValues)
			{
				builder.AppendFormat("{0}: {1}", item.Key, item.Value);
				builder.AppendLine();
			}

			if (builder.Length == 0)
				builder.Append("Empty statistics");

			return builder.ToString();
		}
	}

	public sealed class StatisticsDictionary<T> : IEnumerable<KeyValuePair<string, T>>
	{
		private readonly Dictionary<string, T> cache = new Dictionary<string, T>();

		public T this[string name]
		{
			get
			{
				if (!cache.ContainsKey(name))
					cache.Add(name, default(T));

				return cache[name];
			}
			set => cache[name] = value;
		}

		public IEnumerable<string> GetNames()
		{
			return cache.Keys;
		}

		#region IEnumerable<KeyValuePair<string,T>> Members

		public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
		{
			return cache.GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion
	}
}
