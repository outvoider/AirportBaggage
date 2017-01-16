using AirportBaggage.Routing;
using AirportBaggage.Models;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AirportBaggageTests
{
	[TestClass]
	public class AnswerUnitTest
	{
		[TestMethod]
		public void TestToString()
		{
			var a = new Answer(new List<Route>() { new Route("0003", new List<string>() { "A2", "A1" }, 1) });
			Assert.AreEqual("0003 A2 A1 : 1" + Environment.NewLine, a.ToString());
		}

		[TestMethod]
		public void TestBag()
		{
			var p = new List<string>() { "A2", "A1" };
			var r = new Route("0003", p, 1);
			var a = new Answer(new List<Route>() { r });
			Assert.IsTrue(a.Routes.All(t => t != null));
			Assert.AreEqual(r.ToString(), a.Routes.First().ToString());
			try
			{
				new Answer(null);
				Assert.Fail();
			}
			catch { }
			try
			{
				new Answer(new List<Route>() { null });
				Assert.Fail();
			}
			catch { }
		}
	}
}
