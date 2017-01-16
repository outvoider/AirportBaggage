using AirportBaggage.Models;
using AirportBaggage.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportBaggage
{
	public class Program
	{
		static void Main(string[] args)
		{
			var p = Instance.Parse(Console.In.ReadToEnd());
			// I would rather just add an additional section in the input to handle this.
			p.Departures.Add(Departure.Parse("ARRIVAL BaggageClaim XXX 00:00"));
			var s = p.Solve();
			Console.Write(s);
		}
	}
}
