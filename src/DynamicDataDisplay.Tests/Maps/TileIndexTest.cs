﻿namespace DynamicDataDisplay.Tests.Maps
{
	using Microsoft.Research.DynamicDataDisplay.Charts.Maps;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class TileIndexTest
	{
		[TestMethod]
		public void TestGetLowerTile()
		{
			var tile = new TileIndex(-1, -1, 1);
			var lowerTile = tile.GetLowerTile();

			Assert.AreEqual(new TileIndex(-1, -1, 0), lowerTile);

			Assert.AreEqual(new TileIndex(0, 0, 0), new TileIndex(1, 1, 1).GetLowerTile());
		}
	}
}
