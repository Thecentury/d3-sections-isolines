﻿namespace Microsoft.Research.DynamicDataDisplay.Maps
{
	using System.Diagnostics;
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Charts.Maps;

	[DebuggerDisplay("Tile = {Tile}, Screen = {ScreenBounds}, Visible = {VisibleBounds}")]
	public sealed class VisibleTileInfo
	{
		public TileIndex Tile { get; set; }
		public Rect ScreenBounds { get; set; }
		public DataRect VisibleBounds { get; set; }
	}
}
