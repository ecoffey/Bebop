using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bebop;

namespace Example.App
{
	public class Index : Resource
	{
		public override IResourceResponse Get(ResourceRequestContext context)
		{
			return new SimpleResponse("blah");
		}
	}

	public class ExampleApplication : BebopApplication
	{
		public override IEnumerable<BebopRoute> Map(BebopRouteFactory routeFactory)
		{
			yield return routeFactory.Create<Index>("");
		}
	}
}
