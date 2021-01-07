﻿namespace DynamicDataDisplay.Tests.D3
{
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class DataRectTest
	{
		[TestMethod]
		public void TestInfiniteRectContainsEverything()
		{
			var infinite = DataRect.Infinite;

			Assert.IsTrue(infinite.Contains(new DataRect(0, 0, 1, 1)));
			Assert.IsTrue(infinite.Contains(new DataRect(-100, -100, 1, 1)));
			Assert.IsTrue(infinite.Contains(new Point(0, 0)));
		}
	}
}
