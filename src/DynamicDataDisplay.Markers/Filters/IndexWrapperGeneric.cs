namespace Microsoft.Research.DynamicDataDisplay.Filters
{
	using System.Diagnostics;

	[DebuggerDisplay("Data={Data}, Index={Index}")]
	public struct IndexWrapper<T>
	{
		public T Data { get; set; }
		public int Index { get; set; }
	}
}
