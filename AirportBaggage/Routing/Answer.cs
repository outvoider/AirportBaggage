using AirportBaggage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportBaggage.Routing
{
	public class Answer
	{
		public IEnumerable<Route> Routes { get; private set; }

		public Answer(IEnumerable<Route> routes)
		{
			if (routes.Any(r => r == null))
				throw new ArgumentException();
			Routes = routes.ToList();
		}

		public override string ToString()
		{
			var b = new StringBuilder();
			foreach (var r in Routes)
				b.AppendLine(r.ToString());
			return b.ToString();
		}
	}
}
