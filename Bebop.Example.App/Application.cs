using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using Autofac.Builder;

namespace Bebop.Example.App
{
	public sealed class Application : BebopApplication
	{
		public override IEnumerable<Route> Map(RouteCollection routes)
		{
			yield return routes.Map<BlahView>("blah/{d}");
		}
	}
}
