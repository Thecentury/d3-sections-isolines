﻿namespace DynamicDataDisplay.Tests.Maps
{
	using System.Linq;
	using Microsoft.Research.DynamicDataDisplay;
	using Microsoft.Research.DynamicDataDisplay.Maps.Charts.TiledRendering;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class RenderTileProviderTest
	{
		[TestMethod]
		public void TestGetTiles()
		{
			RenderTileProvider provider = new RenderTileProvider();
			var tiles = provider.GetTilesForRegion(new DataRect(0, 0, 1, 1), provider.Level).ToArray();
		}
	}
}
