namespace Microsoft.Research.DynamicDataDisplay.Maps
{
	using System.Diagnostics;

	public sealed class MapsTraceSource
	{
		private MapsTraceSource()
		{
		}

		private static readonly MapsTraceSource instance = new MapsTraceSource();
		public static MapsTraceSource Instance => instance;

		private readonly TraceSource serverInformationTraceSource = new TraceSource("D3.Maps.Server", SourceLevels.Information);
		public TraceSource ServerInformationTraceSource => serverInformationTraceSource;
	}
}
