using AirportBaggage.Models;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ModelsTests
{
	[TestClass]
	public class RouteUnitTest
	{
		[TestMethod]
		public void TestToString()
		{
			var r = new Route("0003", new List<string>() { "A2", "A1" }, 1);
			Assert.AreEqual("0003 A2 A1 : 1", r.ToString());
			var a = new Route("0003", new List<string>(), 1);
			Assert.AreEqual("0003 : 1", a.ToString());
		}

		[TestMethod]
		public void TestRoute()
		{
			var p = new List<string>() { "A2", "A1" };
			var r = new Route("0003", p, 1);
			Assert.AreEqual("0003", r.BagNumber);
			Assert.IsTrue(r.Points.SequenceEqual(p));
			Assert.AreEqual(1, r.TotalTravelTime);
			try
			{
				new Route(null, p, 1);
				Assert.Fail();
			}
			catch { }
			try
			{
				new Route("0003", null, 1);
				Assert.Fail();
			}
			catch { }
			try
			{
				new Route("0003", p, -1);
				Assert.Fail();
			}
			catch { }
			try
			{
				new Route("0003", new List<string>() { null }, -1);
				Assert.Fail();
			}
			catch { }
		}
	}
}
