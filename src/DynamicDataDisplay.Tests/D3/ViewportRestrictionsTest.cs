namespace DynamicDataDisplay.Test.D3
{
	using System;
	using Microsoft.Research.DynamicDataDisplay;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class ViewportConstraintsTest
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void TestAddingNull()
		{
			ChartPlotter plotter = new ChartPlotter();
			bool thrown = false;
			try
			{
				plotter.Viewport.Constraints.Add(null);
			}
			catch (ArgumentNullException)
			{
				thrown = true;
			}

			Assert.IsTrue(thrown);
		}
	}
}
