﻿namespace DynamicDataDisplay.Tests.D3
{
	using Microsoft.Research.DynamicDataDisplay;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class DataRectExtensionsTest
	{
		[TestMethod]
		public void TestIsClose()
		{
			DataRect rect1 = new DataRect(0, 0, 1, 1);
			DataRect rect2 = new DataRect(0, 0, 1, 1);

			const double diff = 0.01;

			Assert.IsTrue(rect1.IsCloseTo(rect2, diff));
			Assert.IsTrue(rect1.IsCloseTo(new DataRect(0, 0, 1, 1.005), diff));

			Assert.IsFalse(new DataRect(0, 0, 0.0001, 0.0001).IsCloseTo(DataRect.Empty, 0.1));
			Assert.IsFalse(rect1.IsCloseTo(new DataRect(-0.1, 0, 1, 0.99), 0.1));
		}
	}
}
