namespace DynamicDataDisplay.Tests.D3
{
	using System.Diagnostics;
	using System.Linq;
	using Microsoft.Research.DynamicDataDisplay.Common.Auxiliary;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class SplitEnumeratorTest
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void TestMethod()
		{
			var source = Enumerable.Range(0, 200);
			var split = source.Split(10);
			foreach (var item in split)
			{
				Debug.WriteLine("Item");
				Debug.Indent();
				foreach (var subitem in item)
				{
					Debug.WriteLine(subitem);
				}
				Debug.Unindent();
			}
		}
	}
}
