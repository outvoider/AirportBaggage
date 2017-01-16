using AirportBaggage.Models;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelsTests
{
	[TestClass]
	public class PathUnitTest
	{
		[TestMethod]
		public void TestParse()
		{
			var p = Path.Parse(" A5 A10 4 ");
			Assert.AreEqual("A5", p.Node1);
			Assert.AreEqual("A10", p.Node2);
			Assert.AreEqual(4, p.TravelTime);
			try
			{
				Path.Parse(" A5 A10");
				Assert.Fail();
			}
			catch { }
			try
			{
				Path.Parse(" A5 A10 4 Q1");
				Assert.Fail();
			}
			catch { }
			try
			{
				Path.Parse(" A5 A10 Q1");
				Assert.Fail();
			}
			catch { }
			try
			{
				Path.Parse(" A5 A10 -4");
				Assert.Fail();
			}
			catch { }
		}

		[TestMethod]
		public void TestPath()
		{
			var p = new Path("A5", "A10", 4);
			Assert.AreEqual("A5", p.Node1);
			Assert.AreEqual("A10", p.Node2);
			Assert.AreEqual(4, p.TravelTime);
			try
			{
				new Path(null, "A10", 4);
				Assert.Fail();
			}
			catch { }
			try
			{
				new Path("A5", null, 4);
				Assert.Fail();
			}
			catch { }
			try
			{
				new Path("A5", "A10", -4);
				Assert.Fail();
			}
			catch { }
		}
	}
}
