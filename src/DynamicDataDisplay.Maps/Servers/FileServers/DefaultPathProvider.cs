namespace Microsoft.Research.DynamicDataDisplay.Maps.Servers.FileServers
{
	using System.IO;
	using System.Text;
	using Microsoft.Research.DynamicDataDisplay.Charts.Maps;

	public sealed class DefaultPathProvider : TilePathProvider
	{
		public override string GetTilePath(TileIndex id)
		{
			StringBuilder builder = new StringBuilder("z");

			builder = builder.Append(id.Level).Append(Path.DirectorySeparatorChar).Append(id.X).Append('x').Append(id.Y);

			return builder.ToString();
		}
	}
}
