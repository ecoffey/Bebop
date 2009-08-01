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
		public override IEnumerable<BebopRoute> Map(BebopRouteFactory routeFactory)
		{
			yield return routeFactory.Create<BlahView>("blah/{d}");
		}

		protected override void Load(ContainerBuilder builder)
		{
			builder.Register<SomeService>();
		}
	}
}
