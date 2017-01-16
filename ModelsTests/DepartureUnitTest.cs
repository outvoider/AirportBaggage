using AirportBaggage.Models;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelsTests
{
	[TestClass]
	public class DepartureUnitTest
	{
		[TestMethod]
		public void TestParse()
		{
			var d = Departure.Parse("UA10 A1 MIA 08:00 ");
			Assert.AreEqual("UA10", d.FlightId);
			Assert.AreEqual("A1", d.FlightGate);
			Assert.AreEqual("MIA", d.Destination);
			Assert.AreEqual(DateTime.Parse("08:00"), d.FlightTime);
			try
			{
				Departure.Parse("UA10 A1");
				Assert.Fail();
			}
			catch { }
			try
			{
				Departure.Parse("UA10 A1 MIA 08:00 Q01");
				Assert.Fail();
			}
			catch { }
			try
			{
				Departure.Parse("UA10 A1 MIA Q01");
				Assert.Fail();
			}
			catch { }
		}

		[TestMethod]
		public void TestDeparture()
		{
			var d = new Departure("UA10", "A1", "MIA", DateTime.Parse("08:00"));
			Assert.AreEqual("UA10", d.FlightId);
			Assert.AreEqual("A1", d.FlightGate);
			Assert.AreEqual("MIA", d.Destination);
			Assert.AreEqual(DateTime.Parse("08:00"), d.FlightTime);
			try
			{
				new Departure(null, "A1", "MIA", DateTime.Parse("08:00"));
				Assert.Fail();
			}
			catch { }
			try
			{
				new Departure("UA10", null, "MIA", DateTime.Parse("08:00"));
				Assert.Fail();
			}
			catch { }
			try
			{
				new Departure("UA10", "A1", null, DateTime.Parse("08:00"));
				Assert.Fail();
			}
			catch { }
		}
	}
}
