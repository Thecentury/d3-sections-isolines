﻿namespace DynamicDataDisplay.Test.D3
{
	using Microsoft.Research.DynamicDataDisplay.Common;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class D3CollectionTest
	{
		public class CustomCollection : D3Collection<int>
		{
			public int addingCalled;
			public int addedCalled;
			public int removedCalled;

			protected override void OnItemAdding(int item)
			{
				addingCalled++;
			}

			protected override void OnItemAdded(int item)
			{
				addedCalled++;
			}

			protected override void OnItemRemoving(int item)
			{
				removedCalled++;
			}
		}

		[TestMethod]
		public void TestCalls()
		{
			CustomCollection coll = new CustomCollection();
			coll.Add(1);

			Assert.IsTrue(coll.addedCalled == 1);
			Assert.IsTrue(coll.addingCalled == 1);

			coll.Add(2);
			Assert.IsTrue(coll.addedCalled == 2);
			Assert.IsTrue(coll.addingCalled == 2);
			Assert.IsTrue(coll.removedCalled == 0);

			coll.Remove(1);
			Assert.IsTrue(coll.removedCalled == 1);
			Assert.IsTrue(coll.addedCalled == 2);
			Assert.IsTrue(coll.addingCalled == 2);

			coll[0] = 3;
			Assert.IsTrue(coll.addedCalled == 3);
			Assert.IsTrue(coll.removedCalled == 2);
			Assert.IsTrue(coll.addingCalled == 3);

			coll.Clear();
			Assert.IsTrue(coll.removedCalled == 3);
			Assert.IsTrue(coll.addedCalled == 3);
			Assert.IsTrue(coll.Count == 0);
			Assert.IsTrue(coll.addingCalled == 3);

			coll.addedCalled = 0;
			coll.addingCalled = 0;
			coll.removedCalled = 0;

			coll.Add(1);
			coll.Add(2);
			coll.Add(3);
			coll.Add(4);

			Assert.IsTrue(coll.addedCalled == 4);
			coll.Clear();
			Assert.IsTrue(coll.removedCalled == 4);
		}
	}
}
