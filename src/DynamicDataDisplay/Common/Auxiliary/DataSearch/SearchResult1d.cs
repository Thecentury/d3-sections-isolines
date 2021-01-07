namespace Microsoft.Research.DynamicDataDisplay.Common.DataSearch
{
	using System;

	internal struct SearchResult1d
	{
		public static SearchResult1d Empty => new SearchResult1d { Index = -1 };

		public int Index { get; internal set; }

		public bool IsEmpty => Index == -1;

		public override string ToString()
		{
			if (IsEmpty)
				return "Empty";

			return String.Format("Index = {0}", Index);
		}
	}
}
