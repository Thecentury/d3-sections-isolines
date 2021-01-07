namespace Microsoft.Research.DynamicDataDisplay.Maps.Servers
{
	using System;
	using Microsoft.Research.DynamicDataDisplay.Charts.Maps;

	public sealed class ModeChangedEventArgs : EventArgs
	{
		private readonly TileSystemMode mode;
		public ModeChangedEventArgs(TileSystemMode mode)
		{
			this.mode = mode;
		}

		public TileSystemMode Mode => mode;
	}
}
