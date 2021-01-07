namespace DynamicDataDisplay.Test.D3
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	internal static class AssertExtensions
	{
		public static void AssertIsTrue(this bool expression)
		{
			Assert.IsTrue(expression);
		}
	}
}
