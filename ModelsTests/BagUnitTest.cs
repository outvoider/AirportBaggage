using AirportBaggage.Models;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelsTests
{
	[TestClass]
	public class BagUnitTest
	{
		[TestMethod]
		public void TestParse()
		{
			var b = Bag.Parse(" 0002 A5 UA17 ");
			Assert.AreEqual("0002", b.BagNumber);
			Assert.AreEqual("A5", b.EntryPoint);
			Assert.AreEqual("UA17", b.FlightId);
			try
			{
				Bag.Parse(" A5 UA17");
				Assert.Fail();
			}
			catch { }
			try
			{
				Bag.Parse("0002 A5 UA17 Q01");
				Assert.Fail();
			}
			catch { }
		}

		[TestMethod]
		public void TestBag()
		{
			var b = new Bag("0002", "A5", "UA17");
			Assert.AreEqual("0002", b.BagNumber);
			Assert.AreEqual("A5", b.EntryPoint);
			Assert.AreEqual("UA17", b.FlightId);
			try
			{
				new Bag(null, "A5", "UA17");
				Assert.Fail();
			}
			catch { }
			try
			{
				new Bag("0002", null, "UA17");
				Assert.Fail();
			}
			catch { }
			try
			{
				new Bag("0002", "A5", null);
				Assert.Fail();
			}
			catch { }
		}
	}
}
