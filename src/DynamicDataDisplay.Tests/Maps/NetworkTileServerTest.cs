namespace DynamicDataDisplay.Tests.Maps
{
	using System;
	using Microsoft.Research.DynamicDataDisplay.Charts.Maps.Network;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class NetworkTileServerTest
	{
		[TestMethod]
		public void TestGCCollectsServer()
		{
			var server = new OpenStreetMapServer();
			WeakReference reference = new WeakReference(server);
			server.Dispose();
			server = null;

			GC.Collect(2);
			GC.WaitForPendingFinalizers();
			GC.Collect(2);

			Assert.IsFalse(reference.IsAlive);
		}
	}
}
