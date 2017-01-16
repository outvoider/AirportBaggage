using AirportBaggage.Routing;
using AirportBaggage.Models;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportBaggageTests
{
	[TestClass]
	public class InstanceUnitTest
	{
		[TestMethod]
		public void TestParse()
		{
			var i = Instance.Parse(
				"# Section: Conveyor System" + Environment.NewLine +
				"# Section: Departures" + Environment.NewLine +
				"# Section: Bags" + Environment.NewLine);
			Assert.AreEqual(0, i.Bags.Count);
			Assert.AreEqual(0, i.Departures.Count);
			Assert.AreEqual(0, i.Paths.Count);
		}

		[TestMethod]
		public void TestInstance()
		{
			var p = Path.Parse("A5 A10 4");
			var d = Departure.Parse("UA10 A1 MIA 08:00");
			var b = Bag.Parse("0002 A5 UA17");
			var pp = new List<Path>() { p };
			var pn = new List<Path>() { null };
			var dd = new List<Departure>() { d };
			var dn = new List<Departure>() { null };
			var bb = new List<Bag>() { b };
			var bn = new List<Bag>() { null };
			var i = new Instance(pp, dd, bb);
			Assert.IsTrue(i.Paths.All(a => a != null));
			Assert.AreEqual(p.ToString(), i.Paths.First().ToString());
			Assert.AreEqual(d.ToString(), i.Departures.First().ToString());
			Assert.AreEqual(b.ToString(), i.Bags.First().ToString());
			try
			{
				new Instance(null, dd, bb);
				Assert.Fail();
			}
			catch { }
			try
			{
				new Instance(pp, null, bb);
				Assert.Fail();
			}
			catch { }
			try
			{
				new Instance(pp, dd, null);
				Assert.Fail();
			}
			catch { }
			try
			{
				new Instance(pn, dd, bb);
				Assert.Fail();
			}
			catch { }
			try
			{
				new Instance(pp, dn, bb);
				Assert.Fail();
			}
			catch { }
			try
			{
				new Instance(pp, dd, bn);
				Assert.Fail();
			}
			catch { }
		}

		[TestMethod]
		public void TestSolve()
		{
			var b = new StringBuilder();
			b.AppendLine("# Section: Conveyor System");
			b.AppendLine("Concourse_A_Ticketing A5 5");
			b.AppendLine("A5 BaggageClaim 5");
			b.AppendLine("A5 A10 4");
			b.AppendLine("A5 A1 6");
			b.AppendLine("A1 A2 1");
			b.AppendLine("A2 A3 1");
			b.AppendLine("A3 A4 1");
			b.AppendLine("A10 A9 1");
			b.AppendLine("A9 A8 1");
			b.AppendLine("A8 A7 1");
			b.AppendLine("A7 A6 1");
			b.AppendLine("# Section: Departures");
			b.AppendLine("UA10 A1 MIA 08:00");
			b.AppendLine("UA11 A1 LAX 09:00");
			b.AppendLine("UA12 A1 JFK 09:45");
			b.AppendLine("UA13 A2 JFK 08:30");
			b.AppendLine("UA14 A2 JFK 09:45");
			b.AppendLine("UA15 A2 JFK 10:00");
			b.AppendLine("UA16 A3 JFK 09:00");
			b.AppendLine("UA17 A4 MHT 09:15");
			b.AppendLine("UA18 A5 LAX 10:15");
			b.AppendLine("ARRIVAL BaggageClaim XXX 00:00");
			b.AppendLine("# Section: Bags");
			b.AppendLine("0001 Concourse_A_Ticketing UA12");
			b.AppendLine("0002 A5 UA17");
			b.AppendLine("0003 A2 UA10");
			b.AppendLine("0004 A8 UA18");
			b.AppendLine("0005 A7 ARRIVAL");

			var i = Instance.Parse(b.ToString());
			var a = i.Solve();

			var c = new StringBuilder();
			c.AppendLine("0001 Concourse_A_Ticketing A5 A1 : 11");
			c.AppendLine("0002 A5 A1 A2 A3 A4 : 9");
			c.AppendLine("0003 A2 A1 : 1");
			c.AppendLine("0004 A8 A9 A10 A5 : 6");
			c.AppendLine("0005 A7 A8 A9 A10 A5 BaggageClaim : 12");

			Assert.AreEqual(c.ToString(), a.ToString());
		}
	}
}
