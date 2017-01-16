using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace SolutionsTests
{
	[TestClass]
	public class FloydWarshallUnitTest
	{
		[TestMethod]
		public void TestFloydWarshall()
		{
			var ee = new int[] { 0, 2, 2, 3, 3, 1, 1, 0, 1, 2 };
			var en = new int[] { -1, 2, 2, 3, 3, 1, 1, 0, 1, 2 };
			var ww = new int[] { -2, 2, -1, 4, 3 };
			var fw = new Solutions.Graph.FloydWarshall(ee, ww);
			Assert.IsFalse(fw.HasNegativeCycle);
			Assert.IsTrue(fw.HasPath(0, 0));
			Assert.IsTrue(fw.HasPath(0, 1));
			Assert.AreEqual(0, fw.GetDistance(0, 0));
			Assert.AreEqual(-1, fw.GetDistance(0, 1));
			Assert.AreEqual(-2, fw.GetDistance(0, 2));
			Assert.AreEqual(0, fw.GetDistance(0, 3));
			Assert.AreEqual(4, fw.GetDistance(1, 0));
			Assert.AreEqual(0, fw.GetDistance(1, 1));
			Assert.AreEqual(2, fw.GetDistance(1, 2));
			Assert.AreEqual(4, fw.GetDistance(1, 3));
			Assert.AreEqual(5, fw.GetDistance(2, 0));
			Assert.AreEqual(1, fw.GetDistance(2, 1));
			Assert.AreEqual(0, fw.GetDistance(2, 2));
			Assert.AreEqual(2, fw.GetDistance(2, 3));
			Assert.AreEqual(3, fw.GetDistance(3, 0));
			Assert.AreEqual(-1, fw.GetDistance(3, 1));
			Assert.AreEqual(1, fw.GetDistance(3, 2));
			Assert.AreEqual(0, fw.GetDistance(3, 3));
			Assert.IsTrue(fw.GetPath(0, 0).SequenceEqual(new int[] { 0 }));
			Assert.IsTrue(fw.GetPath(0, 1).SequenceEqual(new int[] { 0, 2, 3, 1 }));
			try
			{
				new Solutions.Graph.FloydWarshall(null, ww);
				Assert.Fail();
			}
			catch { }
			try
			{
				new Solutions.Graph.FloydWarshall(ee, null);
				Assert.Fail();
			}
			catch { }
			try
			{
				new Solutions.Graph.FloydWarshall(en, ww);
				Assert.Fail();
			}
			catch { }
		}
	}
}
