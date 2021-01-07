namespace DynamicDataDisplay.Tests.D3
{
	using Microsoft.Research.DynamicDataDisplay.Charts.Selectors;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class PointSelectorTest
	{
		[TestMethod]
		public void TestModeChangeWhileDisconnected()
		{
			PointSelector selector = new PointSelector();
			selector.Mode = PointSelectorMode.Add;
			selector.Mode = PointSelectorMode.MultipleSelect;
			selector.Mode = PointSelectorMode.Remove;
		}
	}
}
